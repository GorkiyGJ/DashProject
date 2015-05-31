using System;

namespace DashProject.Data.Item.Custom
{
    public abstract class iScaleVideoFilterBase : Manitou.Data.Item.Base.BaseItem
    {
        public iScaleVideoFilterBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int16? Width { get; set; } 
                
         public virtual System.Int16? Height { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        iScaleVideoFilter copy = new iScaleVideoFilter();
          copy.Width = this.Width;
          copy.Height = this.Height;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum iScaleVideoFilterColumn : byte
        {
              Width = 0 ,     
              Height = 1      
                    
        }        
    }                   
}