using System;

namespace DashProject.Data.Item.Custom
{
    public abstract class iStreamInfoBase : Manitou.Data.Item.Base.BaseItem
    {
        public iStreamInfoBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int32? Id { get; set; } 
                
         public virtual System.Byte? Index { get; set; } 
                
         public virtual System.Decimal? GlobalEndTimeS { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        iStreamInfo copy = new iStreamInfo();
          copy.Id = this.Id;
          copy.Index = this.Index;
          copy.GlobalEndTimeS = this.GlobalEndTimeS;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum iStreamInfoColumn : byte
        {
              Id = 0 ,     
              Index = 1 ,     
              GlobalEndTimeS = 2      
                    
        }        
    }                   
}