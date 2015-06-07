using System;

namespace DashProject.Service.Factory.AVprocessors.FFmpeg.FFmpegConfigs
{
    public class ScaleVideoFilter : IFFmpegConfig
    {
        public Int16 Width;
        public Int16 Height;

        public override string GetArgumentsString()
        {
            return " -vf scale=" + Width.ToString() + ":" + Height.ToString();
        }
    }
}
