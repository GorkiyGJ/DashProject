using System;

namespace DashProject.Web.DataSource
{
    public class EncoderTypeDataSourceBase : Winnetou.WebControls.DataSources.extObjectDataSource
    {
        string _typeName = "DashProject.Repository.EncoderTypeFactory, DashProject.Repository";
        string _dataObjectTypeName = "DashProject.Entity.EncoderType, DashProject.Entity";

        public EncoderTypeDataSourceBase()
        {
            defaultView = new DashProject.Web.DataSourceView.EncoderTypeDataSourceView(this, _typeName, Context);
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);
        }

        public EncoderTypeDataSourceBase(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            defaultView = new DashProject.Web.DataSourceView.EncoderTypeDataSourceView(this, _typeName, Context);
            SelectMethod = selectMethod;
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
        }
    }
}