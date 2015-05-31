using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DashProject.Api.Enum
{
    public enum DecoderType
    {
        none = 0, //default
        h264 = 65,
        mpeg2video = 94,
        mpeg4 = 96,
        mp3 = 291,
        aac = 208,
        ac3 = 210
    }
}
