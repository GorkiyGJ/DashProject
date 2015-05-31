using System;

namespace DashProject.Entity.Custom
{
    public class iLIBx264EncoderConfigBase : Manitou.Entity.Base.BaseEntityReadOnly<DashProject.Data.Item.Custom.iLIBx264EncoderConfig>
    {
        public iLIBx264EncoderConfigBase()
            : base()
        {
        }

        public iLIBx264EncoderConfigBase(DashProject.Data.Item.Custom.iLIBx264EncoderConfig item)
            : base(item)
        {
        }

        #region Properties
                public virtual System.Int32? DashMediaId
        {
            get { return DataItem.DashMediaId; }
            set
            {
                DataItem.DashMediaId = value;
            }
        } 
        public virtual System.Byte? ThreadsCount
        {
            get { return DataItem.ThreadsCount; }
            set
            {
                DataItem.ThreadsCount = value;
            }
        } 
        public virtual System.Int32? BitrateKbps
        {
            get { return DataItem.BitrateKbps; }
            set
            {
                DataItem.BitrateKbps = value;
            }
        } 
        public virtual System.Int32? LIBx264EncoderPresetTypeId
        {
            get { return DataItem.LIBx264EncoderPresetTypeId; }
            set
            {
                DataItem.LIBx264EncoderPresetTypeId = value;
            }
        } 
        public virtual System.Int32? X264ProfileId
        {
            get { return DataItem.X264ProfileId; }
            set
            {
                DataItem.X264ProfileId = value;
            }
        } 
        public virtual System.Int32? X264ProfileLevelId
        {
            get { return DataItem.X264ProfileLevelId; }
            set
            {
                DataItem.X264ProfileLevelId = value;
            }
        } 
        public virtual System.Boolean? IsUseConstantBitRate
        {
            get { return DataItem.IsUseConstantBitRate; }
            set
            {
                DataItem.IsUseConstantBitRate = value;
            }
        } 
        public virtual System.Boolean? IsUseConstantRateFactorForQualityManagement
        {
            get { return DataItem.IsUseConstantRateFactorForQualityManagement; }
            set
            {
                DataItem.IsUseConstantRateFactorForQualityManagement = value;
            }
        } 
        public virtual System.Byte? ConstantRateFactor
        {
            get { return DataItem.ConstantRateFactor; }
            set
            {
                DataItem.ConstantRateFactor = value;
            }
        } 
        #endregion

        public virtual object Clone()
        {
            iLIBx264EncoderConfigBase copy = new iLIBx264EncoderConfigBase();
            
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
    }
}