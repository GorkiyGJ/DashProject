using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class RawMediaReadOnly : RawMediaReadOnlyBase
    {
        public RawMediaReadOnly()
            : base()
        {
        }

        public RawMediaReadOnly(DashProject.Data.Item.RawMedia item)
            : base(item)
        {
        }
    }
}