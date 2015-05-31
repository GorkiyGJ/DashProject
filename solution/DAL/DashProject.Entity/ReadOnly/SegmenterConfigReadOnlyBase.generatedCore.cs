using System;

namespace DashProject.Entity.ReadOnly
{
    public class SegmenterConfigReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.SegmenterConfig>
    {
        public SegmenterConfigReadOnlyBase()
            : base()
        {
        }

        public SegmenterConfigReadOnlyBase(DashProject.Data.Item.SegmenterConfig item)
            : base(item)
        {
        }

        #region Properties
                public virtual System.Int32 Id
        {
            get { return DataItem.Id; }
        }
        public virtual System.Int32 MediaId
        {
            get { return DataItem.MediaId; }
        }
        public virtual System.Boolean IsForceKeyFrames
        {
            get { return DataItem.IsForceKeyFrames; }
        }
        public virtual System.Byte SegmentTime
        {
            get { return DataItem.SegmentTime; }
        }
        public virtual System.Boolean ResetTimeStamps
        {
            get { return DataItem.ResetTimeStamps; }
        }
        public virtual System.Boolean IsUseSegmentTimeDelta
        {
            get { return DataItem.IsUseSegmentTimeDelta; }
        }
        public virtual System.Single SegmentTimeDelta
        {
            get { return DataItem.SegmentTimeDelta; }
        }
        public virtual System.Boolean IsUseFastStart
        {
            get { return DataItem.IsUseFastStart; }
        }
        public virtual System.Int32 FastStartDurationS
        {
            get { return DataItem.FastStartDurationS; }
        }
        public virtual System.Int32 DurationSLimit
        {
            get { return DataItem.DurationSLimit; }
        }
        public virtual System.Boolean UseDurationSLimit
        {
            get { return DataItem.UseDurationSLimit; }
        }
        public virtual System.Boolean IsDone
        {
            get { return DataItem.IsDone; }
        }
        
        #endregion
    }
}