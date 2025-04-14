using Abstract3DConverters.Creators;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Points;

using ErrorHandler;
using System.ComponentModel.Design.Serialization;



namespace Abstract3DConverters.Meshes
{
    internal class AbstractMeshAC : AbstractMeshPolygon
    {


        Dictionary<Polygon, int> dp = new Dictionary<Polygon, int>();

        protected override Effect Effect 
        { 
            get => base.Effect; 
            set => base.Effect = value; 
        }

        float[] Location
        {
            get;
            set;
        }

        float[][] RotationMatrix
        {
            get;
            set;
        }

        List<Material> Materials
        {
            get;
            set;
        }

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

        void CreateTransform()
        {
            if (Location != null)
            {
                if (RotationMatrix != null)
                {
                    TransformationMatrix = [ RotationMatrix[0][0], RotationMatrix[0][1], RotationMatrix[0][2], 0,
                                          RotationMatrix[1][0], RotationMatrix[1][1], RotationMatrix[1][2], 0,
                                            RotationMatrix[2][0], RotationMatrix[2][1], RotationMatrix[2][2], 0,
                                            Location[0], Location[1], Location[2], 1 ];

                }
                else
                {
                    TransformationMatrix = [ 1, 0, 0, 0,
                                             0, 1, 0, 0,
                                             0, 0, 1, 0,
                                            Location[0], Location[1], Location[2], 1 ];

                }
            }
            else if (RotationMatrix != null)
            {
                TransformationMatrix = [ RotationMatrix[0][0], RotationMatrix[0][1], RotationMatrix[0][2], 0,
                                          RotationMatrix[1][0], RotationMatrix[1][1], RotationMatrix[1][2], 0,
                                            RotationMatrix[2][0], RotationMatrix[2][1], RotationMatrix[2][2], 0,
                                            0, 0, 0, 1 ];
            }
        }

        internal AbstractMeshAC(AbstractMeshAC parent, List<Material> materials1, List<string> l, AcCreator creator) : base(null, null, null, creator)
        {
            try
            {
                var directory = Creator.Directory;
                AcCreator = Creator as AcCreator;
                var i = creator.Position + 1;
                var ltex = new List<int>();
                var dd = new Dictionary<int, float[]>();
                var pos = creator.Position;
                Materials = materials1;
                this.l = l;
                int nv = -1;
                int ns = -1;
                int txt = 0;
                var ds = new Dictionary<int, float[]>();
                var vrt = new List<float[]>();
                var line = l[i];
                var str = s.ToString(line, "name ");
                if (parent != null)
                {
                    ProtectedParent = parent;
                }

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
                        if (n > 0)
                        {
                        }
                        IMesh m = this;
                        if (m.Parent == null & (parent != null))
                        {
                            m = parent;
                        }
                        Zero();
                        for (var k = 0; k < n; k++)
                        {
                            if (creator.Position + 1 >= l.Count)
                            {
                                return;
                            }
                            new AbstractMeshAC(this, Materials, l, AcCreator);
                        }
                        return;
                    }
                    var loc = s.ToString(line, "loc ");
                    if (loc != null)
                    {
                        Location = s.ToRealArray<float>(loc);
                        CreateTransform();
                    }
                    var rot = s.ToString(line, "rot ");
                    if (rot != null)
                    {
                        var r = s.ToRealArray<float>(rot);
                        RotationMatrix = s.ToRealArray<float>(r, 3).ToArray();
                        CreateTransform();
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
                        if (nc > 0)
                        {
                            if (Textures == null)
                            {
                                Textures = new();
                            }
                        }
                        for (var surf = 0; surf < nc; surf++)
                        {
                            i += 2;
                            var mp = s.ToReal<int>(l[i], "mat ");
                            if (mp != null)
                            {
                                mt = mp.Value;
                                Effect = AcCreator.GetEffect(mt, Image);
                                if (!mats.Contains(Effect.Name))
                                {
                                    mats.Add(Effect.Name);
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
                                    
                                    Textures.Add([s.ToReal<float>(ss[1].Trim()),
                                    s.ToReal<float>(ss[2].Trim()) ]);
                                    var pt = s.CreatePointTexture(this, key, Textures.Count - 1);
                                    if (pt == null)
                                    {
                                        lp = null;
                                        break;
                                    }
                                    lp.Add(pt);
                                }
                                if (lp == null)
                                {
                                    continue;
                                }
                                var polygon = new Polygon(this, lp.ToArray(), Effect);
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
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("Ac Creator Constructor 1");
            }
        }

 
        private AbstractMeshAC(AbstractMesh parent, Polygon polygon, AcCreator creator) : base(parent, null, null, creator)
        {
            try
            {

                ProtectedParent = parent;
                IMesh pmesh = parent;
                Polygons = new();
                Name = pmesh.Name + "_" + Path.GetRandomFileName();
                Effect = polygon.Effect;
                var dd = new Dictionary<int, int>();
                var l = new List<int>();
                int k = 0;
            }
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("Ac Creator Constructor 2");
            }
        }

        public AbstractMeshAC(AbstractMesh parent, string name, AcCreator creator, 
            int count, List<string> l, List<Material> materials1, string directory) :
            base(parent, name, null, creator)
        {
            try
            {
                var ltex = new List<int>();
                var dd = new Dictionary<int, float[]>();
                var pos = creator.Position;
                this.count = count;
                Materials = materials1;
                this.l = l;
                int nv = -1;
                int ns = -1;
                AcCreator = creator;
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
                            var mtt = Materials[mt].Clone() as Material;
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
                                throw new OwnException("!!!!!!!!!!!!");
                                /*
                                var pt = new PointTexture(key, [s.ToReal<float>(ss[1].Trim()),
                                    s.ToReal<float>(ss[2].Trim()) ]);
                                lp.Add(pt);*/
                            }
                            var polygon = new Polygon(this, lp.ToArray(), Effect);
                            if (Polygons == null)
                            {
                                Polygons = new();
                            }
                            Polygons.Add(polygon);
                        }
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
                ex.HandleException();
            }
        }


        protected void Disintegrate()
        {
            if (mats.Count > 1)
            {
                foreach (Polygon p in Polygons)
                {
                    int h = 0;
                    h = dp[p];
                    var mat = Materials[h];
                    new AbstractMeshAC(this, p, AcCreator);
                }
            }
            Polygons = null;
            Image = null;
        }
    }
}