using System;

namespace DashProject.Entity.ReadOnly
{
    public class CoderTypeReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.CoderType>
    {
        public CoderTypeReadOnlyBase()
            : base()
        {
        }

        public CoderTypeReadOnlyBase(DashProject.Data.Item.CoderType item)
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
        
        #endregion
    }
}