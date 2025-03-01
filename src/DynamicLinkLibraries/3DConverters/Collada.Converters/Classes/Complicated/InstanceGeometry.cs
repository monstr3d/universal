using System.Xml;
using Abstract3DConverters.Interfaces;

namespace Collada.Converters.Classes.Complicated
{
    [Tag("instance_geometry")]
    public class InstanceGeomery : XmlHolder
    {
  
        public static IClear Clear => StaticExtensionCollada.GetClear<InstanceGeomery>();



        public GeometryObject Geometry { get; private set; }



        private InstanceGeomery(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {
            var url = element.GetAttribute("url").Substring(1);
            Geometry = url.Get<GeometryObject>();
        }


        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new InstanceGeomery(element,  meshCreator);
            return a.Get();
        }
    }
}