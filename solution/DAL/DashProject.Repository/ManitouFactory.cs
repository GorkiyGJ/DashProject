using System;
using System.Collections.Generic;
using System.Text;

namespace DashProject.Repository
{
    public sealed class ManitouFactory
    {
        private static object syncRoot = new Object();

             
        private Repository.AACTranscoderConfigFactory innerAACTranscoderConfigFactory;
        public Repository.AACTranscoderConfigFactory AACTranscoderConfig
        {
            get
            {
                if (innerAACTranscoderConfigFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerAACTranscoderConfigFactory == null)
                        {
                            innerAACTranscoderConfigFactory = new Repository.AACTranscoderConfigFactory();
                        }
                    }
                }

                return innerAACTranscoderConfigFactory;
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
             
        private Repository.CodecMediaTypeFactory innerCodecMediaTypeFactory;
        public Repository.CodecMediaTypeFactory CodecMediaType
        {
            get
            {
                if (innerCodecMediaTypeFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerCodecMediaTypeFactory == null)
                        {
                            innerCodecMediaTypeFactory = new Repository.CodecMediaTypeFactory();
                        }
                    }
                }

                return innerCodecMediaTypeFactory;
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
             
        private Repository.ContainerTypeFactory innerContainerTypeFactory;
        public Repository.ContainerTypeFactory ContainerType
        {
            get
            {
                if (innerContainerTypeFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerContainerTypeFactory == null)
                        {
                            innerContainerTypeFactory = new Repository.ContainerTypeFactory();
                        }
                    }
                }

                return innerContainerTypeFactory;
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
             
        private Repository.DecoderTypeFactory innerDecoderTypeFactory;
        public Repository.DecoderTypeFactory DecoderType
        {
            get
            {
                if (innerDecoderTypeFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerDecoderTypeFactory == null)
                        {
                            innerDecoderTypeFactory = new Repository.DecoderTypeFactory();
                        }
                    }
                }

                return innerDecoderTypeFactory;
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
             
        private Repository.RawMediaSourceTypeFactory innerRawMediaSourceTypeFactory;
        public Repository.RawMediaSourceTypeFactory RawMediaSourceType
        {
            get
            {
                if (innerRawMediaSourceTypeFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerRawMediaSourceTypeFactory == null)
                        {
                            innerRawMediaSourceTypeFactory = new Repository.RawMediaSourceTypeFactory();
                        }
                    }
                }

                return innerRawMediaSourceTypeFactory;
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
             
        private Repository.ScaleVideoFilterFactory innerScaleVideoFilterFactory;
        public Repository.ScaleVideoFilterFactory ScaleVideoFilter
        {
            get
            {
                if (innerScaleVideoFilterFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerScaleVideoFilterFactory == null)
                        {
                            innerScaleVideoFilterFactory = new Repository.ScaleVideoFilterFactory();
                        }
                    }
                }

                return innerScaleVideoFilterFactory;
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
             
        private Repository.X264ProfileFactory innerX264ProfileFactory;
        public Repository.X264ProfileFactory X264Profile
        {
            get
            {
                if (innerX264ProfileFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerX264ProfileFactory == null)
                        {
                            innerX264ProfileFactory = new Repository.X264ProfileFactory();
                        }
                    }
                }

                return innerX264ProfileFactory;
            }
        }
             
        private Repository.X264ProfileLevelFactory innerX264ProfileLevelFactory;
        public Repository.X264ProfileLevelFactory X264ProfileLevel
        {
            get
            {
                if (innerX264ProfileLevelFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (innerX264ProfileLevelFactory == null)
                        {
                            innerX264ProfileLevelFactory = new Repository.X264ProfileLevelFactory();
                        }
                    }
                }

                return innerX264ProfileLevelFactory;
            }
        }
 


             
        private Repository.Custom.iTranscoderConfigFactory inneriTranscoderConfigFactory;
        public Repository.Custom.iTranscoderConfigFactory iTranscoderConfig
        {
            get
            {
                if (inneriTranscoderConfigFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (inneriTranscoderConfigFactory == null)
                        {
                            inneriTranscoderConfigFactory = new Repository.Custom.iTranscoderConfigFactory();
                        }
                    }
                }

                return inneriTranscoderConfigFactory;
            }
        }
             
        private Repository.Custom.iLIBx264EncoderConfigFactory inneriLIBx264EncoderConfigFactory;
        public Repository.Custom.iLIBx264EncoderConfigFactory iLIBx264EncoderConfig
        {
            get
            {
                if (inneriLIBx264EncoderConfigFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (inneriLIBx264EncoderConfigFactory == null)
                        {
                            inneriLIBx264EncoderConfigFactory = new Repository.Custom.iLIBx264EncoderConfigFactory();
                        }
                    }
                }

                return inneriLIBx264EncoderConfigFactory;
            }
        }
             
        private Repository.Custom.iScaleVideoFilterFactory inneriScaleVideoFilterFactory;
        public Repository.Custom.iScaleVideoFilterFactory iScaleVideoFilter
        {
            get
            {
                if (inneriScaleVideoFilterFactory == null)
                {
                    lock (syncRoot)
                    {
                        if (inneriScaleVideoFilterFactory == null)
                        {
                            inneriScaleVideoFilterFactory = new Repository.Custom.iScaleVideoFilterFactory();
                        }
                    }
                }

                return inneriScaleVideoFilterFactory;
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