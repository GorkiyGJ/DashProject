using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using DashProject.Api;
using DashProject.Api.Enum;
using DashProject.Entity.Custom;
using DashProject.Service.Factory.MediaFactories;
using DashProject.Service.Factory.DashFactories;

namespace DashProject.Service.Factory
{
    public sealed class Production
    {
        private static readonly Production instance = new Production();

        public static Production GetProduction()
        {
            return instance;
        }

        public FactoryCollection<MediaFactory> MediaFactories = new FactoryCollection<MediaFactory>();

        private Production()
        {
            List<iMediaInfo> mediaInfoList = MediaApi.iMediaInfo_Get();
            if (mediaInfoList == null || mediaInfoList.Count == 0)
                return;

            foreach (iMediaInfo mediaInfo in mediaInfoList)
            {
                MediaOriginType mediaOriginType = (MediaOriginType) mediaInfo.MediaOriginTypeId;
                int mediaId = mediaInfo.MediaId;

                MediaFactory mediaFactory = null;

                if (mediaOriginType == MediaOriginType.udp_mpegts)
                    mediaFactory = new UdpMpegTs_MediaFactory(mediaId);
                else if (mediaOriginType == MediaOriginType.file)
                    mediaFactory = new MediaFactory(mediaId);

                if (mediaFactory == null)
                    return

                MediaFactories.Add(mediaInfo.MediaId.Value, mediaFactory);

                List<iDashMediaInfo> dashMediaInfoList = Api.DashMediaApi.iDashMediaInfo_Get_By_MediaId(mediaId);
                if (dashMediaInfoList == null || dashMediaInfoList.Count == 0)
                    return;

                foreach (iDashMediaInfo dashMediaInfo in dashMediaInfoList)
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
        }

        public void Start()
        {
            foreach (MediaFactory mediaFactory in MediaFactories)
                mediaFactory.Start();
        }

        public void Stop()
        {
            foreach (MediaFactory mediaFactory in MediaFactories)
                mediaFactory.Stop();
        }
    }
}
