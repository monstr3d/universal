using Abstract3DConverters.Interfaces;
using System.Xml;
using Collada;
using Collada150.Classes.Elementary;

namespace Collada150.Classes.Comlicated
{
    [Tag("transparency")]
    internal class Transparency : XmlHolder
    {

        public static IClear Clear => StaticExtensionCollada.GetClear<Transparency>();
        public float Value { get; private set; }

        private Transparency(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {
            Value = element.Get<FloatObject>().Value;
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Transparency(element, meshCreator);
            return a.Get();
        }
    }
}

