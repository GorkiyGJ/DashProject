using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class LIBx264EncoderConfigReadOnly : LIBx264EncoderConfigReadOnlyBase
    {
        public LIBx264EncoderConfigReadOnly()
            : base()
        {
        }

        public LIBx264EncoderConfigReadOnly(DashProject.Data.Item.LIBx264EncoderConfig item)
            : base(item)
        {
        }
    }
}