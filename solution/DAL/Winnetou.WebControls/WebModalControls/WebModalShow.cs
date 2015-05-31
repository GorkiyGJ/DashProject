//===============================================================================
// Copyright © Codesummit
// http://www.codesummit.com
//===============================================================================

using System;
using System.Collections;
using System.ComponentModel.Design;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using System.Web.UI.Design;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;

namespace Winnetou.WebControls.WebModalControls
{
	/// <summary>
	/// Web control which simplifies the complex process of opening a modal window in ASP.Net, and passing information in both directions.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The WebModalAnchor control renders all the necessary javascript
	/// to open modal windows and to move server-side data and/or client-side data
	/// to the modal window and back again. 
	/// </para>
	[
    DefaultProperty("NavigateUrl"),
    ToolboxData("<{0}:WebModalShow runat=\"server\"></{0}:WebModalShow>"), 
	DefaultEvent("OnWindowClose"),
    ToolboxBitmap(typeof(WebModalShow), "Toolbox.WebModalAnchor.bmp"),
    Designer(typeof(WebModalShowDesigner)),
    ParseChildren(true, "PropertiesSend"), //needed by the page parser
	PersistChildren(false) // Needed by the designer
	]
    public class WebModalShow : WebControl, INamingContainer
	{
		#region Variables               
		private bool _scrolling = true;
        private bool  _IsClientResult = false;
        private string _OutControlId = string.Empty;
        private string _OutControlName = string.Empty;
        private Properties _PropertiesSend;
		private string _linkedControlID = "";
		private JSEvent _handledEvent = JSEvent.onclick;
        private Resizable _resizable = Resizable.yes;
        private Unit _windowHeight = 600;
		private Unit _windowWidth = 800;
        private Properties _PropertiesIncoming;
        private string _NavigateUrl = string.Empty;

        public delegate void OnWindowCloseEventHandler(WebModalShow sender);
		public event OnWindowCloseEventHandler OnWindowClose; 

		#endregion
		#region Properties              
		/// <summary>
		/// Should the window have a scrollbar?
		/// </summary>
		[
		Bindable(true),
		Browsable(true),
		Category("Window"),
		DefaultValue(true),
		Description("Should the window have a scrollbar?")
		]
		public bool Scrolling
		{
			get { return _scrolling; }
			set { _scrolling=value; }
		}  
		/// <summary>
		/// Show the assembly version in the designer?
		/// </summary>
		[
		Bindable(true),
		Browsable(true),
		Category("Window"),
		DefaultValue(false),
		Description("Show the assembly version in the designer?")
		]
        public string OutControlName
		{
            get { return _OutControlName; }
            set { _OutControlName = value; }
		}      
		/// <summary>
		/// Enable client-side javascript support?
		/// </summary>
		[
		Bindable(true),
		Browsable(true),
		Category("Window"),
		DefaultValue(false),
		Description("Enable client-side javascript support?")
		]
        public bool IsClientResult
		{
            get { return _IsClientResult; }
            set { _IsClientResult = value; }
		}
		/// <summary>
		/// Text that appears in the window's title bar
		/// </summary>
		[
		Bindable(true),
		Browsable(true),
		Category("Window"),
		DefaultValue("")
		]
        public string OutControlId
		{
			get { return this._OutControlId; }
			set { this._OutControlId = value; }
		}
		
		
        [
		Bindable(true),
		Browsable(true),
		Category("Window"),
		DefaultValue(""),
		Description("URL of the page that is loaded in the window"),
		Editor(typeof(UrlEditor), typeof(UITypeEditor))
		]
        public string NavigateUrl
		{
            get { return _NavigateUrl; }
            set { _NavigateUrl = value; }
		}
		/// <summary>
		/// Data Returned to anchor from the window
		/// </summary>
		[
		Bindable(true),
		Browsable(false),
		Category("Window"),
		Description("Data Returned to anchor from the window")
		]
        public Properties PropertiesSend
		{
            get
            {
                if (_PropertiesSend == null)
                {
                    _PropertiesSend = new Properties();
                }
                return _PropertiesSend;
            }
		}

		/// <summary>
		/// Collection of Property(string Key, string Value) objects sent to Modal Window.
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

		/// <summary>
		/// Contol which event will cause the window to show
		/// </summary>
		[
        Bindable(true),
        Browsable(true),
		Category("Window"),
		Editor(typeof(AllControlsEditor), typeof(UITypeEditor)),
		Description("Control ")
		]
		public string LinkedControlID
		{
			get { return _linkedControlID; }
			set { _linkedControlID=value; }
		}

		/// <summary>
		/// Object reference to LinkedControlID
		/// </summary>
		[
		Bindable(false),
		Browsable(false),
		Category("Window"),
		DefaultValue(null),
		Description("Object reference to LinkedControlID")
		]
        public IExtButton LinkedControl
		{
			get
			{
                IExtButton ctrl = null;
				if (_linkedControlID != string.Empty)
				{
                    ctrl = (IExtButton)FindControl(this, _linkedControlID);
				}
				return ctrl;
			}
		}

		/// <summary>
		/// JavaScript event to handle
		/// </summary>
		[
		Bindable(true),
		Browsable(true),
		Category("Window"),
		DefaultValue("onclick"),
		//Editor(typeof(JavaScriptEventEditor),typeof(UITypeEditor)),
		Description("JavaScript event to handle")
		]
		public JSEvent HandledEvent
		{
			get { return _handledEvent; }
			set { _handledEvent=value; }
		}

        [
        Bindable(true),
        Browsable(true),
        Category("Window"),
        DefaultValue("yes"),
        ]
        public Resizable resizable 
        {
            get { return _resizable; }
            set { _resizable = value; }
        }
		/// <summary>
		/// The width of the window
		/// </summary>
		[
		Bindable(true),
		Browsable(true),
		Category("Window"),
		Description("The width of the window"),
		DefaultValue(typeof(Unit), "800")
		]
		public virtual Unit WindowWidth
		{
			get
			{
				return _windowWidth;
			}
			set
			{
				if (value.Value < 0)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this._windowWidth = value;
			}
		}

		/// <summary>
		/// The height of the window
		/// </summary>
		[
		Bindable(true),
		Browsable(true),
		Category("Window"),
		Description("The height of the window"),
		DefaultValue(typeof(Unit), "600")
		]
		public virtual Unit WindowHeight
		{
			get
			{
				return _windowHeight;
			}
			set
			{
				if (value.Value < 0)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this._windowHeight = value;
			}
		}

		#endregion
		#region View State              
		protected override object SaveViewState() 
		{ 
			// Save State as a cumulative array of objects.
			object[] SavedState = new object[12]; 
			SavedState[0] = base.SaveViewState(); 
			SavedState[1] = this.Scrolling;
			SavedState[2] = this.IsClientResult;
			SavedState[3] = this.OutControlName;
			SavedState[4] = this.OutControlId; 
			SavedState[5] = this.PropertiesSend.Xml; 
			SavedState[6] = this.NavigateUrl; 
			SavedState[7] = this.LinkedControlID; 
			SavedState[8] = this.HandledEvent.ToString("d"); 
			SavedState[9] = this.WindowHeight; 
			SavedState[10] = this.WindowWidth;
            SavedState[11] = this.resizable.ToString("d");
			return SavedState; 
		} 

		protected override void LoadViewState(object SavedState) 
		{ 
			
            if (SavedState != null)
			{
				// Load State from the array of objects that was saved at SavedViewState.
				object[] state = (object[])SavedState;
				if (state[0] != null) base.LoadViewState(state[0]);
				if (state[1] != null) this.Scrolling				= (bool)state[1]; 
				if (state[2] != null) this.IsClientResult		    = (bool)state[2]; 
				if (state[3] != null) this.OutControlName			= (string)state[3]; 
				if (state[4] != null) this.OutControlId				= (string)state[4]; 
				if (state[5] != null) this.PropertiesSend.Xml		= (string)state[5];
				if (state[6] != null) this.NavigateUrl				= (string)state[6]; 
				if (state[7] != null) this.LinkedControlID			= (string)state[7]; 
				if (state[8] != null) this.HandledEvent				= (JSEvent)Enum.Parse(typeof(JSEvent), (string)state[8]); 
				if (state[9] != null) this.WindowHeight				= (Unit)state[9];
				if (state[10] != null) this.WindowWidth				= (Unit)state[10];
                if (state[11] != null) this.resizable               = (Resizable)Enum.Parse(typeof(Resizable), (string)state[11], true);
            } 
		}
		#endregion
		#region Control Events          
		protected override void OnInit(System.EventArgs e) 
		{
            base.OnInit(e);
			RegisterJavascript("WebModalJavascript", "Javascript.Common.js");
			this.Page.ClientScript.RegisterHiddenField("__WebModalData"	, string.Empty);
			this.Page.ClientScript.RegisterHiddenField("__AnchorID"		, string.Empty);

			//Move the data returned from the window back into the anchor.
			if (this.Page.IsPostBack) 
			{ 
				//Every anchor calls its OnLoad function, so only the anchor that opened the window should take action here
				if((this.Page.Request.Form["__AnchorID"] == this.ClientID))
				{ 
					this.PropertiesIncoming.Xml = HttpUtility.UrlDecode(this.Page.Request.Form["__WebModalData"]); 
					
					//Allow the anchor host to take action on the return data
					if (OnWindowClose != null) 
					{ 
						//Prevent this event from firing more than once. 
						//Occurs in a dynamic scenario, where the anchor is created twice.
						if (this.Context.Items["OnWindowCloseFired"] == null)
						{
							this.Context.Items["OnWindowCloseFired"] = "true";
							OnWindowClose(this); 
						}
						
					} 
					
					 
				} 
			} 

			this.RegisterClientEvent();
			
		} 
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			
					if (LinkedControl != null &&  LinkedControl.Visible == true)
					{
						if ( LinkedControlID == null ||  LinkedControlID == string.Empty ) 
						{
							throw new ArgumentNullException("LinkedControlID for " +  ClientID);
						}
                        if (NavigateUrl == null)
                        {
                            throw new ArgumentNullException("URL for " + ClientID);
                        }
                        else 
                        {
                            if (HttpContext.Current.Request.Url.ToString().ToLower().IndexOf("service/admin/") > -1 && NavigateUrl.ToLower().IndexOf("service") == -1)
                            {
                                NavigateUrl = "/service" + NavigateUrl;
                            }
                        }
			
						if ( WindowHeight == Unit.Empty) 
						{
							throw new ArgumentNullException("WindowHeight for " +  ClientID);
						}
						if ( WindowWidth == Unit.Empty) 
						{
							throw new ArgumentNullException("WindowWidth for " + ClientID);
						}

                        LinkedControl.OnClientClick = string.Format("return WebModal ( null, \"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", \"{6}\", \"{7}\", \"{8}\", \"{9}\");", ClientID, IsClientResult, NavigateUrl, WindowHeight, WindowWidth, Scrolling, resizable.ToString("f") ,HttpUtility.UrlEncode(PropertiesSend.Xml), OutControlId, OutControlName);
                       
                    }
			}
		

#endregion
		#region Internal Functions      

        //private string GetClientID(WebModalShow anchor, string id)
        //{
        //    Control control =  FindControl(this, id);
        //    if (control != null)
        //        return control.ClientID;

        //    return string.Empty;		  
        //}

        private Control FindControl(WebModalShow anchor, string id)
		{
			// recursive routine for walking from anchor to top, looking for the LinkedControlID,
			// so it can retrieve an actual reference
            //for (Control ctrl = anchor.Parent; ctrl != null; ctrl = ctrl.Parent)
            //{
            //    Control _ctrl = ctrl.FindControl(id);
            //    if ( _ctrl != null)
            //    {
            //        return _ctrl;
            //    }
            //}

			//throw new ApplicationException(string.Format("Anchor:{0} was unable to find LinkedControlID:{1} in the control hierarchy.", anchor.ClientID, anchor.LinkedControlID));
            return FindControlRecursive(Page, id);
		}

        private Control FindControlRecursive(Control control, string value)
        {

            if (control != null && control.ClientID == value)
                return control;

            foreach (Control c in control.Controls)
            {
                Control f = FindControlRecursive(c, value);
                if (f != null)
                    return f;
            }
            return null;

            
            //foreach (Control c in control.Controls)
            //{
            //    if (c.ClientID == value)
            //    {
            //        return c;
            //    }
            //    else if (c.Controls.Count > 0)
            //    {
            //        Control res = FindControlRecursive(c, value);
            //        if (res != null && res.ClientID == value)
            //            return res;
            //    }
            //}

            //return null;
        }

		

		/// <summary>
		/// Store a reference to the anchor in the httpcontext, so all anchors can be rendered in one block
		/// </summary>
		private void RegisterClientEvent()
		{
            if (this.Context.Items["WebModalShow"] == null)
            {
                this.Context.Items["WebModalShow"] = new Hashtable(); 
			}
			//If the anchor is already in memory, remove it, since the latter on is more up to date.
            if (((Hashtable)this.Context.Items["WebModalShow"]).Contains(this.ClientID))
			{
                ((Hashtable)this.Context.Items["WebModalShow"]).Remove(this.ClientID);
			}
            ((Hashtable)this.Context.Items["WebModalShow"]).Add(this.ClientID, this);
			
		}
		/// <summary>
		/// Wrapper for retrieving and registering embedded javascript resource files
		/// </summary>
		private void RegisterJavascript(string blockName, string scriptname)
		{
            if (!Page.ClientScript.IsClientScriptBlockRegistered(blockName)) 
			{
                //Page.ClientScript.GetWebResourceUrl(typeof(WebModalShow), "Winnetou.WebControls.Javascript.Common.js");
                //using (System.IO.StreamReader reader = new System.IO.StreamReader(typeof(WebModalShow).Assembly.GetManifestResourceStream(typeof(WebModalShow), scriptname)))
                //{
                //    string script = "<script language='javascript' type='text/javascript' >\r\n<!--\r\n" + reader.ReadToEnd() + "\r\n//-->\r\n</script>";
                //    this.Page.RegisterClientScriptBlock(blockName, script);
                //}
                Page.ClientScript.RegisterClientScriptInclude(GetType(), blockName, Page.ClientScript.GetWebResourceUrl(GetType(), "Winnetou.WebControls.Javascript.Common.js"));
			}			
		}

		#endregion 
	}

	#region DesignTime
	/// <summary>
	/// Editor for selecting adding and editing properties in designer
	/// </summary>
	internal class PropertyCollectionEditor : CollectionEditor
	{

		public PropertyCollectionEditor(Type type) : base(type)
		{
		}

		protected override Type CreateCollectionItemType()
		{
			return typeof(Property);
		}
	}

	/// <summary>
	/// Class for displaying WebModalAnchor in designer
	/// </summary>
    internal class WebModalShowDesigner : ControlDesigner
	{
		#region Overriden methods

		/// <summary>
		/// Returns HTML code to show in designer
		/// </summary>
		public override string GetDesignTimeHtml()
		{
			string s = "<div style=\"padding:6px; background-color: #333333;color:#FFFFFF;font:12px Verdana " +
				"border-style:outset; border-width:1px; font: 75% 'Microsoft Sans Serif';\">&nbsp;<span style=\"color:#FAB301\">CS</span> "+((Control)Component).ID;
			s += "</div>";
			return s;
			
		}
    
		#endregion
	}
	/// <summary>
	/// Editor for selecting controls from Asp.Net page
	/// </summary>
	internal abstract class ControlsEditor : UITypeEditor
	{
		#region Variables

		private System.Windows.Forms.Design.IWindowsFormsEditorService edSvc=null;
		private System.Windows.Forms.ListBox lb;
		private Type typeShow;

		#endregion
		#region Constructor


		/// <summary>
		/// onstructor - show specified types
		/// </summary>
		/// <param name="show">Type descriptor</param>
		public ControlsEditor(Type show)
		{
			typeShow=show;
		}

		#endregion
		#region Methods

		/// <summary>   
		/// Overrides the method used to provide basic behaviour for selecting editor.
		/// Shows our custom control for editing the value.
		/// </summary>
		/// <param name="context">The context of the editing control</param>
		/// <param name="provider">A valid service provider</param>
		/// <param name="value">The current value of the object to edit</param>
		/// <returns>The new value of the object</returns>
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider,object value) 
		{  
			if (context!=null&&context.Instance!=null&&provider!=null) 
			{
				edSvc=(System.Windows.Forms.Design.IWindowsFormsEditorService)
					provider.GetService(typeof(System.Windows.Forms.Design.IWindowsFormsEditorService));

				if (edSvc!=null) 
				{					
					lb=new System.Windows.Forms.ListBox();
					ArrayList controlArray = new ArrayList();
					lb.BorderStyle=System.Windows.Forms.BorderStyle.None;
					lb.SelectedIndexChanged+=new EventHandler(lb_SelectedIndexChanged);

					//Cycle through the controls in the anchor's NamingContainer
					ControlCollection coll = ((Control)context.Instance).NamingContainer.Controls;

					//((ReadOnlyCollectionBase)((IContainer)(context.Container)).Components)

					for(int i = 0; i<= coll.Count; i++)
					{
						try
						{
							Control ctrl = coll[i];
							if ((ctrl.GetType().IsSubclassOf(typeShow) || ctrl.GetType().FullName==typeShow.FullName) && ctrl.ID != null) 
								controlArray.Add(ctrl.ID);
						}
						catch{}
					}
					
					//Sort the controls by ID, and then add them to the listbox
					controlArray.Sort(new CaseInsensitiveComparer());
					IEnumerator myEnumerator = controlArray.GetEnumerator();
					while ( myEnumerator.MoveNext() )
						lb.Items.Add(myEnumerator.Current);

					//return it to the IDE
					edSvc.DropDownControl(lb);
					if (lb.SelectedIndex==-1) return value;
						return lb.SelectedItem;
				}
			}

			return value;
		}


		/// <summary>
		/// Choose editor type
		/// </summary>
		/// <param name="context">The context of the editing control</param>
		/// <returns>Returns <c>UITypeEditorEditStyle.DropDown</c></returns>
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) 
		{
			return UITypeEditorEditStyle.DropDown;			
		}


		/// <summary>
		/// Close the dropdowncontrol when theProperty has selected a value
		/// </summary>
		private void lb_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (edSvc != null) 
			{
				edSvc.CloseDropDown();
			}
		}

		#endregion
	}


	/// <summary>
	/// Editor for selecting all Asp.Net controls
	/// </summary>
	internal class AllControlsEditor : ControlsEditor
	{
		#region Members

		/// <summary>
		/// Invoke base constructor
		/// </summary>
		public AllControlsEditor() : base(typeof(Control)) {}

		#endregion
	}
	
	/// <summary>
	/// List of javascript events used for HandleEvent Property
	/// </summary>
    public enum Resizable
    {
        yes,
        no
    }
    
    public enum JSEvent
	{
		onabort,
		onblur,
		onchange,
		onclick,
		oncontextmenu,
		ondblclick,
		ondragdrop,
		onerror,
		onfocus,
		onkeydown,
		onkeypress,
		onkeyup,
		onload,
		onmousedown,
		onmouseout,
		onmouseover,
		onmouseup,
		onmove,
		onreset,
		onresize,
		onselect,
		onsubmit,
		onunload
	}
}
#endregion