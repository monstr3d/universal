using System.Collections;
using System.Reflection;

using Abstract3DConverters.Attributes;
using Abstract3DConverters.Fartories.Converters;
using Abstract3DConverters.Fartories.Creators;
using Abstract3DConverters.Interfaces;

using ErrorHandler;

namespace Abstract3DConverters
{
    public static class StaticExtensionAbstract3DConverters
    {
        #region Fields

        static MeshCreatorFactoryCollection meshCreators;

        static MeshConverterFactoryCollection meshConverters;

        static IMeshCreatorFactory meshCreatorFactory;

        static IMeshConverterFactory meshConverterFactory;

        public static IPolygonSplitterFactory PolygonSplitterFactory { get; set; }

        public static IPolygonSplitter PolygonSplitter => PolygonSplitterFactory.CreatePolygonSplitter();

        static readonly Type[] InputTypes = new Type[] { typeof(InitAttribute) };

        static Dictionary<string, ConstructorInfo> creators = new();

        static Dictionary<string, Dictionary<string, ConstructorInfo>>  conveters = new();

        static List<IMeshCreatorFactory> meshCreatorFactories = new();

        static List<IMeshConverterFactory> meshConverterFactories = new();

        static bool useDirectory = false;


        #endregion

        #region Ctor
        static StaticExtensionAbstract3DConverters()
        {
            meshCreators = new MeshCreatorFactoryCollection();
            meshCreatorFactory = meshCreators;
            meshConverters = new MeshConverterFactoryCollection();
            meshConverterFactory = meshConverters;
            var ass = AppDomain.CurrentDomain.GetAssemblies();
            var inputTypes = new Type[] { typeof(InitAttribute) };
            var l = new List<string>();
            foreach (var assembly in ass)
            {
                l.Add(assembly.Location);
                assembly.Initialize();
            }
            string[] fn = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
            foreach (var file in fn)
            {
                if (!l.Contains(file))
                {
                    var assembly = Assembly.LoadFrom(file);
                    assembly.Initialize();
                }
            }
            var fd = new MeshCreatorConstructorFactory(creators);
            fd.Add();
            foreach (var f in meshCreatorFactories)
            {
                f.Add();
            }
            var fc = new MeshConverterConstructorFactory(conveters);
            fc.Add();
            foreach (var f in meshConverterFactories)
            {
                f.Add();
            }

        }



        #endregion

        public static void TestDirectory(this string directory)
        {
            var l = new List<string>();
            var ldir = new List<string>();
            foreach(var t in FileTypes.Values)
            {
                foreach (var s in t.Item1)
                {
                    if (!l.Contains(s))
                    {
                        l.Add(s);
                    }
                }
            }
            TestDirectoryPrivate(directory, l, ldir);
        }


        static void TestDirectoryPrivate(string directory, List<string> ext, List<string> ld)
        {
            var drs = Directory.GetDirectories(directory);
            foreach (var d in drs)
            {
                TestDirectoryPrivate(d, ext, ld);
            }
            var directoryInfo = new DirectoryInfo(directory);
            var files = directoryInfo.GetFiles();
            foreach (var file in files)
            {
                var e = file.Extension;
                if (!ext.Contains(e))
                {
                    continue;
                }
                var filename = file.FullName;
                ("File input: " + filename).ShowMessage();
                foreach (var t in FileTypes)
                {
                    foreach (var s in t.Value.Item1)
                    {
                        if (s == e)
                        {
                            continue;
                        }
                        var d = Path.Combine(directory, s);
                        var dirout = new DirectoryInfo(d);
                        if (!dirout.Exists)
                        {
                            dirout.Create();
                        }
                        var p = new Performer();
                        ("File output: " + Path.Combine(d, Path.GetFileNameWithoutExtension(filename)) + s).ShowMessage();
                        p.CreateAndSaveByUniqueName(filename, t.Key, d);
                    }
                }
            }
        }

        static public  Dictionary<string, Tuple<string[], string>> FileTypes
        {
            get;
            set;
        }


        static public bool UseDirectory
        {
            get => useDirectory;
            set => useDirectory = value;
        } 

        /// <summary>
        /// Gets image file
        /// </summary>
        /// <param name="image">The image</param>
        /// <returns>The file</returns>
        public static string GetImageFile(this Image image)
        {
            if (image == null)
            {
                
            }
            if (UseDirectory)
            {
                var fullPath = image.FullPath;
                if (fullPath != null)
                {
                   return fullPath;
                }
            }
            return image.Name;
        }


        static public string GetDirectory(this string filename)
        {
            return UseDirectory ? Path.GetDirectoryName(filename) : null;
        }


        public static void Init()
        {

        }

       public static IMeshCreator GetMeshCreator(string extension, byte[] bytes)
        {
            return meshCreatorFactory[extension, bytes];
        }

        public static void Add(this IMeshCreatorFactory factory)
        {
            meshCreators.Add(factory);
        }

        public static void Add(this IMeshConverterFactory factory)
        {
            meshConverters.Add(factory);
        }


        static void Initialize(this Assembly assembly)
        {
            try
            {
                var types = assembly.GetTypes();


                foreach (var type in types)
                {
                    if (!type.IsAbstract)
                    {
                        var tt = new List<Type>(type.GetInterfaces());
                        if (tt.Contains(typeof(IMeshConverterFactory)))
                        {
                            var cat = CustomAttributeExtensions.GetCustomAttribute<ConverterAttribute>(IntrospectionExtensions.GetTypeInfo(type));
                            if (cat != null)
                            {
                                var ci = type.GetConstructor([]);
                                if (ci != null)
                                {
                                    var f = ci.Invoke([]) as IMeshConverterFactory;
                                    f.Add();
                                }
                            }
                        }

                        if (tt.Contains(typeof(IMeshCreator)))
                        {
                            var ca = CustomAttributeExtensions.GetCustomAttribute<ExtensionAttribute>(IntrospectionExtensions.GetTypeInfo(type));
                            if (ca != null)
                            {
                                ConstructorInfo constructor = type.GetConstructor([typeof(string), typeof(byte[])]);
                                var keys = ca.Extensions;
                                foreach (var key in keys)
                                {
                                    creators[key] = constructor;
                                }
                            }
                            else
                            {

                            }
                        }
                        if (tt.Contains(typeof(IMeshCreatorFactory)))
                        {
                            var ca = CustomAttributeExtensions.GetCustomAttribute<ExtensionAttribute>(IntrospectionExtensions.GetTypeInfo(type));
                            if (ca != null)
                            {
                                ConstructorInfo constructor = type.GetConstructor([]);
                                var f = constructor.Invoke(null) as IMeshCreatorFactory;
                                meshCreatorFactories.Add(f);
                            }

                        }
                        if (tt.Contains(typeof(IMeshConverter)))
                        {
                            var ca = CustomAttributeExtensions.GetCustomAttribute<ConverterAttribute>(IntrospectionExtensions.GetTypeInfo(type));
                            if (ca != null)
                            {
                                ConstructorInfo constructor = type.GetConstructor([]);
                                var f = constructor.Invoke(null) as IMeshCreatorFactory;
                                var key = ca.Extension;
                                Dictionary<string, ConstructorInfo> d;
                                if (conveters.ContainsKey(key))
                                {
                                    d = conveters[key];
                                }
                                else
                                {
                                    d = new Dictionary<string, ConstructorInfo>();
                                    conveters[key] = d;
                                }
                                var comment = ca.Comment;
                                if (comment == null)
                                {
                                    comment = "";
                                }
                                d[comment] = constructor;
                            }

                        }
                    }
                    if (CustomAttributeExtensions.GetCustomAttribute<InitAttribute>(IntrospectionExtensions.GetTypeInfo(type)) != null)
                    {
                        MethodInfo mi = type.GetMethod("Init", InputTypes);
                        if (mi == null)
                        {
                            continue;
                        }
                        mi.Invoke(null, [null]);
                    }
                }
            }
            catch (Exception e)
            {
                e.ShowError();
            }
        }

        public static IMeshConverter ToMeshConvertor(this string extension, string comment = null)
        {
            return meshConverterFactory[extension, comment];
        }

        public static IMeshCreator ToMeshCreator(this string filename, byte[] bytes)
        {
            return meshCreatorFactory[filename, bytes];
        }

        public static IMeshCreator ToMeshCreator(this string filename)
        {
            using var stream = File.OpenRead(filename);
            byte[] b = new byte[stream.Length];
            stream.ReadExactly(b);
            return ToMeshCreator(filename, b);
        }

        /// <summary>
        /// Adds object with all its properties
        /// </summary>
        /// <param name="obj">the object</param>
        /// <param name="dic">the dictionary</param>
        /// <param name="assembly">the assembly</param>
        static public void Add(this object obj, Dictionary<Type, List<object>> dic, Assembly assembly)
        {
            if (obj == null)
            {
                return;
            }
            if (obj is IEnumerable enu)
            {
                foreach (var item in enu)
                {
                    if (item != null)
                    {
                        item.Add(dic, assembly);
                    }
                }
                return;
            }
            var t = obj.GetType();
            if (t.Assembly != assembly)
            {
                return;
            }
            List<object> list = null;
            if (dic.ContainsKey(t))
            {
                list = dic[t];
            }
            else
            {
                list = new List<object>();
                dic[t] = list;
            }
            if (list.Contains(obj))
            {
                return;
            }
            list.Add(obj);
            var prop = t.GetProperties();
            foreach (var p in prop)
            {
                var ob = p.GetValue(obj);
                if (ob != null)
                {
                    ob.Add(dic, assembly);
                }
            }
        }
    }
}
