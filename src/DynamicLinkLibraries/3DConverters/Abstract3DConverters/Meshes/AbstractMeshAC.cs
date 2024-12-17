using System.Linq.Expressions;
using Abstract3DConverters.Creators;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;

namespace Abstract3DConverters.Meshes
{
    public class AbstractMeshAC : AbstractMeshPolygon
    {



        Dictionary<Polygon, int> dp = new Dictionary<Polygon, int>();

        int count;

        List<string> l;

        int shift = -1;

        public Image Image
        {
            get;
            private set;
        }


        public AbstractMeshAC(AbstractMeshAC parent, string name, AcCreator creator, int count, List<string> l, List<Material> materials, string directory) :
            base(name, parent, creator)
        {
            if (creator is AcCreator ac)
            {
                shift = ac.Shift;
            }
            this.count = count;
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
                    var mats = new List<int>();
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
                                if (pp.Count == refs)
                                {
                                    break;
                                }

                            }
                            var polygon = new Polygon(pp);
                            dp[polygon] = mt;
                            Polygons.Add(polygon);
                        }
                        if (Polygons.Count < ns)
                        {
                            continue;
                        }
                        if (mats.Count == 1)
                        {
                            var mat = materials[dp.Values.ToArray()[0]];
                            Material = mat.Clone() as Material;
                            SetImage(Material, Image);
                        }
                        else if (mats.Count > 1)
                        {
                            if (Vertices.Count > 0)
                            {
                                foreach (Polygon p in Polygons)
                                {
                                    var mat = materials[dp[p]];
                                    new AbstractMeshAC(this, p, mat, Image, creator);
                                }
                                Vertices = new List<float[]>();
                                Polygons.Clear();
                                Image = null;
                            }
                        }
                    }
                    i = k;
                    continue;
                }
            }

        }

        private AbstractMeshAC(AbstractMeshAC parent, Polygon polygon, Material material, Image image, IMeshCreator creator) :
            base(parent.Name, parent, creator)
        {
            /*       TransformationMatrix = [ 1, 0, 0, 0,
                                                    0, 1, 0, 0,
                                                    0, 0, 1, 0,
                                                   0, 0, 0, 0 ];
            */

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
                Vertices.Add(parent.Vertices[key]);
            }
            var l = new List<Tuple<int, int, int, float[]>>();
            foreach (var p in polygon.Points)
            {
                var t = new Tuple<int, int, int, float[]>(d[p.Item1], p.Item2, p.Item3, p.Item4);
                l.Add(t);
            }
            var pol = new Polygon(l);
            Polygons.Add(pol);
            Material = material.Clone() as Material;
            if (image != null)
            {
                Image = image.Clone() as Image;
                SetImage(Material, Image);
            }
        }
    }
}