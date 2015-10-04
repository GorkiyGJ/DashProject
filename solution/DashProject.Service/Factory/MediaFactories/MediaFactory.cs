using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using DashProject.Api;
using DashProject.Service.Factory;
using System.Threading.Tasks.Dataflow;
using System.Diagnostics;
using DashProject.Api.Enum;
using DashProject.Api.Extension;
using DashProject.Entity.Custom;
using DashProject.Service.Factory.DashFactories;
using DashProject.Service.Factory.AVprocessors.Segmenter;
using DashProject.Service.Factory.AVprocessors;
using DashProject.Service.Factory.DataEntities;
using DashProject.Service.Factory.AVprocessors.FFmpeg;



namespace DashProject.Service.Factory.MediaFactories
{
    public class MediaFactory : MediaFactoryBase
    {
        private Segmenter segmenter;
        
        public MediaFactory(int mediaId, int? programIndex = null)
              :base(mediaId, programIndex)
        {
            iSegmenterConfig segmenterConfig = SegmenterConfigApi.iSegmenterConfig_Get_By_MediaId(mediaId);
            if (segmenterConfig == null)
            {
                this.OnLog("segmenterConfig == null", EventLogEntryType.Error);
                return;
            }
            
            FFmpegSetting ffmpegSetting = new FFmpegSetting()
            {
                InputMedia = segmenterConfig.InputMedia,
                OutputMedia = CoreApi.Get_RawMediaSegments_DirectoryPath(mediaId) + @"\%d." + ((ContainerType)segmenterConfig.RawMediaContainerTypeId.Value).GetFileExtension(),
                InputContainer = (ContainerType)segmenterConfig.RawMediaContainerTypeId.Value,
                OutputContainer = ContainerType.stream_segment,
                ProgramIndex = segmenterConfig.ProgramIndex,
                StreamsMaps = null,
                CustomConfig = new SegmenterConfig()
                {
                    IsForceKeyFrames = segmenterConfig.IsForceKeyFrames.Value,
                    SegmentTime = segmenterConfig.SegmentTime.Value,
                    ResetTimeStamps = segmenterConfig.ResetTimeStamps.Value,
                    IsUseSegmentTimeDelta = segmenterConfig.IsUseSegmentTimeDelta.Value,
                    SegmentTimeDelta = segmenterConfig.SegmentTimeDelta.Value,
                    StartNumber = segmenterConfig.StartNumber.HasValue ? segmenterConfig.StartNumber.Value : 1,
                    SegmentContainer = (ContainerType)segmenterConfig.RawMediaContainerTypeId
                }
            };


            segmenter = new Segmenter(ffmpegSetting);
            segmenter.LogEvent += this.OnLog;
            segmenter.FileOutputReceived += OnSegmenterFileOutputReceived;
            segmenter.StatusChanged += OnSegmenterStatusChanged;
        }

        private void OnSegmenterStatusChanged(FFmpegProcessStatus status)
        {
            foreach (DashFactory dashFactory in DashFactories)
            {
                if (status == FFmpegProcessStatus.RunningWithWarnings)
                    dashFactory.Status = FactoryStatus.RunningWithWarnings;

                if (status == FFmpegProcessStatus.Stopped)
                    dashFactory.Stop();
            }
                
        }

        private void OnSegmenterFileOutputReceived(FileData fileData)
        {
           /* try
            {
                FFprobeApi.MediaInfo rawSegmentInfo = FFprobeApi.GetMediaInfo(fileData.File.FullName, ProgramIndex);
                if (rawSegmentInfo == null || !rawSegmentInfo.DurationS.HasValue || !rawSegmentInfo.ContainerType.HasValue || rawSegmentInfo.Streams == null || rawSegmentInfo.Streams.Count == 0)
                    throw new Exception("");

                Dictionary<int, decimal> streamsStartTs = new Dictionary<int, decimal>();
                Dictionary<int, Api.Enum.CodecType> streamsCodec = new Dictionary<int, Api.Enum.CodecType>();

                int segmentId = int.Parse(Path.GetFileNameWithoutExtension(fileData.File.FullName));
                foreach (FFprobeApi.MediaInfo.StreamInfo streamInfo in rawSegmentInfo.Streams)
                {
                    iStreamInfo iStreamInfo = SegmenterApi.iStreamInfo_Get_By_MediaId_StreamIndex(MediaId, streamInfo.Index);

                    if (iStreamInfo == null)
                        continue;

                    RawSegmentStream segmentStream = new RawSegmentStream();
                    segmentStream.MediaId = MediaId;
                    segmentStream.StreamId = iStreamInfo.Id.Value;
                    segmentStream.FileName = fileData.File.Name;
                    segmentStream.DurationS = streamInfo.DurationS.Value;
                    segmentStream.GlobalStartTimeS = iStreamInfo.GlobalEndTimeS.Value;
                    segmentStream.GlobalEndTimeS = segmentStream.GlobalStartTimeS + segmentStream.DurationS;
                    segmentStream.DateTimeCreated = DateTime.Now;
                    segmentStream.SegmentId = segmentId;
                    SegmenterApi.RawSegmentStream_Insert(segmentStream);
                    streamsStartTs.Add(streamInfo.Index, iStreamInfo.GlobalEndTimeS.Value);
                    streamsCodec.Add(streamInfo.Index, streamInfo.Codec.Value);
                }

                InputDataBuffer.Post(new FileData_TimeStamps(fileData.File, streamsStartTs));
            }
            catch (Exception ex)
            {
                LogEvent(ex.Message, EventLogEntryType.Error);
                System.IO.File.Delete(fileData.File.FullName);
                return;
            }
            * */
        }

        public override void Start()
        {
            segmenter.Start();
            base.Start();
        }

        public override void Stop(bool isWaitForTasksDone = true)
        {
            segmenter.Stop();
            base.Stop(isWaitForTasksDone);
        }
    }
}
