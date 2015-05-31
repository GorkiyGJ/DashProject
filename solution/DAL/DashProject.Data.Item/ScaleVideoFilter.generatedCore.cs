using System;

namespace DashProject.Data.Item
{
    public abstract class ScaleVideoFilterBase : Manitou.Data.Item.Base.BaseItem
    {
        public ScaleVideoFilterBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int32 Id { get; set; } 
                
         public virtual System.Int32 DashMediaId { get; set; } 
                
         public virtual System.Int16 Width { get; set; } 
                
         public virtual System.Int16 Height { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        ScaleVideoFilter copy = new ScaleVideoFilter();
          copy.Id = this.Id;
          copy.DashMediaId = this.DashMediaId;
          copy.Width = this.Width;
          copy.Height = this.Height;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum ScaleVideoFilterColumn : byte
        {
              Id = 1 ,     
              DashMediaId = 2 ,     
              Width = 3 ,     
              Height = 4      
                    
        }        
    }                   
}