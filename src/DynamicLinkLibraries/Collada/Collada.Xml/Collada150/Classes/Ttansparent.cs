
using System.Windows.Media;
using System.Xml;
using Collada;

namespace Collada150.Classes
{
    [Tag("transparent", true)]
    internal class Transparent : XmlHolder
    {
        static public readonly string Tag = "transparent";
        public Color Color { get; private set; }

        public string Opaque { get; private set; }
        private Transparent(XmlElement xml) : base(xml)
        {
            Color = (Color)(xml.FirstChild as XmlElement).Get();
            Opaque = xml.GetAttribute("opaque");
        }

        public static object Get(XmlElement element)
        {
            var a = new Transparent(element);
            return a.Get();
        }
    }
}
