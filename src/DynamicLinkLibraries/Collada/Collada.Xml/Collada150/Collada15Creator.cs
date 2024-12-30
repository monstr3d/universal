
using System.Net.NetworkInformation;
using System.Reflection;
using System.Xml;
using Abstract3DConverters;
using Abstract3DConverters.Creators;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Meshes;
using Collada;
using Collada150.Classes.Complicated;
using Collada150.Classes.Elementary;

namespace Collada150.Creators
{
    public partial class Collada15MeshCreator : XmlMeshCreator, IFunction, ICollada
    {
        Service s = new();

        Dictionary<string, List<XmlElement>> elementList = new();

        internal Dictionary<string, List<Abstract3DConverters.Materials.Material>> MaterialList { get; private set; } = new();

  
        internal Dictionary<string, Sampler2D> Samplers { get; private set; } = new();
        public Dictionary<string, Abstract3DConverters.Materials.Material> Effects { get; private set; }
        public Dictionary<XmlElement, IParent> Meshes { get; private set; } = new(); 

   
        static Dictionary<string, MethodInfo> methods;

        internal Dictionary<string, Float_Array> Arrays 
        { 
            get;
            private set; 
        } = new();

        Dictionary<string, XmlElement> urls = new();

        internal Dictionary<string, Abstract3DConverters.Image> ImageIds { get; private set; } = new();

        internal Dictionary<string, NewParam> Surfaces { get; private set; } = new();

        internal Dictionary<string, NewParam> Samples2D { get; private set; } = new();

        internal Dictionary<string, Source> Sources { get; private set; } = new();

        static List<string> allTags;

        static List<string> elementary;

        static List<string> nonelementary;

        internal Dictionary<string, Effect> Eff { get; private set; } = new Dictionary<string, Effect>();

        internal Dictionary<string, GeometryObject> Geom { get; private set; } = new();
        /*
                public Dictionary<string, geometry> Geometries { get; private set; }

                public Dictionary<string, common_newparam_type> NewParam { get; private set; }


                Dictionary<Type, List<object>> dic = new Dictionary<Type, List<object>>();

        */

        static Collada15MeshCreator()
        {
            StaticExtensionCollada.AdditionalType = typeof(IMeshCreator);
            StaticExtensionCollada.Id = "id";
            elementary = new();
            methods = new Dictionary<string, MethodInfo>();
            allTags = new List<string>();
            nonelementary = new();
            Assembly assembly = typeof(Collada15MeshCreator).Assembly;
            try
            {
                assembly.Detect(methods, elementary, allTags);
            }
            catch (Exception ex)
            {

            }
            Type[] types = [typeof(Source), typeof(Classes.Complicated.Image), typeof(Surface), typeof(Sampler2D), typeof(NewParam), typeof(Texture), typeof(Transparency), typeof(Transparent),
            typeof(Emission), typeof(Ambient),typeof(Specular), typeof(Phong), typeof(Effect), typeof(Classes.Complicated.Material),
          typeof(Instance_Material), typeof(BindMaterial), typeof(Vertices), typeof(Input), typeof(Triangles), typeof(PolyList),
            typeof(GeometryObject), typeof(InstanceGeomery), typeof(Node) ];
            foreach (var type in types)
            {
                if (type.IsUknown())
                {
                    throw new Exception();
                }
                TagAttribute tag = type.GetTag();
                var name = tag.Tag;
                if (tag.IsElemenary)
                {
                    throw new Exception();

                }
                nonelementary.Add(name);
            }
           
        }


        public Collada15MeshCreator()
        {
            try
            {
                images = new();
                StaticExtensionCollada.Collada = this;
                StaticExtensionCollada.Function = this;
            }
            catch (Exception ex)
            {

            }

            
        }

        protected override void CreateAll()
        {
            PrepareData();
        }


        void CreateParams()
        {
            foreach (var np in Samples2D)
            {
                var sam = np.Value;
                var sa = sam.Sampler2D.SourceName;
                if (Surfaces.ContainsKey(sa))
                {
                    var nss = Surfaces[sa];
                    var ss = nss.Surface;
                    sam.Sampler2D.Surface = ss;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        void PrepareData()
        {
            StaticExtensionCollada.XmlElement = doc.DocumentElement;
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

        protected override IEnumerable<AbstractMesh> Get()
        {
            s.SetParents(Meshes);
            return s.GetRoots(Meshes.Values).Select(a => a as AbstractMesh).ToList();
        }
  
        #region ICollada Members
             string ICollada.Filename { get => filename; set { } }

        void ICollada.Clear()
        {
            Clear();
        }

            object ICollada.Get(string s)
            {
                throw new NotImplementedException();
            }

        void ICollada.Init(XmlElement xmlElement)
        {
            {
                var l = new List<string>();
                if (false)
                {
                    var x = xmlElement.GetElements().Where(e => !e.IsUnknown());
                    foreach (var e in x)
                    {
                        if (!l.Contains(e.Name))
                        {
                            var s = e.OuterXml;

                            if (s.Contains("source"))
                            {
                                l.Add(e.Name);
                            }
                        }
                    }
                    l.Sort();
                    using (var writer = new StreamWriter("source.txt"))
                    {
                        foreach (var e in l)
                        {
                            writer.WriteLine(e);
                        }
                    }
                    l = null;
                }
            }
            var t = elementary;
            t.GetAll();
            t = nonelementary;
            for (int j = 0; j < nonelementary.Count; j++)
            {
                var n = nonelementary[j];
                n.Get();
                if (n == "newparam")
                {
                    CreateParams();
                }

            }

        }

        void ICollada.Put(XmlElement xmlElement)
        {

        }

        string ICollada.UniqueId(XmlElement xmlElement)
        {
            var id = xmlElement.GetAttribute("id");
            if (id.Length == 0)
            {
                var url = xmlElement.GetAttribute("url");
                if (url.Length > 0)
                {
                    if (urls.ContainsKey(url))
                    {
                        throw new Exception();
                    }
                    urls[url] = xmlElement;
                    return url;
                }
                return null;
            }
            var name = xmlElement.GetAttribute("name");
            return id + "@" + name;
        }

        private void Clear()
        {

        }

        Func<XmlElement, object> Get(XmlElement xmlElement)
        {
            var tag = xmlElement.Name;
            try
            {
                if (methods.ContainsKey(tag))
                {
                    Put(xmlElement);
                    var mi = methods[tag];
                    return (e) => mi.Invoke(null, [e, this]);
                }
            }
            catch (Exception e)
            {

            }
            return null;
            }

        void Put(XmlElement xmlElement)
        {
            var id = xmlElement.GetAttribute("id");
            if (id.Length == 0)
            {
                return;
            }
            List<XmlElement> l = null;
            if (elementList.ContainsKey(id))
            {
                l = elementList[id];
            }
            else
            {
                l = new List<XmlElement>();
                elementList[id] = l;
            }
            l.Add(xmlElement);
        }


        #endregion

        #region IFunction Members

        Func<XmlElement, object> IFunction.this[XmlElement xmlElement] => Get(xmlElement);

        string IFunction.Filename { get => filename; set { } }

        void IFunction.Clear()
        {
            Clear();
        }

        object IFunction.Clone(object obj)
        {
            return obj;
        }

        Func<XmlElement, object, object> IFunction.Combine(XmlElement xmlElement, object obj)
        {
            return null;
        }

        void IFunction.Init(XmlElement xmlElement)
        {
            List<string> tags = new List<string>();
            var s = xmlElement.GetElements();
            foreach (var e in s)
            {
                if (!e.IsUnknown())
                {
                    continue;
                }
                var n = e.Name;

                if (!allTags.Contains(n))
                {
                    if (!tags.Contains(n))
                    {
                        tags.Add(n);
                    }
                }
            }
        }

        #endregion
    }
}

/*
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
     /*      if (diffColor == null)
           {
               var txt = diff.Item as common_color_or_texture_typeTexture;
               var np = NewParam[txt.texture];

           }*/
/*     float opacity = 1;
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

 public override Tuple<object, List<AbstractMesh>> Create()
 {
     var l = new List<AbstractMesh>();
     foreach (var node in Nodes)
     {
         l.Add(Create(node));
     }


     var t = new Tuple<object, List<AbstractMesh>>(null, l);
     //         var sc = collada.asset.no
     return t;
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
     var mesh = new AbstractMeshCollada(node, null, this);
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
 }*/
