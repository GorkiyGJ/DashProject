using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

namespace Manitou.Helper
{
    public class WebUtils
    {
        public static bool ValidateEmail(string value)
        {
            return Regex.IsMatch(value, @"^[a-z0-9._-~%+<>]+@(\w[a-z0-9.-]*\w|\w)\.[a-z]{2,4}$", RegexOptions.IgnoreCase);
        }

        public static bool IsAsyncPostBackRequest()
        {
            NameValueCollection headers = HttpContext.Current.Request.Headers;
            string[] values = headers.GetValues("X-MicrosoftAjax");
            if (values != null)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    string[] headerContents = values[i].Split(',');
                    for (int j = 0; j < headerContents.Length; j++)
                    {
                        if (headerContents[j].Trim() == "Delta=true")
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static string IP
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Request != null)
                    return HttpContext.Current.Request.UserHostAddress;
                else
                    return "(none)";
            }
        }

        public static string SetNoIndex(object value)
        {
            if (value != null)
                return string.Format("<noindex><nofollow>{0}</nofollow></noindex>", Manitou.Helper.Converter.ToString(value));

            return "";
        }

        public static string RootHTTP
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Request != null)
                {
                    if (!HttpContext.Current.Items.Contains("WebUtils.RootHTTP"))
                    {
                        string value = (string.Format("{0}://{1}{2}/", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Authority, HttpContext.Current.Request.ApplicationPath)).Replace("//", "/").Replace(":/", "://");
                        HttpContext.Current.Items["WebUtils.RootHTTP"] = value;

                        return value;
                    }
                    else
                        return (string)HttpContext.Current.Items["WebUtils.RootHTTP"];
                }
                else
                {
                    return "/";
                }
            }
        }

        public static string RootHTTPWWW
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Request != null)
                {
                    if (!HttpContext.Current.Items.Contains("WebUtils.RootHTTPWWW"))
                    {
                        string value;
                        if (HttpContext.Current.Request.Url.Host != "localhost" && HttpContext.Current.Request.Url.Authority.IndexOf("www.") == -1)
                            value = (string.Format("{0}://www.{1}{2}/", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Authority, HttpContext.Current.Request.ApplicationPath)).Replace("//", "/").Replace(":/", "://");
                        else
                            value = RootHTTP;

                        HttpContext.Current.Items["WebUtils.RootHTTPWWW"] = value;

                        return value;
                    }
                    else
                        return (string)HttpContext.Current.Items["WebUtils.RootHTTPWWW"];
                }
                else
                {
                    return "/";
                }
            }
        }

        public static string RootHTTPNoAbsolute
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Request != null && HttpContext.Current.Items.Contains("WebUtils.RootHTTPNoAbsolute"))
                {
                    return (string)HttpContext.Current.Items["WebUtils.RootHTTPNoAbsolute"];
                }
                else
                {
                    string path;
                    if (HttpContext.Current != null && HttpContext.Current.Request != null)
                        path = HttpContext.Current.Request.ApplicationPath + "/" + HttpContext.Current.Request.PathInfo;
                    else
                        path = "/";

                    if (path.Length > 2 && path[path.Length - 1] == '/' && path[path.Length - 2] == '/')
                    {
                        path = path.Substring(0, path.Length - 1);
                    }

                    path.Replace("//", "/");

                    if (HttpContext.Current != null && HttpContext.Current.Request != null && HttpContext.Current.Items.Contains("WebUtils.RootHTTPNoAbsolute"))
                        HttpContext.Current.Items["WebUtils.RootHTTPNoAbsolute"] = path;

                    return path;
                }
            }
        }

        public static bool IsRequestIsNotNull(HttpRequest Request, string value)
        {
            return Request != null && QueryUtils.QueryString != null && QueryUtils.QueryString[value] != null && QueryUtils.QueryString[value] != String.Empty;
        }

        public static int? GetRequestParamValueInt32Nullable(HttpRequest Request, string paramName)
        {
            if (IsRequestIsNotNull(Request, paramName))
            {
                return Manitou.Helper.Converter.ToInt32Nullable(QueryUtils.QueryString[paramName]);
            }

            return null;
        }

        public static int GetRequestParamValueInt32(HttpRequest Request, string paramName)
        {
            if (IsRequestIsNotNull(Request, paramName))
            {
                return Manitou.Helper.Converter.ToInt32(QueryUtils.QueryString[paramName]);
            }

            return -1;
        }

        public static short GetRequestParamValueInt16(HttpRequest Request, string paramName)
        {
            if (IsRequestIsNotNull(Request, paramName))
            {
                return Manitou.Helper.Converter.ToInt16(QueryUtils.QueryString[paramName]);
            }

            return -1;
        }

        public static bool GetRequestParamValueBoolean(HttpRequest Request, string paramName)
        {
            if (IsRequestIsNotNull(Request, paramName))
            {
                return Manitou.Helper.Converter.ToBollean(QueryUtils.QueryString[paramName]);
            }

            return false;
        }

        public static string GetRequestParamValueString(HttpRequest Request, string paramName)
        {
            if (IsRequestIsNotNull(Request, paramName))
            {
                return Manitou.Helper.Converter.ToStringNullable(QueryUtils.QueryString[paramName]);
            }

            return null;
        }

        public static string GetCurrentPageName(Page obj)
        {
            return (obj).AppRelativeVirtualPath.Replace((obj).AppRelativeTemplateSourceDirectory, "");
        }

        public static void JavaClose(Page page)
        {
            page.Response.Write("<script language='JavaScript'> window.close(); </script>");
        }

        public static void JavaReloadParent(Page page)
        {
            page.Response.Write("<script language='JavaScript'> window.opener.document.location.reload(true); </script>");
        }

        public static string MSSQLAntiEjection(string value)
        {
            return value.Trim().Replace("'", "''").Replace("\'", "").Replace("\\\"", "");
        }

        public static bool GetRequestFormValue(string SearchKey, out string value)
        {
            NameValueCollection FormNVC = HttpContext.Current.Request.Form;
            string[] keys = FormNVC.AllKeys;

            value = null;
            foreach (string key in keys)
            {
                if (key.Contains(SearchKey))
                {
                    value = MSSQLAntiEjection(FormNVC[key]);
                    return true;
                }
            }

            return false;
        }

        public static string GetRequestFormValue(string SearchKey)
        {
            NameValueCollection FormNVC = HttpContext.Current.Request.Form;
            string[] keys = FormNVC.AllKeys;
            foreach (string key in keys)
            {
                if (key.Contains(SearchKey))
                    return FormNVC[key];
            }

            return null;
        }

        public static void SetAlternative(HtmlTable tbl)
        {
            bool isColor = true;
            foreach (HtmlTableRow r in tbl.Rows)
            {
                if (r.Visible)
                {
                    if (isColor)
                        r.BgColor = "#EFEFF3";
                    else
                        r.BgColor = "#FFFFFF";

                    isColor = !isColor;
                }
            }
        }

        public static string GetAlt(object value)
        {
            return Manitou.Helper.Converter.ToString(value).Replace('\'', ' ').Replace('\"', ' ');
        }

        public static string StripHTML(string text, string[] tags)
        {
            foreach (string t in tags)
                text = Regex.Replace(text, @"<" + t + "\\s*?(.*=\".*\"\\s*?)*?(/>|>.*?</\\s*?" + t + "\\s*?>)", string.Empty);

            return text;
        }

        public static string StripHTML(string text)
        {
            return Regex.Replace(text, @"<(.|\n)*?>", string.Empty);
        }

        public static string NL2BR(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;
            return text.Replace("\r\n", "<br />").Replace("\n", "<br />").Replace("\r", string.Empty);
        }

        public static string BR2NL(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;
            return text.Replace("<br />", "\r\n").Replace("<br/>", "\r\n").Replace("<br>", "\r\n");
        }
    }
}
