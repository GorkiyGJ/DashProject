using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashProject.Api;
using DashProject.Api.Enum;
using DashProject.Entity.Custom;


namespace DashProject.Service.Factory.Transcoders
{
    public class Transcoder_file_in_mpegts_x264_piped_out_fmp4_x264// : Transcoder<BytesData_TimeStamp>
    {
       /* private int? fragmentDurationS;
        private LIBx264EncoderPresetType? libx264PresetType;
        private byte threadsCount;
        private int? bitrateKbps;
        private bool? isUseConstantBitRate;
        private short? dWidth;
        private short? dHeight;
        private X264Profile? profile;
        private X264ProfileLevel? profileLevel;
        private bool? isUseConstantRateFactorForQualityManagement;
        private byte? crf;

        public Transcoder_file_in_mpegts_x264_piped_out_fmp4_x264(int dashMediaId)
           : base(false, true, false)
        {
            iLIBx264TranscoderConfig config = TranscoderApi.iLIBx264TranscoderConfig_Get_By_DashMedidiaId(dashMediaId);

            if (config == null)
                throw new Exception("cannot parse LIBx264 configuration!");

            fragmentDurationS = config.FragmentDurationS;
            StreamIndex = config.StreamIndex;
            threadsCount = config.ThreadsCount.Value;

            profile = (X264Profile)config.X264Profile;
            profileLevel = (X264ProfileLevel) config.X264ProfileLevel;
            libx264PresetType = (LIBx264EncoderPresetType)config.LIBx264EncoderPresetTypeId; //encoding speed, default is medium

            //manage quality
            //
            isUseConstantRateFactorForQualityManagement = config.isUseConstantRateFactorForQualityManagement.Value;
            //isUseConstantRateFactorForQualityManagement = true - if quality is important! This is default!
            crf = config.ConstantRateFactor.Value; //quality 0-51, where 0 is lossless, 23 is default, and 51 is worst possible
            //isUseConstantRateFactorForQualityManagement = false if file size is important
            bitrateKbps = config.BitrateKbps; //for avarage bitrate
            isUseConstantBitRate = config.IsUseConstantBitRate.Value; //for constant bitrate
            //

            dWidth = config.Width;
            dHeight = config.Height;
        }

        protected override Api.Enum.Decoder InputVideoDecoder
        {
            get { return Api.Enum.Decoder.h264; }
        }

        protected override Api.Enum.Decoder InputAudioDecoder
        {
            get { return Api.Enum.Decoder.none; }
        }

        protected override ContainerFormat InputContainerFormat
        {
            get { return ContainerFormat.mpegts; }
        }

        protected override Api.Enum.Encoder OutputVideoEncoder
        {
            get { return Api.Enum.Encoder.copy; }
        }

        protected override Api.Enum.Encoder OutputAudioEncoder
        {
            get { return Api.Enum.Encoder.none; }
        }

        protected override ContainerFormat OutputContainerFormat
        {
            get { return ContainerFormat.mp4; }
        }

        protected override string CustomArguments
        {
            get 
            {
                StringBuilder argumentsString = new StringBuilder();
               
                if (threadsCount > 0)
                    argumentsString.Append(" -threads " + threadsCount);

                argumentsString.Append(" -profile:v " + profile + " -level " + profileLevel.GetProfile());

                argumentsString.Append(" -preset " + libx264PresetType.ToString());

                if (isUseConstantRateFactorForQualityManagement)
                {
                    
                    argumentsString.Append(" -crf " + crf);
                    if (bitrateKbps.HasValue)
                    {
                        argumentsString.Append(" -maxrate " + bitrateKbps.Value + "k");
                        argumentsString.Append(" -bufsize 1835k");
                    }
                    
                }
                else if (bitrateKbps.HasValue)
                {
                    argumentsString.Append("-b " + bitrateKbps + "k");

                    if (isUseConstantBitRate)
                    {
                        string constantBitrateArg = " -minrate {0} -maxrate {1} -bufsize 1835k";
                        argumentsString.Append(string.Format(constantBitrateArg, bitrateKbps, bitrateKbps));
                    }
                }

                if (dWidth.HasValue && dHeight.HasValue)
                {
                    argumentsString.Append(" -vf scale=" + dWidth.ToString() + ":" + dHeight.ToString());
                }

                if (fragmentDurationS.HasValue)
                {
                    argumentsString.Append(" -min_frag_duration " + (fragmentDurationS * 1000000) * 0.2); //20% - 2sec
                    //argumentsString.Append(" -frag_duration " + fragmentDurationS/2 * 1000000); //5sec
                    argumentsString.Append(" -movflags empty_moov+frag_keyframe+default_base_moof");
                }

                return argumentsString.ToString();
            }
        }

        decimal startTime;
        public override void Transcode(Api.Data data)
        {
            if (data.Type == DataType.file_streams_ts)
            {
                FileData_TimeStamps fileData = data as FileData_TimeStamps;
                startTime = fileData.StreamsStartTs[StreamIndex.Value];
                InputMedia = fileData.File.FullName;
                Start();
            }
        }

        protected override BytesData_TimeStamp BytesToOutDataType(ref byte[] bytes)
        {
            return new BytesData_TimeStamp(bytes, startTime);
        }*/
    }
}
