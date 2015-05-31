using System;

namespace DashProject.Web.DataSource
{
    public class LIBx264EncoderConfigDataSourceBase : Winnetou.WebControls.DataSources.extObjectDataSource
    {
        string _typeName = "DashProject.Repository.LIBx264EncoderConfigFactory, DashProject.Repository";
        string _dataObjectTypeName = "DashProject.Entity.LIBx264EncoderConfig, DashProject.Entity";

        public LIBx264EncoderConfigDataSourceBase()
        {
            defaultView = new DashProject.Web.DataSourceView.LIBx264EncoderConfigDataSourceView(this, _typeName, Context);
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);
        }

        public LIBx264EncoderConfigDataSourceBase(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            defaultView = new DashProject.Web.DataSourceView.LIBx264EncoderConfigDataSourceView(this, _typeName, Context);
            SelectMethod = selectMethod;
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
        }
    }
}