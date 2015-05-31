using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DashProject.Api.Enum
{
    public enum StreamType
    {
        [StreamSpecifier("v")]
        video = 1,
        [StreamSpecifier("a")]
        audio = 2
    }

    public class StreamSpecifier : System.Attribute
    {
        private string value;

        public StreamSpecifier(string specifier)
        {
            value = specifier;
        }

        public string Value
        {
            get { return value; }
        }
    }
}
