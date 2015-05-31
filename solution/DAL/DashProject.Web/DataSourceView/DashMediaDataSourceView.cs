using System;

namespace DashProject.Web.DataSourceView
{
    public class DashMediaDataSourceView : DashMediaDataSourceViewBase
    {
        public DashMediaDataSourceView(DashProject.Web.DataSource.DashMediaDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
    }
}