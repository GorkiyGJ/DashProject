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
                
         public virtual System.Int32 TimeScale { get; set; } 
                
         public virtual System.Int64 DecodeTimeTS { get; set; } 
                
         public virtual System.Int32 DurationTS { get; set; } 
                
         public virtual System.Decimal DurationS { get; set; } 
                
         public virtual System.DateTime DateTimeCreated { get; set; } 
                
         public virtual System.Decimal GlobalStartTimeS { get; set; } 
                
         public virtual System.Decimal GlobalEndTimeS { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        DashMediaSegment copy = new DashMediaSegment();
          copy.Id = this.Id;
          copy.DashMediaId = this.DashMediaId;
          copy.TimeScale = this.TimeScale;
          copy.DecodeTimeTS = this.DecodeTimeTS;
          copy.DurationTS = this.DurationTS;
          copy.DurationS = this.DurationS;
          copy.DateTimeCreated = this.DateTimeCreated;
          copy.GlobalStartTimeS = this.GlobalStartTimeS;
          copy.GlobalEndTimeS = this.GlobalEndTimeS;
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
              TimeScale = 3 ,     
              DecodeTimeTS = 4 ,     
              DurationTS = 5 ,     
              DurationS = 6 ,     
              DateTimeCreated = 7 ,     
              GlobalStartTimeS = 8 ,     
              GlobalEndTimeS = 9      
                    
        }        
    }                   
}