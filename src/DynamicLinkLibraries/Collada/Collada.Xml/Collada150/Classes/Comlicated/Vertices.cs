
using System.Xml;
using Abstract3DConverters.Interfaces;
using Collada;

namespace Collada150.Classes.Comlicated
{
    [Tag("vertices")]
    public class Vertices : XmlHolder
    {


        public Input Input { get; private set; }

        private Vertices(XmlElement xml) : base(xml, null)
        {
            Input = xml.Get<Input>();
        }
        public static IClear Clear => StaticExtensionCollada.GetClear<Vertices>();


        private object Value => this;


        public static object Get(XmlElement xml, IMeshCreator meshCreator)
        {
            var v = new Vertices(xml);
            return v.Value;
        }

    }
}
