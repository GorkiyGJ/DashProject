using System;

namespace DashProject.Entity
{
    public class EncoderBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.Encoder, EncoderKey, EncoderOriginalKey>
    {
        public EncoderBase()
            : base()
        {
            _OriginalKey = new EncoderOriginalKey(DataItem);
            _Key = new EncoderKey(DataItem);
        }

        public EncoderBase(DashProject.Data.Item.Encoder item)
            : base(item)
        {
            _OriginalKey = new EncoderOriginalKey(item);
            _Key = new EncoderKey(item);
        }

        private EncoderKey _Key = null;
        public override EncoderKey Key
        {
            get
            {
                return _Key;
            }
        }

        private EncoderOriginalKey _OriginalKey = null;
        public override EncoderOriginalKey OriginalKey
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
        public virtual System.Int32 EncoderTypeId
        {
            get { return DataItem.EncoderTypeId; }
            set
            {
                if (DataItem.EncoderTypeId == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.EncoderTypeId = value;
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
            EncoderBase copy = new EncoderBase();
            
            copy.Id = this.Id;
              copy.OriginalKey.Id = this.OriginalKey.Id;
            
            copy.EncoderTypeId = this.EncoderTypeId;
            
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

            _OriginalKey = new EncoderOriginalKey(DataItem);
        }
    }

    public class EncoderKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.Encoder>
    {
        public EncoderKey()
        {
        }

        public EncoderKey(DashProject.Data.Item.Encoder value)
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

    public class EncoderOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.Encoder>
    {
        public EncoderOriginalKey()
        {
        }

        public EncoderOriginalKey(DashProject.Data.Item.Encoder value)
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
            EncoderOriginalKey obj = new EncoderOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.Encoder value)
        {
            
            _Id = value.Id;        
         
        }
    }
}