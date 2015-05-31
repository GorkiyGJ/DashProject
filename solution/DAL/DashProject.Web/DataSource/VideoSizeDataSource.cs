using System;

namespace DashProject.Web.DataSource
{
    public class VideoSizeDataSource : VideoSizeDataSourceBase
    {
        public VideoSizeDataSource()
            : base() { }

        public VideoSizeDataSource(string typeName, string selectMethod)
            : base(typeName, selectMethod) { }
    }
}