using System;

namespace DashProject.Entity
{
    public class LIBx264EncoderPresetTypeBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.LIBx264EncoderPresetType, LIBx264EncoderPresetTypeKey, LIBx264EncoderPresetTypeOriginalKey>
    {
        public LIBx264EncoderPresetTypeBase()
            : base()
        {
            _OriginalKey = new LIBx264EncoderPresetTypeOriginalKey(DataItem);
            _Key = new LIBx264EncoderPresetTypeKey(DataItem);
        }

        public LIBx264EncoderPresetTypeBase(DashProject.Data.Item.LIBx264EncoderPresetType item)
            : base(item)
        {
            _OriginalKey = new LIBx264EncoderPresetTypeOriginalKey(item);
            _Key = new LIBx264EncoderPresetTypeKey(item);
        }

        private LIBx264EncoderPresetTypeKey _Key = null;
        public override LIBx264EncoderPresetTypeKey Key
        {
            get
            {
                return _Key;
            }
        }

        private LIBx264EncoderPresetTypeOriginalKey _OriginalKey = null;
        public override LIBx264EncoderPresetTypeOriginalKey OriginalKey
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
        public virtual System.String Name
        {
            get { return DataItem.Name; }
            set
            {
                if (DataItem.Name == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.Name = value;
            }
        } 
        #endregion

        public override object Clone()
        {
            LIBx264EncoderPresetTypeBase copy = new LIBx264EncoderPresetTypeBase();
            
            copy.Id = this.Id;
              copy.OriginalKey.Id = this.OriginalKey.Id;
            
            copy.Name = this.Name;
             
            return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public override void AcceptChanges()
        {
            EntityState = Manitou.Entity.Base.EntityState.Unchanged;

            _OriginalKey = new LIBx264EncoderPresetTypeOriginalKey(DataItem);
        }
    }

    public class LIBx264EncoderPresetTypeKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.LIBx264EncoderPresetType>
    {
        public LIBx264EncoderPresetTypeKey()
        {
        }

        public LIBx264EncoderPresetTypeKey(DashProject.Data.Item.LIBx264EncoderPresetType value)
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

    public class LIBx264EncoderPresetTypeOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.LIBx264EncoderPresetType>
    {
        public LIBx264EncoderPresetTypeOriginalKey()
        {
        }

        public LIBx264EncoderPresetTypeOriginalKey(DashProject.Data.Item.LIBx264EncoderPresetType value)
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
            LIBx264EncoderPresetTypeOriginalKey obj = new LIBx264EncoderPresetTypeOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.LIBx264EncoderPresetType value)
        {
            
            _Id = value.Id;        
         
        }
    }
}