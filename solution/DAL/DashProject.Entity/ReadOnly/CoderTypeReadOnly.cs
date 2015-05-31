using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class CoderTypeReadOnly : CoderTypeReadOnlyBase
    {
        public CoderTypeReadOnly()
            : base()
        {
        }

        public CoderTypeReadOnly(DashProject.Data.Item.CoderType item)
            : base(item)
        {
        }
    }
}