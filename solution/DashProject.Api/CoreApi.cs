using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using DashProject.Entity;
using DashProject.Repository;
using Microsoft.Win32;
using System.Configuration;
using DashProject.Entity.Custom;
using DashProject.Api.Extension;


namespace DashProject.Api
{
    public static class CoreApi
    {
        public static class AppEventLog
        {
            public static readonly string sLog = CoreApi.AppConf.ProjectName;

            public static void WriteEntry(string message, string eventSource, EventLogEntryType type)
            {
                if (!EventLog.SourceExists(eventSource))
                    EventLog.CreateEventSource(eventSource, sLog);
                EventLog.WriteEntry(eventSource, message, type);
            }
        }

        public static class AppConf
        {
            private static ApplicationConfiguration _applicationConfiguration
            {
                get
                {
                    ApplicationConfiguration appConf;
                    List<ApplicationConfiguration> appConfList = Factory.ApplicationConfiguration.GetList();
                    if (appConfList == null)
                    {
                        appConf = new ApplicationConfiguration();
                        appConf.ProjectName = "DashProject";
                        appConf.StorageRootDirectoryPath = Directory.GetDirectoryRoot(Directory.GetCurrentDirectory()) + appConf.ProjectName;
                        appConf.ManifestFileName = "manifest.mpd";
                        appConf.InitMediaFileName = "init";
                        appConf.MediaContentFolderName = "MediaContent";
                        //appConf.MediaProductionFolderName = "production";
                        //appConf.MediaFragmentsFolderName = "fragments";
                        appConf.DashMediaFolderName = "dash";
                        appConf.MediaRawSegmentsFolderName = "raw_segments";
                        appConf.MediaRawFolderName = "raw";
                        appConf.ServiceName = "Service";
                        //appConf.SegmenterServiceName = "Segmenter";
                        //appConf.FragmenterServiceName = "Fragmenter";
                        /////// appConf.ServiceName = "service";
                        /////////appConf.DefaultDomain = "localhost";

                        Factory.ApplicationConfiguration.Save(appConf);
                    }
                    else
                        appConf = appConfList[0];

                    return appConf;
                }
                set
                {
                    Factory.ApplicationConfiguration.Update(value);
                }
            }

            /*public static string DefaultDomain
            {
                get
                {
                    return _applicationConfiguration.SegmenterServiceName;
                }
                set
                {
                    _applicationConfiguration.DefaultDomain = value;
                    _applicationConfiguration = _applicationConfiguration;
                }
            }*/

            public static string ServiceDomain
            {
                get
                {
                    return _applicationConfiguration.ServiceName.ToLower() + "." + _applicationConfiguration.DefaultDomain;
                }
            }

            public static string ServiceDomainUrl
            {
                get
                {
                    return "http://" + ServiceDomain;
                }
            }

            public static string ServiceName
            {
                get
                {
                    return _applicationConfiguration.ServiceName;
                }
                set
                {
                    _applicationConfiguration.ServiceName = value;
                    _applicationConfiguration = _applicationConfiguration;
                }
            }

            public static string ServiceFullName
            {
                get
                {
                    return ProjectName + "." + ServiceName;
                }
            }

            /*public static string SegmenterServiceName
            {
                get
                {
                    return _applicationConfiguration.SegmenterServiceName;
                }
                set
                {
                    _applicationConfiguration.SegmenterServiceName = value;
                    _applicationConfiguration = _applicationConfiguration;
                }
            }

            public static string SegmenterServiceFullName
            {
                get
                {
                    return ProjectName + "." + SegmenterServiceName;
                }
            }

            public static string FragmenterServiceName
            {
                get
                {
                    return _applicationConfiguration.FragmenterServiceName;
                }
                set
                {
                    _applicationConfiguration.FragmenterServiceName = value;
                    _applicationConfiguration = _applicationConfiguration;
                }
            }

            public static string FragmenterServiceFullName
            {
                get
                {
                    return ProjectName + "." + FragmenterServiceName;
                }
            }*/

            /* public static string SegmentFileWatcherServiceName
             {
                 get
                 {
                     return _applicationConfiguration.SegmentFileWatcherServiceName;
                 }
                 set
                 {
                     _applicationConfiguration.SegmentFileWatcherServiceName = value;
                     _applicationConfiguration = _applicationConfiguration;
                 }
             }

             public static string SegmentFileWatcherServiceFullName
             {
                 get
                 {
                     return ProjectName + "." + SegmentFileWatcherServiceName;
                 }
             }*/

            public static string ProjectName
            {
                get
                {
                    return _applicationConfiguration.ProjectName;
                }
                set
                {
                    _applicationConfiguration.ProjectName = value;
                    _applicationConfiguration = _applicationConfiguration;
                }
            }

            public static string ManifestFileName
            {
                get
                {
                    return _applicationConfiguration.ManifestFileName;
                }
                set
                {
                    _applicationConfiguration.ManifestFileName = value;
                    _applicationConfiguration = _applicationConfiguration;
                }
            }

            public static string InitMediaFileName
            {
                get
                {
                    return _applicationConfiguration.InitMediaFileName;
                }
                set
                {
                    _applicationConfiguration.InitMediaFileName = value;
                    _applicationConfiguration = _applicationConfiguration;
                }
            }

            public static string MediaContentFolderName
            {
                get
                {
                    return _applicationConfiguration.MediaContentFolderName;
                }
                set
                {
                    _applicationConfiguration.MediaContentFolderName = value;
                    _applicationConfiguration = _applicationConfiguration;
                }
            }

            /*public static string MediaProductionFolderName
            {
                get
                {
                    return _applicationConfiguration.MediaProductionFolderName;
                }
                set
                {
                    _applicationConfiguration.MediaProductionFolderName = value;
                    _applicationConfiguration = _applicationConfiguration;
                }
            }*/

            /*public static string MediaFragmentsFolderName
            {
                get
                {
                    return _applicationConfiguration.MediaFragmentsFolderName;
                }
                set
                {
                    _applicationConfiguration.MediaFragmentsFolderName = value;
                    _applicationConfiguration = _applicationConfiguration;
                }
            }*/

            public static string MediaRawSegmentsFolderName
            {
                get
                {
                    return _applicationConfiguration.MediaRawSegmentsFolderName;
                }
                set
                {
                    _applicationConfiguration.MediaRawSegmentsFolderName = value;
                    _applicationConfiguration = _applicationConfiguration;
                }
            }

            public static string MediaRawFolderName
            {
                get
                {
                    return _applicationConfiguration.MediaRawFolderName;
                }
                set
                {
                    _applicationConfiguration.MediaRawFolderName = value;
                    _applicationConfiguration = _applicationConfiguration;
                }
            }

            public static string DashMediaFolderName
            {
                get
                {
                    return _applicationConfiguration.DashMediaFolderName;
                }
                set
                {
                    _applicationConfiguration.DashMediaFolderName = value;
                    _applicationConfiguration = _applicationConfiguration;
                }
            }

            public static string StorageRootDirectoryPath
            {
                get
                {
                    string path = _applicationConfiguration.StorageRootDirectoryPath;
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    return path;
                }
                set
                {
                    _applicationConfiguration.StorageRootDirectoryPath = value;
                    _applicationConfiguration = _applicationConfiguration;
                }
            }            
        }

        private static readonly string AppUtilsDirectoryName = ConfigurationManager.AppSettings["UtilsDirectoryName"];

        public static string FFprobeFilePath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + AppUtilsDirectoryName + @"\" + "ffprobe.exe";
            }
        }

        public static string FFmpegFilePath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + AppUtilsDirectoryName + @"\" + "ffmpeg.exe";
            }
        }

        public static string MediaContentDirectoryPath
        {
            get
            {
                string pathTmpl = AppConf.StorageRootDirectoryPath + @"\{0}";
                string path = string.Format(pathTmpl, AppConf.MediaContentFolderName);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return path;
            }
        }

        /*public static string GetProductionDirectoryPath(int mediaId, MediaUtils.MediaType mediaType)
        {
            string pathTmpl = MediaContentDirectoryPath + @"\{0}\{1}\{2}";
            string path = string.Format(pathTmpl, MediaProductionFolderName, mediaId.ToString(), mediaType.ToString());
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        public static string GetProductionDirectoryPath(int mediaId)
        {
            string pathTmpl = MediaContentDirectoryPath + @"\{0}\{1}";
            string path = string.Format(pathTmpl, MediaProductionFolderName, mediaId.ToString());
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }*/

        /*public static string GetFragmentsDirectoryPath(int dashMediaId)
        {
            string pathTmpl = MediaContentDirectoryPath + @"\{0}\{1}";
            string path = string.Format(pathTmpl, MediaFragmentsFolderName, dashMediaId.ToString());
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }*/

        public static string Get_RawSegments_DirectoryPath(int mediaId)
        {
            string pathTmpl = MediaContentDirectoryPath + @"\{0}\{1}";
            string path = string.Format(pathTmpl, mediaId.ToString(), AppConf.MediaRawSegmentsFolderName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        public static string Get_Raw_DirectoryPath(int mediaId)
        {
            string pathTmpl = MediaContentDirectoryPath + @"\{0}\{1}";
            string path = string.Format(pathTmpl, mediaId.ToString(), AppConf.MediaRawFolderName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        public static string Get_Media_DirectoryPath(int mediaId)
        {
            string pathTmpl = MediaContentDirectoryPath + @"\{0}";
            string path = string.Format(pathTmpl, mediaId.ToString());
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        public static string Get_DashMedia_DirectoryPath(int mediaId, int dashMediaId)
        {
            string pathTmpl = Get_Media_DirectoryPath(mediaId) + @"\{0}\{1}";
            string path = string.Format(pathTmpl, AppConf.DashMediaFolderName, dashMediaId.ToString());
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        public static string Get_Dash_InitSegment_FilePath(int dashMediaId)
        {
            int? mediaId = null;
            Factory.DashMedia.Get_MediaId_ById(dashMediaId, ref mediaId);

            return Get_Dash_InitSegment_FilePath(mediaId.Value, dashMediaId);
        }

        public static string Get_Dash_InitSegment_FilePath(int mediaId, int dashMediaId)
        {
            string pathTmpl = Get_DashMedia_DirectoryPath(mediaId, dashMediaId) + @"\{0}";
            return string.Format(pathTmpl, AppConf.InitMediaFileName);
        }

        public static string Get_DashSegment_FilePath(int dashMediaId, int dashMediaSegmentId)
        {
            iDashMediaInfo dashMediaInfo = DashMediaApi.iDashMediaInfo_Get_By_DashMediaId(dashMediaId);
            if (dashMediaInfo == null)
                return string.Empty;

            string pathTmpl = Get_DashMedia_DirectoryPath(dashMediaInfo.MediaId, dashMediaId) + @"\{0}";
            return string.Format(pathTmpl, dashMediaSegmentId.ToString() + "." + ((Api.Enum.ContainerType)dashMediaInfo.DashContainerTypeId).GetFileExtension());

        }

        public static string Get_Manifest_FilePath(int mediaId)
        {
            string pathTmpl = Get_Media_DirectoryPath(mediaId) + @"\{0}";
            return string.Format(pathTmpl, AppConf.ManifestFileName);
        }

        public static class RegUtils
        {
            public static RegistryKey AppUserRootRegistry
            {
                get
                {
                    RegistryKey key;
                    using (RegistryKey HKEY_CURRENT_USER = Registry.CurrentUser)
                    {
                        using (RegistryKey HKEY_CURRENT_USER_SOFTWARE = HKEY_CURRENT_USER.CreateSubKey("Software"))
                        {
                            key = HKEY_CURRENT_USER_SOFTWARE.CreateSubKey(AppConf.ProjectName);
                        }
                    }
                    return key;
                }
            }
        }
    }
}
