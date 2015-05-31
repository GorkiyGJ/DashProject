using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class DecoderTypeReadOnly : DecoderTypeReadOnlyBase
    {
        public DecoderTypeReadOnly()
            : base()
        {
        }

        public DecoderTypeReadOnly(DashProject.Data.Item.DecoderType item)
            : base(item)
        {
        }
    }
}