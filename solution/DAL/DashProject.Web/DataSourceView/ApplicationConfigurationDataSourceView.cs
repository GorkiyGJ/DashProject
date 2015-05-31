using System;

namespace DashProject.Web.DataSourceView
{
    public class ApplicationConfigurationDataSourceView : ApplicationConfigurationDataSourceViewBase
    {
        public ApplicationConfigurationDataSourceView(DashProject.Web.DataSource.ApplicationConfigurationDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
    }
}