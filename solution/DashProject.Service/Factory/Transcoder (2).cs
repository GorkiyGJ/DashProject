using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using DashProject.Api;
using DashProject.Api.Enum;
using DashProject.Entity.Custom;

namespace DashProject.Service.Factory
{
    public abstract class Transcoder : FFmpegProcess
    {
        protected int? fragmentDurationS;
        protected LIBx264EncoderPresetType libx264PresetType;
        protected byte threadsCount;
        protected int? bitrateBpS;
        protected bool isUseConstantBitRate;
        protected bool isUseOriginalVideoSize;
        protected short? dWidth;
        protected short? dHeight;

        public ActionBlock<IData> ProcessQueue;

        public Transcoder(int dashMediaId, bool isPartillyOuput)
            : base(isPartillyOuput) {

                iLIBx264TranscoderConfig config = TranscoderApi.LIBx264TranscoderConfig_Get_By_DashMedidiaId(dashMediaId);
                dContainerFormat = ContainerFormat.mp4;
                fragmentDurationS = config.FragmentDurationS;
                OutputEncoder = (DashProject.Api.Enum.Encoder)config.EncoderId;
                ProgramIndex = config.ProgramIndex;
                StreamIndex = config.StreamIndex;
                libx264PresetType = (LIBx264EncoderPresetType)config.LIBx264EncoderPresetTypeId;
                threadsCount = config.ThreadsCount.Value;
                isUseConstantBitRate = config.IsUseConstantBitRate.Value;
                bitrateBpS = config.BitrateBpS;
                isUseOriginalVideoSize = config.IsUseOriginalVideoSize.Value;
                dWidth = config.Width;
                dHeight = config.Height;
                ProcessQueue = new ActionBlock<IData>(new Action<IData>(ProcessQueueAction));
        }
        
        public abstract void ProcessQueueAction(IData data);
    }
}
