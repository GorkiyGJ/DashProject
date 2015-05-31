using System;

namespace DashProject.Web.DataSource
{
    public class CodecTypeDataSourceBase : Winnetou.WebControls.DataSources.extObjectDataSource
    {
        string _typeName = "DashProject.Repository.CodecTypeFactory, DashProject.Repository";
        string _dataObjectTypeName = "DashProject.Entity.CodecType, DashProject.Entity";

        public CodecTypeDataSourceBase()
        {
            defaultView = new DashProject.Web.DataSourceView.CodecTypeDataSourceView(this, _typeName, Context);
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);
        }

        public CodecTypeDataSourceBase(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            defaultView = new DashProject.Web.DataSourceView.CodecTypeDataSourceView(this, _typeName, Context);
            SelectMethod = selectMethod;
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
        }
    }
}