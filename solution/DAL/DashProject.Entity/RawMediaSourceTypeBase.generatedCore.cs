using System;

namespace DashProject.Entity
{
    public class RawMediaSourceTypeBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.RawMediaSourceType, RawMediaSourceTypeKey, RawMediaSourceTypeOriginalKey>
    {
        public RawMediaSourceTypeBase()
            : base()
        {
            _OriginalKey = new RawMediaSourceTypeOriginalKey(DataItem);
            _Key = new RawMediaSourceTypeKey(DataItem);
        }

        public RawMediaSourceTypeBase(DashProject.Data.Item.RawMediaSourceType item)
            : base(item)
        {
            _OriginalKey = new RawMediaSourceTypeOriginalKey(item);
            _Key = new RawMediaSourceTypeKey(item);
        }

        private RawMediaSourceTypeKey _Key = null;
        public override RawMediaSourceTypeKey Key
        {
            get
            {
                return _Key;
            }
        }

        private RawMediaSourceTypeOriginalKey _OriginalKey = null;
        public override RawMediaSourceTypeOriginalKey OriginalKey
        {
            get
            {
                return _OriginalKey;
            }
        }

        #region Properties
                public virtual System.Byte Id
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
            RawMediaSourceTypeBase copy = new RawMediaSourceTypeBase();
            
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

            _OriginalKey = new RawMediaSourceTypeOriginalKey(DataItem);
        }
    }

    public class RawMediaSourceTypeKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.RawMediaSourceType>
    {
        public RawMediaSourceTypeKey()
        {
        }

        public RawMediaSourceTypeKey(DashProject.Data.Item.RawMediaSourceType value)
            : base(value)
        {
        }

            
        public System.Byte Id
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

    public class RawMediaSourceTypeOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.RawMediaSourceType>
    {
        public RawMediaSourceTypeOriginalKey()
        {
        }

        public RawMediaSourceTypeOriginalKey(DashProject.Data.Item.RawMediaSourceType value)
            : base(value)
        {
        }

         
        private System.Byte _Id;   
        public System.Byte Id
        {
            get
            {
                return _Id;
            }
            
            internal set { _Id = value; }
        }
 

        public override object Clone()
        {
            RawMediaSourceTypeOriginalKey obj = new RawMediaSourceTypeOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.RawMediaSourceType value)
        {
            
            _Id = value.Id;        
         
        }
    }
}