
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml;

namespace Collada.Wpf.Classes
{
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
        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new Transparent(element);
            return a.Get();
        }
    }
}
