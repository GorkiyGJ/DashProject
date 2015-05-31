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
             
        public static AACEncoderConfigFactory AACEncoderConfig
        {
            get
            {
                return Repository.AACEncoderConfig;
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
             
        public static AudioStreamFactory AudioStream
        {
            get
            {
                return Repository.AudioStream;
            }
        }
             
        public static BroadcastTypeFactory BroadcastType
        {
            get
            {
                return Repository.BroadcastType;
            }
        }
             
        public static CodecFactory Codec
        {
            get
            {
                return Repository.Codec;
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
             
        public static ContainerFormatFactory ContainerFormat
        {
            get
            {
                return Repository.ContainerFormat;
            }
        }
             
        public static DashContainerFormatFactory DashContainerFormat
        {
            get
            {
                return Repository.DashContainerFormat;
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
             
        public static EncoderFactory Encoder
        {
            get
            {
                return Repository.Encoder;
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
             
        public static MediaOriginTypeFactory MediaOriginType
        {
            get
            {
                return Repository.MediaOriginType;
            }
        }
             
        public static RawMediaFactory RawMedia
        {
            get
            {
                return Repository.RawMedia;
            }
        }
             
        public static RawSegmentFactory RawSegment
        {
            get
            {
                return Repository.RawSegment;
            }
        }
             
        public static RawSegmentStreamFactory RawSegmentStream
        {
            get
            {
                return Repository.RawSegmentStream;
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
             
        public static TranscoderConfigFactory TranscoderConfig
        {
            get
            {
                return Repository.TranscoderConfig;
            }
        }
             
        public static VideoSizeFactory VideoSize
        {
            get
            {
                return Repository.VideoSize;
            }
        }
             
        public static VideoStreamFactory VideoStream
        {
            get
            {
                return Repository.VideoStream;
            }
        }
         
    
     
    
             
        public static Custom.iDashMediaInfoFactory iDashMediaInfo
        {
            get
            {
                return Repository.iDashMediaInfo;
            }
        }
             
        public static Custom.iLIBx264TranscoderConfigFactory iLIBx264TranscoderConfig
        {
            get
            {
                return Repository.iLIBx264TranscoderConfig;
            }
        }
             
        public static Custom.iMediaInfoFactory iMediaInfo
        {
            get
            {
                return Repository.iMediaInfo;
            }
        }
             
        public static Custom.iSegmenterConfigFactory iSegmenterConfig
        {
            get
            {
                return Repository.iSegmenterConfig;
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