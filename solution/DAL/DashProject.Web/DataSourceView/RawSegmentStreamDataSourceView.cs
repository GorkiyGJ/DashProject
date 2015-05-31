using System;

namespace DashProject.Web.DataSourceView
{
    public class RawSegmentStreamDataSourceView : RawSegmentStreamDataSourceViewBase
    {
        public RawSegmentStreamDataSourceView(DashProject.Web.DataSource.RawSegmentStreamDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
    }
}