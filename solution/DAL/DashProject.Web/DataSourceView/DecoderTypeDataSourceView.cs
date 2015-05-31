using System;

namespace DashProject.Web.DataSourceView
{
    public class DecoderTypeDataSourceView : DecoderTypeDataSourceViewBase
    {
        public DecoderTypeDataSourceView(DashProject.Web.DataSource.DecoderTypeDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
    }
}