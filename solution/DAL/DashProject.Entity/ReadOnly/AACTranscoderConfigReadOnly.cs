using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class AACTranscoderConfigReadOnly : AACTranscoderConfigReadOnlyBase
    {
        public AACTranscoderConfigReadOnly()
            : base()
        {
        }

        public AACTranscoderConfigReadOnly(DashProject.Data.Item.AACTranscoderConfig item)
            : base(item)
        {
        }
    }
}