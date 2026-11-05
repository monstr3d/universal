using AssemblyService.Attributes;
using ErrorHandler;
using Motion6D.Portable.TypeScript.Attributes;
using Motion6D.Portable.TypeScript.Interfaces;
using System.Reflection;

namespace Motion6D.Portable.TypeScript
{
    /// <summary>
    /// Static Extension
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionMotion6DPortableTypeScript
    {
        static NamedTree.Performer performer = new NamedTree.Performer();
        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionMotion6DPortableTypeScript()
        {
            try
            {


                string dir = AppDomain.CurrentDomain.BaseDirectory;
                var ass = AppDomain.CurrentDomain.GetAssemblies();
                var inputTypes = new Type[] { typeof(InitAttribute) };
                var l = new List<string>();
                foreach (var assembly in ass)
                {
                    var loc = assembly.Location;
                    l.Add(loc);
                    if (loc.Contains(dir))
                    {
                        if (assembly.Initialize()) return;
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
                    if (assembly.Initialize()) return;
                }
            }
            catch (Exception exception)
            {
                exception.HandleException("StaticExtensionAbstract3DConverters");
            }

            new ClassCodeCreator(null);
        }

        /// <summary>
        /// Initialize itself
        /// </summary>
        /// <param name="attr">Initialization attribute</param>
        static public void Init(InitAssemblyAttribute attr)
        {

        }

        public static IPositionCodeFactory  Factory
        {
            get;
            set;
        }


        static bool Initialize(this Assembly assembly)
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            try
            {
                try
                {
                    var location = assembly.Location;
                    if (!location.Contains(dir))
                    {
                        return false;
                    }
                }
                catch
                {
                    return false; ;
                }
                Type[] types = null;
                try
                {
                    types = assembly.GetTypes();
                }
                catch
                {
                    return false;
                }
                foreach (var type in types)
                {
                    var tt = new List<Type>(type.GetInterfaces());
                    if (tt.Contains(typeof(IPositionCodeFactory)))
                    {
                        var ci = type.GetConstructor([]);
                        if (ci != null)
                        {
                            var f = ci.Invoke([]) as IPositionCodeFactory;
                            new ClassCodeCreator(f);
                            return true;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                exception.HandleException("Init assembly 3D convertes " + assembly.FullName, -1);
            }
            return false;
        }

    }
}
