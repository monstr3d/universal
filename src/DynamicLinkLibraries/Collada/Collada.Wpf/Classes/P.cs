using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("p", true)]
    internal class P : XmlHolder
    {
        static public readonly string Tag = "p";

        /// <summary>
        /// Is elementary
        /// </summary>
        static public readonly bool IsElementary = true;

        public static IClear Clear => StaticExtensionCollada.GetClear<P>();


        public int[] p { get; private set; }

        protected P(XmlElement element) : base(element)
        {
            p = element.ToRealArray<int>();
        }

        protected virtual object Get()
        {
            return p;
        }

        public static object Get(XmlElement element)
        {
            var a = new P(element);
            return a.Get();
        }

    }
}