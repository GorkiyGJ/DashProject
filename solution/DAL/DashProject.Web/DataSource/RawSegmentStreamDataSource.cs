using System;

namespace DashProject.Web.DataSource
{
    public class RawSegmentStreamDataSource : RawSegmentStreamDataSourceBase
    {
        public RawSegmentStreamDataSource()
            : base() { }

        public RawSegmentStreamDataSource(string typeName, string selectMethod)
            : base(typeName, selectMethod) { }
    }
}