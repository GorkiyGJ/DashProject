using System;

namespace DashProject.Data.Item
{
    public abstract class CodecToEncoderBase : Manitou.Data.Item.Base.BaseItem
    {
        public CodecToEncoderBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int32 Id { get; set; } 
                
         public virtual System.Int32 CodecTypeId { get; set; } 
                
         public virtual System.Int32 EncoderTypeId { get; set; } 
                
         public virtual System.Boolean IsMain { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        CodecToEncoder copy = new CodecToEncoder();
          copy.Id = this.Id;
          copy.CodecTypeId = this.CodecTypeId;
          copy.EncoderTypeId = this.EncoderTypeId;
          copy.IsMain = this.IsMain;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum CodecToEncoderColumn : byte
        {
              Id = 1 ,     
              CodecTypeId = 2 ,     
              EncoderTypeId = 3 ,     
              IsMain = 4      
                    
        }        
    }                   
}