using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters;
using System.Xml;
using Abstract3DConverters.Materials;
using System.Reflection;
using Abstract3DConverters.Meshes;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

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
            throw new NotImplementedException();
        }

        object IMeshConverter.Combine(IEnumerable<object> meshes)
        {
            throw new NotImplementedException();
        }

        object IMeshConverter.Create(AbstractMesh mesh)
        {
            throw new NotImplementedException();
        }

        void IMeshConverter.Init(object obj)
        {

            if (obj is Tuple<List<float[]>, List<float[]>, List<float[]>> t)
            {
                vertices = t.Item1;
                textures = t.Item2;
                normals = t.Item3;
            }
        }

        void IMeshConverter.SetMaterial(object mesh, object material)
        {
            throw new NotImplementedException();
        }

        void IMeshConverter.SetTransformation(object mesh, float[] transformation)
        {
            throw new NotImplementedException();
        }

    #endregion

    #region
    

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
        throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            this.materials = materials;
            var parent = doc.GetElementsByTagName("library_effects")[0] as XmlElement;
            foreach (var m in materials.Values)
            {
                CreateMaterial(parent, m);
            }
        }

        int nm = 0;

        Dictionary<string, string> dWhap = new Dictionary<string, string>()
        {
            { "wrap_s", "WRAP" },
            {"wrap_t", "WRAP" },
            {"wrap_p", "WRAP" },
            {"minfilter", "NONE" },
           {"mipfilter", "NONE" },
           {"mapfilter", "NONE" },

        };
        private void CreateMaterial(XmlElement parent, Material material)
        {
            ++nm;
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
            eff.SetAttribute("id", material.Name);
            var pc = doc.CreateElement("profile_COMMON");
            eff.AppendChild(pc);
            var dcf = "DiffuseColor-surface" + nm;
            var np = doc.CreateElement("newparam");
            pc.AppendChild(np);
            np.SetAttribute("sid", dcf);
            Image image = diffuseMaterial.Image;
            var at = imAttr[image];
            var sur = doc.CreateElement("surface");
            np.AppendChild(sur);
            sur.SetAttribute("type", "2D");
            var ifr = doc.CreateElement("init_from");
            sur.AppendChild(ifr);
            ifr.InnerText = at;
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
        }

        protected void CreateColor(XmlElement p, string tag, Color color)
        {
            var t = doc.CreateElement(tag);
            p.AppendChild(t);
            var c = doc.CreateElement("color");
            t.AppendChild(c);
            c.InnerText = color.StringValue();
        }



        #endregion



    }
}
