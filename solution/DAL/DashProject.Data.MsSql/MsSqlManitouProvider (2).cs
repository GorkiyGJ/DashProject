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

        
                        private Mapper.AACEncoderConfigMapper innerAACEncoderConfigMapper;
                        public override DashProject.Data.Providers.AACEncoderConfigProvider AACEncoderConfigProvider
                        {
                            get
                            {
                                if (innerAACEncoderConfigMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerAACEncoderConfigMapper == null)
                                        {
                                            innerAACEncoderConfigMapper = new Mapper.AACEncoderConfigMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerAACEncoderConfigMapper;
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
                        
                        private Mapper.AudioStreamMapper innerAudioStreamMapper;
                        public override DashProject.Data.Providers.AudioStreamProvider AudioStreamProvider
                        {
                            get
                            {
                                if (innerAudioStreamMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerAudioStreamMapper == null)
                                        {
                                            innerAudioStreamMapper = new Mapper.AudioStreamMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerAudioStreamMapper;
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
                        
                        private Mapper.CodecMapper innerCodecMapper;
                        public override DashProject.Data.Providers.CodecProvider CodecProvider
                        {
                            get
                            {
                                if (innerCodecMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerCodecMapper == null)
                                        {
                                            innerCodecMapper = new Mapper.CodecMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerCodecMapper;
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
                        
                        private Mapper.ContainerFormatMapper innerContainerFormatMapper;
                        public override DashProject.Data.Providers.ContainerFormatProvider ContainerFormatProvider
                        {
                            get
                            {
                                if (innerContainerFormatMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerContainerFormatMapper == null)
                                        {
                                            innerContainerFormatMapper = new Mapper.ContainerFormatMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerContainerFormatMapper;
                            }
                        }
                        
                        private Mapper.DashContainerFormatMapper innerDashContainerFormatMapper;
                        public override DashProject.Data.Providers.DashContainerFormatProvider DashContainerFormatProvider
                        {
                            get
                            {
                                if (innerDashContainerFormatMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerDashContainerFormatMapper == null)
                                        {
                                            innerDashContainerFormatMapper = new Mapper.DashContainerFormatMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerDashContainerFormatMapper;
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
                        
                        private Mapper.EncoderMapper innerEncoderMapper;
                        public override DashProject.Data.Providers.EncoderProvider EncoderProvider
                        {
                            get
                            {
                                if (innerEncoderMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerEncoderMapper == null)
                                        {
                                            innerEncoderMapper = new Mapper.EncoderMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerEncoderMapper;
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
                        
                        private Mapper.MediaOriginTypeMapper innerMediaOriginTypeMapper;
                        public override DashProject.Data.Providers.MediaOriginTypeProvider MediaOriginTypeProvider
                        {
                            get
                            {
                                if (innerMediaOriginTypeMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerMediaOriginTypeMapper == null)
                                        {
                                            innerMediaOriginTypeMapper = new Mapper.MediaOriginTypeMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerMediaOriginTypeMapper;
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
                        
                        private Mapper.RawSegmentMapper innerRawSegmentMapper;
                        public override DashProject.Data.Providers.RawSegmentProvider RawSegmentProvider
                        {
                            get
                            {
                                if (innerRawSegmentMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerRawSegmentMapper == null)
                                        {
                                            innerRawSegmentMapper = new Mapper.RawSegmentMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerRawSegmentMapper;
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
                        
                        private Mapper.TranscoderConfigMapper innerTranscoderConfigMapper;
                        public override DashProject.Data.Providers.TranscoderConfigProvider TranscoderConfigProvider
                        {
                            get
                            {
                                if (innerTranscoderConfigMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerTranscoderConfigMapper == null)
                                        {
                                            innerTranscoderConfigMapper = new Mapper.TranscoderConfigMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerTranscoderConfigMapper;
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
                        
                        private Mapper.VideoStreamMapper innerVideoStreamMapper;
                        public override DashProject.Data.Providers.VideoStreamProvider VideoStreamProvider
                        {
                            get
                            {
                                if (innerVideoStreamMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (innerVideoStreamMapper == null)
                                        {
                                            innerVideoStreamMapper = new Mapper.VideoStreamMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return innerVideoStreamMapper;
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
                        
                        private Mapper.Custom.iLIBx264TranscoderConfigMapper inneriLIBx264TranscoderConfigMapper;
                        public override DashProject.Data.Providers.Custom.iLIBx264TranscoderConfigProvider iLIBx264TranscoderConfigProvider
                        {
                            get
                            {
                                if (inneriLIBx264TranscoderConfigMapper == null)
                                {
                                    lock (syncRoot)
                                    {
                                        if (inneriLIBx264TranscoderConfigMapper == null)
                                        {
                                            inneriLIBx264TranscoderConfigMapper = new Mapper.Custom.iLIBx264TranscoderConfigMapper(_connectionString);
                                        }
                                    }
                                }
                
                                return inneriLIBx264TranscoderConfigMapper;
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