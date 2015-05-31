using System;

namespace DashProject.Web.DataSource
{
    public class CodecToEncoderDataSourceBase : Winnetou.WebControls.DataSources.extObjectDataSource
    {
        string _typeName = "DashProject.Repository.CodecToEncoderFactory, DashProject.Repository";
        string _dataObjectTypeName = "DashProject.Entity.CodecToEncoder, DashProject.Entity";

        public CodecToEncoderDataSourceBase()
        {
            defaultView = new DashProject.Web.DataSourceView.CodecToEncoderDataSourceView(this, _typeName, Context);
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);
        }

        public CodecToEncoderDataSourceBase(string typeName, string selectMethod)
            : base(typeName, selectMethod)
        {
            defaultView = new DashProject.Web.DataSourceView.CodecToEncoderDataSourceView(this, _typeName, Context);
            SelectMethod = selectMethod;
            TypeName = _typeName;
            DataObjectTypeName = _dataObjectTypeName;
        }
    }
}