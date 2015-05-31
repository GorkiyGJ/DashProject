using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class DashInitSegmentReadOnly : DashInitSegmentReadOnlyBase
    {
        public DashInitSegmentReadOnly()
            : base()
        {
        }

        public DashInitSegmentReadOnly(DashProject.Data.Item.DashInitSegment item)
            : base(item)
        {
        }
    }
}