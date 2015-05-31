using System;

namespace DashProject.Web.DataSource
{
    public class AACTranscoderConfigDataSourceBase : Winnetou.WebControls.DataSources.extObjectDataSource
    {
        string _typeName = "DashProject.Repository.AACTranscoderConfigFactory, DashProject.Repository";
        string _dataObjectTypeName = "DashProject.Entity.AACTranscoderConfig, DashProject.Entity";

        public AACTranscoderConfigDataSourceBase()
        {
            defaultView = new DashProject.Web.DataSourceView.AACTranscoderConfigDataSourceView(this, _typeName, Context);
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);
        }

        public AACTranscoderConfigDataSourceBase(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            defaultView = new DashProject.Web.DataSourceView.AACTranscoderConfigDataSourceView(this, _typeName, Context);
            SelectMethod = selectMethod;
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
        }
    }
}