using System;

namespace DashProject.Entity.ReadOnly
{
    public class AspectRatioReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.AspectRatio>
    {
        public AspectRatioReadOnlyBase()
            : base()
        {
        }

        public AspectRatioReadOnlyBase(DashProject.Data.Item.AspectRatio item)
            : base(item)
        {
        }

        #region Properties
                public virtual System.Int32 Id
        {
            get { return DataItem.Id; }
        }
        public virtual System.String Type1
        {
            get { return DataItem.Type1; }
        }
        public virtual System.Double? Type2
        {
            get { return DataItem.Type2; }
        }
        
        #endregion
    }
}