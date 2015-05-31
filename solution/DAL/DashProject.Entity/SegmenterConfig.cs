using System;

namespace DashProject.Entity
{
    public class SegmenterConfig : SegmenterConfigBase
    {
        public SegmenterConfig()
            : base()
        { 
        }

        public SegmenterConfig(DashProject.Data.Item.SegmenterConfig item)
            : base(item)
        { 
        }
    }
}