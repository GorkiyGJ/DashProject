using DashProject.Api;
using DashProject.Api.Enum;
using DashProject.Api.Extension;
using DashProject.Service.Factory.AVprocessors.FFmpeg.FFmpegConfigs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DashProject.Service.Factory.AVprocessors.FFmpeg
{ 

    public class FFmpegProcess : Process
    {
        public FFmpegProcessStatus Status
        {
            get
            {
                return status;
            }
            private set
            {
                lock (statusLock)
                {
                    if (status == value)
                        return;
                    if (status == FFmpegProcessStatus.Stopped && value == FFmpegProcessStatus.RunningWithWarnings)
                        return;
                    status = value;
                    StatusChanged(value);
                }
            }
        }
        private FFmpegProcessStatus status;
        private object statusLock = new object();

        protected AutoResetEvent WorkDoneHandle;

        public void WaitWorkDone()
        {
            WorkDoneHandle.WaitOne();
            WorkDoneHandle.Reset();
        }

        private string argumentString
        {
            get
            {
                StringBuilder argumentsString = new StringBuilder();

                if (string.IsNullOrEmpty(InputMedia))
                    throw new Exception("Cannot start process, Input media is not defined!");

                if (string.IsNullOrEmpty(OutputMedia))
                    throw new Exception("Cannot start process, Output media is not defined!");

                if (ffmpegSetting.OutputContainer == ContainerType.none)
                    throw new Exception("Cannot start process, OutputContainer not defined!");

                argumentsString.Append("-v repeat+" + FFmpegLogLevel.error.ToString());
                argumentsString.Append(" -hide_banner");
                string overwriteOutputFiles = " -y";
                argumentsString.Append(overwriteOutputFiles);

                if (ffmpegSetting.InputContainer != ContainerType.none)
                    argumentsString.Append(" -f " + ffmpegSetting.InputContainer);

                if (ffmpegSetting.StreamsMaps != null && ffmpegSetting.StreamsMaps.Length > 0)
                    foreach (FFmpegSetting.StreamMap streamMap in ffmpegSetting.StreamsMaps)
                        if (streamMap.Decoder != DecoderType.none)
                            argumentsString.Append(" -c:" + streamMap.streamType.GetStreamSpecifier() + ":" + streamMap.StreamIndex + " " + streamMap.Decoder);

                argumentsString.Append(" -i " + InputMedia);

                if (ffmpegSetting.StreamsMaps == null || ffmpegSetting.StreamsMaps.Length == 0)
                    argumentsString.Append(" -map 0" + (ffmpegSetting.ProgramIndex.HasValue ? ":p:" + ffmpegSetting.ProgramIndex : string.Empty));

                if (ffmpegSetting.StreamsMaps != null && ffmpegSetting.StreamsMaps.Length > 0)
                    for (int n = 0; n < ffmpegSetting.StreamsMaps.Length; n++)
                    {
                        FFmpegSetting.StreamMap streamMap = ffmpegSetting.StreamsMaps[n];
                        argumentsString.Append(" -map 0" + (ffmpegSetting.ProgramIndex.HasValue ? ":p:" + ffmpegSetting.ProgramIndex : string.Empty) + ":" + streamMap.StreamIndex);
                        argumentsString.Append(" -c:" + streamMap.streamType.GetStreamSpecifier() + ":" + n + " " + streamMap.Encoder);

                        if (streamMap.EncoderConfig != null)
                            argumentsString.Append(" " + streamMap.EncoderConfig.GetArgumentsString());

                        if (streamMap.CustomConfigs != null && streamMap.CustomConfigs.Length > 0)
                            foreach (IFFmpegConfig config in streamMap.CustomConfigs)
                                argumentsString.Append(config.GetArgumentsString());
                    }

                if (ffmpegSetting.CustomConfig != null)
                    argumentsString.Append(ffmpegSetting.CustomConfig.GetArgumentsString());

                argumentsString.Append(" -f " + ffmpegSetting.OutputContainer.GetContainerToForce());

                argumentsString.Append(" " + OutputMedia);


                return argumentsString.ToString();
            }
        }

        private FFmpegSetting ffmpegSetting;
        protected string InputMedia;
        protected string OutputMedia;

        public FFmpegProcess(FFmpegSetting ffmpegSetting)
            : base()
        {
            this.ffmpegSetting = ffmpegSetting;
            InputMedia = ffmpegSetting.InputMedia;
            OutputMedia = ffmpegSetting.OutputMedia;
            StartInfo.RedirectStandardError = true;
            StartInfo.FileName = CoreApi.FFmpegFilePath;
            StartInfo.CreateNoWindow = true;
            StartInfo.ErrorDialog = false;
            StartInfo.UseShellExecute = false;
            EnableRaisingEvents = true;

            WorkDoneHandle = new AutoResetEvent(false);

            ErrorDataReceived += (sender, data) =>
            {
                if (string.IsNullOrEmpty(data.Data))
                    return;
                Status = FFmpegProcessStatus.RunningWithWarnings;
                LogEvent(data.Data, EventLogEntryType.Warning);
            };

            Exited += (sender, data) =>
            {
                Status = FFmpegProcessStatus.Stopped;
                if (data != null)
                    LogEvent(data.ToString(), EventLogEntryType.Information);
            };

            //LogEvent += OnLog;

        }

        public new bool Start()
        {
            WorkDoneHandle.Reset();
            Refresh();
            try
            {
                StartInfo.Arguments = argumentString;
            }
            catch (Exception ex)
            {
                LogEvent(ex.Message, EventLogEntryType.Error);
                return false;
            }

            bool isStarted = base.Start();
            if (isStarted)
            {
                BeginErrorReadLine();
                Status = FFmpegProcessStatus.Running;
            }
            else
                LogEvent("FFmpeg process do not started! Info: " + ToString(), EventLogEntryType.Error);

            return isStarted;
        }

        public void Stop(bool disposing = true)
        {
            Stop(null, disposing);
        }

        public void Stop(int? waitForExitS, bool disposing = true)
        {
            if (Status != FFmpegProcessStatus.Stopped)
                if (Responding)
                {
                    if (!waitForExitS.HasValue)
                        WaitForExit();
                    else
                    {
                        WaitForExit(waitForExitS.Value);

                        if (!HasExited)
                            Kill();
                    }
                }
                else
                    Kill();

            if (disposing)
                Dispose(true);
        }

        public delegate void LogEventHandler(string message, EventLogEntryType logLevel);
        public LogEventHandler LogEvent = delegate { }; // add empty delegate!;

        public delegate void StatusChangedHandler(FFmpegProcessStatus status);
        public event StatusChangedHandler StatusChanged = delegate { }; // add empty delegate!;

        public new string ToString()
        {
            return base.ToString();
        }
    }
}
