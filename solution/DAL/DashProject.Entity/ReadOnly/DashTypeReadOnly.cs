using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class DashTypeReadOnly : DashTypeReadOnlyBase
    {
        public DashTypeReadOnly()
            : base()
        {
        }

        public DashTypeReadOnly(DashProject.Data.Item.DashType item)
            : base(item)
        {
        }
    }
}