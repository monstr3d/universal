using Abstract3DConverters.Creators;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Points;
using Microsoft.VisualBasic;

namespace Abstract3DConverters.Meshes
{
    internal class AbstractMeshAC : AbstractMeshPolygon
    {

    
        Dictionary<Polygon, int> dp = new Dictionary<Polygon, int>();

        List<Material> materials = new();

        List<string> mats = new List<string>()]

        int count = 0;
  

        List<string> l;

        public Image Image
        {
            get;
            private set;
        }


        public AbstractMeshAC(AbstractMesh parent, string name,  AcCreator creator, int count, List<string> l, List<Material> materials,  string directory) :
            base(name, parent, null, creator)
        {
            var dd = new Dictionary<int, float[]>();
            var pos = creator.Position;
            this.count = count;
            this.materials = materials;
            this.l = l;
            int nv = -1;
            int ns = -1;
            this.creator = creator;
            int txt = 0;
            var ds = new Dictionary<int, float[]>();
            var vrt = new List<float[]>();
            for (int i = pos; i < l.Count; i++)
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
                        var vertex = s.ToRealArray<float>(l[j]);
                        v.Add(vertex);
                        vrt.Add(vertex);
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
                    ++i;
                    for (var surf = 0; surf < nc; surf++)
                    {
                        i += 2;
                        var mp = s.ToReal<int>(l[i], "mat ");
                        mt = mp.Value;
                        var material = materials[mt];
                        var mn = material.Name;
                        if (!mats.Contains(mn))
                        {
                            mats.Add(mn);
                        }
                        ++i;
                        var refs = s.ToReal<int>(l[i], "refs ");
                        var lp = new List<int>();
                        var rf = refs.Value;

                        for (var rr = 0; rr < rf; rr++)
                        {
                            ++i;
                            var lp = new List<int>();
                            for (; p < l.Count; p++)
                            {
                                var il = l[p];
                                var ss = s.Split(il);
                                var key = s.ToReal<int>(ss[0].Trim());
                                lp.Add(key);
                                if (!dd.ContainsKey(key))
                                {
                                    dd[key] = new float[] { s.ToReal<float>(ss[1].Trim()),
                                    s.ToReal< float >(ss[2].Trim()) };
                                }
                                else
                                {

                                }

                            }


                        }
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
                            if (Polygons == null)
                            {
                                Polygons = new();
                            }
                            var rf = refs.Value;
                            var p = k + 1;
                            var pp = new List<PointAC>();
                            var lp = new List<int>();
                            for (; p < l.Count; p++)
                            {
                                var il = l[p];
                                var ss = s.Split(il);
                                var key = s.ToReal<int>(ss[0].Trim());
                                lp.Add(key);
                                if (!dd.ContainsKey(key))
                                {
                                    dd[key] = new float[] { s.ToReal<float>(ss[1].Trim()),
                                    s.ToReal< float >(ss[2].Trim()) };
                                }
                                else
                                {

                                }
                                if (false)
                                {
                                    var t = new PointAC(s.ToReal<int>(ss[0].Trim()), txt, 0, new float[] { s.ToReal<float>(ss[1].Trim()),
                                    s.ToReal< float >(ss[2].Trim()) });
                                    pp.Add(t);
                                    ++txt;
                                }
                                if (lp.Count == rf)
                                {
                                    break;
                                }

                            }
                            
                            var material = materials[mt];
                            if (Image != null)
                            {
                                material = material.SetImage(Image);
                            }
                            else
                            {
                                material = material.Clone() as Material;
                            }
                            var polygon = new Polygon(lp.ToArray(), material);
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
                                var mm  = mat.Clone() as Material;
                                if (Image == null)
                                {
                                    Material = mm;
                                }
                                else
                                {
                                    Material = mm.SetImage(Image);
                                }
                            }
                            i = k;
                            continue;
                        }

                    }
                    i = k;
                    continue;
                }
            }
            if (vrt != null)
            {
                if (vrt.Count > 0)
                {
                    Points = new List<Point>();
                    for (var h = 0; h < vrt.Count; h++)
                    {
                        var point = new Point(vrt[h], dd[h], null);
                        Points.Add(point);
                    }
                }
            }
         //   Disintegrate();
        }

        private AbstractMeshAC(AbstractMeshAC parent, PolygonLocal polygon, Material material, Image image, IMeshCreator creator) :
            base(parent.Name + Path.GetRandomFileName(), parent, null, creator)
        {
            Vertices = new List<float[]>();
            var d = new Dictionary<int, int>();
            int i = 0;
            foreach (var p in polygon.Points)
            {
                var k = p.Vertex;
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
            var l = new List<PointAC>();
            foreach (var p in polygon.Points)
            {
                var t = new PointAC(d[p.Vertex], p.Textrure, p.Normal, p.Data);
                l.Add(t);
            }
            if (image != null)
            {
                material = material.Clone() as Material;
                var im = image.Clone() as Image;
                material = material.SetImage(im);
            }
            Material = material.Clone() as Material;
            if (image != null & !Material.HasImage)
            {
                Image = image.Clone() as Image;
                Material = Material.SetImage( Image);
            }
            Disintegrate();
        }

        protected  void Disintegrate()
        {/*
            if (mats.Count > 1)
            {
                if (Vertices != null)
                {
                    if (Vertices.Count > 0)
                    {
                        foreach (PolygonLocal p in Polygons)
                        {
                            int h = 0;
                            h = dp[p];
                            var mat = materials[h];
                            new AbstractMeshAC(this, p, mat, Image, creator);
                        }
                    }
                    Vertices = null;
                    Polygons.Clear();
                    Image = null;
                }
            }*/
        }
    }
}