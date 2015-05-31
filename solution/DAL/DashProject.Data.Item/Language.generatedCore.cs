using System;

namespace DashProject.Data.Item
{
    public abstract class LanguageBase : Manitou.Data.Item.Base.BaseItem
    {
        public LanguageBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int32 Id { get; set; } 
                
         public virtual System.String Code1 { get; set; } 
                
         public virtual System.String Code2 { get; set; } 
                
         public virtual System.String Code3 { get; set; } 
                
         public virtual System.String Name { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        Language copy = new Language();
          copy.Id = this.Id;
          copy.Code1 = this.Code1;
          copy.Code2 = this.Code2;
          copy.Code3 = this.Code3;
          copy.Name = this.Name;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum LanguageColumn : byte
        {
              Id = 1 ,     
              Code1 = 2 ,     
              Code2 = 3 ,     
              Code3 = 4 ,     
              Name = 5      
                    
        }        
    }                   
}