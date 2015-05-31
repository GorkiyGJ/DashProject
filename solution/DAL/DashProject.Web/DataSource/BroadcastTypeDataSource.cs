using System;

namespace DashProject.Web.DataSource
{
    public class BroadcastTypeDataSource : BroadcastTypeDataSourceBase
    {
        public BroadcastTypeDataSource()
            : base() { }

        public BroadcastTypeDataSource(string typeName, string selectMethod)
            : base(typeName, selectMethod) { }
    }
}