using System;
using System.IO;


namespace MatrixIO.IO.Bmff.Boxes
{
    /// <summary>
    /// Track Fragment Decode Time Box ("tfdt")
    /// </summary>
    [Box("tfdt", "Track Fragment Decode Time Box")]
    public class TrackFragmentDecodeTimeBox : FullBox
    {
        public TrackFragmentDecodeTimeBox() : base() { }
        public TrackFragmentDecodeTimeBox(Stream stream) : base(stream) { }

        internal override ulong CalculateSize()
        {
            ulong calculatedSize = base.CalculateSize() + 4;
            if (Version == 1)
                calculatedSize += 8;
            return calculatedSize;
        }

        protected override void LoadFromStream(Stream stream)
        {
            base.LoadFromStream(stream);

            if (Version == 1)
                BaseMediaDecodeTime = stream.ReadBEUInt64();
            else
                BaseMediaDecodeTime = stream.ReadBEUInt32();
        }

        protected override void SaveToStream(Stream stream)
        {
            base.SaveToStream(stream);

            if (Version == 1)
                stream.WriteBEUInt64(BaseMediaDecodeTime);
            else
                stream.WriteBEUInt32((uint)BaseMediaDecodeTime);
        }
        public ulong BaseMediaDecodeTime { get; set; }
    }
}
