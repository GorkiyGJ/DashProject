using System;

namespace DashProject.Web.DataSource
{
    public class AspectRatioDataSource : AspectRatioDataSourceBase
    {
        public AspectRatioDataSource()
            : base() { }

        public AspectRatioDataSource(string typeName, string selectMethod)
            : base(typeName, selectMethod) { }
    }
}