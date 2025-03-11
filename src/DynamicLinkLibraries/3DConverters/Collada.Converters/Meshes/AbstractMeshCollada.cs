using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Meshes;
using Collada.Converters.Classes.Complicated;
using Collada.Converters.MeshCreators;
using ErrorHandler;

namespace Collada.Converters.Meshes
{
    
    class AbstractMeshCollada : AbstractMeshPolygon
    {

        private ColladaMeshCreator meshCreator;

        float[] GetValue(object o)
        {
            switch (o)
            {
                case Source so:
                    return so.Array;
                case Vertices v:
                    return v.Array;
            }
            throw new Exception("Collade GetValue");
        }


        internal AbstractMeshCollada(InstanceGeomery geom, BindMaterial material, string name, float[] mm, ColladaMeshCreator creator) : base(name, null, mm, creator)
        {
            try
            {
                if (geom == null)
                {
                    return;
                }
                meshCreator = creator;
                Effect = material.Effect;
                var g = geom.Geometry;
                var meshObject = g.Mesh;
                var tr = meshObject.Triangles;
                List<float[]> vertices = null;
                List<float[]> normal = null;
                List<float[]> textures = null;
                List<int[][]> t = null;
                var poly = meshObject.PolyList as IMesh;
                if (poly == null)
                {
                    if (!s.IsEmpty(meshObject.Triangles))
                    {
                        poly = meshObject.Triangles[0];
                    }
                    else
                    {
                        poly = meshObject;
                    }
                }
                Vertices = poly.Vertices;
                Textures = poly.Textures;
                Normals = poly.Normals;
                Polygons = new();
                s.CopyPolygons(poly, this);
                if (!s.CheckPolygons(this))
                {
                    throw new Exception("Abstract mesh collada polygons");
                }
                return;
            }
            catch (Exception e)
            {
                e.HandleException("AbstractMeshCollada constructor");
                throw new IncludedException(e, "AbstractMeshCollada constructor");
            }
        }
    }
}
