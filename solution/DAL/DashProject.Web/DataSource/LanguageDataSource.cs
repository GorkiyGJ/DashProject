using System;

namespace DashProject.Web.DataSource
{
    public class LanguageDataSource : LanguageDataSourceBase
    {
        public LanguageDataSource()
            : base() { }

        public LanguageDataSource(string typeName, string selectMethod)
            : base(typeName, selectMethod) { }
    }
}