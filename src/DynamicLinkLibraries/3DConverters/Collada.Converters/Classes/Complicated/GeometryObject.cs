using System.Xml;

using Abstract3DConverters;
using Abstract3DConverters.Interfaces;

using Collada.Converters.MeshCreators;



namespace Collada.Converters.Classes.Complicated
{
    [Tag("geometry")]
    public class GeometryObject : Collada.XmlHolder
    {
    
  
        public static IClear Clear => StaticExtensionCollada.GetClear<GeometryObject>();

      
      
        internal MeshObject Mesh { get; private set; }

        public Abstract3DConverters.Materials.Effect Effect { get; private set; }


        private GeometryObject(XmlElement element, IMeshCreator meshCreator) : base(element)
        {
            try
            {
                Mesh = element.Get<MeshObject>();
                var b = element.Get<BindMaterial>();
                if (b != null)
                {
                    Effect = b.Effect;
                }
                var creator = meshCreator as ColladaMeshCreator;
                creator.Geom[element.GetAttribute("id")] = this;
            }
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("Collada geometry");
            }
            
        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new GeometryObject(element, meshCreator);
            return a.Get();
        }
    }
}