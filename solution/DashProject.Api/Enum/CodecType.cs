using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DashProject.Api.Enum
{
    public enum CodecType
    {
        [EncoderToUse(EncoderType.libx264)]
        [DecoderToUse(DecoderType.h264)]
        h264 = 63,
        mpeg2video = 92,
        mp2 = 272,
        [EncoderToUse(EncoderType.libmp3lame)]
        [DecoderToUse(DecoderType.mp3)]
        mp3 = 273,
        [EncoderToUse(EncoderType.libvo_aacenc)]
        [DecoderToUse(DecoderType.aac)]
        aac = 202,
        ac3 = 204,
        vp8 = 179,
        vp9 = 180,
        none = 0 //default
    }

    public class EncoderToUse : System.Attribute
    {
        private EncoderType value;

        public EncoderToUse(EncoderType encoder)
        {
            value = encoder;
        }

        public EncoderType Value
        {
            get { return value; }
        }
    }

    public class DecoderToUse : System.Attribute
    {
        private DecoderType value;

        public DecoderToUse(DecoderType decoder)
        {
            value = decoder;
        }

        public DecoderType Value
        {
            get { return value; }
        }
    }
}
