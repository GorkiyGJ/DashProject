using System;

namespace DashProject.Data.Item
{
    public abstract class ApplicationConfigurationBase : Manitou.Data.Item.Base.BaseItem
    {
        public ApplicationConfigurationBase()
            :base()
        {         
        }
        
        #region Properties
         public virtual System.Int32 Id { get; set; } 
                
         public virtual System.String ProjectName { get; set; } 
                
         public virtual System.String StorageRootDirectoryPath { get; set; } 
                
         public virtual System.String ManifestFileName { get; set; } 
                
         public virtual System.String InitMediaFileName { get; set; } 
                
         public virtual System.String MediaContentFolderName { get; set; } 
                
         public virtual System.String MediaRawSegmentsFolderName { get; set; } 
                
         public virtual System.String MediaRawFolderName { get; set; } 
                
         public virtual System.String DashMediaFolderName { get; set; } 
                
         public virtual System.String ServiceName { get; set; } 
                
         public virtual System.String DefaultDomain { get; set; } 
                
                #endregion
        
        public override object Clone()
        {
        ApplicationConfiguration copy = new ApplicationConfiguration();
          copy.Id = this.Id;
          copy.ProjectName = this.ProjectName;
          copy.StorageRootDirectoryPath = this.StorageRootDirectoryPath;
          copy.ManifestFileName = this.ManifestFileName;
          copy.InitMediaFileName = this.InitMediaFileName;
          copy.MediaContentFolderName = this.MediaContentFolderName;
          copy.MediaRawSegmentsFolderName = this.MediaRawSegmentsFolderName;
          copy.MediaRawFolderName = this.MediaRawFolderName;
          copy.DashMediaFolderName = this.DashMediaFolderName;
          copy.ServiceName = this.ServiceName;
          copy.DefaultDomain = this.DefaultDomain;
                    return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        
        [Serializable]
        public enum ApplicationConfigurationColumn : byte
        {
              Id = 1 ,     
              ProjectName = 2 ,     
              StorageRootDirectoryPath = 3 ,     
              ManifestFileName = 4 ,     
              InitMediaFileName = 5 ,     
              MediaContentFolderName = 6 ,     
              MediaRawSegmentsFolderName = 7 ,     
              MediaRawFolderName = 8 ,     
              DashMediaFolderName = 9 ,     
              ServiceName = 10 ,     
              DefaultDomain = 11      
                    
        }        
    }                   
}