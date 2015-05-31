using System;

namespace DashProject.Entity
{
    public class ContainerTypeBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.ContainerType, ContainerTypeKey, ContainerTypeOriginalKey>
    {
        public ContainerTypeBase()
            : base()
        {
            _OriginalKey = new ContainerTypeOriginalKey(DataItem);
            _Key = new ContainerTypeKey(DataItem);
        }

        public ContainerTypeBase(DashProject.Data.Item.ContainerType item)
            : base(item)
        {
            _OriginalKey = new ContainerTypeOriginalKey(item);
            _Key = new ContainerTypeKey(item);
        }

        private ContainerTypeKey _Key = null;
        public override ContainerTypeKey Key
        {
            get
            {
                return _Key;
            }
        }

        private ContainerTypeOriginalKey _OriginalKey = null;
        public override ContainerTypeOriginalKey OriginalKey
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
            ContainerTypeBase copy = new ContainerTypeBase();
            
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

            _OriginalKey = new ContainerTypeOriginalKey(DataItem);
        }
    }

    public class ContainerTypeKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.ContainerType>
    {
        public ContainerTypeKey()
        {
        }

        public ContainerTypeKey(DashProject.Data.Item.ContainerType value)
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

    public class ContainerTypeOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.ContainerType>
    {
        public ContainerTypeOriginalKey()
        {
        }

        public ContainerTypeOriginalKey(DashProject.Data.Item.ContainerType value)
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
            ContainerTypeOriginalKey obj = new ContainerTypeOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.ContainerType value)
        {
            
            _Id = value.Id;        
         
        }
    }
}