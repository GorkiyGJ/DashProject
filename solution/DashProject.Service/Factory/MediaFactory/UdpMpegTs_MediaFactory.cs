using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using DashProject.Api;
using DashProject.Api.Enum;
using DashProject.Data;
using DashProject.Entity;
using DashProject.Entity.Custom;
using DashProject.Service.Factory.Dash;

namespace DashProject.Service.Factory
{
    public class UdpMpegTs_MediaFactory: MediaFactory
    {
        private SegmenterApi.Segmenter segmenter;

        public UdpMpegTs_MediaFactory(iMediaInfo mediaInfo)
            : base(mediaInfo)
        {
            segmenter = new SegmenterApi.Segmenter(MediaId);
            segmenter.FileOutputReceived += segmenter_FileOutputReceived;
            segmenter.LogEvent += (message, logType) => { LogEvent(message, logType); };

            foreach (DashFactory dashFactory in DashFactories)
                segmenter.StatusChanged += status =>
                {
                    if (status == FFmpegProcessStatus.RunningWithWarnings)
                        dashFactory.Status = FactoryStatus.RunningWithWarnings;

                    if(status == FFmpegProcessStatus.Stopped)
                        dashFactory.Stop();
                };
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

        private void segmenter_FileOutputReceived(FileData fileData)
        {
            try
            {
                FFprobeApi.MediaInfo rawSegmentInfo = FFprobeApi.GetMediaInfo(fileData.File.FullName, ProgramIndex);
                if (rawSegmentInfo == null || !rawSegmentInfo.DurationS.HasValue|| !rawSegmentInfo.ContainerType.HasValue || rawSegmentInfo.Streams == null || rawSegmentInfo.Streams.Count == 0)
                    throw new Exception("");

                Dictionary<int, decimal> streamsStartTs = new Dictionary<int,decimal>();
                Dictionary<int, Api.Enum.CodecType> streamsCodec = new Dictionary<int,Api.Enum.CodecType>();

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
        }
    }
}
