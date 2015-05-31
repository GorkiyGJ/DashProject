using System;

namespace DashProject.Web.DataSource
{
    public class ApplicationConfigurationDataSource : ApplicationConfigurationDataSourceBase
    {
        public ApplicationConfigurationDataSource()
            : base() { }

        public ApplicationConfigurationDataSource(string typeName, string selectMethod)
            : base(typeName, selectMethod) { }
    }
}