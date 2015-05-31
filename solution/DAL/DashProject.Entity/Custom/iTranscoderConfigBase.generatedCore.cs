using System;

namespace DashProject.Entity.Custom
{
    public class iTranscoderConfigBase : Manitou.Entity.Base.BaseEntityReadOnly<DashProject.Data.Item.Custom.iTranscoderConfig>
    {
        public iTranscoderConfigBase()
            : base()
        {
        }

        public iTranscoderConfigBase(DashProject.Data.Item.Custom.iTranscoderConfig item)
            : base(item)
        {
        }

        #region Properties
                public virtual System.Int32? DashMediaCodecId
        {
            get { return DataItem.DashMediaCodecId; }
            set
            {
                DataItem.DashMediaCodecId = value;
            }
        } 
        public virtual System.Int32? RawMediaCodecId
        {
            get { return DataItem.RawMediaCodecId; }
            set
            {
                DataItem.RawMediaCodecId = value;
            }
        } 
        public virtual System.Byte? StreamIndex
        {
            get { return DataItem.StreamIndex; }
            set
            {
                DataItem.StreamIndex = value;
            }
        } 
        public virtual System.Int32? StreamTypeId
        {
            get { return DataItem.StreamTypeId; }
            set
            {
                DataItem.StreamTypeId = value;
            }
        } 
        public virtual System.Int32? InputContainerId
        {
            get { return DataItem.InputContainerId; }
            set
            {
                DataItem.InputContainerId = value;
            }
        } 
        public virtual System.Int32? OutputContainerId
        {
            get { return DataItem.OutputContainerId; }
            set
            {
                DataItem.OutputContainerId = value;
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
        public virtual System.Int32? FragmentDurationS
        {
            get { return DataItem.FragmentDurationS; }
            set
            {
                DataItem.FragmentDurationS = value;
            }
        } 
        #endregion

        public virtual object Clone()
        {
            iTranscoderConfigBase copy = new iTranscoderConfigBase();
            
            copy.DashMediaCodecId = this.DashMediaCodecId;
            
            copy.RawMediaCodecId = this.RawMediaCodecId;
            
            copy.StreamIndex = this.StreamIndex;
            
            copy.StreamTypeId = this.StreamTypeId;
            
            copy.InputContainerId = this.InputContainerId;
            
            copy.OutputContainerId = this.OutputContainerId;
            
            copy.ProgramIndex = this.ProgramIndex;
            
            copy.FragmentDurationS = this.FragmentDurationS;
             
            return copy;
        }
    }
}