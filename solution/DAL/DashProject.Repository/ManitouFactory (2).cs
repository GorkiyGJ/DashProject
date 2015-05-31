using System;
using System.Collections.Generic;
using System.Text;

namespace DashProject.Repository
{
    public sealed class ManitouFactory
    {
        private static object syncRoot = new Object();

             
        private Repository.AACEncoderConfigFactory innerAACEncoderConfigFactory;
        public Repository.AACEncoderConfigFactory AACEncoderConfig
        {
            get
            {
                if (innerAACEncoderConfigFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerAACEncoderConfigFactory == null)
                        {
                            innerAACEncoderConfigFactory = new Repository.AACEncoderConfigFactory();
                        }
                    }
                }

                return innerAACEncoderConfigFactory;
            }
        }
             
        private Repository.ApplicationConfigurationFactory innerApplicationConfigurationFactory;
        public Repository.ApplicationConfigurationFactory ApplicationConfiguration
        {
            get
            {
                if (innerApplicationConfigurationFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerApplicationConfigurationFactory == null)
                        {
                            innerApplicationConfigurationFactory = new Repository.ApplicationConfigurationFactory();
                        }
                    }
                }

                return innerApplicationConfigurationFactory;
            }
        }
             
        private Repository.AspectRatioFactory innerAspectRatioFactory;
        public Repository.AspectRatioFactory AspectRatio
        {
            get
            {
                if (innerAspectRatioFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerAspectRatioFactory == null)
                        {
                            innerAspectRatioFactory = new Repository.AspectRatioFactory();
                        }
                    }
                }

                return innerAspectRatioFactory;
            }
        }
             
        private Repository.AudioStreamFactory innerAudioStreamFactory;
        public Repository.AudioStreamFactory AudioStream
        {
            get
            {
                if (innerAudioStreamFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerAudioStreamFactory == null)
                        {
                            innerAudioStreamFactory = new Repository.AudioStreamFactory();
                        }
                    }
                }

                return innerAudioStreamFactory;
            }
        }
             
        private Repository.BroadcastTypeFactory innerBroadcastTypeFactory;
        public Repository.BroadcastTypeFactory BroadcastType
        {
            get
            {
                if (innerBroadcastTypeFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerBroadcastTypeFactory == null)
                        {
                            innerBroadcastTypeFactory = new Repository.BroadcastTypeFactory();
                        }
                    }
                }

                return innerBroadcastTypeFactory;
            }
        }
             
        private Repository.CodecFactory innerCodecFactory;
        public Repository.CodecFactory Codec
        {
            get
            {
                if (innerCodecFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerCodecFactory == null)
                        {
                            innerCodecFactory = new Repository.CodecFactory();
                        }
                    }
                }

                return innerCodecFactory;
            }
        }
             
        private Repository.CodecToEncoderFactory innerCodecToEncoderFactory;
        public Repository.CodecToEncoderFactory CodecToEncoder
        {
            get
            {
                if (innerCodecToEncoderFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerCodecToEncoderFactory == null)
                        {
                            innerCodecToEncoderFactory = new Repository.CodecToEncoderFactory();
                        }
                    }
                }

                return innerCodecToEncoderFactory;
            }
        }
             
        private Repository.CodecTypeFactory innerCodecTypeFactory;
        public Repository.CodecTypeFactory CodecType
        {
            get
            {
                if (innerCodecTypeFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerCodecTypeFactory == null)
                        {
                            innerCodecTypeFactory = new Repository.CodecTypeFactory();
                        }
                    }
                }

                return innerCodecTypeFactory;
            }
        }
             
        private Repository.ContainerFormatFactory innerContainerFormatFactory;
        public Repository.ContainerFormatFactory ContainerFormat
        {
            get
            {
                if (innerContainerFormatFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerContainerFormatFactory == null)
                        {
                            innerContainerFormatFactory = new Repository.ContainerFormatFactory();
                        }
                    }
                }

                return innerContainerFormatFactory;
            }
        }
             
        private Repository.DashContainerFormatFactory innerDashContainerFormatFactory;
        public Repository.DashContainerFormatFactory DashContainerFormat
        {
            get
            {
                if (innerDashContainerFormatFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerDashContainerFormatFactory == null)
                        {
                            innerDashContainerFormatFactory = new Repository.DashContainerFormatFactory();
                        }
                    }
                }

                return innerDashContainerFormatFactory;
            }
        }
             
        private Repository.DashInitSegmentFactory innerDashInitSegmentFactory;
        public Repository.DashInitSegmentFactory DashInitSegment
        {
            get
            {
                if (innerDashInitSegmentFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerDashInitSegmentFactory == null)
                        {
                            innerDashInitSegmentFactory = new Repository.DashInitSegmentFactory();
                        }
                    }
                }

                return innerDashInitSegmentFactory;
            }
        }
             
        private Repository.DashMediaFactory innerDashMediaFactory;
        public Repository.DashMediaFactory DashMedia
        {
            get
            {
                if (innerDashMediaFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerDashMediaFactory == null)
                        {
                            innerDashMediaFactory = new Repository.DashMediaFactory();
                        }
                    }
                }

                return innerDashMediaFactory;
            }
        }
             
        private Repository.DashMediaSegmentFactory innerDashMediaSegmentFactory;
        public Repository.DashMediaSegmentFactory DashMediaSegment
        {
            get
            {
                if (innerDashMediaSegmentFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerDashMediaSegmentFactory == null)
                        {
                            innerDashMediaSegmentFactory = new Repository.DashMediaSegmentFactory();
                        }
                    }
                }

                return innerDashMediaSegmentFactory;
            }
        }
             
        private Repository.DashTypeFactory innerDashTypeFactory;
        public Repository.DashTypeFactory DashType
        {
            get
            {
                if (innerDashTypeFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerDashTypeFactory == null)
                        {
                            innerDashTypeFactory = new Repository.DashTypeFactory();
                        }
                    }
                }

                return innerDashTypeFactory;
            }
        }
             
        private Repository.EncoderFactory innerEncoderFactory;
        public Repository.EncoderFactory Encoder
        {
            get
            {
                if (innerEncoderFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerEncoderFactory == null)
                        {
                            innerEncoderFactory = new Repository.EncoderFactory();
                        }
                    }
                }

                return innerEncoderFactory;
            }
        }
             
        private Repository.EncoderTypeFactory innerEncoderTypeFactory;
        public Repository.EncoderTypeFactory EncoderType
        {
            get
            {
                if (innerEncoderTypeFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerEncoderTypeFactory == null)
                        {
                            innerEncoderTypeFactory = new Repository.EncoderTypeFactory();
                        }
                    }
                }

                return innerEncoderTypeFactory;
            }
        }
             
        private Repository.LanguageFactory innerLanguageFactory;
        public Repository.LanguageFactory Language
        {
            get
            {
                if (innerLanguageFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerLanguageFactory == null)
                        {
                            innerLanguageFactory = new Repository.LanguageFactory();
                        }
                    }
                }

                return innerLanguageFactory;
            }
        }
             
        private Repository.LIBx264EncoderConfigFactory innerLIBx264EncoderConfigFactory;
        public Repository.LIBx264EncoderConfigFactory LIBx264EncoderConfig
        {
            get
            {
                if (innerLIBx264EncoderConfigFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerLIBx264EncoderConfigFactory == null)
                        {
                            innerLIBx264EncoderConfigFactory = new Repository.LIBx264EncoderConfigFactory();
                        }
                    }
                }

                return innerLIBx264EncoderConfigFactory;
            }
        }
             
        private Repository.LIBx264EncoderPresetTypeFactory innerLIBx264EncoderPresetTypeFactory;
        public Repository.LIBx264EncoderPresetTypeFactory LIBx264EncoderPresetType
        {
            get
            {
                if (innerLIBx264EncoderPresetTypeFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerLIBx264EncoderPresetTypeFactory == null)
                        {
                            innerLIBx264EncoderPresetTypeFactory = new Repository.LIBx264EncoderPresetTypeFactory();
                        }
                    }
                }

                return innerLIBx264EncoderPresetTypeFactory;
            }
        }
             
        private Repository.MediaFactory innerMediaFactory;
        public Repository.MediaFactory Media
        {
            get
            {
                if (innerMediaFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerMediaFactory == null)
                        {
                            innerMediaFactory = new Repository.MediaFactory();
                        }
                    }
                }

                return innerMediaFactory;
            }
        }
             
        private Repository.MediaOriginTypeFactory innerMediaOriginTypeFactory;
        public Repository.MediaOriginTypeFactory MediaOriginType
        {
            get
            {
                if (innerMediaOriginTypeFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerMediaOriginTypeFactory == null)
                        {
                            innerMediaOriginTypeFactory = new Repository.MediaOriginTypeFactory();
                        }
                    }
                }

                return innerMediaOriginTypeFactory;
            }
        }
             
        private Repository.RawMediaFactory innerRawMediaFactory;
        public Repository.RawMediaFactory RawMedia
        {
            get
            {
                if (innerRawMediaFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerRawMediaFactory == null)
                        {
                            innerRawMediaFactory = new Repository.RawMediaFactory();
                        }
                    }
                }

                return innerRawMediaFactory;
            }
        }
             
        private Repository.RawSegmentFactory innerRawSegmentFactory;
        public Repository.RawSegmentFactory RawSegment
        {
            get
            {
                if (innerRawSegmentFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerRawSegmentFactory == null)
                        {
                            innerRawSegmentFactory = new Repository.RawSegmentFactory();
                        }
                    }
                }

                return innerRawSegmentFactory;
            }
        }
             
        private Repository.RawSegmentStreamFactory innerRawSegmentStreamFactory;
        public Repository.RawSegmentStreamFactory RawSegmentStream
        {
            get
            {
                if (innerRawSegmentStreamFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerRawSegmentStreamFactory == null)
                        {
                            innerRawSegmentStreamFactory = new Repository.RawSegmentStreamFactory();
                        }
                    }
                }

                return innerRawSegmentStreamFactory;
            }
        }
             
        private Repository.SegmenterConfigFactory innerSegmenterConfigFactory;
        public Repository.SegmenterConfigFactory SegmenterConfig
        {
            get
            {
                if (innerSegmenterConfigFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerSegmenterConfigFactory == null)
                        {
                            innerSegmenterConfigFactory = new Repository.SegmenterConfigFactory();
                        }
                    }
                }

                return innerSegmenterConfigFactory;
            }
        }
             
        private Repository.StreamFactory innerStreamFactory;
        public Repository.StreamFactory Stream
        {
            get
            {
                if (innerStreamFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerStreamFactory == null)
                        {
                            innerStreamFactory = new Repository.StreamFactory();
                        }
                    }
                }

                return innerStreamFactory;
            }
        }
             
        private Repository.StreamTypeFactory innerStreamTypeFactory;
        public Repository.StreamTypeFactory StreamType
        {
            get
            {
                if (innerStreamTypeFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerStreamTypeFactory == null)
                        {
                            innerStreamTypeFactory = new Repository.StreamTypeFactory();
                        }
                    }
                }

                return innerStreamTypeFactory;
            }
        }
             
        private Repository.TranscoderConfigFactory innerTranscoderConfigFactory;
        public Repository.TranscoderConfigFactory TranscoderConfig
        {
            get
            {
                if (innerTranscoderConfigFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerTranscoderConfigFactory == null)
                        {
                            innerTranscoderConfigFactory = new Repository.TranscoderConfigFactory();
                        }
                    }
                }

                return innerTranscoderConfigFactory;
            }
        }
             
        private Repository.VideoSizeFactory innerVideoSizeFactory;
        public Repository.VideoSizeFactory VideoSize
        {
            get
            {
                if (innerVideoSizeFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerVideoSizeFactory == null)
                        {
                            innerVideoSizeFactory = new Repository.VideoSizeFactory();
                        }
                    }
                }

                return innerVideoSizeFactory;
            }
        }
             
        private Repository.VideoStreamFactory innerVideoStreamFactory;
        public Repository.VideoStreamFactory VideoStream
        {
            get
            {
                if (innerVideoStreamFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerVideoStreamFactory == null)
                        {
                            innerVideoStreamFactory = new Repository.VideoStreamFactory();
                        }
                    }
                }

                return innerVideoStreamFactory;
            }
        }
 


             
        private Repository.Custom.iDashMediaInfoFactory inneriDashMediaInfoFactory;
        public Repository.Custom.iDashMediaInfoFactory iDashMediaInfo
        {
            get
            {
                if (inneriDashMediaInfoFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (inneriDashMediaInfoFactory == null)
                        {
                            inneriDashMediaInfoFactory = new Repository.Custom.iDashMediaInfoFactory();
                        }
                    }
                }

                return inneriDashMediaInfoFactory;
            }
        }
             
        private Repository.Custom.iLIBx264TranscoderConfigFactory inneriLIBx264TranscoderConfigFactory;
        public Repository.Custom.iLIBx264TranscoderConfigFactory iLIBx264TranscoderConfig
        {
            get
            {
                if (inneriLIBx264TranscoderConfigFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (inneriLIBx264TranscoderConfigFactory == null)
                        {
                            inneriLIBx264TranscoderConfigFactory = new Repository.Custom.iLIBx264TranscoderConfigFactory();
                        }
                    }
                }

                return inneriLIBx264TranscoderConfigFactory;
            }
        }
             
        private Repository.Custom.iMediaInfoFactory inneriMediaInfoFactory;
        public Repository.Custom.iMediaInfoFactory iMediaInfo
        {
            get
            {
                if (inneriMediaInfoFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (inneriMediaInfoFactory == null)
                        {
                            inneriMediaInfoFactory = new Repository.Custom.iMediaInfoFactory();
                        }
                    }
                }

                return inneriMediaInfoFactory;
            }
        }
             
        private Repository.Custom.iSegmenterConfigFactory inneriSegmenterConfigFactory;
        public Repository.Custom.iSegmenterConfigFactory iSegmenterConfig
        {
            get
            {
                if (inneriSegmenterConfigFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (inneriSegmenterConfigFactory == null)
                        {
                            inneriSegmenterConfigFactory = new Repository.Custom.iSegmenterConfigFactory();
                        }
                    }
                }

                return inneriSegmenterConfigFactory;
            }
        }
             
        private Repository.Custom.iStreamInfoFactory inneriStreamInfoFactory;
        public Repository.Custom.iStreamInfoFactory iStreamInfo
        {
            get
            {
                if (inneriStreamInfoFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (inneriStreamInfoFactory == null)
                        {
                            inneriStreamInfoFactory = new Repository.Custom.iStreamInfoFactory();
                        }
                    }
                }

                return inneriStreamInfoFactory;
            }
        }
        
    }
}