using System;

namespace DashProject.Entity.ReadOnly
{
    public class DashInitSegmentReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.DashInitSegment>
    {
        public DashInitSegmentReadOnlyBase()
            : base()
        {
        }

        public DashInitSegmentReadOnlyBase(DashProject.Data.Item.DashInitSegment item)
            : base(item)
        {
        }

        #region Properties
                public virtual System.Int32 Id
        {
            get { return DataItem.Id; }
        }
        public virtual System.Int32 ContainerFormatId
        {
            get { return DataItem.ContainerFormatId; }
        }
        public virtual System.String FileName
        {
            get { return DataItem.FileName; }
        }
        public virtual System.DateTime DateTimeCreated
        {
            get { return DataItem.DateTimeCreated; }
        }
        
        #endregion
    }
}