using Collada;
using System.Xml;


namespace Collada.Wpf.Classes
{
    [Tag("vcount", true)]
    internal class VCount : P
    {
        static public new  readonly string Tag = "vcount";

        /// <summary>
        /// Is elementary
        /// </summary>
        static public readonly bool IsElementary = true;


        private VCount(XmlElement element) : base(element)
        {

        }

        protected override object Get()
        {
            return p;
        }

        public static object Get(XmlElement element)
        {
            var a = new VCount(element);
            return a.Get();
        }
    }
}
