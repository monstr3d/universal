using System.Xml;

namespace Collada.Wpf.Classes
{
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

        public static object MeskObject(XmlElement element)
        {
            var a = new MeshObject(element);
            return a.Get();
        }
    }
}