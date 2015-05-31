using System;

namespace DashProject.Data.Item
{
    public abstract class X264ProfileBase : Manitou.Data.Item.Base.BaseItem
    {
        public X264ProfileBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int32 Id { get; set; } 
                
         public virtual System.String Name { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        X264Profile copy = new X264Profile();
          copy.Id = this.Id;
          copy.Name = this.Name;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum X264ProfileColumn : byte
        {
              Id = 1 ,     
              Name = 2      
                    
        }        
    }                   
}