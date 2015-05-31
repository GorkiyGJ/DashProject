using System;

namespace DashProject.Entity.ReadOnly
{
    public class ApplicationConfigurationReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.ApplicationConfiguration>
    {
        public ApplicationConfigurationReadOnlyBase()
            : base()
        {
        }

        public ApplicationConfigurationReadOnlyBase(DashProject.Data.Item.ApplicationConfiguration item)
            : base(item)
        {
        }

        #region Properties
                public virtual System.Int32 Id
        {
            get { return DataItem.Id; }
        }
        public virtual System.String ProjectName
        {
            get { return DataItem.ProjectName; }
        }
        public virtual System.String StorageRootDirectoryPath
        {
            get { return DataItem.StorageRootDirectoryPath; }
        }
        public virtual System.String ManifestFileName
        {
            get { return DataItem.ManifestFileName; }
        }
        public virtual System.String InitMediaFileName
        {
            get { return DataItem.InitMediaFileName; }
        }
        public virtual System.String MediaContentFolderName
        {
            get { return DataItem.MediaContentFolderName; }
        }
        public virtual System.String MediaRawSegmentsFolderName
        {
            get { return DataItem.MediaRawSegmentsFolderName; }
        }
        public virtual System.String MediaRawFolderName
        {
            get { return DataItem.MediaRawFolderName; }
        }
        public virtual System.String DashMediaFolderName
        {
            get { return DataItem.DashMediaFolderName; }
        }
        public virtual System.String ServiceName
        {
            get { return DataItem.ServiceName; }
        }
        public virtual System.String DefaultDomain
        {
            get { return DataItem.DefaultDomain; }
        }
        
        #endregion
    }
}