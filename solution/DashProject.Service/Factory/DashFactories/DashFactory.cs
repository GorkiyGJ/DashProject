using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks.Dataflow;
using DashProject.Api;
using DashProject.Api.Enum;
using DashProject.Service.Factory.Transcoders;
using DashProject.Utils;
using MatrixIO.IO.Bmff;
using MatrixIO.IO.Bmff.Boxes;
using MatrixIO.IO;
using System.Linq;

namespace DashProject.Service.Factory.DashFactories
{
    public abstract class DashFactory : FactoryBase
    {
        public static bool IsHasInitSegment(int dashMediaId) { return System.IO.File.Exists(CoreApi.Get_Dash_InitSegment_FilePath(dashMediaId)); }
        public ActionBlock<DashProject.Api.Data> InputDataBuffer;

        protected abstract Transcoder<BytesData_TimeStamp> Transcoder { get; }
        protected abstract DashSegmentFactory<BytesData_TimeStamp> SegmentFactory { get; }

        //private Transcoder<BytesData_TimeStamp> transcoder;
        //private SegmentFactory<BytesData_TimeStamp> segmentFactory;
        public int DashMediaId;
        //public bool IsMain;

        /*public DashFactory(int dashMediaId)
            : this(dashMediaId, DashMediaApi.DashMedia_Get_IsMain(dashMediaId)) { }*/

        public DashFactory(int dashMediaId/*, bool isMain*/)
        {
            DashMediaId = dashMediaId;

            InputDataBuffer = new ActionBlock<Api.Data>(new Action<Api.Data>(Post), new ExecutionDataflowBlockOptions() { MaxDegreeOfParallelism = 5 });
            //transcoder = Transcoder;
            //segmentFactory = SegmentFactory;
            //segmentFactory.LogEvent += (message, logLevel) => { LogEvent(message, logLevel); };
            //transcoder.OutputDataBuffer.LinkTo(segmentFactory.InputDataBuffer);
            //transcoder.StatusChanged += Transcoder_StatusChanged;
            //transcoder.ErrorDataReceived += (sender, data) => { LogEvent(data.ToString(), EventLogEntryType.Warning); };

            //IsMain = isMain;    
        }

        private void Post(Api.Data data)
        {
            Transcoder<BytesData_TimeStamp> transcoder = Transcoder;
            DashSegmentFactory<BytesData_TimeStamp> segmentFactory = SegmentFactory;
            segmentFactory.LogEvent += (message, logLevel) => { LogEvent(message, logLevel); };
            transcoder.OutputDataBuffer.LinkTo(segmentFactory.InputDataBuffer);
            transcoder.StatusChanged += Transcoder_StatusChanged;
            transcoder.ErrorDataReceived += (sender, info) => { LogEvent(info.ToString(), EventLogEntryType.Warning); };
            transcoder.Transcode(data);
            transcoder.WaitWorkDone();
            transcoder = null;
        }

        //public abstract void Transcoder_OutputDataReceived(BytesData_TimeStamp data);

        public abstract class DashSegmentFactory<inputDataType>
        {
            public ActionBlock<inputDataType> InputDataBuffer;
            protected int DashMediaId;

            public DashSegmentFactory(int dashMediaId)
            {
                InputDataBuffer = new ActionBlock<inputDataType>(new Action<inputDataType>(OnDataInputReceived));
                DashMediaId = dashMediaId;
            }

            protected abstract void OnDataInputReceived(inputDataType data);

            public void Stop(bool isWaitForTasksDone)
            {
                InputDataBuffer.Complete();
                InputDataBuffer.Completion.Wait();
            }

            public LogEventHandler LogEvent = delegate { }; 
        }

        public void Transcoder_StatusChanged(FFmpegProcessStatus status)
        {
            if (status == FFmpegProcessStatus.RunningWithWarnings)
                this.Status = FactoryStatus.RunningWithWarnings;
        }

        protected override void OnStatusChanged(FactoryStatus status)
        {
            //throw new NotImplementedException();
        }

        protected override void OnLog(string message, EventLogEntryType logLevel)
        {
            //throw new NotImplementedException();
        }

        public override void Stop(bool isWaitForTasksDone = true)
        {
            //throw new NotImplementedException();
        }

        public override void Start()
        {
            //throw new NotImplementedException();
        }
    }
}
