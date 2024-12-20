using System.Xml;
using Abstract3DConverters.Interfaces;
using Collada;

namespace Collada150.Classes
{
    [Tag("p", true)]
    internal class P : XmlHolder
    {

        /// <summary>
        /// Is elementary
        /// </summary>
        static public readonly bool IsElementary = true;

        public static IClear Clear => StaticExtensionCollada.GetClear<P>();


        public int[] p { get; private set; }

        protected P(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {
            p = element.InnerText.ToRealArray<int>();
        }

        protected virtual object Get()
        {
            return p;
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new P(element, meshCreator);
            return a.Get();
        }

    }
}