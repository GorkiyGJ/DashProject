using System;
using System.Collections.Generic;

using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Winnetou.WebControls
{
    public class extTextBoxReadOnly : TextBox
    {
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("document.getElementById('" + ClientID + "').readOnly = true;");
            ScriptManager.RegisterStartupScript(this, GetType(), "readOnly_" + ClientID, sb.ToString(), true);
        }
    }
}
