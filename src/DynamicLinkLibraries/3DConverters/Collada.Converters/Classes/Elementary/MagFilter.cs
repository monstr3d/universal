using System.Xml;
using Abstract3DConverters.Interfaces;
using Collada;

namespace Collada.Converters.Classes.Elementary
{
    [Tag("magfilter", true)]
    internal class MagFilter : XmlHolder
    {
 


        public static IClear Clear => StaticExtensionCollada.GetClear<MagFilter>();


        private MagFilter(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {

        }


        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new MagFilter(element, meshCreator);
            return a.Get();
        }
    }
}
