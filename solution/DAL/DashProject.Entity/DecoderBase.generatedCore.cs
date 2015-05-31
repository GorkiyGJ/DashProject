using System;

namespace DashProject.Entity
{
    public class DecoderBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.Decoder, DecoderKey, DecoderOriginalKey>
    {
        public DecoderBase()
            : base()
        {
            _OriginalKey = new DecoderOriginalKey(DataItem);
            _Key = new DecoderKey(DataItem);
        }

        public DecoderBase(DashProject.Data.Item.Decoder item)
            : base(item)
        {
            _OriginalKey = new DecoderOriginalKey(item);
            _Key = new DecoderKey(item);
        }

        private DecoderKey _Key = null;
        public override DecoderKey Key
        {
            get
            {
                return _Key;
            }
        }

        private DecoderOriginalKey _OriginalKey = null;
        public override DecoderOriginalKey OriginalKey
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
        public virtual System.String Description
        {
            get { return DataItem.Description; }
            set
            {
                if (DataItem.Description == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.Description = value;
            }
        } 
        #endregion

        public override object Clone()
        {
            DecoderBase copy = new DecoderBase();
            
            copy.Id = this.Id;
              copy.OriginalKey.Id = this.OriginalKey.Id;
            
            copy.Name = this.Name;
            
            copy.Description = this.Description;
             
            return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public override void AcceptChanges()
        {
            EntityState = Manitou.Entity.Base.EntityState.Unchanged;

            _OriginalKey = new DecoderOriginalKey(DataItem);
        }
    }

    public class DecoderKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.Decoder>
    {
        public DecoderKey()
        {
        }

        public DecoderKey(DashProject.Data.Item.Decoder value)
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

    public class DecoderOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.Decoder>
    {
        public DecoderOriginalKey()
        {
        }

        public DecoderOriginalKey(DashProject.Data.Item.Decoder value)
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
            DecoderOriginalKey obj = new DecoderOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.Decoder value)
        {
            
            _Id = value.Id;        
         
        }
    }
}