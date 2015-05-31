using System;

namespace DashProject.Entity.ReadOnly
{
    public class X264ProfileLevelReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.X264ProfileLevel>
    {
        public X264ProfileLevelReadOnlyBase()
            : base()
        {
        }

        public X264ProfileLevelReadOnlyBase(DashProject.Data.Item.X264ProfileLevel item)
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