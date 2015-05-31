using System;

namespace DashProject.Web.DataSourceView
{
    public class VideoSizeDataSourceView : VideoSizeDataSourceViewBase
    {
        public VideoSizeDataSourceView(DashProject.Web.DataSource.VideoSizeDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
    }
}