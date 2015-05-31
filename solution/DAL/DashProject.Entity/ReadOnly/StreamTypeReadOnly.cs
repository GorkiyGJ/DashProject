using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class StreamTypeReadOnly : StreamTypeReadOnlyBase
    {
        public StreamTypeReadOnly()
            : base()
        {
        }

        public StreamTypeReadOnly(DashProject.Data.Item.StreamType item)
            : base(item)
        {
        }
    }
}