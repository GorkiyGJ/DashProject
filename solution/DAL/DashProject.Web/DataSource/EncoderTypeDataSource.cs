using System;

namespace DashProject.Web.DataSource
{
    public class EncoderTypeDataSource : EncoderTypeDataSourceBase
    {
        public EncoderTypeDataSource()
            : base() { }

        public EncoderTypeDataSource(string typeName, string selectMethod)
            : base(typeName, selectMethod) { }
    }
}