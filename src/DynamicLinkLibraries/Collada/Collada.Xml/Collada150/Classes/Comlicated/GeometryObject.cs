
using System.Xml;
using System;
using System.Collections.Generic;
using Collada;
using Abstract3DConverters.Interfaces;

namespace Collada150.Classes.Comlicated
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
            var creator = meshCreator as Collada150.Creators.Collada15MeshCreator;
            creator.Geom[element.GetAttribute("id")] = this;
            
        }
 /*           var name = element.GetAttribute("name");
            if (name.Length > 0)
            {
                if (byName.ContainsKey(name))
                {
                    throw new Exception();
                }
                byName[name] = this;
            }
            var mesh = element.Get<MeshObject>();
            if (mesh == null)
            {
                throw new Exception();
            }
            var geom = new GeometryModel3D();
            geom.Geometry = mesh.MeshGeometry3D;
            geom.Material = mesh.Material;
            var mod = new ModelVisual3D();
            mod.Content = geom;
            Visual3D = mod;
            if (geom.Material == null)
            {
                var id = element.GetAttribute("id");
            }
        }*/

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