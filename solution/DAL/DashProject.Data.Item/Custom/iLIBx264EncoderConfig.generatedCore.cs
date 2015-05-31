using System;

namespace DashProject.Data.Item.Custom
{
    public abstract class iLIBx264EncoderConfigBase : Manitou.Data.Item.Base.BaseItem
    {
        public iLIBx264EncoderConfigBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int32? DashMediaId { get; set; } 
                
         public virtual System.Byte? ThreadsCount { get; set; } 
                
         public virtual System.Int32? BitrateKbps { get; set; } 
                
         public virtual System.Int32? LIBx264EncoderPresetTypeId { get; set; } 
                
         public virtual System.Int32? X264ProfileId { get; set; } 
                
         public virtual System.Int32? X264ProfileLevelId { get; set; } 
                
         public virtual System.Boolean? IsUseConstantBitRate { get; set; } 
                
         public virtual System.Boolean? IsUseConstantRateFactorForQualityManagement { get; set; } 
                
         public virtual System.Byte? ConstantRateFactor { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        iLIBx264EncoderConfig copy = new iLIBx264EncoderConfig();
          copy.DashMediaId = this.DashMediaId;
          copy.ThreadsCount = this.ThreadsCount;
          copy.BitrateKbps = this.BitrateKbps;
          copy.LIBx264EncoderPresetTypeId = this.LIBx264EncoderPresetTypeId;
          copy.X264ProfileId = this.X264ProfileId;
          copy.X264ProfileLevelId = this.X264ProfileLevelId;
          copy.IsUseConstantBitRate = this.IsUseConstantBitRate;
          copy.IsUseConstantRateFactorForQualityManagement = this.IsUseConstantRateFactorForQualityManagement;
          copy.ConstantRateFactor = this.ConstantRateFactor;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum iLIBx264EncoderConfigColumn : byte
        {
              DashMediaId = 0 ,     
              ThreadsCount = 1 ,     
              BitrateKbps = 2 ,     
              LIBx264EncoderPresetTypeId = 3 ,     
              X264ProfileId = 4 ,     
              X264ProfileLevelId = 5 ,     
              IsUseConstantBitRate = 6 ,     
              IsUseConstantRateFactorForQualityManagement = 7 ,     
              ConstantRateFactor = 8      
                    
        }        
    }                   
}