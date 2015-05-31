using System;

namespace DashProject.Entity.ReadOnly
{
    public class RawSegmentStreamReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.RawSegmentStream>
    {
        public RawSegmentStreamReadOnlyBase()
            : base()
        {
        }

        public RawSegmentStreamReadOnlyBase(DashProject.Data.Item.RawSegmentStream item)
            : base(item)
        {
        }

        #region Properties
                public virtual System.Int64 Id
        {
            get { return DataItem.Id; }
        }
        public virtual System.Int64 SegmentId
        {
            get { return DataItem.SegmentId; }
        }
        public virtual System.Int32 MediaId
        {
            get { return DataItem.MediaId; }
        }
        public virtual System.Int32 StreamId
        {
            get { return DataItem.StreamId; }
        }
        public virtual System.String FileName
        {
            get { return DataItem.FileName; }
        }
        public virtual System.Decimal DurationS
        {
            get { return DataItem.DurationS; }
        }
        public virtual System.Decimal GlobalStartTimeS
        {
            get { return DataItem.GlobalStartTimeS; }
        }
        public virtual System.Decimal GlobalEndTimeS
        {
            get { return DataItem.GlobalEndTimeS; }
        }
        public virtual System.DateTime DateTimeCreated
        {
            get { return DataItem.DateTimeCreated; }
        }
        
        #endregion
    }
}