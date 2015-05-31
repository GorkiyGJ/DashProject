using System;

namespace DashProject.Entity
{
    public class DecoderTypeBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.DecoderType, DecoderTypeKey, DecoderTypeOriginalKey>
    {
        public DecoderTypeBase()
            : base()
        {
            _OriginalKey = new DecoderTypeOriginalKey(DataItem);
            _Key = new DecoderTypeKey(DataItem);
        }

        public DecoderTypeBase(DashProject.Data.Item.DecoderType item)
            : base(item)
        {
            _OriginalKey = new DecoderTypeOriginalKey(item);
            _Key = new DecoderTypeKey(item);
        }

        private DecoderTypeKey _Key = null;
        public override DecoderTypeKey Key
        {
            get
            {
                return _Key;
            }
        }

        private DecoderTypeOriginalKey _OriginalKey = null;
        public override DecoderTypeOriginalKey OriginalKey
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
            DecoderTypeBase copy = new DecoderTypeBase();
            
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

            _OriginalKey = new DecoderTypeOriginalKey(DataItem);
        }
    }

    public class DecoderTypeKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.DecoderType>
    {
        public DecoderTypeKey()
        {
        }

        public DecoderTypeKey(DashProject.Data.Item.DecoderType value)
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

    public class DecoderTypeOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.DecoderType>
    {
        public DecoderTypeOriginalKey()
        {
        }

        public DecoderTypeOriginalKey(DashProject.Data.Item.DecoderType value)
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
            DecoderTypeOriginalKey obj = new DecoderTypeOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.DecoderType value)
        {
            
            _Id = value.Id;        
         
        }
    }
}