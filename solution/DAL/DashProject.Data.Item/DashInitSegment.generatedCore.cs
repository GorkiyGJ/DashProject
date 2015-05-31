using System;

namespace DashProject.Data.Item
{
    public abstract class DashInitSegmentBase : Manitou.Data.Item.Base.BaseItem
    {
        public DashInitSegmentBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int32 Id { get; set; } 
                
         public virtual System.Int32 ContainerFormatId { get; set; } 
                
         public virtual System.String FileName { get; set; } 
                
         public virtual System.DateTime DateTimeCreated { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        DashInitSegment copy = new DashInitSegment();
          copy.Id = this.Id;
          copy.ContainerFormatId = this.ContainerFormatId;
          copy.FileName = this.FileName;
          copy.DateTimeCreated = this.DateTimeCreated;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum DashInitSegmentColumn : byte
        {
              Id = 1 ,     
              ContainerFormatId = 2 ,     
              FileName = 3 ,     
              DateTimeCreated = 4      
                    
        }        
    }                   
}