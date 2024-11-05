using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("node")]
    internal class Node : XmlHolder
    {
        static public readonly string Tag = "node";

        private Node(XmlElement element) : base(element)
        {

        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new Node(element);
            return a.Get();
        }
    }
}