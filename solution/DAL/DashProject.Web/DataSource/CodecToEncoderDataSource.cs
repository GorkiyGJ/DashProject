using System;

namespace DashProject.Web.DataSource
{
    public class CodecToEncoderDataSource : CodecToEncoderDataSourceBase
    {
        public CodecToEncoderDataSource()
            : base() { }

        public CodecToEncoderDataSource(string typeName, string selectMethod)
            : base(typeName, selectMethod) { }
    }
}