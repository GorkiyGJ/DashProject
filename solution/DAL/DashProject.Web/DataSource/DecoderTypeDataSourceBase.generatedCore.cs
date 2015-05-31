using System;

namespace DashProject.Web.DataSource
{
    public class DecoderTypeDataSourceBase : Winnetou.WebControls.DataSources.extObjectDataSource
    {
        string _typeName = "DashProject.Repository.DecoderTypeFactory, DashProject.Repository";
        string _dataObjectTypeName = "DashProject.Entity.DecoderType, DashProject.Entity";

        public DecoderTypeDataSourceBase()
        {
            defaultView = new DashProject.Web.DataSourceView.DecoderTypeDataSourceView(this, _typeName, Context);
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);
        }

        public DecoderTypeDataSourceBase(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            defaultView = new DashProject.Web.DataSourceView.DecoderTypeDataSourceView(this, _typeName, Context);
            SelectMethod = selectMethod;
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
        }
    }
}