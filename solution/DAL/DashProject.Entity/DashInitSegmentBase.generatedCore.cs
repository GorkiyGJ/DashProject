using System;

namespace DashProject.Entity
{
    public class DashInitSegmentBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.DashInitSegment, DashInitSegmentKey, DashInitSegmentOriginalKey>
    {
        public DashInitSegmentBase()
            : base()
        {
            _OriginalKey = new DashInitSegmentOriginalKey(DataItem);
            _Key = new DashInitSegmentKey(DataItem);
        }

        public DashInitSegmentBase(DashProject.Data.Item.DashInitSegment item)
            : base(item)
        {
            _OriginalKey = new DashInitSegmentOriginalKey(item);
            _Key = new DashInitSegmentKey(item);
        }

        private DashInitSegmentKey _Key = null;
        public override DashInitSegmentKey Key
        {
            get
            {
                return _Key;
            }
        }

        private DashInitSegmentOriginalKey _OriginalKey = null;
        public override DashInitSegmentOriginalKey OriginalKey
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
        public virtual System.Int32 ContainerFormatId
        {
            get { return DataItem.ContainerFormatId; }
            set
            {
                if (DataItem.ContainerFormatId == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.ContainerFormatId = value;
            }
        } 
        public virtual System.String FileName
        {
            get { return DataItem.FileName; }
            set
            {
                if (DataItem.FileName == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.FileName = value;
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
            DashInitSegmentBase copy = new DashInitSegmentBase();
            
            copy.Id = this.Id;
              copy.OriginalKey.Id = this.OriginalKey.Id;
            
            copy.ContainerFormatId = this.ContainerFormatId;
            
            copy.FileName = this.FileName;
            
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

            _OriginalKey = new DashInitSegmentOriginalKey(DataItem);
        }
    }

    public class DashInitSegmentKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.DashInitSegment>
    {
        public DashInitSegmentKey()
        {
        }

        public DashInitSegmentKey(DashProject.Data.Item.DashInitSegment value)
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

    public class DashInitSegmentOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.DashInitSegment>
    {
        public DashInitSegmentOriginalKey()
        {
        }

        public DashInitSegmentOriginalKey(DashProject.Data.Item.DashInitSegment value)
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
            DashInitSegmentOriginalKey obj = new DashInitSegmentOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.DashInitSegment value)
        {
            
            _Id = value.Id;        
         
        }
    }
}