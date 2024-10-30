using System.Xml;

namespace Collada.Wpf
{
    internal class Scene
    {
        XmlElement xmlElement;

        public Scene(XmlElement xmlElement)
        {
            this.xmlElement = xmlElement;
        }

        public XmlElement Xml { get =>  xmlElement; }

        public object Object { get; set; }
    }
}