using System;

namespace DashProject.Web.DataSource
{
    public class ApplicationConfigurationDataSourceBase : Winnetou.WebControls.DataSources.extObjectDataSource
    {
        string _typeName = "DashProject.Repository.ApplicationConfigurationFactory, DashProject.Repository";
        string _dataObjectTypeName = "DashProject.Entity.ApplicationConfiguration, DashProject.Entity";

        public ApplicationConfigurationDataSourceBase()
        {
            defaultView = new DashProject.Web.DataSourceView.ApplicationConfigurationDataSourceView(this, _typeName, Context);
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);
        }

        public ApplicationConfigurationDataSourceBase(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            defaultView = new DashProject.Web.DataSourceView.ApplicationConfigurationDataSourceView(this, _typeName, Context);
            SelectMethod = selectMethod;
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
        }
    }
}