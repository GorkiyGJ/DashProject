using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class DecoderReadOnly : DecoderReadOnlyBase
    {
        public DecoderReadOnly()
            : base()
        {
        }

        public DecoderReadOnly(DashProject.Data.Item.Decoder item)
            : base(item)
        {
        }
    }
}