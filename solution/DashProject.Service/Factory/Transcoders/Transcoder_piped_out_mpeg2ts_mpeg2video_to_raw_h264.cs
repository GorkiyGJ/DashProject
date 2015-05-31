using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashProject.Api;
using DashProject.Api.Enum;
using DashProject.Entity.Custom;
using DashProject.Utils.Extension;

namespace DashProject.Service.Factory.Transcoders
{
    public class Transcoder_piped_out_mpeg2ts_mpeg2video_to_raw_h264 : Transcoder<TimeBasedFileData, TimeBasedBytesData>
    {
        public Transcoder_piped_out_mpeg2ts_mpeg2video_to_raw_h264(string pipeName/*, bool isPartillyOuput*/)
            : base(pipeName, false,true/*, isPartillyOuput*/)
        { }

        protected override Api.Enum.Decoder InputVideoDecoder
        {
            get { return Api.Enum.Decoder.mpeg2video; }
        }

        protected override Api.Enum.Decoder InputAudioDecoder
        {
            get { return Api.Enum.Decoder.none; }
        }

        protected override ContainerFormat InputContainerFormat
        {
            get { return Api.Enum.ContainerFormat.mpegts; }
        }

        protected override Api.Enum.Encoder OutputVideoEncoder
        {
            get { return Api.Enum.Encoder.libx264; }
        }

        protected override Api.Enum.Encoder OutputAudioEncoder
        {
            get { return Api.Enum.Encoder.none; }
        }

        protected override ContainerFormat OutputContainerFormat
        {
            get { return ContainerFormat.h264; }
        }

        protected override string CustomArguments
        {
            get 
            {
                StringBuilder argumentsString = new StringBuilder();

                //argumentsString.Append(" -q 1");

                /*if (threadsCount > 0)
                    argumentsString.Append(" -threads " + threadsCount);

                argumentsString.Append(" -preset " + libx264PresetType.ToString());

                if(bitrateBpS.HasValue)
                {
                    argumentsString.Append("-b " + bitrateBpS);

                    if (isUseConstantBitRate)
                    {
                        string constantBitrateArg = "-minrate {0} -maxrate {1} -bufsize {3}";
                        argumentsString.Append(string.Format(constantBitrateArg, bitrateBpS, bitrateBpS, bitrateBpS / 2));
                    }
                }

                if (!isUseOriginalVideoSize)
                {
                    argumentsString.Append(" -vf scale=" + dWidth.ToString() + ":" + dHeight.ToString());
                }

                argumentsString.Append(" -profile:v main -level 5.1");

                if (fragmentDurationS.HasValue)
                {
                    argumentsString.Append(" -frag_duration " + fragmentDurationS * 1000000);
                    argumentsString.Append(" -movflags empty_moov+frag_keyframe+default_base_moof");
                }*/

                //argumentsString.Append(" -blocksize 4096");
                return argumentsString.ToString();
                
            }
        }


        public override void ProcessQueueAction(FileData data)
        {
            InputMedia = data.Data.FullName;

            if (!Start())
                return;

            WaitWorkDone();
        }

        private int current_startTs;

        protected override TimeBasedBytesData BytesToOutDataType(byte[] bytes)
        {
            Queue<byte> bytesQueue = new Queue<byte>();
            for (int n = 0; n < bytes.Length; n++)
                bytesQueue.Enqueue(bytes[n]);

            return new TimeBasedBytesData() { Data = bytesQueue, StartTs = };
        }
    }
}
