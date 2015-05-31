using System;

namespace DashProject.Web.DataSource
{
    public class DecoderTypeDataSource : DecoderTypeDataSourceBase
    {
        public DecoderTypeDataSource()
            : base() { }

        public DecoderTypeDataSource(string typeName, string selectMethod)
            : base(typeName, selectMethod) { }
    }
}