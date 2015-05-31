using System;

namespace DashProject.Web.DataSource
{
    public class ContainerTypeDataSource : ContainerTypeDataSourceBase
    {
        public ContainerTypeDataSource()
            : base() { }

        public ContainerTypeDataSource(string typeName, string selectMethod)
            : base(typeName, selectMethod) { }
    }
}