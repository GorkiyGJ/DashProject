using System;

namespace DashProject.Data.Item
{
    public abstract class VideoSizeBase : Manitou.Data.Item.Base.BaseItem
    {
        public VideoSizeBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int32 Id { get; set; } 
                
         public virtual System.String Name { get; set; } 
                
         public virtual System.Int16 Width { get; set; } 
                
         public virtual System.Int16 Height { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        VideoSize copy = new VideoSize();
          copy.Id = this.Id;
          copy.Name = this.Name;
          copy.Width = this.Width;
          copy.Height = this.Height;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum VideoSizeColumn : byte
        {
              Id = 1 ,     
              Name = 2 ,     
              Width = 3 ,     
              Height = 4      
                    
        }        
    }                   
}