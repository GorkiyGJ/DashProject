using System;

namespace DashProject.Web.DataSource
{
    public class DashMediaDataSource : DashMediaDataSourceBase
    {
        public DashMediaDataSource()
            : base() { }

        public DashMediaDataSource(string typeName, string selectMethod)
            : base(typeName, selectMethod) { }
    }
}