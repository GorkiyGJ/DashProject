using System;
using System.Collections.Generic;
using DashProject.Api.Enum;
using DashProject.Entity.Custom;
using DashProject.Repository;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.IO;
using DashProject.Api.Extension;

namespace DashProject.Api
{
    public static class TranscoderApi
    {
        /*#region iLIBx264TranscoderConfig_Get_By_DashMedidiaId
        public static iLIBx264TranscoderConfig iLIBx264TranscoderConfig_Get_By_DashMedidiaId(int dashMediaId)
        {
            List<iLIBx264TranscoderConfig> items = Factory.iLIBx264TranscoderConfig.Get_By_DashMedidiaId(dashMediaId);

            return items != null && items.Count > 0 ? items[0] : null;
        }
        #endregion*/

        #region iLIBx264EncoderConfig_Get_By_DashMedidiaId
        public static iLIBx264EncoderConfig iLIBx264EncoderConfig_Get_By_DashMediaId(int dashMediaId)
        {
            List<iLIBx264EncoderConfig> items = Factory.iLIBx264EncoderConfig.Get_By_DashMediaId(dashMediaId);
            return items != null && items.Count > 0 ? items[0] : null;
        }
        #endregion


        #region LIBx264EncoderConfig_Get_By_dashMedidiaId
        public static iLIBx264EncoderConfig LIBx264EncoderConfig_Get_By_DashMedidiaId(int dashMediaId)
        {
            iLIBx264EncoderConfig item = iLIBx264EncoderConfig_Get_By_DashMediaId(dashMediaId);
            if (item == null)
                return null;
            return item;
        }
        /*
        private static FFmpegConfigApi.LIBx264EncoderConfig LIBx264EncoderConfig_Get_By_iLIBx264EncoderConfig(iLIBx264EncoderConfig item)
        {
            FFmpegConfigApi.LIBx264EncoderConfig encoderConfig =  new FFmpegConfigApi.LIBx264EncoderConfig()
            {
                ThreadsCount = item.ThreadsCount.Value,
                BitrateKbps = item.BitrateKbps,
                LIBx264EncoderPresetType = (LIBx264EncoderPresetType)item.LIBx264EncoderPresetTypeId,
                X264Profile = (X264Profile)item.X264ProfileId,
                X264ProfileLevel = (X264ProfileLevel)item.X264ProfileLevelId,
                IsUseConstantBitRate = item.IsUseConstantBitRate.Value,
                IsUseConstantRateFactorForQualityManagement = item.IsUseConstantRateFactorForQualityManagement.Value,
                ConstantRateFactor = item.ConstantRateFactor.Value,
                ScaleVideoFilter = ScaleVideoFilter_Get_By_DashMediaId(item.DashMediaId.Value)
            };

            return encoderConfig;
        }
        #endregion
        */

        #region iScaleVideoFilter_Get_By_DashMediaId
        public static iScaleVideoFilter iScaleVideoFilter_Get_By_DashMediaId(int dashMediaId)
        {
             List<iScaleVideoFilter> items = Factory.iScaleVideoFilter.Get_By_DashMediaId(dashMediaId);
            return items != null && items.Count > 0 ? items[0] : null;
        }
        #endregion

        #region  ScaleVideoFilter_Get_By_DashMediaId
        public static iScaleVideoFilter ScaleVideoFilter_Get_By_DashMediaId(int dashMediaId)
        {
            iScaleVideoFilter item = iScaleVideoFilter_Get_By_DashMediaId(dashMediaId);
            if(item == null)
                return null;
            return item
        }
        /*
        private static FFmpegConfigApi.ScaleVideoFilter ScaleVideoFilter_Get_By_iScaleVideoFilter(iScaleVideoFilter item)
        {
            return new FFmpegConfigApi.ScaleVideoFilter()
            {
                Width = item.Width.Value,
                Height = item.Height.Value
            };
        }*/
        #endregion


        #region iTranscoderConfig_Get_By_DashMediaId
        public static iTranscoderConfig iTranscoderConfig_Get_By_DashMediaId(int dashMediaId)
        {
            List<iTranscoderConfig> items = Factory.iTranscoderConfig.Get_By_DashMediaId(dashMediaId);
            return items != null && items.Count > 0 ? items[0] : null;
        }
        #endregion

        #region
        public static DashFactoryTranscoder DashFactoryTranscoder_Get_By_DashMediaId(int dashMediaId)
        {
            iTranscoderConfig transcoderConfig = iTranscoderConfig_Get_By_DashMediaId(dashMediaId);

            FFmpegConfigApi.EncoderConfig encoderConfig = null;
            
            EncoderType encoder = ((CodecType)transcoderConfig.DashMediaCodecId).GetEncoderType();
            
            if(encoder == EncoderType.libx264)
                encoderConfig = LIBx264EncoderConfig_Get_By_DashMedidiaId(dashMediaId);

            FFmpegApi.FFmpegSetting.StreamMap streamsMap = new FFmpegApi.FFmpegSetting.StreamMap()
            {
                StreamIndex = transcoderConfig.StreamIndex.Value,
                streamType = (StreamType)transcoderConfig.StreamTypeId,
                Decoder = ((CodecType)transcoderConfig.RawMediaCodecId).GetDecoderType(),
                Encoder = encoderConfig != null ? encoder : EncoderType.copy,
                EncoderConfig = encoderConfig
            };

            FFmpegConfigApi.Mp4FragmentationConfig mp4FragmentationConfig = new  FFmpegConfigApi.Mp4FragmentationConfig()
            {
                FragmentDurationS = transcoderConfig.FragmentDurationS.Value
            };

            FFmpegApi.FFmpegSetting ffmpegSettig = new FFmpegApi.FFmpegSetting()
            {
                InputContainer = (ContainerType)transcoderConfig.InputContainerId,
                OutputContainer = (ContainerType)transcoderConfig.OutputContainerId,
                ProgramIndex = transcoderConfig.ProgramIndex,
                StreamsMaps = new FFmpegApi.FFmpegSetting.StreamMap[] 
                {
                    streamsMap
                },
                CustomConfig = mp4FragmentationConfig
            };

            DashFactoryTranscoder transcoder = new DashFactoryTranscoder(ffmpegSettig);
            return transcoder;
        }
        #endregion

        public class DashFactoryTranscoder : Transcoder<FileData_TimeStamps, BytesData_TimeStamp>
        {
            private int streamIndex;

            public DashFactoryTranscoder(FFmpegApi.FFmpegSetting ffmpegSetting)
                : base(ffmpegSetting)
            {
                streamIndex = ffmpegSetting.StreamsMaps[0].StreamIndex;
            }
            
            private decimal streamStartTs;

            public override void Transcode(FileData_TimeStamps data)
            {
                FileData_TimeStamps fileData = data as FileData_TimeStamps;

                streamStartTs = data.StreamsStartTs[streamIndex];

                InputMedia = fileData.File.FullName;
                Start();
            }

            protected override BytesData_TimeStamp BytesToOutDataType(ref byte[] bytes)
            {
                return new BytesData_TimeStamp(bytes, streamStartTs);
            }
        }

        public abstract class Transcoder<inDataType,outDataType> : FFmpegApi.FFmpegProcess_piped
            where outDataType : DashProject.Api.Data
            where inDataType : DashProject.Api.Data
        {
            public BufferBlock<outDataType> OutputDataBuffer;

            public Transcoder(FFmpegApi.FFmpegSetting ffmpegSetting, bool isUsePipeIn = false, bool isUsePipeOut = true, bool isPartillyOuput = false)
                : base(ffmpegSetting, isUsePipeIn, isUsePipeOut, isPartillyOuput)
            {
                OutputDataBuffer = new BufferBlock<outDataType>();
            }

            
            public abstract void Transcode(inDataType data);
            

            protected sealed override void BytesOutputReceived(ref byte[] bytes)
            {
                outDataType data = BytesToOutDataType(ref bytes);
                OutputDataBuffer.Post(data);
            }

            protected abstract outDataType BytesToOutDataType(ref byte[] bytes);
            

            public new void Stop(bool isWaitForTasksDone = true)
            {
                if (isWaitForTasksDone)
                {
                    OutputDataBuffer.Complete();
                    OutputDataBuffer.Completion.Wait();
                }
                base.Stop(true);
            }
        }      
    }
    
}
