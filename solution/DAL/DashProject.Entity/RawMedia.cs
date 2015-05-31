using System;

namespace DashProject.Entity
{
    public class RawMedia : RawMediaBase
    {
        public RawMedia()
            : base()
        { 
        }

        public RawMedia(DashProject.Data.Item.RawMedia item)
            : base(item)
        { 
        }
    }
}