using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Winnetou.WebControls.WebModalControls
{
    /// <summary>
    /// Helper class for WebModal Windows.  Only one control for each modal window is necessary.  This control
    /// gives access to the Properties collection, OutputData, and the ability to cause the main window to postback on close.
    /// </summary>
    [
    DefaultProperty("CloseForm"),
    ToolboxData("<{0}:WebModalResult runat=\"server\"></{0}:WebModalResult>"),
    ToolboxBitmap(typeof(WebModalResult), "Toolbox.WebModalWindowHelper.bmp"),
    Designer(typeof(WebModalResultDesigner))
    ]
    public class WebModalResult : WebControl
    {
        #region Variables
        private Properties _PropertiesIncoming;
        private Properties _PropetiesSend;
        private bool _closeForm = false;
        //private bool _IsClientResult = false;
        private string _OutValueId = string.Empty;
        private string _OutValueName = string.Empty;

        // This javascript is used to send data back to the main page.  takes hidden input data
        // and attaches it to the window return object.


//        private static string _javascript = @"
//				<script language=""javascript"">
//					var returnValue = new Object;
//					window.parent.returnValue = returnValue;
//
//					function windowOnLoad()
//					{
//						returnValue.OutPutValueId = document.all(""___OutPutValueId"").value;
//                        returnValue.OutValueName = document.all(""___OutPutValueName"").value;
//                        returnValue.WebModalData = document.all(""__WebModalData_ForHelper"").value;
//						window.parent.close();
//					}
//					window.onload = windowOnLoad;
//					
//				</script>";

        private static string _javascript = @"
        				<script language=""javascript"">
        					var returnValue = new Object;
        					window.parent.returnValue = returnValue;
        
        					function windowOnLoad()
        					{
        						returnValue.OutPutValueId = '{OutPutValueId}';
                                returnValue.OutValueName = '{OutValueName}';
                                returnValue.WebModalData = '{WebModalData}';
        						window.parent.close();
        					}
        					window.onload = windowOnLoad;
        					
        				</script>";



        //This is rendered when __LoadIFrame=True is discovered in the querystring.  In order for a modal window to allow postbacks
        //to function correctly, they must be loaded in an IFrame.  In effect the modal window URL gets called twice:
        //Once to render only this Html, and then the second time it loads within the IFrame.
        private static string iFrameHtml = @"
			<html>
				<head>
					<title></title>
					<script language=""javascript"">
						function body_onload()
						{
							
                            window.parent.returnValue = """";
                            if(window.dialogArguments != null && window.dialogArguments.Properties != null)
							    document.WebModalForm.__Properties.value = window.dialogArguments.Properties;
                            document.WebModalForm.__IsClientResult.value = '{IsClientResult}';
							document.WebModalForm.submit();
						}
					</script>
					</head>
				<body style=""margin: 0px"" onload=""body_onload();"">
					<form action=""ActionParam"" target=""WebModalIFrame"" method=""post"" id=""WebModalForm"" name=""WebModalForm"" >
						<input type=""hidden"" id=""__Properties"" name=""__Properties"" >
                        <input type=""hidden"" id=""__IsClientResult"" name=""__IsClientResult"" >
					</form>
					<iframe scrolling=""ScrollingParam"" id=""WebModalIFrame"" name=""WebModalIFrame"" style=""margin: 0px;width:100%;height:100%"" frameborder=""no""></iframe>
				</body>
			</html>";
        #endregion
        #region Properties

        /// <summary>
        /// Collection of Property(string Key, string Value) objects send to Modal Window.
        /// </summary>
        [
        Bindable(true),
        Browsable(true),
        Category("Window"),
        Editor(typeof(PropertyCollectionEditor), typeof(UITypeEditor)),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        PersistenceMode(PersistenceMode.InnerDefaultProperty),
        Description("Collection of Property(string Key, string Value) objects sent to Modal Window.")
        ]
        public Properties PropertiesIncoming
        {
            get
            {
                if (_PropertiesIncoming == null)
                {
                    _PropertiesIncoming = new Properties();
                }
                return _PropertiesIncoming;
            }
        }

        [
        Bindable(true),
        Browsable(true),
        Category("Window"),
        Editor(typeof(PropertyCollectionEditor), typeof(UITypeEditor)),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        PersistenceMode(PersistenceMode.InnerDefaultProperty),
        Description("Collection of Property(string Key, string Value) objects sent to Modal Window.")
        ]
        public Properties PropetiesSend
        {
            get
            {
                if (_PropetiesSend == null)
                {
                    _PropetiesSend = new Properties();
                }
                return _PropetiesSend;
            }
        }

        /// <summary>
        /// Data Returned to anchor from the window
        /// </summary>

        /// <summary>
        /// Should the main window postback when the modal window closes?
        /// </summary>
        [
        Bindable(true),
        Browsable(true),
        Category("Window"),
        DefaultValue("")
        ]
        public bool IsClientResult
        {
            get
            {
                return Manitou.Helper.Converter.ToBollean(ViewState["IsClientResult"]);
            }
            set
            {
                ViewState["IsClientResult"] = value;
            }
        }

        public bool IsModalShow
        {
            get
            {
                return Manitou.Helper.Converter.ToBollean(Page.Request.Params["__IsModalShow"]);
            }
        }

        public bool IsClientResultUrl
        {
            get
            {
                return Manitou.Helper.Converter.ToBollean(Page.Request.Params["__IsClientResult"]);
            }
        }

        /// <summary>
        /// Show the assembly version in the designer?
        /// </summary>
        [
        Bindable(true),
        Browsable(true),
        Category("Window"),
        DefaultValue(""),
        ]
        public string OutValueId
        {
            get { return _OutValueId; }
            set { _OutValueId = value; }
        }

        [
        Bindable(true),
        Browsable(true),
        Category("Window"),
        DefaultValue(""),
        ]
        public string OutValueName
        {
            get { return _OutValueName; }
            set { _OutValueName = value; }
        }
        /// <summary>
        /// If true, modal window will close at appropriate time.
        /// </summary>
        [
        Bindable(true),
        Browsable(true),
        Category("Window"),
        DefaultValue(""),
        Description("If true, modal window will close at appropriate time.")
        ]
        public bool CloseForm
        {
            get
            {
                return _closeForm;
            }
            set
            {
                _closeForm = value;

            }
        }
        #endregion
        #region View State
        protected override object SaveViewState()
        {
            // Save State as a cumulative array of objects.
            object[] SavedState = new object[6];
            SavedState[0] = base.SaveViewState();
            SavedState[1] = this.PropertiesIncoming.Xml;
            SavedState[2] = this.PropetiesSend.Xml;
            SavedState[3] = this.IsClientResult;
            SavedState[4] = this.OutValueId;
            SavedState[5] = this.OutValueName;


            return SavedState;
        }

        protected override void LoadViewState(object SavedState)
        {
            if (SavedState != null)
            {
                // Load State from the array of objects that was saved at SavedViewState.
                object[] state = (object[])SavedState;
                if (state[0] != null) base.LoadViewState(state[0]);
                if (state[1] != null) this.PropertiesIncoming.Xml = (string)state[1];
                if (state[2] != null) this.PropetiesSend.Xml = (string)state[2];
                if (state[3] != null) this.IsClientResult = (bool)state[3];
                if (state[4] != null) this.OutValueId = (string)state[4];
                if (state[5] != null) this.OutValueName = (string)state[5];
            }

        }
        #endregion
        #region Control Events
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //Attach to the helper's Page Class.
            this.Page.Init += new System.EventHandler(this.Page_Init);
            //this.Page.Init += Page_Init;
        }

        //Attach to the helper's Page Class.
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                IsClientResult = Convert.ToBoolean(this.Page.Request.QueryString["__IsClientResult"]);
                if (this.Page.Request.QueryString["__LoadIFrame"] != null)
                {
                    //Page is being loaded into the modalwindow.  Will create an iframe, set the scrolling property, 
                    string Scrolling;
                    if (((!(this.Page.Request.QueryString["__Scrolling"] == null)) && (this.Page.Request.QueryString["__Scrolling"] == "True")))
                    {
                        Scrolling = "yes";
                    }
                    else
                    {
                        Scrolling = "no";
                    }
                    //strip off internal parameters
                    string url = this.Page.Request.Url.ToString();
                    int internalParameters = url.IndexOf("__LoadIFrame");
                    url = url.Substring(0, internalParameters - 1);

                    //Render the IFrame with the adjusted url
                    this.Page.Response.Clear();
                    this.Page.Response.Write(iFrameHtml.Replace("ScrollingParam", Scrolling).Replace("ActionParam", url+"&tc="+DateTime.Now.Ticks).Replace("{IsClientResult}", IsClientResult.ToString()));
                    this.Page.Response.End();
                }
                else
                {
                    //This time, the page is being loaded into the iframe
                    //Load the Properties
                    this.PropertiesIncoming.Xml = System.Web.HttpUtility.UrlDecode(this.Page.Request.Form["__Properties"]);
                }
            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (CloseForm)
            {
                this.Page.ClientScript.RegisterHiddenField("__WebModalData_ForHelper", System.Web.HttpUtility.UrlEncode(PropetiesSend.Xml));
                this.Page.ClientScript.RegisterHiddenField("___OutPutValueId", OutValueId);
                this.Page.ClientScript.RegisterHiddenField("___OutPutValueName", OutValueName);

                if (!this.Page.ClientScript.IsClientScriptBlockRegistered("HandleClose"))
                {
                    this.Page.ClientScript.RegisterClientScriptBlock(GetType(), "HandleClose", _javascript.Replace("{OutPutValueId}", OutValueId).Replace("{OutValueName}", OutValueName).Replace("{WebModalData}", System.Web.HttpUtility.UrlEncode(PropetiesSend.Xml)));
                }
            }
        }
        #endregion

    }

    #region DesignTime


    /// <summary>
    /// Class for displaying WebModalWindowHelper in designer
    /// </summary>
    internal class WebModalResultDesigner : System.Web.UI.Design.ControlDesigner
    {
        #region Overriden methods

        /// <summary>
        /// Returns HTML code to show in designer
        /// </summary>
        public override string GetDesignTimeHtml()
        {
            string s = "<div style=\"padding:6px; background-color: #333333;color:#FFFFFF;font:12px Verdana " +
                "border-style:outset; border-width:1px; font: 75% 'Microsoft Sans Serif';\">&nbsp;<span style=\"color:#FAB301\">CS</span> " + ((Control)Component).ID;
            s += "</div>";
            return s;
        }

        #endregion
    }
    #endregion
}