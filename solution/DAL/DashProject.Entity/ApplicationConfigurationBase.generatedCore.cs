using System;

namespace DashProject.Entity
{
    public class ApplicationConfigurationBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.ApplicationConfiguration, ApplicationConfigurationKey, ApplicationConfigurationOriginalKey>
    {
        public ApplicationConfigurationBase()
            : base()
        {
            _OriginalKey = new ApplicationConfigurationOriginalKey(DataItem);
            _Key = new ApplicationConfigurationKey(DataItem);
        }

        public ApplicationConfigurationBase(DashProject.Data.Item.ApplicationConfiguration item)
            : base(item)
        {
            _OriginalKey = new ApplicationConfigurationOriginalKey(item);
            _Key = new ApplicationConfigurationKey(item);
        }

        private ApplicationConfigurationKey _Key = null;
        public override ApplicationConfigurationKey Key
        {
            get
            {
                return _Key;
            }
        }

        private ApplicationConfigurationOriginalKey _OriginalKey = null;
        public override ApplicationConfigurationOriginalKey OriginalKey
        {
            get
            {
                return _OriginalKey;
            }
        }

        #region Properties
                public virtual System.Int32 Id
        {
            get { return DataItem.Id; }
            set
            {
                if (DataItem.Id == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.Id = value;
            }
        } 
        public virtual System.String ProjectName
        {
            get { return DataItem.ProjectName; }
            set
            {
                if (DataItem.ProjectName == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.ProjectName = value;
            }
        } 
        public virtual System.String StorageRootDirectoryPath
        {
            get { return DataItem.StorageRootDirectoryPath; }
            set
            {
                if (DataItem.StorageRootDirectoryPath == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.StorageRootDirectoryPath = value;
            }
        } 
        public virtual System.String ManifestFileName
        {
            get { return DataItem.ManifestFileName; }
            set
            {
                if (DataItem.ManifestFileName == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.ManifestFileName = value;
            }
        } 
        public virtual System.String InitMediaFileName
        {
            get { return DataItem.InitMediaFileName; }
            set
            {
                if (DataItem.InitMediaFileName == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.InitMediaFileName = value;
            }
        } 
        public virtual System.String MediaContentFolderName
        {
            get { return DataItem.MediaContentFolderName; }
            set
            {
                if (DataItem.MediaContentFolderName == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.MediaContentFolderName = value;
            }
        } 
        public virtual System.String MediaRawSegmentsFolderName
        {
            get { return DataItem.MediaRawSegmentsFolderName; }
            set
            {
                if (DataItem.MediaRawSegmentsFolderName == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.MediaRawSegmentsFolderName = value;
            }
        } 
        public virtual System.String MediaRawFolderName
        {
            get { return DataItem.MediaRawFolderName; }
            set
            {
                if (DataItem.MediaRawFolderName == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.MediaRawFolderName = value;
            }
        } 
        public virtual System.String DashMediaFolderName
        {
            get { return DataItem.DashMediaFolderName; }
            set
            {
                if (DataItem.DashMediaFolderName == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.DashMediaFolderName = value;
            }
        } 
        public virtual System.String ServiceName
        {
            get { return DataItem.ServiceName; }
            set
            {
                if (DataItem.ServiceName == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.ServiceName = value;
            }
        } 
        public virtual System.String DefaultDomain
        {
            get { return DataItem.DefaultDomain; }
            set
            {
                if (DataItem.DefaultDomain == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.DefaultDomain = value;
            }
        } 
        #endregion

        public override object Clone()
        {
            ApplicationConfigurationBase copy = new ApplicationConfigurationBase();
            
            copy.Id = this.Id;
              copy.OriginalKey.Id = this.OriginalKey.Id;
            
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

        public override void AcceptChanges()
        {
            EntityState = Manitou.Entity.Base.EntityState.Unchanged;

            _OriginalKey = new ApplicationConfigurationOriginalKey(DataItem);
        }
    }

    public class ApplicationConfigurationKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.ApplicationConfiguration>
    {
        public ApplicationConfigurationKey()
        {
        }

        public ApplicationConfigurationKey(DashProject.Data.Item.ApplicationConfiguration value)
            : base(value)
        {
        }

            
        public System.Int32 Id
        {
            get
            {
                return _item.Id;
            }
        }
        

        public override object Clone()
        {
                            
            object[] obj = new object[1];
            
            obj[0] = Id;        
                         
            return obj;
        }
    }

    public class ApplicationConfigurationOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.ApplicationConfiguration>
    {
        public ApplicationConfigurationOriginalKey()
        {
        }

        public ApplicationConfigurationOriginalKey(DashProject.Data.Item.ApplicationConfiguration value)
            : base(value)
        {
        }

         
        private System.Int32 _Id;   
        public System.Int32 Id
        {
            get
            {
                return _Id;
            }
            
            internal set { _Id = value; }
        }
 

        public override object Clone()
        {
            ApplicationConfigurationOriginalKey obj = new ApplicationConfigurationOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.ApplicationConfiguration value)
        {
            
            _Id = value.Id;        
         
        }
    }
}