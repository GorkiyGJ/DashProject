using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DashProject.Api.Extension
{
    public static class FloatExtension
    {
        public static string ToStringJS(this float input)
        {
            return input.ToString().Replace(',', '.');
        }
    }
}
