using System;

namespace DashProject.Web.DataSourceView
{
    public class CodecToEncoderDataSourceView : CodecToEncoderDataSourceViewBase
    {
        public CodecToEncoderDataSourceView(DashProject.Web.DataSource.CodecToEncoderDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
    }
}