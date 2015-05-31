using System;

namespace DashProject.Web.DataSource
{
    public class AACTranscoderConfigDataSource : AACTranscoderConfigDataSourceBase
    {
        public AACTranscoderConfigDataSource()
            : base() { }

        public AACTranscoderConfigDataSource(string typeName, string selectMethod)
            : base(typeName, selectMethod) { }
    }
}