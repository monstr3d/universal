using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("scene")]
    internal class Scene : XmlHolder
    {
        static public readonly string Tag = "scene";

        private Scene(XmlElement element) : base(element)
        {
            var c = Node.Roots;

        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new Scene(element);
            return a.Get();
        }
    }
}