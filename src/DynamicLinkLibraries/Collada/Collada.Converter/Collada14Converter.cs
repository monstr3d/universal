using System.ComponentModel.DataAnnotations;
using System.Net.WebSockets;
using Abstract3DConverters;
using Collada141;

namespace Collada.Converter
{
    public partial class Collada14MeshCreator : AbstractMeshCreator
    {

        private Collada141.COLLADA collada;

        Dictionary<string, Image> images;

        Dictionary<string, Material> materials;

        public override Dictionary<string, Image> Images { get => images; }

        public Dictionary<string, Material> Effects { get; private set; }

        public override Dictionary<string, Material> Materials { get => materials; } 

        public Dictionary<string, geometry> Geometries { get; private set; }

        public Dictionary<string, common_newparam_type> NewParam { get; private set; }


        Dictionary<Type, List<object>> dic = new Dictionary<Type, List<object>>();
        public Collada14MeshCreator() : base(".dae")
        {

        }

        protected override void CreateAll()
        {
            collada = Collada141.COLLADA.Load(filename);
            PrepareData();
        }


        void PrepareData()
        {
            collada.Add(dic, collada.GetType().Assembly);
            images = ToDictionary(dic[typeof(image)], GetImage);
            NewParam = ToDictionary(dic[typeof(common_newparam_type)], o => (common_newparam_type)o, "sid");
            Effects = ToDictionary(dic[typeof(effect)], GetEffect);
            materials = ToDictionary(dic[typeof(material)], GetMaterial);
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
/*
        protected  Tuple<object, List<AbstractMesh>> Create(string filename)
        {
            Directory = Path.GetDirectoryName(filename);
            collada = Collada141.COLLADA.Load(filename);
            PrepareData();
            return Create();
        }
*/
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
                var val = func(item);
                if (val != null)
                {
                    d[s] = func(item);
                }
                else
                {

                }
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
            Image image = null;
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
                        var im = itttt.init_from[0].Value;
                        if (Images.ContainsKey(im))
                        {
                            image = Images[im];
                        }
                        ittt = itt[1] as common_newparam_type;
                        var st = ittt.Item as fx_sampler2D_common;
                    }
                }

                var tech = eff.Items[0];
                return GetMaterial(eff.Items[0].technique, image);
            }
            return null;

        }

        Material GetMaterial(Collada141.effectFx_profile_abstractProfile_COMMONTechnique technique, Image image)
        {
             var it = technique.Item;
            if (it is Collada141.effectFx_profile_abstractProfile_COMMONTechniquePhong phong)
            {
                return GetMaterial(phong, image);
            }
            return null;
        }



        private Material GetMaterial(effectFx_profile_abstractProfile_COMMONTechniquePhong material, Image image)
        {
            var grp = new MaterialGroup();
            var ambient = GetColor(material.ambient);
            var diff = material.diffuse;
            var diffColor = GetColor(material.diffuse);
      /*      if (diffColor == null)
            {
                var txt = diff.Item as common_color_or_texture_typeTexture;
                var np = NewParam[txt.texture];

            }*/
            float opacity = 1;
            var diffuse = new DiffuseMaterial(diffColor, ambient, image, opacity);
            grp.Children.Add(diffuse);
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