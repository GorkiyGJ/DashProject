using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class DashMediaReadOnly : DashMediaReadOnlyBase
    {
        public DashMediaReadOnly()
            : base()
        {
        }

        public DashMediaReadOnly(DashProject.Data.Item.DashMedia item)
            : base(item)
        {
        }
    }
}