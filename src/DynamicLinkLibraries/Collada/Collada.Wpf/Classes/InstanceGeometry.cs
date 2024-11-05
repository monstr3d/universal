using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("instance_geometry")]
    internal class InstanceGeomery : XmlHolder
    {
        static public readonly string Tag = "instance_geometry";

        private InstanceGeomery(XmlElement element) : base(element)
        {

        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new InstanceGeomery(element);
            return a.Get();
        }
    }
}