using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashProject.Api.Enum
{
    public enum FFmpegProcessStatus
    {
        Stopped = 0,//default
        Running = 1,
        RunningWithWarnings = 2
    }
}
