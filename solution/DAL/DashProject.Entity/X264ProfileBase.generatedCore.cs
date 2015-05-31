using System;

namespace DashProject.Entity
{
    public class X264ProfileBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.X264Profile, X264ProfileKey, X264ProfileOriginalKey>
    {
        public X264ProfileBase()
            : base()
        {
            _OriginalKey = new X264ProfileOriginalKey(DataItem);
            _Key = new X264ProfileKey(DataItem);
        }

        public X264ProfileBase(DashProject.Data.Item.X264Profile item)
            : base(item)
        {
            _OriginalKey = new X264ProfileOriginalKey(item);
            _Key = new X264ProfileKey(item);
        }

        private X264ProfileKey _Key = null;
        public override X264ProfileKey Key
        {
            get
            {
                return _Key;
            }
        }

        private X264ProfileOriginalKey _OriginalKey = null;
        public override X264ProfileOriginalKey OriginalKey
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
            X264ProfileBase copy = new X264ProfileBase();
            
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

            _OriginalKey = new X264ProfileOriginalKey(DataItem);
        }
    }

    public class X264ProfileKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.X264Profile>
    {
        public X264ProfileKey()
        {
        }

        public X264ProfileKey(DashProject.Data.Item.X264Profile value)
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

    public class X264ProfileOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.X264Profile>
    {
        public X264ProfileOriginalKey()
        {
        }

        public X264ProfileOriginalKey(DashProject.Data.Item.X264Profile value)
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
            X264ProfileOriginalKey obj = new X264ProfileOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.X264Profile value)
        {
            
            _Id = value.Id;        
         
        }
    }
}