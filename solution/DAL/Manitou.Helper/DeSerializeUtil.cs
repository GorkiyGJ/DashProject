using System;
using System.IO;
using System.Xml.Serialization;

namespace Manitou.Helper
{
    public static class DeSerializeUtil
    {
        public static object GetObject(string value, Type type)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(type);
            StringReader sr = new StringReader(value);

            return xmlSerializer.Deserialize(sr);
        }
    }
}
