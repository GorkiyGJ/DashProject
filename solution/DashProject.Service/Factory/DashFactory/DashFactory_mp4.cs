using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashProject.Service.Factory.Transcoders;
using System.Threading.Tasks.Dataflow;
using DashProject.Api.Enum;
using System.Diagnostics;
using DashProject.Api;
using MatrixIO.IO.Bmff.Boxes;
using MatrixIO.IO.Bmff;
using MatrixIO.IO;

namespace DashProject.Service.Factory.Dash
{
    public abstract class DashFactory_mp4 : DashFactory
    {
        public DashFactory_mp4(int dashMediaId)
            : base(dashMediaId) { }

        protected override DashFactory.DashSegmentFactory<BytesData_TimeStamp> SegmentFactory
        {
            get { return new SegmentFactory_mp4(DashMediaId); }
        }

        protected class SegmentFactory_mp4 : DashFactory.DashSegmentFactory<BytesData_TimeStamp>
        {
            private FileTypeBox ftypBox;
            private MovieBox moovBox;
            private MovieFragmentBox moofBox;
            private MovieDataBox mdatBox;

            private decimal startTs;
            private uint timeScale;

            public SegmentFactory_mp4(int dashMediaId)
                : base(dashMediaId) { }

            public void Add(FileTypeBox box)
            {
                ftypBox = box;
            }

            public void Add(MovieBox box)
            {
                moovBox = box;

                timeScale = moovBox.Children.OfType<TrackBox>().SingleOrDefault()
                                        .Children.OfType<MediaBox>().SingleOrDefault()
                                        .Children.OfType<MediaHeaderBox>().SingleOrDefault().TimeScale;

                if (DashFactory_mp4.IsHasInitSegment(DashMediaId))
                    return;

                BaseMedia initBaseMedia = new BaseMedia();
                initBaseMedia.Children.Insert(0, ftypBox);
                initBaseMedia.Children.Insert(1, moovBox);

                using (FileStream fs = new FileStream(CoreApi.Get_Dash_InitSegment_FilePath(DashMediaId), FileMode.Create))
                {
                    try
                    {
                        initBaseMedia.SaveTo(fs);
                        DashMediaApi.DashMedia_Save_InitSegment(DashMediaId, new Entity.DashInitSegment() { FileName = CoreApi.AppConf.InitMediaFileName, DateTimeCreated = DateTime.Now, ContainerFormatId = (int)ContainerFormat.mp4 });
                    }
                    catch (Exception ex) { LogEvent(ex.Message, System.Diagnostics.EventLogEntryType.Error); }
                }
            }

            public void Add(MovieFragmentBox box)
            {
                moofBox = box;
            }

            public void Add(MovieDataBox box, decimal startTs)
            {
                mdatBox = box;

                TrackFragmentBox traf = moofBox.Children.OfType<TrackFragmentBox>().SingleOrDefault();
                if (traf == null)
                    return;

                TrackFragmentDecodeTimeBox tfdt = traf.Children.OfType<TrackFragmentDecodeTimeBox>().SingleOrDefault();
                if (tfdt == null)
                    return;

                TrackFragmentHeaderBox tfhd = traf.Children.OfType<TrackFragmentHeaderBox>().SingleOrDefault();
                if (tfhd == null)
                    return;

                //tfhd.BaseDataOffset = null;

                MovieFragmentHeaderBox mfhd = moofBox.Children.OfType<MovieFragmentHeaderBox>().SingleOrDefault();
                if (mfhd == null)
                    return;

                TrackRunBox trun = traf.Children.OfType<TrackRunBox>().SingleOrDefault();
                if (trun == null)
                    return;

                long mediaSegmentDuration = 0;

                uint? sampleDefDuration = tfhd.DefaultSampleDuration;

                foreach (TrackRunBox.TrackRunEntry entry in trun.Entries)
                {
                    if (entry.SampleDuration.HasValue)
                        mediaSegmentDuration += entry.SampleDuration.Value;
                    else if (sampleDefDuration.HasValue)
                        mediaSegmentDuration += sampleDefDuration.Value;
                }

                if (mfhd.SequenceNumber == 1)
                    this.startTs = startTs;

                ulong decodeTimeTS = (ulong)(Math.Round(startTs * timeScale, MidpointRounding.AwayFromZero));
                tfdt.BaseMediaDecodeTime = decodeTimeTS;

                /*TrackFragmentDecodeTimeBox tfdt = new TrackFragmentDecodeTimeBox()
                {
                    Version = (byte)1,
                    BaseMediaDecodeTime = decodeTimeTS
                };*/

                //int tfhdIndex = traf.Children.IndexOf(tfhd);

                // traf.Children.Insert(tfhdIndex + 1, tfdt);

                DashProject.Entity.DashMediaSegment dashMediaSegment = new DashProject.Entity.DashMediaSegment();
                dashMediaSegment.DashMediaId = DashMediaId;
                dashMediaSegment.ContainerFormatId = (int)Api.Enum.ContainerFormat.mp4;
                dashMediaSegment.TimeScale = (int)timeScale;
                dashMediaSegment.DecodeTimeTS = (long)decodeTimeTS;
                dashMediaSegment.DurationTS = (int)mediaSegmentDuration;
                dashMediaSegment.DurationS = (decimal)mediaSegmentDuration / timeScale;
                //dashMediaSegment.GlobalStartTimeS = startTs;
                //dashMediaSegment.GlobalEndTimeS = startTs + dashMediaSegment.DurationS;
                dashMediaSegment.DateTimeCreated = DateTime.Now;
                dashMediaSegment = DashMediaSegmentApi.DashMediaSegment_Save(dashMediaSegment);

                BaseMedia dashSegmentBaseMedia = new BaseMedia();
                dashSegmentBaseMedia.Children.Insert(0, moofBox);
                dashSegmentBaseMedia.Children.Insert(1, mdatBox);

                string segmentfilePath = CoreApi.Get_DashSegment_FilePath(DashMediaId, dashMediaSegment.Id);

                using (FileStream fs = new FileStream(segmentfilePath, FileMode.Create))
                {
                    try
                    {
                        dashSegmentBaseMedia.SaveTo(fs);
                    }
                    catch (Exception ex) { LogEvent(ex.Message, System.Diagnostics.EventLogEntryType.Error); }
                }

                startTs += dashMediaSegment.DurationS;
            }

            private byte[] ByteBuffer;

            protected override void OnDataInputReceived(BytesData_TimeStamp data)
            {
                byte[] bytes;
                if (ByteBuffer != null && ByteBuffer.Length > 0)
                {
                    bytes = new byte[ByteBuffer.Length + data.Bytes.Length];
                    ByteBuffer.CopyTo(bytes, 0);
                    Array.Copy(data.Bytes, 0, bytes, ByteBuffer.Length, data.Bytes.Length);
                    ByteBuffer = null;
                }
                else
                    bytes = data.Bytes;

                int size = 0;
                int offset = 0;

                int nextBytesCount = bytes.Length;
                do
                {
                    size = BitConverter.ToInt32(bytes, offset).NetworkToHostOrder();
                    if (nextBytesCount < size)
                        break;

                    if (size == 0)
                        break;

                    if (size > 1)
                    {
                        MemoryStream ms = new MemoryStream(bytes, offset, size);
                        ms.Position = 0;
                        Box box = null;
                        try
                        {
                            box = Box.FromStream(ms);
                        }
                        catch { }

                        if (box != null)
                        {
                            if (box is FileTypeBox)
                                Add(box as FileTypeBox);
                            else if (box is MovieBox)
                                Add(box as MovieBox);
                            else if (box is MovieFragmentBox)
                                Add(box as MovieFragmentBox);
                            else if (box is MovieDataBox)
                                Add(box as MovieDataBox, data.StreamStartTs);
                        }
                    }
                    offset += size;
                    nextBytesCount -= size;

                } while (nextBytesCount > 4);

                if (nextBytesCount != 0)
                    Array.Copy(bytes, offset, ByteBuffer = new byte[nextBytesCount], 0, nextBytesCount);
            }
        }

        public new void Stop(bool isWaitForTasksDone = true)
        {
            base.Stop(isWaitForTasksDone);
        }

        public new void Start()
        {
            //throw new NotImplementedException();
        }
    }

    public class DashFactory_mp4v : DashFactory_mp4
    {
        public DashFactory_mp4v(int dashMediaId)
            : base(dashMediaId) { }

        protected override Transcoder<BytesData_TimeStamp> Transcoder
        {
            get { return new Transcoder_file_in_mpegts_h262_piped_out_fmp4_x264(DashMediaId); }
        }
    }
}
