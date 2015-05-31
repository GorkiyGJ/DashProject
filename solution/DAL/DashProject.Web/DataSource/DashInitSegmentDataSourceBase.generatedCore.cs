using System;

namespace DashProject.Web.DataSource
{
    public class DashInitSegmentDataSourceBase : Winnetou.WebControls.DataSources.extObjectDataSource
    {
        string _typeName = "DashProject.Repository.DashInitSegmentFactory, DashProject.Repository";
        string _dataObjectTypeName = "DashProject.Entity.DashInitSegment, DashProject.Entity";

        public DashInitSegmentDataSourceBase()
        {
            defaultView = new DashProject.Web.DataSourceView.DashInitSegmentDataSourceView(this, _typeName, Context);
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);
        }

        public DashInitSegmentDataSourceBase(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            defaultView = new DashProject.Web.DataSourceView.DashInitSegmentDataSourceView(this, _typeName, Context);
            SelectMethod = selectMethod;
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
        }
    }
}