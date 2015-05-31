using System;

namespace DashProject.Entity
{
    public class AspectRatioBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.AspectRatio, AspectRatioKey, AspectRatioOriginalKey>
    {
        public AspectRatioBase()
            : base()
        {
            _OriginalKey = new AspectRatioOriginalKey(DataItem);
            _Key = new AspectRatioKey(DataItem);
        }

        public AspectRatioBase(DashProject.Data.Item.AspectRatio item)
            : base(item)
        {
            _OriginalKey = new AspectRatioOriginalKey(item);
            _Key = new AspectRatioKey(item);
        }

        private AspectRatioKey _Key = null;
        public override AspectRatioKey Key
        {
            get
            {
                return _Key;
            }
        }

        private AspectRatioOriginalKey _OriginalKey = null;
        public override AspectRatioOriginalKey OriginalKey
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
        public virtual System.String Type1
        {
            get { return DataItem.Type1; }
            set
            {
                if (DataItem.Type1 == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.Type1 = value;
            }
        } 
        public virtual System.Double? Type2
        {
            get { return DataItem.Type2; }
            set
            {
                if (DataItem.Type2 == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.Type2 = value;
            }
        } 
        #endregion

        public override object Clone()
        {
            AspectRatioBase copy = new AspectRatioBase();
            
            copy.Id = this.Id;
              copy.OriginalKey.Id = this.OriginalKey.Id;
            
            copy.Type1 = this.Type1;
            
            copy.Type2 = this.Type2;
             
            return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public override void AcceptChanges()
        {
            EntityState = Manitou.Entity.Base.EntityState.Unchanged;

            _OriginalKey = new AspectRatioOriginalKey(DataItem);
        }
    }

    public class AspectRatioKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.AspectRatio>
    {
        public AspectRatioKey()
        {
        }

        public AspectRatioKey(DashProject.Data.Item.AspectRatio value)
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

    public class AspectRatioOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.AspectRatio>
    {
        public AspectRatioOriginalKey()
        {
        }

        public AspectRatioOriginalKey(DashProject.Data.Item.AspectRatio value)
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
            AspectRatioOriginalKey obj = new AspectRatioOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.AspectRatio value)
        {
            
            _Id = value.Id;        
         
        }
    }
}