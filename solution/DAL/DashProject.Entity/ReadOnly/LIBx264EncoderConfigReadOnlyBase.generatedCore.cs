using System;

namespace DashProject.Entity.ReadOnly
{
    public class LIBx264EncoderConfigReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.LIBx264EncoderConfig>
    {
        public LIBx264EncoderConfigReadOnlyBase()
            : base()
        {
        }

        public LIBx264EncoderConfigReadOnlyBase(DashProject.Data.Item.LIBx264EncoderConfig item)
            : base(item)
        {
        }

        #region Properties
                public virtual System.Int32 Id
        {
            get { return DataItem.Id; }
        }
        public virtual System.Int32 DashMediaId
        {
            get { return DataItem.DashMediaId; }
        }
        public virtual System.Int32 LIBx264EncoderPresetTypeId
        {
            get { return DataItem.LIBx264EncoderPresetTypeId; }
        }
        public virtual System.Int32 X264ProfileId
        {
            get { return DataItem.X264ProfileId; }
        }
        public virtual System.Int32 X264ProfileLevelId
        {
            get { return DataItem.X264ProfileLevelId; }
        }
        public virtual System.Byte ThreadsCount
        {
            get { return DataItem.ThreadsCount; }
        }
        public virtual System.Int32? BitrateKbps
        {
            get { return DataItem.BitrateKbps; }
        }
        public virtual System.Boolean IsUseConstantBitRate
        {
            get { return DataItem.IsUseConstantBitRate; }
        }
        public virtual System.Byte ConstantRateFactor
        {
            get { return DataItem.ConstantRateFactor; }
        }
        public virtual System.Boolean isUseConstantRateFactorForQualityManagement
        {
            get { return DataItem.isUseConstantRateFactorForQualityManagement; }
        }
        
        #endregion
    }
}