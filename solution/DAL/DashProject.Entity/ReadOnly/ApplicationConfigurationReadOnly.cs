using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class ApplicationConfigurationReadOnly : ApplicationConfigurationReadOnlyBase
    {
        public ApplicationConfigurationReadOnly()
            : base()
        {
        }

        public ApplicationConfigurationReadOnly(DashProject.Data.Item.ApplicationConfiguration item)
            : base(item)
        {
        }
    }
}