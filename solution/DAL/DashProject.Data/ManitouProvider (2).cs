using System;
using Manitou.Data.Provider;
using DashProject.Data.Providers;

namespace DashProject.Data
{
    public abstract class ManitouProvider : ManitouProviderBase
    {
    public abstract AACEncoderConfigProvider AACEncoderConfigProvider { get; }
                public abstract ApplicationConfigurationProvider ApplicationConfigurationProvider { get; }
                public abstract AspectRatioProvider AspectRatioProvider { get; }
                public abstract AudioStreamProvider AudioStreamProvider { get; }
                public abstract BroadcastTypeProvider BroadcastTypeProvider { get; }
                public abstract CodecProvider CodecProvider { get; }
                public abstract CodecToEncoderProvider CodecToEncoderProvider { get; }
                public abstract CodecTypeProvider CodecTypeProvider { get; }
                public abstract ContainerFormatProvider ContainerFormatProvider { get; }
                public abstract DashContainerFormatProvider DashContainerFormatProvider { get; }
                public abstract DashInitSegmentProvider DashInitSegmentProvider { get; }
                public abstract DashMediaProvider DashMediaProvider { get; }
                public abstract DashMediaSegmentProvider DashMediaSegmentProvider { get; }
                public abstract DashTypeProvider DashTypeProvider { get; }
                public abstract EncoderProvider EncoderProvider { get; }
                public abstract EncoderTypeProvider EncoderTypeProvider { get; }
                public abstract LanguageProvider LanguageProvider { get; }
                public abstract LIBx264EncoderConfigProvider LIBx264EncoderConfigProvider { get; }
                public abstract LIBx264EncoderPresetTypeProvider LIBx264EncoderPresetTypeProvider { get; }
                public abstract MediaProvider MediaProvider { get; }
                public abstract MediaOriginTypeProvider MediaOriginTypeProvider { get; }
                public abstract RawMediaProvider RawMediaProvider { get; }
                public abstract RawSegmentProvider RawSegmentProvider { get; }
                public abstract RawSegmentStreamProvider RawSegmentStreamProvider { get; }
                public abstract SegmenterConfigProvider SegmenterConfigProvider { get; }
                public abstract StreamProvider StreamProvider { get; }
                public abstract StreamTypeProvider StreamTypeProvider { get; }
                public abstract TranscoderConfigProvider TranscoderConfigProvider { get; }
                public abstract VideoSizeProvider VideoSizeProvider { get; }
                public abstract VideoStreamProvider VideoStreamProvider { get; }
    
        
    
    public abstract DashProject.Data.Providers.Custom.iDashMediaInfoProvider iDashMediaInfoProvider { get; }
                public abstract DashProject.Data.Providers.Custom.iLIBx264TranscoderConfigProvider iLIBx264TranscoderConfigProvider { get; }
                public abstract DashProject.Data.Providers.Custom.iMediaInfoProvider iMediaInfoProvider { get; }
                public abstract DashProject.Data.Providers.Custom.iSegmenterConfigProvider iSegmenterConfigProvider { get; }
                public abstract DashProject.Data.Providers.Custom.iStreamInfoProvider iStreamInfoProvider { get; }
    
    }
}