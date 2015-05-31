using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class DashMediaSegmentReadOnly : DashMediaSegmentReadOnlyBase
    {
        public DashMediaSegmentReadOnly()
            : base()
        {
        }

        public DashMediaSegmentReadOnly(DashProject.Data.Item.DashMediaSegment item)
            : base(item)
        {
        }
    }
}