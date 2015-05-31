using System;

namespace DashProject.Data.Item.Custom
{
    public abstract class iMediaInfoBase : Manitou.Data.Item.Base.BaseItem
    {
        public iMediaInfoBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int32? MediaId { get; set; } 
                
         public virtual System.Byte? ProgramIndex { get; set; } 
                
         public virtual System.Int32? RawMediaId { get; set; } 
                
         public virtual System.Byte? RawMediaSourceTypeId { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        iMediaInfo copy = new iMediaInfo();
          copy.MediaId = this.MediaId;
          copy.ProgramIndex = this.ProgramIndex;
          copy.RawMediaId = this.RawMediaId;
          copy.RawMediaSourceTypeId = this.RawMediaSourceTypeId;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum iMediaInfoColumn : byte
        {
              MediaId = 0 ,     
              ProgramIndex = 1 ,     
              RawMediaId = 2 ,     
              RawMediaSourceTypeId = 3      
                    
        }        
    }                   
}