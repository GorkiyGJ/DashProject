using System;

namespace DashProject.Web.DataSourceView
{
    public class RawMediaDataSourceView : RawMediaDataSourceViewBase
    {
        public RawMediaDataSourceView(DashProject.Web.DataSource.RawMediaDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
    }
}