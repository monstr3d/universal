using System.Drawing;
using System.Windows.Media;
using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("color", true)]
    internal class ColorObject : XmlHolder
    {
        static public readonly string Tag = "color";

        /// <summary>
        /// Is elementary
        /// </summary>
        static public readonly bool IsElementary = true;



        public System.Windows.Media.Color Color { get; private set; }

        private ColorObject(XmlElement element) : base(element)
        {
            Color = element.GetColor();
        }

        object Get()
        {
            return Color;
        }

        public static object Get(XmlElement element)
        {
            var a = new ColorObject(element);
            return a.Get();
        }
    }
}