using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DashProject.Api.Enum
{
    public enum LIBx264EncoderPresetType
    {
        medium = 5, //default value since it is the first enumerator
        //ultrafast = 1, // do not use it! It change duration of the file after transcoding!
        superfast = 1,
        veryfast = 2,
        faster = 3,
        fast = 4,
        slow = 6,
        slower = 7,
        veryslow = 8,
        placebo = 9
    }
}
