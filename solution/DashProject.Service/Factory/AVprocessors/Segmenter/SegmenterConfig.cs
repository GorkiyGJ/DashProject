using DashProject.Api.Enum;
using DashProject.Api.Extension;
using DashProject.Service.Factory.AVprocessors.FFmpeg.FFmpegConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashProject.Service.Factory.AVprocessors.Segmenter
{
    public class SegmenterConfig : IFFmpegConfig
    {
        public bool IsForceKeyFrames;
        public int SegmentTime;
        public bool ResetTimeStamps;
        public bool IsUseSegmentTimeDelta;
        public float SegmentTimeDelta;
        public long StartNumber;
        public ContainerType SegmentContainer;

        public override string GetArgumentsString()
        {
            StringBuilder argumentsString = new StringBuilder();

            argumentsString.Append(" -c copy");

            if (IsForceKeyFrames)
                argumentsString.Append(" -force_key_frames expr:gte(t,n_forced*" + SegmentTime + ")");

            if (ResetTimeStamps)
                argumentsString.Append(" -reset_timestamps 1");

            argumentsString.Append(" -segment_time " + SegmentTime);

            if (IsUseSegmentTimeDelta && SegmentTimeDelta > 0)
                argumentsString.Append(" -segment_time_delta " + SegmentTimeDelta.ToStringJS());

            argumentsString.Append(" -segment_format " + SegmentContainer.GetContainerToForce());

            argumentsString.Append(" -segment_start_number " + StartNumber);

            return argumentsString.ToString();
        }
    }
}
