using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using DashProject.Api;
using DashProject.Api.Enum;
using DashProject.Entity.Custom;

namespace DashProject.Service.Factory
{
    public sealed class Production
    {
        private static readonly Production instance = new Production();

        public static Production GetProduction()
        {
            return instance;
        }
        
        public FactoryCollection<MediaFactory> MediaFactories;

        private Production()
        {
            MediaFactories = new FactoryCollection<MediaFactory>();

            List<iMediaInfo> mediaList = MediaApi.iMediaInfo_Get();
            foreach (iMediaInfo mediaInfo in mediaList)
            {
                RawMediaSourceType rawMediaSourceType = (RawMediaSourceType)mediaInfo.RawMediaSourceTypeId;
                if (rawMediaSourceType == RawMediaSourceType.udp_mpegts)
                    MediaFactories.Add(mediaInfo.MediaId.Value, new UdpMpegTs_MediaFactory(mediaInfo));
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
