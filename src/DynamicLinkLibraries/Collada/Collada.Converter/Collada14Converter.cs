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
            Effects = ToDictionary(dic[typeof(effect)], GetMaterial);
            var bind_material = dic[typeof(bind_material)];
            var Instance_Material = dic[typeof(instance_material)];

        }


        protected override Tuple<object, List<AbstractMesh>> Create(string filename)
        {
            Directory = Path.GetDirectoryName(filename);
            collada = Collada141.COLLADA.Load(filename);
            PrepareData();
            return Create();
        }

        public Dictionary<string, T> ToDictionary<T>(List<object> list, Func<object, T> func) where T : class
        {
            var d = new Dictionary<string, T>();
            foreach (var item in list)
            {
                if (item == null)
                {
                    continue;
                }
                var t = item.GetType();
                var p = t.GetProperty("name");
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

        private Material GetMaterial(object effect)
        {
            if (effect is effect eff)
            {
                var mt = ToZeroItem<Collada141.effectFx_profile_abstractProfile_COMMON>(eff);
                var t = mt.technique;
                var im = eff.image;
                if (t != null)
                {
                    return GetMaterial(t, im);
                }
            }
            return null;

        }

        Material GetMaterial(Collada141.effectFx_profile_abstractProfile_COMMONTechnique technique, object image)
        {
            if (image != null)
            {

            }
            var it = technique.Item;
            if (it is Collada141.effectFx_profile_abstractProfile_COMMONTechniquePhong phong)
            {
                return GetMaterial(phong);
            }
            return null;
        }



        private Material GetMaterial(effectFx_profile_abstractProfile_COMMONTechniquePhong material)
        {
            var grp = new MaterialGroup();
            var ambient = GetColor(material.ambient);
            var diffColor = GetColor(material.diffuse);

            float opacity = 0;
            if (diffColor != null)
            {
                var diffuse = new DiffuseMaterial(diffColor, ambient, null, opacity);
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