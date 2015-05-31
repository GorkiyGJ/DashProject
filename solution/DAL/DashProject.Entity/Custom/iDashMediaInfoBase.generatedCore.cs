using System;

namespace DashProject.Entity.Custom
{
    public class iDashMediaInfoBase : Manitou.Entity.Base.BaseEntityReadOnly<DashProject.Data.Item.Custom.iDashMediaInfo>
    {
        public iDashMediaInfoBase()
            : base()
        {
        }

        public iDashMediaInfoBase(DashProject.Data.Item.Custom.iDashMediaInfo item)
            : base(item)
        {
        }

        #region Properties
                public virtual System.Int32? DashMediaId
        {
            get { return DataItem.DashMediaId; }
            set
            {
                DataItem.DashMediaId = value;
            }
        } 
        public virtual System.Int32? DashTypeId
        {
            get { return DataItem.DashTypeId; }
            set
            {
                DataItem.DashTypeId = value;
            }
        }
        public virtual System.Int32? DashContainerTypeId
        {
            get { return DataItem.DashContainerTypeId; }
            set
            {
                DataItem.DashContainerTypeId = value;
            }
        }
        public virtual System.Int32? CodecTypeId
        {
            get { return DataItem.CodecTypeId; }
            set
            {
                DataItem.CodecTypeId = value;
            }
        }
        public virtual System.Int32? MediaId
        {
            get { return DataItem.MediaId; }
            set
            {
                DataItem.MediaId = value;
            }
        } 
        #endregion

        public virtual object Clone()
        {
            iDashMediaInfoBase copy = new iDashMediaInfoBase();
            
            copy.DashMediaId = this.DashMediaId;
            
            copy.DashTypeId = this.DashTypeId;
            
            copy.DashContainerTypeId = this.DashContainerTypeId;
            
            copy.CodecTypeId = this.CodecTypeId;
            
            copy.MediaId = this.MediaId;
             
            return copy;
        }
    }
}