using System;

namespace DashProject.Data.Item
{
    public abstract class LIBx264EncoderConfigBase : Manitou.Data.Item.Base.BaseItem
    {
        public LIBx264EncoderConfigBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int32 Id { get; set; } 
                
         public virtual System.Int32 DashMediaId { get; set; } 
                
         public virtual System.Int32 LIBx264EncoderPresetTypeId { get; set; } 
                
         public virtual System.Int32 X264ProfileId { get; set; } 
                
         public virtual System.Int32 X264ProfileLevelId { get; set; } 
                
         public virtual System.Byte ThreadsCount { get; set; } 
                
         public virtual System.Int32? BitrateKbps { get; set; } 
                
         public virtual System.Boolean IsUseConstantBitRate { get; set; } 
                
         public virtual System.Byte ConstantRateFactor { get; set; } 
                
         public virtual System.Boolean isUseConstantRateFactorForQualityManagement { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        LIBx264EncoderConfig copy = new LIBx264EncoderConfig();
          copy.Id = this.Id;
          copy.DashMediaId = this.DashMediaId;
          copy.LIBx264EncoderPresetTypeId = this.LIBx264EncoderPresetTypeId;
          copy.X264ProfileId = this.X264ProfileId;
          copy.X264ProfileLevelId = this.X264ProfileLevelId;
          copy.ThreadsCount = this.ThreadsCount;
          copy.BitrateKbps = this.BitrateKbps;
          copy.IsUseConstantBitRate = this.IsUseConstantBitRate;
          copy.ConstantRateFactor = this.ConstantRateFactor;
          copy.isUseConstantRateFactorForQualityManagement = this.isUseConstantRateFactorForQualityManagement;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum LIBx264EncoderConfigColumn : byte
        {
              Id = 1 ,     
              DashMediaId = 2 ,     
              LIBx264EncoderPresetTypeId = 3 ,     
              X264ProfileId = 4 ,     
              X264ProfileLevelId = 5 ,     
              ThreadsCount = 6 ,     
              BitrateKbps = 7 ,     
              IsUseConstantBitRate = 8 ,     
              ConstantRateFactor = 9 ,     
              isUseConstantRateFactorForQualityManagement = 10      
                    
        }        
    }                   
}