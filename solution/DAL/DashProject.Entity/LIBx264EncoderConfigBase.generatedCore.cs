using System;

namespace DashProject.Entity
{
    public class LIBx264EncoderConfigBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.LIBx264EncoderConfig, LIBx264EncoderConfigKey, LIBx264EncoderConfigOriginalKey>
    {
        public LIBx264EncoderConfigBase()
            : base()
        {
            _OriginalKey = new LIBx264EncoderConfigOriginalKey(DataItem);
            _Key = new LIBx264EncoderConfigKey(DataItem);
        }

        public LIBx264EncoderConfigBase(DashProject.Data.Item.LIBx264EncoderConfig item)
            : base(item)
        {
            _OriginalKey = new LIBx264EncoderConfigOriginalKey(item);
            _Key = new LIBx264EncoderConfigKey(item);
        }

        private LIBx264EncoderConfigKey _Key = null;
        public override LIBx264EncoderConfigKey Key
        {
            get
            {
                return _Key;
            }
        }

        private LIBx264EncoderConfigOriginalKey _OriginalKey = null;
        public override LIBx264EncoderConfigOriginalKey OriginalKey
        {
            get
            {
                return _OriginalKey;
            }
        }

        #region Properties
                public virtual System.Int32 Id
        {
            get { return DataItem.Id; }
            set
            {
                if (DataItem.Id == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.Id = value;
            }
        } 
        public virtual System.Int32 DashMediaId
        {
            get { return DataItem.DashMediaId; }
            set
            {
                if (DataItem.DashMediaId == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.DashMediaId = value;
            }
        } 
        public virtual System.Int32 LIBx264EncoderPresetTypeId
        {
            get { return DataItem.LIBx264EncoderPresetTypeId; }
            set
            {
                if (DataItem.LIBx264EncoderPresetTypeId == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.LIBx264EncoderPresetTypeId = value;
            }
        } 
        public virtual System.Int32 X264ProfileId
        {
            get { return DataItem.X264ProfileId; }
            set
            {
                if (DataItem.X264ProfileId == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.X264ProfileId = value;
            }
        } 
        public virtual System.Int32 X264ProfileLevelId
        {
            get { return DataItem.X264ProfileLevelId; }
            set
            {
                if (DataItem.X264ProfileLevelId == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.X264ProfileLevelId = value;
            }
        } 
        public virtual System.Byte ThreadsCount
        {
            get { return DataItem.ThreadsCount; }
            set
            {
                if (DataItem.ThreadsCount == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.ThreadsCount = value;
            }
        } 
        public virtual System.Int32? BitrateKbps
        {
            get { return DataItem.BitrateKbps; }
            set
            {
                if (DataItem.BitrateKbps == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.BitrateKbps = value;
            }
        } 
        public virtual System.Boolean IsUseConstantBitRate
        {
            get { return DataItem.IsUseConstantBitRate; }
            set
            {
                if (DataItem.IsUseConstantBitRate == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.IsUseConstantBitRate = value;
            }
        } 
        public virtual System.Byte ConstantRateFactor
        {
            get { return DataItem.ConstantRateFactor; }
            set
            {
                if (DataItem.ConstantRateFactor == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.ConstantRateFactor = value;
            }
        } 
        public virtual System.Boolean isUseConstantRateFactorForQualityManagement
        {
            get { return DataItem.isUseConstantRateFactorForQualityManagement; }
            set
            {
                if (DataItem.isUseConstantRateFactorForQualityManagement == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.isUseConstantRateFactorForQualityManagement = value;
            }
        } 
        #endregion

        public override object Clone()
        {
            LIBx264EncoderConfigBase copy = new LIBx264EncoderConfigBase();
            
            copy.Id = this.Id;
              copy.OriginalKey.Id = this.OriginalKey.Id;
            
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

        public override void AcceptChanges()
        {
            EntityState = Manitou.Entity.Base.EntityState.Unchanged;

            _OriginalKey = new LIBx264EncoderConfigOriginalKey(DataItem);
        }
    }

    public class LIBx264EncoderConfigKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.LIBx264EncoderConfig>
    {
        public LIBx264EncoderConfigKey()
        {
        }

        public LIBx264EncoderConfigKey(DashProject.Data.Item.LIBx264EncoderConfig value)
            : base(value)
        {
        }

            
        public System.Int32 Id
        {
            get
            {
                return _item.Id;
            }
        }
        

        public override object Clone()
        {
                            
            object[] obj = new object[1];
            
            obj[0] = Id;        
                         
            return obj;
        }
    }

    public class LIBx264EncoderConfigOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.LIBx264EncoderConfig>
    {
        public LIBx264EncoderConfigOriginalKey()
        {
        }

        public LIBx264EncoderConfigOriginalKey(DashProject.Data.Item.LIBx264EncoderConfig value)
            : base(value)
        {
        }

         
        private System.Int32 _Id;   
        public System.Int32 Id
        {
            get
            {
                return _Id;
            }
            
            internal set { _Id = value; }
        }
 

        public override object Clone()
        {
            LIBx264EncoderConfigOriginalKey obj = new LIBx264EncoderConfigOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.LIBx264EncoderConfig value)
        {
            
            _Id = value.Id;        
         
        }
    }
}