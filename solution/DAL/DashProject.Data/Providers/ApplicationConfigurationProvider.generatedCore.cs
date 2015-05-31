using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class ApplicationConfigurationProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.ApplicationConfiguration>
    {
        public static List<DashProject.Data.Item.ApplicationConfiguration> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.ApplicationConfiguration> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.ApplicationConfiguration>();
            
                DashProject.Data.Item.ApplicationConfiguration row = new DashProject.Data.Item.ApplicationConfiguration();

                row.Id = (System.Int32)dr[((byte)ApplicationConfigurationBase.ApplicationConfigurationColumn.Id - 1)];
                row.ProjectName = (System.String)dr[((byte)ApplicationConfigurationBase.ApplicationConfigurationColumn.ProjectName - 1)];
                row.StorageRootDirectoryPath = (System.String)dr[((byte)ApplicationConfigurationBase.ApplicationConfigurationColumn.StorageRootDirectoryPath - 1)];
                row.ManifestFileName = (System.String)dr[((byte)ApplicationConfigurationBase.ApplicationConfigurationColumn.ManifestFileName - 1)];
                row.InitMediaFileName = (System.String)dr[((byte)ApplicationConfigurationBase.ApplicationConfigurationColumn.InitMediaFileName - 1)];
                row.MediaContentFolderName = (System.String)dr[((byte)ApplicationConfigurationBase.ApplicationConfigurationColumn.MediaContentFolderName - 1)];
                row.MediaRawSegmentsFolderName = (System.String)dr[((byte)ApplicationConfigurationBase.ApplicationConfigurationColumn.MediaRawSegmentsFolderName - 1)];
                row.MediaRawFolderName = (System.String)dr[((byte)ApplicationConfigurationBase.ApplicationConfigurationColumn.MediaRawFolderName - 1)];
                row.DashMediaFolderName = (System.String)dr[((byte)ApplicationConfigurationBase.ApplicationConfigurationColumn.DashMediaFolderName - 1)];
                row.ServiceName = (System.String)dr[((byte)ApplicationConfigurationBase.ApplicationConfigurationColumn.ServiceName - 1)];
                row.DefaultDomain = (System.String)dr[((byte)ApplicationConfigurationBase.ApplicationConfigurationColumn.DefaultDomain - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.ApplicationConfiguration FillItem(IDataReader dr)
        {
            DashProject.Data.Item.ApplicationConfiguration row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.ApplicationConfiguration();
                row.Id = (System.Int32)dr[((byte)ApplicationConfigurationBase.ApplicationConfigurationColumn.Id - 1)];
                row.ProjectName = (System.String)dr[((byte)ApplicationConfigurationBase.ApplicationConfigurationColumn.ProjectName - 1)];
                row.StorageRootDirectoryPath = (System.String)dr[((byte)ApplicationConfigurationBase.ApplicationConfigurationColumn.StorageRootDirectoryPath - 1)];
                row.ManifestFileName = (System.String)dr[((byte)ApplicationConfigurationBase.ApplicationConfigurationColumn.ManifestFileName - 1)];
                row.InitMediaFileName = (System.String)dr[((byte)ApplicationConfigurationBase.ApplicationConfigurationColumn.InitMediaFileName - 1)];
                row.MediaContentFolderName = (System.String)dr[((byte)ApplicationConfigurationBase.ApplicationConfigurationColumn.MediaContentFolderName - 1)];
                row.MediaRawSegmentsFolderName = (System.String)dr[((byte)ApplicationConfigurationBase.ApplicationConfigurationColumn.MediaRawSegmentsFolderName - 1)];
                row.MediaRawFolderName = (System.String)dr[((byte)ApplicationConfigurationBase.ApplicationConfigurationColumn.MediaRawFolderName - 1)];
                row.DashMediaFolderName = (System.String)dr[((byte)ApplicationConfigurationBase.ApplicationConfigurationColumn.DashMediaFolderName - 1)];
                row.ServiceName = (System.String)dr[((byte)ApplicationConfigurationBase.ApplicationConfigurationColumn.ServiceName - 1)];
                row.DefaultDomain = (System.String)dr[((byte)ApplicationConfigurationBase.ApplicationConfigurationColumn.DefaultDomain - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.ApplicationConfiguration item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.ApplicationConfiguration item );        
        

   

     
        public virtual DashProject.Data.Item.ApplicationConfiguration GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.ApplicationConfiguration GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

 
    
    }                       
}