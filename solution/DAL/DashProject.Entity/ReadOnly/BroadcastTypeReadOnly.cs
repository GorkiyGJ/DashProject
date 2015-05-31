using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class BroadcastTypeReadOnly : BroadcastTypeReadOnlyBase
    {
        public BroadcastTypeReadOnly()
            : base()
        {
        }

        public BroadcastTypeReadOnly(DashProject.Data.Item.BroadcastType item)
            : base(item)
        {
        }
    }
}