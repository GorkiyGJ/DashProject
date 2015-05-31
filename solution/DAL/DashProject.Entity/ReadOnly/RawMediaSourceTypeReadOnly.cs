using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class RawMediaSourceTypeReadOnly : RawMediaSourceTypeReadOnlyBase
    {
        public RawMediaSourceTypeReadOnly()
            : base()
        {
        }

        public RawMediaSourceTypeReadOnly(DashProject.Data.Item.RawMediaSourceType item)
            : base(item)
        {
        }
    }
}