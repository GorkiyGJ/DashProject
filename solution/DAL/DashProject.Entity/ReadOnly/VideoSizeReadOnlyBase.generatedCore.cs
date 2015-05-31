using System;

namespace DashProject.Entity.ReadOnly
{
    public class VideoSizeReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.VideoSize>
    {
        public VideoSizeReadOnlyBase()
            : base()
        {
        }

        public VideoSizeReadOnlyBase(DashProject.Data.Item.VideoSize item)
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