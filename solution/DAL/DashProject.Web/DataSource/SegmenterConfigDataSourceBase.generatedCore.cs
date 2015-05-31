using System;

namespace DashProject.Web.DataSource
{
    public class SegmenterConfigDataSourceBase : Winnetou.WebControls.DataSources.extObjectDataSource
    {
        string _typeName = "DashProject.Repository.SegmenterConfigFactory, DashProject.Repository";
        string _dataObjectTypeName = "DashProject.Entity.SegmenterConfig, DashProject.Entity";

        public SegmenterConfigDataSourceBase()
        {
            defaultView = new DashProject.Web.DataSourceView.SegmenterConfigDataSourceView(this, _typeName, Context);
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);
        }

        public SegmenterConfigDataSourceBase(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            defaultView = new DashProject.Web.DataSourceView.SegmenterConfigDataSourceView(this, _typeName, Context);
            SelectMethod = selectMethod;
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
        }
    }
}