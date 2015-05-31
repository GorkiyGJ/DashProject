using System;

namespace DashProject.Entity
{
    public class VideoSize : VideoSizeBase
    {
        public VideoSize()
            : base()
        { 
        }

        public VideoSize(DashProject.Data.Item.VideoSize item)
            : base(item)
        { 
        }
    }
}