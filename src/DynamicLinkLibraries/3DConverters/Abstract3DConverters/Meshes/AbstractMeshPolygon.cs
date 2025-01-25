using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;

namespace Abstract3DConverters.Meshes
{
    public  class AbstractMeshPolygon : AbstractMesh
    {

        IPolygonSplitter splitter = StaticExtensionAbstract3DConverters.PolygonSplitter;
        public AbstractMeshPolygon(string name, AbstractMesh parent,  IMeshCreator creator) :
            base(name, creator)
        {
            if (parent != null)
            {
                Parent = parent;
            }
        }

        public AbstractMeshPolygon(string name, AbstractMesh parent, string material, IMeshCreator creator) :
            this(name, parent, creator)
        {
            MaterialString = material;
        }

        public AbstractMeshPolygon(string name, AbstractMesh parent, string material, IMeshCreator creator, List<Polygon> polygons) :
            this(name, parent, material, creator)
        {
            foreach (var p in polygons)
            {
                Polygons.Add(p);
            }
        }

        public AbstractMeshPolygon(string name, AbstractMesh parent, Material material, List<Polygon> polygons, IMeshCreator creator) :
      this(name, parent, null, creator)
        {
            Material = material;
            foreach (var p in polygons)
            {
                Polygons.Add(p);
            }
        }

        public AbstractMeshPolygon(string name, AbstractMesh parent, Material material, List<Polygon> polygons, List<float[]> vertices, List<float[]> normals, IMeshCreator creator) :
            this(name, parent, material, polygons, creator)
        {
            Vertices = vertices;
            Normals = normals;
        }


        public override void CreateTriangles()
        {
            base.CreateTriangles();
            trianlesCreared = false;
            Disintegrate();
            CreateFromPolygons();
            trianlesCreared = true;
        }

        protected virtual void Disintegrate()
        {

        }

        protected void CreateFromPolygons()
        {
            if (Polygons.Count > 0 & !trianlesCreared)
            {
                List<Polygon> polygons = new List<Polygon>();
                foreach (var polygon in Polygons)
                {
                    if (polygon.Points.Count <= 3)
                    {
                        polygons.Add(polygon);
                    }
                    else
                    {
                        var pp = splitter[polygon];
                        foreach (var p in pp)
                        {
                            polygons.Add(p);
                        }
                    }
                }
                var idx = new List<int[][]>();
                Indexes = idx;
                var txt = new List<float[]>();
                Textures = txt;
                var k = 0;
                foreach (var p in polygons)
                {
                    var t = p.Points;
                    var ii = new int[t.Count][];
                    idx.Add(ii);
                    for (int j = 0; j < t.Count; j++)
                    {
                        var pp = t[j];
                        var iii = new int[] { pp.Vertex, k, pp.Normal };
                        ii[j] = iii;
                        txt.Add(pp.Data);
                        ++k;
                    }
                }
            }
        }
    }
}