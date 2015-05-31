using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Winnetou.WebControls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:extTextBox runat=server></{0}:extTextBox>")]
    [SupportsEventValidation]
    [ValidationProperty("Text")]
    public class extTextBox : CompositeControl
    {
        private readonly TextBox txt;
        private readonly CustomValidator cv;

        #region Properties

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

        [Themeable(false)]
        [DefaultValue("")]
        public virtual string ErrorMessage
        {
            get
            {
                return cv.ErrorMessage;
            }
            set
            {
                cv.ErrorMessage = value;
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

        [Themeable(false)]
        [DefaultValue(true)]
        public virtual bool ValidateOnInjection
        {
            get
            {
                if (ViewState["ValidateOnInjection"] != null)
                {
                    return Manitou.Helper.Converter.ToBollean(ViewState["ValidateOnInjection"]);
                }
                else
                {
                    return true;
                }
            }
            set
            {
                ViewState["ValidateOnInjection"] = value;
            }
        }

        [Bindable(true)]
        [Category("extSetting")]
        public string Text
        {
            get
            {
                return txt.Text;
            }

            set
            {
                txt.Text = value;
            }
        }

        [Bindable(true)]
        [Category("extSetting")]
        public string TxtClientID
        {
            get
            {
                return txt.ClientID;
            }
        }

        [Bindable(true)]
        [Category("extSetting")]
        public string TxtID
        {
            get
            {
                return txt.ID;
            }
        }

        [Bindable(true)]
        [Category("Width")]
        public override Unit Width
        {
            get
            {
                return txt.Width;
            }

            set
            {
                txt.Width = value;
            }
        }

        [Bindable(true)]
        [Category("Height")]
        public override Unit Height
        {
            get
            {
                return txt.Height;
            }

            set
            {
                txt.Height = value;
            }
        }

        [Bindable(true)]
        [Category("extSetting")]
        public int MaxLength
        {
            get
            {
                return txt.MaxLength;
            }

            set
            {
                txt.MaxLength = value;
            }
        }

        [Bindable(true)]
        [Category("extSetting")]
        public TextBoxMode TextMode
        {
            get
            {
                return txt.TextMode;
            }

            set
            {
                txt.TextMode = value;
            }
        }

        [Bindable(true)]
        [Category("extSetting")]
        public int Rows
        {
            get
            {
                return txt.Rows;
            }

            set
            {
                txt.Rows = value;
            }
        }

        [Bindable(true)]
        [Category("extSetting")]
        public bool Enabled
        {
            get
            {
                return txt.Enabled;
            }

            set
            {
                txt.Enabled = value;
            }
        }

        [Bindable(true)]
        [Category("extSetting")]
        public string CssClass
        {
            get
            {
                return txt.CssClass;
            }

            set
            {
                txt.CssClass = value;
            }
        }

        [Bindable(true)]
        [Category("extSetting")]
        public int Columns
        {
            get
            {
                return txt.Columns;
            }

            set
            {
                txt.Columns = value;
            }
        }

        #endregion

        public extTextBox()
        {
            txt = new TextBox();
            cv = new CustomValidator();
            BorderWidth = new Unit(0);
        }

        void cv_ServerValidate(object source, ServerValidateEventArgs e)
        {
            if (this.ValidateOnInjection)
            {

                e.IsValid = Manitou.Helper.StringUtils.IsFixText(e.Value);
            }
            else
            {
                e.IsValid = true;
            }
        }

        protected override void CreateChildControls()
        {
            txt.ID = this.ID + "_" + "txtID";
            cv.ID = this.ID + "_" + "cvID";
            cv.ControlToValidate = txt.ID;
            cv.Display = ValidatorDisplay.Static;
            cv.SetFocusOnError = true;
            if (string.IsNullOrEmpty(this.ErrorMessage))
            {
                cv.ErrorMessage = "Обнаружено потенциально опасное значение.";
            }
            cv.EnableViewState = false;
            if (!string.IsNullOrEmpty(this.ValidationGroup))
            {
                cv.ValidationGroup = this.ValidationGroup;
            }
            cv.ServerValidate += new ServerValidateEventHandler(cv_ServerValidate);

            Controls.Add(txt);
            Controls.Add(new LiteralControl("<br />"));
            Controls.Add(cv);

            base.CreateChildControls();
        }

    }
}
