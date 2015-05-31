using System;

namespace DashProject.Web.DataSource
{
    public class StreamDataSourceBase : Winnetou.WebControls.DataSources.extObjectDataSource
    {
        string _typeName = "DashProject.Repository.StreamFactory, DashProject.Repository";
        string _dataObjectTypeName = "DashProject.Entity.Stream, DashProject.Entity";

        public StreamDataSourceBase()
        {
            defaultView = new DashProject.Web.DataSourceView.StreamDataSourceView(this, _typeName, Context);
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);
        }

        public StreamDataSourceBase(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            defaultView = new DashProject.Web.DataSourceView.StreamDataSourceView(this, _typeName, Context);
            SelectMethod = selectMethod;
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
        }
    }
}