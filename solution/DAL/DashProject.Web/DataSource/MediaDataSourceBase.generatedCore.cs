using System;

namespace DashProject.Web.DataSource
{
    public class MediaDataSourceBase : Winnetou.WebControls.DataSources.extObjectDataSource
    {
        string _typeName = "DashProject.Repository.MediaFactory, DashProject.Repository";
        string _dataObjectTypeName = "DashProject.Entity.Media, DashProject.Entity";

        public MediaDataSourceBase()
        {
            defaultView = new DashProject.Web.DataSourceView.MediaDataSourceView(this, _typeName, Context);
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);
        }

        public MediaDataSourceBase(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            defaultView = new DashProject.Web.DataSourceView.MediaDataSourceView(this, _typeName, Context);
            SelectMethod = selectMethod;
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
        }
    }
}