using System;

namespace DashProject.Entity
{
    public class RawSegmentStreamBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.RawSegmentStream, RawSegmentStreamKey, RawSegmentStreamOriginalKey>
    {
        public RawSegmentStreamBase()
            : base()
        {
            _OriginalKey = new RawSegmentStreamOriginalKey(DataItem);
            _Key = new RawSegmentStreamKey(DataItem);
        }

        public RawSegmentStreamBase(DashProject.Data.Item.RawSegmentStream item)
            : base(item)
        {
            _OriginalKey = new RawSegmentStreamOriginalKey(item);
            _Key = new RawSegmentStreamKey(item);
        }

        private RawSegmentStreamKey _Key = null;
        public override RawSegmentStreamKey Key
        {
            get
            {
                return _Key;
            }
        }

        private RawSegmentStreamOriginalKey _OriginalKey = null;
        public override RawSegmentStreamOriginalKey OriginalKey
        {
            get
            {
                return _OriginalKey;
            }
        }

        #region Properties
                public virtual System.Int64 Id
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
        public virtual System.Int64 SegmentId
        {
            get { return DataItem.SegmentId; }
            set
            {
                if (DataItem.SegmentId == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.SegmentId = value;
            }
        } 
        public virtual System.Int32 MediaId
        {
            get { return DataItem.MediaId; }
            set
            {
                if (DataItem.MediaId == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.MediaId = value;
            }
        } 
        public virtual System.Int32 StreamId
        {
            get { return DataItem.StreamId; }
            set
            {
                if (DataItem.StreamId == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.StreamId = value;
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
        public virtual System.Decimal GlobalStartTimeS
        {
            get { return DataItem.GlobalStartTimeS; }
            set
            {
                if (DataItem.GlobalStartTimeS == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.GlobalStartTimeS = value;
            }
        } 
        public virtual System.Decimal GlobalEndTimeS
        {
            get { return DataItem.GlobalEndTimeS; }
            set
            {
                if (DataItem.GlobalEndTimeS == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.GlobalEndTimeS = value;
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
            RawSegmentStreamBase copy = new RawSegmentStreamBase();
            
            copy.Id = this.Id;
              copy.OriginalKey.Id = this.OriginalKey.Id;
            
            copy.SegmentId = this.SegmentId;
            
            copy.MediaId = this.MediaId;
            
            copy.StreamId = this.StreamId;
            
            copy.FileName = this.FileName;
            
            copy.DurationS = this.DurationS;
            
            copy.GlobalStartTimeS = this.GlobalStartTimeS;
            
            copy.GlobalEndTimeS = this.GlobalEndTimeS;
            
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

            _OriginalKey = new RawSegmentStreamOriginalKey(DataItem);
        }
    }

    public class RawSegmentStreamKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.RawSegmentStream>
    {
        public RawSegmentStreamKey()
        {
        }

        public RawSegmentStreamKey(DashProject.Data.Item.RawSegmentStream value)
            : base(value)
        {
        }

            
        public System.Int64 Id
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

    public class RawSegmentStreamOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.RawSegmentStream>
    {
        public RawSegmentStreamOriginalKey()
        {
        }

        public RawSegmentStreamOriginalKey(DashProject.Data.Item.RawSegmentStream value)
            : base(value)
        {
        }

         
        private System.Int64 _Id;   
        public System.Int64 Id
        {
            get
            {
                return _Id;
            }
            
            internal set { _Id = value; }
        }
 

        public override object Clone()
        {
            RawSegmentStreamOriginalKey obj = new RawSegmentStreamOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.RawSegmentStream value)
        {
            
            _Id = value.Id;        
         
        }
    }
}