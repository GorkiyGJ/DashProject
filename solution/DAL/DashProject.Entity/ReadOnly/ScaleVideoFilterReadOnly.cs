using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class ScaleVideoFilterReadOnly : ScaleVideoFilterReadOnlyBase
    {
        public ScaleVideoFilterReadOnly()
            : base()
        {
        }

        public ScaleVideoFilterReadOnly(DashProject.Data.Item.ScaleVideoFilter item)
            : base(item)
        {
        }
    }
}