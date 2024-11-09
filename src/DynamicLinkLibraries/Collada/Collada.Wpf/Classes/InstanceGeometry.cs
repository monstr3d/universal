using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("instance_geometry")]
    public class InstanceGeomery : XmlHolder
    {
        static public readonly string Tag = "instance_geometry";

        bool isCombined = false;

        public void Combine()
        {
            if (isCombined)
            {
                return;
            }
            var x = Xml;

            isCombined = true;
        }

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