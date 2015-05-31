using System;

namespace DashProject.Web.DataSource
{
    public class LanguageDataSourceBase : Winnetou.WebControls.DataSources.extObjectDataSource
    {
        string _typeName = "DashProject.Repository.LanguageFactory, DashProject.Repository";
        string _dataObjectTypeName = "DashProject.Entity.Language, DashProject.Entity";

        public LanguageDataSourceBase()
        {
            defaultView = new DashProject.Web.DataSourceView.LanguageDataSourceView(this, _typeName, Context);
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);
        }

        public LanguageDataSourceBase(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            defaultView = new DashProject.Web.DataSourceView.LanguageDataSourceView(this, _typeName, Context);
            SelectMethod = selectMethod;
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
        }
    }
}