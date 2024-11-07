using System.Windows.Media.Media3D;
using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("polylist")]
    internal class PolyList : XmlHolder
    {
        static public readonly string Tag = "polylist";

        public Material Material { get; private set; }

        private PolyList(XmlElement element) : base(element)
        {
            Material = element.GetMaterial();

        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new PolyList(element);
            return a.Get();
        }
    }
}