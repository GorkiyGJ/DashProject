using System;

namespace DashProject.Data.Item
{
    public abstract class CodecTypeBase : Manitou.Data.Item.Base.BaseItem
    {
        public CodecTypeBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int32 Id { get; set; } 
                
         public virtual System.Int32 StreamTypeId { get; set; } 
                
         public virtual System.String Name { get; set; } 
                
         public virtual System.String Description { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        CodecType copy = new CodecType();
          copy.Id = this.Id;
          copy.StreamTypeId = this.StreamTypeId;
          copy.Name = this.Name;
          copy.Description = this.Description;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum CodecTypeColumn : byte
        {
              Id = 1 ,     
              StreamTypeId = 2 ,     
              Name = 3 ,     
              Description = 4      
                    
        }        
    }                   
}