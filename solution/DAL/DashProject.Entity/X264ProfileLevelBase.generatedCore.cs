using System;

namespace DashProject.Entity
{
    public class X264ProfileLevelBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.X264ProfileLevel, X264ProfileLevelKey, X264ProfileLevelOriginalKey>
    {
        public X264ProfileLevelBase()
            : base()
        {
            _OriginalKey = new X264ProfileLevelOriginalKey(DataItem);
            _Key = new X264ProfileLevelKey(DataItem);
        }

        public X264ProfileLevelBase(DashProject.Data.Item.X264ProfileLevel item)
            : base(item)
        {
            _OriginalKey = new X264ProfileLevelOriginalKey(item);
            _Key = new X264ProfileLevelKey(item);
        }

        private X264ProfileLevelKey _Key = null;
        public override X264ProfileLevelKey Key
        {
            get
            {
                return _Key;
            }
        }

        private X264ProfileLevelOriginalKey _OriginalKey = null;
        public override X264ProfileLevelOriginalKey OriginalKey
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
            X264ProfileLevelBase copy = new X264ProfileLevelBase();
            
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

            _OriginalKey = new X264ProfileLevelOriginalKey(DataItem);
        }
    }

    public class X264ProfileLevelKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.X264ProfileLevel>
    {
        public X264ProfileLevelKey()
        {
        }

        public X264ProfileLevelKey(DashProject.Data.Item.X264ProfileLevel value)
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

    public class X264ProfileLevelOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.X264ProfileLevel>
    {
        public X264ProfileLevelOriginalKey()
        {
        }

        public X264ProfileLevelOriginalKey(DashProject.Data.Item.X264ProfileLevel value)
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
            X264ProfileLevelOriginalKey obj = new X264ProfileLevelOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.X264ProfileLevel value)
        {
            
            _Id = value.Id;        
         
        }
    }
}