using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class X264ProfileReadOnly : X264ProfileReadOnlyBase
    {
        public X264ProfileReadOnly()
            : base()
        {
        }

        public X264ProfileReadOnly(DashProject.Data.Item.X264Profile item)
            : base(item)
        {
        }
    }
}