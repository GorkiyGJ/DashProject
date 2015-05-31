using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration.Provider;

namespace DashProject.Data.MsSql
{
public sealed class MsSqlManitouProvider : ManitouProvider
    {
        private static object syncRoot = new Object();
        public MsSqlManitouProvider()
        {
            
        }

        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null)
                throw new ArgumentNullException("config");

            if (String.IsNullOrEmpty(name))
                name = "ManitouProvider";

            base.Initialize(name, config);


            string connect = config["connectionStringName"];
            config.Remove("connectionStringName");

            CommandTimeout = Manitou.Helper.Converter.ToInt32(config["commandTimeOut"]);
            if (CommandTimeout == -1)
                CommandTimeout = 30;

            if (String.IsNullOrEmpty(_connectionString))
            {
                if (String.IsNullOrEmpty(connect))
                    throw new ProviderException("Empty or missing connectionStringName");

                if (DataProvider.ConnectionStrings[connect] == null)
                    throw new ProviderException("Missing connection string");

                _connectionString = DataProvider.ConnectionStrings[connect].ConnectionString;
            }

            if (String.IsNullOrEmpty(_connectionString))
                throw new ProviderException("Empty connection string");
        }

        #region Properties
        private string _connectionString;
        public override string ConnectionString
        {
            get { return _connectionString; }
        }

        private int _CommandTimeout;
        public int CommandTimeout
        {
            get { return _CommandTimeout; }
            set { _CommandTimeout = value; }
        }

        
                        private Mapper.AACTranscoderConfigMapper innerAACTranscoderConfigMapper;
                        public override DashProject.Data.Providers.AACTranscoderConfigProvider AACTranscoderConfigProvider
                        {
                            get
                            {
                                if (innerAACTranscoderConfigMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerAACTranscoderConfigMapper == null)
                                        {
                                            innerAACTranscoderConfigMapper = new Mapper.AACTranscoderConfigMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerAACTranscoderConfigMapper;
                            }
                        }
                        
                        private Mapper.ApplicationConfigurationMapper innerApplicationConfigurationMapper;
                        public override DashProject.Data.Providers.ApplicationConfigurationProvider ApplicationConfigurationProvider
                        {
                            get
                            {
                                if (innerApplicationConfigurationMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerApplicationConfigurationMapper == null)
                                        {
                                            innerApplicationConfigurationMapper = new Mapper.ApplicationConfigurationMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerApplicationConfigurationMapper;
                            }
                        }
                        
                        private Mapper.AspectRatioMapper innerAspectRatioMapper;
                        public override DashProject.Data.Providers.AspectRatioProvider AspectRatioProvider
                        {
                            get
                            {
                                if (innerAspectRatioMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerAspectRatioMapper == null)
                                        {
                                            innerAspectRatioMapper = new Mapper.AspectRatioMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerAspectRatioMapper;
                            }
                        }
                        
                        private Mapper.BroadcastTypeMapper innerBroadcastTypeMapper;
                        public override DashProject.Data.Providers.BroadcastTypeProvider BroadcastTypeProvider
                        {
                            get
                            {
                                if (innerBroadcastTypeMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerBroadcastTypeMapper == null)
                                        {
                                            innerBroadcastTypeMapper = new Mapper.BroadcastTypeMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerBroadcastTypeMapper;
                            }
                        }
                        
                        private Mapper.CodecMediaTypeMapper innerCodecMediaTypeMapper;
                        public override DashProject.Data.Providers.CodecMediaTypeProvider CodecMediaTypeProvider
                        {
                            get
                            {
                                if (innerCodecMediaTypeMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerCodecMediaTypeMapper == null)
                                        {
                                            innerCodecMediaTypeMapper = new Mapper.CodecMediaTypeMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerCodecMediaTypeMapper;
                            }
                        }
                        
                        private Mapper.CodecToEncoderMapper innerCodecToEncoderMapper;
                        public override DashProject.Data.Providers.CodecToEncoderProvider CodecToEncoderProvider
                        {
                            get
                            {
                                if (innerCodecToEncoderMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerCodecToEncoderMapper == null)
                                        {
                                            innerCodecToEncoderMapper = new Mapper.CodecToEncoderMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerCodecToEncoderMapper;
                            }
                        }
                        
                        private Mapper.CodecTypeMapper innerCodecTypeMapper;
                        public override DashProject.Data.Providers.CodecTypeProvider CodecTypeProvider
                        {
                            get
                            {
                                if (innerCodecTypeMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerCodecTypeMapper == null)
                                        {
                                            innerCodecTypeMapper = new Mapper.CodecTypeMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerCodecTypeMapper;
                            }
                        }
                        
                        private Mapper.ContainerTypeMapper innerContainerTypeMapper;
                        public override DashProject.Data.Providers.ContainerTypeProvider ContainerTypeProvider
                        {
                            get
                            {
                                if (innerContainerTypeMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerContainerTypeMapper == null)
                                        {
                                            innerContainerTypeMapper = new Mapper.ContainerTypeMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerContainerTypeMapper;
                            }
                        }
                        
                        private Mapper.DashInitSegmentMapper innerDashInitSegmentMapper;
                        public override DashProject.Data.Providers.DashInitSegmentProvider DashInitSegmentProvider
                        {
                            get
                            {
                                if (innerDashInitSegmentMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerDashInitSegmentMapper == null)
                                        {
                                            innerDashInitSegmentMapper = new Mapper.DashInitSegmentMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerDashInitSegmentMapper;
                            }
                        }
                        
                        private Mapper.DashMediaMapper innerDashMediaMapper;
                        public override DashProject.Data.Providers.DashMediaProvider DashMediaProvider
                        {
                            get
                            {
                                if (innerDashMediaMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerDashMediaMapper == null)
                                        {
                                            innerDashMediaMapper = new Mapper.DashMediaMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerDashMediaMapper;
                            }
                        }
                        
                        private Mapper.DashMediaSegmentMapper innerDashMediaSegmentMapper;
                        public override DashProject.Data.Providers.DashMediaSegmentProvider DashMediaSegmentProvider
                        {
                            get
                            {
                                if (innerDashMediaSegmentMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerDashMediaSegmentMapper == null)
                                        {
                                            innerDashMediaSegmentMapper = new Mapper.DashMediaSegmentMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerDashMediaSegmentMapper;
                            }
                        }
                        
                        private Mapper.DashTypeMapper innerDashTypeMapper;
                        public override DashProject.Data.Providers.DashTypeProvider DashTypeProvider
                        {
                            get
                            {
                                if (innerDashTypeMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerDashTypeMapper == null)
                                        {
                                            innerDashTypeMapper = new Mapper.DashTypeMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerDashTypeMapper;
                            }
                        }
                        
                        private Mapper.DecoderTypeMapper innerDecoderTypeMapper;
                        public override DashProject.Data.Providers.DecoderTypeProvider DecoderTypeProvider
                        {
                            get
                            {
                                if (innerDecoderTypeMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerDecoderTypeMapper == null)
                                        {
                                            innerDecoderTypeMapper = new Mapper.DecoderTypeMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerDecoderTypeMapper;
                            }
                        }
                        
                        private Mapper.EncoderTypeMapper innerEncoderTypeMapper;
                        public override DashProject.Data.Providers.EncoderTypeProvider EncoderTypeProvider
                        {
                            get
                            {
                                if (innerEncoderTypeMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerEncoderTypeMapper == null)
                                        {
                                            innerEncoderTypeMapper = new Mapper.EncoderTypeMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerEncoderTypeMapper;
                            }
                        }
                        
                        private Mapper.LanguageMapper innerLanguageMapper;
                        public override DashProject.Data.Providers.LanguageProvider LanguageProvider
                        {
                            get
                            {
                                if (innerLanguageMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerLanguageMapper == null)
                                        {
                                            innerLanguageMapper = new Mapper.LanguageMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerLanguageMapper;
                            }
                        }
                        
                        private Mapper.LIBx264EncoderConfigMapper innerLIBx264EncoderConfigMapper;
                        public override DashProject.Data.Providers.LIBx264EncoderConfigProvider LIBx264EncoderConfigProvider
                        {
                            get
                            {
                                if (innerLIBx264EncoderConfigMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerLIBx264EncoderConfigMapper == null)
                                        {
                                            innerLIBx264EncoderConfigMapper = new Mapper.LIBx264EncoderConfigMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerLIBx264EncoderConfigMapper;
                            }
                        }
                        
                        private Mapper.LIBx264EncoderPresetTypeMapper innerLIBx264EncoderPresetTypeMapper;
                        public override DashProject.Data.Providers.LIBx264EncoderPresetTypeProvider LIBx264EncoderPresetTypeProvider
                        {
                            get
                            {
                                if (innerLIBx264EncoderPresetTypeMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerLIBx264EncoderPresetTypeMapper == null)
                                        {
                                            innerLIBx264EncoderPresetTypeMapper = new Mapper.LIBx264EncoderPresetTypeMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerLIBx264EncoderPresetTypeMapper;
                            }
                        }
                        
                        private Mapper.MediaMapper innerMediaMapper;
                        public override DashProject.Data.Providers.MediaProvider MediaProvider
                        {
                            get
                            {
                                if (innerMediaMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerMediaMapper == null)
                                        {
                                            innerMediaMapper = new Mapper.MediaMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerMediaMapper;
                            }
                        }
                        
                        private Mapper.RawMediaMapper innerRawMediaMapper;
                        public override DashProject.Data.Providers.RawMediaProvider RawMediaProvider
                        {
                            get
                            {
                                if (innerRawMediaMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerRawMediaMapper == null)
                                        {
                                            innerRawMediaMapper = new Mapper.RawMediaMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerRawMediaMapper;
                            }
                        }
                        
                        private Mapper.RawMediaSourceTypeMapper innerRawMediaSourceTypeMapper;
                        public override DashProject.Data.Providers.RawMediaSourceTypeProvider RawMediaSourceTypeProvider
                        {
                            get
                            {
                                if (innerRawMediaSourceTypeMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerRawMediaSourceTypeMapper == null)
                                        {
                                            innerRawMediaSourceTypeMapper = new Mapper.RawMediaSourceTypeMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerRawMediaSourceTypeMapper;
                            }
                        }
                        
                        private Mapper.RawSegmentStreamMapper innerRawSegmentStreamMapper;
                        public override DashProject.Data.Providers.RawSegmentStreamProvider RawSegmentStreamProvider
                        {
                            get
                            {
                                if (innerRawSegmentStreamMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerRawSegmentStreamMapper == null)
                                        {
                                            innerRawSegmentStreamMapper = new Mapper.RawSegmentStreamMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerRawSegmentStreamMapper;
                            }
                        }
                        
                        private Mapper.ScaleVideoFilterMapper innerScaleVideoFilterMapper;
                        public override DashProject.Data.Providers.ScaleVideoFilterProvider ScaleVideoFilterProvider
                        {
                            get
                            {
                                if (innerScaleVideoFilterMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerScaleVideoFilterMapper == null)
                                        {
                                            innerScaleVideoFilterMapper = new Mapper.ScaleVideoFilterMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerScaleVideoFilterMapper;
                            }
                        }
                        
                        private Mapper.SegmenterConfigMapper innerSegmenterConfigMapper;
                        public override DashProject.Data.Providers.SegmenterConfigProvider SegmenterConfigProvider
                        {
                            get
                            {
                                if (innerSegmenterConfigMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerSegmenterConfigMapper == null)
                                        {
                                            innerSegmenterConfigMapper = new Mapper.SegmenterConfigMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerSegmenterConfigMapper;
                            }
                        }
                        
                        private Mapper.StreamMapper innerStreamMapper;
                        public override DashProject.Data.Providers.StreamProvider StreamProvider
                        {
                            get
                            {
                                if (innerStreamMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerStreamMapper == null)
                                        {
                                            innerStreamMapper = new Mapper.StreamMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerStreamMapper;
                            }
                        }
                        
                        private Mapper.StreamTypeMapper innerStreamTypeMapper;
                        public override DashProject.Data.Providers.StreamTypeProvider StreamTypeProvider
                        {
                            get
                            {
                                if (innerStreamTypeMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerStreamTypeMapper == null)
                                        {
                                            innerStreamTypeMapper = new Mapper.StreamTypeMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerStreamTypeMapper;
                            }
                        }
                        
                        private Mapper.VideoSizeMapper innerVideoSizeMapper;
                        public override DashProject.Data.Providers.VideoSizeProvider VideoSizeProvider
                        {
                            get
                            {
                                if (innerVideoSizeMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerVideoSizeMapper == null)
                                        {
                                            innerVideoSizeMapper = new Mapper.VideoSizeMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerVideoSizeMapper;
                            }
                        }
                        
                        private Mapper.X264ProfileMapper innerX264ProfileMapper;
                        public override DashProject.Data.Providers.X264ProfileProvider X264ProfileProvider
                        {
                            get
                            {
                                if (innerX264ProfileMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerX264ProfileMapper == null)
                                        {
                                            innerX264ProfileMapper = new Mapper.X264ProfileMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerX264ProfileMapper;
                            }
                        }
                        
                        private Mapper.X264ProfileLevelMapper innerX264ProfileLevelMapper;
                        public override DashProject.Data.Providers.X264ProfileLevelProvider X264ProfileLevelProvider
                        {
                            get
                            {
                                if (innerX264ProfileLevelMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerX264ProfileLevelMapper == null)
                                        {
                                            innerX264ProfileLevelMapper = new Mapper.X264ProfileLevelMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerX264ProfileLevelMapper;
                            }
                        }
                        
        
    
        
                        private Mapper.Custom.iTranscoderConfigMapper inneriTranscoderConfigMapper;
                        public override DashProject.Data.Providers.Custom.iTranscoderConfigProvider iTranscoderConfigProvider
                        {
                            get
                            {
                                if (inneriTranscoderConfigMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (inneriTranscoderConfigMapper == null)
                                        {
                                            inneriTranscoderConfigMapper = new Mapper.Custom.iTranscoderConfigMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return inneriTranscoderConfigMapper;
                            }
                        }
                        
                        private Mapper.Custom.iLIBx264EncoderConfigMapper inneriLIBx264EncoderConfigMapper;
                        public override DashProject.Data.Providers.Custom.iLIBx264EncoderConfigProvider iLIBx264EncoderConfigProvider
                        {
                            get
                            {
                                if (inneriLIBx264EncoderConfigMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (inneriLIBx264EncoderConfigMapper == null)
                                        {
                                            inneriLIBx264EncoderConfigMapper = new Mapper.Custom.iLIBx264EncoderConfigMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return inneriLIBx264EncoderConfigMapper;
                            }
                        }
                        
                        private Mapper.Custom.iScaleVideoFilterMapper inneriScaleVideoFilterMapper;
                        public override DashProject.Data.Providers.Custom.iScaleVideoFilterProvider iScaleVideoFilterProvider
                        {
                            get
                            {
                                if (inneriScaleVideoFilterMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (inneriScaleVideoFilterMapper == null)
                                        {
                                            inneriScaleVideoFilterMapper = new Mapper.Custom.iScaleVideoFilterMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return inneriScaleVideoFilterMapper;
                            }
                        }
                        
                        private Mapper.Custom.iDashMediaInfoMapper inneriDashMediaInfoMapper;
                        public override DashProject.Data.Providers.Custom.iDashMediaInfoProvider iDashMediaInfoProvider
                        {
                            get
                            {
                                if (inneriDashMediaInfoMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (inneriDashMediaInfoMapper == null)
                                        {
                                            inneriDashMediaInfoMapper = new Mapper.Custom.iDashMediaInfoMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return inneriDashMediaInfoMapper;
                            }
                        }
                        
                        private Mapper.Custom.iSegmenterConfigMapper inneriSegmenterConfigMapper;
                        public override DashProject.Data.Providers.Custom.iSegmenterConfigProvider iSegmenterConfigProvider
                        {
                            get
                            {
                                if (inneriSegmenterConfigMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (inneriSegmenterConfigMapper == null)
                                        {
                                            inneriSegmenterConfigMapper = new Mapper.Custom.iSegmenterConfigMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return inneriSegmenterConfigMapper;
                            }
                        }
                        
                        private Mapper.Custom.iMediaInfoMapper inneriMediaInfoMapper;
                        public override DashProject.Data.Providers.Custom.iMediaInfoProvider iMediaInfoProvider
                        {
                            get
                            {
                                if (inneriMediaInfoMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (inneriMediaInfoMapper == null)
                                        {
                                            inneriMediaInfoMapper = new Mapper.Custom.iMediaInfoMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return inneriMediaInfoMapper;
                            }
                        }
                        
                        private Mapper.Custom.iStreamInfoMapper inneriStreamInfoMapper;
                        public override DashProject.Data.Providers.Custom.iStreamInfoProvider iStreamInfoProvider
                        {
                            get
                            {
                                if (inneriStreamInfoMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (inneriStreamInfoMapper == null)
                                        {
                                            inneriStreamInfoMapper = new Mapper.Custom.iStreamInfoMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return inneriStreamInfoMapper;
                            }
                        }
                        
        #endregion
    }    
}