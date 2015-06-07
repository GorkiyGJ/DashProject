using DashProject.Api.Enum;
using System;
using System.Text;
using DashProject.Api.Extension;


namespace DashProject.Service.Factory.AVprocessors.FFmpeg.FFmpegConfigs
{
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
}
