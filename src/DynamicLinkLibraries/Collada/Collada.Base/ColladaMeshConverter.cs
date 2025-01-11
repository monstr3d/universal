using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;

namespace Collada.Base
{
    public class ColladaMeshConverter : IMeshConverter, IStringRepresentation, IMaterialCreator
    {

        #region Fields

        protected XmlDocument doc = new();

        protected XmlDocument effect = new();

        protected Service s = new();




        List<float[]> vertices;

        List<float[]> textures;

        List<float[]> normals;


        Dictionary<string, Image> images;

        Dictionary<string, Material> materials;

        protected XmlElement library_visual_scenes; 



        protected IMeshConverter converter;

        string directory;

        #endregion


        #region Ctor

        protected ColladaMeshConverter(string directory)
        {
            this.directory = directory;
            try
            {
                var eff = Properties.Resources.effect.Replace("\r", "");
                eff = eff.Replace("\n", "");
                eff = eff.Replace("\t", "");
                effect.Load(eff);
            }
            catch (Exception e)
            {

            }
        }

        #endregion


        #region IMeshConverter implemebtation

        Assembly IMeshConverter.Assembly => typeof(ColladaMeshConverter).Assembly;

        Dictionary<string, Material> IMeshConverter.Materials { set => Set(value); }

        IMaterialCreator IMeshConverter.MaterialCreator => this;

        Dictionary<string, Image> IMeshConverter.Images { set => Set(value); }

        string IMeshConverter.Directory => directory;

        void IMeshConverter.Add(object mesh, object child)
        {
            var p = mesh as XmlElement;
            var c = child as XmlElement;
            if (c.ParentNode == null)
            {
                p.AppendChild(c);
            }
        }

        object IMeshConverter.Combine(IEnumerable<object> meshes)
        {
            return doc; ;
        }

        object IMeshConverter.Create(AbstractMesh mesh)
        {
            return Create(library_visual_scenes, mesh);
        }

        void IMeshConverter.SetMaterial(object mesh, object material)
        {
            var group = material as MaterialGroup;
            var n = group.Name;
            var eff = mat_mat0[n];
        }

        void IMeshConverter.SetTransformation(object mesh, float[] transformation)
        {
            throw new NotImplementedException();
        }

        #endregion

        int ng = 0;

        void CreateSemantic(XmlElement parent, string semantic, string source, int offset = -1)
        {
            var sem = doc.CreateElement("input");
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
                var e = doc.CreateElement("geometry");
                e.SetAttribute("id", name);
                var r = doc.GetElementsByTagName("library_geometries")[0];
                r.AppendChild(e);
                var me = doc.CreateElement("mesh");
                e.AppendChild(me);
                var se = doc.CreateElement("source");
                me.AppendChild(se);
                se.SetAttribute("id", name + "-position");
                se.SetAttribute("name", "position");
                var vert = s.ToSingleArray(mesh.Vertices).ToArray();
                CreateFloatArray(se, name + "-position-array", vert);
                CreateTechnique_XYZ(se, "#" + name + "-position-array", vert);
                se = doc.CreateElement("source");
                me.AppendChild(se);
                se.SetAttribute("id", name + "-texcoord");
                se.SetAttribute("name", "texcoord");
                var txt = mesh.Textures;
                if (txt != null)
                {
                    vert = GetTextureArray(txt).ToArray();
                    CreateFloatArray(se, name + "-texcoord-array", vert);
                    CreateTechnique_TS(se, "#" + name + "-texcoord-array", vert);
                }
                else
                {

                }
                //
                //
                var vt = doc.CreateElement("vertices");
                me.AppendChild(vt);
                vt.SetAttribute("id", name + "-vertices");
                CreateSemantic(vt, "POSITION", name + "-position");
                if (mesh.Indexes != null)
                {
                    var tr = doc.CreateElement("triangles");
                    me.AppendChild(tr);
                    tr.SetAttribute("material", "default");
                    tr.SetAttribute("count", mesh.Vertices.Count + "");
                    CreateSemantic(tr, "VERTEX", name + "-vertices", 0);
                    CreateSemantic(tr, "TEXCOORD", name + "-texcoord", 1);
                    CreateArray(tr, "p", mesh.Indexes.ToArray());
                }
            }
            return name;
        }

        void CreateTechnique_common(XmlElement parent, string name, float[] f, string[][] s)
        {
            var e = doc.CreateElement("technique_common");
            parent.AppendChild(e);
            var a = doc.CreateElement("accessor");
            e.AppendChild(a);
            a.SetAttribute("source", "#" + name);
            a.SetAttribute("count", "" + f.Length);
            a.SetAttribute("sride", "" + s.Length);
            foreach (var ss in s)
            {
                var p = doc.CreateElement("param");
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


        Assembly IMaterialCreator.Assembly => throw new NotImplementedException();

        void IMaterialCreator.Add(object group, object value)
        {
            throw new NotImplementedException();
        }

        object IMaterialCreator.Create(Image image)
        {
            throw new NotImplementedException();
        }

        object IMaterialCreator.Create(Color color)
        {
            throw new NotImplementedException();
        }

        object IMaterialCreator.Create(Material material)
        {
            return material;
        }

        object IMaterialCreator.Create(MaterialGroup material)
        {
            throw new NotImplementedException();
        }

        object IMaterialCreator.Create(DiffuseMaterial material)
        {
            throw new NotImplementedException();
        }

        object IMaterialCreator.Create(SpecularMaterial material)
        {
            throw new NotImplementedException();
        }

        object IMaterialCreator.Create(EmissiveMaterial material)
        {
            throw new NotImplementedException();
        }

        void IMaterialCreator.Set(object material, object color)
        {
            throw new NotImplementedException();
        }

        void IMaterialCreator.Set(object material, Color color)
        {
            throw new NotImplementedException();
        }

        void IMaterialCreator.SetImage(object material, object image)
        {
            throw new NotImplementedException();
        }

        void IMaterialCreator.SetImage(object material, Image image)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IStringRepresentation Members

        string IStringRepresentation.ToString(object obj)
        {
            var d = obj as XmlDocument;
            return d.OuterXml;
        }


        #endregion

        #region Membres

        protected Dictionary<Image, string> imAttr = new();

        protected virtual void Set(Dictionary<string, Image> images)
        {
            int i = 1;
            this.images = images;
            var parent = doc.GetElementsByTagName("library_images")[0] as XmlElement;
            foreach (var image in images)
            {
                var im = image.Value;
                var e = doc.CreateElement("image");
                parent.AppendChild(e);
                var attr = "object_" + i;
                imAttr[im] = attr;
                ++i;
                e.SetAttribute("id", attr);
                var el = doc.CreateElement("init_from");
                e.AppendChild(el);
                var f = im.Name;
                if (directory != null)
                {
                    f = Path.Combine(directory, f);
                }
                el.InnerText = f;

            }
        }



        protected virtual void Set(Dictionary<string, Material> materials)
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
            var eff = doc.CreateElement("effect");
            parent.AppendChild(eff);
            var effn = "effect-" + material.Name;
            eff.SetAttribute("id", effn);
            var pc = doc.CreateElement("profile_COMMON");
            eff.AppendChild(pc);
            var dcf = "DiffuseColor-surface" + nm;
            var np = doc.CreateElement("newparam");
            pc.AppendChild(np);
            np.SetAttribute("sid", dcf);
            Image image = diffuseMaterial.Image;
            var at = "";
            if (image != null)
            {
                at = imAttr[image];
            }
            var sur = doc.CreateElement("surface");
            np.AppendChild(sur);
            sur.SetAttribute("type", "2D");
            if (at.Length > 0)
            {
                var ifr = doc.CreateElement("init_from");
                sur.AppendChild(ifr);
                ifr.InnerText = at;
            }
            np = doc.CreateElement("newparam");
            pc.AppendChild(np);
            var dcs = "DiffuseColor-sampler" + nm;
            np.SetAttribute("sid", dcs);
            var sam = doc.CreateElement("sampler2D");
            np.AppendChild(sam);
            var sou = doc.CreateElement("source");
            sam.AppendChild(sou);
            sou.InnerText = dcf;
            foreach (var wr in dWhap)
            {
                var er = doc.CreateElement(wr.Key);
                er.InnerText = wr.Value;
                sam.AppendChild(er);
            }
            var tn = doc.CreateElement("technique");
            pc.AppendChild(tn);
            tn.SetAttribute("sid", "COMMON");
            var p = doc.CreateElement("phong");
            tn.AppendChild(p);
            CreateColor(p, "emission", emissiveMaterial.Color);
            if (diffuseMaterial.AmbientColor != null)
            {
                CreateColor(p, "ambient", diffuseMaterial.AmbientColor);
            }
            var df = doc.CreateElement("diffuse");
            p.AppendChild(df);
            var txt = doc.CreateElement("texture");
            df.AppendChild(txt);
            txt.SetAttribute("texcoord", "uv0");
            txt.SetAttribute("texture", dcs);
            if (specularMaterial != null)
            {
                CreateColor(p, "specular", specularMaterial.Color);
                CreateFloat(p, "shininess", specularMaterial.SpecularPower);
            }
            CreateColor(p, "transparent", diffuseMaterial.Color);
            CreateFloat(p, "transparency", 1 - diffuseMaterial.Opacity);
            var nmt = doc.CreateElement("material");
            pm.AppendChild(nmt);
            var matn = material.Name;
            nmt.SetAttribute("id", matn);
            nmt.SetAttribute("name", matn);
            var ieff = doc.CreateElement("instance_effect");
            nmt.AppendChild(ieff);
            ieff.SetAttribute("url", "#" + effn);
            mat_mat0[matn] = effn;
        }

        protected void CreateColor(XmlElement p, string tag, Color color)
        {
            var t = doc.CreateElement(tag);
            p.AppendChild(t);
            var c = doc.CreateElement("color");
            t.AppendChild(c);
            c.InnerText = color.StringValue();
        }


        protected void CreateFloat(XmlElement p, string tag, float a)
        {
            var t = doc.CreateElement(tag);
            p.AppendChild(t);
            var c = doc.CreateElement("float");
            t.AppendChild(c);
            c.InnerText = a + "";
        }

        protected XmlElement CreateArray<T>(XmlElement p, string tag, T[] a) where T: struct
        {
            if (a == null)
            {
                return null;
            }
            var t = doc.CreateElement(tag);
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
            var t = doc.CreateElement(tag);
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
            var t = doc.CreateElement(tag);
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
            var t = doc.CreateElement(tag);
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

        protected Dictionary<AbstractMesh, XmlElement> nodes = new();


        int nmat = 0;

        protected XmlElement Create(XmlElement parent, AbstractMesh mesh)
        {
            var node = doc.CreateElement("node");
            var pmesh =  Process(node, mesh);
            var ig = doc.CreateElement("instance_geometry");
            ig.SetAttribute("url", "#" + pmesh);
            var mt = mesh.Material;
            if (mt != null)
            {
                var bm = doc.CreateElement("bind_material");
                ig.AppendChild(bm);
                var tc = doc.CreateElement("technique_common");
                bm.AppendChild(tc);
                var im = doc.CreateElement("instance_material");
                tc.AppendChild(im);
                im.SetAttribute("symbol", "mat" + nmat);
                var nm = mt.Name;
                im.SetAttribute("target", "#" + nm);
            }
            ++nmat;
            node.AppendChild(ig);
            parent.AppendChild(node);
            mesh.Children.Select(e => Create(node, e)).ToList();
            nodes[mesh] = node;
            return node;
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
