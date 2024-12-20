
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using Abstract3DConverters;
using Abstract3DConverters.Creators;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;
using Collada;
using Collada150.Classes.Comlicated;

namespace Collada150.Creators
{
    public partial class Collada15MeshCreator : AbstractMeshCreator, IFunction, ICollada
    {
        Dictionary<string, List<XmlElement>> elementList = new();


        Dictionary<string, Material> materials;

        Dictionary<string, Abstract3DConverters.Image> images;

        public override Dictionary<string, Abstract3DConverters.Image> Images { get => images; }

        public Dictionary<string, Material> Effects { get; private set; }

        public override Dictionary<string, Material> Materials { get => materials; }


        static Dictionary<string, MethodInfo> methods;


        Dictionary<string, XmlElement> urls = new();

        internal Dictionary<string, Abstract3DConverters.Image> ImageIds { get; private set; } = new();


        static List<string> allTags;

        static List<string> elementary;

        static List<string> nonelementary;
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
            Type[] types = [typeof(Classes.Comlicated.Image), typeof(Texture), typeof(Transparency), typeof(Transparent)];
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
            images = new();
            materials = new Dictionary<string, Material>();
            StaticExtensionCollada.Collada = this;
            StaticExtensionCollada.Function = this;
            
        }

        protected override void CreateAll()
        {
            PrepareData();
        }


        void PrepareData()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            StaticExtensionCollada.XmlElement = doc.DocumentElement;
            /*
             collada.Add(dic, collada.GetType().Assembly);
             images = ToDictionary(dic[typeof(image)], GetImage);
             NewParam = ToDictionary(dic[typeof(common_newparam_type)], o => (common_newparam_type)o, "sid");
             Effects = ToDictionary(dic[typeof(effect)], GetEffect);
             materials = ToDictionary(dic[typeof(material)], GetMaterial);
             Geometries = ToDictionary(dic[typeof(geometry)], GetGeometry, "id");*/
        }
        /*
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

        public override Tuple<object, List<AbstractMesh>> Create()
        {
            return null;
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
                    //  Testtechnique(xmlElement);
                    //    Testtecfiltes(xmlElement);
                }
            }
            var t = elementary;
            t.GetAll();
            t = nonelementary;
            foreach (var n in t)
            {
                n.Get();
            }
                   
            //       t = Function.AddTags;
            //        t.Get();
            int i = 0;

            /*          var s = xmlElement.GetElements();
                      foreach (XmlElement e in s)
                      {
                          if (finalTypes.Contains(e.Name))
                          {
                              e.Get();
                          }
                      }
                      s = xmlElement.GetElements(IsSource);
                      foreach (XmlElement e in s)
                      {
                          //          sources[e.InnerText] = e;
                          var param = e.ParentNode.ParentNode as XmlElement;
                          sourceParam[e] = param;
                          paramSource[param] = e;
                      }*/
            // newparam.Get();

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
            /* if (functions.ContainsKey(xmlElement.Name))
             {
                 Put(xmlElement);
                 return functions[xmlElement.Name];
             }*/
            var tag = xmlElement.Name;
            if (methods.ContainsKey(tag))
            {
                Put(xmlElement);
                var mi = methods[tag];
                return (e) => mi.Invoke(null, [e, this]);
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
