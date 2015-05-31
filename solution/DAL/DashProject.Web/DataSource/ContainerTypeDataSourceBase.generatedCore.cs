using System;

namespace DashProject.Web.DataSource
{
    public class ContainerTypeDataSourceBase : Winnetou.WebControls.DataSources.extObjectDataSource
    {
        string _typeName = "DashProject.Repository.ContainerTypeFactory, DashProject.Repository";
        string _dataObjectTypeName = "DashProject.Entity.ContainerType, DashProject.Entity";

        public ContainerTypeDataSourceBase()
        {
            defaultView = new DashProject.Web.DataSourceView.ContainerTypeDataSourceView(this, _typeName, Context);
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);
        }

        public ContainerTypeDataSourceBase(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            defaultView = new DashProject.Web.DataSourceView.ContainerTypeDataSourceView(this, _typeName, Context);
            SelectMethod = selectMethod;
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
        }
    }
}