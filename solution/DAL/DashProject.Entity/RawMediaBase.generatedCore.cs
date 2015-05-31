using System;

namespace DashProject.Entity
{
    public class RawMediaBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.RawMedia, RawMediaKey, RawMediaOriginalKey>
    {
        public RawMediaBase()
            : base()
        {
            _OriginalKey = new RawMediaOriginalKey(DataItem);
            _Key = new RawMediaKey(DataItem);
        }

        public RawMediaBase(DashProject.Data.Item.RawMedia item)
            : base(item)
        {
            _OriginalKey = new RawMediaOriginalKey(item);
            _Key = new RawMediaKey(item);
        }

        private RawMediaKey _Key = null;
        public override RawMediaKey Key
        {
            get
            {
                return _Key;
            }
        }

        private RawMediaOriginalKey _OriginalKey = null;
        public override RawMediaOriginalKey OriginalKey
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
        public virtual System.String InputMedia
        {
            get { return DataItem.InputMedia; }
            set
            {
                if (DataItem.InputMedia == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.InputMedia = value;
            }
        } 
        public virtual System.Byte RawMediaSourceTypeId
        {
            get { return DataItem.RawMediaSourceTypeId; }
            set
            {
                if (DataItem.RawMediaSourceTypeId == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.RawMediaSourceTypeId = value;
            }
        } 
        #endregion

        public override object Clone()
        {
            RawMediaBase copy = new RawMediaBase();
            
            copy.Id = this.Id;
              copy.OriginalKey.Id = this.OriginalKey.Id;
            
            copy.ContainerTypeId = this.ContainerTypeId;
            
            copy.InputMedia = this.InputMedia;
            
            copy.RawMediaSourceTypeId = this.RawMediaSourceTypeId;
             
            return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public override void AcceptChanges()
        {
            EntityState = Manitou.Entity.Base.EntityState.Unchanged;

            _OriginalKey = new RawMediaOriginalKey(DataItem);
        }
    }

    public class RawMediaKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.RawMedia>
    {
        public RawMediaKey()
        {
        }

        public RawMediaKey(DashProject.Data.Item.RawMedia value)
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

    public class RawMediaOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.RawMedia>
    {
        public RawMediaOriginalKey()
        {
        }

        public RawMediaOriginalKey(DashProject.Data.Item.RawMedia value)
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
            RawMediaOriginalKey obj = new RawMediaOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.RawMedia value)
        {
            
            _Id = value.Id;        
         
        }
    }
}