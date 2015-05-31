using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class LIBx264EncoderPresetTypeReadOnly : LIBx264EncoderPresetTypeReadOnlyBase
    {
        public LIBx264EncoderPresetTypeReadOnly()
            : base()
        {
        }

        public LIBx264EncoderPresetTypeReadOnly(DashProject.Data.Item.LIBx264EncoderPresetType item)
            : base(item)
        {
        }
    }
}