using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class CodecToEncoderReadOnly : CodecToEncoderReadOnlyBase
    {
        public CodecToEncoderReadOnly()
            : base()
        {
        }

        public CodecToEncoderReadOnly(DashProject.Data.Item.CodecToEncoder item)
            : base(item)
        {
        }
    }
}