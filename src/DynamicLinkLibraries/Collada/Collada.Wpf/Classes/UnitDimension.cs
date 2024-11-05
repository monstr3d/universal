using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("unit", true)]
    internal class UnitDimension : XmlHolder
    {
  
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