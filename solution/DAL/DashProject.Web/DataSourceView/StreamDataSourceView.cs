using System;

namespace DashProject.Web.DataSourceView
{
    public class StreamDataSourceView : StreamDataSourceViewBase
    {
        public StreamDataSourceView(DashProject.Web.DataSource.StreamDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
    }
}