using System.Collections;
using System.Reflection;

using Abstract3DConverters.Attributes;
using Abstract3DConverters.Interfaces;

using ErrorHandler;

namespace Abstract3DConverters
{
    public static class StaticExtensionAbstract3DConverters
    {
        static MeshCreatorFactoryCollection meshCreators;

        static MeshConverterFactoryCollection meshConverters;

        static IMeshCreatorFactory meshCreatorFactory;

        static IMeshConverterFactory meshConvertFactory;


        static  IErrorHandler ErrorHandler { get; set; }

        public static IPolygonSplitterFactory PolygonSplitterFactory { get; set; }

        public static IPolygonSplitter PolygonSplitter => PolygonSplitterFactory.CreatePolygonSplitter();

        static readonly Type[] InputTypes = new Type[] { typeof(InitAttribute) };

        static Dictionary<string, ConstructorInfo> creators = new();

        static Dictionary<string, Dictionary<string, ConstructorInfo>>  conveters = new();


        static List<IMeshCreatorFactory> meshCreatorFactories = new();

        static List<IMeshConverterFactory> meshConverterFactories = new();

        static public bool UseDirectory
        {
            get;
            set;
        } = false;

        static public string GetDirectory(this string filename)
        {
            return UseDirectory ? Path.GetDirectoryName(filename) : null;
        }


        static StaticExtensionAbstract3DConverters()
        {
            meshCreators = new MeshCreatorFactoryCollection();
            meshCreatorFactory = meshCreators;
            meshConverters = new MeshConverterFactoryCollection();
            meshConvertFactory = meshConverters;
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
            var factories = new List<IMeshCreatorFactory>();
            try
            {
                var types = assembly.GetTypes();


                foreach (var type in types)
                {
                    if (!type.IsAbstract)
                    {
                        var tt = new List<Type>(type.GetInterfaces());

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
                                var key = ca.Extention;
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
            return meshConvertFactory[extension, comment];
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
