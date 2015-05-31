using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class StreamReadOnly : StreamReadOnlyBase
    {
        public StreamReadOnly()
            : base()
        {
        }

        public StreamReadOnly(DashProject.Data.Item.Stream item)
            : base(item)
        {
        }
    }
}