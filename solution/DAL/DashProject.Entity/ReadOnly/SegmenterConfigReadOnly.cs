using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class SegmenterConfigReadOnly : SegmenterConfigReadOnlyBase
    {
        public SegmenterConfigReadOnly()
            : base()
        {
        }

        public SegmenterConfigReadOnly(DashProject.Data.Item.SegmenterConfig item)
            : base(item)
        {
        }
    }
}