using System;

namespace DashProject.Web.DataSource
{
    public class DashMediaDataSourceBase : Winnetou.WebControls.DataSources.extObjectDataSource
    {
        string _typeName = "DashProject.Repository.DashMediaFactory, DashProject.Repository";
        string _dataObjectTypeName = "DashProject.Entity.DashMedia, DashProject.Entity";

        public DashMediaDataSourceBase()
        {
            defaultView = new DashProject.Web.DataSourceView.DashMediaDataSourceView(this, _typeName, Context);
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);
        }

        public DashMediaDataSourceBase(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            defaultView = new DashProject.Web.DataSourceView.DashMediaDataSourceView(this, _typeName, Context);
            SelectMethod = selectMethod;
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
        }
    }
}