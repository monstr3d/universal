using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace SerializationInterface
{
    [XmlRoot("dictionary")]
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
    {
        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SerializableDictionary()
        {
        }

 
        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="dictionary">Dictionary</param>
        public SerializableDictionary(IDictionary<TKey, TValue> dictionary)
            : base(dictionary)
        {
        }

        #endregion

        #region IXmlSerializable Members

        /// <summary>
        /// Gets schema
        /// </summary>
        /// <returns>Schema</returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Reads Xml
        /// </summary>
        /// <param name="xmlReader">Reader</param>
        public void ReadXml(XmlReader xmlReader)
        {
            XmlSerializer keyXmlSerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueXmlSerializer = new XmlSerializer(typeof(TValue));

            if (xmlReader.IsEmptyElement)
                return;

            xmlReader.ReadStartElement("root");

            while (xmlReader.NodeType != XmlNodeType.EndElement)
            {
                xmlReader.ReadStartElement("item");
                xmlReader.ReadStartElement("key");

                TKey key = (TKey)keyXmlSerializer.Deserialize(xmlReader);

                xmlReader.ReadEndElement();
                xmlReader.ReadStartElement("value");
                TValue value = (TValue)valueXmlSerializer.Deserialize(xmlReader);
                xmlReader.ReadEndElement();

                this.Add(key, value);
                xmlReader.ReadEndElement();
            }

            xmlReader.ReadEndElement();
        }

        /// <summary>
        /// Writes xml
        /// </summary>
        /// <param name="xmlWriter">Writer</param>
        public void WriteXml(XmlWriter xmlWriter)
        {
            XmlSerializer keyXMLSerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueXMLSerializer = new XmlSerializer(typeof(TValue));

            foreach (TKey key in this.Keys)
            {
                xmlWriter.WriteStartElement("item");

                xmlWriter.WriteStartElement("key");
                keyXMLSerializer.Serialize(xmlWriter, key);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("value");
                TValue value = this[key];
                valueXMLSerializer.Serialize(xmlWriter, value);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndElement();
            }
        }

        #endregion

        #region Members

        /// <summary>
        /// Reads itself from string
        /// </summary>
        /// <param name="xmlString">The string</param>
        /// <returns>Dictionary</returns>
        public void ReadFromString(string xmlString)
        {
             StringReader stringReader = new StringReader(xmlString);
            XmlTextReader xmlTextReader = new XmlTextReader(stringReader);

            ReadXml(xmlTextReader);

            xmlTextReader.Close();
            stringReader.Close();
     }

        /// <summary>
        /// Serializes itself to string
        /// </summary>
        /// <returns>The string</returns>
        public string SerializeToString()
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8))
                {
                    xmlTextWriter.Namespaces = true;

                    WriteXml(xmlTextWriter);
                    xmlTextWriter.Flush();
                    memoryStream.Flush();
                    string result = Encoding.UTF8.GetString(memoryStream.GetBuffer());
                    try
                    {
                        result = result.Substring(result.IndexOf(Convert.ToChar(60)));
                        result = result.Substring(0, (result.LastIndexOf(Convert.ToChar(62)) + 1));
                    }
                    catch (Exception)
                    {
                        result = "";
                    }
                    result = "<root>" + result + "</root>";
                    return result;
                }
            }
        }

        #endregion
    }
}
