using System;

namespace DashProject.Web.DataSource
{
    public class DashMediaSegmentDataSource : DashMediaSegmentDataSourceBase
    {
        public DashMediaSegmentDataSource()
            : base() { }

        public DashMediaSegmentDataSource(string typeName, string selectMethod)
            : base(typeName, selectMethod) { }
    }
}