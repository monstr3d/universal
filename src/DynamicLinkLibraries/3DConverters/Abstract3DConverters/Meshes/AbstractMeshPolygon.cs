using Abstract3DConverters.Interfaces;

namespace Abstract3DConverters.Meshes
{
    public abstract class AbstractMeshPolygon : AbstractMesh
    {

        IPolygonSplitter splitter = StaticExtensionAbstract3DConverters.PolygonSplitter;

        public List<Polygon> Polygons
        { get; } = new List<Polygon>();


        public AbstractMeshPolygon(string name, AbstractMesh parent, IMeshCreator creator) :
            base(name, creator)
        {
            Parent = parent;
        }

        public AbstractMeshPolygon(string name, AbstractMesh parent, string material, IMeshCreator creator) :
            this(name, parent, creator)
        {
            MaterialString = material;
        }

        public void CreateTriangles()
        {
            Disintegrate();
            CreateFromPolygons();
        }

        protected abstract void Disintegrate();

        protected void CreateFromPolygons()
        {
            if (Polygons.Count == 0)
            {
                return;
            }
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
                    var iii = new int[] { pp.Item1, k, pp.Item3 };
                    ii[j] = iii;
                    txt.Add(pp.Item4);
                    ++k;
                }
            }
        }
    }
}