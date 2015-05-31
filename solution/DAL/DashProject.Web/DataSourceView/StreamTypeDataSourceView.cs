using System;

namespace DashProject.Web.DataSourceView
{
    public class StreamTypeDataSourceView : StreamTypeDataSourceViewBase
    {
        public StreamTypeDataSourceView(DashProject.Web.DataSource.StreamTypeDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
    }
}