using System;

namespace DashProject.Web.DataSource
{
    public class X264ProfileDataSourceBase : Winnetou.WebControls.DataSources.extObjectDataSource
    {
        string _typeName = "DashProject.Repository.X264ProfileFactory, DashProject.Repository";
        string _dataObjectTypeName = "DashProject.Entity.X264Profile, DashProject.Entity";

        public X264ProfileDataSourceBase()
        {
            defaultView = new DashProject.Web.DataSourceView.X264ProfileDataSourceView(this, _typeName, Context);
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);
        }

        public X264ProfileDataSourceBase(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            defaultView = new DashProject.Web.DataSourceView.X264ProfileDataSourceView(this, _typeName, Context);
            SelectMethod = selectMethod;
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
        }
    }
}