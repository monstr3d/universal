using System.Xml;
using Abstract3DConverters.Interfaces;
using Collada;

namespace Collada.Converters.Classes.Elementary
{
    [Tag("minfilter", true)]
    internal class MinFilter : XmlHolder
    {


        public static IClear Clear => StaticExtensionCollada.GetClear<MinFilter>();

        private MinFilter(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {

        }

        


        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new MinFilter(element, meshCreator);
            return a.Get();
        }
    }
}