using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DashProject.Repository;
using DashProject.Entity.Custom;
using DashProject.Entity;
using Manitou.Data.Provider;
using System.IO;
using DashProject.Api.Extension;

namespace DashProject.Api
{
    public static class SegmenterApi
    {

        #region iSegmenterConfig_Get_By_MediaId
        public static iSegmenterConfig iSegmenterConfig_Get_By_MediaId(int mediaId)
        {
            List<iSegmenterConfig> config = Factory.iSegmenterConfig.Get_By_MediaId(mediaId);
            return config != null ? config[0] : null;
        }
        #endregion 

        #region SegmenterProcess_Get_SegmenterProcess
        public static FFmpegApi.FFmpegProcess Get_SegmenterProcess(int mediaId)
        {
            iSegmenterConfig item = iSegmenterConfig_Get_By_MediaId(mediaId);
            if (item == null)
                return null;

            FFmpegApi.FFmpegSetting ffmpegSetting = new FFmpegApi.FFmpegSetting()
            {
                InputMedia = item.InputMedia,
                OutputMedia = CoreApi.Get_RawSegments_DirectoryPath(mediaId) + @"\%d." + ((Enum.ContainerType)item.RawMediaContainerTypeId).GetFileExtension(),
                InputContainer = (Enum.ContainerType) item.RawMediaContainerTypeId.Value,
                OutputContainer = Enum.ContainerType.stream_segment,
                ProgramIndex = null,
                StreamsMaps = null,
                CustomConfig = new FFmpegConfigApi.SegmenterConfig()
                {
                    IsForceKeyFrames = item.IsForceKeyFrames.Value,
                    SegmentTime = item.SegmentTime.Value,
                    ResetTimeStamps = item.ResetTimeStamps.Value,
                    IsUseSegmentTimeDelta = item.IsUseSegmentTimeDelta.Value,
                    SegmentTimeDelta = item.SegmentTimeDelta.Value,
                    StartNumber = item.StartNumber.HasValue ? item.StartNumber.Value : 1,
                    SegmentContainer = (Enum.ContainerType)item.RawMediaContainerTypeId.Value
                } 
            };

            return new FFmpegApi.FFmpegProcess(ffmpegSetting);
        }
        #endregion

        #region iStreamInfo_Get_By_MediaId_StreamIndex
        public static iStreamInfo iStreamInfo_Get_By_MediaId_StreamIndex(int mediaId, int index)
        {
            List<iStreamInfo> items = Factory.iStreamInfo.Get_By_MediaId_StreamIndex(mediaId, index);
            return (items != null && items.Count > 0) ? items[0] : null;
        }
        #endregion

        #region
        public static void RawSegmentStream_Insert(RawSegmentStream item)
        {
            Factory.RawSegmentStream.Insert(item);
        }
        #endregion

        public class Segmenter : FFmpegApi.FFmpegProcess
        {
            private FileSystemWatcher fileWatcher;
            private Queue<string> segmentsFilesQueue;

            protected static FFmpegApi.FFmpegSetting Get_FFmpegSettings(int mediaId)
            {
                iSegmenterConfig item = iSegmenterConfig_Get_By_MediaId(mediaId);
                if (item == null)
                    return null;

                FFmpegApi.FFmpegSetting ffmpegSetting = new FFmpegApi.FFmpegSetting()
                {
                    InputMedia = item.InputMedia,
                    OutputMedia = CoreApi.Get_RawSegments_DirectoryPath(mediaId) + @"\%d." + ((Enum.ContainerType)item.RawMediaContainerTypeId.Value).GetFileExtension(),
                    InputContainer = (Enum.ContainerType)item.RawMediaContainerTypeId.Value,
                    OutputContainer = Enum.ContainerType.stream_segment,
                    ProgramIndex = item.ProgramIndex,
                    StreamsMaps = null,
                    CustomConfig = new FFmpegConfigApi.SegmenterConfig()
                    {
                        IsForceKeyFrames = item.IsForceKeyFrames.Value,
                        SegmentTime = item.SegmentTime.Value,
                        ResetTimeStamps = item.ResetTimeStamps.Value,
                        IsUseSegmentTimeDelta = item.IsUseSegmentTimeDelta.Value,
                        SegmentTimeDelta = item.SegmentTimeDelta.Value,
                        StartNumber = item.StartNumber.HasValue ? item.StartNumber.Value : 1,
                        SegmentContainer = (Enum.ContainerType)item.RawMediaContainerTypeId
                    } 
                };

                return ffmpegSetting;
            }

            public Segmenter(int mediaId)
                : base(Get_FFmpegSettings(mediaId))
            {
                fileWatcher = new FileSystemWatcher(CoreApi.Get_RawSegments_DirectoryPath(mediaId));
                fileWatcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.FileName;
                fileWatcher.Filter = "*.*";
                fileWatcher.Created += fileWatcher_Created;
                segmentsFilesQueue = new Queue<string>();
            }

            public bool Start()
            {
                fileWatcher.EnableRaisingEvents = true;
                bool isStarted = base.Start();
                return isStarted;
            }

            public void Stop()
            {
                fileWatcher.EnableRaisingEvents = false;
                fileWatcher.Dispose();
                base.Stop(2000);
            }

            private void fileWatcher_Created(object sender, FileSystemEventArgs e)
            {
                segmentsFilesQueue.Enqueue(e.FullPath);

                if (segmentsFilesQueue.Count == 1)
                    return;

                string filePath = segmentsFilesQueue.Dequeue();

                FileOutputReceived(new FileData(new FileInfo(filePath)));
            }

            public delegate void FileOutputReceivedEventHandler(FileData file);
            public event FileOutputReceivedEventHandler FileOutputReceived = delegate { }; // add empty delegate!;
        }
    }
}
