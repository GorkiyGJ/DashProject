using System;

namespace DashProject.Web.DataSourceView
{
    public class DashMediaSegmentDataSourceView : DashMediaSegmentDataSourceViewBase
    {
        public DashMediaSegmentDataSourceView(DashProject.Web.DataSource.DashMediaSegmentDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
    }
}