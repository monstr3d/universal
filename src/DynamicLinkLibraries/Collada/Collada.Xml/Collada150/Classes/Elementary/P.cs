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


        public int[] Value { get; private set; }

        protected P(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {
            Value = element.InnerText.ToRealArray<int>();
        }

 
        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new P(element, meshCreator);
            return a.Get();
        }

    }
}