using System;

namespace DashProject.Web.DataSourceView
{
    public class CodecTypeDataSourceView : CodecTypeDataSourceViewBase
    {
        public CodecTypeDataSourceView(DashProject.Web.DataSource.CodecTypeDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
    }
}