using Abstract3DConverters.Interfaces;
using Collada;
using System.Xml;


namespace Collada150.Classes .Elementary   
{
    [Tag("vcount", true)]
    internal class VCount : P
    {

        public static new IClear Clear => StaticExtensionCollada.GetClear<VCount>();


        private VCount(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {

        }

        protected override object Get()
        {
            return this;
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new VCount(element, null);
            return a.Get();
        }
    }
}
