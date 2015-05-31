using System;

namespace DashProject.Entity.ReadOnly
{
    public class ContainerTypeReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.ContainerType>
    {
        public ContainerTypeReadOnlyBase()
            : base()
        {
        }

        public ContainerTypeReadOnlyBase(DashProject.Data.Item.ContainerType item)
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
        public virtual System.String Description
        {
            get { return DataItem.Description; }
        }
        
        #endregion
    }
}