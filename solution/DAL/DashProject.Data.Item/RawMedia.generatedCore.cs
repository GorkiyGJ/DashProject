using System;

namespace DashProject.Data.Item
{
    public abstract class RawMediaBase : Manitou.Data.Item.Base.BaseItem
    {
        public RawMediaBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int32 Id { get; set; } 
                
         public virtual System.Int32 ContainerTypeId { get; set; } 
                
         public virtual System.String InputMedia { get; set; } 
                
         public virtual System.Byte RawMediaSourceTypeId { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        RawMedia copy = new RawMedia();
          copy.Id = this.Id;
          copy.ContainerTypeId = this.ContainerTypeId;
          copy.InputMedia = this.InputMedia;
          copy.RawMediaSourceTypeId = this.RawMediaSourceTypeId;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum RawMediaColumn : byte
        {
              Id = 1 ,     
              ContainerTypeId = 2 ,     
              InputMedia = 3 ,     
              RawMediaSourceTypeId = 4      
                    
        }        
    }                   
}