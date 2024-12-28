using Abstract3DConverters.Creators;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;

namespace Abstract3DConverters.Meshes
{
    internal class AbstractMeshAC : AbstractMeshPolygon
    {

        List<int> mats = new List<int>();

        Dictionary<Polygon, int> dp = new Dictionary<Polygon, int>();

        List<Material> materials;

        int count;

        List<string> l;

        public Image Image
        {
            get;
            private set;
        }


        public AbstractMeshAC(AbstractMesh parent, string name, AcCreator creator, int count, List<string> l, List<Material> materials, string directory) :
            base(name, parent, creator)
        {
            this.count = count;
            this.materials = materials;
            this.l = l;
            int nv = -1;
            int ns = -1;
            this.creator = creator;
            for (int i = 0; i < l.Count; i++)
            {
                var line = l[i];
                var loc = s.ToString(line, "loc ");
                if (loc != null)
                {
                    var location = s.ToRealArray<float>(loc);
                    TransformationMatrix = [ 1, 0, 0, 0,
                                             0, 1, 0, 0,
                                             0, 0, 1, 0,
                                            location[0], location[1], location[2], 0 ];
                }
                var texture = s.ToString(line, "texture ");
                if (texture != null)
                {
                    Image = new Image(texture, directory);
                }
                var numvert = s.ToReal<int>(line, "numvert ");
                if (numvert != null)
                {
                    nv = numvert.Value;
                    var v = new List<float[]>();
                    Vertices = v;
                    var j = i + 1;
                    for (; j < nv + i + 1; j++)
                    {
                        v.Add(s.ToRealArray<float>(l[j]));
                    }
                    i = j - 1;
                    continue;
                }
                var numsurf = s.ToReal<int>(line, "numsurf ");
                if (numsurf != null)
                {
                    ns = numsurf.Value;
                    int mt = -1;
                    var nc = numsurf.Value;
                    var k = i + 1;
                    for (; k < l.Count; k++)
                    {
                        var mp = s.ToReal<int>(l[k], "mat ");
                        {
                            if (mp != null)
                            {
                                mt = mp.Value;
                                if (!mats.Contains(mt))
                                {
                                    mats.Add(mt);
                                }
                                continue;
                            }
                        }
                        var refs = s.ToReal<int>(l[k], "refs ");
                        if (refs != null)
                        {
                            var rf = refs.Value;
                            var p = k + 1;
                            var pp = new List<Tuple<int, int, int, float[]>>();
                            int j = 0;
                            for (; p < l.Count; p++)
                            {
                                var il = l[p];
                                var ss = s.Split(il);
                                var t = new Tuple<int, int, int, float[]>(s.ToReal<int>(ss[0].Trim()), j, -1, new float[] { s.ToReal<float>(ss[1].Trim()),
                                    s.ToReal< float >(ss[2].Trim()) });
                                pp.Add(t);
                                ++j;
                                if (pp.Count == rf)
                                {
                                    break;
                                }

                            }
                            var matetrial = materials[mt];
                            matetrial = matetrial.Clone() as Material;
                            var polygon = new Polygon(pp, matetrial);
                            dp[polygon] = mt;
                            Polygons.Add(polygon);
                        }
                        if (Polygons.Count < ns)
                        {
                            continue;
                        }
                        else
                        {
                            if (mats.Count == 1)
                            {
                                var mat = materials[dp.Values.ToArray()[0]];
                                Material = mat.Clone() as Material;
                                SetImage(Material, Image);
                            }
                            i = k;
                            continue;
                        }

                    }
                    i = k;
                    continue;
                }
            }
        }

        private AbstractMeshAC(AbstractMeshAC parent, Polygon polygon, Material material, Image image, IMeshCreator creator) :
            base(parent.Name + Guid.NewGuid(), parent, creator)
        {
            Vertices = new List<float[]>();
            var d = new Dictionary<int, int>();
            int i = 0;
            foreach (var p in polygon.Points)
            {
                var k = p.Item1;
                if (!d.ContainsKey(k))
                {
                    d[k] = i;
                    ++i;
                }
            }
            foreach (var key in d.Keys)
            {
                if ((key < 0) | (key >= parent.Vertices.Count))
                {

                }
                Vertices.Add(parent.Vertices[key]);
            }
            var l = new List<Tuple<int, int, int, float[]>>();
            foreach (var p in polygon.Points)
            {
                var t = new Tuple<int, int, int, float[]>(d[p.Item1], p.Item2, p.Item3, p.Item4);
                l.Add(t);
            }
            var pol = new Polygon(l, material.Clone() as Material);
            Polygons.Add(pol);
            Material = material.Clone() as Material;
            if (image != null)
            {
                Image = image.Clone() as Image;
                SetImage(Material, Image);
            }
        }

        public override void Disintegrate()
        {
            if (mats.Count > 1)
            {
                if (Vertices.Count > 0)
                {
                    foreach (Polygon p in Polygons)
                    {
                        int h = 0;
                        h = dp[p];
                        var mat = materials[h];
                        new AbstractMeshAC(this, p, mat, Image, creator);
                    }
                    Vertices = new List<float[]>();
                    Polygons.Clear();
                    Image = null;
                }
            }
        }
    }
}