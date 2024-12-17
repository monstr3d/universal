using Abstract3DConverters.Attributes;
using Abstract3DConverters.Interfaces;
using System;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters
{
    public static class StaticExtensionAbstract3DConverters
    {
        public static IPolygonSplitterFactory PolygonSplitterFactory { get; set; }

        public static IPolygonSplitter PolygonSplitter => PolygonSplitterFactory.CreatePolygonSplitter();

        static readonly Type[] InputTypes = new Type[] { typeof(InitAttribute) };

        static Dictionary<string, ConstructorInfo> creators = new();


        static StaticExtensionAbstract3DConverters()
        {
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
                    var assembl = Assembly.LoadFrom(file);
                    assembl.Initialize();
                }
            }
        }

        public static void Init()
        {

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

                        if (tt.Contains(typeof(IMeshCreator)))
                        {
                            var ca = CustomAttributeExtensions.GetCustomAttribute<Attributes.ExtensionAttribute>(IntrospectionExtensions.GetTypeInfo(type));
                            if (ca != null)
                            {
                                ConstructorInfo constructor = type.GetConstructor([]);
                                var keys = ca.Extensions;
                                foreach (var key in keys)
                                {
                                    creators[key] = constructor;
                                }
                            }
                            else
                            {
                                throw new Exception();
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

            }

        }

        public static IMeshCreator ToMeshCreator(this string filename)
        {
            var ext = Path.GetExtension(filename);
            if (creators.ContainsKey(ext))
            {
                return creators[ext].Invoke([]) as IMeshCreator;
            }
            return null;
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
