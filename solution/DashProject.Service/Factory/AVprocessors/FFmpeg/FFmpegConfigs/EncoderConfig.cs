using DashProject.Api.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashProject.Service.Factory.AVprocessors.FFmpeg.FFmpegConfigs
{
    public abstract class EncoderConfig : IFFmpegConfig
    {
        public Int16 ThreadsCount;
        public int? BitrateKbps;
        public abstract EncoderType GetType();

        public abstract string GetArgumentsString();

    }
}
