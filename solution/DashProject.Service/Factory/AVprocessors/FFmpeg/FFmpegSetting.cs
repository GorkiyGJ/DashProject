using DashProject.Api.Enum;
using DashProject.Service.Factory.AVprocessors.FFmpeg.FFmpegConfigs;
using System;

namespace DashProject.Service.Factory.AVprocessors.FFmpeg
{
    public class FFmpegSetting
    {
        public string InputMedia;
        public string OutputMedia;
        public ContainerType InputContainer;
        public ContainerType OutputContainer;
        public int? ProgramIndex;
        public StreamMap[] StreamsMaps;
        public IFFmpegConfig CustomConfig;

        public class StreamMap
        {
            public byte StreamIndex;
            public StreamType streamType;
            public DecoderType Decoder;
            public EncoderType Encoder;
            public EncoderConfig EncoderConfig;
            public IFFmpegConfig[] CustomConfigs;
        }
    }
}
