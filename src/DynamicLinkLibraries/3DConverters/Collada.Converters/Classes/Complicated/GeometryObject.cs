
using System.Xml;
using System;
using System.Collections.Generic;
using Collada;
using Abstract3DConverters.Interfaces;
using Collada.Converters.MeshCreators;

namespace Collada.Converters.Classes.Complicated
{
    [Tag("geometry")]
    public class GeometryObject : Collada.XmlHolder
    {
    
  
        public static IClear Clear => StaticExtensionCollada.GetClear<GeometryObject>();

      
      
        internal MeshObject Mesh { get; private set; }

        public Abstract3DConverters.Materials.Material Material { get; private set; }


        private GeometryObject(XmlElement element, IMeshCreator meshCreator) : base(element)
        {
            Mesh = element.Get<MeshObject>();
            var b = element.Get<BindMaterial>();
            if (b != null)
            {
                Material = b.Material;
            }
            var creator = meshCreator as ColladaMeshCreator;
            creator.Geom[element.GetAttribute("id")] = this;
            
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