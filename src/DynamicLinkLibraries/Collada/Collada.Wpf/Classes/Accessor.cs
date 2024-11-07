using System;
using System.Linq;
using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("accessor")]
    public class Accessor : XmlHolder
    {

        public float[] Array { get; private set; }

        public Param[] Params { get; private set; }

        public Source Source { get; private set; }

        public static IClear Clear => StaticExtensionCollada.GetClear<Accessor>();



        public Accessor(XmlElement element) : base(element)
        {
            Params = "param".ByTag<Param>(element).ToArray(); ;
            var s = element.GetAttribute("source").Substring(1);
            var ob = s.Get<Float_Array>();
            if (ob == null)
            {
                throw new Exception();
            }
            Array = ob.Array;
        }

        public static object Get(XmlElement element)
        {
            return new Accessor(element);
        }
    }
}
