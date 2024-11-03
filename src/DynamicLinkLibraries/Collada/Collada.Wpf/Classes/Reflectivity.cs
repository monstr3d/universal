using System.Xml;

namespace Collada.Wpf.Classes
{
    internal class Reflectivity : XmlHolder
    {
        static public readonly string Tag = "reflectivity";

        public double Value { get; private set; }

        private Reflectivity(XmlElement element) : base(element)
        {
            Value = element.ToDouble();
        }

        object Get()
        {
            return Value;
        }

        public static object Get(XmlElement element)
        {
            var a = new Reflectivity(element);
            return a.Get();
        }
    }
}