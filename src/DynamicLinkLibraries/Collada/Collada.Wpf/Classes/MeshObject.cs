using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("mesh")]
    internal class MeshObject : XmlHolder
    {
        static public readonly string Tag = "mesh";

        private MeshObject(XmlElement element) : base(element)
        {

        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new MeshObject(element);
            return a.Get();
        }
    }
}