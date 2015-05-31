using System;

namespace DashProject.Web.DataSource
{
    public class DashInitSegmentDataSource : DashInitSegmentDataSourceBase
    {
        public DashInitSegmentDataSource()
            : base() { }

        public DashInitSegmentDataSource(string typeName, string selectMethod)
            : base(typeName, selectMethod) { }
    }
}