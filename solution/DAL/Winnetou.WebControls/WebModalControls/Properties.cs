using System.Collections;
using System.IO;
using System.Xml;

namespace Winnetou.WebControls.WebModalControls
{
    public class Property
    {
        string _key = string.Empty;
        string _value = string.Empty;

        public Property() : this("", "")
        {
        }

        public Property(string Key, string Value)
        {
            this.Key = Key;
            this.Value = Value;
        }

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }

    public class Properties : CollectionBase
    {
        private const string CS = "http://www.smsumh.com.ua/schemas";

        private Hashtable _index = new Hashtable();

        public Properties()
        {
            this.Clear();
        }

        public Properties(string Xml)
            : this()
        {
            this.Xml = Xml;
        }

        public void Add(Property Property)
        {
            List.Add(Property);
            _index.Add(Property.Key, Property);
        }

        public void Add(string Key, string Value)
        {
            Property Property = new Property(Key, Value);
            this.Add(Property);

        }

        public void Remove(Property Property)
        {
            if (Exists(Property.Key))
            {
                Property p = (Property)_index[Property.Key];
                List.Remove(p);
                _index.Remove(Property.Key);
            }
        }

        public new void Clear()
        {
            base.Clear();
            _index.Clear();
        }

        public bool Exists(string Key)
        {
            return _index.ContainsKey(Key);
        }

        public Property this[string Key]
        {
            get
            {
                return ((Property)_index[Key]);
            }
            set
            {
                Property Property = (Property)_index[Key];
                Property = value;
                List[List.IndexOf(Property)] = value;
            }
        }

        public string Xml
        {
            get
            {
                StringWriter stringWriter = new StringWriter();
                XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
                foreach (Property Property in List)
                {
                    xmlTextWriter.WriteStartElement("cs", "property", CS);

                    xmlTextWriter.WriteStartElement("cs", "key", CS);
                    xmlTextWriter.WriteCData(Property.Key);
                    xmlTextWriter.WriteEndElement();

                    xmlTextWriter.WriteStartElement("cs", "value", CS);
                    xmlTextWriter.WriteCData(Property.Value);
                    xmlTextWriter.WriteEndElement();

                    xmlTextWriter.WriteEndElement();
                }

                return (stringWriter.ToString());
            }
            set
            {
                if (value != null)
                {
                    Clear();
                    string Xml = string.Format("<cs:properties xmlns:cs=\"{0}\">", CS) + value + "</cs:properties>";
                    XmlDocument doc = new XmlDocument();
                    XmlNamespaceManager nsmanager = new XmlNamespaceManager(doc.NameTable);
                    nsmanager.AddNamespace("cs", CS);

                    doc.LoadXml(Xml);

                    XmlNodeList properties = doc.SelectNodes("cs:properties/cs:property", nsmanager);
                    foreach (XmlNode Property in properties)
                    {
                        this.Add(Property.SelectSingleNode("cs:key", nsmanager).InnerText, Property.SelectSingleNode("cs:value", nsmanager).InnerText);
                    }
                }
            }
        }
    }
}