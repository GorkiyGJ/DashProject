using System;

namespace DashProject.Entity.ReadOnly
{
    public class RawMediaReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.RawMedia>
    {
        public RawMediaReadOnlyBase()
            : base()
        {
        }

        public RawMediaReadOnlyBase(DashProject.Data.Item.RawMedia item)
            : base(item)
        {
        }

        #region Properties
                public virtual System.Int32 Id
        {
            get { return DataItem.Id; }
        }
        public virtual System.Int32 ContainerTypeId
        {
            get { return DataItem.ContainerTypeId; }
        }
        public virtual System.String InputMedia
        {
            get { return DataItem.InputMedia; }
        }
        public virtual System.Byte RawMediaSourceTypeId
        {
            get { return DataItem.RawMediaSourceTypeId; }
        }
        
        #endregion
    }
}