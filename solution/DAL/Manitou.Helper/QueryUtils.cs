using System.Collections.Specialized;
using System.Web;
using System.Text;

namespace Manitou.Helper
{
    public static class QueryUtils
    {
        public const string keyFilter = "Manitou.Helper.QueryUtils";

        public static NameValueCollection QueryString
        {
            get
            {
                if (HttpContext.Current.Items.Contains(keyFilter))
                    return (NameValueCollection)HttpContext.Current.Items[keyFilter];

                return HttpContext.Current.Request.QueryString;
            }

            set
            {
                HttpContext.Current.Items[keyFilter] = value;
            }
        }

        public static string GetFullQuery
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                NameValueCollection q = QueryString;

                foreach (string key in q.AllKeys)
                {
                    sb.Append(key);
                    sb.Append("=");
                    sb.Append(q[key]);
                    sb.Append("&");
                }

                return sb.ToString();
            }
        }
    }
}
