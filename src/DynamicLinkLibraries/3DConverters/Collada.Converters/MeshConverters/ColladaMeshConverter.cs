
using Abstract3DConverters;
using Abstract3DConverters.Converters;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.MaterialCreators;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;
using ErrorHandler;
using System.Text;
using System.Xml;


namespace Collada.Converters.MeshConverters
{
    public abstract class ColladaMeshConverter : XmlMeshConverter
    {
        #region Fields

        public static Contributor Contributor
        {
            get;
            set;
        }


  
        protected XmlDocument effect = new();


       

        protected List<float[]> vertices;

        protected List<float[]> textures;

        List<float[]> normals;


        protected Dictionary<string, Image> imagesdictionary;

        protected XmlElement library_visual_scenes;

        private int geomName = 0;

        EmptyXmlMaterialCreator emptyXmlMaterialCreator;

        protected override IMaterialCreator MaterialCreator => emptyXmlMaterialCreator;

        override 

        private string GeomName
        {
            get
            {
                ++geomName;
                return "mesh_" + geomName;
            }
        }

        int matName = 0;


        string MaterialName
        {
            get
            {
                ++matName;
                return "mat" + matName;
            }
        }

        #endregion

        #region Ctor

        protected ColladaMeshConverter(string xmlns) : base(xmlns, null)
        {
            try
            {
                Load();
                if (Contributor != null)
                {
                    Contributor.Set(doc);
                }
                SetDate();
                var eff = Properties.Resources.effect.Replace("\r", "");
                eff = eff.Replace("\n", "");
                eff = eff.Replace("\t", "");
                effect.LoadXml(eff);
                var r = doc.GetElementsByTagName("library_visual_scenes")[0];
                library_visual_scenes = doc.GetElementsByTagName("library_visual_scenes")[0] as XmlElement;
                emptyXmlMaterialCreator = new EmptyXmlMaterialCreator(doc, xmlns, Images);
                nodes = doc.GetElementsByTagName("instance_visual_scene")[0] as XmlElement;

            }
            catch (Exception e)
            {
                e.ShowError("Collada MeshConver constructor");
            }
        }

        #endregion

        #region IMeshConverter implemebtation


        protected virtual XmlElement Create(XmlElement parent, AbstractMesh mesh)
        {
            var x = Create(mesh);
            parent.AppendChild(x);
            return x;
        }



        protected override void SetEffect(object mesh, object material)
        {
            var group = material as MaterialGroup;
            var n = group.Name;
            var eff = mat_mat0[n];
        }

        protected override void SetTransformation(object mesh, float[] transformation)
        {

        }

        protected override void SetEffect(XmlElement mesh, XmlElement material)
        {
        }



        #endregion


        protected abstract void Load();
        protected override XmlElement Create(AbstractMesh mesh)
        {
            var node = Create("node");
            var pmesh = Process(node, mesh);
            nodesDic[mesh] = node;
            if (mesh.Points != null)
            {
                if (mesh.Points.Count > 0)
                {
                    var ig = Create("instance_geometry");
                    ig.SetAttribute("url", "#" + pmesh);
                    var mt = mesh.Material;
                    if (mt != null)
                    {
                        var bm = Create("bind_material");
                        ig.AppendChild(bm);
                        var tc = Create("technique_common");
                        bm.AppendChild(tc);
                        var im = Create("instance_material");
                        tc.AppendChild(im);
                        im.SetAttribute("symbol", MaterialName);
                        var nm = mt.Name;
                        im.SetAttribute("target", "#" + nm);
                    }
                    node.AppendChild(ig);
                }
            }
            return node;
        }




        void CreateSemantic(XmlElement parent, string semantic, string source, int offset = -1)
        {
            var sem = Create("input");
            parent.AppendChild(sem);
            sem.SetAttribute("semantic", semantic);
            sem.SetAttribute("source", '#' + source);
            if (offset >= 0)
            {
                sem.SetAttribute("offset", offset + "");
            }
        }

        IEnumerable<float> GetArray(List<float[]> l)
        {
            foreach (var x in l)
            {
                foreach (var y in x)
                {
                    yield return y;
                }
            }
        }

        IEnumerable<float> GetTextureArray(List<float[]> l)
        {
            foreach (var item in l)
            {
                yield return item[0];
                yield return item[1];
            }
        }

        string CreateGeometry(AbstractMesh mesh)
        {
            var name = GeomName;
            var e = Create("geometry");
            e.SetAttribute("id", name);
            var r = doc.GetElementsByTagName("library_geometries")[0];
            r.AppendChild(e);
            var me = Create("mesh");
            e.AppendChild(me);
            //         if (mesh is AbstractMeshPolygon poly)
            if (true)
            {
                if (mesh.Points != null)
                {
                    if (mesh.Points.Count > 0)
                    {
                        var vv = new List<float[]>();
                        var vn = new List<float[]>();
                        foreach (var pt in mesh.Points)
                        {
                            if (pt.Vertex != null)
                            {
                                vv.Add(pt.Vertex);
                            }
                            if (pt.Normal != null)
                            {
                                vn.Add(pt.Normal);
                            }
                        }

                        var se = Create("source");
                        me.AppendChild(se);
                        se.SetAttribute("id", name + "-position");
                        se.SetAttribute("name", "position");
                        var vvv = s.ToSingleArray(vv).ToArray();
                        CreateFloatArray(se, name + "-position-array", vvv);
                        CreateTechnique_XYZ(se, name + "-position-array", vvv);
                        se = Create("source");
                        me.AppendChild(se);
                        se.SetAttribute("id", name + "-texcoord");
                        se.SetAttribute("name", "texcoord");
                        var l = new List<float[]>();
                        var pol = mesh.Polygons;
                        var vcount = new List<int>();
                        var p = new List<int>();
                        var ln = new List<int[][]>();
                        int gg = 0;
                        var vtxt = new List<float[]>();
                        var ppp = new List<int>();
                        foreach (var polygon in pol)
                        {
                            var count = polygon.Points.Length;
                            int[][] kk = new int[count][];
                            ln.Add(kk);
                            var nn = 0;
                            var points = polygon.Points;
                            vcount.Add(points.Length);
                            foreach (var point in points)
                            {
                                vtxt.Add([point.Texture[0], point.Texture[1]]);
                                ppp.Add(point.Index);
                            }
                        }
                        var txt = l;
                        se = Create("source");
                        me.AppendChild(se);
                        se.SetAttribute("id", name + "-texcoord");
                        se.SetAttribute("name", "texcoord");
                        var tex = s.ToSingleArray(vtxt).ToArray();
                        if (tex != null)
                        {
                            CreateFloatArray(se, name + "-texcoord-array", tex);
                            CreateTechnique_TS(se, name + "-texcoord-array", tex);
                        }
                        var vt = Create("vertices");
                        me.AppendChild(vt);
                        vt.SetAttribute("id", name + "-vertices");
                        CreateSemantic(vt, "POSITION", name + "-position");
                        if (vn.Count > 0)
                        {
                            se = Create("source");
                            me.AppendChild(se);
                            se.SetAttribute("id", name + "-normal");
                            se.SetAttribute("name", name + "-normal");
                            var norm = s.ToSingleArray(vn).ToArray();
                            CreateFloatArray(se, name + "-normal-array", norm);
                            CreateTechnique_XYZ(se, name + "-normal-array", norm);
                        }
                        if (pol.Count > 0)
                        {
                            var polylist = Create("polylist");
                            me.AppendChild(polylist);
                            polylist.SetAttribute("count", "" + pol.Count);
                            var mat = "Default";
                            var effect = pol[0].Effect;
                            if (effect != null)
                            {
                                mat = effect.Name;
                            }
                            polylist.SetAttribute("material", mat);
                            var sem = 0;
                            var li = new List<int>();
                            CreateSemantic(polylist, "VERTEX", name + "-vertices", sem);
                            li.Add(0);
                            ++sem;
                            if (mesh.Normals != null)
                            {
                                if (mesh.Normals.Count != 0)
                                {
                                    CreateSemantic(polylist, "NORMAL", name + "-normal", sem);
                                    li.Add(2);
                                    ++sem;
                                }
                            }
                            CreateSemantic(polylist, "TEXCOORD", name + "-texcoord", sem);
                            li.Add(1);
                            var ofs = li.ToArray();
                            CreateArray(polylist, "vcount", vcount.ToArray());
                            CreateArray(polylist, "p", ppp.ToArray());

                        }
                    }
                }
            }
            else
            {
                var li = new List<int>();
                if (mesh.Vertices != null)
                {
                    var se = Create("source");
                    me.AppendChild(se);
                    se.SetAttribute("id", name + "-position");
                    se.SetAttribute("name", "position");
                    var vert = s.ToSingleArray(mesh.Vertices).ToArray();
                    CreateFloatArray(se, name + "-position-array", vert);
                    CreateTechnique_XYZ(se, name + "-position-array", vert);


                    se = Create("source");
                    me.AppendChild(se);
                    se.SetAttribute("id", name + "-texcoord");
                    se.SetAttribute("name", "texcoord");
                    var txt = mesh.Textures;
                    if (txt != null)
                    {
                        var tex = GetTextureArray(txt).ToArray();
                        CreateFloatArray(se, name + "-texcoord-array", tex);
                        CreateTechnique_TS(se, name + "-texcoord-array", tex);
                    }
                    else
                    {

                    }
                    //
                    //
                    var vt = Create("vertices");
                    me.AppendChild(vt);
                    vt.SetAttribute("id", name + "-vertices");
                    CreateSemantic(vt, "POSITION", name + "-position");
                    if (mesh.Normals != null)
                    {
                        se = Create("source");
                        me.AppendChild(se);
                        se.SetAttribute("id", name + "-normal");
                        se.SetAttribute("name", name + "-normal");
                        var norm = s.ToSingleArray(mesh.Normals).ToArray();
                        CreateFloatArray(se, name + "-normal-array", norm);
                        CreateTechnique_XYZ(se, name + "-normal-array", norm);

                    }

                    var tr = Create("triangles");
                    me.AppendChild(tr);
                    tr.SetAttribute("material", "default");
                    tr.SetAttribute("count", mesh.Vertices.Count + "");
                    var sem = 0;
                    CreateSemantic(tr, "VERTEX", name + "-vertices", sem);
                    li.Add(0);
                    ++sem;
                    if (mesh.Normals != null)
                    {
                        if (mesh.Normals != null)
                        {
                            CreateSemantic(tr, "NORMAL", name + "-normal", sem);
                            li.Add(2);
                            ++sem;
                        }
                    }
                    CreateSemantic(tr, "TEXCOORD", name + "-texcoord", sem);
                    li.Add(1);
                    var ofs = li.ToArray();
                    var p = new List<int>();
                    foreach (var item in mesh.Indexes)
                    {
                        foreach (var k in item)
                        {
                            for (int i = 0; i < k.Length; i++)
                                p.Add(k[ofs[i]]);
                        }
                    }
                    if (mesh.Indexes != null)
                    {
                        CreateArray(tr, "p", p.ToArray());
                    }
                }
                else
                {

                }
            }
            return name;
        }



        void CreateTechnique_common(XmlElement parent, string name, float[] f, string[][] s)
        {
            var e = Create("technique_common");
            parent.AppendChild(e);
            var a = Create("accessor");
            e.AppendChild(a);
            a.SetAttribute("source", "#" + name);
            a.SetAttribute("count", "" + f.Length);
            a.SetAttribute("sride", "" + s.Length);
            foreach (var ss in s)
            {
                var p = Create("param");
                p.SetAttribute("name", ss[0]);
                p.SetAttribute("type", ss[1]);
                a.AppendChild(p);
            }
        }

        void CreateTechnique_XYZ(XmlElement parent, string name, float[] f)
        {
            CreateTechnique_common(parent, name, f, [["X", "float"], ["Y", "float"], ["Z", "float"]]);
        }

        void CreateTechnique_TS(XmlElement parent, string name, float[] f)
        {
            CreateTechnique_common(parent, name, f, [["T", "float"], ["S", "float"]]);
        }




        #region Material Creator



        #endregion

        #region Membres

        protected Dictionary<Image, string> imAttr = new();

        protected override Dictionary<string, Image> Images
        {
            set
            {
                base.Images = value;
                int i = 1;
                imagesdictionary = value;
                var parent = doc.GetElementsByTagName("library_images")[0] as XmlElement;
                foreach (var image in Images)
                {
                    var im = image.Value;
                    var e = Create("image");
                    parent.AppendChild(e);
                    var attr = "object_" + i;
                    imAttr[im] = attr;
                    ++i;
                    e.SetAttribute("id", attr);
                    var el = Create("init_from");
                    e.AppendChild(el);
                    var f = im.Name;
                    if (converter.Directory != null)
                    {
                        f = Path.Combine(converter.Directory, f);
                    }
                    el.InnerText = f;

                }
            }
        }


        protected override Dictionary<string, Material> Materials
        {
            set
            {
                int nm = 0;
                base.Materials = value;
                var pm = doc.GetElementsByTagName("library_materials")[0] as XmlElement;
                var parent = doc.GetElementsByTagName("library_effects")[0] as XmlElement;
                foreach (var m in value.Values)
                {
                    ++nm;
                    CreateMaterial(parent, pm, m, nm);
                }
            }

        }

       protected override void Set(Dictionary<string, Material> materials)
        {
            int nm = 0;
            this.materials = materials;
            var pm = doc.GetElementsByTagName("library_materials")[0] as XmlElement;
            var parent = doc.GetElementsByTagName("library_effects")[0] as XmlElement;
            foreach (var m in materials.Values)
            {
                ++nm;
                CreateMaterial(parent, pm, m, nm);
            }
        }


        Dictionary<string, string> dWhap = new Dictionary<string, string>()
        {
            { "wrap_s", "WRAP" },
            {"wrap_t", "WRAP" },
            {"wrap_p", "WRAP" },
            {"minfilter", "NONE" },
           {"mipfilter", "NONE" },
           {"mapfilter", "NONE" },

        };

        Dictionary<string, string> mat_mat0 = new Dictionary<string, string>();

        protected void CreateEffect(XmlElement parent, XmlElement pm, Effect effect, int nm)
        {

        }

        private void CreateMaterial(XmlElement parent, XmlElement pm, Material material, int nm)
        {
            DiffuseMaterial diffuseMaterial = null;
            EmissiveMaterial emissiveMaterial = null;
            SpecularMaterial specularMaterial = null;
            var group = material as MaterialGroup;
            foreach (var m in group.Children)
            {
                switch (m)
                {
                    case DiffuseMaterial diffuse:
                        diffuseMaterial = diffuse;
                        break;
                    case EmissiveMaterial emissive:
                        emissiveMaterial = emissive;
                        break;
                    case SpecularMaterial specular:
                        specularMaterial = specular;
                        break;
                }
            }
            var eff = Create("effect");
            parent.AppendChild(eff);
            var effn = "effect-" + material.Name;
            eff.SetAttribute("id", effn);
            var pc = Create("profile_COMMON");
            eff.AppendChild(pc);
            var dcf = "DiffuseColor-surface" + nm;
            var np = Create("newparam");
            pc.AppendChild(np);
            np.SetAttribute("sid", dcf);
            Image image = diffuseMaterial.Image;
            var at = "";
            if (image != null)
            {
                at = imAttr[image];
            }
            var sur = Create("surface");
            np.AppendChild(sur);
            sur.SetAttribute("type", "2D");
            if (at.Length > 0)
            {
                var ifr = Create("init_from");
                sur.AppendChild(ifr);
                ifr.InnerText = at;
            }
            np = Create("newparam");
            pc.AppendChild(np);
            var dcs = "DiffuseColor-sampler" + nm;
            np.SetAttribute("sid", dcs);
            var sam = Create("sampler2D");
            np.AppendChild(sam);
            var sou = Create("source");
            sam.AppendChild(sou);
            sou.InnerText = dcf;
            foreach (var wr in dWhap)
            {
                var er = Create(wr.Key);
                er.InnerText = wr.Value;
                sam.AppendChild(er);
            }
            var tn = Create("technique");
            pc.AppendChild(tn);
            tn.SetAttribute("sid", "COMMON");
            var p = Create("phong");
            tn.AppendChild(p);
            CreateColor(p, "emission", emissiveMaterial.Color);
            if (diffuseMaterial.AmbientColor != null)
            {
                CreateColor(p, "ambient", diffuseMaterial.AmbientColor);
            }
            var df = Create("diffuse");
            p.AppendChild(df);
            var txt = Create("texture");
            df.AppendChild(txt);
            txt.SetAttribute("texcoord", "uv0");
            txt.SetAttribute("texture", dcs);
            if (specularMaterial != null)
            {
                CreateColor(p, "specular", specularMaterial.Color);
                CreateFloat(p, "shininess", specularMaterial.SpecularPower);
            }
            CreateColor(p, "transparent", diffuseMaterial.Color);
            CreateFloat(p, "transparency", 1f - diffuseMaterial.Opacity);
            var nmt = Create("material");
            pm.AppendChild(nmt);
            var matn = material.Name;
            nmt.SetAttribute("id", matn);
            nmt.SetAttribute("name", matn);
            var ieff = Create("instance_effect");
            nmt.AppendChild(ieff);
            ieff.SetAttribute("url", "#" + effn);
            mat_mat0[matn] = effn;
        }

        protected void CreateColor(XmlElement p, string tag, Color color)
        {
            var t = Create(tag);
            p.AppendChild(t);
            var c = Create("color");
            t.AppendChild(c);
            c.InnerText = color.StringValue();
        }


        protected void CreateFloat(XmlElement p, string tag, float a)
        {
            var t = Create(tag);
            p.AppendChild(t);
            var c = Create("float");
            t.AppendChild(c);
            c.InnerText = a + "";
        }

        protected XmlElement CreateArray<T>(XmlElement p, string tag, T[] a) where T : struct
        {
            if (a == null)
            {
                return null;
            }
            var t = Create(tag);
            p.AppendChild(t);
            var sb = new StringBuilder();
            foreach (var x in a)
            {
                sb.Append(" ");
                sb.Append(x);
            }
            var st = sb + "";
            t.InnerText = st.Trim();
            return t;

        }

        protected XmlElement CreateArray<T>(XmlElement p, string tag, T[][] a) where T : struct
        {
            if (a == null)
            {
                return null;
            }
            var t = Create(tag);
            p.AppendChild(t);
            var sb = new StringBuilder();
            foreach (var x in a)
            {
                foreach (var xx in x)
                {
                    sb.Append(" ");
                    sb.Append(xx);
                }
            }
            var st = sb + "";
            t.InnerText = st.Trim();
            return t;

        }

        protected XmlElement CreateArray(XmlElement p, string tag, int[][][] a)
        {
            if (a == null)
            {
                return null;
            }
            var t = Create(tag);
            p.AppendChild(t);
            var sb = new StringBuilder();
            foreach (var x in a)
            {
                foreach (var xx in x)
                {
                    foreach (var y in xx)
                    {
                        if (y < 0)
                        {
                            continue;
                        }
                        sb.Append(" ");
                        sb.Append(y);
                    }
                }
            }
            var st = sb + "";
            t.InnerText = st.Trim();
            return t;


        }


        protected XmlElement CreateArray<T>(XmlElement p, string tag, T[][][] a) where T : struct
        {
            if (a == null)
            {
                return null;
            }
            var t = Create(tag);
            p.AppendChild(t);
            var sb = new StringBuilder();
            foreach (var x in a)
            {
                foreach (var xx in x)
                {
                    foreach (var y in xx)
                    {
                        sb.Append(" ");
                        sb.Append(y);
                    }
                }
            }
            var st = sb + "";
            t.InnerText = st.Trim();
            return t;

        }


        protected void CreateFloatArray(XmlElement p, string name, float[] a)
        {
            if (a == null)
            {
                return;
            }
            var t = CreateArray(p, "float_array", a);
            t.SetAttribute("id", name);
            t.SetAttribute("count", "" + a.Length);
        }

        protected string Process(XmlElement element, AbstractMesh mesh)
        {
            var name = mesh.Name;
            element.SetAttribute("id", name);
            element.SetAttribute("name", name);
            element.SetAttribute("sid", name);
            CreateArray(element, "matrix", mesh.TransformationMatrix);
            return CreateGeometry(mesh);

        }

        #endregion

        #region Private

        void SetDate()
        {
            var d = DateTime.Now;
            var s = d.ToString("yyyy-MM-ddTHH:mm:ss");
            var e = doc.GetElementsByTagName("asset")[0];
            foreach (var c in e.ChildNodes)
            {
                if (c is XmlElement child)
                {
                    switch (child.Name)
                    {
                        case "created":
                            child.InnerText = s;
                            break;
                        case "modified":
                            child.InnerText = s;
                            break;
                    }
                }
            }

            #endregion


        }
    }
}
