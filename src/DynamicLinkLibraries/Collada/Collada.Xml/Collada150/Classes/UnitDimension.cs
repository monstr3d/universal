using System.Xml;
using Collada;

namespace Collada150.Classes
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