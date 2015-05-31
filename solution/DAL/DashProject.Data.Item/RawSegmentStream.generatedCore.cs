using System;

namespace DashProject.Data.Item
{
    public abstract class RawSegmentStreamBase : Manitou.Data.Item.Base.BaseItem
    {
        public RawSegmentStreamBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int64 Id { get; set; } 
                
         public virtual System.Int64 SegmentId { get; set; } 
                
         public virtual System.Int32 MediaId { get; set; } 
                
         public virtual System.Int32 StreamId { get; set; } 
                
         public virtual System.String FileName { get; set; } 
                
         public virtual System.Decimal DurationS { get; set; } 
                
         public virtual System.Decimal GlobalStartTimeS { get; set; } 
                
         public virtual System.Decimal GlobalEndTimeS { get; set; } 
                
         public virtual System.DateTime DateTimeCreated { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        RawSegmentStream copy = new RawSegmentStream();
          copy.Id = this.Id;
          copy.SegmentId = this.SegmentId;
          copy.MediaId = this.MediaId;
          copy.StreamId = this.StreamId;
          copy.FileName = this.FileName;
          copy.DurationS = this.DurationS;
          copy.GlobalStartTimeS = this.GlobalStartTimeS;
          copy.GlobalEndTimeS = this.GlobalEndTimeS;
          copy.DateTimeCreated = this.DateTimeCreated;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum RawSegmentStreamColumn : byte
        {
              Id = 1 ,     
              SegmentId = 2 ,     
              MediaId = 3 ,     
              StreamId = 4 ,     
              FileName = 5 ,     
              DurationS = 6 ,     
              GlobalStartTimeS = 7 ,     
              GlobalEndTimeS = 8 ,     
              DateTimeCreated = 9      
                    
        }        
    }                   
}