using System;

namespace DashProject.Entity
{
    public class DashTypeBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.DashType, DashTypeKey, DashTypeOriginalKey>
    {
        public DashTypeBase()
            : base()
        {
            _OriginalKey = new DashTypeOriginalKey(DataItem);
            _Key = new DashTypeKey(DataItem);
        }

        public DashTypeBase(DashProject.Data.Item.DashType item)
            : base(item)
        {
            _OriginalKey = new DashTypeOriginalKey(item);
            _Key = new DashTypeKey(item);
        }

        private DashTypeKey _Key = null;
        public override DashTypeKey Key
        {
            get
            {
                return _Key;
            }
        }

        private DashTypeOriginalKey _OriginalKey = null;
        public override DashTypeOriginalKey OriginalKey
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
        public virtual System.Int32 ContainerTypeId
        {
            get { return DataItem.ContainerTypeId; }
            set
            {
                if (DataItem.ContainerTypeId == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.ContainerTypeId = value;
            }
        } 
        #endregion

        public override object Clone()
        {
            DashTypeBase copy = new DashTypeBase();
            
            copy.Id = this.Id;
              copy.OriginalKey.Id = this.OriginalKey.Id;
            
            copy.Name = this.Name;
            
            copy.ContainerTypeId = this.ContainerTypeId;
             
            return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public override void AcceptChanges()
        {
            EntityState = Manitou.Entity.Base.EntityState.Unchanged;

            _OriginalKey = new DashTypeOriginalKey(DataItem);
        }
    }

    public class DashTypeKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.DashType>
    {
        public DashTypeKey()
        {
        }

        public DashTypeKey(DashProject.Data.Item.DashType value)
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

    public class DashTypeOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.DashType>
    {
        public DashTypeOriginalKey()
        {
        }

        public DashTypeOriginalKey(DashProject.Data.Item.DashType value)
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
            DashTypeOriginalKey obj = new DashTypeOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.DashType value)
        {
            
            _Id = value.Id;        
         
        }
    }
}