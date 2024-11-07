
using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("vertices")]
    public class Vertices : XmlHolder
    {
 
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
