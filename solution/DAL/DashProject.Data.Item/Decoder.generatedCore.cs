using System;

namespace DashProject.Data.Item
{
    public abstract class DecoderBase : Manitou.Data.Item.Base.BaseItem
    {
        public DecoderBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int32 Id { get; set; } 
                
         public virtual System.String Name { get; set; } 
                
         public virtual System.String Description { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        Decoder copy = new Decoder();
          copy.Id = this.Id;
          copy.Name = this.Name;
          copy.Description = this.Description;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum DecoderColumn : byte
        {
              Id = 1 ,     
              Name = 2 ,     
              Description = 3      
                    
        }        
    }                   
}