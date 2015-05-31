using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class MediaReadOnly : MediaReadOnlyBase
    {
        public MediaReadOnly()
            : base()
        {
        }

        public MediaReadOnly(DashProject.Data.Item.Media item)
            : base(item)
        {
        }
    }
}