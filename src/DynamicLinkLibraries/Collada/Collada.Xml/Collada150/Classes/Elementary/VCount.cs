using Abstract3DConverters.Interfaces;
using Collada;
using System.Xml;


namespace Collada150.Classes
{
    [Tag("vcount", true)]
    internal class VCount : P
    {

        public static IClear Clear => StaticExtensionCollada.GetClear<VCount>();


        private VCount(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {

        }

        protected override object Get()
        {
            return p;
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new VCount(element, null);
            return a.Get();
        }
    }
}
