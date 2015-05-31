using System;

namespace DashProject.Data.Item.Custom
{
    public abstract class iSegmenterConfigBase : Manitou.Data.Item.Base.BaseItem
    {
        public iSegmenterConfigBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.String InputMedia { get; set; } 
                
         public virtual System.Byte? ProgramIndex { get; set; } 
                
         public virtual System.Boolean? IsForceKeyFrames { get; set; } 
                
         public virtual System.Byte? SegmentTime { get; set; } 
                
         public virtual System.Boolean? ResetTimeStamps { get; set; } 
                
         public virtual System.Boolean? IsUseSegmentTimeDelta { get; set; } 
                
         public virtual System.Single? SegmentTimeDelta { get; set; } 
                
         public virtual System.Int64? StartNumber { get; set; } 
                
         public virtual System.Int32? RawMediaContainerTypeId { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        iSegmenterConfig copy = new iSegmenterConfig();
          copy.InputMedia = this.InputMedia;
          copy.ProgramIndex = this.ProgramIndex;
          copy.IsForceKeyFrames = this.IsForceKeyFrames;
          copy.SegmentTime = this.SegmentTime;
          copy.ResetTimeStamps = this.ResetTimeStamps;
          copy.IsUseSegmentTimeDelta = this.IsUseSegmentTimeDelta;
          copy.SegmentTimeDelta = this.SegmentTimeDelta;
          copy.StartNumber = this.StartNumber;
          copy.RawMediaContainerTypeId = this.RawMediaContainerTypeId;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum iSegmenterConfigColumn : byte
        {
              InputMedia = 0 ,     
              ProgramIndex = 1 ,     
              IsForceKeyFrames = 2 ,     
              SegmentTime = 3 ,     
              ResetTimeStamps = 4 ,     
              IsUseSegmentTimeDelta = 5 ,     
              SegmentTimeDelta = 6 ,     
              StartNumber = 7 ,     
              RawMediaContainerTypeId = 8      
                    
        }        
    }                   
}