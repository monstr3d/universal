

using System.Xml;
using Abstract3DConverters;
using Abstract3DConverters.Interfaces;
using Collada;

namespace Collada150.Classes
{
    [Tag("transparent", true)]
    internal class Transparent : XmlHolder
    {

        public static IClear Clear => StaticExtensionCollada.GetClear<Transparent>();
        public Color Color { get; private set; }

        public string Opaque { get; private set; }
        private Transparent(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {
            Color = (Color)(element.FirstChild as XmlElement).Get();
            Opaque = element.GetAttribute("opaque");
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Transparent(element, meshCreator);
            return a.Get();
        }
    }
}
