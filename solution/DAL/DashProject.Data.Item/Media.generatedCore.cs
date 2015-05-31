using System;

namespace DashProject.Data.Item
{
    public abstract class MediaBase : Manitou.Data.Item.Base.BaseItem
    {
        public MediaBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int32 Id { get; set; } 
                
         public virtual System.Int32 RawMediaId { get; set; } 
                
         public virtual System.Byte? ProgramIndex { get; set; } 
                
         public virtual System.String Name { get; set; } 
                
         public virtual System.Boolean IsActive { get; set; } 
                
         public virtual System.DateTime DateTimeCreated { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        Media copy = new Media();
          copy.Id = this.Id;
          copy.RawMediaId = this.RawMediaId;
          copy.ProgramIndex = this.ProgramIndex;
          copy.Name = this.Name;
          copy.IsActive = this.IsActive;
          copy.DateTimeCreated = this.DateTimeCreated;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum MediaColumn : byte
        {
              Id = 1 ,     
              RawMediaId = 2 ,     
              ProgramIndex = 3 ,     
              Name = 4 ,     
              IsActive = 5 ,     
              DateTimeCreated = 6      
                    
        }        
    }                   
}