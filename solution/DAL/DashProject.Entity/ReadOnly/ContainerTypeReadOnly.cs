using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class ContainerTypeReadOnly : ContainerTypeReadOnlyBase
    {
        public ContainerTypeReadOnly()
            : base()
        {
        }

        public ContainerTypeReadOnly(DashProject.Data.Item.ContainerType item)
            : base(item)
        {
        }
    }
}