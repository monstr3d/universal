using System.ComponentModel.DataAnnotations;
using Abstract3DConverters;
using Collada141;

namespace Collada.Converter
{
    public partial class Collada14Converter : AbstractMeshCreator
    {

        private Collada141.COLLADA collada;

        public Dictionary<string, Image> Images { get; private set; }

        public Dictionary<string, Material> Effects { get; private set; }

        public Dictionary<string, Material> Materials { get; private set; }

        public Dictionary<string, geometry> Geometries { get; private set; }


        public string Directory
        { get; private set; }

        Dictionary<Type, List<object>> dic = new Dictionary<Type, List<object>>();
        public Collada14Converter() : base(".dae")
        {

        }

        void PrepareData()
        {
            collada.Add(dic, collada.GetType().Assembly);
            Images = ToDictionary(dic[typeof(image)], GetImage);
            Effects = ToDictionary(dic[typeof(effect)], GetEffect);
            Materials = ToDictionary(dic[typeof(material)], GetMaterial);
            Geometries = ToDictionary(dic[typeof(geometry)], GetGeometry, "id");
        }

        geometry GetGeometry(object obj)
        {
            return obj as geometry;
        }


        Material GetMaterial(object obj)
        {
            if (obj is material mat)
            {
                var eff = mat.instance_effect;
                if (eff != null)
                {
                    var url = eff.url;
                    if (url != null)
                    {
                        if (url.Length > 1)
                        {
                            url = url.Substring(1);
                            if (Effects.ContainsKey(url))
                            {
                                return Effects[url];
                            }
                        }
                    }
                }
            }
            return null;

        }

        protected override Tuple<object, List<AbstractMesh>> Create(string filename)
        {
            Directory = Path.GetDirectoryName(filename);
            collada = Collada141.COLLADA.Load(filename);
            PrepareData();
            return Create();
        }

        public Dictionary<string, T> ToDictionary<T>(List<object> list, Func<object, T> func, string pname = "name") where T : class
        {
            var d = new Dictionary<string, T>();
            foreach (var item in list)
            {
                if (item == null)
                {
                    continue;
                }
                var t = item.GetType();
                var p = t.GetProperty(pname);
                var s = p.GetValue(item) + "";
                d[s] = func(item);
            }

            return d;
        }

        private Color GetColor(common_color_or_texture_typeColor color)
        {
            if (color == null)
            {
                return null;
            }
            return new Color(color.Values);
        }

        private Color GetColor(common_color_or_texture_type color)
        {
            if (color == null)
            {
                return null;
            }
            var c = color.Item as common_color_or_texture_typeColor;
            return GetColor(c);
        }

        private Material GetEffect(object effect)
        {
            string im = null;
            if (effect is effect eff)
            {
                var mt = ToZeroItem<Collada141.effectFx_profile_abstractProfile_COMMON>(eff);
                var t = mt.technique;
                var it = eff.Items[0];
                var itt = it.Items;
                if (itt != null)
                {
                    if (itt.Length > 0)
                    {
                        var ittt = itt[0] as common_newparam_type;
                        var itttt = ittt.Item as fx_surface_common;
                        im = itttt.init_from[0].Value;
                    }
                }
                if (t != null)
                {
                    return GetMaterial(t, im);
                }
            }
            return null;

        }

        Material GetMaterial(Collada141.effectFx_profile_abstractProfile_COMMONTechnique technique, string image)
        {
            Image img = null;
            if (image != null)
            {
                if (Images.ContainsKey(image))
                {
                    img = Images[image];
                }
            }
            var it = technique.Item;
            if (it is Collada141.effectFx_profile_abstractProfile_COMMONTechniquePhong phong)
            {
                return GetMaterial(phong, img);
            }
            return null;
        }



        private Material GetMaterial(effectFx_profile_abstractProfile_COMMONTechniquePhong material, Image image)
        {
            var grp = new MaterialGroup();
            var ambient = GetColor(material.ambient);
            var diffColor = GetColor(material.diffuse);

            float opacity = 0;
            if (diffColor != null)
            {
                var diffuse = new DiffuseMaterial(diffColor, ambient, image, opacity);
                grp.Children.Add(diffuse);
            }
            var ecolor =  GetColor(material.emission);
            if (ecolor != null)
            {
                var emissive = new EmissiveMaterial(ecolor);
                grp.Children.Add(emissive);
            }
            var spec = GetColor(material.specular);
            if (spec != null)
            {
                var specular = new SpecularMaterial(spec, 0);
                grp.Children.Add(specular);
            }

            return grp;
        }
    }
}