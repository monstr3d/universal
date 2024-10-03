using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using AssemblyService.Attributes;

namespace AssemblyService
{
    /// <summary>
    /// Works with assemblies
    /// </summary>
    public static class StaticExtensionAssemblyService
    {

        static Dictionary<string, Assembly> assemblyDictionary = new Dictionary<string, Assembly>();

        static LinkedList<string> locations = new LinkedList<string>();

        static string dir;

        static readonly Type[] inputTypes = [typeof(InitAssemblyAttribute)];

        static readonly object[] input = [null];
        
        static StaticExtensionAssemblyService()
        {
            Action<Exception> act = (Exception ex) => 
            {  
            
            };
            dir = AppDomain.CurrentDomain.BaseDirectory;
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoadArgs;
            Assembly ass = typeof(StaticExtensionAssemblyService).Assembly;
            CurrentDomain_AssemblyLoad(ass);
            assemblyDictionary[ass.FullName] = ass;
            LoadBaseAssemblies(act);
        }

        private static void CurrentDomain_AssemblyLoadArgs(object sender, AssemblyLoadEventArgs args)
        {
            Assembly ass = args.LoadedAssembly;
            if (assemblyDictionary.ContainsKey(ass.FullName))
            {
                return;
            }
            assemblyDictionary[ass.FullName] = ass;
            CurrentDomain_AssemblyLoad(ass);
            locations.AddLast(ass.Location);
        }

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr = null)
        {
            
        }

        static internal  bool HasAttributeAss<T>(this Type type) where T : Attribute
        {
            return CustomAttributeExtensions.GetCustomAttribute<T>(IntrospectionExtensions.GetTypeInfo(type)) != null;
        }


        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            Assembly ass = args.RequestingAssembly;
            string fn = ass.FullName;
            if (!assemblyDictionary.ContainsKey(fn))
            {
                assemblyDictionary[fn] = ass;
                locations.AddLast(ass.Location);
            }
            else
            {
                return assemblyDictionary[fn];
            }
            return ass;
        }

        private static void CallInit(this Assembly ass)
        {
            try
            {
                Type[] types = ass.GetTypes();
                foreach (Type t in types)
                {
                    if (t.HasAttributeAss<InitAssemblyAttribute>())
                    {
                        MethodInfo mi = t.GetMethod("Init", inputTypes);
                        if (mi == null)
                        {
                            continue;
                        }
                        mi.Invoke(null, input);
                    }
                }
            }
            catch (Exception)
            {

            }

        }

        private static void CurrentDomain_AssemblyLoad(Assembly ass)
        {
            ass.CallInit();
        }




        #region Fields

        private static Dictionary<Action<Assembly>, List<string>> acted =
                new Dictionary<Action<Assembly>, List<string>>();
  
        #endregion

        #region Public Members

        /// <summary>
        /// Gets Field dictionary
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="assembly">assembly</param>
        /// <param name="fieldName">Field name</param>
        /// <returns>Dictionary</returns>
        public static Dictionary<string, T> GetStaticFieldDictionary<T>(this Assembly assembly, string fieldName) where T : class
        {
            Dictionary<string, T> d = new Dictionary<string, T>();
            Type[] tt = assembly.GetTypes();
            foreach (Type t in tt)
            {
                FieldInfo fi = t.GetField(fieldName);
                if (fi != null)
                {
                    if (fi.IsStatic)
                    {
                        try
                        {
                            object ob = fi.GetValue(null);
                            if (ob != null)
                            {
                                if (ob is T)
                                {
                                    d[t.FullName] = ob as T;
                                }
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
            }

            return d;
        }

        /// <summary>
        /// Creates object
        /// </summary>
        /// <typeparam name="T">Interface type</typeparam>
        /// <param name="assembly">Assembly</param>
        /// <param name="types">Types of parameters</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>Object</returns>
        public static T CreateObject<T>(this Assembly assembly,
            Type[] types, object[] parameters) where T : class
        {
            string st = typeof(T).FullName;
            Type[] tt = assembly.GetTypes();
            foreach (Type t in tt)
            {
                Type ti = t.GetInterface(st);   // Gets interface
                if (ti != null)
                {
                    ConstructorInfo c = t.GetConstructor(types);
                    if (c != null)
                    {
                        return c.Invoke(parameters) as T;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Creates object
        /// </summary>
        /// <typeparam name="T">Interface type</typeparam>
        /// <param name="assembly">Assembly</param>
        /// <returns>Object</returns>
        public static T CreateObject<T>(this Assembly assembly) where T : class
        {
            return assembly.CreateObject<T>(new Type[0], new object[0]);
        }

        /// <summary>
        /// Gets first interface object
        /// </summary>
        /// <typeparam name="T">Type of interface</typeparam>
        /// <returns>First object</returns>
        public static T GetFirstInterfaceObjectFromBaseDirectory<T>() where T : class
        {
            return AppDomain.CurrentDomain.BaseDirectory.GetSubclassObject<T>();
        }

        /// <summary>
        /// Gets interfaces from base directory
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <returns>Interfaces</returns>
        public static IEnumerable<T> GetInterfacesFromBaseDirectory<T>() where T : class
        {
            return AppDomain.CurrentDomain.BaseDirectory.GetInterfaces<T>();
        }

        /// <summary>
        /// Gets first interface object
        /// </summary>
        /// <typeparam name="T">Type of interface</typeparam>
        /// <param name="directory">Directory</param>
        /// <returns>First object</returns>
        public static T GetFirstInterfaceObject<T>(this string directory) where T : class
        {
            IEnumerable<T> en = directory.GetInterfaces<T>();
            foreach (T t in en)
            {
                return t;
            }
            return null;
        }

        /// <summary>
        /// Gets subclass object
        /// </summary>
        /// <typeparam name="T">Type of interface</typeparam>
        /// <param name="directory">Directory</param>
        /// <returns>Subclass object</returns>
        public static T GetSubclassObject<T>(this string directory) where T : class
        {
            Dictionary<int, T> dic = new Dictionary<int, T>();
            IEnumerable<T> en = directory.GetInterfaces<T>();
            List<int> ln = new List<int>();
            int i = 0;
            foreach (T t in en)
            {
                if (t == null)
                {
                    continue;
                }
                Type ty = t.GetType();
                foreach (int j in dic.Keys)
                {
                    T tt = dic[j];
                    Type tty = tt.GetType();
                    if (ty.IsSubclassOf(tty))
                    {
                        ln.Add(j);
                    }
                    else if (tty.IsSubclassOf(ty))
                    {
                        ln.Add(i);
                    }
                }
                dic[i] = t;
                ++i;
            }
            foreach (int k in dic.Keys)
            {
                if (!ln.Contains(k))
                {
                    return dic[k];
                }
            }
            return null;
       }

        /// <summary>
        /// Gets bytes of first assembly
        /// </summary>
        /// <param name="detector">Detector of type</param>
        /// <param name="directory">Directory</param>
        /// <returns>Bytes of first assembly</returns>
        public static byte[] GetFirstAssemblyBytes(this Func<Type, bool> detector, string directory)
        {
            IEnumerable<byte[]> bb = detector.GetAssemblies(directory);
            foreach (byte[] b in bb)
            {
                return b;
            }
            return null;
        }

        /// <summary>
        /// Gets bytes of all asseblies
        /// </summary>
        /// <param name="detector">Detector of type</param>
        /// <param name="directory">Directory</param>
        /// <returns>Bytes of assemblies</returns>
        public static IEnumerable<byte[]> GetAssemblies(this Func<Type, bool> detector, string directory)
        {
            List<Type> lt = new List<Type>();
            Assembly[] ass = AppDomain.CurrentDomain.GetAssemblies(); // Current domain assemblies
            List<string> l = new List<string>();
            foreach (Assembly a in ass)
            {
                if (a.HasInterface(detector))
                {
                    string loc = a.Location;
                    l.Add(loc);
                    yield return loc.GetFileBytes();
                }
            }
            string[] fn = Directory.GetFiles(directory, "*.dll");   // Dll files
            foreach (string f in fn)
            {
                if (l.Contains(f))
                {
                    continue;
                }
                Assembly a = null;
                byte[] b = null;
                try
                {
                    b = f.GetFileBytes();
                    Assembly.Load(b);
                }
                catch (Exception)
                {
                    continue;
                }
                a = Assembly.Load(b);
                if (a.HasInterface(detector))
                {
                    yield return b;
                }
            }
        }

        /// <summary>
        /// Gets interfaces
        /// </summary>
        /// <typeparam name="T">Interface type</typeparam>
        /// <param name="directory">Directory</param>
        /// <returns>Interface objects</returns>
        public static IEnumerable<T> GetInterfaces<T>(this string directory) where T : class
        {
            string[] fn = Directory.GetFiles(directory, "*.dll");   // Dll files
            Assembly[] ass = AppDomain.CurrentDomain.GetAssemblies(); // Current domain assemblies
            foreach (Assembly a in ass) // Looking for objects in loaded assemblies
            {
                if (!locations.Contains(a.Location))
                {
                    locations.AddLast(a.Location);
                }
                IEnumerable<T> en = a.GetInterfaces<T>();
                foreach (T t in en)
                {
                    yield return t;
                }

            }
            foreach (string f in fn) // Looking for objects in directory
            {
                if (!locations.Contains(f))
                {
                    locations.AddLast(f);
                    IEnumerable<T> en = null;
                    try
                    {
                        en = Assembly.LoadFile(f).GetInterfaces<T>();
                    }
                    catch (Exception exception)
                    {
                        continue;
                    }
                    foreach (T t in en)
                    {
                        yield return t;
                    }
                }

            }
        }

        /// <summary>
        /// Gets interfaces from assembly (Searching of driver assembly)
        /// </summary>
        /// <typeparam name="T">Interface type</typeparam>
        /// <param name="assembly">Assembly</param>
        /// <returns>Interface objects</returns>
        public static IEnumerable<T> GetInterfaces<T>(this Assembly assembly) where T : class
        {
            Type[] types = new Type[0];
            try
            {
                types = assembly.GetTypes(); // Assembly types
            }
            catch (Exception)
            {
            }
            string st = typeof(T).FullName;     // Interface full name
            foreach (Type t in types)
            {
                Type ti = t.GetInterface(st);   // Gets interface
                if (ti == null)
                {
                    continue;
                }
                FieldInfo fi = t.GetField("Singleton"); // Gets Singleton field
                if (fi != null)
                {
                    yield return fi.GetValue(null) as T; // yeild Singleton
                }
            }
        }

        private static byte[] GetFileBytes(this string fileName)
        {
            if (!File.Exists(fileName))
            {
                return null;
            }
            using (Stream stream = File.OpenRead(fileName))
            {
                byte[] b = new byte[stream.Length];
                stream.Read(b, 0, b.Length);
                return b;
            }
        }




        /// <summary>
        /// Action for loaded assemblies
        /// </summary>
        /// <param name="action">Action</param>
        public static void AssemblyAction(this Action<Assembly> action)
        {
            List<string> l;
            if (acted.ContainsKey(action))
            {
                l = acted[action];
            }
            else
            {
                l = new List<string>();
                acted[action] = l;
            }
           Assembly[] ass = AppDomain.CurrentDomain.GetAssemblies();
           foreach (Assembly a in ass)
           {
               AssemblyName an = a.GetName();
               l.Add(an.Name);
               action(a);
           }
            AppDomain.CurrentDomain.AssemblyLoad += (object sender, AssemblyLoadEventArgs args) =>
                {
                    Assembly a = args.LoadedAssembly;
                    AssemblyName an = a.GetName();
                    if (l.Contains(an.Name))
                    {
                        return;
                    }
                    l.Add(an.Name);
                    action(args.LoadedAssembly);
                };
        }

        /// <summary>
        /// Check whether asse
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="type"></param>
        /// <returns>True if assembly has interface</returns>
        public static bool HasInterface(this Assembly assembly, Type type)
        {
           Type[] types = assembly.GetTypes(); // Assembly types
            string st = type.FullName;     // Interface full name
            foreach (Type t in types)
            {
                Type ti = t.GetInterface(st);   // Gets interface
                if (ti != null)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Loads assemblies from base directory
        /// </summary>
        /// <param name="exceptionHandler">Exception handler</param>
        private static void LoadBaseAssemblies(Action<Exception> exceptionHandler)
        {
            Assembly[] ass = AppDomain.CurrentDomain.GetAssemblies(); // Current domain assemblies
            foreach (var a in ass)
            {
                a.CallInit();
            }            
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            foreach (Assembly a in ass)
            {
                string loc = Path.GetFileName(a.Location);
                locations.AddLast(loc);
            }
            string[] fn = Directory.GetFiles(dir, "*.dll");   // Dll files
            locations.IteratedLoad(fn, exceptionHandler);
        }

        /// <summary>
        /// Check whether asse
        /// </summary>
        /// <param name="assembly">Assembly</param>
        /// <param name="detector">Type detector</param>
        /// <returns>True if assembly has interface</returns>
        public static bool HasInterface(this Assembly assembly, Func<Type, bool> detector)
        {
            try
            {
                Type[] types = assembly.GetTypes(); // Assembly types
                foreach (Type t in types)
                {
                    if (detector(t))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        #endregion

        #region Private Members

        static private void IteratedLoad(this LinkedList<string> l, 
            string[] files, Action<Exception> action)
        {
            int n = l.Count;
            foreach (string f in files)
            {
                if (l.Contains(Path.GetFileName(f)))
                {
                    continue;
                }
                try
                {
                    Assembly.LoadFile(f);
                    l.AddLast(Path.GetFileName(f));
                }
                catch (Exception ex)
                {
                    action(ex);
                }
            }
            if (l.Count != n)
            {
                l.IteratedLoad(files, action);
            }
        }

        #endregion

    }
}