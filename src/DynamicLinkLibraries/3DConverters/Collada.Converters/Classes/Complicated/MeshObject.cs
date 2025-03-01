using System.Xml;
using Abstract3DConverters.Interfaces;

namespace Collada.Converters.Classes.Complicated
{
    [Tag("mesh")]
    internal class MeshObject : Collada.XmlHolder
    {

        public Triangles Triangles 
        { 
            get; 
            private set; 
        }

        public PolyList Polygon 
        { 
            get; 
            private set; 
        }

        public static IClear Clear => StaticExtensionCollada.GetClear<MeshObject>();

        private MeshObject(XmlElement xmlElement) : base(xmlElement)
        {
            Triangles = xmlElement.Get<Triangles>();
            Polygon = xmlElement.Get<PolyList>();
            if (Triangles != null | Polygon != null)
            {
                return;
            }
            var vert = xmlElement.Get<Vertices>();
          
        }

        static public object Get(XmlElement xmlElement, IMeshCreator meshCreator)
        {
            return new MeshObject(xmlElement);
        }

    }
}