using System.ComponentModel;
using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


namespace Winnetou.WebControls
{   
    [ToolboxData("<{0}:extDateTime runat=server></{0}:extDateTime>")]
    [SupportsEventValidation]
    [ValidationProperty("Text")]
    public class extDateTime : CompositeControl
    {
        #region "private"
        private readonly extOperationButton dtButton;
        private readonly extOperationButton dtResetButton;
        private readonly TextBox dtText;
        private readonly AjaxControlToolkit.CalendarExtender dtCalendar;
        #endregion

        public extDateTime()
        {                                 
            dtText = new TextBox();
            dtText.ID = "dtTextID";

            dtButton = new extOperationButton();
            dtButton.ID = "dtButtonID";
            dtButton.TypeControl = extOperationButton.TypeControls.Calendar;

            dtResetButton = new extOperationButton();
            dtResetButton.ID = "dtResetButtonID";
            dtResetButton.TypeControl = extOperationButton.TypeControls.Delete;
           
            
            dtCalendar = new AjaxControlToolkit.CalendarExtender();
            dtCalendar.ID = "CalendarExtenderID";
            dtCalendar.PopupButtonID = dtButton.ID;
            dtCalendar.TargetControlID = dtText.ID;

            BorderWidth = new Unit(0);
        }

        public string TextClientId
        {
            get
            {
                return this.ClientID + "_" + dtText.ID;
            }
        }
        
        [DefaultValue("")]
        public  string ValidationGroup
        {
            get
            {
                return (string)ViewState["ValidationGroup"];
            }
            set
            {
                ViewState["ValidationGroup"] = value;
            }
        }
        
        
        [Bindable(true)]
        public DateTime? Date
        {
            get
            {
                try
                {
                    return Manitou.Helper.Converter.ToDateTimeNullable(dtText.Text);
                }
                catch
                {
                    return DateTime.Now;
                }
            }
        }

        [DefaultValue("dd.MM.yyyy")]
        public string Format
        {
            get
            {
                return dtCalendar.Format;
            }
            set
            {
                dtCalendar.Format = value;
            }
        }

        public override string CssClass
        {
            get
            {
                return dtCalendar.CssClass;
            }

            set
            {
                dtCalendar.CssClass = value;
            }
        }

        [Bindable(true)]
        public string Text
        {
            get
            {
                return dtText.Text;
            }

            set
            {
                dtText.Text = value;
            }
        }
       
        [DefaultValue("true")]
        public bool ClientReadOnlyData
        {
            get
            {
                if (ViewState["ClientReadOnlyData"] == null)
                    return true;
                return (bool)ViewState["ClientReadOnlyData"];
            }
            set
            {
                ViewState["ClientReadOnlyData"] = value;
            }
        }

        public Unit DateTextWidth
        {
            get
            {
                return dtText.Width;
            }
            set
            {
                dtText.Width = value;
            }
        }

        protected override void CreateChildControls()
        {
            HtmlTableCell tblCelldtText = new HtmlTableCell();
            //tblCelldtText.Width = "0px";
            tblCelldtText.Controls.Add(dtText);

            HtmlTableCell tblCelldtButton = new HtmlTableCell();
            //tblCelldtButton.Width = "0px";
            tblCelldtButton.Controls.Add(dtButton);

            HtmlTableCell tblCelldtResetButton = new HtmlTableCell();
            //tblCelldtResetButton.Width = "0px";
            tblCelldtResetButton.Controls.Add(dtResetButton);
            
            HtmlTableRow tblRow1 = new HtmlTableRow();
            //tblRow1.Height = "0px";
            tblRow1.Cells.Add(tblCelldtText);
            tblRow1.Cells.Add(tblCelldtButton);
            tblRow1.Cells.Add(tblCelldtResetButton);
            
            HtmlTableCell tblCelldtCalendar = new HtmlTableCell();
            //tblCelldtCalendar.Width = "0px";
            tblCelldtCalendar.ColSpan = 3;
            tblCelldtCalendar.Controls.Add(dtCalendar);
            HtmlTableRow tblRow2 = new HtmlTableRow();
            //tblRow2.Height = "0px";
            tblRow2.Cells.Add(tblCelldtCalendar);

            HtmlTable tbl = new HtmlTable();
            //tbl.Width = "0px";
            //tbl.Height = "0px";
            tbl.Rows.Add(tblRow1);
            tbl.Rows.Add(tblRow2);

            Controls.Add(tbl);

            base.CreateChildControls();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            dtResetButton.OnClientClick = "document.getElementById('" + dtText.ClientID + "').value = ''; return false;";
            
            base.Render(writer);

            StringBuilder sb = new StringBuilder();

            if (!ClientReadOnlyData)
         
                sb.AppendLine("document.getElementById('" + dtText.ClientID + "').readOnly = false;");            
            else               
                sb.AppendLine("document.getElementById('" + dtText.ClientID + "').readOnly = true;");
            
            ScriptManager.RegisterStartupScript(this, GetType(), "readOnly_" + ClientID, sb.ToString(), true);
        }
    }
}