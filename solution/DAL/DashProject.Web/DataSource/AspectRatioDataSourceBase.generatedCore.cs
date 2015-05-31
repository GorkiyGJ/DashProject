using System;

namespace DashProject.Web.DataSource
{
    public class AspectRatioDataSourceBase : Winnetou.WebControls.DataSources.extObjectDataSource
    {
        string _typeName = "DashProject.Repository.AspectRatioFactory, DashProject.Repository";
        string _dataObjectTypeName = "DashProject.Entity.AspectRatio, DashProject.Entity";

        public AspectRatioDataSourceBase()
        {
            defaultView = new DashProject.Web.DataSourceView.AspectRatioDataSourceView(this, _typeName, Context);
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);
        }

        public AspectRatioDataSourceBase(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            defaultView = new DashProject.Web.DataSourceView.AspectRatioDataSourceView(this, _typeName, Context);
            SelectMethod = selectMethod;
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
        }
    }
}