using System;

namespace DashProject.Web.DataSource
{
    public class StreamTypeDataSourceBase : Winnetou.WebControls.DataSources.extObjectDataSource
    {
        string _typeName = "DashProject.Repository.StreamTypeFactory, DashProject.Repository";
        string _dataObjectTypeName = "DashProject.Entity.StreamType, DashProject.Entity";

        public StreamTypeDataSourceBase()
        {
            defaultView = new DashProject.Web.DataSourceView.StreamTypeDataSourceView(this, _typeName, Context);
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);
        }

        public StreamTypeDataSourceBase(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            defaultView = new DashProject.Web.DataSourceView.StreamTypeDataSourceView(this, _typeName, Context);
            SelectMethod = selectMethod;
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
        }
    }
}