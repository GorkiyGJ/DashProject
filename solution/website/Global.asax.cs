using System;
using System.Web;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

public partial class _Global : HttpApplication
{
    public _Global()
    {

    }

    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        /*string[] queryes = null;
        if(Request.QueryString != null && Request.QueryString.Count > 0)
            queryes = Server.UrlDecode(Request.QueryString.ToString()).Split('&', ',');
        if (queryes != null && queryes.Length > 0)
        {
            //Request.QueryString.Clear();
            foreach(string input in queryes)
            {
                if (!Regex.IsMatch(input, @"(^\w*=\w*$)", RegexOptions.Singleline))
                    continue;
                string[] arr = input.Split('=');
                if (arr.Length != 1)
                    continue;
                string parameter = arr[0];
                string value = arr[1];
                Request.QueryString.Add(parameter,value);
            }
        }*/
    }
}
