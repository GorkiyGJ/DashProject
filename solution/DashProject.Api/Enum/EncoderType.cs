using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DashProject.Api.Enum
{
    public enum EncoderType
    {
        none = 0, //default
        copy = -1,
        libx264 = 26,
        mpeg2video = 35,
        mpeg4 = 36,
        libmp3lame = 107,
        libvo_aacenc = 82,
        aac = 81
    }
}
