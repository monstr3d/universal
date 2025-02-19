using System.Xml;
using System.Reflection;

using Abstract3DConverters.Creators;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Meshes;

using Collada.Converters.Classes.Complicated;
using Collada.Converters.Classes.Elementary;

using ErrorHandler;

namespace Collada.Converters.MeshCreators
{
    public partial class ColladaMeshCreator : XmlMeshCreator, IFunction, ICollada
    {

        Dictionary<string, List<XmlElement>> elementList = new();

              

        internal Dictionary<string, List<Abstract3DConverters.Materials.Material>> MaterialList { get; private set; } = new();


        internal Dictionary<string, Sampler2D> Samplers { get; private set; } = new();
   

        static Dictionary<string, MethodInfo> methods;

        internal Dictionary<string, Float_Array> Arrays
        {
            get;
            private set;
        } = new();

        Dictionary<string, XmlElement> urls = new();

       internal Dictionary<string, string> EffectToMaterial
        {
            get;
        } = new();

        internal Dictionary<string, Abstract3DConverters.Image> ImageIds { get; private set; } = new();

        internal Dictionary<string, NewParam> Surfaces { get; private set; } = new();

        internal Dictionary<string, NewParam> Samples2D { get; private set; } = new();

        internal Dictionary<string, Source> Sources { get; private set; } = new();

        static List<string> allTags;

        static List<string> elementary;

        static List<string> nonelementary;

        internal Dictionary<string, Effect> Eff 
        { 
            get;  
        } = new Dictionary<string, Effect>();

        internal Dictionary<string, Abstract3DConverters.Image> ImagesIntrenal => Images;

        internal Dictionary<string, GeometryObject> Geom { get; private set; } = new();
        /*
                public Dictionary<string, geometry> Geometries { get; private set; }

                public Dictionary<string, common_newparam_type> NewParam { get; private set; }


                Dictionary<Type, List<object>> dic = new Dictionary<Type, List<object>>();

        */

        static ColladaMeshCreator()
        {
            StaticExtensionCollada.AdditionalType = typeof(IMeshCreator);
            StaticExtensionCollada.Id = "id";
            elementary = new();
            methods = new Dictionary<string, MethodInfo>();
            allTags = new List<string>();
            nonelementary = new();
            Assembly assembly = typeof(ColladaMeshCreator).Assembly;
            try
            {
                assembly.Detect(methods, elementary, allTags);
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
            Type[] types = [typeof(Source), typeof(Surface), typeof(Sampler2D), typeof(NewParam), typeof(Texture), typeof(Transparency), typeof(Transparent),
            typeof(Emission), typeof(Ambient),typeof(Specular), typeof(Phong), typeof(Effect), typeof(Material),
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



        protected ColladaMeshCreator(string filename, XmlDocument doc) : base(filename, doc)
        {
            try
            {
                StaticExtensionCollada.Collada = this;
                StaticExtensionCollada.Function = this;
                CreateAll();
                s.SetParents(MeshesParent);
            }
            catch (Exception ex)
            {
                ex.ShowError();
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

        protected override IEnumerable<AbstractMesh> Meshes
        {
            get
            {
                s.SetParents(MeshesParent);
                return s.GetRoots(MeshesParent.Values).Select(a => a as AbstractMesh).ToList();
            }
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
                e.ShowError();
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