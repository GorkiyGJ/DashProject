using System;

namespace DashProject.Web.DataSourceView
{
    public class AspectRatioDataSourceView : AspectRatioDataSourceViewBase
    {
        public AspectRatioDataSourceView(DashProject.Web.DataSource.AspectRatioDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
    }
}