using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DashProject.Api.Extension
{
    public static class IntExtension
    {
        public static int ToKbps(this int valueBps)
        {
            int valueKbps = valueBps / 1000;
            return (valueKbps == 0) ? 1 : valueKbps;
        }
    }
}
