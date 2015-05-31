using System;

namespace DashProject.Web.DataSource
{
    public class ScaleVideoFilterDataSource : ScaleVideoFilterDataSourceBase
    {
        public ScaleVideoFilterDataSource()
            : base() { }

        public ScaleVideoFilterDataSource(string typeName, string selectMethod)
            : base(typeName, selectMethod) { }
    }
}