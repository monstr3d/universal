using Collada;
using System.Xml;


namespace Collada.Wpf.Classes
{

    internal class VCount : P
    {
        static public new  readonly string Tag = "vcount";

        private VCount(XmlElement element) : base(element)
        {

        }

        public static new object Get(XmlElement element)
        {
            var a = new VCount(element);
            return a.Get();
        }
    }
}
