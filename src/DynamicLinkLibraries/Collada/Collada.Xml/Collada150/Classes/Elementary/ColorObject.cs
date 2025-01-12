using System.Xml;
using Abstract3DConverters;
using Abstract3DConverters.Interfaces;
using Collada;

namespace Collada150.Classes.Elementary
{
    [Tag("color", true)]
    internal class ColorObject : XmlHolder
    {
    
        Service s = new Service();
        public Color Color { get; private set; }


        public static IClear Clear => StaticExtensionCollada.GetClear<ColorObject>();


        private ColorObject(XmlElement element) : base(element, null)
        {
            Color = element.GetColor();
        }

  
        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new ColorObject(element);
            return a.Get();
        }
    }
}