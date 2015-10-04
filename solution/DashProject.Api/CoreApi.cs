using System.Diagnostics;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Configuration;
using DashProject.Api.Extension;
using System;


namespace DashProject.Api
{
    public static class CoreApi
    {
        public static class AppEventLog
        {
            public static readonly string sLog = CoreApi.ApplicationConfiguration.ApplicationName;

            public static void WriteEntry(string message, string eventSource, EventLogEntryType type)
            {
                if (!EventLog.SourceExists(eventSource))
                    EventLog.CreateEventSource(eventSource, sLog);
                EventLog.WriteEntry(eventSource, message, type);
            }
        }

        public static class ApplicationConfiguration
        {
            private static Factory.Entity.ApplicationConfiguration _applicationConfiguration
            {
                get
                {
                    Factory.Entity.ApplicationConfiguration applicationConfiguration;

                    List<Factory.Entity.ApplicationConfiguration> appConfList = Factory.ApplicationConfiguration.GetList();
                    
                    if (appConfList != null)
                        applicationConfiguration = appConfList[0];
                    return applicationConfiguration;

                    applicationConfiguration = new Factory.Entity.ApplicationConfiguration();
                    applicationConfiguration.ApplicationName = "DashProject";
                    applicationConfiguration.StorageRootDirectoryPath = Directory.GetDirectoryRoot(Directory.GetCurrentDirectory()) + applicationConfiguration.ApplicationName;
                    applicationConfiguration.DashManifestFileName = "manifest";
                    applicationConfiguration.DashInitSegmentFileName = "init";
                    applicationConfiguration.MediaContentFolderName = "MediaContent";
                    applicationConfiguration.DashMediaFolderName = "dash";
                    applicationConfiguration.RawMediaSegmentsFolderName = "raw_segments";
                    applicationConfiguration.RawMediaFolderName = "raw";
                    applicationConfiguration.ServiceName = "Service";

                    Factory.ApplicationConfiguration.Save(applicationConfiguration);

                    return applicationConfiguration;
                }
                set
                {
                    Factory.ApplicationConfiguration.Update(value);
                }
            }

            public static string ServiceDomainName
            {
                get
                {
                    return _applicationConfiguration.ServiceName.ToLower();
                }
            }

            public static string ServiceDomainUrl
            {
                get
                {
                    return "http://" + ServiceDomainName;
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
                    return ApplicationName + "." + ServiceName;
                }
            }

            public static string ApplicationName
            {
                get
                {
                    return _applicationConfiguration.ApplicationName;
                }
                set
                {
                    _applicationConfiguration.ApplicationName = value;
                    _applicationConfiguration = _applicationConfiguration;
                }
            }

            public static string DashManifestFileName
            {
                get
                {
                    return _applicationConfiguration.DashManifestFileName;
                }
                set
                {
                    _applicationConfiguration.DashManifestFileName = value;
                    _applicationConfiguration = _applicationConfiguration;
                }
            }

            public static string DashInitSegmentFileName
            {
                get
                {
                    return _applicationConfiguration.DashInitSegmentFileName;
                }
                set
                {
                    _applicationConfiguration.DashInitSegmentFileName = value;
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

            public static string RawMediaSegmentsFolderName
            {
                get
                {
                    return _applicationConfiguration.RawMediaSegmentsFolderName;
                }
                set
                {
                    _applicationConfiguration.RawMediaSegmentsFolderName = value;
                    _applicationConfiguration = _applicationConfiguration;
                }
            }

            public static string RawMediaFolderName
            {
                get
                {
                    return _applicationConfiguration.RawMediaFolderName;
                }
                set
                {
                    _applicationConfiguration.RawMediaFolderName = value;
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

        public static string AppUtilsDirectoryPath 
        {
            get 
            {
                return AppDomain.CurrentDomain.BaseDirectory + AppUtilsDirectoryName;
            }
        }

        public static string FFprobeFilePath
        {
            get
            {
                return AppUtilsDirectoryPath + @"\" + "ffprobe.exe";
            }
        }

        public static string FFmpegFilePath
        {
            get
            {
                return AppUtilsDirectoryPath + @"\" + "ffmpeg.exe";
            }
        }

        public static string MediaContentDirectoryPath
        {
            get
            {
                string pathTmpl = ApplicationConfiguration.StorageRootDirectoryPath + @"\{0}";
                string path = string.Format(pathTmpl, ApplicationConfiguration.MediaContentFolderName);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return path;
            }
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

        public static string Get_RawMedia_DirectoryPath(int mediaId)
        {
            string pathTmpl = Get_Media_DirectoryPath(mediaId) + @"\{0}";
            string path = string.Format(pathTmpl, ApplicationConfiguration.RawMediaFolderName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        public static string Get_RawMediaSegments_DirectoryPath(int mediaId)
        {
            string pathTmpl = Get_Media_DirectoryPath(mediaId) + @"\{0}";
            string path = string.Format(pathTmpl, ApplicationConfiguration.RawMediaSegmentsFolderName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }


        public static string Get_DashMedia_DirectoryPath(int dashMediaId, int? mediaId = null)
        {
            if(mediaId.HasValue == false)
               Factory.DashMedia.Get_MediaId_ById(dashMediaId, ref mediaId);

            string pathTmpl = Get_Media_DirectoryPath(mediaId.Value) + @"\{0}\{1}";
            string path = string.Format(pathTmpl, ApplicationConfiguration.DashMediaFolderName, dashMediaId.ToString());
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        public static string Get_DashInitSegment_FilePath(int dashMediaId, int? mediaId = null)
        {
            string pathTmpl = Get_DashMedia_DirectoryPath(dashMediaId, mediaId) + @"\{0}";
            return string.Format(pathTmpl, ApplicationConfiguration.DashInitSegmentFileName);
        }

        public static string Get_DashSegment_FilePath(int dashMediaId, int dashMediaSegmentId)
        {
            DashSegment dashSegment = Factory.DashSegment_GetBy_DashMediaId_DashMediaSegmentId(dashMediaId, dashMediaSegmentId);
            string fileName = dashSegment.fileName;
            
            if(String.IsNullOrEmpty(fileName))
                return string.Empty;

            string pathTmpl = Get_DashMedia_DirectoryPath(dashMediaId) + @"\{0}";
            return string.Format(pathTmpl, fileName);
        }

        public static string Get_DashManifest_FilePath(int mediaId)
        {
            string pathTmpl = Get_Media_DirectoryPath(mediaId) + @"\{0}";
            return string.Format(pathTmpl, ApplicationConfiguration.DashManifestFileName);
        }
    }
}
