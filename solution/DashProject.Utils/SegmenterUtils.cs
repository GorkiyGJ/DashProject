using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using DashProject.Utils;
using System.Diagnostics;
using System.Configuration;
using System.IO;

namespace DashProject.Utils
{
    public static class SegmenterUtils
    {
        
        /*public enum  SupportedContainerFormat
        {
            [FileExtension("mkv")]
            matroska = 118,
            [ContainerToForce("mp4")]
            mov = 128,
            mp4 = 134,
            webm = 244,
            [FileExtension("ts")]
            mpegts = 140,
            c3gp = 2,
            c3g2 = 1,
            asf = 21,
            avi = 26,
            f4v = 65,
            flv = 74,
            m4v = 117,
            m4a = 131
        }*/

        /*public static SupportedContainerFormat GetSegmenterSupportedContainer(MediaUtils.ContainerType rawContainer)
        {
            SegmenterUtils.SupportedContainerFormat container;
            Enum.TryParse<SegmenterUtils.SupportedContainerFormat>(rawContainer.ToString(), out container);
            return container;
        }*/

        /*private class FileExtension : System.Attribute
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

        private class ContainerToForce : System.Attribute
        {
            private string value;

            public ContainerToForce(string container)
            {
                value = container;
            }

            public string Value
            {
                get { return value; }
            }
        }

        public static string GetContainerToForce(this SupportedContainerFormat container)
        {
            FieldInfo fi = container.GetType().GetField(container.ToString());
            ContainerToForce[] attributes = fi.GetCustomAttributes(typeof(ContainerToForce), false) as ContainerToForce[];
            string containerToForce = (attributes != null && attributes.Length > 0) ? attributes[0].Value : container.ToString();
            return containerToForce;
        }

        public static string GetFileExtension(this SupportedContainerFormat container)
        {
            FieldInfo fi = container.GetType().GetField(container.ToString());
            FileExtension[] attributes = fi.GetCustomAttributes(typeof(FileExtension), false) as FileExtension[];
            string fileExtension = (attributes != null && attributes.Length > 0) ? attributes[0].Value : container.ToString();
            return fileExtension;
        }*/
        
    }

    
}
