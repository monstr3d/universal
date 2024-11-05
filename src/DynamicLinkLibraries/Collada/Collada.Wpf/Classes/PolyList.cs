using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("polylist")]
    internal class PolyList : XmlHolder
    {
        static public readonly string Tag = "polylist";

        private PolyList(XmlElement element) : base(element)
        {

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