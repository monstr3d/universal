using System.Xml;
using Abstract3DConverters.Interfaces;
using Collada;

namespace Collada150.Classes.Elementary
{
    [Tag("unit", true)]
    internal class UnitDimension : XmlHolder
    {


        public static IClear Clear => StaticExtensionCollada.GetClear<UnitDimension>();

        private UnitDimension(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {

        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new UnitDimension(element, meshCreator);
            return a.Get();
        }
    }
}