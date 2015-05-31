using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class X264ProfileLevelReadOnly : X264ProfileLevelReadOnlyBase
    {
        public X264ProfileLevelReadOnly()
            : base()
        {
        }

        public X264ProfileLevelReadOnly(DashProject.Data.Item.X264ProfileLevel item)
            : base(item)
        {
        }
    }
}