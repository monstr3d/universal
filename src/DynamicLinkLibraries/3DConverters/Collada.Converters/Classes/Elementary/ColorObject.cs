using System.Xml;
using Abstract3DConverters;
using Abstract3DConverters.Interfaces;
using Collada;

namespace Collada.Converters.Classes.Elementary
{
    [Tag("color", true)]
    internal class ColorObject : XmlHolder
    {
    
        Service s = new Service();
        public Color Color { get; private set; }


        public static IClear Clear => StaticExtensionCollada.GetClear<ColorObject>();


        private ColorObject(XmlElement element) : base(element, null)
        {
            Color = s.GetColor(element);
        }

  
        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new ColorObject(element);
            return a.Get();
        }
    }
}