using System;

namespace DashProject.Entity
{
    public class MediaBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.Media, MediaKey, MediaOriginalKey>
    {
        public MediaBase()
            : base()
        {
            _OriginalKey = new MediaOriginalKey(DataItem);
            _Key = new MediaKey(DataItem);
        }

        public MediaBase(DashProject.Data.Item.Media item)
            : base(item)
        {
            _OriginalKey = new MediaOriginalKey(item);
            _Key = new MediaKey(item);
        }

        private MediaKey _Key = null;
        public override MediaKey Key
        {
            get
            {
                return _Key;
            }
        }

        private MediaOriginalKey _OriginalKey = null;
        public override MediaOriginalKey OriginalKey
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
        public virtual System.Int32 RawMediaId
        {
            get { return DataItem.RawMediaId; }
            set
            {
                if (DataItem.RawMediaId == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.RawMediaId = value;
            }
        } 
        public virtual System.Byte? ProgramIndex
        {
            get { return DataItem.ProgramIndex; }
            set
            {
                if (DataItem.ProgramIndex == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.ProgramIndex = value;
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
        public virtual System.Boolean IsActive
        {
            get { return DataItem.IsActive; }
            set
            {
                if (DataItem.IsActive == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.IsActive = value;
            }
        } 
        public virtual System.DateTime DateTimeCreated
        {
            get { return DataItem.DateTimeCreated; }
            set
            {
                if (DataItem.DateTimeCreated == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.DateTimeCreated = value;
            }
        } 
        #endregion

        public override object Clone()
        {
            MediaBase copy = new MediaBase();
            
            copy.Id = this.Id;
              copy.OriginalKey.Id = this.OriginalKey.Id;
            
            copy.RawMediaId = this.RawMediaId;
            
            copy.ProgramIndex = this.ProgramIndex;
            
            copy.Name = this.Name;
            
            copy.IsActive = this.IsActive;
            
            copy.DateTimeCreated = this.DateTimeCreated;
             
            return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public override void AcceptChanges()
        {
            EntityState = Manitou.Entity.Base.EntityState.Unchanged;

            _OriginalKey = new MediaOriginalKey(DataItem);
        }
    }

    public class MediaKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.Media>
    {
        public MediaKey()
        {
        }

        public MediaKey(DashProject.Data.Item.Media value)
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

    public class MediaOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.Media>
    {
        public MediaOriginalKey()
        {
        }

        public MediaOriginalKey(DashProject.Data.Item.Media value)
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
            MediaOriginalKey obj = new MediaOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.Media value)
        {
            
            _Id = value.Id;        
         
        }
    }
}