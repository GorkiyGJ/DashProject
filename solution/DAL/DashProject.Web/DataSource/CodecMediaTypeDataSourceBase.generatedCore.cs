using System;

namespace DashProject.Web.DataSource
{
    public class CodecMediaTypeDataSourceBase : Winnetou.WebControls.DataSources.extObjectDataSource
    {
        string _typeName = "DashProject.Repository.CodecMediaTypeFactory, DashProject.Repository";
        string _dataObjectTypeName = "DashProject.Entity.CodecMediaType, DashProject.Entity";

        public CodecMediaTypeDataSourceBase()
        {
            defaultView = new DashProject.Web.DataSourceView.CodecMediaTypeDataSourceView(this, _typeName, Context);
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);
        }

        public CodecMediaTypeDataSourceBase(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            defaultView = new DashProject.Web.DataSourceView.CodecMediaTypeDataSourceView(this, _typeName, Context);
            SelectMethod = selectMethod;
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
        }
    }
}