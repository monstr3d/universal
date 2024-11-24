using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters
{
    public static class StaticExtensionAbstract3DConverters
    {
        public static IPolygonSplitterFactory PolygonSplitterFactory { get; set; }

        public static IPolygonSplitter PolygonSplitter => PolygonSplitterFactory.CreatePolygonSplitter();

        static readonly Type[] InputTypes = new Type[] { typeof(InitAttribute) };

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

        static void Initialize(this Assembly assembly)
        {
            var types = assembly.GetTypes();

            foreach (var type in types)
            {
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
    }
}
