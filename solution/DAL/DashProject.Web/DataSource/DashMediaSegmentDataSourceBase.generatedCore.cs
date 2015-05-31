using System;

namespace DashProject.Web.DataSource
{
    public class DashMediaSegmentDataSourceBase : Winnetou.WebControls.DataSources.extObjectDataSource
    {
        string _typeName = "DashProject.Repository.DashMediaSegmentFactory, DashProject.Repository";
        string _dataObjectTypeName = "DashProject.Entity.DashMediaSegment, DashProject.Entity";

        public DashMediaSegmentDataSourceBase()
        {
            defaultView = new DashProject.Web.DataSourceView.DashMediaSegmentDataSourceView(this, _typeName, Context);
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);
        }

        public DashMediaSegmentDataSourceBase(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            defaultView = new DashProject.Web.DataSourceView.DashMediaSegmentDataSourceView(this, _typeName, Context);
            SelectMethod = selectMethod;
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
        }
    }
}