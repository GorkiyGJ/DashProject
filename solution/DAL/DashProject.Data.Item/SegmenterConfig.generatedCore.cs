using System;

namespace DashProject.Data.Item
{
    public abstract class SegmenterConfigBase : Manitou.Data.Item.Base.BaseItem
    {
        public SegmenterConfigBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int32 Id { get; set; } 
                
         public virtual System.Int32 MediaId { get; set; } 
                
         public virtual System.Boolean IsForceKeyFrames { get; set; } 
                
         public virtual System.Byte SegmentTime { get; set; } 
                
         public virtual System.Boolean ResetTimeStamps { get; set; } 
                
         public virtual System.Boolean IsUseSegmentTimeDelta { get; set; } 
                
         public virtual System.Single SegmentTimeDelta { get; set; } 
                
         public virtual System.Boolean IsUseFastStart { get; set; } 
                
         public virtual System.Int32 FastStartDurationS { get; set; } 
                
         public virtual System.Int32 DurationSLimit { get; set; } 
                
         public virtual System.Boolean UseDurationSLimit { get; set; } 
                
         public virtual System.Boolean IsDone { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        SegmenterConfig copy = new SegmenterConfig();
          copy.Id = this.Id;
          copy.MediaId = this.MediaId;
          copy.IsForceKeyFrames = this.IsForceKeyFrames;
          copy.SegmentTime = this.SegmentTime;
          copy.ResetTimeStamps = this.ResetTimeStamps;
          copy.IsUseSegmentTimeDelta = this.IsUseSegmentTimeDelta;
          copy.SegmentTimeDelta = this.SegmentTimeDelta;
          copy.IsUseFastStart = this.IsUseFastStart;
          copy.FastStartDurationS = this.FastStartDurationS;
          copy.DurationSLimit = this.DurationSLimit;
          copy.UseDurationSLimit = this.UseDurationSLimit;
          copy.IsDone = this.IsDone;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum SegmenterConfigColumn : byte
        {
              Id = 1 ,     
              MediaId = 2 ,     
              IsForceKeyFrames = 3 ,     
              SegmentTime = 4 ,     
              ResetTimeStamps = 5 ,     
              IsUseSegmentTimeDelta = 6 ,     
              SegmentTimeDelta = 7 ,     
              IsUseFastStart = 8 ,     
              FastStartDurationS = 9 ,     
              DurationSLimit = 10 ,     
              UseDurationSLimit = 11 ,     
              IsDone = 12      
                    
        }        
    }                   
}