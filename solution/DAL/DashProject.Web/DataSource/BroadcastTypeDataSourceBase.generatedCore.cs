using System;

namespace DashProject.Web.DataSource
{
    public class BroadcastTypeDataSourceBase : Winnetou.WebControls.DataSources.extObjectDataSource
    {
        string _typeName = "DashProject.Repository.BroadcastTypeFactory, DashProject.Repository";
        string _dataObjectTypeName = "DashProject.Entity.BroadcastType, DashProject.Entity";

        public BroadcastTypeDataSourceBase()
        {
            defaultView = new DashProject.Web.DataSourceView.BroadcastTypeDataSourceView(this, _typeName, Context);
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);
        }

        public BroadcastTypeDataSourceBase(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            defaultView = new DashProject.Web.DataSourceView.BroadcastTypeDataSourceView(this, _typeName, Context);
            SelectMethod = selectMethod;
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
        }
    }
}