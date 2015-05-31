using System;

namespace DashProject.Web.DataSource
{
    public class CodecTypeDataSource : CodecTypeDataSourceBase
    {
        public CodecTypeDataSource()
            : base() { }

        public CodecTypeDataSource(string typeName, string selectMethod)
            : base(typeName, selectMethod) { }
    }
}