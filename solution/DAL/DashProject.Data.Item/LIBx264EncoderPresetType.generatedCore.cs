using System;

namespace DashProject.Data.Item
{
    public abstract class LIBx264EncoderPresetTypeBase : Manitou.Data.Item.Base.BaseItem
    {
        public LIBx264EncoderPresetTypeBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int32 Id { get; set; } 
                
         public virtual System.String Name { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        LIBx264EncoderPresetType copy = new LIBx264EncoderPresetType();
          copy.Id = this.Id;
          copy.Name = this.Name;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum LIBx264EncoderPresetTypeColumn : byte
        {
              Id = 1 ,     
              Name = 2      
                    
        }        
    }                   
}