using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class AspectRatioReadOnly : AspectRatioReadOnlyBase
    {
        public AspectRatioReadOnly()
            : base()
        {
        }

        public AspectRatioReadOnly(DashProject.Data.Item.AspectRatio item)
            : base(item)
        {
        }
    }
}