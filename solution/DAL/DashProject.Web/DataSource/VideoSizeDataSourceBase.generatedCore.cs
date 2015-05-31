using System;

namespace DashProject.Web.DataSource
{
    public class VideoSizeDataSourceBase : Winnetou.WebControls.DataSources.extObjectDataSource
    {
        string _typeName = "DashProject.Repository.VideoSizeFactory, DashProject.Repository";
        string _dataObjectTypeName = "DashProject.Entity.VideoSize, DashProject.Entity";

        public VideoSizeDataSourceBase()
        {
            defaultView = new DashProject.Web.DataSourceView.VideoSizeDataSourceView(this, _typeName, Context);
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);
        }

        public VideoSizeDataSourceBase(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            defaultView = new DashProject.Web.DataSourceView.VideoSizeDataSourceView(this, _typeName, Context);
            SelectMethod = selectMethod;
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
        }
    }
}