using Abstract3DConverters.Interfaces;
using Collada.Converters.Classes.Abstract;
using System.Xml;

namespace Collada.Converters.Classes.Complicated
{
  
    [Tag("specular")]
    internal class Specular : ColorWrapper
    {

        public static IClear Clear => StaticExtensionCollada.GetClear<Specular>();

        private Specular(XmlElement element) : base(element)
        {

        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Specular(element);
            return a.Get();
        }
    }
}

