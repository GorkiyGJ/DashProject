using System;

namespace DashProject.Entity
{
    public class BroadcastTypeBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.BroadcastType, BroadcastTypeKey, BroadcastTypeOriginalKey>
    {
        public BroadcastTypeBase()
            : base()
        {
            _OriginalKey = new BroadcastTypeOriginalKey(DataItem);
            _Key = new BroadcastTypeKey(DataItem);
        }

        public BroadcastTypeBase(DashProject.Data.Item.BroadcastType item)
            : base(item)
        {
            _OriginalKey = new BroadcastTypeOriginalKey(item);
            _Key = new BroadcastTypeKey(item);
        }

        private BroadcastTypeKey _Key = null;
        public override BroadcastTypeKey Key
        {
            get
            {
                return _Key;
            }
        }

        private BroadcastTypeOriginalKey _OriginalKey = null;
        public override BroadcastTypeOriginalKey OriginalKey
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
            BroadcastTypeBase copy = new BroadcastTypeBase();
            
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

            _OriginalKey = new BroadcastTypeOriginalKey(DataItem);
        }
    }

    public class BroadcastTypeKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.BroadcastType>
    {
        public BroadcastTypeKey()
        {
        }

        public BroadcastTypeKey(DashProject.Data.Item.BroadcastType value)
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

    public class BroadcastTypeOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.BroadcastType>
    {
        public BroadcastTypeOriginalKey()
        {
        }

        public BroadcastTypeOriginalKey(DashProject.Data.Item.BroadcastType value)
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
            BroadcastTypeOriginalKey obj = new BroadcastTypeOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.BroadcastType value)
        {
            
            _Id = value.Id;        
         
        }
    }
}