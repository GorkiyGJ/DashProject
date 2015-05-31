using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Winnetou.WebControls
{
   
    public class extOperationButton : ImageButton, IExtButton
    {
        public enum TypeControls
        {
            Add,
            Edit,
            Delete,
            Import,
            Export,
            Statistic,
            Select,
            SelectForm,
            Calendar,
            Apply,
            DeleteTextBoxId, 
            Copy,
            Custom
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Type t = GetType();
            if (!Page.ClientScript.IsClientScriptBlockRegistered(t, "OperationButton"))
            {
                string script =
                    @"<script type='text/javascript'>function MM_swapImgRestore() { //v3.0
                                  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
                                }

                                function MM_preloadImages() { //v3.0
                                  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
                                    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
                                    if (a[i].indexOf('#')!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
                                }

                                function MM_findObj(n, d) { //v4.01
                                  var p,i,x;  if(!d) d=document; if((p=n.indexOf('?'))>0&&parent.frames.length) {
                                    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
                                  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
                                  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
                                  if(!x && d.getElementById) x=d.getElementById(n); return x;
                                }

                                function MM_swapImage() { //v3.0
                                  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
                                   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
                                }</script>";

                Page.ClientScript.RegisterClientScriptBlock(t, "OperationButton", script);
            }

            SetImageURL();

            ImageUrl = RootHTTP + imgSrc;

            if (!Page.ClientScript.IsClientScriptBlockRegistered(t, "LoadImgButton" + t + TypeControl))
            {
                string script = "<script type='text/javascript'>MM_preloadImages('" + RootHTTP + imgSrcOver + "')</script>";

                Page.ClientScript.RegisterClientScriptBlock(t, "LoadImgButton" + t + TypeControl, script);
            }

            if (TypeControl != TypeControls.Custom)
            {
                Attributes.Add("onMouseOut", "MM_swapImgRestore()");
                Attributes.Add("onMouseOver", "MM_swapImage('" + ClientID + "','','" + RootHTTP + imgSrcOver + "',1)");
            }
        }

        private void typeDeleteTextBoxId()
        {
            typeDel();

            Type t = GetType();
            if (!Page.ClientScript.IsClientScriptBlockRegistered(t, "ClearTextBox"))
            {
                string script =
                       @"<script type='text/javascript'>function ClearTextBox(argId, argTextId)
                            {        
                                document.getElementById(argId).value = '';;
                                document.getElementById(argTextId).value = '';
                            } </script>";

                Page.ClientScript.RegisterClientScriptBlock(t, "ClearTextBox", script);
            }

            if (TextBoxId != null)
            {
                OnClientClick = "javascript:ClearTextBox('" + TextBoxId.IdClientId + "','" + TextBoxId.TextClientId + "'); return false;";
            }
        }

        private void SetImageURL()
        {
            switch (TypeControl)
            {
                case TypeControls.Add:
                    typeAdd();
                    break;

                case TypeControls.Delete:
                    typeDel();
                    break;

                case TypeControls.DeleteTextBoxId:
                    typeDeleteTextBoxId();
                    break;

                case TypeControls.Edit:
                    typeEdit();
                    break;

                case TypeControls.Import:
                    typeImport();
                    break;

                case TypeControls.Export:
                    typeExport();
                    break;

                case TypeControls.Statistic:
                    typeStatistic();
                    break;

                case TypeControls.Select:
                    typeSelect();
                    break;

                case TypeControls.SelectForm:
                    typeSelectForm();
                    break;

                case TypeControls.Apply:
                    typeApply();
                    break;
                    
                case TypeControls.Calendar:
                    typeCalendar();
                    break;

                case TypeControls.Copy:
                    typeCopy();
                    break;

                case TypeControls.Custom:
                    typeCustom();
                    break;
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            SetImageURL();
            ImageUrl = imgSrc;
            base.Render(writer);
        }

        protected override void OnPreRender(EventArgs e)
        {
            ImageUrl = RootHTTP + imgSrc;
            base.OnPreRender(e);
        }

        public TypeControls _TypeControl = TypeControls.Add;
        public TypeControls TypeControl
        {
            get { return _TypeControl; }
            set { _TypeControl = value; }
        }

        private extTextBoxId _TextBoxId;
        public extTextBoxId TextBoxId
        {
            get { return _TextBoxId; }
            set { _TextBoxId = value; }
        }

        #region typeImage
        private void typeCalendar()
        {
            if (Enabled)
                imgSrc = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.calendar_light.gif");
            else
                imgSrc = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.calendar_light_enable.gif");

            imgSrcOver = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.calendar_over.gif");
        }

        private void typeSelect()
        {
            if(Enabled)
                imgSrc = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.select_light.gif");
            else
                imgSrc = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.select_light_enable.gif");

            imgSrcOver = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.select_light_over.gif");
        }

        private void typeSelectForm()
        {
            if (Enabled)
                imgSrc = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.popup_light.gif");
            else
                imgSrc = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.popup_light_enable.gif");

            imgSrcOver = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.popup_light_over.gif");
        }

        private void typeApply()
        {
            if (Enabled)
                imgSrc = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.aproved_light.gif");
            else
                imgSrc = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.aproved_light_enable.gif");

            imgSrcOver = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.aproved_over.gif");
        }

        private void typeStatistic()
        {
            if(Enabled)
                imgSrc = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.stat.gif");
            else
                imgSrc = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.stat_enable.gif");

            imgSrcOver = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.stat_over.gif");
        }

        private void typeAdd()
        {
            if(Enabled)
                imgSrc = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.add_light.gif");
            else
                imgSrc = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.add_light_enable.gif");

            imgSrcOver = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.add_light_over.gif");
        }

        private void typeEdit()
        {
            if(Enabled)
                imgSrc = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.edit_light.gif");
            else
                imgSrc = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.edit_light_enable.gif");

            imgSrcOver = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.edit_light_over.gif");
        }

        private void typeDel()
        {
            if(Enabled)
                imgSrc = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.del_light.gif");
            else
                imgSrc = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.del_light_enable.gif");

            imgSrcOver = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.del_light_over.gif");
        }

        private void typeExport()
        {
            if(Enabled)
                imgSrc = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.export_light.gif");
            else
                imgSrc = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.export_light_enable.gif");

            imgSrcOver = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.export_light_over.gif");
        }

        private void typeImport()
        {
            if(Enabled)
                imgSrc = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.import_light.gif");
            else
                imgSrc = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.import_light_enable.gif");

            imgSrcOver = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.import_light_over.gif");
        }

        private void typeCopy() 
        {
            if (Enabled)
                imgSrc = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.copy_light.gif");
            else
                imgSrc = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.copy_light_enable.gif");

            imgSrcOver = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.copy_light_over.gif");
        }

        private void typeCustom()
        {
            //if (Enabled)
            //    imgSrc = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.copy_light.gif");
            //else
            //    imgSrc = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.copy_light_enable.gif");

            //imgSrcOver = Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extOperation.copy_light_over.gif");
        }

        #endregion

        private string _imgSrc = "";
        public string imgSrc
        {
            get { return _imgSrc; }
            set { _imgSrc = value; }
        }

        private string _imgSrcOver = "";
        public string imgSrcOver
        {
            get { return _imgSrcOver; }
            set { _imgSrcOver = value; }
        }

        protected static string RootHTTP
        {
            get
            {
                return HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority;
            }
        }
    }
}