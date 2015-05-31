using System;

namespace DashProject.Data.Item
{
    public abstract class CoderTypeBase : Manitou.Data.Item.Base.BaseItem
    {
        public CoderTypeBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int32 Id { get; set; } 
                
         public virtual System.String Name { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        CoderType copy = new CoderType();
          copy.Id = this.Id;
          copy.Name = this.Name;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum CoderTypeColumn : byte
        {
              Id = 1 ,     
              Name = 2      
                    
        }        
    }                   
}