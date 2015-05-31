using System;

namespace DashProject.Entity
{
    public class AACTranscoderConfigBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.AACTranscoderConfig, AACTranscoderConfigKey, AACTranscoderConfigOriginalKey>
    {
        public AACTranscoderConfigBase()
            : base()
        {
            _OriginalKey = new AACTranscoderConfigOriginalKey(DataItem);
            _Key = new AACTranscoderConfigKey(DataItem);
        }

        public AACTranscoderConfigBase(DashProject.Data.Item.AACTranscoderConfig item)
            : base(item)
        {
            _OriginalKey = new AACTranscoderConfigOriginalKey(item);
            _Key = new AACTranscoderConfigKey(item);
        }

        private AACTranscoderConfigKey _Key = null;
        public override AACTranscoderConfigKey Key
        {
            get
            {
                return _Key;
            }
        }

        private AACTranscoderConfigOriginalKey _OriginalKey = null;
        public override AACTranscoderConfigOriginalKey OriginalKey
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
        public virtual System.Boolean? IsUseConstrainedBitRate
        {
            get { return DataItem.IsUseConstrainedBitRate; }
            set
            {
                if (DataItem.IsUseConstrainedBitRate == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.IsUseConstrainedBitRate = value;
            }
        } 
        public virtual System.Byte? Channels
        {
            get { return DataItem.Channels; }
            set
            {
                if (DataItem.Channels == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.Channels = value;
            }
        } 
        #endregion

        public override object Clone()
        {
            AACTranscoderConfigBase copy = new AACTranscoderConfigBase();
            
            copy.Id = this.Id;
              copy.OriginalKey.Id = this.OriginalKey.Id;
            
            copy.BitrateKbps = this.BitrateKbps;
            
            copy.IsUseConstrainedBitRate = this.IsUseConstrainedBitRate;
            
            copy.Channels = this.Channels;
             
            return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public override void AcceptChanges()
        {
            EntityState = Manitou.Entity.Base.EntityState.Unchanged;

            _OriginalKey = new AACTranscoderConfigOriginalKey(DataItem);
        }
    }

    public class AACTranscoderConfigKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.AACTranscoderConfig>
    {
        public AACTranscoderConfigKey()
        {
        }

        public AACTranscoderConfigKey(DashProject.Data.Item.AACTranscoderConfig value)
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

    public class AACTranscoderConfigOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.AACTranscoderConfig>
    {
        public AACTranscoderConfigOriginalKey()
        {
        }

        public AACTranscoderConfigOriginalKey(DashProject.Data.Item.AACTranscoderConfig value)
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
            AACTranscoderConfigOriginalKey obj = new AACTranscoderConfigOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.AACTranscoderConfig value)
        {
            
            _Id = value.Id;        
         
        }
    }
}