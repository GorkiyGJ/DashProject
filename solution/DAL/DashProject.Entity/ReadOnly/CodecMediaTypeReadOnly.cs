using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class CodecMediaTypeReadOnly : CodecMediaTypeReadOnlyBase
    {
        public CodecMediaTypeReadOnly()
            : base()
        {
        }

        public CodecMediaTypeReadOnly(DashProject.Data.Item.CodecMediaType item)
            : base(item)
        {
        }
    }
}