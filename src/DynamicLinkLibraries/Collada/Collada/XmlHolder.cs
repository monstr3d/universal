using System.Xml;

namespace Collada
{
    /// <summary>
    /// Holder of xml element
    /// </summary>
    public class XmlHolder
    {

        public ICollada Collada
        {
            get;
            private set;
        }
        

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
            Collada = StaticExtensionCollada.Collada;
            Xml = xml;
            xml.PutObject(this);
        }
    }
}
