using System;

namespace DashProject.Entity
{
    public class DashMediaSegmentBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.DashMediaSegment, DashMediaSegmentKey, DashMediaSegmentOriginalKey>
    {
        public DashMediaSegmentBase()
            : base()
        {
            _OriginalKey = new DashMediaSegmentOriginalKey(DataItem);
            _Key = new DashMediaSegmentKey(DataItem);
        }

        public DashMediaSegmentBase(DashProject.Data.Item.DashMediaSegment item)
            : base(item)
        {
            _OriginalKey = new DashMediaSegmentOriginalKey(item);
            _Key = new DashMediaSegmentKey(item);
        }

        private DashMediaSegmentKey _Key = null;
        public override DashMediaSegmentKey Key
        {
            get
            {
                return _Key;
            }
        }

        private DashMediaSegmentOriginalKey _OriginalKey = null;
        public override DashMediaSegmentOriginalKey OriginalKey
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
        public virtual System.Int32 TimeScale
        {
            get { return DataItem.TimeScale; }
            set
            {
                if (DataItem.TimeScale == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.TimeScale = value;
            }
        } 
        public virtual System.Int64 DecodeTimeTS
        {
            get { return DataItem.DecodeTimeTS; }
            set
            {
                if (DataItem.DecodeTimeTS == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.DecodeTimeTS = value;
            }
        } 
        public virtual System.Int32 DurationTS
        {
            get { return DataItem.DurationTS; }
            set
            {
                if (DataItem.DurationTS == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.DurationTS = value;
            }
        } 
        public virtual System.Decimal DurationS
        {
            get { return DataItem.DurationS; }
            set
            {
                if (DataItem.DurationS == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.DurationS = value;
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
            DashMediaSegmentBase copy = new DashMediaSegmentBase();
            
            copy.Id = this.Id;
              copy.OriginalKey.Id = this.OriginalKey.Id;
            
            copy.DashMediaId = this.DashMediaId;
            
            copy.ContainerFormatId = this.ContainerFormatId;
            
            copy.TimeScale = this.TimeScale;
            
            copy.DecodeTimeTS = this.DecodeTimeTS;
            
            copy.DurationTS = this.DurationTS;
            
            copy.DurationS = this.DurationS;
            
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

            _OriginalKey = new DashMediaSegmentOriginalKey(DataItem);
        }
    }

    public class DashMediaSegmentKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.DashMediaSegment>
    {
        public DashMediaSegmentKey()
        {
        }

        public DashMediaSegmentKey(DashProject.Data.Item.DashMediaSegment value)
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

    public class DashMediaSegmentOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.DashMediaSegment>
    {
        public DashMediaSegmentOriginalKey()
        {
        }

        public DashMediaSegmentOriginalKey(DashProject.Data.Item.DashMediaSegment value)
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
            DashMediaSegmentOriginalKey obj = new DashMediaSegmentOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.DashMediaSegment value)
        {
            
            _Id = value.Id;        
         
        }
    }
}