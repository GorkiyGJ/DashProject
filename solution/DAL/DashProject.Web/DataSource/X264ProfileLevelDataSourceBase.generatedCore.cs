using System;

namespace DashProject.Web.DataSource
{
    public class X264ProfileLevelDataSourceBase : Winnetou.WebControls.DataSources.extObjectDataSource
    {
        string _typeName = "DashProject.Repository.X264ProfileLevelFactory, DashProject.Repository";
        string _dataObjectTypeName = "DashProject.Entity.X264ProfileLevel, DashProject.Entity";

        public X264ProfileLevelDataSourceBase()
        {
            defaultView = new DashProject.Web.DataSourceView.X264ProfileLevelDataSourceView(this, _typeName, Context);
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);
        }

        public X264ProfileLevelDataSourceBase(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            defaultView = new DashProject.Web.DataSourceView.X264ProfileLevelDataSourceView(this, _typeName, Context);
            SelectMethod = selectMethod;
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
        }
    }
}