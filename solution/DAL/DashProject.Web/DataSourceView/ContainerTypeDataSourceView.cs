using System;

namespace DashProject.Web.DataSourceView
{
    public class ContainerTypeDataSourceView : ContainerTypeDataSourceViewBase
    {
        public ContainerTypeDataSourceView(DashProject.Web.DataSource.ContainerTypeDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
    }
}