using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DashProject.Api.Enum;

namespace DashProject.Api.Extension
{
    public static class StreamTypeExtension
    {
        public static string GetStreamSpecifier(this StreamType streamType)
        {
            FieldInfo fi = streamType.GetType().GetField(streamType.ToString());
            StreamSpecifier[] attributes = fi.GetCustomAttributes(typeof(StreamSpecifier), false) as StreamSpecifier[];
            string specifier = (attributes != null && attributes.Length > 0) ? attributes[0].Value : string.Empty;
            return specifier;
        }
    }
}
