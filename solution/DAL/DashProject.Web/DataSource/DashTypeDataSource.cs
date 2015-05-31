using System;

namespace DashProject.Web.DataSource
{
    public class DashTypeDataSource : DashTypeDataSourceBase
    {
        public DashTypeDataSource()
            : base() { }

        public DashTypeDataSource(string typeName, string selectMethod)
            : base(typeName, selectMethod) { }
    }
}