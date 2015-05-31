using System;

namespace DashProject.Web.DataSource
{
    public class MediaDataSource : MediaDataSourceBase
    {
        public MediaDataSource()
            : base() { }

        public MediaDataSource(string typeName, string selectMethod)
            : base(typeName, selectMethod) { }
    }
}