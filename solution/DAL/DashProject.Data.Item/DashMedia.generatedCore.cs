using System;

namespace DashProject.Data.Item
{
    public abstract class DashMediaBase : Manitou.Data.Item.Base.BaseItem
    {
        public DashMediaBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int32 Id { get; set; } 
                
         public virtual System.Int32 MediaId { get; set; } 
                
         public virtual System.Int32 StreamId { get; set; } 
                
         public virtual System.Int32? DashInitSegmentId { get; set; } 
                
         public virtual System.Int32 DashTypeId { get; set; } 
                
         public virtual System.Int32 CodecTypeId { get; set; } 
                
         public virtual System.Int16? Width { get; set; } 
                
         public virtual System.Int16? Height { get; set; } 
                
         public virtual System.Byte? Channels { get; set; } 
                
         public virtual System.Int32 BitrateKbps { get; set; } 
                
         public virtual System.Boolean IsActive { get; set; } 
                
         public virtual System.Int32 FragmentDurationS { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        DashMedia copy = new DashMedia();
          copy.Id = this.Id;
          copy.MediaId = this.MediaId;
          copy.StreamId = this.StreamId;
          copy.DashInitSegmentId = this.DashInitSegmentId;
          copy.DashTypeId = this.DashTypeId;
          copy.CodecTypeId = this.CodecTypeId;
          copy.Width = this.Width;
          copy.Height = this.Height;
          copy.Channels = this.Channels;
          copy.BitrateKbps = this.BitrateKbps;
          copy.IsActive = this.IsActive;
          copy.FragmentDurationS = this.FragmentDurationS;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum DashMediaColumn : byte
        {
              Id = 1 ,     
              MediaId = 2 ,     
              StreamId = 3 ,     
              DashInitSegmentId = 4 ,     
              DashTypeId = 5 ,     
              CodecTypeId = 6 ,     
              Width = 7 ,     
              Height = 8 ,     
              Channels = 9 ,     
              BitrateKbps = 10 ,     
              IsActive = 11 ,     
              FragmentDurationS = 12      
                    
        }        
    }                   
}