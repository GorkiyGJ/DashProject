using System;

namespace DashProject.Web.DataSourceView
{
    public class DashTypeDataSourceView : DashTypeDataSourceViewBase
    {
        public DashTypeDataSourceView(DashProject.Web.DataSource.DashTypeDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
    }
}