using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DashProject.Api.Enum
{
    public enum FFmpegProcessStatus
    {
        Stopped = 0,//default
        Running = 1,
        RunningWithWarnings = 2
    }

    public enum FFmpegLogLevel
    {
        quiet,
        panic,
        fatal,
        error,
        warning,
        info,
        verbose,
        debug
    }

    public enum FFmpegProcessExitCode
    {
        Success = 0,
        Error = 1//,
        //StoppedByService = 2
    }
}
