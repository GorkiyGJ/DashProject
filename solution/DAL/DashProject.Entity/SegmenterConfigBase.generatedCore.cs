using System;

namespace DashProject.Entity
{
    public class SegmenterConfigBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.SegmenterConfig, SegmenterConfigKey, SegmenterConfigOriginalKey>
    {
        public SegmenterConfigBase()
            : base()
        {
            _OriginalKey = new SegmenterConfigOriginalKey(DataItem);
            _Key = new SegmenterConfigKey(DataItem);
        }

        public SegmenterConfigBase(DashProject.Data.Item.SegmenterConfig item)
            : base(item)
        {
            _OriginalKey = new SegmenterConfigOriginalKey(item);
            _Key = new SegmenterConfigKey(item);
        }

        private SegmenterConfigKey _Key = null;
        public override SegmenterConfigKey Key
        {
            get
            {
                return _Key;
            }
        }

        private SegmenterConfigOriginalKey _OriginalKey = null;
        public override SegmenterConfigOriginalKey OriginalKey
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
        public virtual System.Boolean IsForceKeyFrames
        {
            get { return DataItem.IsForceKeyFrames; }
            set
            {
                if (DataItem.IsForceKeyFrames == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.IsForceKeyFrames = value;
            }
        } 
        public virtual System.Byte SegmentTime
        {
            get { return DataItem.SegmentTime; }
            set
            {
                if (DataItem.SegmentTime == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.SegmentTime = value;
            }
        } 
        public virtual System.Boolean ResetTimeStamps
        {
            get { return DataItem.ResetTimeStamps; }
            set
            {
                if (DataItem.ResetTimeStamps == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.ResetTimeStamps = value;
            }
        } 
        public virtual System.Boolean IsUseSegmentTimeDelta
        {
            get { return DataItem.IsUseSegmentTimeDelta; }
            set
            {
                if (DataItem.IsUseSegmentTimeDelta == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.IsUseSegmentTimeDelta = value;
            }
        } 
        public virtual System.Single SegmentTimeDelta
        {
            get { return DataItem.SegmentTimeDelta; }
            set
            {
                if (DataItem.SegmentTimeDelta == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.SegmentTimeDelta = value;
            }
        } 
        public virtual System.Boolean IsUseFastStart
        {
            get { return DataItem.IsUseFastStart; }
            set
            {
                if (DataItem.IsUseFastStart == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.IsUseFastStart = value;
            }
        } 
        public virtual System.Int32 FastStartDurationS
        {
            get { return DataItem.FastStartDurationS; }
            set
            {
                if (DataItem.FastStartDurationS == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.FastStartDurationS = value;
            }
        } 
        public virtual System.Int32 DurationSLimit
        {
            get { return DataItem.DurationSLimit; }
            set
            {
                if (DataItem.DurationSLimit == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.DurationSLimit = value;
            }
        } 
        public virtual System.Boolean UseDurationSLimit
        {
            get { return DataItem.UseDurationSLimit; }
            set
            {
                if (DataItem.UseDurationSLimit == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.UseDurationSLimit = value;
            }
        } 
        public virtual System.Boolean IsDone
        {
            get { return DataItem.IsDone; }
            set
            {
                if (DataItem.IsDone == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.IsDone = value;
            }
        } 
        #endregion

        public override object Clone()
        {
            SegmenterConfigBase copy = new SegmenterConfigBase();
            
            copy.Id = this.Id;
              copy.OriginalKey.Id = this.OriginalKey.Id;
            
            copy.MediaId = this.MediaId;
            
            copy.IsForceKeyFrames = this.IsForceKeyFrames;
            
            copy.SegmentTime = this.SegmentTime;
            
            copy.ResetTimeStamps = this.ResetTimeStamps;
            
            copy.IsUseSegmentTimeDelta = this.IsUseSegmentTimeDelta;
            
            copy.SegmentTimeDelta = this.SegmentTimeDelta;
            
            copy.IsUseFastStart = this.IsUseFastStart;
            
            copy.FastStartDurationS = this.FastStartDurationS;
            
            copy.DurationSLimit = this.DurationSLimit;
            
            copy.UseDurationSLimit = this.UseDurationSLimit;
            
            copy.IsDone = this.IsDone;
             
            return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public override void AcceptChanges()
        {
            EntityState = Manitou.Entity.Base.EntityState.Unchanged;

            _OriginalKey = new SegmenterConfigOriginalKey(DataItem);
        }
    }

    public class SegmenterConfigKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.SegmenterConfig>
    {
        public SegmenterConfigKey()
        {
        }

        public SegmenterConfigKey(DashProject.Data.Item.SegmenterConfig value)
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

    public class SegmenterConfigOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.SegmenterConfig>
    {
        public SegmenterConfigOriginalKey()
        {
        }

        public SegmenterConfigOriginalKey(DashProject.Data.Item.SegmenterConfig value)
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
            SegmenterConfigOriginalKey obj = new SegmenterConfigOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.SegmenterConfig value)
        {
            
            _Id = value.Id;        
         
        }
    }
}