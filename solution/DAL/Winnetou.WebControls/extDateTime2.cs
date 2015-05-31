using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Winnetou.WebControls
{
    [ToolboxData("<{0}:extDateTime2 runat=server></{0}:extDateTime2>")]
    [SupportsEventValidation]
    [ValidationProperty("Text")]
    public class extDateTime2 : CompositeControl
    {
        #region "private"
        private readonly extOperationButton dtButton;
        private readonly extOperationButton dtResetButton;
        private readonly TextBox dtDate;
        private readonly RegularExpressionValidator revdtDate;
        private readonly AjaxControlToolkit.ValidatorCalloutExtender vcerevdtDate;

        private readonly TextBox dtHours;
        private readonly RangeValidator rvdtHours;
        private readonly AjaxControlToolkit.ValidatorCalloutExtender vcervdtHours;

        private readonly TextBox dtMinutes;
        private readonly RangeValidator rvdtMinutes;
        private readonly AjaxControlToolkit.ValidatorCalloutExtender vcervdtMinutes;

        private readonly AjaxControlToolkit.CalendarExtender dtCalendar;
        #endregion

        public extDateTime2()
        {                                 
            dtDate = new TextBox();
            dtDate.ID = this.ID + "dtDateID";
            dtDate.Width = new Unit(65);

            revdtDate = new RegularExpressionValidator();
            revdtDate.ID = this.ID + "revdtDateID";
            revdtDate.ValidationExpression = "(\\d){2}.(\\d){2}.(\\d){4}";
            revdtDate.ErrorMessage = "Некорректный формат даты";
            revdtDate.Display = ValidatorDisplay.None;
            revdtDate.SetFocusOnError = true;
            revdtDate.ControlToValidate = dtDate.ID;

            vcerevdtDate = new AjaxControlToolkit.ValidatorCalloutExtender();
            vcerevdtDate.ID = this.ID + "vcerevdtDateID";
            vcerevdtDate.TargetControlID = revdtDate.ID;

            dtMinutes = new TextBox();
            dtMinutes.ID = this.ID + "dtMinutesID";
            dtMinutes.Width = new Unit(20);

            rvdtMinutes = new RangeValidator();
            rvdtMinutes.ID = this.ID + "rvdtMinutesID";
            rvdtMinutes.Type = ValidationDataType.Integer;
            rvdtMinutes.MinimumValue = "0";
            rvdtMinutes.MaximumValue = "59";
            rvdtMinutes.ErrorMessage = "Некорректный формат минут";
            rvdtMinutes.Display = ValidatorDisplay.None;
            rvdtMinutes.SetFocusOnError = true;
            rvdtMinutes.ControlToValidate = dtMinutes.ID;
            
            vcervdtMinutes = new AjaxControlToolkit.ValidatorCalloutExtender();
            vcervdtMinutes.ID = "vcervdtMinutesID";
            vcervdtMinutes.TargetControlID = rvdtMinutes.ID;

            dtHours = new TextBox();
            dtHours.ID = this.ID + "dtHoursID";
            dtHours.Width = new Unit(20);

            rvdtHours = new RangeValidator();
            rvdtHours.ID = this.ID + "rvdtHoursID";
            rvdtHours.Type = ValidationDataType.Integer;
            rvdtHours.MinimumValue = "0";
            rvdtHours.MaximumValue = "23";
            rvdtHours.ErrorMessage = "Некорректный формат часов";
            rvdtHours.Display = ValidatorDisplay.None;
            rvdtHours.SetFocusOnError = true;
            rvdtHours.ControlToValidate = dtHours.ID;

            vcervdtHours = new AjaxControlToolkit.ValidatorCalloutExtender();
            vcervdtHours.ID = this.ID + "vcervdtHoursID";
            vcervdtHours.TargetControlID = rvdtHours.ID;

            dtButton = new extOperationButton();
            dtButton.ID = this.ID + "dtButtonID";
            dtButton.TypeControl = extOperationButton.TypeControls.Calendar;

            dtResetButton = new extOperationButton();
            dtResetButton.ID = this.ID + "dtResetButtonID";
            dtResetButton.TypeControl = extOperationButton.TypeControls.Delete;
           
            
            dtCalendar = new AjaxControlToolkit.CalendarExtender();
            dtCalendar.ID = this.ID + "CalendarExtenderID";
            dtCalendar.PopupButtonID = dtButton.ID;
            dtCalendar.TargetControlID = dtDate.ID;

            BorderWidth = new Unit(0);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            revdtDate.ValidationGroup = ValidationGroup;
            rvdtMinutes.ValidationGroup = ValidationGroup;
            rvdtHours.ValidationGroup = ValidationGroup;
        }

        public string TextClientId
        {
            get
            {
                return this.ClientID + "_" + dtDate.ID;
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
                    DateTime? d = Manitou.Helper.Converter.ToDateTimeNullable(dtDate.Text);
                    if (d == null)
                        return null;

                    return new DateTime(d.Value.Year, d.Value.Month, d.Value.Day, Manitou.Helper.Converter.ToInt32(dtHours.Text, true), Manitou.Helper.Converter.ToInt32(dtMinutes.Text, true), 0);
                }
                catch
                {
                    return DateTime.Now;
                }
            }
        }

        [DefaultValue("dd.MM.yyyy HH:mm")]
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
                return string.Format("{0} {1}:{2}",dtDate.Text, dtHours, dtMinutes);
            }

            set
            {
                string[] d = value.Split(new char[] {' ',':'});
                if (d != null && d.Length >= 3)
                {
                    dtDate.Text = d[0];
                    dtHours.Text = d[1];
                    dtMinutes.Text = d[2];
                }
                else
                {
                    dtDate.Text = "";
                    dtHours.Text = "";
                    dtMinutes.Text = "";
                }
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

        protected override void CreateChildControls()
        {
            HtmlTableRow tblRow1 = new HtmlTableRow();

            HtmlTableCell tblCelldtDate = new HtmlTableCell();
            tblCelldtDate.Controls.Add(dtDate);
            tblCelldtDate.Controls.Add(revdtDate);
            tblCelldtDate.Controls.Add(vcerevdtDate);
            tblRow1.Cells.Add(tblCelldtDate);

            
            tblCelldtDate = new HtmlTableCell();
            tblCelldtDate.Controls.Add(dtHours);
            tblCelldtDate.Controls.Add(rvdtHours);
            tblCelldtDate.Controls.Add(vcervdtHours);
            tblRow1.Cells.Add(tblCelldtDate);

            tblCelldtDate = new HtmlTableCell();
            tblCelldtDate.Controls.Add(dtMinutes);
            tblCelldtDate.Controls.Add(rvdtMinutes);
            tblCelldtDate.Controls.Add(vcervdtMinutes);
            tblRow1.Cells.Add(tblCelldtDate);

            HtmlTableCell tblCelldtButton = new HtmlTableCell();
            tblCelldtButton.Controls.Add(dtButton);

            HtmlTableCell tblCelldtResetButton = new HtmlTableCell();
            tblCelldtResetButton.Controls.Add(dtResetButton);
            
            tblRow1.Cells.Add(tblCelldtButton);
            tblRow1.Cells.Add(tblCelldtResetButton);
            
            HtmlTableCell tblCelldtCalendar = new HtmlTableCell();
            tblCelldtCalendar.ColSpan = 5;
            tblCelldtCalendar.Controls.Add(dtCalendar);

            HtmlTableRow tblRow2 = new HtmlTableRow();
            tblRow2.Cells.Add(tblCelldtCalendar);

            HtmlTable tbl = new HtmlTable();
            tbl.Rows.Add(tblRow1);
            tbl.Rows.Add(tblRow2);

            Controls.Add(tbl);

            base.CreateChildControls();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("document.getElementById('{0}').value = '';",dtDate.ClientID);
            sb.AppendFormat("document.getElementById('{0}').value = '';", dtHours.ClientID);
            sb.AppendFormat("document.getElementById('{0}').value = ''; return false;", dtMinutes.ClientID);
            dtResetButton.OnClientClick = sb.ToString();
            
            base.Render(writer);

            sb = new StringBuilder();

            if (!ClientReadOnlyData)
            {
                sb.AppendLine("document.getElementById('" + dtDate.ClientID + "').readOnly = false;");
                sb.AppendLine("document.getElementById('" + dtHours.ClientID + "').readOnly = false;");
                sb.AppendLine("document.getElementById('" + dtMinutes.ClientID + "').readOnly = false;");
            }
            else
            {
                sb.AppendLine("document.getElementById('" + dtDate.ClientID + "').readOnly = true;");
                sb.AppendLine("document.getElementById('" + dtHours.ClientID + "').readOnly = true;");
                sb.AppendLine("document.getElementById('" + dtMinutes.ClientID + "').readOnly = true;");
            }
            
            ScriptManager.RegisterStartupScript(this, GetType(), "readOnly_" + ClientID, sb.ToString(), true);
        }
    }
}
