using System;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.IO;

namespace Winnetou.WebControls
{
    public class extAutoComplete : WebControl
    {
        public string ControlId { get; set; }
        public string ControlName { get; set; }
        public string WebServiceUrl { get; set; }
        public string WebServiceName { get; set; }

        private int _ItemsWithoutScroll = 4;
        public int ItemsWithoutScroll
        {
            get
            {
                return _ItemsWithoutScroll;
            }
            set
            {
                _ItemsWithoutScroll = value;
            }
        }

        private int _MinNameLengthToComplete = 3;
        public int MinNameLengthToComplete
        {
            get
            {
                return _MinNameLengthToComplete;
            }
            set
            {
                _MinNameLengthToComplete = value;
            }
        }

        private string _ElementBaseForPosition;
        public string ElementbaseForPosition
        {
            get
            {
                return _ElementBaseForPosition;
            }
            set
            {
                _ElementBaseForPosition = value;
            }
        }

        public string CallbackJavascript { get; set; }

        private HtmlGenericControl OutputDivId { get; set; }
        private HtmlSelect OutputComboBoxId { get; set; }

        private bool _IsPositionStyles = true;
        public bool IsPositionStyles 
        { 
            get
            {
                return _IsPositionStyles;
            }
            set
            {
                _IsPositionStyles = value;
            }
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            HtmlGenericControl c = new HtmlGenericControl("div");
            OutputDivId = c;
            c.ID = ID + "_outputDiv";

            c.Style.Add("position", "absolute");
            c.Style.Add("width", ((int)(Width.Value + 10)).ToString() + "px");
            c.Style.Add("display", "none");

            HtmlSelect s = new HtmlSelect();
            OutputComboBoxId = s;
            s.ID = ID + "_cb";

            s.Style.Add("width", ((int)Width.Value).ToString() + "px");
            s.Attributes.Add("onclick", ClientID + "_cb_click();");
            s.Attributes.Add("onkeydown", "return " + ClientID + "_cb_keydown(event);");
            s.Attributes.Add("size", ItemsWithoutScroll.ToString());
            c.Controls.Add(s);

            Controls.Add(c);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ScriptManager sm = ScriptManager.GetCurrent(Page);
            if (sm != null && !string.IsNullOrEmpty(WebServiceUrl))
            {
                bool isIs = false;

                for (int i = 0; i < sm.Services.Count; i++)
                    if (sm.Services[i].Path == WebServiceUrl)
                    {
                        isIs = true;
                        break;
                    }

                if (!isIs)
                {
                    ServiceReference sr = new ServiceReference();
                    sr.Path = WebServiceUrl;
                    sm.Services.Add(sr);
                }
            }
            else
                Visible = false;

            if (string.IsNullOrEmpty(_ElementBaseForPosition))
                _ElementBaseForPosition = ControlId;
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            base.Render(writer);

            string styles = "";
            if(IsPositionStyles)
                styles = string.Format(@"res.style.top = $(""#{0}"").position().top + 5 + 'px';
                                         res.style.left = $(""#{0}"").position().left + parseInt($(""#{0}"").css(""margin-left"").replace(""px"", """"), 10) - 3 + 'px';
                                         res.style.marginTop = $(""#{0}"").height() + parseInt($(""#{0}"").css(""margin-top"").replace(""px"", """"), 10) + parseInt($(""#{0}"").css(""margin-bottom"").replace(""px"", """"), 10) + 1 + 'px';", ElementbaseForPosition);

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"  var {4}__WAIT_TIME = 1000;
                                var {4}__timeoutFunction;
                                var _executor = null;
                                
                                {4}_addListeners();
                                Sys.Net.WebRequestManager.add_invokingRequest({4}_onInvokingRequest); 
                                
                                function {4}_onTxtKeyUpName() {{
                                    {4}__timeoutFunction = setTimeout({4}_performSearchName, {4}__WAIT_TIME);
                                }}
                                
                                function {4}_onTxtKeyDownName() {{
                                    if({4}__timeoutFunction)clearTimeout({4}__timeoutFunction);
                                }}
                                
                                function {4}_performSearchName() {{
                                    if(_executor) {{
                                        _executor.abort();
                                        _executor = null;
                                    }}
                                    {5}.GetItemsByName($get(""{0}"").value, {6}, {4}_onComplete, {4}_onError);
                                }}

                                function {4}_onTxtKeyUpId() {{
                                    {4}__timeoutFunction = setTimeout({4}_performSearchId, {4}__WAIT_TIME);
                                }}
                                
                                function {4}_onTxtKeyDownId() {{
                                    if({4}__timeoutFunction)clearTimeout({4}__timeoutFunction);
                                }}
                                
                                function {4}_performSearchId() {{
                                    if(_executor) {{
                                        _executor.abort();
                                        _executor = null;
                                    }}
                                    {5}.GetItemsById($get(""{1}"").value, {4}_onComplete, {4}_onError);
                                }}
                                
                                function {4}_onInvokingRequest(sender, args) {{
                                    _executor = args.get_webRequest().get_executor();
                                }}
                                
                                function {4}_onComplete(result) {{
                                    var res = $get(""{2}"");
                                    var cb = $get(""{3}"");

                                    cb.options.length = 0; 
                                    if(result != null){{           
                                        for (var i = 0; i < result.length; i++) {{
                                            cb.appendChild(document.createElement(""option""));
                                            cb.options[cb.options.length-1].value = result[i].Id;
                                            cb.options[cb.options.length-1].text = result[i].Name;
                                        }}
                                            
                                        {8}
                                        res.style.display = 'block';
                                        cb.focus();

                                        if(cb.options.length > 0)
                                            cb.options[0].selected = true;
                                    }}
                                    else
                                    {{
                                        res.style.display = 'none';
                                    }}
                                    _executor = null;
                                }}
                                
                                function {4}_onError() {{
                                    _executor = null;
                                }}

                                function {4}_cb_click() {{
                                    var cb = $get(""{3}"");

                                    if(cb != null){{
                                        $get(""{2}"").style.display = 'none';
                                        for (var i = 0; i < cb.options.length; i++)
                                            if (cb.options[i].selected) {{
                                                $get(""{0}"").value = cb.options[i].text;
                                                $get(""{1}"").value = cb.options[i].value;

                                                $get(""{0}"").focus();
                                                return false;
                                            }}
                                        {7}
                                    }}
                                }}

                                function {4}_cb_keydown(e) {{
                                    if (e.keyCode == 13) {{
                                        {4}_cb_click();
                                        
                                        var defbtn = $(e.srcElement ? e.srcElement : e.target).parent().parent().parent()[0];
                                        //if(defbtn.onkeypress != null)
                                        //    $(defbtn).trigger(""keypress"");//defbtn.onkeypress();
                                        $(defbtn).find(':submit').trigger('click');
                                    }}
                                    
                                    if (e.charCode?e.charCode:e.keyCode == 8) 
                                    {{
                                        $get('{2}').style.display = 'none';
                                        
                                        var cn = $get('{0}');
                                        if (cn)
                                            cn.focus();

                                        return false;
                                    }}
                                }}

                                function {4}_addListeners(){{
                                    if(window.addEventListener) {{ // Standard
                                        $get(""{0}"").addEventListener('keydown', {4}_onTxtKeyDownName, false);
                                        $get(""{0}"").addEventListener('keyup', {4}_onTxtKeyUpName, false);

                                        $get(""{1}"").addEventListener('keydown', {4}_onTxtKeyDownId, false);
                                        $get(""{1}"").addEventListener('keyup', {4}_onTxtKeyUpId, false);

                                        return true;
                                    }}
                                    else if(window.attachEvent) {{ // IE
                                        $get(""{0}"").attachEvent('onkeydown', {4}_onTxtKeyDownName);
                                        $get(""{0}"").attachEvent('onkeyup', {4}_onTxtKeyUpName);

                                        $get(""{1}"").attachEvent('onkeydown', {4}_onTxtKeyDownId);
                                        $get(""{1}"").attachEvent('onkeyup', {4}_onTxtKeyUpId);

                                        return true;
                                    }} 
                                    else return false;
                                }}
                
            ", ControlName, ControlId, OutputDivId.ClientID, OutputComboBoxId.ClientID, ClientID, WebServiceName, MinNameLengthToComplete, CallbackJavascript, styles);

            ScriptManager.RegisterStartupScript(this, GetType(), ClientID + "_extAutoComplete", sb.ToString(), true);
        }
    }
}
