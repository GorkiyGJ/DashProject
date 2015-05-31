using System;

namespace DashProject.Entity.ReadOnly
{
    public class DashMediaSegmentReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.DashMediaSegment>
    {
        public DashMediaSegmentReadOnlyBase()
            : base()
        {
        }

        public DashMediaSegmentReadOnlyBase(DashProject.Data.Item.DashMediaSegment item)
            : base(item)
        {
        }

        #region Properties
                public virtual System.Int32 Id
        {
            get { return DataItem.Id; }
        }
        public virtual System.Int32 DashMediaId
        {
            get { return DataItem.DashMediaId; }
        }
        public virtual System.Int32 TimeScale
        {
            get { return DataItem.TimeScale; }
        }
        public virtual System.Int64 DecodeTimeTS
        {
            get { return DataItem.DecodeTimeTS; }
        }
        public virtual System.Int32 DurationTS
        {
            get { return DataItem.DurationTS; }
        }
        public virtual System.Decimal DurationS
        {
            get { return DataItem.DurationS; }
        }
        public virtual System.DateTime DateTimeCreated
        {
            get { return DataItem.DateTimeCreated; }
        }
        public virtual System.Decimal GlobalStartTimeS
        {
            get { return DataItem.GlobalStartTimeS; }
        }
        public virtual System.Decimal GlobalEndTimeS
        {
            get { return DataItem.GlobalEndTimeS; }
        }
        
        #endregion
    }
}