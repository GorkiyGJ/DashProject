using System;

namespace DashProject.Data.Item
{
    public abstract class DashTypeBase : Manitou.Data.Item.Base.BaseItem
    {
        public DashTypeBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int32 Id { get; set; } 
                
         public virtual System.String Name { get; set; } 
                
         public virtual System.Int32 ContainerTypeId { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        DashType copy = new DashType();
          copy.Id = this.Id;
          copy.Name = this.Name;
          copy.ContainerTypeId = this.ContainerTypeId;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum DashTypeColumn : byte
        {
              Id = 1 ,     
              Name = 2 ,     
              ContainerTypeId = 3      
                    
        }        
    }                   
}