using System;

namespace DashProject.Web.DataSourceView
{
    public class ApplicationConfigurationDataSourceViewBase : Winnetou.WebControls.DataSources.extObjectDataSourceView
    {
        public ApplicationConfigurationDataSourceViewBase(DashProject.Web.DataSource.ApplicationConfigurationDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
        
        protected override int ExecuteUpdate(System.Collections.IDictionary keys, System.Collections.IDictionary values, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.ApplicationConfiguration entity = GetEntityByKeys(keys);

            if (values.Contains("ProjectName"))
                entity.ProjectName = values["ProjectName"].ToString();

            if (values.Contains("StorageRootDirectoryPath"))
                entity.StorageRootDirectoryPath = values["StorageRootDirectoryPath"].ToString();

            if (values.Contains("ManifestFileName"))
                entity.ManifestFileName = values["ManifestFileName"].ToString();

            if (values.Contains("InitMediaFileName"))
                entity.InitMediaFileName = values["InitMediaFileName"].ToString();

            if (values.Contains("MediaContentFolderName"))
                entity.MediaContentFolderName = values["MediaContentFolderName"].ToString();

            if (values.Contains("MediaRawSegmentsFolderName"))
                entity.MediaRawSegmentsFolderName = values["MediaRawSegmentsFolderName"].ToString();

            if (values.Contains("MediaRawFolderName"))
                entity.MediaRawFolderName = values["MediaRawFolderName"].ToString();

            if (values.Contains("DashMediaFolderName"))
                entity.DashMediaFolderName = values["DashMediaFolderName"].ToString();

            if (values.Contains("ServiceName"))
                entity.ServiceName = values["ServiceName"].ToString();

            if (values.Contains("DefaultDomain"))
                entity.DefaultDomain = values["DefaultDomain"].ToString();

            if (DashProject.Repository.Factory.ApplicationConfiguration.Update(entity))
                return 1;
            else
                return 0;
        }

        protected override int ExecuteDelete(System.Collections.IDictionary keys, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.ApplicationConfiguration entity = GetEntityByKeys(keys);
            if (DashProject.Repository.Factory.ApplicationConfiguration.Delete(entity))
                return 1;
            else
                return 0;
        }

        protected DashProject.Entity.ApplicationConfiguration GetEntityByKeys(System.Collections.IDictionary keys)
        {
            DashProject.Entity.ApplicationConfiguration entity;
            if (!keys.Contains("Id"))
                throw new System.Collections.Generic.KeyNotFoundException("Key not found.");

            System.Int32 _Id = System.Int32.Parse(keys["Id"].ToString());

            entity = DashProject.Repository.Factory.ApplicationConfiguration.GetById(_Id);
            if (entity == null)
                throw new System.Data.RowNotInTableException("Object does not exists.");

            return entity;
        }
    }
}