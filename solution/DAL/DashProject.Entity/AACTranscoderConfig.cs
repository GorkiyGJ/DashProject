using System;

namespace DashProject.Entity
{
    public class AACTranscoderConfig : AACTranscoderConfigBase
    {
        public AACTranscoderConfig()
            : base()
        { 
        }

        public AACTranscoderConfig(DashProject.Data.Item.AACTranscoderConfig item)
            : base(item)
        { 
        }
    }
}