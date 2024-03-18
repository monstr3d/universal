using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Diagram.UI
{
    /// <summary>
    /// Writer of parameters (XML)
    /// </summary>
    public class XmlParameterWriter : IParameterWriter
    {
        #region Fields
        
        private XmlDocument doc = new XmlDocument();
        
        private string filename;

        private XmlElement root;
        
        #endregion

        #region Ctor
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filename">File name</param>
        public XmlParameterWriter(string filename)
        {
            this.filename = filename;
            doc.LoadXml("<Root/>");
            root = doc.DocumentElement;
        }

        #endregion

        #region IParameterWriter Members

        void IParameterWriter.Write(Dictionary<string, string> parameters)
        {
            XmlElement el = doc.CreateElement("Parameters");
            root.AppendChild(el);
            foreach (string par in parameters.Keys)
            {
                XmlElement e = doc.CreateElement("Parameter");
                el.AppendChild(e);
                XmlAttribute ap = doc.CreateAttribute("Name");
                ap.Value = par;
                e.Attributes.Append(ap);
                XmlAttribute av = doc.CreateAttribute("Value");
                av.Value = parameters[par];
                e.Attributes.Append(av);
            }
        }

        void IParameterWriter.Flush()
        {
            if (filename != null)
            {
                doc.Save(filename);
            }
        }

        #endregion

        #region Members

        /// <summary>
        /// Document
        /// </summary>
        public XmlDocument Document
        {
            get
            {
                return doc;
            }
        }

        #endregion
    }
}
