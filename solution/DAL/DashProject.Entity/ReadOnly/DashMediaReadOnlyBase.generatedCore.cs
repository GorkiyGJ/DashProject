using System;

namespace DashProject.Entity.ReadOnly
{
    public class DashMediaReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.DashMedia>
    {
        public DashMediaReadOnlyBase()
            : base()
        {
        }

        public DashMediaReadOnlyBase(DashProject.Data.Item.DashMedia item)
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
        public virtual System.Int32 StreamId
        {
            get { return DataItem.StreamId; }
        }
        public virtual System.Int32? DashInitSegmentId
        {
            get { return DataItem.DashInitSegmentId; }
        }
        public virtual System.Int32 DashTypeId
        {
            get { return DataItem.DashTypeId; }
        }
        public virtual System.Int32 CodecTypeId
        {
            get { return DataItem.CodecTypeId; }
        }
        public virtual System.Int16? Width
        {
            get { return DataItem.Width; }
        }
        public virtual System.Int16? Height
        {
            get { return DataItem.Height; }
        }
        public virtual System.Byte? Channels
        {
            get { return DataItem.Channels; }
        }
        public virtual System.Int32 BitrateKbps
        {
            get { return DataItem.BitrateKbps; }
        }
        public virtual System.Boolean IsActive
        {
            get { return DataItem.IsActive; }
        }
        public virtual System.Int32 FragmentDurationS
        {
            get { return DataItem.FragmentDurationS; }
        }
        
        #endregion
    }
}