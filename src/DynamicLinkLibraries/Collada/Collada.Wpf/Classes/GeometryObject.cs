using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("geometry")]
    internal class GeometryObject : XmlHolder
    {
        static public readonly string Tag = "geometry";

        private GeometryObject(XmlElement element) : base(element)
        {

        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new GeometryObject(element);
            return a.Get();
        }
    }
}