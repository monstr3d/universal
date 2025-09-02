using System.Xml;
using Abstract3DConverters.Interfaces;
using Collada;

namespace Collada.Converters.Classes.Elementary
{
    [Tag("up_axis", true)]
    internal class Up_Axis : XmlHolder
    {

        public static IClear Clear => StaticExtensionCollada.GetClear<Up_Axis>();



        private Up_Axis(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {

        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Up_Axis(element, meshCreator);
            return a.Get();
        }
    }
}