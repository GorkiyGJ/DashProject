using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class CodecTypeReadOnly : CodecTypeReadOnlyBase
    {
        public CodecTypeReadOnly()
            : base()
        {
        }

        public CodecTypeReadOnly(DashProject.Data.Item.CodecType item)
            : base(item)
        {
        }
    }
}