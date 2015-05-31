using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using DashProject.Api.Enum;

namespace DashProject.Api.Extension
{
    public static class ContainerTypeExtension
    {
        public static string GetFileExtension(this ContainerType container)
        {
            FieldInfo fi = container.GetType().GetField(container.ToString());
            FileExtension[] attributes = fi.GetCustomAttributes(typeof(FileExtension), false) as FileExtension[];
            string fileExtension = (attributes != null && attributes.Length > 0) ? attributes[0].Value : container.ToString();
            return fileExtension;
        }

        public static ContainerType GetContainerToForce(this ContainerType container)
        {
            FieldInfo fi = container.GetType().GetField(container.ToString());
            ContainerToForce[] attributes = fi.GetCustomAttributes(typeof(ContainerToForce), false) as ContainerToForce[];
            ContainerType containerToForce = (attributes != null && attributes.Length > 0) ? attributes[0].Value : container;
            return containerToForce;
        }
    }
}
