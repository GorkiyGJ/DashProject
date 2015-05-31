using System;

namespace DashProject.Web.DataSource
{
    public class RawMediaSourceTypeDataSourceBase : Winnetou.WebControls.DataSources.extObjectDataSource
    {
        string _typeName = "DashProject.Repository.RawMediaSourceTypeFactory, DashProject.Repository";
        string _dataObjectTypeName = "DashProject.Entity.RawMediaSourceType, DashProject.Entity";

        public RawMediaSourceTypeDataSourceBase()
        {
            defaultView = new DashProject.Web.DataSourceView.RawMediaSourceTypeDataSourceView(this, _typeName, Context);
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);
        }

        public RawMediaSourceTypeDataSourceBase(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            defaultView = new DashProject.Web.DataSourceView.RawMediaSourceTypeDataSourceView(this, _typeName, Context);
            SelectMethod = selectMethod;
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
        }
    }
}