using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Collada.Wpf
{
    public class Vertices : XmlHolder
    {
        public readonly static string Tag = "vertices";

        public Sid Sid { get; private set; }

        private Vertices(XmlElement xml) : base(xml)
        {

        }

        private object Value => this;
        

        public static object Get(XmlElement xml)
        {
            var v = new Vertices(xml);
            return v.Value;
        }

    }
}
