using System;

namespace DashProject.Data.Item
{
    public abstract class AspectRatioBase : Manitou.Data.Item.Base.BaseItem
    {
        public AspectRatioBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int32 Id { get; set; } 
                
         public virtual System.String Type1 { get; set; } 
                
         public virtual System.Double? Type2 { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        AspectRatio copy = new AspectRatio();
          copy.Id = this.Id;
          copy.Type1 = this.Type1;
          copy.Type2 = this.Type2;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum AspectRatioColumn : byte
        {
              Id = 1 ,     
              Type1 = 2 ,     
              Type2 = 3      
                    
        }        
    }                   
}