using System;
using System.IO;
using System.Xml.Serialization;

namespace Manitou.Helper
{
    public static class SerializeUtil
    {
        public static string GetXml(object obj, Type type)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(type);

            StringWriter sw = new StringWriter();
            xmlSerializer.Serialize(sw, obj);

            return sw.ToString();
        }
    }
}
