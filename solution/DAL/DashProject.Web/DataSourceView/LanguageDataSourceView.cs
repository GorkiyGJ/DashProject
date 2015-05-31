using System;

namespace DashProject.Web.DataSourceView
{
    public class LanguageDataSourceView : LanguageDataSourceViewBase
    {
        public LanguageDataSourceView(DashProject.Web.DataSource.LanguageDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
    }
}