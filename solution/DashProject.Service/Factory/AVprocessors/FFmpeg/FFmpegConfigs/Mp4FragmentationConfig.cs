using System;
using System.Text;

namespace DashProject.Service.Factory.AVprocessors.FFmpeg.FFmpegConfigs
{
    public static class FFmpegConfigApi
    {
        public class Mp4FragmentationConfig : IFFmpegConfig
        {
            public int FragmentDurationS;
            public override string GetArgumentsString()
            {
                StringBuilder argumentsString = new StringBuilder();
                argumentsString.Append(" -min_frag_duration " + (FragmentDurationS * 1000000) * 0.2); //20% - 2sec
                //argumentsString.Append(" -frag_duration " + fragmentDurationS/2 * 1000000); //5sec
                argumentsString.Append(" -movflags empty_moov+frag_keyframe+default_base_moof");
                return argumentsString.ToString();
            }
        }
    }
}
