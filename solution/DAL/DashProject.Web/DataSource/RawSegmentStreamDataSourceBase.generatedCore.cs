using System;

namespace DashProject.Web.DataSource
{
    public class RawSegmentStreamDataSourceBase : Winnetou.WebControls.DataSources.extObjectDataSource
    {
        string _typeName = "DashProject.Repository.RawSegmentStreamFactory, DashProject.Repository";
        string _dataObjectTypeName = "DashProject.Entity.RawSegmentStream, DashProject.Entity";

        public RawSegmentStreamDataSourceBase()
        {
            defaultView = new DashProject.Web.DataSourceView.RawSegmentStreamDataSourceView(this, _typeName, Context);
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);
        }

        public RawSegmentStreamDataSourceBase(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            defaultView = new DashProject.Web.DataSourceView.RawSegmentStreamDataSourceView(this, _typeName, Context);
            SelectMethod = selectMethod;
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
        }
    }
}