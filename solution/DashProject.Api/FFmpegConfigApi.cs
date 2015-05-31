using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashProject.Api.Enum;
using DashProject.Api.Extension;

namespace DashProject.Api
{
    public static class FFmpegConfigApi
    {
        public abstract class FFmpegConfig
        {
            public abstract string GetArgumentsString();
        }

        public class SegmenterConfig : FFmpegConfig
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

        public class ScaleVideoFilter : FFmpegConfig
        {
            public Int16 Width;
            public Int16 Height;

            public override string GetArgumentsString()
            {
                return " -vf scale=" + Width.ToString() + ":" + Height.ToString();
            }
        }

        public abstract class EncoderConfig : FFmpegConfig
        {
            public Int16 ThreadsCount;
            public int? BitrateKbps;
            public abstract EncoderType GetType();
        }

        public class LIBx264EncoderConfig : EncoderConfig
        {
            public LIBx264EncoderPresetType LIBx264EncoderPresetType;
            public X264Profile X264Profile;
            public X264ProfileLevel X264ProfileLevel;
            public bool IsUseConstantBitRate;
            public bool IsUseConstantRateFactorForQualityManagement;
            public int ConstantRateFactor;
            public ScaleVideoFilter ScaleVideoFilter;

            public override EncoderType GetType()
            {
                return EncoderType.libx264;
            }

            public override string GetArgumentsString()
            {
                StringBuilder argumentsString = new StringBuilder();

                if (ThreadsCount > 0)
                    argumentsString.Append(" -threads " + ThreadsCount);

                argumentsString.Append(" -profile:v " + X264Profile + " -level " + X264ProfileLevel.GetProfile());

                argumentsString.Append(" -preset " + LIBx264EncoderPresetType);

                if (IsUseConstantRateFactorForQualityManagement)
                {

                    argumentsString.Append(" -crf " + ConstantRateFactor);
                    if (BitrateKbps.HasValue)
                    {
                        argumentsString.Append(" -maxrate " + BitrateKbps.Value + "k");
                        argumentsString.Append(" -bufsize 1835k");
                    }

                }
                else if (BitrateKbps.HasValue)
                {
                    argumentsString.Append("-b " + BitrateKbps + "k");

                    if (IsUseConstantBitRate)
                    {
                        string constantBitrateArg = " -minrate {0} -maxrate {1} -bufsize 1835k";
                        argumentsString.Append(string.Format(constantBitrateArg, BitrateKbps, BitrateKbps));
                    }
                }

                if (ScaleVideoFilter != null)
                    ScaleVideoFilter.GetArgumentsString();

                return argumentsString.ToString();
            }
        }

        public abstract class FragmentationConfig : FFmpegConfig
        {
            public int FragmentDurationS;
        }

        public class Mp4FragmentationConfig : FragmentationConfig
        {
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
