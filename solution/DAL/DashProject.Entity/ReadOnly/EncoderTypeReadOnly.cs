using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class EncoderTypeReadOnly : EncoderTypeReadOnlyBase
    {
        public EncoderTypeReadOnly()
            : base()
        {
        }

        public EncoderTypeReadOnly(DashProject.Data.Item.EncoderType item)
            : base(item)
        {
        }
    }
}