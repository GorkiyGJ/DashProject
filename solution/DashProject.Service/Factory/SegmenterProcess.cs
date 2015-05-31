using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using DashProject.Api;
using DashProject.Api.Enum;
using DashProject.Data;
using DashProject.Entity;
using DashProject.Entity.Custom;
using DashProject.Service.Factory.Transcoders;
using DashProject.Utils;
using DashProject.Api.Extension;
using Manitou.Data.Provider;

namespace DashProject.Service.Factory
{
    public class SegmenterProcess// : DashProject.Api.FFmpegApi.FFmpegProcess
    {
       /* private bool isForceKeyFrames;
        private int segmentTime;
        private bool resetTimeStamps;
        private bool useSegmentTimeDelta;
        private float segmentTimeDelta;
        private FileSystemWatcher fileWatcher;
        private Queue<string> segmentsFilesQueue;
        private long startNumber;
        private Api.Enum.ContainerType containerType;

        public SegmenterProcess(iSegmenterConfig config)
            : base()
        {         
            if(config == null)
                throw new Exception();
            this.InputMedia = config.InputMedia;
            this.ProgramIndex = config.ProgramIndex;
            this.containerType = (Api.Enum.ContainerType)config.ContainerFormatId.Value;
            this.OutputMedia = CoreApi.Get_RawSegments_DirectoryPath(config.MediaId.Value) + @"\%d." + containerType.GetFileExtension();
            this.isForceKeyFrames = config.IsForceKeyFrames.Value;
            this.segmentTime = config.SegmentTime.Value;
            this.resetTimeStamps = config.ResetTimeStamps.Value;
            this.useSegmentTimeDelta = config.UseSegmentTimeDelta.Value;
            this.segmentTimeDelta = config.SegmentTimeDelta.Value;
            this.startNumber = config.StartNumber.HasValue ? config.StartNumber.Value : 1;
            /*this.StartInfo.RedirectStandardInput = false;
            this.StartInfo.RedirectStandardOutput = false;
            this.StartInfo.StandardOutputEncoding = null;*/
        /*
            fileWatcher = new FileSystemWatcher(CoreApi.Get_RawSegments_DirectoryPath(config.MediaId.Value));
            fileWatcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.FileName;
            fileWatcher.Filter = "*.*";
            fileWatcher.Created += fileWatcher_Created;
            segmentsFilesQueue = new Queue<string>();
        }

        /*
        protected override DecoderType InputVideoDecoder
        {
            get { return Api.Enum.Decoder.none; }
        }

        protected override Api.Enum.Decoder InputAudioDecoder
        {
            get { return Api.Enum.Decoder.none; }
        }

        protected override Api.Enum.Encoder OutputVideoEncoder
        {
            get { return Api.Enum.Encoder.copy; }
        }

        protected override Api.Enum.Encoder OutputAudioEncoder
        {
            get { return Api.Enum.Encoder.copy; }
        }

        protected override Api.Enum.ContainerType InputContainerFormat
        {
            get { return Api.Enum.ContainerType.mpegts; }
        }

        protected override Api.Enum.ContainerType OutputContainerFormat
        {
            get { return Api.Enum.ContainerType.stream_segment; }
        }
        */

      /*  protected override string CustomArguments
        {
            get 
            {
                StringBuilder argumentsString = new StringBuilder();

                if (isForceKeyFrames)
                    argumentsString.Append(" -force_key_frames expr:gte(t,n_forced*" + segmentTime + ")");

                if (resetTimeStamps)
                    argumentsString.Append(" -reset_timestamps 1");

                argumentsString.Append(" -segment_time " + segmentTime);

                if (useSegmentTimeDelta && segmentTimeDelta > 0)
                    argumentsString.Append(" -segment_time_delta " + segmentTimeDelta.ToStringJS());

                argumentsString.Append(" -segment_format " + containerType.GetContainerToForce());

                argumentsString.Append(" -segment_start_number " + startNumber);

                return argumentsString.ToString();
            }
        }

        public new bool Start()
        {
            fileWatcher.EnableRaisingEvents = true;
            bool isStarted = base.Start();
            return isStarted;
        }

        public new void Stop()
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
        public event FileOutputReceivedEventHandler FileOutputReceived = delegate { }; // add empty delegate!;*/
    }
}
