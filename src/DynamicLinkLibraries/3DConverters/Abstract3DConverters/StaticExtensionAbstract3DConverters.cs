using System.Collections;
using System.Reflection;

using Abstract3DConverters.Attributes;
using Abstract3DConverters.Fartories.Converters;
using Abstract3DConverters.Fartories.Creators;
using Abstract3DConverters.Interfaces;


namespace Abstract3DConverters
{

    /// <summary>
    /// Check file
    /// </summary>
    public enum CheckFile
    {
        None = 0,
        Check = 1,
    }
    public static class StaticExtensionAbstract3DConverters
    {
        #region Fields

        static IImageConverterFactory imageConverterFactory = null;

        static IImageDetector imageDetector = null;

        static MeshCreatorFactoryCollection meshCreators;

        static MeshConverterFactoryCollection meshConverters;

        static IMeshCreatorFactory meshCreatorFactory;

        static IMeshConverterFactory meshConverterFactory;

        static public IImageDetector ImageDetector { get => imageDetector; }
 
        static public bool DetectImage(this string imagePath)
        {
            if (imageDetector == null)
            {
                return true;
            }
            return imageDetector.Detect(imagePath);
        }

        static public IImageConverter GetImageConverter(this string extension)
        {
            if (imageConverterFactory == null)
            {
                return null;
            }
            return imageConverterFactory[extension];
        }


        static public void Set(this IImageConverterFactory factory)
        {
            imageConverterFactory = factory;
        }


        static public void Set(this IImageDetector detector)
        {
            imageDetector = detector;
        }

        public static IPolygonSplitterFactory PolygonSplitterFactory 
        { 
            get; 
            set; 
        }

        public static IPolygonSplitter PolygonSplitter => PolygonSplitterFactory.CreatePolygonSplitter();

        static readonly Type[] InputTypes = new Type[] { typeof(InitAttribute) };

        static Dictionary<string, ConstructorInfo> creators = new();

        static Dictionary<string, ConstructorInfo> converters = new();

        static List<IMeshCreatorFactory> meshCreatorFactories = new();

        static List<IMeshConverterFactory> meshConverterFactories = new();

        static bool useDirectory = false;

        static Service s = new();



        static List<string> absc = new List<string>();

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionAbstract3DConverters()
        {
            try
            {
                string dir = AppDomain.CurrentDomain.BaseDirectory;
                HandleExceptionDoubleFunc = DefaultHandeExceptionDouble;
                HandleExceptionFunc = DefaultHandeException;
                meshCreators = new MeshCreatorFactoryCollection();
                meshCreatorFactory = meshCreators;
                meshConverters = new MeshConverterFactoryCollection();
                meshConverterFactory = meshConverters;
                var ass = AppDomain.CurrentDomain.GetAssemblies();
                var inputTypes = new Type[] { typeof(InitAttribute) };
                var l = new List<string>();
                foreach (var assembly in ass)
                {
                    var loc = assembly.Location;
                    l.Add(loc);
                    if (loc.Contains(dir))
                    {
                        assembly.Initialize();
                    }
                    else
                    {

                    }
                }
                string[] fn = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
                var lt = new List<string>();
                foreach (var file in fn)
                {
                    if (!l.Contains(file))
                    {
                        lt.Add(file);
                     }
                }
                foreach (var file in lt)
                {
                    var assembly = Assembly.LoadFrom(file);
                    assembly.Initialize();
                }
                var fd = new MeshCreatorConstructorFactory(creators);
                fd.Add();
                foreach (var f in meshCreatorFactories)
                {
                    f.Add();
                }
                var fc = new MeshConverterConstructorFactory(converters);
                fc.Add();
                foreach (var f in meshConverterFactories)
                {
                    f.Add();
                }
            }
            catch (Exception exception)
            {
                exception.HandleException("StaticExtensionAbstract3DConverters");
            }
        }

        #endregion

        #region Public Members

        static public void Finish(this string fn)
        {
            using var writer = new StreamWriter(fn);
            foreach (var sc in absc)
            {
                writer.WriteLine(sc);
            }
        }

        static public void HandleExceptionDouble(this Exception exception, params object[] objects)
        {
            HandleExceptionDoubleFunc(exception, objects);
        }
        static public void HandleExceptionDouble(this Exception exception, object obj)
        {
            HandleExceptionDoubleFunc(exception, [obj]);
        }

        static public void HandleException(this Exception exception, params object[] objects)
        {
            HandleExceptionFunc(exception, objects);
        }

        static public void HandleException(this Exception exception, object obj)
        {
            HandleExceptionFunc(exception, [obj]);
        }




        /// <summary>
        /// The Check file sign
        /// </summary>
        static public CheckFile CheckFile
        {
            get;
            set;
        }

        static public Dictionary<string, Tuple<string[], string>> FileTypes
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
            return Path.GetDirectoryName(filename);
        }


        public static void Init()
        {

        }

        public static IMeshCreator GetMeshCreator(string extension, string directory, byte[] bytes, object additional)
        {
            return meshCreatorFactory[extension, directory, bytes, additional];
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
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            try
            {
                try
                {
                    var location = assembly.Location;
                    if (!location.Contains(dir))
                    {
                        return;
                    }
                }
                catch
                {
                    return;
                }
                Type[] types = null;
                try
                {
                    types = assembly.GetTypes();
                }
                catch
                {
                    return;
                }
                foreach (var type in types)
                {
                    if (s.GetAttribute<InitAttribute>(type) != null)
                    {
                        MethodInfo mi = type.GetMethod("Init", InputTypes);
                        if (mi == null)
                        {
                            continue;
                        }
                        mi.Invoke(null, [null]);
                    }

                    if (type.IsAbstract)
                    {
                        continue;
                    }
                    var tt = new List<Type>(type.GetInterfaces());
                    if (tt.Contains(typeof(IMeshConverterFactory)))
                    {
                        var cat = s.GetAttribute<ConverterAttribute>(type);
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
                            ConstructorInfo constructor = type.GetConstructor([typeof(string), typeof(string), typeof(object[])]);
                            if (constructor != null)
                            {
                                var keys = ca.Extensions;
                                foreach (var key in keys)
                                {
                                    creators[key] = constructor;
                                }
                            }
                        }
                        else
                        {

                        }
                    }
                    if (tt.Contains(typeof(IMeshCreatorFactory)))
                    {
                        var ca = s.GetAttribute<ExtensionAttribute>(type);
                        if (ca != null)
                        {
                            ConstructorInfo constructor = type.GetConstructor([]);
                            var f = constructor.Invoke(null) as IMeshCreatorFactory;
                            meshCreatorFactories.Add(f);
                        }

                    }
                    if (tt.Contains(typeof(IMeshConverter)))
                    {
                        var ca = s.GetAttribute<ConverterAttribute>(type);
                        if (ca != null)
                        {
                            ConstructorInfo constructor = type.GetConstructor([typeof(object[])]);
                            //var f = constructor.Invoke([]) as IMeshConverter;
                            var key = ca.Extension;
                            converters[key] = constructor;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                exception.HandleException("Init assembly 3D convertes " + assembly.FullName, -1);
            }
        }

        public static IMeshConverter ToMeshConvertor(this string extension, params object[] objects)
        {
            return meshConverterFactory[extension, objects];
        }

        public static IMeshCreator ToMeshCreator(this string filename, string directory, params object[] objects)
        {
            return meshCreatorFactory[filename, directory, objects];
        }
/*
        public static IMeshCreator ToMeshCreator(this string filename, object additional)
        {
            using var stream = File.OpenRead(filename);
            byte[] b = new byte[stream.Length];
            stream.ReadExactly(b);
            return ToMeshCreator(filename, b, additional);
        }*/

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

        static public void TestACTetxures(this string directoty)
        {
            var files = Directory.GetFiles(directoty, "*.ac");
            foreach (var file in files)
            {
                using var reader = new StreamReader(file);
                do
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    if (!line.StartsWith("texture"))
                    {
                        continue;
                    }
                    var st = line.Substring("texture".Length);
                    st = s.Trim(st);
                    var fi = Path.Combine(directoty, st);
                    if (!s.FileExists(fi))
                    {
                        absc.Add(fi);
                    }
                }
                while (!reader.EndOfStream);
            }
            var dirs = Directory.GetDirectories(directoty);
            foreach (var d in dirs)
            {
                try
                {
                    d.TestACTetxures();
                }
                catch (Exception)
                {

                }
            }
        }


        public static void TestDirectory(this string directory)
        {
            var l = new List<string>();
            var ldir = new List<string>();
            foreach (var t in FileTypes.Values)
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

        public static Action<Exception, object[]> HandleExceptionDoubleFunc
        {
            get;
            set;
        }


        public static Action<Exception, object[]> HandleExceptionFunc
        {
            get;
            set;
        }


        static public void Log(this string message, params object[] obj)
        {
            ErrorHandler.StaticExtensionErrorHandler.Log(message, obj);
        }

        #endregion

        #region Private Members

        private static void DefaultHandeExceptionDouble(Exception exception, params object[] objects)
        {
            ErrorHandler.StaticExtensionErrorHandler.HandleExceptionDouble(exception, objects);
        }

        private static void DefaultHandeException(Exception exception, params object[] objects)
        {
            ErrorHandler.StaticExtensionErrorHandler.HandleException(exception, objects);
        }




        static void TestDirectoryPrivate(string directory, List<string> ext, List<string> ld)
        {
            var drs = Directory.GetDirectories(directory);
            foreach (var d in drs)
            {
                var dt = Path.GetFileName(d);
                if (ext.Contains(dt))
                {
                    var di = new DirectoryInfo(d);
                    di.Delete(true);
                    continue;
                }
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
                ("\nFile input: " + filename + "\n").Log();
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
                        var ff = Path.GetFileNameWithoutExtension(filename) + s;
                        var comment = t.Value.Item2;
                        if (comment != null)
                        {
                            ff = Path.GetFileNameWithoutExtension(filename) + "." + comment + s;
                        }
                        ("File output: " + Path.Combine(d, ff)).Log();
                        p.CreateAndSaveByUniqueName(filename, t.Key, d);
                    }
                }
            }
        }

        #endregion
    }


}
