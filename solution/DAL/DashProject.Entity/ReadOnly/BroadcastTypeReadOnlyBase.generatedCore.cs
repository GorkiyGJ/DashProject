using System;

namespace DashProject.Entity.ReadOnly
{
    public class BroadcastTypeReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.BroadcastType>
    {
        public BroadcastTypeReadOnlyBase()
            : base()
        {
        }

        public BroadcastTypeReadOnlyBase(DashProject.Data.Item.BroadcastType item)
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