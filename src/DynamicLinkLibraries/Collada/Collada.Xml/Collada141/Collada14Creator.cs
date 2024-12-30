
using Abstract3DConverters;
using Abstract3DConverters.Creators;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;
using Collada.Converter.Meshes;
using Collada141;

namespace Collada.Converter.Creators
{
    public partial class Collada14MeshCreator : AbstractMeshCreator
    {

        private Collada141.COLLADA collada;

    
   
        public Dictionary<string, Material> Effects { get; private set; }


        public Dictionary<string, geometry> Geometries { get; private set; }

        public Dictionary<string, common_newparam_type> NewParam { get; private set; }


        Dictionary<Type, List<object>> dic = new Dictionary<Type, List<object>>();

        public Collada14MeshCreator()
        {

        }

        protected override void LoadIfself(Stream stream)
        {
            collada = COLLADA.Load(stream);
        }

        protected override void CreateAll()
        {
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
                                var mt = Effects[url] as MaterialGroup;
                                var mg = new MaterialGroup(mat.id);
                                foreach (var mm in mt.Children)
                                {
                                    var mmm = mm.Clone() as Material;
                                    mg.Children.Add(mmm);
                                }
                                return mg;
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
                var mt = ToZeroItem<effectFx_profile_abstractProfile_COMMON>(eff);
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

        Material GetMaterial(effectFx_profile_abstractProfile_COMMONTechnique technique, Image image)
        {
            var it = technique.Item;
            if (it is effectFx_profile_abstractProfile_COMMONTechniquePhong phong)
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
            if (diffColor == null)
            {
                var tr = material.transparent.Item as common_color_or_texture_typeColor;
                diffColor = new Color(tr.Values);
            }
            float opacity = 1;
            var diffuse = new DiffuseMaterial(diffColor, ambient, image, opacity);
            grp.Children.Add(diffuse);
            var ecolor = GetColor(material.emission);
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

        protected override IEnumerable<AbstractMesh> Get()
        {
            var l = new List<AbstractMesh>();
            foreach (var node in Nodes)
            {
                l.Add(Create(node));
            }

            return l;
        }

        object ToZeroItem(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            var pr = obj.GetType().GetProperty("Items");
            if (pr == null)
            {
                return null;
            }
            var it = pr.GetValue(obj);
            if (it == null)
            {
                return null;
            }
            if (it is Array array)
            {
                if (array.Length != 1)
                {
                    throw new Exception();
                }
                return array.GetValue(0);
            }
            return null;
        }

        T ToZeroItem<T>(object obj)
        {
            return (T)ToZeroItem(obj);
        }


        Image GetImage(object obj)
        {
            var image = obj as image;
            var im = new Image(image.Item + "", directory);
            return im.Name == null ? null : im;
        }


        AbstractMesh Create(node node)
        {
            var mesh = new AbstractMeshCollada14(node, null, this);
            if (node.node1 != null)
            {
                foreach (var item in node.node1)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    var m = Create(item);
                    m.Parent = mesh;
                }
            }
            return mesh;
        }

        IEnumerable<node> Nodes
        {
            get
            {
                var it = collada.Items;
                foreach (var i in it)
                {
                    if (i is library_visual_scenes sc)
                    {
                        var vs = sc.visual_scene;
                        foreach (var v in vs)
                        {
                            var nd = v.node;
                            foreach (var n in nd)
                            {
                                yield return n;
                            }
                        }
                    }
                }
                yield break;
            }
        }
    }
}