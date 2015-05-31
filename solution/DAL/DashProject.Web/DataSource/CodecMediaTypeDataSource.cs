using System;

namespace DashProject.Web.DataSource
{
    public class CodecMediaTypeDataSource : CodecMediaTypeDataSourceBase
    {
        public CodecMediaTypeDataSource()
            : base() { }

        public CodecMediaTypeDataSource(string typeName, string selectMethod)
            : base(typeName, selectMethod) { }
    }
}