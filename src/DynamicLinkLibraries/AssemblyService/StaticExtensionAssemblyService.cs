﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

using SerializationInterface;
using Diagram.UI;


namespace AssemblyService
{
    /// <summary>
    /// Works with asseblies
    /// </summary>
    public static class StaticExtensionAssemblyService
    {

        #region Fields

        private static Dictionary<Action<Assembly>, List<string>> acted =
                new Dictionary<Action<Assembly>, List<string>>();

        static private bool firstBaseLoad = true;

        #endregion

        #region Public Members

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
            List<string> l = new List<string>();
            foreach (Assembly a in ass) // Looking for objects in loaded assemblies
            {
                l.Add(a.Location);
                IEnumerable<T> en = a.GetInterfaces<T>();
                foreach (T t in en)
                {
                    yield return t;
                }

            }
            foreach (string f in fn) // Looking for objects in directory
            {
                if (!l.Contains(f))
                {
                    IEnumerable<T> en = null;
                    try
                    {
                        en = Assembly.LoadFile(f).GetInterfaces<T>();
                    }
                    catch (Exception exception)
                    {
                        exception.ShowError();
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
        public static void LoadBaseAssemblies(Action<Exception> exceptionHandler)
        {
            if (!firstBaseLoad)
            {
                return;
            }
            firstBaseLoad = false;
            Assembly[] ass = AppDomain.CurrentDomain.GetAssemblies(); // Current domain assemblies
            List<string> l = new List<string>();
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            foreach (Assembly a in ass)
            {
                string loc = Path.GetFileName(a.Location);
                l.Add(loc);
            }
            string[] fn = Directory.GetFiles(dir, "*.dll");   // Dll files
            IteratedLoad(l, fn, exceptionHandler);
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
                ex.ShowError(10);
            }
            return false;
        }

        #endregion

        #region Private Members

        static private void IteratedLoad(List<string> l, string[] files, Action<Exception> action)
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
                    Assembly.Load(f);
                    l.Add(Path.GetFileName(f));
                }
                catch (Exception ex)
                {
                    action(ex);
                }
            }
            if (l.Count != n)
            {
                IteratedLoad(l, files, action);
            }
        }

        #endregion

    }
}