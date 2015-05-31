using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class LanguageReadOnly : LanguageReadOnlyBase
    {
        public LanguageReadOnly()
            : base()
        {
        }

        public LanguageReadOnly(DashProject.Data.Item.Language item)
            : base(item)
        {
        }
    }
}