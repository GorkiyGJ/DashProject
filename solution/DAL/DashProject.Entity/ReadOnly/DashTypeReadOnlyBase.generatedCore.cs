using System;

namespace DashProject.Entity.ReadOnly
{
    public class DashTypeReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.DashType>
    {
        public DashTypeReadOnlyBase()
            : base()
        {
        }

        public DashTypeReadOnlyBase(DashProject.Data.Item.DashType item)
            : base(item)
        {
        }

        #region Properties
                public virtual System.Int32 Id
        {
            get { return DataItem.Id; }
        }
        public virtual System.String Name
        {
            get { return DataItem.Name; }
        }
        public virtual System.Int32 ContainerTypeId
        {
            get { return DataItem.ContainerTypeId; }
        }
        
        #endregion
    }
}