using System;

namespace DashProject.Entity
{
    public class StreamType : StreamTypeBase
    {
        public StreamType()
            : base()
        { 
        }

        public StreamType(DashProject.Data.Item.StreamType item)
            : base(item)
        { 
        }
    }
}