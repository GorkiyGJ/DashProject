using System;

namespace DashProject.Web.DataSource
{
    public class RawMediaDataSource : RawMediaDataSourceBase
    {
        public RawMediaDataSource()
            : base() { }

        public RawMediaDataSource(string typeName, string selectMethod)
            : base(typeName, selectMethod) { }
    }
}