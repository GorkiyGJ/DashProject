using System;

namespace DashProject.Entity.Custom
{
    public class iScaleVideoFilterBase : Manitou.Entity.Base.BaseEntityReadOnly<DashProject.Data.Item.Custom.iScaleVideoFilter>
    {
        public iScaleVideoFilterBase()
            : base()
        {
        }

        public iScaleVideoFilterBase(DashProject.Data.Item.Custom.iScaleVideoFilter item)
            : base(item)
        {
        }

        #region Properties
                public virtual System.Int16? Width
        {
            get { return DataItem.Width; }
            set
            {
                DataItem.Width = value;
            }
        } 
        public virtual System.Int16? Height
        {
            get { return DataItem.Height; }
            set
            {
                DataItem.Height = value;
            }
        } 
        #endregion

        public virtual object Clone()
        {
            iScaleVideoFilterBase copy = new iScaleVideoFilterBase();
            
            copy.Width = this.Width;
            
            copy.Height = this.Height;
             
            return copy;
        }
    }
}