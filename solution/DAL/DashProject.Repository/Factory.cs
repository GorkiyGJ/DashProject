using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Manitou.Data.Provider;
using System.Web;

namespace DashProject.Repository
{
    public sealed class Factory
    {
        private static volatile ManitouFactory _factory = null;
        private static object SyncRoot = new object();

        #region Factory
        private static ManitouFactory Repository
        {
            get
            {
                if (_factory == null)
                {
                    lock (SyncRoot)
                    {
                        if (_factory == null)
                        {
                            _factory = new ManitouFactory();
                        }
                    }
                }

                return _factory;
            }
        }
        #endregion

        #region Factories
             
        public static AACTranscoderConfigFactory AACTranscoderConfig
        {
            get
            {
                return Repository.AACTranscoderConfig;
            }
        }
             
        public static ApplicationConfigurationFactory ApplicationConfiguration
        {
            get
            {
                return Repository.ApplicationConfiguration;
            }
        }
             
        public static AspectRatioFactory AspectRatio
        {
            get
            {
                return Repository.AspectRatio;
            }
        }
             
        public static BroadcastTypeFactory BroadcastType
        {
            get
            {
                return Repository.BroadcastType;
            }
        }
             
        public static CodecMediaTypeFactory CodecMediaType
        {
            get
            {
                return Repository.CodecMediaType;
            }
        }
             
        public static CodecToEncoderFactory CodecToEncoder
        {
            get
            {
                return Repository.CodecToEncoder;
            }
        }
             
        public static CodecTypeFactory CodecType
        {
            get
            {
                return Repository.CodecType;
            }
        }
             
        public static ContainerTypeFactory ContainerType
        {
            get
            {
                return Repository.ContainerType;
            }
        }
             
        public static DashInitSegmentFactory DashInitSegment
        {
            get
            {
                return Repository.DashInitSegment;
            }
        }
             
        public static DashMediaFactory DashMedia
        {
            get
            {
                return Repository.DashMedia;
            }
        }
             
        public static DashMediaSegmentFactory DashMediaSegment
        {
            get
            {
                return Repository.DashMediaSegment;
            }
        }
             
        public static DashTypeFactory DashType
        {
            get
            {
                return Repository.DashType;
            }
        }
             
        public static DecoderTypeFactory DecoderType
        {
            get
            {
                return Repository.DecoderType;
            }
        }
             
        public static EncoderTypeFactory EncoderType
        {
            get
            {
                return Repository.EncoderType;
            }
        }
             
        public static LanguageFactory Language
        {
            get
            {
                return Repository.Language;
            }
        }
             
        public static LIBx264EncoderConfigFactory LIBx264EncoderConfig
        {
            get
            {
                return Repository.LIBx264EncoderConfig;
            }
        }
             
        public static LIBx264EncoderPresetTypeFactory LIBx264EncoderPresetType
        {
            get
            {
                return Repository.LIBx264EncoderPresetType;
            }
        }
             
        public static MediaFactory Media
        {
            get
            {
                return Repository.Media;
            }
        }
             
        public static RawMediaFactory RawMedia
        {
            get
            {
                return Repository.RawMedia;
            }
        }
             
        public static RawMediaSourceTypeFactory RawMediaSourceType
        {
            get
            {
                return Repository.RawMediaSourceType;
            }
        }
             
        public static RawSegmentStreamFactory RawSegmentStream
        {
            get
            {
                return Repository.RawSegmentStream;
            }
        }
             
        public static ScaleVideoFilterFactory ScaleVideoFilter
        {
            get
            {
                return Repository.ScaleVideoFilter;
            }
        }
             
        public static SegmenterConfigFactory SegmenterConfig
        {
            get
            {
                return Repository.SegmenterConfig;
            }
        }
             
        public static StreamFactory Stream
        {
            get
            {
                return Repository.Stream;
            }
        }
             
        public static StreamTypeFactory StreamType
        {
            get
            {
                return Repository.StreamType;
            }
        }
             
        public static VideoSizeFactory VideoSize
        {
            get
            {
                return Repository.VideoSize;
            }
        }
             
        public static X264ProfileFactory X264Profile
        {
            get
            {
                return Repository.X264Profile;
            }
        }
             
        public static X264ProfileLevelFactory X264ProfileLevel
        {
            get
            {
                return Repository.X264ProfileLevel;
            }
        }
         
    
     
    
             
        public static Custom.iTranscoderConfigFactory iTranscoderConfig
        {
            get
            {
                return Repository.iTranscoderConfig;
            }
        }
             
        public static Custom.iLIBx264EncoderConfigFactory iLIBx264EncoderConfig
        {
            get
            {
                return Repository.iLIBx264EncoderConfig;
            }
        }
             
        public static Custom.iScaleVideoFilterFactory iScaleVideoFilter
        {
            get
            {
                return Repository.iScaleVideoFilter;
            }
        }
             
        public static Custom.iDashMediaInfoFactory iDashMediaInfo
        {
            get
            {
                return Repository.iDashMediaInfo;
            }
        }
             
        public static Custom.iSegmenterConfigFactory iSegmenterConfig
        {
            get
            {
                return Repository.iSegmenterConfig;
            }
        }
             
        public static Custom.iMediaInfoFactory iMediaInfo
        {
            get
            {
                return Repository.iMediaInfo;
            }
        }
             
        public static Custom.iStreamInfoFactory iStreamInfo
        {
            get
            {
                return Repository.iStreamInfo;
            }
        }
     
        #endregion
    }
}