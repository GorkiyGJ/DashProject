using System;

namespace DashProject.Web.DataSource
{
    public class SegmenterConfigDataSource : SegmenterConfigDataSourceBase
    {
        public SegmenterConfigDataSource()
            : base() { }

        public SegmenterConfigDataSource(string typeName, string selectMethod)
            : base(typeName, selectMethod) { }
    }
}