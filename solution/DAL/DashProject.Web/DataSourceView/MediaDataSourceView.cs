using System;

namespace DashProject.Web.DataSourceView
{
    public class MediaDataSourceView : MediaDataSourceViewBase
    {
        public MediaDataSourceView(DashProject.Web.DataSource.MediaDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
    }
}