using System;

namespace DashProject.Entity.ReadOnly
{
    public class X264ProfileReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.X264Profile>
    {
        public X264ProfileReadOnlyBase()
            : base()
        {
        }

        public X264ProfileReadOnlyBase(DashProject.Data.Item.X264Profile item)
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