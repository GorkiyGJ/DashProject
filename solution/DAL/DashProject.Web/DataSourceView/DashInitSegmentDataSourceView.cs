using System;

namespace DashProject.Web.DataSourceView
{
    public class DashInitSegmentDataSourceView : DashInitSegmentDataSourceViewBase
    {
        public DashInitSegmentDataSourceView(DashProject.Web.DataSource.DashInitSegmentDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
    }
}