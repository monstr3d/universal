using System.Xml;
using Abstract3DConverters;
using Abstract3DConverters.Interfaces;
using Collada;

namespace Collada150.Classes
{
    [Tag("color", true)]
    internal class ColorObject : XmlHolder
    {
        static public readonly string Tag = "color";

        /// <summary>
        /// Is elementary
        /// </summary>
        static public readonly bool IsElementary = true;

        Service s = new Service();
        public Color Color { get; private set; }


        public static IClear Clear => StaticExtensionCollada.GetClear<ColorObject>();


        private ColorObject(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {
            Color = element.GetColor();
        }

        object Get()
        {
            return Color;
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new ColorObject(element, null);
            return a.Get();
        }
    }
}