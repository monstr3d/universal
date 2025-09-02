

using System.Xml;
using Abstract3DConverters;
using Abstract3DConverters.Interfaces;
using Collada;
using Collada.Converters.Classes.Abstract;

namespace Collada.Converters.Classes.Complicated
{
    [Tag("transparent")]
    internal class Transparent : ColorWrapper
    {

        public static IClear Clear => StaticExtensionCollada.GetClear<Transparent>();
      
        private Transparent(XmlElement element) : base(element)
        {

        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Transparent(element);
            return a.Get();
        }
    }
}
