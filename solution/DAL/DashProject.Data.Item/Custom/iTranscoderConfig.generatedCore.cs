using System;

namespace DashProject.Data.Item.Custom
{
    public abstract class iTranscoderConfigBase : Manitou.Data.Item.Base.BaseItem
    {
        public iTranscoderConfigBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int32? DashMediaCodecId { get; set; } 
                
         public virtual System.Int32? RawMediaCodecId { get; set; } 
                
         public virtual System.Byte? StreamIndex { get; set; } 
                
         public virtual System.Int32? StreamTypeId { get; set; } 
                
         public virtual System.Int32? InputContainerId { get; set; } 
                
         public virtual System.Int32? OutputContainerId { get; set; } 
                
         public virtual System.Byte? ProgramIndex { get; set; } 
                
         public virtual System.Int32? FragmentDurationS { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        iTranscoderConfig copy = new iTranscoderConfig();
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

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum iTranscoderConfigColumn : byte
        {
              DashMediaCodecId = 0 ,     
              RawMediaCodecId = 1 ,     
              StreamIndex = 2 ,     
              StreamTypeId = 3 ,     
              InputContainerId = 4 ,     
              OutputContainerId = 5 ,     
              ProgramIndex = 6 ,     
              FragmentDurationS = 7      
                    
        }        
    }                   
}