using System;

namespace DashProject.Data.Item.Custom
{
    public abstract class iDashMediaInfoBase : Manitou.Data.Item.Base.BaseItem
    {
        public iDashMediaInfoBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int32? DashMediaId { get; set; } 
                
         public virtual System.Int32? DashTypeId { get; set; } 
                
         public virtual System.Int32? DashContainerTypeId { get; set; } 
                
         public virtual System.Int32? CodecTypeId { get; set; } 
                
         public virtual System.Int32? MediaId { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        iDashMediaInfo copy = new iDashMediaInfo();
          copy.DashMediaId = this.DashMediaId;
          copy.DashTypeId = this.DashTypeId;
          copy.DashContainerTypeId = this.DashContainerTypeId;
          copy.CodecTypeId = this.CodecTypeId;
          copy.MediaId = this.MediaId;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum iDashMediaInfoColumn : byte
        {
              DashMediaId = 0 ,     
              DashTypeId = 1 ,     
              DashContainerTypeId = 2 ,     
              CodecTypeId = 3 ,     
              MediaId = 4      
                    
        }        
    }                   
}