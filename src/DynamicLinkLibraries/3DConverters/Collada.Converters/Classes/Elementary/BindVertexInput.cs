using System.Xml;
using Abstract3DConverters.Interfaces;

namespace Collada.Converters.Classes.Complicated
{
    [Tag("bind_vertex_input", true)]
    internal class BindVertexInput : XmlHolder
    {

        public static IClear Clear => StaticExtensionCollada.GetClear<BindVertexInput>();

        public static readonly string Tag = "bind_vertex_input";

        static string xml = null;
        private BindVertexInput(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {
            var x = element.OuterXml;
            if (xml == null)
            {
                xml = x;
            }
            else
            {
                if (xml != x)
                {
                    throw new Exception("Bind Vertex Input");
                }
            }
        }
        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            return new BindVertexInput(element, null);
        }
    }
}
