using System.Xml;

namespace Collada.Wpf.Classes
{
    internal class UnitDimension : XmlHolder
    {
        static public readonly string Tag = "unit";

        private UnitDimension(XmlElement element) : base(element)
        {

        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new UnitDimension(element);
            return a.Get();
        }
    }
}