﻿using System.Text;
using System.Xml;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;
using Abstract3DConverters.Converters;
using Abstract3DConverters.MaterialCreators;

namespace Collada.Converters.MeshConverters
{
    public abstract class ColladaMeshConverter : XmlMeshConverter
    {

        #region Fields


        protected XmlDocument effect = new();


        protected int nmat = 0;


        protected List<float[]> vertices;

        protected List<float[]> textures;

        List<float[]> normals;


        protected Dictionary<string, Image> imagesdictionary;

        protected XmlElement library_visual_scenes;

        #endregion


        #region Ctor

        protected ColladaMeshConverter(string xmlns) : base(xmlns)
        {
            try
            {
                Load();
                var eff = Properties.Resources.effect.Replace("\r", "");
                eff = eff.Replace("\n", "");
                eff = eff.Replace("\t", "");
                effect.Load(eff);
                var r = doc.GetElementsByTagName("library_visual_scenes")[0];
                library_visual_scenes = doc.GetElementsByTagName("library_visual_scenes")[0] as XmlElement;
                materialCreator = new EmptyXmlMaterialCreator(doc, xmlns, images);
                nodes = doc.GetElementsByTagName("instance_visual_scene")[0] as XmlElement;

            }
            catch (Exception e)
            {

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



        protected override void SetMaterial(object mesh, object material)
        {
            var group = material as MaterialGroup;
            var n = group.Name;
            var eff = mat_mat0[n];
        }

        protected override void SetTransformation(object mesh, float[] transformation)
        {

        }

        protected override void SetMaterial(XmlElement mesh, XmlElement material)
        {
        }



        #endregion


        protected abstract void Load();
        protected override XmlElement Create(AbstractMesh mesh)
        {
            if (mesh is AbstractMeshPolygon mp)
            {
                mp.CreateTriangles();
            }
            var node = Create("node");
            var pmesh = Process(node, mesh);
            //   mesh.Children.Select(e => Create(node, e)).ToList();
            nodesDic[mesh] = node;
            if (mesh.Vertices != null)
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
                    im.SetAttribute("symbol", "mat" + nmat);
                    var nm = mt.Name;
                    im.SetAttribute("target", "#" + nm);
                }
                ++nmat;
                node.AppendChild(ig);
            }
            return node;
        }




        int ng = 0;

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
            ++ng;
            var name = "mesh_" + ng;
            if (mesh.Vertices != null)
            {
                var e = Create("geometry");
                e.SetAttribute("id", name);
                var r = doc.GetElementsByTagName("library_geometries")[0];
                r.AppendChild(e);
                var me = Create("mesh");
                e.AppendChild(me);
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
                    vert = GetTextureArray(txt).ToArray();
                    CreateFloatArray(se, name + "-texcoord-array", vert);
                    CreateTechnique_TS(se, name + "-texcoord-array", vert);
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
                var tr = Create("triangles");
                me.AppendChild(tr);
                tr.SetAttribute("material", "default");
                tr.SetAttribute("count", mesh.Vertices.Count + "");
                CreateSemantic(tr, "VERTEX", name + "-vertices", 0);
                CreateSemantic(tr, "TEXCOORD", name + "-texcoord", 1);
                if (mesh.Indexes != null)
                {
                    CreateArray(tr, "p", mesh.Indexes.ToArray());
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

        protected override void Set(Dictionary<string, Image> images)
        {
            int i = 1;
            imagesdictionary = images;
            var parent = doc.GetElementsByTagName("library_images")[0] as XmlElement;
            foreach (var image in images)
            {
                var im = image.Value;
                var e =  Create("image");
                parent.AppendChild(e);
                var attr = "object_" + i;
                imAttr[im] = attr;
                ++i;
                e.SetAttribute("id", attr);
                var el = Create("init_from");
                e.AppendChild(el);
                var f = im.Name;
                if (directory != null)
                {
                    f = Path.Combine(directory, f);
                }
                el.InnerText = f;

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
            CreateFloat(p, "transparency", diffuseMaterial.Opacity);
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


    }
}
