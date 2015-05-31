using System;

namespace DashProject.Entity
{
    public class Stream : StreamBase
    {
        public Stream()
            : base()
        { 
        }

        public Stream(DashProject.Data.Item.Stream item)
            : base(item)
        { 
        }
    }
}