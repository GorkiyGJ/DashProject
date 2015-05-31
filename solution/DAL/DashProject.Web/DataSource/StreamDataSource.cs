using System;

namespace DashProject.Web.DataSource
{
    public class StreamDataSource : StreamDataSourceBase
    {
        public StreamDataSource()
            : base() { }

        public StreamDataSource(string typeName, string selectMethod)
            : base(typeName, selectMethod) { }
    }
}