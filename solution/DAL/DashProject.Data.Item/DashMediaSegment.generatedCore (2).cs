using System;

namespace DashProject.Data.Item
{
    public abstract class DashMediaSegmentBase : Manitou.Data.Item.Base.BaseItem
    {
        public DashMediaSegmentBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int32 Id { get; set; } 
                
         public virtual System.Int32 DashMediaId { get; set; } 
                
         public virtual System.Int32 ContainerFormatId { get; set; } 
                
         public virtual System.Int32 TimeScale { get; set; } 
                
         public virtual System.Int64 DecodeTimeTS { get; set; } 
                
         public virtual System.Int32 DurationTS { get; set; } 
                
         public virtual System.Decimal DurationS { get; set; } 
                
         public virtual System.DateTime DateTimeCreated { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        DashMediaSegment copy = new DashMediaSegment();
          copy.Id = this.Id;
          copy.DashMediaId = this.DashMediaId;
          copy.ContainerFormatId = this.ContainerFormatId;
          copy.TimeScale = this.TimeScale;
          copy.DecodeTimeTS = this.DecodeTimeTS;
          copy.DurationTS = this.DurationTS;
          copy.DurationS = this.DurationS;
          copy.DateTimeCreated = this.DateTimeCreated;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum DashMediaSegmentColumn : byte
        {
              Id = 1 ,     
              DashMediaId = 2 ,     
              ContainerFormatId = 3 ,     
              TimeScale = 4 ,     
              DecodeTimeTS = 5 ,     
              DurationTS = 6 ,     
              DurationS = 7 ,     
              DateTimeCreated = 8      
                    
        }        
    }                   
}