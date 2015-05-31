using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using DashProject.Api.Enum;
using Manitou.Helper;
using Newtonsoft.Json;
using DashProject.Api.Extension;
using System.IO;

namespace DashProject.Api
{
    public static class FFmpegApi
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

            /*private DecoderType videoDecoder;
             private DecoderType audioDecoder;
             private ContainerType inputContainer;
             private EncoderType videoEncoder;
             private EncoderType audioEncoder;
             private ContainerType outputContainer;
             private FFmpegOption[] ffmpegOptions;

             protected string InputMedia;
             protected string OutputMedia;
             public int? ProgramIndex;
             public int? StreamIndex;*/

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

                    if(ffmpegSetting.InputContainer != ContainerType.none)
                        argumentsString.Append(" -f " + ffmpegSetting.InputContainer);

                    if (ffmpegSetting.StreamsMaps != null && ffmpegSetting.StreamsMaps.Length > 0)
                        foreach(FFmpegSetting.StreamMap streamMap in  ffmpegSetting.StreamsMaps)
                            if(streamMap.Decoder != DecoderType.none)
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
                                foreach (FFmpegConfigApi.FFmpegConfig config in streamMap.CustomConfigs)
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
                /*this.videoDecoder = videoDecoder;
                this.audioDecoder = audioDecoder;
                this.inputContainer = inputContainer;
                this.videoEncoder = videoEncoder;
                this.audioEncoder = audioEncoder;
                this.outputContainer = outputContainer;
                this.ffmpegConfigs = ffmpegConfigs;*/
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

            /*private void OnLog(string message, EventLogEntryType logLevel)
            {
                DashProject.Api.CoreApi.AppEventLog.WriteEntry(message, "DashProject", logLevel);
            }*/

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

        public abstract class FFmpegProcess_piped : FFmpegProcess
        {
            private NamedPipeServerStream pipeOutput;
            private NamedPipeServerStream pipeInput;
            private string pipeName;
            private bool isUsePipeIn;
            private bool isUsePipeOut;
            private bool isPartillyOuput;
            private string pipeFullNameTmpl = @"\\.\pipe\{0}";
            private string pipeInNameTmpl = @"{0}_in";
            private string pipeOutNameTmpl = @"{0}_out";
            private string pipeInName;
            private string pipeOutName;

            public FFmpegProcess_piped(FFmpegApi.FFmpegSetting ffmpegSetting, bool isUsePipeIn, bool isUsePipeOut, bool isPartillyOuput)
                : base(ffmpegSetting)
            {
                this.pipeName = Guid.NewGuid().ToString();
                this.isUsePipeIn = isUsePipeIn;
                this.isUsePipeOut = isUsePipeOut;
                this.isPartillyOuput = isPartillyOuput;

                pipeInName = string.Format(pipeInNameTmpl, pipeName);
                pipeOutName = string.Format(pipeOutNameTmpl, pipeName);

                if (isUsePipeIn)
                    this.InputMedia = string.Format(pipeFullNameTmpl, pipeInName);

                if (isUsePipeOut)
                    this.OutputMedia = string.Format(pipeFullNameTmpl, pipeOutName);
            }

            public new bool Start()
            {
                bool isStarted = true;

                if (isUsePipeIn)
                    pipeInput = new NamedPipeServerStream(pipeInName, PipeDirection.Out, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);

                if (isUsePipeOut)
                    pipeOutput = new NamedPipeServerStream(pipeOutName, PipeDirection.In, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);

                isStarted = base.Start();

                if (isStarted)
                {
                    if (isUsePipeIn && !pipeInput.IsConnected)
                        pipeInput.WaitForConnection();

                    if (isUsePipeOut)
                        pipeOutput.BeginWaitForConnection(new AsyncCallback(asyncResult =>
                        {
                            pipeOutput.EndWaitForConnection(asyncResult);
                            BeginReadPipeOut();
                        }), null);

                }
                return isStarted;
            }

            Queue<byte> bufferQueue;

            private const int bufferSize = 4096;
            private byte[] buffer = new byte[bufferSize];

            public void BeginReadPipeOut()
            {
                int bytesCount = pipeOutput.Read(buffer, 0, bufferSize);

                if (bytesCount == 0)
                {
                    if (!isPartillyOuput)
                    {
                        byte[] bytes = bufferQueue.ToArray();
                        BytesOutputReceived(ref bytes);
                    }
                    bufferQueue = null;

                    pipeOutput.Close();
                    pipeOutput = null;

                    WorkDoneHandle.Set();
                    return;
                }

                byte[] bytesReaded = new byte[bytesCount];
                Array.Copy(buffer, 0, bytesReaded, 0, bytesCount);

                if (isPartillyOuput)
                    BytesOutputReceived(ref bytesReaded);

                if (!isPartillyOuput)
                {
                    if (bufferQueue == null)
                        bufferQueue = new Queue<byte>();

                    for (int n = 0; n < bytesCount; n++)
                        bufferQueue.Enqueue(bytesReaded[n]);
                }
                BeginReadPipeOut();
            }

            public void BeginWriteToPipeInput(byte[] bytes)
            {
                pipeInput.Write(bytes, 0, bytes.Length);
                pipeInput.WaitForPipeDrain();
                pipeInput.Close();
                pipeInput = null;
            }

            public new void Stop(bool disposing = true)
            {
                base.Stop(disposing);
            }

            public new void Stop(int? waitForExitS, bool disposing = true)
            {
                base.Stop(waitForExitS, disposing);
            }

            public new string ToString()
            {
                return base.ToString();
            }

            protected abstract void BytesOutputReceived(ref byte[] bytes);      
        }

        public class FFmpegSetting
        {
            public string InputMedia;
            public string OutputMedia;
            public ContainerType InputContainer;
            public ContainerType OutputContainer;
            public int? ProgramIndex;
            public StreamMap[] StreamsMaps;
            public FFmpegConfigApi.FFmpegConfig CustomConfig;

            public class StreamMap
            {
                public byte StreamIndex;
                public StreamType streamType;
                public DecoderType Decoder;
                public EncoderType Encoder;
                public FFmpegConfigApi.EncoderConfig EncoderConfig;
                public FFmpegConfigApi.FFmpegConfig[] CustomConfigs;
            }
        }

        

        

    } 
}
