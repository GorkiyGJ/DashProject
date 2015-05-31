using System;

namespace DashProject.Web.DataSource
{
    public class StreamTypeDataSource : StreamTypeDataSourceBase
    {
        public StreamTypeDataSource()
            : base() { }

        public StreamTypeDataSource(string typeName, string selectMethod)
            : base(typeName, selectMethod) { }
    }
}