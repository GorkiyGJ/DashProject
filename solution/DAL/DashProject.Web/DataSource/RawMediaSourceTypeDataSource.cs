using System;

namespace DashProject.Web.DataSource
{
    public class RawMediaSourceTypeDataSource : RawMediaSourceTypeDataSourceBase
    {
        public RawMediaSourceTypeDataSource()
            : base() { }

        public RawMediaSourceTypeDataSource(string typeName, string selectMethod)
            : base(typeName, selectMethod) { }
    }
}