using System.Runtime.InteropServices.Marshalling;
using Abstract3DConverters.Creators;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Points;

using ErrorHandler;

namespace Abstract3DConverters.Meshes
{
    internal class AbstractMeshAC : AbstractMeshPolygon
    {


        Dictionary<Polygon, int> dp = new Dictionary<Polygon, int>();

        List<Material> materials = new();

        List<string> mats = new List<string>();

        int count = 0;


        List<string> l;

        AcCreator AcCreator
        {
            get;
            set;
        }

        public Image Image
        {
            get;
            private set;
        }

        internal AbstractMeshAC(AbstractMeshAC parent, List<Material> materials, List<string> l, AcCreator creator) : base(null, null, null, creator)
        {
            var directory = base.creator.Directory;
            AcCreator = creator;
            var i = creator.Position + 1;
            var ltex = new List<int>();
            var dd = new Dictionary<int, float[]>();
            var pos = creator.Position;
            this.materials = materials;
            this.l = l;
            int nv = -1;
            int ns = -1;
            int txt = 0;
            var ds = new Dictionary<int, float[]>();
            var vrt = new List<float[]>();
            var line = l[i];
            var str = s.ToString(line, "name ");
            if (str != null)
            {
                Name = str;
                ++i;
            }
            else
            {
                Name = "";
            }
            for (; i < l.Count; i++)
            {
                line = l[i];
                var kids = s.ToReal<int>(line, "kids");
                if (kids != null)
                {
                    var n = kids.Value;
                    AcCreator.Position = i + 1;
                    if (vrt != null)
                    {
                        if (vrt.Count > 0)
                        {
                            Points = new List<Point>();
                            for (var h = 0; h < vrt.Count; h++)
                            {
                                float[] norm = null;
                                if (dd.ContainsKey(h))
                                {
                                    norm = dd[h];
                                }
                                var point = new Point(vrt[h], norm);
                                Points.Add(point);
                            }
                        }
                    }
                   if (n > 0)
                    {
                        if (parent != null)
                        {
                            Parent = parent;
                        }
                    }
                    else if (Points != null)
                    {
                        if (Points.Count > 0)
                        {
                            if (parent != null)
                            {
                                Parent = parent;
                            }
                        }
                    }
                    AbstractMesh m = this;
                    if (Parent == null & (parent != null))
                    {
                        m = parent;
                    }
                    Zero();
                    for (var k = 0; k < n; k++)
                    {
                        new AbstractMeshAC(this, materials, l, AcCreator);
                    }
                    return;
                }
                var loc = s.ToString(line, "loc ");
                if (loc != null)
                {
                    var location = s.ToRealArray<float>(loc);
                    TransformationMatrix = [ 1, 0, 0, 0,
                                             0, 1, 0, 0,
                                             0, 0, 1, 0,
                                            location[0], location[1], location[2], 1 ];
                }
                var texture = s.ToString(line, "texture ");
                if (texture != null)
                {
                    Image = new Image(texture, directory);
                }
                var numvert = s.ToReal<int>(line, "numvert ");
                if (numvert != null)
                {
                    if (vrt.Count > 0)
                    {
                        continue;
                    }
                    nv = numvert.Value;
                    var v = new List<float[]>();
                    Vertices = v;
                    var j = i + 1;
                    for (var b = 0; b < nv; b++)
                    {
                        var vertex = s.ToRealArray<float>(l[j]);
                        v.Add(vertex);
                        vrt.Add(vertex);
                        ++j;
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
                    for (var surf = 0; surf < nc; surf++)
                    {
                        i += 2;
                        var mp = s.ToReal<int>(l[i], "mat ");
                        if (mp != null)
                        {
                            mt = mp.Value;
                            var mtt = materials[mt].Clone() as Material;
                            var mn = mtt.Name;
                            if (Image != null)
                            {
                                var im = Image.Clone() as Image;
                                mn += "-" + im.Name;
                                Effect = new Effect(creator, mn, mtt, im);
                            }
                            else
                            {
                                Effect = new Effect(creator, mn, mtt);
                            }
                            if (!mats.Contains(mn))
                            {
                                mats.Add(mn);
                            }
                            else
                            {

                            }
                            if (mats.Count != 1)
                            {

                            }
                        }
                            ++i;
                        var refs = s.ToReal<int>(l[i], "refs ");
                        if (refs != null)
                        {
                            var lp = new List<PointTexture>();

                            var rf = refs.Value;
                            for (var rr = 0; rr < rf; rr++)
                            {
                                ++i;
                                var il = l[i];
                                var ss = s.Split(il);
                                var key = s.ToReal<int>(ss[0].Trim());
                                if (!ltex.Contains(key))
                                {
                                    ltex.Add(key);
                                }
                                var pt = new PointTexture(key, [s.ToReal<float>(ss[1].Trim()),
                                    s.ToReal<float>(ss[2].Trim()) ]);
                                lp.Add(pt);
                            }
                            var polygon = new Polygon(lp.ToArray(), Effect);
                            if (Polygons == null)
                            {
                                Polygons = new();
                            }
                            Polygons.Add(polygon);
                        }
                    }
                }
            }
            if (mats.Count > 0)
            {
                Disintegrate();
            }
        }

/*            for (var i = 0; i < Points.Count; i++)
            {
                if (!ltex.Contains(i))
                {

                }
            }
            if (mats.Count > 1)
            {
                Disintegrate();
            }
        }
            catch (Exception ex)
            {
                ex.ShowError();
            }
}
        }*/

        private AbstractMeshAC(AbstractMesh parent, Polygon polygon, AcCreator creator) : base(null, parent, null, creator)
        {
            Parent = parent;
            Polygons = new();
            Name = parent.Name + "_" + Path.GetRandomFileName();
            Effect = polygon.Effect;
            var pts = new Dictionary<int, Point>();
            var dd = new Dictionary<int, int>();
            var l = new List<int>();
            int k = 0;
   /*         foreach (var i in polygon.Indexes)
            {
                if (!pts.ContainsKey(i))
                {
                    var c = Points.Count;
                    l.Add(c);
                    dd[i] = c;
                    Points.Add(parent.Points[i]);
                }
                else
                {
                    l.Add(dd[i]);
                }
            }
            var poly = new Polygon(l.ToArray(), Material);
            Polygons.Add(poly);*/
        }


        public AbstractMeshAC(AbstractMesh parent, string name, AcCreator creator, int count, List<string> l, List<Material> materials, string directory) :
            base(name, parent, null, creator)
        {
            try
            {
                var ltex = new List<int>();
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
                        if (vrt.Count > 0)
                        {
                            continue;
                        }
                        nv = numvert.Value;
                        var v = new List<float[]>();
                        Vertices = v;
                        var j = i + 1;
                        for (var b = 0; b < nv; b++)
                        { 
                            var vertex = s.ToRealArray<float>(l[j]);
                            v.Add(vertex);
                            vrt.Add(vertex);
                            if (vrt.Count >= nv)
                            ++j;
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
                        for (var surf = 0; surf < nc; surf++)
                        {
                            i += 2;
                            var mp = s.ToReal<int>(l[i], "mat ");
                            mt = mp.Value;
                            var mtt = materials[mt].Clone() as Material;
                            var mn = mtt.Name;
                            if (Image != null)
                            {
                                var im = Image.Clone() as Image;
                                Effect = new Effect(creator, mn + "-" + im.Name, mtt, im);
                            }
                            else
                            {
                                Effect = new Effect(creator, mn, mtt);
                            }
                            if (!mats.Contains(mn))
                            {
                                mats.Add(mn);
                            }
                            else
                            {

                            }
                            if (mats.Count != 1)
                            {

                            }
                            ++i;
                            var refs = s.ToReal<int>(l[i], "refs ");
                            var lp = new List<PointTexture>();
                            var rf = refs.Value;
                            for (var rr = 0; rr < rf; rr++)
                            {
                                ++i;
                                var il = l[i];
                                var ss = s.Split(il);
                                var key = s.ToReal<int>(ss[0].Trim());
                                if (!ltex.Contains(key))
                                {
                                    ltex.Add(key);
                                }
                                var pt = new PointTexture(key, [s.ToReal<float>(ss[1].Trim()),
                                    s.ToReal<float>(ss[2].Trim()) ]);
                                lp.Add(pt);
                            }
                            var polygon = new Polygon(lp.ToArray(), Effect);
                            if (Polygons == null)
                            {
                                Polygons = new();
                            }
                            Polygons.Add(polygon);
                        }
                    }
                }
                if (vrt != null)
                {
                    if (vrt.Count > 0)
                    {
                        Points = new List<Point>();
                        for (var h = 0; h < vrt.Count; h++)
                        {
                            float[] norm = null;
                            if (dd.ContainsKey(h))
                            {
                                norm = dd[h];
                            }
                            var point = new Point(vrt[h], norm);
                            Points.Add(point);
                        }
                    }
                }
                for (var i = 0;  i < Points.Count; i++)
                {
                    if (!ltex.Contains(i))
                    {

                    }
                }

                Zero();
                if (mats.Count > 1)
                {
                    Disintegrate();
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }


        protected void Disintegrate()
        {
            if (mats.Count > 1)
            {
                if (Points.Count > 0)
                {
                    foreach (Polygon p in Polygons)
                    {
                        int h = 0;
                        h = dp[p];
                        var mat = materials[h];
                        new AbstractMeshAC(this, p, creator as AcCreator);
                    }
                }
                Points = null;
                Polygons = null;
                Image = null;
            }
        }
    }
}