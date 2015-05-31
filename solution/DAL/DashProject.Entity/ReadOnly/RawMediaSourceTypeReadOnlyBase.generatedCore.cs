using System;

namespace DashProject.Entity.ReadOnly
{
    public class RawMediaSourceTypeReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.RawMediaSourceType>
    {
        public RawMediaSourceTypeReadOnlyBase()
            : base()
        {
        }

        public RawMediaSourceTypeReadOnlyBase(DashProject.Data.Item.RawMediaSourceType item)
            : base(item)
        {
        }

        #region Properties
                public virtual System.Byte Id
        {
            get { return DataItem.Id; }
        }
        public virtual System.String Name
        {
            get { return DataItem.Name; }
        }
        
        #endregion
    }
}