using System;

namespace DashProject.Data.Item
{
    public abstract class StreamBase : Manitou.Data.Item.Base.BaseItem
    {
        public StreamBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int32 Id { get; set; } 
                
         public virtual System.Int32 RawMediaId { get; set; } 
                
         public virtual System.Int32 StreamTypeId { get; set; } 
                
         public virtual System.Byte Index { get; set; } 
                
         public virtual System.Int32 CodecTypeId { get; set; } 
                
         public virtual System.Byte? Channels { get; set; } 
                
         public virtual System.Int32? LanguageId { get; set; } 
                
         public virtual System.Int16? Width { get; set; } 
                
         public virtual System.Int16? Height { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        Stream copy = new Stream();
          copy.Id = this.Id;
          copy.RawMediaId = this.RawMediaId;
          copy.StreamTypeId = this.StreamTypeId;
          copy.Index = this.Index;
          copy.CodecTypeId = this.CodecTypeId;
          copy.Channels = this.Channels;
          copy.LanguageId = this.LanguageId;
          copy.Width = this.Width;
          copy.Height = this.Height;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum StreamColumn : byte
        {
              Id = 1 ,     
              RawMediaId = 2 ,     
              StreamTypeId = 3 ,     
              Index = 4 ,     
              CodecTypeId = 5 ,     
              Channels = 6 ,     
              LanguageId = 7 ,     
              Width = 8 ,     
              Height = 9      
                    
        }        
    }                   
}