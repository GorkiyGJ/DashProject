using System;

namespace DashProject.Data.Item
{
    public abstract class RawMediaSourceTypeBase : Manitou.Data.Item.Base.BaseItem
    {
        public RawMediaSourceTypeBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Byte Id { get; set; } 
                
         public virtual System.String Name { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        RawMediaSourceType copy = new RawMediaSourceType();
          copy.Id = this.Id;
          copy.Name = this.Name;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum RawMediaSourceTypeColumn : byte
        {
              Id = 1 ,     
              Name = 2      
                    
        }        
    }                   
}