using System;
using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("bind_vertex_input", true)]
    internal class BindVertexInput : XmlHolder
    {
        public static readonly string Tag = "bind_vertex_input";

        static string xml = null;
        private BindVertexInput(XmlElement element) : base(element)
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
                    throw new Exception();
                }
            }
        }
        public static object Get(XmlElement element)
        {
            return new BindVertexInput(element);
        }
    }
}
