using System;

namespace DashProject.Data.Item
{
    public abstract class AACTranscoderConfigBase : Manitou.Data.Item.Base.BaseItem
    {
        public AACTranscoderConfigBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int32 Id { get; set; } 
                
         public virtual System.Int32? BitrateKbps { get; set; } 
                
         public virtual System.Boolean? IsUseConstrainedBitRate { get; set; } 
                
         public virtual System.Byte? Channels { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        AACTranscoderConfig copy = new AACTranscoderConfig();
          copy.Id = this.Id;
          copy.BitrateKbps = this.BitrateKbps;
          copy.IsUseConstrainedBitRate = this.IsUseConstrainedBitRate;
          copy.Channels = this.Channels;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum AACTranscoderConfigColumn : byte
        {
              Id = 1 ,     
              BitrateKbps = 2 ,     
              IsUseConstrainedBitRate = 3 ,     
              Channels = 4      
                    
        }        
    }                   
}