using System.Xml;

namespace Collada.Wpf.Classes
{
    internal class BingMaterial : XmlHolder
    {
        static public readonly string Tag = "bind_material";

        private BingMaterial(XmlElement element) : base(element)
        {

        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new BingMaterial(element);
            return a.Get();
        }
    }
}