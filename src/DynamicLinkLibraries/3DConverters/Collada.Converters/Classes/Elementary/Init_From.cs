using System.Xml;
using Abstract3DConverters.Interfaces;
using Collada;

namespace Collada.Converters.Classes.Complicated
{
    [Tag("init_from", true)]
    public class Init_From : XmlHolder
    {

        public static IClear Clear => StaticExtensionCollada.GetClear<Init_From>();

        internal string Text { get; private set; }

        private Init_From(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {
            Text  = element.InnerText;
        }

 

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Init_From(element, meshCreator);
            return a.Get();
        }
    }
}
