using System;

namespace DashProject.Web.DataSourceView
{
    public class BroadcastTypeDataSourceView : BroadcastTypeDataSourceViewBase
    {
        public BroadcastTypeDataSourceView(DashProject.Web.DataSource.BroadcastTypeDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
    }
}