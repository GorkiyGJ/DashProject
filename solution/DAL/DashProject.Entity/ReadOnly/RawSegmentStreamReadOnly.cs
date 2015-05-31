using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class RawSegmentStreamReadOnly : RawSegmentStreamReadOnlyBase
    {
        public RawSegmentStreamReadOnly()
            : base()
        {
        }

        public RawSegmentStreamReadOnly(DashProject.Data.Item.RawSegmentStream item)
            : base(item)
        {
        }
    }
}