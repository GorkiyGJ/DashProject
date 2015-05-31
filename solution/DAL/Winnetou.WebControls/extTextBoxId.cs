using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Web.UI.Design.WebControls;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Winnetou.WebControls
{
    [DefaultProperty("DataText")]
    [Designer(typeof(extTextBoxIdDesigner))]
    [ToolboxData("<{0}:extTextBoxId runat=server></{0}:extTextBoxId>")]
    [SupportsEventValidation]
    [ValidationProperty("DataText")]
    public class extTextBoxId : CompositeControl
    {
        #region "private"
        private readonly TextBox txtId;
        private readonly TextBox txtName;
        #endregion

        #region "Свойства"
        [Themeable(false)]
        [DefaultValue("")]
        public bool VisibleId
        {
            get
            {
                return txtId.Style["display"] == "block";
            }
            set
            {
                txtId.Style["display"] = value ? "block" : "none";
            }
        }
        
        [Themeable(false)]
        [DefaultValue("")]
        public virtual string ValidationGroup
        {
            get
            {
                return Manitou.Helper.Converter.ToString(ViewState["ValidationGroup"]);
            }
            set
            {
                ViewState["ValidationGroup"] = value;
            }
        }

        [DefaultValue(false)]
        [Themeable(false)]
        public virtual bool CausesValidation
        {
            get
            {
                return Manitou.Helper.Converter.ToBollean(ViewState["CausesValidation"]);
            }
            set
            {
                ViewState["CausesValidation"] = value;
            }
        }

        [Bindable(true)]
        [Category("extSetting")]
        public string DataText
        {
            get
            {
                return txtName.Text;
            }

            set
            {
                txtName.Text = value;
            }
        }

        [Bindable(true)]
        [Category("extSetting")]
        public string TextClientId
        {
            get
            {
                return this.ClientID + "_" + txtName.ID;
            }
        }

        [Bindable(true)]
        [Category("extSetting")]
        public string IdClientId
        {
            get
            {
                return this.ClientID + "_" + txtId.ID;
            }
        }

        [Bindable(true)]
        [Category("extSetting")]
        public string TextServerId
        {
            get
            {
                return txtName.ID;
            }
        }

        [Bindable(true)]
        [Category("extSetting")]
        public string IdServerId
        {
            get
            {
                return txtId.ID;
            }
        }

        [Bindable(true)]
        [Category("extSetting")]
        public int? DataId
        {
            get
            {
                return Manitou.Helper.Converter.ToInt32Nullable(txtId.Text);
            }

            set
            {
                txtId.Text = Manitou.Helper.Converter.ToString(value);
            }
        }

        [Bindable(true)]
        [Category("extSetting")]
        [DefaultValue("true")]
        public bool ReadOnlyText
        {
            get
            {
                if (ViewState["ReadOnlyText"] == null)
                    return true;

                return (bool)ViewState["ReadOnlyText"];
            }

            set
            {
                ViewState["ReadOnlyText"] = value;
            }
        }

        [Browsable(false)]
        public override Unit Width
        {
            get
            {
                return base.Width;
            }
            set
            {
                base.Width = value;
            }
        }

        [Browsable(false)]
        public override Unit Height
        {
            get
            {
                return base.Height;
            }
            set
            {
                base.Height = value;
            }
        }

        [Bindable(true)]
        [Category("Width")]
        public Unit WidthId
        {
            get
            {
                return txtId.Width;
            }

            set
            {
                txtId.Width = value;
            }
        }

        [Bindable(true)]
        [Category("Width")]
        public Unit WidthName
        {
            get
            {
                return txtName.Width;
            }

            set
            {
                txtName.Width = value;
            }
        }

        [Bindable(true)]
        [Category("CssClass")]
        public string CssClassName
        {
            get
            {
                return txtName.CssClass;
            }

            set
            {
                txtName.CssClass = value;
            }
        }
        #endregion

        public extTextBoxId()
        {
            txtId = new TextBox();
            txtName = new TextBox();

            txtId.ID = "txtID";
            txtName.ID = "txtName";

            BorderWidth = new Unit(0);
        }

        protected override void CreateChildControls()
        {
            HtmlTableCell tblCellId = new HtmlTableCell();
            tblCellId.Controls.Add(txtId);

            HtmlTableCell tblCellName = new HtmlTableCell();
            tblCellName.Controls.Add(txtName);
            //tblCellName.Width = "100%";

            HtmlTableRow tblRow = new HtmlTableRow();
            tblRow.Cells.Add(tblCellId);
            tblRow.Cells.Add(tblCellName);

            HtmlTable tbl = new HtmlTable();
            tbl.Rows.Add(tblRow);

            Controls.Add(tbl);

            base.CreateChildControls();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("document.getElementById('" + txtId.ClientID + "').readOnly = true;");

            if (ReadOnlyText)
                sb.AppendLine("document.getElementById('" + txtName.ClientID + "').readOnly = true;");


            ScriptManager.RegisterStartupScript(this, GetType(), "readOnly_" + ClientID, sb.ToString(), true);
        }
    }

    public class extTextBoxIdDesigner : CompositeControlDesigner
    {
        public override bool AllowResize
        {
            get { return false; }
        }
    }
}