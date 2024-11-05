using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("A")]
    internal class A : XmlHolder
    {
 
        /// <summary>
        /// Is elementary
        /// </summary>
        static public readonly bool IsElementary = false;


        private A(XmlElement element) : base(element)
        {

        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new A(element);
            return a.Get();
        }
    }
}