using System;

namespace DashProject.Entity
{
    public class CoderTypeBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.CoderType, CoderTypeKey, CoderTypeOriginalKey>
    {
        public CoderTypeBase()
            : base()
        {
            _OriginalKey = new CoderTypeOriginalKey(DataItem);
            _Key = new CoderTypeKey(DataItem);
        }

        public CoderTypeBase(DashProject.Data.Item.CoderType item)
            : base(item)
        {
            _OriginalKey = new CoderTypeOriginalKey(item);
            _Key = new CoderTypeKey(item);
        }

        private CoderTypeKey _Key = null;
        public override CoderTypeKey Key
        {
            get
            {
                return _Key;
            }
        }

        private CoderTypeOriginalKey _OriginalKey = null;
        public override CoderTypeOriginalKey OriginalKey
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
            CoderTypeBase copy = new CoderTypeBase();
            
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

            _OriginalKey = new CoderTypeOriginalKey(DataItem);
        }
    }

    public class CoderTypeKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.CoderType>
    {
        public CoderTypeKey()
        {
        }

        public CoderTypeKey(DashProject.Data.Item.CoderType value)
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

    public class CoderTypeOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.CoderType>
    {
        public CoderTypeOriginalKey()
        {
        }

        public CoderTypeOriginalKey(DashProject.Data.Item.CoderType value)
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
            CoderTypeOriginalKey obj = new CoderTypeOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.CoderType value)
        {
            
            _Id = value.Id;        
         
        }
    }
}