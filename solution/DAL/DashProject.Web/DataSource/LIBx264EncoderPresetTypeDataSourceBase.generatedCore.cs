using System;

namespace DashProject.Web.DataSource
{
    public class LIBx264EncoderPresetTypeDataSourceBase : Winnetou.WebControls.DataSources.extObjectDataSource
    {
        string _typeName = "DashProject.Repository.LIBx264EncoderPresetTypeFactory, DashProject.Repository";
        string _dataObjectTypeName = "DashProject.Entity.LIBx264EncoderPresetType, DashProject.Entity";

        public LIBx264EncoderPresetTypeDataSourceBase()
        {
            defaultView = new DashProject.Web.DataSourceView.LIBx264EncoderPresetTypeDataSourceView(this, _typeName, Context);
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);
        }

        public LIBx264EncoderPresetTypeDataSourceBase(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            defaultView = new DashProject.Web.DataSourceView.LIBx264EncoderPresetTypeDataSourceView(this, _typeName, Context);
            SelectMethod = selectMethod;
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
        }
    }
}