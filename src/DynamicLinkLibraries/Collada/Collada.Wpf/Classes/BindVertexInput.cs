using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Collada.Wpf.Classes
{
    internal class BindVertexInput : XmlHolder
    {
        public static readonly string Tag = "bind_vertex_input";
        private BindVertexInput(XmlElement element) : base(element)
        {

        }

        internal static object Get(XmlElement element)
        {
            return new BindVertexInput(element);
        }
    }
}
