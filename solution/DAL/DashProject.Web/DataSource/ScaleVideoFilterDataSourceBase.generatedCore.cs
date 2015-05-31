using System;

namespace DashProject.Web.DataSource
{
    public class ScaleVideoFilterDataSourceBase : Winnetou.WebControls.DataSources.extObjectDataSource
    {
        string _typeName = "DashProject.Repository.ScaleVideoFilterFactory, DashProject.Repository";
        string _dataObjectTypeName = "DashProject.Entity.ScaleVideoFilter, DashProject.Entity";

        public ScaleVideoFilterDataSourceBase()
        {
            defaultView = new DashProject.Web.DataSourceView.ScaleVideoFilterDataSourceView(this, _typeName, Context);
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);
        }

        public ScaleVideoFilterDataSourceBase(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            defaultView = new DashProject.Web.DataSourceView.ScaleVideoFilterDataSourceView(this, _typeName, Context);
            SelectMethod = selectMethod;
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
        }
    }
}