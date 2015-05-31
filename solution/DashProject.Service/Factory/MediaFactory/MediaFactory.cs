using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using DashProject.Api;
using DashProject.Service.Factory;
using System.Threading.Tasks.Dataflow;
using System.Diagnostics;
using DashProject.Api.Enum;
using DashProject.Entity.Custom;
using DashProject.Service.Factory.Dash;


namespace DashProject.Service.Factory
{
   
    public abstract class MediaFactory : FactoryBase, IEnumerable
    {
        public int MediaId;
        //public int RawMediaId;
        public int? ProgramIndex;
        protected FactoryCollection<DashFactory> DashFactories;
        public BroadcastBlock<DashProject.Api.Data> InputDataBuffer;

        public MediaFactory(int mediaId)
            : this(Api.MediaApi.iMediaInfo_Get_By_MediaId(mediaId)) { }

        public MediaFactory(iMediaInfo mediaInfo)
        {
            MediaId = mediaInfo.MediaId.Value;
            ProgramIndex = mediaInfo.ProgramIndex;
            InputDataBuffer = new BroadcastBlock<DashProject.Api.Data>(data =>
            {
                return data.Clone() as DashProject.Api.Data;
            });

            DashFactories = new FactoryCollection<DashFactory>();

            List<iDashMediaInfo> iDashMediaInfoList = Api.DashMediaApi.iDashMediaInfo_Get_By_MediaId(MediaId);
            if (iDashMediaInfoList != null && iDashMediaInfoList.Count != 0)
                foreach (iDashMediaInfo dashMediaInfo in iDashMediaInfoList)
                {
                    Api.Enum.DashType dashType = (Api.Enum.DashType)dashMediaInfo.DashTypeId;
                    
                    int dashMediaId = dashMediaInfo.DashMediaId;

                    DashFactory dashFactory = null;
                    if (dashType == Api.Enum.DashType.mp4v || dashType == Api.Enum.DashType.mp4a)
                        dashFactory = new DashFactory_mp4(dashMediaId);
                    /*if (dashType == Api.Enum.DashType.mp4v || dashType == Api.Enum.DashType.mp4a)
                    {
                        if (rawMediaStreamCodec == Api.Enum.CodecType.mpeg2video)
                            dashFactory = new DashFactory_mp4<Transcoder_file_in_mpegts_h262_piped_out_fmp4_x264>(dashMediaId);
                        if(rawMediaStreamCodec == Api.Enum.CodecType.h264)
                            dashFactory = new DashFactory_mp4<Transcoder_file_in_mpegts_x264_piped_out_fmp4_x264>(dashMediaId);
                    }
                    if (dashType == Api.Enum.DashType.webmv || dashType == Api.Enum.DashType.webma)
                    {
                    }*/

                    if (dashFactory == null)
                        return;

                    dashFactory.StatusChanged += status => { if (status != FactoryStatus.Running) this.Status = FactoryStatus.RunningWithWarnings; };
                    InputDataBuffer.LinkTo(dashFactory.InputDataBuffer);

                    DashFactories.Add(dashMediaId, dashFactory);
                }
        }

        public override void Start()
        {
            foreach (DashFactory dashFactory in DashFactories)
                dashFactory.Start();

            this.Status = FactoryStatus.Running;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (DashFactory dashFactory in DashFactories)
            {
                yield return dashFactory;
            }
        }

        public override void Stop(bool isWaitForTasksDone = true)
        {
            if (isWaitForTasksDone)
            {
                InputDataBuffer.Complete();
                InputDataBuffer.Completion.Wait();
            }

            foreach (DashFactory dashFactory in DashFactories)
                dashFactory.Stop(isWaitForTasksDone);
        }


        protected override void OnStatusChanged(FactoryStatus status)
        {
            //throw new NotImplementedException();
        }

        protected override void OnLog(string message, EventLogEntryType logLevel)
        {
            //throw new NotImplementedException();
        }
    }
}
