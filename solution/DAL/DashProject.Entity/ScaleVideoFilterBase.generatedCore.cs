using System;

namespace DashProject.Entity
{
    public class ScaleVideoFilterBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.ScaleVideoFilter, ScaleVideoFilterKey, ScaleVideoFilterOriginalKey>
    {
        public ScaleVideoFilterBase()
            : base()
        {
            _OriginalKey = new ScaleVideoFilterOriginalKey(DataItem);
            _Key = new ScaleVideoFilterKey(DataItem);
        }

        public ScaleVideoFilterBase(DashProject.Data.Item.ScaleVideoFilter item)
            : base(item)
        {
            _OriginalKey = new ScaleVideoFilterOriginalKey(item);
            _Key = new ScaleVideoFilterKey(item);
        }

        private ScaleVideoFilterKey _Key = null;
        public override ScaleVideoFilterKey Key
        {
            get
            {
                return _Key;
            }
        }

        private ScaleVideoFilterOriginalKey _OriginalKey = null;
        public override ScaleVideoFilterOriginalKey OriginalKey
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
        public virtual System.Int32 DashMediaId
        {
            get { return DataItem.DashMediaId; }
            set
            {
                if (DataItem.DashMediaId == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.DashMediaId = value;
            }
        } 
        public virtual System.Int16 Width
        {
            get { return DataItem.Width; }
            set
            {
                if (DataItem.Width == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.Width = value;
            }
        } 
        public virtual System.Int16 Height
        {
            get { return DataItem.Height; }
            set
            {
                if (DataItem.Height == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.Height = value;
            }
        } 
        #endregion

        public override object Clone()
        {
            ScaleVideoFilterBase copy = new ScaleVideoFilterBase();
            
            copy.Id = this.Id;
              copy.OriginalKey.Id = this.OriginalKey.Id;
            
            copy.DashMediaId = this.DashMediaId;
            
            copy.Width = this.Width;
            
            copy.Height = this.Height;
             
            return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public override void AcceptChanges()
        {
            EntityState = Manitou.Entity.Base.EntityState.Unchanged;

            _OriginalKey = new ScaleVideoFilterOriginalKey(DataItem);
        }
    }

    public class ScaleVideoFilterKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.ScaleVideoFilter>
    {
        public ScaleVideoFilterKey()
        {
        }

        public ScaleVideoFilterKey(DashProject.Data.Item.ScaleVideoFilter value)
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

    public class ScaleVideoFilterOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.ScaleVideoFilter>
    {
        public ScaleVideoFilterOriginalKey()
        {
        }

        public ScaleVideoFilterOriginalKey(DashProject.Data.Item.ScaleVideoFilter value)
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
            ScaleVideoFilterOriginalKey obj = new ScaleVideoFilterOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.ScaleVideoFilter value)
        {
            
            _Id = value.Id;        
         
        }
    }
}