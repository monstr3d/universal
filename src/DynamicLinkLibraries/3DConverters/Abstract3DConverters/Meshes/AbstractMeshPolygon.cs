using Abstract3DConverters.Interfaces;

namespace Abstract3DConverters.Meshes
{
    public class AbstractMeshPolygon : AbstractMesh
    {

        IPolygonSplitter splitter = StaticExtensionAbstract3DConverters.PolygonSplitter;

        protected List<Polygon> Polygons
        { get; } = new List<Polygon>();


        public AbstractMeshPolygon(string name, AbstractMeshPolygon parent, IMeshCreator creator) :
            base(name, creator)
        {
            Parent = parent;
        }

        public AbstractMeshPolygon(string name, AbstractMeshPolygon parent, string material, IMeshCreator creator) :
            this(name, parent, creator)
        {
            MaterialString = material;
        }

        public void CreateFromPolygons()
        {
            if (Polygons.Count == 0)
            {
                return;
            }
            List<Polygon> polygons = new List<Polygon>();
            foreach (var polygon in Polygons)
            {
                var pp = splitter[polygon];
                foreach (var p in pp)
                {
                    polygons.Add(p);
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