using System.Windows.Media.Media3D;
using System.Xml;
using System;

namespace Collada.Wpf.Classes
{
    [Tag("instance_geometry")]
    public class InstanceGeomery : XmlHolder
    {
        static public readonly string Tag = "instance_geometry";

        bool isCombined = false;

        public Material Material { get; private set; }

        public void Combine()
        {
            if (isCombined)
            {
                return;
            }
            var x = Xml;
            var b = x.Get<BindMaterial>();
            if (b != null)
            {
                Material = b.Material;
            }
            else
            {
                throw new Exception();
            }

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