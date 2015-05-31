using System;

namespace DashProject.Data.Item
{
    public abstract class X264ProfileLevelBase : Manitou.Data.Item.Base.BaseItem
    {
        public X264ProfileLevelBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int32 Id { get; set; } 
                
         public virtual System.String Name { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        X264ProfileLevel copy = new X264ProfileLevel();
          copy.Id = this.Id;
          copy.Name = this.Name;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum X264ProfileLevelColumn : byte
        {
              Id = 1 ,     
              Name = 2      
                    
        }        
    }                   
}