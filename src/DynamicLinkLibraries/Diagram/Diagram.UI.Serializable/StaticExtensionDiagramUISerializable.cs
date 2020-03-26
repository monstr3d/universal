using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Xml;

using CategoryTheory;

using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using AssemblyService;

namespace Diagram.UI
{
    /// <summary>
    /// Static serialization operations
    /// </summary>
    public static class StaticExtensionDiagramUISerializable
    {

        #region Fields

        private static IReplaceAssembly replaceAssembly;

        private static bool first = true;

        #endregion

        #region Public Members

        /// <summary>
        /// Converts string to bytes
        /// </summary>
        /// <param name="buffer">Bytes</param>
        /// <returns>String</returns>
        static public string BytesToString(this byte[] buffer)
        {
            if (buffer == null)
            {
                return null;
            }
            char[] cb = new char[buffer.Length];
            for (int k = 0; k < buffer.Length; k++)
            {
                cb[k] = (char)buffer[k];
            }
            return new string(cb);
        }

        /// <summary>
        /// Converts string to bytes
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>Bytes</returns>
        static public byte[] StringToBytes(this string str)
        {
            if (str == null)
            {
                return null;
            }
            int n = str.Length;
            byte[] b = new byte[n];
            for (int k = 0; k < n; k++)
            {
                b[k] = (byte)str[k];
            }
            return b;
        }

        /// <summary>
        /// Create desktop from bytes
        /// </summary>
        /// <param name="buffer">Buffer</param>
        /// <returns>The desktop</returns>
        public static IDesktop DesktopFromBytes(this byte[] buffer)
        {
            if (buffer == null)
            {
                return null;
            }
            if (buffer.Length == 0)
            {
                return null;
            }
            PureDesktopPeer desktop = new PureDesktopPeer();
            bool success = desktop.Load(buffer);
            return success ? desktop : null;
        }

        /// <summary>
        /// Desktop from stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns>Desktop</returns>
        public static IDesktop DesktopFromStream(this System.IO.Stream stream)
        {
            PureDesktopPeer desktop = new PureDesktopPeer();
            bool success = desktop.Load(stream);
            return success ? desktop : null;
        }

        /// <summary>
        /// Desktop from file
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns>The desktop</returns>
        public static IDesktop DesktopFromFile(this string fileName)
        {
            using (System.IO.Stream stream = System.IO.File.OpenRead(fileName))
            {
                return stream.DesktopFromStream();
            }
        }

        /// <summary>
        /// Create desktop from string
        /// </summary>
        /// <param name="str">The string</param>
        /// <returns>The desktop</returns>
        public static IDesktop DesktopFromString(string str)
        {
            return str.StringToBytes().DesktopFromBytes();
        }

        /// <summary>
        /// Creates bytes from desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <returns>The bytes</returns>
        public static byte[] ToBytes(this IDesktop desktop)
        {
            if (desktop is PureDesktopPeer)
            {
                System.IO.MemoryStream stream = new System.IO.MemoryStream();
                (desktop as PureDesktopPeer).Save(stream);
                return stream.GetBuffer();
            }
            return null;
        }

        /// <summary>
        /// Creates string from desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <returns>The string</returns>
        public static string DesktopToString(this IDesktop desktop)
        {
            byte[] b = desktop.ToBytes();
            return (b == null) ? null : b.BytesToString();
        }

        /// <summary>
        /// Creates desktop from Xml documet
        /// </summary>
        /// <param name="document">The document</param>
        /// <param name="create">The create function</param>
        /// <returns>The desktop</returns>
        public static PureDesktopPeer LoadFromXml(this XmlDocument document, Func<XmlElement, object> create)
        {
            PureDesktopPeer desktop = new PureDesktopPeer();
            Dictionary<string, IObjectLabel> dictionary = new Dictionary<string, IObjectLabel>();
            XmlElement objs = document.GetElementsByTagName("Objects")[0] as XmlElement;
            foreach (XmlElement e in objs.ChildNodes)
            {
                string name = e.GetAttribute("Name");
                object o = create(e);
                if (o == null)
                {
                    continue;
                }
                string t = o.GetType() + "";
                string k = "";
                if (t.Equals("DataPerformer.DataLink") | t.Equals("DataPerformer.VectorFormulaConsumer"))
                {
                    k = "Mv";
                }
                PureObjectLabelPeer l = new PureObjectLabelPeer(name, k, t, 0, 0);
                dictionary[name] = l;
                desktop.AddObjectLabel(l, o as ICategoryObject, true);
                l.Desktop = desktop;
            }
            XmlElement arrs = document.GetElementsByTagName("Arrows")[0] as XmlElement;
            foreach (XmlElement e in arrs.ChildNodes)
            {
                string name = e.GetAttribute("Name");
                ICategoryArrow a = create(e) as ICategoryArrow;
                if (a == null)
                {
                    continue;
                }
                string s = e.GetAttribute("Source");
                string t = e.GetAttribute("Target");
                if (!dictionary.ContainsKey(s) | !dictionary.ContainsKey(t))
                {
                    continue;
                }
                try
                {
                    desktop.AddArrowWithExistingLabels(a, dictionary[s], dictionary[t], name, "");
                }
                catch (Exception)
                {
                }
            }
            return desktop;
        }

        /// <summary>
        /// Loads editor object
        /// </summary>
        /// <param name="editor">The editor</param>
        /// <param name="info">Serialization info</param>
        public static void Load(this IPropertiesEditor editor, SerializationInfo info)
        {
            editor.Properties = info.GetValue("Properties", typeof(object));
        }

        /// <summary>
        /// Saves editor object
        /// </summary>
        /// <param name="editor">The editor</param>
        /// <param name="info">Serialization info</param>
        public static void Save(this IPropertiesEditor editor, SerializationInfo info)
        {
            info.AddValue("Properties", editor.Properties, typeof(object));
        }

        /// <summary>
        /// Adds binder
        /// </summary>
        /// <param name="binder">Binder</param>
        public static void Add(this SerializationBinder binder)
        {
            SerializationInterface.StaticExtensionSerializationInterface.Binder = binder;
        }

        /// <summary>
        /// Sets binder
        /// </summary>
        /// <param name="binaryFormatter">Binary formatter</param>
        public static void SetBinder(this BinaryFormatter binaryFormatter)
        {
            if (SerializationInterface.StaticExtensionSerializationInterface.Binder == null)
            {
                return;
            }
            binaryFormatter.Binder = 
                SerializationInterface.StaticExtensionSerializationInterface.Binder;
        }

        /// <summary>
        /// Creates binary formatter
        /// </summary>
        /// <returns>Binary formatter</returns>
        public static BinaryFormatter CreareBinaryFormatter()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.SetBinder();
            return binaryFormatter;
        }

        /// <summary>
        /// Replaces assembly
        /// </summary>
        /// <param name="assembly">Initial assembly</param>
        /// <returns>Replaced assembly</returns>
        static public Assembly Replace(this Assembly assembly)
        {
            if (replaceAssembly == null)
            {
                return null;
            }
            return replaceAssembly.Replace(assembly);
        }

        /// <summary>
        /// Adds replace
        /// </summary>
        /// <param name="replace"></param>
        static public void Add(this IReplaceAssembly replace)
        {
            if (replaceAssembly == null)
            {
                replaceAssembly = replace;
                return;
            }
            if (replaceAssembly is ReplaceAssemblyCollection)
            {
                (replaceAssembly as ReplaceAssemblyCollection).Add(replace);
            }
            replaceAssembly = new ReplaceAssemblyCollection(
                new IReplaceAssembly[]{ replaceAssembly, replace});
       }

        /// <summary>
        /// Loads assemblt
        /// </summary>
        /// <param name="editor">Assembly editor</param>
        public static void LoadAssembly(this ISeparatedAssemblyEditedObject editor)
        {
            ISeparatedPropertyEditor ed = editor.Editor;
            if (ed != null)
            {
                return;
            }
            Type type = editor.GetType();
            Func<Type, bool> f = (Type t) =>
            {
                bool b = false;
                if (t.GetInterface(typeof(ISeparatedPropertyEditor).FullName) == null)
                {
                    return false;
                }
                b = type.CompareLinkedType(t);
                if (b)
                {
                    ConstructorInfo ci = t.GetConstructor(new Type[0]);
                    ISeparatedPropertyEditor pe = ci.Invoke(new object[0]) as ISeparatedPropertyEditor;
                    editor.Editor = pe;
                }
                return b;
            };             
            f.GetFirstAssemblyBytes(AppDomain.CurrentDomain.BaseDirectory);
        }

        /// <summary>
        /// Gets editor 
        /// </summary>
        /// <param name="editor">Edited object</param>
        /// <returns>Editor</returns>
        public static object GetEditor(this ISeparatedAssemblyEditedObject editor)
        {
            try
            {
                ISeparatedPropertyEditor ed = editor.Editor;
                Type type = editor.GetType();
                if (ed == null)
                {
                    byte[] b = editor.AssemblyBytes;
                    if (b != null)
                    {
                        Assembly ass = Assembly.Load(b);
                        Type[] types = ass.GetTypes();
                        foreach (Type t in types)
                        {
                            if (t.GetInterface(typeof(ISeparatedPropertyEditor).FullName) != null)
                            {
                                if (type.CompareLinkedType(t))
                                {
                                    ConstructorInfo ci = t.GetConstructor(new Type[0]);
                                    ISeparatedPropertyEditor se = ci.Invoke(new object[0]) as ISeparatedPropertyEditor;
                                    ed = se;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (ed == null)
                {
                    Func<Type, bool> f = (Type t) =>
                    {
                        if (t.GetInterface(typeof(ISeparatedPropertyEditor).FullName) 
                                 == null)
                        {
                            return false;
                        }
                        if (t.CompareLinkedType(type))
                        {
                            ConstructorInfo ci = t.GetConstructor(new Type[0]);
                            ISeparatedPropertyEditor pe = ci.Invoke(new object[0]) as ISeparatedPropertyEditor;
                            ed = pe;
                            return true;
                        }
                        return false;
                    };
                    f.GetFirstAssemblyBytes(AppDomain.CurrentDomain.BaseDirectory);
                }
                editor.Editor = ed;
                if (ed == null)
                {
                    return false;
                }
                return ed.GetEditor(editor);
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
            return null;
        }

        /// <summary>
        /// Detects parametrized type
        /// </summary>
        /// <param name="type">Type of object</param>
        /// <param name="parameter">Type of parameter</param>
        /// <returns>True in success</returns>
        public static bool DetectParametrizedType(Type type, Type parameter)
        {
            if (!type.IsGenericType)
            {
                return false;
            }
            Type[] typeParameters = type.GetGenericArguments();
            if (typeParameters == null)
            {
                return false;
            }
            foreach (Type t in typeParameters)
            {
                if (t.Equals(parameter))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Inits itself
        /// </summary>
        public static void Init()
        {
            if (!first)
            {
                return;
            }
            first = false;
            Action<Exception> act = (Exception ex) => { ex.ShowError(10); };
            StaticExtensionAssemblyService.LoadBaseAssemblies(act);
            StaticExtensionAssemblyService.AssemblyAction(CurrentDomain_AssemblyLoad);
            new Binder();
        }

        /// <summary>
        /// Refreshes a desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        public static void Refresh(this IDesktop desktop)
        {
            if (desktop is PureDesktopPeer)
            {
                PureDesktopPeer p = desktop as PureDesktopPeer;
                p.Refresh();
            }
        }

        #endregion

        #region Private Members

        private static void CurrentDomain_AssemblyLoad(Assembly ass)
        {
            try
            {
                Type[] types = ass.GetTypes();
                foreach (Type t in types)
                {
                    if (t.HasAttribute<InitAssemblyAttribute>())
                    {
                        MethodInfo mi = t.GetMethod("Init");
                        mi.Invoke(null, null);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        #endregion

        #region Binder Class

        class Binder : SerializationBinder
        {
            static readonly Dictionary<string, string> ass = new Dictionary<string, string>()
        {
            {"Diagram.UI.S", typeof(PureDesktopPeer).Assembly.FullName}
        };
            static bool first = true;

            internal Binder()
            {
                if (first)
                {
                    first = false;
                    this.Add();
                }
            }
            readonly string[] types = new string[] { "DiagramUI", "Diagram.UI" };
            public override Type BindToType(string assemblyName, string typeName)
            {
                if (assemblyName.Contains("DiagramUISerializable"))
                {
                    string t = typeName.Replace("DiagramUI.", "Diagram.UI.");
                    string a = typeof(Binder).Assembly.FullName;
                               return Type.GetType(String.Format("{0}, {1}",
                                   t, a));
                 
                }
                if (assemblyName.Contains(types[0]))
                {
                    foreach (string key in ass.Keys)
                    {
                        if (assemblyName.Contains(key))
                        {
                            return Type.GetType(String.Format("{0}, {1}",
                                typeName.Replace(types[0], types[1]),
                                ass[key]));
                        }
                    }
                }
                return null;
            }
        }

        #endregion

    }
}
