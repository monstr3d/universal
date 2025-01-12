
using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("vertices")]
    public class Vertices : XmlHolder
    {
 
        public Sid Sid { get; private set; }

        public Input Input { get; private set; }

        private Vertices(XmlElement xml) : base(xml)
        {
            Input = xml.Get<Input>();
        }
        public static IClear Clear => StaticExtensionCollada.GetClear<Vertices>();


        private object Value => this;


        public static object Get(XmlElement xml)
        {
            var v = new Vertices(xml);
            return v.Value;
        }

    }
}
