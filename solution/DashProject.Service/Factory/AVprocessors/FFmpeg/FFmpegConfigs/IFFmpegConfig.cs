using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashProject.Service.Factory.AVprocessors.FFmpeg.FFmpegConfigs
{
    public interface IFFmpegConfig
    {
        public abstract string GetArgumentsString();
    }
}
