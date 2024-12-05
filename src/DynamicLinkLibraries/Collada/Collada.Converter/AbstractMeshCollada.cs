using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract3DConverters;
using Collada141;

namespace Collada.Converter
{
    internal class AbstractMeshCollada : AbstractMesh
    {

        private instance_geometry[] instance_geometry;
        instance_geometry geometry;

        bind_material bind_material;


        internal AbstractMeshCollada(node node) : base(node.name)
        {

            instance_geometry = node.instance_geometry;
            if (instance_geometry != null)
            {
                CreateInstanceGeometry();
            }
        }

        void CreateInstanceGeometry()
        {
            foreach (var geom in instance_geometry)
            {
                if (geometry != null & geom != null)
                {
                    throw new Exception();
                }
                geometry = geom;
            }
            CreateGeometry();
        }

        void CreateGeometry()
        {
            bind_material = geometry.bind_material;
            CreateMaterial();
            
        }

        void CreateMaterial()
        {
            var bm = bind_material;
        }



        
    }
}
