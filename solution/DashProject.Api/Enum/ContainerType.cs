using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DashProject.Api.Enum
{
    public enum ContainerType
    {
        none = 0, //default
        mp4 = 134,
        webm = 244,
        [FileExtension("ts")]
        mpegts = 140,
        [ContainerToForce(ContainerType.mp4)]
        mov = 128,
        c3gp = 2,
        c3g2 = 1,
        asf = 21,
        avi = 26,
        f4v = 65,
        flv = 74,
        [FileExtension("mkv")]
        matroska = 118,
        m4v = 117,
        m4a = 131,
        stream_segment,
        h264 = 86
    }

    public class FileExtension : System.Attribute
    {
        private string value;

        public FileExtension(string extension)
        {
            value = extension;
        }

        public string Value
        {
            get { return value; }
        }
    }

    public class ContainerToForce : System.Attribute
    {
        private ContainerType value;

        public ContainerToForce(ContainerType container)
        {
            value = container;
        }

        public ContainerType Value
        {
            get { return value; }
        }
    }

    
}
