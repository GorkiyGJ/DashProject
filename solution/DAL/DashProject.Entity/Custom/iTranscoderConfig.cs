using System;

namespace DashProject.Entity.Custom
{
    public class iTranscoderConfig : iTranscoderConfigBase
    {
        public iTranscoderConfig()
            : base()
        { 
        }

        public iTranscoderConfig(DashProject.Data.Item.Custom.iTranscoderConfig item)
            : base(item)
        { 
        }
    }
}