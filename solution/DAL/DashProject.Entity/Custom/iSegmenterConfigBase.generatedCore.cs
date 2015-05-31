using System;

namespace DashProject.Entity.Custom
{
    public class iSegmenterConfigBase : Manitou.Entity.Base.BaseEntityReadOnly<DashProject.Data.Item.Custom.iSegmenterConfig>
    {
        public iSegmenterConfigBase()
            : base()
        {
        }

        public iSegmenterConfigBase(DashProject.Data.Item.Custom.iSegmenterConfig item)
            : base(item)
        {
        }

        #region Properties
                public virtual System.String InputMedia
        {
            get { return DataItem.InputMedia; }
            set
            {
                DataItem.InputMedia = value;
            }
        } 
        public virtual System.Byte? ProgramIndex
        {
            get { return DataItem.ProgramIndex; }
            set
            {
                DataItem.ProgramIndex = value;
            }
        } 
        public virtual System.Boolean? IsForceKeyFrames
        {
            get { return DataItem.IsForceKeyFrames; }
            set
            {
                DataItem.IsForceKeyFrames = value;
            }
        } 
        public virtual System.Byte? SegmentTime
        {
            get { return DataItem.SegmentTime; }
            set
            {
                DataItem.SegmentTime = value;
            }
        } 
        public virtual System.Boolean? ResetTimeStamps
        {
            get { return DataItem.ResetTimeStamps; }
            set
            {
                DataItem.ResetTimeStamps = value;
            }
        } 
        public virtual System.Boolean? IsUseSegmentTimeDelta
        {
            get { return DataItem.IsUseSegmentTimeDelta; }
            set
            {
                DataItem.IsUseSegmentTimeDelta = value;
            }
        } 
        public virtual System.Single? SegmentTimeDelta
        {
            get { return DataItem.SegmentTimeDelta; }
            set
            {
                DataItem.SegmentTimeDelta = value;
            }
        } 
        public virtual System.Int64? StartNumber
        {
            get { return DataItem.StartNumber; }
            set
            {
                DataItem.StartNumber = value;
            }
        } 
        public virtual System.Int32? RawMediaContainerTypeId
        {
            get { return DataItem.RawMediaContainerTypeId; }
            set
            {
                DataItem.RawMediaContainerTypeId = value;
            }
        } 
        #endregion

        public virtual object Clone()
        {
            iSegmenterConfigBase copy = new iSegmenterConfigBase();
            
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
    }
}