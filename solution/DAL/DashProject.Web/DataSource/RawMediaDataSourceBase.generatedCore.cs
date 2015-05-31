using System;

namespace DashProject.Web.DataSource
{
    public class RawMediaDataSourceBase : Winnetou.WebControls.DataSources.extObjectDataSource
    {
        string _typeName = "DashProject.Repository.RawMediaFactory, DashProject.Repository";
        string _dataObjectTypeName = "DashProject.Entity.RawMedia, DashProject.Entity";

        public RawMediaDataSourceBase()
        {
            defaultView = new DashProject.Web.DataSourceView.RawMediaDataSourceView(this, _typeName, Context);
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);
        }

        public RawMediaDataSourceBase(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            defaultView = new DashProject.Web.DataSourceView.RawMediaDataSourceView(this, _typeName, Context);
            SelectMethod = selectMethod;
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
        }
    }
}