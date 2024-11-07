using System.Xml;

namespace Collada
{
    /// <summary>
    /// Holder of xml element
    /// </summary>
    public class XmlHolder
    {
        /// <summary>
        /// The xml element
        /// </summary>
        public XmlElement Xml { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="xml">The xml element</param>
        protected XmlHolder(XmlElement xml)
        {
            Xml = xml;
            xml.PutObject(this);
        }
    }
}
