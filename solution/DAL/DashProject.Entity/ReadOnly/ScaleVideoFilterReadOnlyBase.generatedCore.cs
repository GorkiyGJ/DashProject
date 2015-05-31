using System;

namespace DashProject.Entity.ReadOnly
{
    public class ScaleVideoFilterReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.ScaleVideoFilter>
    {
        public ScaleVideoFilterReadOnlyBase()
            : base()
        {
        }

        public ScaleVideoFilterReadOnlyBase(DashProject.Data.Item.ScaleVideoFilter item)
            : base(item)
        {
        }

        #region Properties
                public virtual System.Int32 Id
        {
            get { return DataItem.Id; }
        }
        public virtual System.Int32 DashMediaId
        {
            get { return DataItem.DashMediaId; }
        }
        public virtual System.Int16 Width
        {
            get { return DataItem.Width; }
        }
        public virtual System.Int16 Height
        {
            get { return DataItem.Height; }
        }
        
        #endregion
    }
}