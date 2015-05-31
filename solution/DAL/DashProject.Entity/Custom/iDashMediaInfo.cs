using System;

namespace DashProject.Entity.Custom
{
    public class iDashMediaInfo : iDashMediaInfoBase
    {
        public iDashMediaInfo()
            : base()
        { 
        }

        public iDashMediaInfo(DashProject.Data.Item.Custom.iDashMediaInfo item)
            : base(item)
        { 
        }

        #region Properties
        public virtual System.Int32 DashMediaId
        {
            get { return DataItem.DashMediaId.Value; }
            set
            {
                DataItem.DashMediaId = value;
            }
        }
        public virtual System.Int32 DashTypeId
        {
            get { return DataItem.DashTypeId.Value; }
            set
            {
                DataItem.DashTypeId = value;
            }
        }
        public virtual System.Int32 DashContainerTypeId
        {
            get { return DataItem.DashContainerTypeId.Value; }
            set
            {
                DataItem.DashContainerTypeId = value;
            }
        }
        public virtual System.Int32 CodecTypeId
        {
            get { return DataItem.CodecTypeId.Value; }
            set
            {
                DataItem.CodecTypeId = value;
            }
        }
        public virtual System.Int32 MediaId
        {
            get { return DataItem.MediaId.Value; }
            set
            {
                DataItem.MediaId = value;
            }
        }
        #endregion
    }
}