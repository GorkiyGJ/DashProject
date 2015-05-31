using System;

namespace DashProject.Entity
{
    public class Media : MediaBase
    {
        public Media()
            : base()
        { 
        }

        public Media(DashProject.Data.Item.Media item)
            : base(item)
        { 
        }
    }
}