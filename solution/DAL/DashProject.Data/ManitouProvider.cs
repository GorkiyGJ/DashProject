using System;
using Manitou.Data.Provider;
using DashProject.Data.Providers;

namespace DashProject.Data
{
    public abstract class ManitouProvider : ManitouProviderBase
    {
    public abstract AACTranscoderConfigProvider AACTranscoderConfigProvider { get; }
                public abstract ApplicationConfigurationProvider ApplicationConfigurationProvider { get; }
                public abstract AspectRatioProvider AspectRatioProvider { get; }
                public abstract BroadcastTypeProvider BroadcastTypeProvider { get; }
                public abstract CodecMediaTypeProvider CodecMediaTypeProvider { get; }
                public abstract CodecToEncoderProvider CodecToEncoderProvider { get; }
                public abstract CodecTypeProvider CodecTypeProvider { get; }
                public abstract ContainerTypeProvider ContainerTypeProvider { get; }
                public abstract DashInitSegmentProvider DashInitSegmentProvider { get; }
                public abstract DashMediaProvider DashMediaProvider { get; }
                public abstract DashMediaSegmentProvider DashMediaSegmentProvider { get; }
                public abstract DashTypeProvider DashTypeProvider { get; }
                public abstract DecoderTypeProvider DecoderTypeProvider { get; }
                public abstract EncoderTypeProvider EncoderTypeProvider { get; }
                public abstract LanguageProvider LanguageProvider { get; }
                public abstract LIBx264EncoderConfigProvider LIBx264EncoderConfigProvider { get; }
                public abstract LIBx264EncoderPresetTypeProvider LIBx264EncoderPresetTypeProvider { get; }
                public abstract MediaProvider MediaProvider { get; }
                public abstract RawMediaProvider RawMediaProvider { get; }
                public abstract RawMediaSourceTypeProvider RawMediaSourceTypeProvider { get; }
                public abstract RawSegmentStreamProvider RawSegmentStreamProvider { get; }
                public abstract ScaleVideoFilterProvider ScaleVideoFilterProvider { get; }
                public abstract SegmenterConfigProvider SegmenterConfigProvider { get; }
                public abstract StreamProvider StreamProvider { get; }
                public abstract StreamTypeProvider StreamTypeProvider { get; }
                public abstract VideoSizeProvider VideoSizeProvider { get; }
                public abstract X264ProfileProvider X264ProfileProvider { get; }
                public abstract X264ProfileLevelProvider X264ProfileLevelProvider { get; }
    
        
    
    public abstract DashProject.Data.Providers.Custom.iTranscoderConfigProvider iTranscoderConfigProvider { get; }
                public abstract DashProject.Data.Providers.Custom.iLIBx264EncoderConfigProvider iLIBx264EncoderConfigProvider { get; }
                public abstract DashProject.Data.Providers.Custom.iScaleVideoFilterProvider iScaleVideoFilterProvider { get; }
                public abstract DashProject.Data.Providers.Custom.iDashMediaInfoProvider iDashMediaInfoProvider { get; }
                public abstract DashProject.Data.Providers.Custom.iSegmenterConfigProvider iSegmenterConfigProvider { get; }
                public abstract DashProject.Data.Providers.Custom.iMediaInfoProvider iMediaInfoProvider { get; }
                public abstract DashProject.Data.Providers.Custom.iStreamInfoProvider iStreamInfoProvider { get; }
    
    }
}