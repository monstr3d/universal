using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using System.Data;

using CategoryTheory;

using MathGraph;

using Diagram.UI.Labels;
using Diagram.UI.Interfaces;
using Diagram.UI.Attributes;
using Diagram.Interfaces;

using AssemblyService;


namespace Diagram.UI
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    public static class StaticExtensionDiagramUI
    {

        #region Fields


        private static ExtensionObject extension = new ExtensionObject();

        /// <summary>
        /// Separator
        /// </summary>
        private static char[] sep = "\r\n\t".ToCharArray();

        private static List<ISpecificCodeCreator> specificCodeCreators = new();



        /// <summary>
        /// Post create
        /// </summary>
        static private event Action<object> postCreateObject = (object o) => { };

        /// <summary>
        /// Create code action
        /// </summary>
        static private event Action<List<string>> onCreateCode;

        /// <summary>
        /// Handler of log
        /// </summary>
        private static IErrorHandler errorHandler;

        /// <summary>
        /// Object comparer
        /// </summary>
        public static readonly IComparer<object> ObjectComparer = new ObjectComparerClass();

        /// <summary>
        /// C# code creator
        /// </summary>
        private static IClassCodeCreator cSharpCodeCreator = new CombinedCodeCreator();

        /// Standard header of calculation class
        /// </summary>
        private static readonly string StandardHeader = "using System;" + Environment.NewLine +
            "using System.Collections.Generic;" + Environment.NewLine + 
            "using System.Linq;" + Environment.NewLine +
          //  "using System.Text;" + 
            Environment.NewLine + "" + Environment.NewLine + "";

        private static List<Func<object, bool>> nativeDetectors = new List<Func<object, bool>>();

        private static event Action<IDesktop> postLoadDesktop = (IDesktop desktop) => { };


        #endregion

        #region Public Memberes

        /// <summary>
        /// Adds creator
        /// </summary>
        /// <param name="creator"></param>
        public static void Add(this ISpecificCodeCreator creator)
        {
            specificCodeCreators.Add(creator);
        }

        /// <summary>
        /// Checks allow
        /// </summary>
        /// <param name="allow"></param>
        /// <returns>True if allow</returns>
        public static bool Allow(this IAllowCodeCreation allow)
        {
            foreach (var a in specificCodeCreators)
            {
                if (a.Allow(allow))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Creates data table
        /// </summary>
        /// <param name="strings">Strings</param>
        /// <param name="dic">Dictionary</param>
        public static DataTable Create(this IEnumerable<string> strings, Dictionary<string, string> dic)
        {
            return extension.Create(strings, dic);
        }

        /// <summary>
        /// Fills Dictionary from data table
        /// </summary>
        /// <param name="data">The data table</param>
        /// <param name="dic">The dictionary</param>
        public static void Fill(this DataTable data, Dictionary<string, string> dic)
        {
            extension.Fill(data, dic);
        }

        /// <summary>
        /// Fills dictionary from data table
        /// </summary>
        /// <param name="dataTable">The data table</param>
        /// <param name="strings">Strings</param>
        /// <param name="dic">Dictionary</param>
        public static void Fill(DataTable dataTable, IEnumerable<string> strings, Dictionary<string, string> dic)
        {
            extension.Fill(dataTable, strings, dic);
        }

        /// <summary>
        /// Copy of an array to a string
        /// </summary>
        /// <param name="x">The array</param>
        /// <param name="sep">The sting separator</param>
        /// <param name="end">The en</param>
        /// <returns>The string</returns>
        public static string CopyTo(this double[] x, string sep, string end)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < x.Length; i++)
            {
                sb.Append(x[i]);
                if (i < x.Length - 1)
                {
                    sb.Append(sep);
                }
            }
            sb.Append(end);
            return sb.ToString();
        }

        /// <summary>
        /// Loads array from string
        /// </summary>
        /// <param name="s">The str</param>
        /// <param name="x"></param>
        public static void LoadFromString(this string str, out double[] x)
        {
            var ss = str.Split(sep);
            var l = new List<double>();
            foreach (var ps in ss)
            {
                double y = 0;
                if (double.TryParse(ps, out y))
                {
                    l.Add(y);
                }
            }
            x = l.ToArray();
        }

        /// <summary>
        /// Checks whether a code should be created
        /// </summary>
        /// <param name="component">Component</param>
        /// <returns>True is code should be created</returns>
        public static bool ShouldCreateCode(this INamedComponent component)
        {
            if (component is IObjectLabel l)
            {
                var co = l.Object;
                if (co is IAllowCodeCreation cc)
                {
                    return cc.AllowCodeCreation | cc.Allow();
                }
            }
            if (component is IArrowLabel arrow)
            {
                if (arrow is IAllowCodeCreation cc)
                {
                      return cc.AllowCodeCreation | cc.Allow();
                }
            }
            return true;
        }

        /// <summary>
        /// Post load desktop
        /// </summary>
        public static event Action<IDesktop> PostLoadDesktop
        {
            add { postLoadDesktop += value; }
            remove { postLoadDesktop -= value; }
        }

        /// <summary>
        /// Post load desktop
        /// </summary>
        /// <param name="desktop"></param>
        public static void PostLoad(this IDesktop desktop)
        {
            postLoadDesktop(desktop);
        }

        /// <summary>
        /// Current desktop
        /// </summary>
        public static IDesktop CurrentDeskop
        {
            get;
            set;
        }

        /// <summary>
        /// Sets collection folders
        /// </summary>
        /// <param name="componentCollection">The collection</param>
        static public void SetComponentCollectionHolders(this
            IComponentCollection componentCollection)
        {
            componentCollection.ForEach((IComponentCollectionHolder componentCollectionHolder) =>
                { componentCollectionHolder.ComponentCollection = componentCollection; });
        }


        /// <summary>
        /// Post object creation event
        /// </summary>
        static public event Action<object> PostCreateObjectEvent
        {
            add
            {
                postCreateObject += value;
            }
            remove
            {
                postCreateObject -= value;
            }
        }

 
        /// <summary>
        /// Post object creation event
        /// </summary>
        static public void PostCreateObject(this object obj)
        {
            postCreateObject(obj);
            if (obj is IChildrenObject)
            {
                IAssociatedObject[] ass = (obj as IChildrenObject).Children;
                foreach (object o in ass)
                {
                    PostCreateObject(o);
                }
            }
        }

        /// <summary>
        /// Gets display objects
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objects">Objects</param>
        /// <param name="reason">Reason</param>
        /// <returns>Display objects</returns>
        static public IEnumerable<T> GetDisplayObjects<T>(this IEnumerable<T> objects, string reason) where T : class
        {
            foreach (object o in objects)
            {
                if (o is T)
                {
                    T t = o as T;
                    DisplayReasonsAttribute attr = o.GetType().ToTypeInfo().GetCustomAttribute<DisplayReasonsAttribute>();
                    if (attr != null)
                    {
                        string[] reasons = attr.Reasons;
                        foreach (string r in reasons)
                        {
                            if (r.Equals(reason))
                            {
                                yield return t;

                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets linked type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The linked type</returns>
        public static Type GetLinkedType(this Type type)
        {
            TypeInfo ti = IntrospectionExtensions.GetTypeInfo(type);
            LinkedTypeAttribute attr =
                CustomAttributeExtensions.GetCustomAttribute<LinkedTypeAttribute>(ti);
            if (attr == null)
            {
                return null;
            }
            return attr.Type;
        }

        /// <summary>
        /// Copmares type with linked type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="linked">The linked type</param>
        /// <returns>True in case of equality</returns>
        public static bool CompareLinkedType(this Type type, Type linked)
        {
            Type t = type.GetLinkedType();
            if (t == null)
            {
                return false;
            }
            return linked.Equals(t);
        }


   
        /// <summary>
        /// String value of object
        /// </summary>
        /// <param name="o">Object</param>
        /// <returns>String value</returns>
        public static string StringValue(this object o)
        {
            Type t = o.GetType();
            if (t.Equals(typeof(double)))
            {
                double a = (double)o;
                return a.DoubleToString();
            }
            if (t.Equals(typeof(bool)))
            {
                return ((bool)o) ? "true" : "false";
            }
            return o + "";

        }

        /// <summary>
        /// Converts to string
        /// </summary>
        /// <param name="a">Double value</param>
        /// <returns>String</returns>
        public static string DoubleToString(this double a)
        {
            return a.ToString("G17", System.Globalization.CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Adds native detector
        /// </summary>
        /// <param name="detector">Detector for add</param>
        public static void AddNativeDetector(this Func<object, bool> detector)
        {
            nativeDetectors.Add(detector);
        }


        /// <summary>
        /// Any to string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string AnyToString(this object obj)
        {
            Type t = obj.GetType();
            string s = obj.StringValue();
            if (t.Equals(typeof(double)))
            {
                return "(double)" + s;
            }
            if (t.Equals(typeof(string)))
            {
                return "\"" + s + "\"";
            }
            return s;
        }

        public static List<ICategoryObject> ToList(this IEnumerable<IObjectLabel> labels)
        {
            List<ICategoryObject> list = new List<ICategoryObject>();
            foreach (IObjectLabel l in labels)
            {
                list.Add(l.Object);
            }
            return list;
        }

        public static List<string> GetDictionaryCSharpCode<S,T>(this IDictionary<S,T> dictionary)
        {
            int n = dictionary.Count;
            List<string> l = new List<string>();
            l.Add("new Dictionary<" + typeof(S) + ',' + typeof(T) + ">()");
            l.Add("{");
            int i = 0;
            foreach (S key in dictionary.Keys)
            {
                ++i; ;
                string s = "\t{ " + key.AnyToString() + ',' + dictionary[key].AnyToString() + "}";
                if (i < n)
                {
                    s += ",";
                }
                l.Add(s);
            }
            l.Add("};");
            return l;
        }

        #endregion

        #region Ctor

        static StaticExtensionDiagramUI()
        {
            new ObjectContainerClassCodeCreator();
  /*          nativeDetectors.Add(
                (object obj) => { return obj.HasAttribute<NativeObjectAttribute>(); }
                );*/
        }

        #endregion

        #region Error & Warning indication

        /// <summary>
        /// Creates C# code for strings
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static List<string> GetCSharpCodeArray(this IEnumerable<string> array)
        {
            List<string> l = new List<string>();
            string[] ss = array.ToArray();
            l.Add("{");
            for (int i = 0; i < ss.Length; i++)
            {
                string s = "\t\"" + ss[i] + "\"";
                if (i < (ss.Length - 1))
                {
                    s += ',';
                }
                l.Add(s);
            }
            l.Add("};");
            return l;
        }

        /// <summary>
        /// Error handler
        /// </summary>
        public static IErrorHandler ErrorHandler
        {
            get
            {
                return errorHandler;
            }
            set
            {
                errorHandler = value;
            }
        }

        /// <summary>
        /// Shows exception (extension method)
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="obj">Attached object</param>
        static public void ShowError(this Exception exception, object obj = null)
        {
            object o;
            if (exception is IErrorHandler)
            {
                (exception as IErrorHandler).ShowError(exception, obj);
                return;
            }
            IErrorHandler eh = GetErrorHandler(obj, out o);
            if (eh != null)
            {
                eh.ShowError(exception, o);
                return;
            }
            if (errorHandler != null) // Static error handler
            {
                errorHandler.ShowError(exception, obj);
            }
        }

        /// <summary>
        /// Shows message
        /// </summary>
        /// <param name="message">The message to show</param>
        /// <param name="obj">Attached object</param>
        static public void Show(this string message, object obj = null)
        {
            object o;
            IErrorHandler eh = GetErrorHandler(obj, out o);
            if (eh != null)
            {
                eh.ShowMessage(message, o);
                return;
            }
            if (errorHandler != null)
            {
                errorHandler.ShowMessage(message, obj);
            }
        }

        #endregion

        #region C# Code Create

        /// <summary>
        /// On Create Code Action
        /// </summary>
        public static event Action<List<string>> OnCreateCode
        {
            add { onCreateCode += value; }
            remove { onCreateCode -= value; }
        }

        /// <summary>
        /// Creates desktop code
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <param name="prefix">The prefix</param>
        /// <param name="className">Desktop class</param>
        /// <param name="postLoad">Post load</param>
        /// <param name="constructorType">Type of constructor</param>
        /// <param name="staticClass">The "static class sign</param>
        /// <returns>The code</returns>
        public static List<string> CreateDesktopCode(this PureDesktop desktop, string prefix,
            string className, string check = null, bool postLoad = false, string constructorType = "internal ", bool staticClass = true)
        {
            var ct = constructorType;
            if (staticClass)
            {
                ct = "public ";
            }
            List <string> l = new List<string>();
            string pr = prefix;
            if (pr.Length > 0)
            {
                if (pr[pr.Length - 1] != '.')
                {
                    pr += ".";
                }
            }
            string preffixFull = pr + className;
            l.Add(className + " : Diagram.UI.PureDesktop");
            l.Add("{");
            l.Add("\t" + constructorType + className + "()");
            l.Add("\t{");
            int ko = 0;
            var ignoredObjs = new List<IObjectLabel>();
            foreach (IObjectLabel lab in desktop.Objects)
            {
                if (!lab.ShouldCreateCode())
                {
                    ignoredObjs.Add(lab);
                    continue;
                }
                l.Add("\t\tobjects.Add(new " + preffixFull +".OblectLabel" + ko + "(\"" + lab.Name + "\", this));");
                ++ko;
            }
            int ka = 0;
            l.Add("\t\tDiagram.UI.Labels.PureArrowLabel currALabel = null;");
            var ignoredArrs = new List<IArrowLabel>();
            foreach (IArrowLabel lab in desktop.Arrows)
            {
                if (!lab.ShouldCreateCode())
                {
                    ignoredArrs.Add(lab);
                    continue;
                }
                if (ignoredObjs.Contains(lab.Source) | ignoredObjs.Contains(lab.Target))
                {
                    ignoredArrs.Add(lab);
                    continue;

                }
                l.Add("\t\tcurrALabel  = new " + preffixFull + ".ArrowLabel" + ka + "(\"" + lab.Name + "\", this);");
                l.Add("\t\tarrows.Add(currALabel);");
                l.Add("\t\tcurrALabel.SourceNumber = " + lab.SourceNumber.ArrowNumToString() + ";");
                l.Add("\t\tcurrALabel.TargetNumber = " + lab.TargetNumber.ArrowNumToString() + ";");
                ++ka;
            }
            if (postLoad)
            {
     /*           l.Add("\t\tforeach (IObjectLabel l in objects)");
                l.Add("\t\t{");
                l.Add("\t\t\tl.Desktop = this;");
                l.Add("\t\t}");*/
                l.Add("\t\tbool pl = PostLoad();");
                l.Add("\t\tbool pd = PostDeserialize();");
                if (check != null)
                {
                    l.Add("\t\t" + check);
                }
            }
            l.Add("\t}");
            l.Add("");
            int i = 0;
            foreach (IObjectLabel lab in desktop.Objects)
            {
                if (ignoredObjs.Contains(lab))
                {
                    continue;
                }
                string cln = "OblectLabel" + i;
                l.Add("\tinternal class " + cln + " : Diagram.UI.Labels.PureObjectLabel");
                l.Add("\t{");
                l.Add("\t\tinternal " + cln + "(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, \"\", \"\", 0, 0)");
                l.Add("\t\t{");
                l.Add("\t\t\tthis.desktop = desktop;");
                var o = lab.Object;
                if (o is IObjectContainer)
                {
                    l.Add("\t\t\tobj = new " + cln + ".CategoryObject(this);");
                }
                else
                {
                    l.Add("\t\t\tobj = new " + cln + ".CategoryObject();");
                }
                l.Add("\t\t\tobj.Object = this;");
                l.Add("\t\t}");
                l.Add("");
                List<string> lt = cSharpCodeCreator.CreateCode(preffixFull + "." + cln, lab.Object);
                l.Add("\t\tinternal class CategoryObject : " + lt[0]);
                for (int j = 1; j < lt.Count; j++)
                {
                    l.Add("\t\t" + lt[j]);
                }
                l.Add("\t}");
                l.Add("");
                ++i;
            }
            i = 0;
            foreach (IArrowLabel lab in desktop.Arrows)
            {
                if (ignoredArrs.Contains(lab))
                {
                    continue;
                }
                string cln = "ArrowLabel" + i;
                l.Add("\tinternal class " + cln + " : Diagram.UI.Labels.PureArrowLabel");
                l.Add("\t{");
                l.Add("\t\tinternal " + cln + "(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, \"\", \"\", 0, 0)");
                l.Add("\t\t{");
                l.Add("\t\t\tthis.desktop = desktop;");
                l.Add("\t\t\tarrow = new " + cln + ".CategoryArrow();");
                l.Add("\t\t}");
                l.Add("");
                List<string> lt = cSharpCodeCreator.CreateCode(preffixFull, lab.Arrow);
                l.Add("\t\tinternal class CategoryArrow : " + lt[0]);
                for (int j = 1; j < lt.Count; j++)
                {
                    l.Add("\t\t" + lt[j]);
                }
                l.Add("\t}");
                l.Add("");
                ++i;
            }
            l.Add("}");
            l.Add("");
            return l;
        }

        /// <summary>
        /// Creates C# code
        /// </summary>
        /// <param name="desktope">Desktop</param>
        /// <param name="namespacE">Namespace</param>
        /// <param name="className">Class name</param>
        /// <param name="staticClass">Flag of static class</param>
        /// <returns>The code</returns>
        public static List<string> CreateInitDesktopCSharpCode(this IDesktop desktop, string namespacE, 
            string className, bool staticClass = true)
        {
            List<string> l = new List<string>();
            l.Add(StandardHeader);
            l.Add("namespace " + namespacE);
            l.Add("{");
            if (staticClass)
            {
                l.Add("\tpublic static class " + className);
                l.Add("\t{");
                l.Add("");
                l.Add("\t\t static public bool SuccessLoad { get; private set; } = true;");
                l.Add("");
                l.Add("\t\tpublic static  Diagram.UI.Interfaces.IDesktop Desktop { get => new InternalDesktop(); }");
                l.Add("");
                List<string> lt = (desktop as PureDesktop).CreateDesktopCode("", "InternalDesktop",
                    "SuccessLoad = pl & pd;\n\t\t\t\tPostLoad(this);\n\t\t\t\tName = \"" + className + "\"; ", true, "internal ");
                l.Add("\t\tinternal class " + lt[0]);
                for (int i = 1; i < lt.Count; i++)
                {
                    l.Add("\t\t" + lt[i]);
                }
                l.Add("\t}");
                l.Add("}");
            }
            else
            {
                l.Add("\tpublic  class " + className + " : Diagram.UI.PureDesktop");
                List<string> lt = (desktop as PureDesktop).CreateDesktopCode("", className,
               " \t\t\t\tPostLoad(this);\n\t\t\t\tName = \"" + className + "\"; ", true, "public ");
                for (int i = 1; i < lt.Count; i++)
                {
                    l.Add("\t" + lt[i]);
                }
                l.Add("}");
            }
            onCreateCode?.Invoke(l);
            return l;
        }

        #endregion

        #region Public members

        /// <summary>
        /// Sets order
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        public static void SortOrder<T>(this List<T> items)
        {
            items.Sort(new ObjectComparerClassT<T>());
        }
    
        /// <summary>
        /// Compares values
        /// </summary>
        /// <typeparam name="T">Value type</typeparam>
        /// <typeparam name="S"Key type</typeparam>
        /// <param name="dictionary">Dictionary</param>
        /// <param name="list">List</param>
        /// <returns>Double value</returns>
        public static T CompareValue<T, S>(this Dictionary<S, T> dictionary, List<T> list)
        { 
            foreach (var t in dictionary.Values)
            {
                if (list.Contains(t))
                {
                    return t;
                }
                list.Add(t);
            }
            return default(T);
        }

        /// <summary>
        /// Loads start
        /// </summary>
        public static void LoadStart()
        {
            Action<Assembly> act = (Assembly ass) =>
            {
                var st = ass.GetInterfaces<IRunning>();
                foreach (var s in st)
                {
                    s.IsRunning = true;
                }
            };
            act.AssemblyAction();
        }

        /// <summary>
        /// Gets children
        /// </summary>
        /// <typeparam name="T">Type of retutn</typeparam>
        /// <param name="childrenObject">The children object</param>
        /// <returns>The children</returns>
        static public T GetChild<T>(this IChildrenObject childrenObject) where T : class
        {
            if (childrenObject is T)
            {
                return childrenObject as T;
            }
            IAssociatedObject[] children = childrenObject.Children;
            foreach (object o in children)
            {
                if (o is T)
                {
                    return o as T;
                }
                if (o is IChildrenObject)
                {
                 T t =   (o as IChildrenObject).GetChild<T>();
                    if (t != null)
                    {
                        return t;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Sets parents of objects of desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        public static void SetParents(this IDesktop desktop)
        {
            IEnumerable<IObjectLabel> objects = desktop.Objects;
            foreach (IObjectLabel ol in objects)
            {
                if (ol.Object is IObjectContainer)
                {
                    IObjectContainer oc = ol.Object as IObjectContainer;
                    oc.SetParents(desktop);
                }
            }
        }

        /// <summary>
        /// Gets all objects of desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <returns>Collection of all objects including children</returns>
        public static ICollection<object> GetAllObjects(this IDesktop desktop)
        {
            List<object> l = new List<object>();
            IEnumerable<object> components = desktop.Components;
            l.AddRange(components);
            IEnumerable<IObjectLabel> objs = desktop.Objects;
            foreach (IObjectLabel o in objs)
            {
                if (o.Object is IObjectContainer)
                {
                    IObjectContainer oc = o.Object as IObjectContainer;
                    l.AddRange(oc.AllObjects);
                }
            }
            return l;
        }

        /// <summary>
        /// Adds C# class code creator
        /// </summary>
        /// <param name="creator"></param>
        public static void AddCSharpCodeCreator(this IClassCodeCreator creator)
        {
            (cSharpCodeCreator as CombinedCodeCreator).Add(creator);
        }

        /// <summary>
        /// Gets difference between components 
        /// </summary>
        /// <param name="nc1">First component</param>
        /// <param name="nc2">Second component</param>
        /// <returns>Difference</returns>
        public static int GetDifference(this INamedComponent nc1, INamedComponent nc2)
        {
            IDesktop d = GetCommonDesktop(nc1, nc2);
            return GetOrder(nc1, d) - GetOrder(nc2, d);
        }

        /// <summary>
        /// Common desktop of two components
        /// </summary>
        /// <param name="c1">First component</param>
        /// <param name="c2">Second component</param>
        /// <returns>Common desktop</returns>
        public static IDesktop GetCommonDesktop(this INamedComponent c1, INamedComponent c2)
        {
            List<IDesktop> l1 = GetPath(c1);
            List<IDesktop> l2 = GetPath(c2);
            foreach (IDesktop d in l1)
            {
                if (l2.Contains(d))
                {
                    return d;
                }
            }
            return null;
        }

        /// <summary>
        /// Path of component desktops
        /// </summary>
        /// <param name="component">The component</param>
        /// <returns>Desktop path</returns>
        static public List<IDesktop> GetPath(this INamedComponent component)
        {
            List<IDesktop> l = new List<IDesktop>();
            IDesktop d = component.Desktop;
            while (true)
            {
                if (d == null)
                {
                    break;
                }
                l.Add(d);
                d = d.ParentDesktop;
            }
            return l;
        }

        /// <summary>
        /// Converts Enumerable to string
        /// </summary>
        /// <param name="enumerable">Enumerable</param>
        /// <returns>String</returns>
        static public string EnumerableToString(this IEnumerable<string> enumerable)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in enumerable)
            {
                sb.Append(s + Environment.NewLine);
            }
            return sb + "";
        }

        /// <summary>
        /// Gets child named component
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="name">Name of object</param>
        /// <returns>The child component</returns>
        static public INamedComponent GetChild(this IDesktop desktop, string name)
        {
            IEnumerable<IObjectLabel> c = desktop.Objects;
            foreach (IObjectLabel l in c)
            {
                object ob = l.Object;
                if (!(ob is IObjectContainer))
                {
                    continue;
                }
                IObjectContainer cont = ob as IObjectContainer;
                ICollection<object> all = cont.AllObjects;
                foreach (INamedComponent nc in all)
                {
                    string n = nc.GetName(desktop);
                    if (n.Equals(name))
                    {
                        return nc;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets name of associated object
        /// </summary>
        /// <param name="associatedObject">The object</param>
        /// <returns>The name</returns>
        static public string GetName(this IAssociatedObject associatedObject)
        {
            if (associatedObject is INamedComponent)
            {
                return (associatedObject as INamedComponent).Name;
            }
            object o = associatedObject.Object;
            if (o is INamedComponent)
            {
                return (o as INamedComponent).Name;
            }
            return null;
        }

        /// <summary>
        /// Gets root  name of associated object
        /// </summary>
        /// <param name="associatedObject">The object</param>
        /// <returns>The name</returns>
        static public string GetRootName(this IAssociatedObject associatedObject)
        {
            return associatedObject.GetName(associatedObject.GetRootDesktop());
        }
  
        /// <summary>
        /// Sets aliases
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="names">Names</param>
        /// <param name="parametres">Aliases</param>
        static public void SetAliases(this IDesktop desktop, Dictionary<string, string> names,
            Dictionary<string, object> parametres)
        {
            Dictionary<string, object> d = desktop.GetAllAliases();
            Dictionary<string, object> dd = new Dictionary<string, object>();
            foreach (string n in names.Keys)
            {
                if (!parametres.ContainsKey(n))
                {
                    continue;
                }
                string ali = names[n];
                if (d.ContainsKey(ali))
                {
                    dd[ali] = parametres[n];
                }
            }
            desktop.SetAliases(dd);
        }

        /// <summary>
        /// Gets aliases
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="names">Names of aliases</param>
        /// <returns>Values of aliases</returns>
        static public Dictionary<string, object> GetAliases(this IDesktop desktop, Dictionary<string, string> names)
        {
            Dictionary<string, object> d = desktop.GetAllAliases();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            foreach (string n in names.Keys)
            {
                string a = names[n];
                if (d.ContainsKey(a))
                {
                    dic[n] = d[a];
                }
            }
            return dic;
        }

        /// <summary>
        /// Gets names of aliases
        /// </summary>
        /// <param name="vector">Alias vector</param>
        /// <returns>Names of aliases</returns>
        public static IList<string> GetAliasNames(this IAliasVector vector)
        {
            return vector.AliasNames;
        }

        /// <summary>
        /// Ordered keys of dictionary
        /// </summary>
        /// <typeparam name="S">Key type</typeparam>
        /// <typeparam name="T">Value type</typeparam>
        /// <param name="dictionary">The dictionary</param>
        /// <returns>Ordered keys</returns>
        static public S[] OrderedKeys<S, T>(this IDictionary<S, T> dictionary)
        {
            List<S> l = new List<S>(dictionary.Keys);
            l.Sort();
            return l.ToArray();
        }
      
        /// <summary>
        /// Adds Error hablder
        /// </summary>
        /// <param name="errorHandler">Error handler</param>
        /// <param name="onError">On error event</param>
        static public void Add(this IErrorHandler errorHandler, Action<Exception, object> onError)
        {
            if (errorHandler == null)
            {
                return;
            }
            if (onError != null)
            {
                onError += errorHandler.ShowError;
            }
        }

        /// <summary>
        /// Removes Error hablder
        /// </summary>
        /// <param name="errorHandler">Error handler</param>
        static public void Remove(this IErrorHandler errorHandler, Action<Exception, object> onError)
        {
            if (errorHandler == null)
            {
                return;
            }
            if (onError != null)
            {
                onError -= errorHandler.ShowError;
            }
        }

        /// <summary>
        /// Converts object to single array
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="t">Object</param>
        /// <returns>Array</returns>
        public static T[] ToSingleArray<T>(this T t)
        {
            return new T[] { t };
        }

        /// <summary>
        /// Converts enumerable to array
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="enumerable">Enumerable</param>
        /// <returns>Array</returns>
        public static T[] EnumerableToArray<T>(this IEnumerable<T> enumerable) 
        {
            List<T> l = new List<T>();
            foreach (T t in enumerable)
            {
                l.Add(t);
            }
            return l.ToArray();
        }

        /// <summary>
        /// Sets strict error handler
        /// </summary>
        public static void SetStrictErrorHandler()
        {
            ErrorHandler = ErrorHandlers.StrictErrorHandler.Singleton;
        }

  
        /// <summary>
        /// Shows error
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="errorLevel">Error level</param>
        static public void ShowErrorLevel(this Exception exception, int errorLevel = 0)
        {

            object o = errorLevel;
            ShowError(exception, o);
        }

        /// <summary>
        /// Shows message
        /// </summary>
        /// <param name="message">The message to show</param>
        /// <param name="level">Level of message</param>
        static public void Show(this string message, int level)
        {
            object o = level;
            Show(message, o);
        }

        /// <summary>
        /// Gets relative name
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="target">Target</param>
        /// <returns>The relative name</returns>
        static public string GetRelativeName(this INamedComponent source, INamedComponent target)
        {
            return target.GetName(source.Desktop);
        }

        /// <summary>
        /// Gets relative name
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="target">Target</param>
        /// <returns>The relative name</returns>
        static public string GetRelativeName(this IAssociatedObject source, IAssociatedObject target)
        {
            INamedComponent cs = null;
            if (source is INamedComponent)
            {
                cs = source as INamedComponent;
            }
            else
            {
                cs = source.Object as INamedComponent;
            }
            INamedComponent ct = null;
            if (target is INamedComponent)
            {
                ct = target as INamedComponent;
            }
            else
            {
                ct = target.Object as INamedComponent;
            }
            return GetRelativeName(cs, ct);
        }

        /// <summary>
        /// Names of desktop objects
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <returns>Names</returns>
        public static string[] GetNames(this IDesktop desktop)
        {
            IEnumerable<object> l = GetObjectsAndArrows(desktop);
            List<string> ln = new List<string>();
            foreach (object o in l)
            {
                if (o is INamedComponent)
                {
                    INamedComponent nc = o as INamedComponent;
                    ln.Add(nc.GetName(desktop));
                }
            }
            return ln.ToArray();
        }

        /// <summary>
        /// Composition of path arrows
        /// </summary>
        /// <param name="category">Category of arrows</param>
        /// <param name="path">The path</param>
        /// <returns>The composition</returns>
        static public  IAdvancedCategoryArrow Composition(this ICategory category, DigraphPath path)
        {
            IArrowLabel label = path[0].Object as IArrowLabel;
            IAdvancedCategoryArrow arrow = label.Arrow as IAdvancedCategoryArrow;
            for (int i = 1; i < path.Count; i++)
            {
                label = path[i].Object as IArrowLabel;
                arrow = (label.Arrow as IAdvancedCategoryArrow).Compose(category, arrow);
            }
            return arrow;
        }

        /// <summary>
        /// Gets all category objects and arrows of collectiob
        /// </summary>
        /// <param name="collection">Collection</param>
        /// <returns>All category objects and arrows</returns>
        static public List<object> GetObjectsAndArrows(this IEnumerable<object> collection)
        {
            List<object> l = new List<object>();
            ForEach<ICategoryObject>(collection, (ICategoryObject o) => { if (!l.Contains(o)) { l.Add(o); } });
            ForEach<ICategoryArrow>(collection, (ICategoryArrow o) => { if (!l.Contains(o)) { l.Add(o); } });
            return l;
        }

        /// <summary>
        /// Get objects of object
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Objects</returns>
        static public object[] GetObjects(this object obj)
        {
            if (obj is IChildrenObject)
            {
                IChildrenObject co = obj as IChildrenObject;
                return GetObjects(co);
            }
            if (obj is IObjectLabel)
            {
                ICategoryObject cato = (obj as IObjectLabel).Object;
                if (cato is IChildrenObject)
                {
                    IChildrenObject co = cato as IChildrenObject;
                    return GetObjects(co);
                }
                else
                {
                    return new object[] { cato };
                }
            }
            if (obj is IArrowLabel)
            {
                ICategoryArrow caro = (obj as IArrowLabel).Arrow;
                if (caro is IChildrenObject)
                {
                    IChildrenObject co = caro as IChildrenObject;
                    return GetObjects(co);
                }
                else
                {
                    return new object[] { caro};
                }
            }
            return new object[] { obj };
        }

        /// <summary>
        /// Gets objects of children object
        /// </summary>
        /// <param name="childrenObject"></param>
        /// <returns></returns>
        static public object[] GetObjects(IChildrenObject childrenObject)
        {
            List<object> l = new List<object>();
            l.Add(childrenObject);
            IAssociatedObject[] ch = childrenObject.Children;
            foreach (object o in ch)
            {
                if (o is IChildrenObject)
                {
                    IChildrenObject cc = o as IChildrenObject;
                    l.AddRange(GetObjects(cc));
                }
                else if (o != null)
                {
                    l.Add(o);
                }
            }
            return l.ToArray();
        }

        /// <summary>
        /// Gets all category objects and arrows of desktop
        /// </summary>
        /// <param name="d">Desktop</param>
        /// <returns>All category objects and arrows</returns>
        static public IEnumerable<object> GetObjectsAndArrows(this IDesktop d)
        {
            IEnumerable<ICategoryObject> objs = d.CategoryObjects;
            IEnumerable<ICategoryArrow> arrs = d.CategoryArrows;
            foreach (object o in objs)
            {
                yield return o;
            }
            foreach (object o in arrs)
            {
                yield return o;
            }
        }

        /// <summary>
        /// Gets all category objects and arrows of collection
        /// </summary>
        /// <param name="collection">Desktop</param>
        /// <returns>All category objects and arrows</returns>
        static public IEnumerable<object> GetObjectsAndArrows(this IComponentCollection collection)
        {
            return GetObjectsAndArrows(collection.AllComponents);
        }
   
        /// <summary>
        /// Gets all aliases of desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <returns>Dictionary "alias - value"</returns>
        static public Dictionary<string, object> GetAllAliases(this IDesktop desktop)
        {
            IEnumerable<object> l = GetObjectsAndArrows(desktop);
            Dictionary<string, object> d = new Dictionary<string, object>();
            foreach (object o in l)
            {
                if (!(o is IAlias))
                {
                    continue;
                }
                IAssociatedObject ao = o as IAssociatedObject;
                INamedComponent nc = ao.Object as INamedComponent;
                string name = nc.GetName(desktop);
                IAlias al = o as IAlias;
                IList<string> an = al.AliasNames;
                foreach (string nam in an)
                {
                    string n = name + "." + nam;
                    if (d.ContainsKey(n))
                    {
                        throw new Exception("Double alias");
                    }
                    d[n] = al[nam];
                }
            }
            return d;
        }

        /// <summary>
        /// Gets types of aliases of desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <returns>Dictionary "alias - value"</returns>
        static public Dictionary<string, object> GetAllAliasTypes(this IDesktop desktop)
        {
            IEnumerable<object> l = GetObjectsAndArrows(desktop);
            Dictionary<string, object> d = new Dictionary<string, object>();
            foreach (object o in l)
            {
                if (!(o is IAlias))
                {
                    continue;
                }
                IAssociatedObject ao = o as IAssociatedObject;
                INamedComponent nc = ao.Object as INamedComponent;
                string name = nc.GetName(desktop);
                IAlias al = o as IAlias;
                IList<string> an = al.AliasNames;
                foreach (string nam in an)
                {
                    string n = name + "." + nam;
                    if (d.ContainsKey(n))
                    {
                        throw new Exception("Double alias");
                    }
                    d[n] = al.GetType(nam);
                }
            }
            return d;
        }

        /// <summary>
        /// Sets all aliases of desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <param name="aliases">Dictionary of aliases</param>
        public static void SetAliases(this IDesktop desktop, Dictionary<string, object> aliases)
        {
            IEnumerable<object> l = GetObjectsAndArrows(desktop);
            foreach (object o in l)
            {
                if (!(o is IAlias))
                {
                    continue;
                }
                IAssociatedObject ao = o as IAssociatedObject;
                INamedComponent nc = ao.Object as INamedComponent;
                string name = nc.GetName(desktop);
                IAlias al = o as IAlias;
                IList<string> an = al.AliasNames;
                foreach (string nam in an)
                {
                    string n = name + "." + nam;
                    if (aliases.ContainsKey(n))
                    {
                        al[nam] = aliases[n];
                    }
                }
            }
        }

        /// <summary>
        /// Disposes desktop
        /// </summary>
        /// <param name="desktop">Desktop to dispose</param>
        public static void Dispose(this IDesktop desktop)
        {
            Remove(desktop);
            IEnumerable<object> c = desktop.AllComponents;
            foreach (object o in c)
            {
                DisposeAssociatedObject(o);

            }
        }

        /// <summary>
        /// Disposes desktop
        /// </summary>
        /// <param name="desktop">Desktop to dispose</param>
        public static void DisposeDesktop(this IDesktop desktop)
        {
            desktop.Dispose();
        }

        /// <summary>
        /// Disposes desktop
        /// </summary>
        /// <param name="desktop">The desktop for disposing</param>
        public static void Remove(this IDesktop desktop)
        {
            IEnumerable<ICategoryArrow> arrs = desktop.CategoryArrows;
            foreach (ICategoryArrow arr in arrs)
            {
                arr.RemoveObject();
            }
            IEnumerable<ICategoryObject> objs = desktop.CategoryObjects;
            foreach (ICategoryObject ob in objs)
            {
                ob.RemoveObject();
            }
        }

        /// <summary>
        /// Removes object
        /// </summary>
        /// <param name="o">The object to remove</param>
        public static void RemoveObject(this object o)
        {
            if (o == null)
            {
                return;
            }
            if (o is IDisposable disposable)
            {
                disposable.Dispose();
            }
            if (o is IChildrenObject ch)
            {
                ch.DisposeChildren();
            }
            if (o is IObjectLabel ol)
            {
                ol.Object.RemoveObject();
                ol.DisposeObject();
            }
            if (o is IArrowLabel al)
            {
                al.Arrow.RemoveObject();
                al.DisposeArrow();
            }
        }

        /// <summary>
        /// Dispodes a children object
        /// </summary>
        /// <param name="ob">The object</param>
        static public void DisposeChildren(this IChildrenObject ob)
        {
            var ch = ob.Children;
            foreach (var o in ch)
            {
                if (o is IChildrenObject c)
                {
                    c.DisposeChildren();
                }
                if (o is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
        }

        /// <summary>
        /// Disposes arrow label
        /// </summary>
        /// <param name="arrow">The arrow label</param>
        static public void DisposeArrow(this IArrowLabel arrow)
        {
            if (arrow is IChildrenObject ch)
            {
                ch.DisposeChildren();
            }
            if (arrow.Arrow is IDisposable da)
            {
                da.Dispose();
            }
            if (arrow is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }

        /// <summary>
        /// Disposes object label
        /// </summary>
        /// <param name="ol">The object label</param>
        static public void DisposeObject(this IObjectLabel ol)
        {
            if (ol == null)
            {
                return;
            }
            if (ol.Object is IChildrenObject c)
            {
                c.DisposeChildren();
            }
            if (ol is IDisposable dol)
            {
                dol.Dispose();
                ol.Object = null;
                return;
            }
            if (ol.Object is IDisposable d)
            {
                d.Dispose();
                ol.Object = null;
            }
        }

        /// <summary>
        /// Transforms collection
        /// </summary>
        /// <typeparam name="T">Output type</typeparam>
        /// <typeparam name="S">Inupt type</typeparam>
        /// <param name="collection">Input collection</param>
        /// <returns>Output collection</returns>
        public static IEnumerable<T> ForEach<T, S>(this IEnumerable<S> collection)
            where T : class where S : class
        {
            foreach (S s in collection)
            {
                if (s is T t)
                {
                    yield return t;
                }
                if (s is IObjectLabel l)
                {
                    object obj = l.Object;
                    if (obj is T to)
                    {
                        yield return to;
                    }
                }
                if (s is IArrowLabel al)
                {
                    object a = al.Arrow;
                    if (a is T ta)
                    {
                        yield return ta;
                    }
                }
                if (s is IAssociatedObject ao)
                {
                    T tc = ao.Find<T>();
                    if (tc != null)
                    {
                        yield return tc;
                    }
                }
            }
        }
  
        /// <summary>
        /// Performs action for each collection objects
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="collection">The collection</param>
        /// <param name="action">The action</param>
        public static void ForEach<T>(this IEnumerable<object> collection, Action<T> action, bool find = false) 
            where T : class
        {
            foreach (object o in collection)
            {
                if (o is T)
                {
                    Execute(o as T, action, find);
                    continue;
                }
                if (o is IObjectLabel)
                {
                    IObjectLabel l = o as IObjectLabel;
                    object obj = l.Object;
                    Execute(obj, action, find);
                }
                if (o is IArrowLabel)
                {
                    IArrowLabel l = o as IArrowLabel;
                    object obj = l.Arrow;
                    Execute(obj, action, find);
                }
                if (o is IAssociatedObject)
                {
                    Execute(o, action, find);
                }
            }
        }

        /// <summary>
        /// Performs action for each collection objects
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="collection">The collection</param>
        /// <param name="action">The action</param>
        /// <param name="find">The "find" sign</param>
        public static void ForEach<T>(this IComponentCollection collection, Action<T> action, bool find = false) where T : class
        {
            IEnumerable<object> c = collection.AllComponents;
            ForEach(c, action, find);
        }

        /// <summary>
        /// Performs action for each collection objects
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="collection">The collection</param>
        /// <param name="action">The action</param>
        public static void ForAll<T>(this IComponentCollection collection, 
            Action<T> action, bool find = true) where T : class
        {
            IEnumerable<object> en = collection.AllComponents;
            foreach (var a in en)
            {
                if (a is T)
                {
                    (a as T).Execute(action, find);
                }
                if (a is IObjectLabel)
                {
                    var o = (a as IObjectLabel).Object;
                    if (o is T)
                    {
                        (o as T).Execute(action, find);
                    }
                    if (o is IObjectContainer)
                    {
                        (o as IObjectContainer).Desktop.ForAll(action, find);
                    }
                }
            }
        }

        /// <summary>
        /// Performs action for each desktop objects
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="obj">Base object</param>
        /// <param name="action">The action</param>
        /// <param name="find">The "find" sign</param>
        public static void ForEach<T>(this ICategoryObject obj, Action<T> action, bool find = false) where T : class
        {
            IDesktop desktop = GetRootDesktop(obj);
            desktop.ForEach(action, find);
        }

  
        /// <summary>
        /// Gets root desktop
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Root desktop</returns>
        public static IDesktop GetRootDesktop(this ICategoryObject obj)
        {
            object o = obj.Object;
            if (o == null)
            {
                return null;
            }
            INamedComponent nc = o as INamedComponent;
            nc = nc.Root;
            return nc.Desktop;
        }

        /// <summary>
        /// Gets root desktop
        /// </summary>
        /// <param name="arr">Arrow</param>
        /// <returns>Root desktop</returns>
        public static IDesktop GetRootDesktop(this ICategoryArrow arr)
        {
            object o = arr.Object;
            INamedComponent nc = o as INamedComponent;
            nc = nc.Root;
            return nc.Desktop;
        }

        /// <summary>
        /// Gets Named Component
        /// </summary>
        /// <param name="obj">Associated object</param>
        /// <returns>Named Component</returns>
        public static INamedComponent GetNamedComponent(this IAssociatedObject obj)
        {
            if (obj is INamedComponent)
            {
                return obj as INamedComponent;
            }
            object o = obj.Object;
            if (o is INamedComponent)
            {
                return o as INamedComponent;
            }
            return null;
        }

        /// <summary>
        /// Gets category object
        /// </summary>
        /// <param name="obj">Prototype</param>
        /// <returns>The object</returns>
        public static ICategoryObject GetCategoryObject(this IAssociatedObject obj)
        {
            object o = GetObject(obj);
            if (o is ICategoryObject)
            {
                return o as ICategoryObject;
            }
            return null;
        }

        /// <summary>
        /// Gets category arrow
        /// </summary>
        /// <param name="obj">Prototype</param>
        /// <returns>The arrow</returns>
        public static ICategoryArrow GetCategoryArrow(this IAssociatedObject obj)
        {
            object o = GetObject(obj);
            if (o is ICategoryArrow)
            {
                return o as ICategoryArrow;
            }
            return null;
        }

        /// <summary>
        /// Adds object label to desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <param name="label">The label</param>
        /// <param name="categoryObject">The object</param>
        /// <param name="associated">The "assoicated" sign</param>
        public static void AddObjectLabel(this IDesktop desktop, IObjectLabel label, ICategoryObject categoryObject, bool associated)
        {
            label.Object = categoryObject;
            categoryObject.Object = label;
            List<IObjectLabel> l = new List<IObjectLabel>();
            l.Add(label);
            List<IArrowLabel> la = new List<IArrowLabel>();
            desktop.Copy(l, la, associated);
        }

        /// <summary>
        /// Gets object name
        /// </summary>
        /// <param name="ao">Object</param>
        /// <returns>The name</returns>
        public static string GetObjectName(this IAssociatedObject ao)
        {
            object o = ao.Object;
            if (!(o is INamedComponent))
            {
                throw new Exception();
            }
            INamedComponent nc = o as INamedComponent;
            return nc.Name + "";
        }

        /// <summary>
        /// Sets value of alias variable
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="alias">The alias name</param>
        /// <param name="val">The alias value</param>
        static public void SetAliasValue(this IDesktop desktop, string alias, object val)
        {
            int n = alias.LastIndexOf('.');
            string cName = alias.Substring(0, n);
            INamedComponent c = desktop[cName];
            string alName = alias.Substring(n + 1);
            IAlias al = null;
            if (c is IObjectLabel)
            {
                IObjectLabel ol = c as IObjectLabel;
                al = ol.Object as IAlias;
            }
            if (c is IArrowLabel)
            {
                IArrowLabel ar = c as IArrowLabel;
                al = ar.Arrow as IAlias;
            }
            al[alName] = val;
        }

        /// <summary>
        /// Gets alias value
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="alias">The alias name</param>
        /// <returns>The alias value</returns>
        static public object GetAliasValue(this IDesktop desktop, string alias)
        {
            int n = alias.IndexOf('.');
            string cName = alias.Substring(0, n);
            INamedComponent c = desktop[cName];
            string alName = alias.Substring(n + 1);
            IAlias al = null;
            if (c is IObjectLabel)
            {
                IObjectLabel ol = c as IObjectLabel;
                al = ol.Object as IAlias;
            }
            if (c is IArrowLabel)
            {
                IArrowLabel ar = c as IArrowLabel;
                al = ar.Arrow as IAlias;
            }
            return al[alName];
        }

        /// <summary>
        /// Gets alias type
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="alias">The alias name</param>
        /// <returns>The alias value</returns>
        static public object GetAliasType(this IDesktop desktop, string alias)
        {
            int n = alias.IndexOf('.');
            string cName = alias.Substring(0, n);
            INamedComponent c = desktop[cName];
            string alName = alias.Substring(n + 1);
            IAlias al = null;
            if (c is IObjectLabel)
            {
                IObjectLabel ol = c as IObjectLabel;
                al = ol.Object as IAlias;
            }
            if (c is IArrowLabel)
            {
                IArrowLabel ar = c as IArrowLabel;
                al = ar.Arrow as IAlias;
            }
            return al.GetType(alName);
        }

        /// <summary>
        /// Gets arrow label from desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <param name="name">Arrow name</param>
        /// <returns>The arrow label</returns>
        static public IArrowLabel GetArrowLabel(this IDesktop desktop, string name)
        {
            object o = desktop[name];
            if (o == null)
            {
                return null;
            }
            if (!(o is IArrowLabel))
            {
                return null;
            }
            return o as IArrowLabel;
        }

        /// <summary>
        /// Gets associated object of desktop component
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="name">Component name</param>
        /// <returns>Associated object</returns>
        public static object GetAssociatedObject(this IDesktop desktop, string name)
        {
            INamedComponent comp = desktop[name];
            if (comp is IObjectLabel)
            {
                IObjectLabel lab = comp as IObjectLabel;
                return lab.Object;
            }
            if (comp is IArrowLabel)
            {
                IArrowLabel lab = comp as IArrowLabel;
                return lab.Arrow;
            }
            return null;
        }

        /// <summary>
        /// Gets associated object that implements the interface
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="name">Name of object</param>
        /// <returns>The object</returns>
        public static T GetAssociatedObject<T>(this IDesktop desktop, string name) where T : class
        {
            object obj = GetAssociatedObject(desktop, name);
            if (!(obj is IAssociatedObject))
            {
                return null;
            }
            IAssociatedObject ao = obj as IAssociatedObject;
            return ao.GetObject<T>();
        }

        /// <summary>
        /// Gets relative object
        /// </summary>
        /// <typeparam name="T">Type of relative object</typeparam>
        /// <param name="obj">This object</param>
        /// <param name="name">Object name</param>
        /// <returns>Relative object</returns>
        public static T GetRelativeObject<T>(this ICategoryObject obj, string name) where T : class
        {
            IAssociatedObject ao = obj as IAssociatedObject;
            INamedComponent nc = ao.Object as INamedComponent;
            IDesktop d = nc.Desktop;
            return GetAssociatedObject<T>(d, name);
        }

        /// <summary>
        /// Gets source arrows of object
        /// </summary>
        /// <typeparam name="T">Arrow type</typeparam>
        /// <param name="obj">The object</param>
        /// <returns>The arrows</returns>
        public static T[] GetSourceArrows<T>(this ICategoryObject obj) where T : class
        {
            List<T> l = new List<T>();
            IDesktop d = obj.GetRootDesktop();
            IEnumerable<ICategoryArrow> arr = d.CategoryArrows;
            foreach (ICategoryArrow a in arr)
            {
                ICategoryObject o = a.Source;
                if (o == obj)
                {
                    if (a is T)
                    {
                        l.Add(a as T);
                    }
                }
            }
            return l.ToArray();
        }

        /// <summary>
        /// Gets target arrows of object
        /// </summary>
        /// <typeparam name="T">Arrow type</typeparam>
        /// <param name="obj">The object</param>
        /// <returns>The arrows</returns>
        public static T[] GetTargetArrows<T>(this ICategoryObject obj) where T : class
        {
            List<T> l = new List<T>();
            IDesktop d = obj.GetRootDesktop();
            IEnumerable<ICategoryArrow> arr = d.CategoryArrows;
            foreach (ICategoryArrow a in arr)
            {
                ICategoryObject o = a.Target;
                if (o == obj)
                {
                    if (a is T)
                    {
                        l.Add(a as T);
                    }
                }
            }
            return l.ToArray();
        }

        /// <summary>
        /// Push
        /// </summary>
        /// <param name="collection">collection</param>
        public static void Push(this IComponentCollection collection)
        {
            IEnumerable<object> coll = collection.AllComponents;
            foreach (object o in coll)
            {
                if (o is IStack)
                {
                    IStack stack = o as IStack;
                    stack.Push();
                }
            }
        }

        /// <summary>
        /// Pop
        /// </summary>
        /// <param name="collection">collection</param>
        public static void Pop(this IComponentCollection collection)
        {
            IEnumerable<object> coll = collection.AllComponents;
            foreach (object o in coll)
            {
                if (o is IStack)
                {
                    IStack stack = o as IStack;
                    stack.Pop();
                }
            }
        }

        /// <summary>
        /// Throws exception linked with object
        /// </summary>
        /// <param name="o">The linked object</param>
        /// <param name="message">Exception message</param>
        public static void Throw(this object o, string message)
        {
            o.Throw(new Exception(message));
        }

        /// <summary>
        /// Throws exception linked with object
        /// </summary>
        /// <param name="o">The linked object</param>
        /// <param name="exception">The parent exception</param>
        public static void Throw(this object o, Exception exception)
        {
            if ((exception is DiagramException) | (exception is AssociatedException))
            {
                throw exception;
            }
            if (o == null)
            {
                throw exception;
            }
            if (o is INamedComponent n)
            {
                throw new DiagramException(exception, n);
            }
            if (o is IAssociatedObject)
            {
                IAssociatedObject ass = o as IAssociatedObject;
                object ob = ass.Object;
                if (ob is INamedComponent nc)
                {
                    throw new DiagramException(exception, nc);
                }
            }
            throw exception;
        }

        /// <summary>
        /// Gets object
        /// </summary>
        /// <param name="collection">Collection</param>
        /// <param name="name">Name</param>
        /// <returns>The object</returns>
        public static object GetObject(this IComponentCollection collection, string name)
        {
            IEnumerable<object> c = collection.AllComponents;
            foreach (object o in c)
            {
                string n = GetName(o, collection);
                if (n != null)
                {
                    if (n.Equals(name))
                    {
                        return o;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets object from collection
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="collection">Collection of objects</param>
        /// <param name="name">Full name</param>
        /// <returns>Object if exist and false otherwise</returns>
        public static T GetObject<T>(this IComponentCollection collection, string name) where T : class
        {
            return collection.GetObject(name).GetLabelObject<T>();
        }

        /// <summary>
        /// Gets object
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="o">Object</param>
        /// <returns>The object</returns>
        public static T GetLabelObject<T>(this object o) where T : class
        {
            if (o == null)
            {
                return null;
            }
            T t = null;
            if (o is T)
            {
                t = o as T;
            }
            else if (o is IAssociatedObject)
            {
                t = (o as IAssociatedObject).GetObject<T>();
            }
            else if (o is IObjectLabel)
            {
                IObjectLabel ol = o as IObjectLabel;
                t = ol.Object.GetLabelObject<T>();
            }
            else if (o is IArrowLabel)
            {
                IArrowLabel al = o as IArrowLabel;
                t = al.Arrow.GetLabelObject<T>();
            }
            return t;
        }

        /// <summary>
        /// Gets object
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="collection">Collection</param>
        /// <param name="name">Name</param>
        /// <returns>The object</returns>
        public static T GetCollectionObject<T>(this IComponentCollection collection, string name) where T : class
        {
            return GetLabelObject<T>(GetObject(collection, name));
        }

        /// <summary>
        /// Gets children objects
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="childrenObject"></param>
        /// <returns>Childern</returns>
        public static IEnumerable<T> GetChildren<T>(this IChildrenObject childrenObject) where T : class
        {
            IAssociatedObject[] children = childrenObject.Children;
            foreach (object o in children)
            {
                if (o is T)
                {
                    yield return o as T;
                }
                if (o is IChildrenObject)
                {
                    IEnumerable<T> en = (o as IChildrenObject).GetChildren<T>();
                    foreach (T t in en)
                    {
                        yield return t;
                    }
                }
            }
        }

        /// <summary>
        /// Gets all names of collection
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="collection">The collection</param>
        /// <returns>List of names</returns>
        public static IEnumerable<string> GetAllNames<T>(this IComponentCollection collection) where T : class
        {
            IEnumerable<object> c = collection.AllComponents;
            string n = null;
            foreach (object o in c)
            {
                n = GetName(o, collection);
                if (n == null)
                {
                    continue;
                }
                T t = GetLabelObject<T>(o);
                if (t != null)
                {
                    yield return n;
                }
            }
        }

        /// <summary>
        /// Gets all objects of collection
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="collection">The collection</param>
        /// <returns>Objects</returns>
        public static IEnumerable<T> GetObjectsAndArrows<T>(this IComponentCollection collection) where T : class
        {
            IEnumerable<object> c = collection.AllComponents;
            foreach (object o in c)
            {
                T t = GetLabelObject<T>(o);
                if (t != null)
                {
                    yield return t;
                }
                if (o is IChildrenObject)
                {
                    IEnumerable<T> en = (o as IChildrenObject).GetChildren<T>();
                    foreach (T tt in en)
                    {
                        yield return tt;
                    }
                }
            }
        }


        /// <summary>
        /// Gets all objects of collection
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="collection">The collection</param>
        /// <param name="list">List of objects</param>
        public static void GetAll<T>(this IComponentCollection collection, IList<T> list)
            where T : class
        {
            list.Clear();
            IEnumerable<T> en = collection.GetObjectsAndArrows<T>();
            foreach (T t in en)
            {
                if (!list.Contains(t))
                {
                    list.Add(t);
                }
            }
        }

        /// <summary>
        /// Gets all objects of collection
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="collection">The collection</param>
        /// <returns>List of objects</returns>
        public static List<T> GetAll<T>(this IComponentCollection collection)
            where T : class
        {
            List<T> list = new List<T>();
            collection.GetAll<T>(list);
            return list;
        }

        /// <summary>
        /// Gets absulute name (with respect to root desktop)
        /// </summary>
        /// <param name="obj">Associated object</param>
        /// <returns>Absolute name</returns>
        public static string GetAbsoluteName(this IAssociatedObject obj)
        {
            return obj.GetName(obj.GetRootDesktop());
        }

        /// <summary>
        /// Gets mame of object
        /// </summary>
        /// <param name="o">The object</param>
        /// <param name="collection">The collection</param>
        /// <returns>The name</returns>
        public static string GetName(this object o, IComponentCollection collection)
        {
            INamedComponent nc = null;
            if (o is INamedComponent)
            {
                nc = o as INamedComponent;
            }
            else if (o is IAssociatedObject)
            {
                IAssociatedObject ao = o as IAssociatedObject;
                object ob = ao.Object;
                if (ob is INamedComponent)
                {
                    nc = ob as INamedComponent;
                }
            }
            if (nc == null)
            {
                return null;
            }
            IDesktop d = collection.Desktop;
            if (d == null)
            {
                return null;
            }
            return nc.GetName(d);
        }

        /// <summary>
        /// Gets named component of associated object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>Rhe desktop</returns>
        public static INamedComponent GetComponent(this IAssociatedObject obj)
        {
            INamedComponent nc = null;
            if (obj is INamedComponent)
            {
                nc = obj as INamedComponent;
            }
            else
            {
                object o = obj.Object;
                if (o is INamedComponent)
                {
                    nc = o as INamedComponent;
                }
            }
            return nc;
        }

        /// <summary>
        /// Gets desktop of associated object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>Rhe desktop</returns>
        public static IDesktop GetDesktop(this IAssociatedObject obj)
        {
            INamedComponent nc = GetNamedComponent(obj);
            if (nc == null)
            {
                return null;
            }
            return nc.Desktop;
        }

        /// <summary>
        /// Gets root desktop of associated object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>Rhe desktop</returns>
        public static IDesktop GetRootDesktop(this IAssociatedObject obj)
        {
            IDesktop d = GetDesktop(obj);
            if (d == null)
            {
                return null;
            }
            return d.Root;
        }

        /// <summary>
        /// Gets order of object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>Order</returns>
        public static int GetOdrer(this object obj)
        {
            if (obj is INamedComponent)
            {
                return (obj as INamedComponent).Ord;
            }
            if (obj is IAssociatedObject)
            {
                IAssociatedObject ao = obj as IAssociatedObject;
                object o = ao.Object;
                if (o is INamedComponent)
                {
                    return (o as INamedComponent).Ord;
                }
            }
            return 0;
        }

        /// <summary>
        /// Compares two objects by order
        /// </summary>
        /// <param name="x">First parameter</param>
        /// <param name="y">Second parameter</param>
        /// <returns>
        /// Less than zero - x is less than y. 
        /// Zero -  x equals y
        /// Greater than zero x is greater than y
        ///</returns>
        public static int Compare(object x, object y)
        {
            return x.GetOdrer() - y.GetOdrer();
        }

        /// <summary>
        /// Desktop copy
        /// </summary>
        /// <param name="src">Source</param>
        /// <param name="dst">Target</param>
        public static void Copy(this IDesktop src, IDesktop dst)
        {
            dst.Copy(src.Objects, src.Arrows, true);
        }

        /// <summary>
        /// Gets composition of constructors
        /// </summary>
        /// <param name="types">Types</param>
        /// <param name="ob">Initial object</param>
        /// <returns>Comosition</returns>
        public static object GetConstructorComposition(this Type[] types, object ob = null)
        {
            object o = ob;
            foreach (Type type in types)
            {
                TypeInfo ti = IntrospectionExtensions.GetTypeInfo(type);
                if (o == null)
                {
                    o = ti.GetConstructor(new Type[0]).Invoke(new object[0]);
                    continue;
                }
                o = ti.GetConstructor(new Type[]
                    { typeof(object)}).Invoke(new object[] { o });
            }
            return o;
        }

        /// <summary>
        /// Gets composition of constructors
        /// </summary>
        /// <param name="types"></param>
        /// <returns>Comosition</returns>
        public static object GetConstructorComposition(this string[] types)
        {
            List<Type> l = new List<Type>();
            string str = null;
            foreach (string s in types)
            {
                Type t = Type.GetType(s);
                if (t == null)
                {
                    str = s;
                    continue;
                }
                l.Add(Type.GetType(s));
            }
            return l.ToArray().GetConstructorComposition(str);
        }


        /// <summary>
        /// Gets order of object
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="enumerable">Enumerable</param>
        /// <param name="obj">Object</param>
        /// <returns>Order</returns>
        public static int GetOrder<T>(this IEnumerable<T> enumerable, T obj) where T : class
        {

            int i = 0;
            foreach (T t in enumerable)
            {
                if (t == obj)
                {
                    return i;
                }
                ++i;
            }
            return -1;
        }

        /// <summary>
        /// Converts reader to string enumerable
        /// </summary>
        /// <param name="reader">Reader</param>
        /// <returns>Enumerable of strings</returns>
        static public IEnumerable<string> ToEnumerable(this System.IO.TextReader reader)
        {
            while (true)
            {
                string s = reader.ReadLine();
                if (s == null)
                {
                    break;
                }
                yield return s;
            }
        }

        /// <summary>
        /// Checks whether string is empty
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>False if string is empty</returns>
        static public bool IsEmpty(this string str)
        {
            if (str != null)
            {
                return str.Length == 0;
            }
            return true;
        }

        /// <summary>
        /// Gets objects of aliases
        /// </summary>
        /// <param name="dictionary">Dictionary</param>
        public static void Get(this Dictionary<IAlias, Dictionary<string, object[]>> dictionary)
        {
            foreach (IAlias alias in dictionary.Keys)
            {
                Dictionary<string, object[]> d = dictionary[alias];
                foreach (string key in d.Keys)
                {
                    object[] o = d[key];
                    o[1] = alias[key];
                    alias[key] = o[0];
                }
            }
        }

        /// <summary>
        /// Sets objects of aliases
        /// </summary>
        /// <param name="dictionary">Dictionary</param>
        public static void Set(this Dictionary<IAlias, Dictionary<string, object[]>> dictionary)
        {
            foreach (IAlias alias in dictionary.Keys)
            {
                Dictionary<string, object[]> d = dictionary[alias];
                foreach (string key in d.Keys)
                {
                    alias[key] = d[key][1];
                }
            }
        }

        /// <summary>
        /// Gets all objects related to category theory
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <returns>The objects</returns>
        public static object[] GetAllRelatedObjects(this IDesktop desktop)
        {
            List<object> l = new List<object>();
            IEnumerable<ICategoryObject> co = desktop.CategoryObjects;
            foreach (object o in co)
            {
                l.Add(o);
            }
            IEnumerable<ICategoryArrow> ca = desktop.CategoryArrows;
            foreach (object a in ca)
            {
                l.Add(a);
            }
            return l.ToArray();
        }

        /// <summary>
        /// Gets all objects of defined type
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="desktop">The desktop</param>
        /// <returns>Array of objects</returns>
        public static T[] GetAll<T>(this IDesktop desktop) where T : class
        {
            List<T> l = new List<T>();
            foreach (ICategoryObject obj in desktop.CategoryObjects)
            {
                T t = obj.GetObject<T>();
                if (t != null)
                {
                    l.Add(t);
                }
            }
            foreach (ICategoryArrow arr in desktop.CategoryArrows)
            {
                T t = arr.GetObject<T>();
                if (t != null)
                {
                    l.Add(t);
                }
            }
            return l.ToArray();
        }

        /// <summary>
        /// Adds double to code creator
        /// </summary>
        /// <param name="x">List of double</param>
        /// <param name="lcode">List of code</param>
        public static void ToCodeCreator(this double[][] x, List<string> lcode)
        {
            for (int i = 0; i < x.Length; i++)
            {
                lcode.Add("\t{");
                double[] xx = x[i];
                for (int j = 0; j < xx.Length; j++)
                {
                    string s = j == xx.Length - 1 ? "" :  ",";
                    lcode.Add("\t\t" + xx[j].StringValue() + s);
                }
                string f = i == x.Length - 1 ? "}" : "},";
                lcode.Add(f);
            }
        }

        /// <summary>
        /// Adss dictionary to code creator
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="d">Dictionary</param>
        /// <param name="lcode">Code</param>
        public static void ToCodeCreator<T>(this Dictionary<T, string> d, List<string> lcode)
        {
            int c = d.Count;
            int i = 0;
            foreach (T key in d.Keys)
            {
                string s = "{ " + key.StringValue() + ", \"" + d[key] + "\"}";
                ++i;
                if (i != c)
                {
                    s += ",";
                }
                lcode.Add(s);
            }
        }

        /// <summary>
        /// Adds double to code creator
        /// </summary>
        /// <param name="x">List of double</param>
        /// <param name="lcode">List of code</param>
        public static void ToCodeCreator(this double[,] x, List<string> lcode)
        {
            for (int i = 0; i < x.GetLength(0); i++)
            {
                lcode.Add("\t{");
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    string s = j == x.GetLength(1) - 1 ? "" : ",";
                    lcode.Add("\t\t" + x[i, j].StringValue() + s);
                }
                string f = i == x.GetLength(0) - 1 ? "}" : "},";
                lcode.Add(f);
            }
        }

        /// <summary>
        /// Adds strings to code creator
        /// </summary>
        /// <param name="list">List of strigs</param>
        /// <param name="lcode">List of code</param>
        public static void ToCodeCreator(this IEnumerable<string> list, List<string> lcode)
        {
            bool f = true;
            foreach (string s in list)
            {
                string x = "\"" + s + "\"";
                if (f)
                {
                    f = false;
                }
                else
                {
                    x = ", " + x;
                }
                lcode.Add(x);
            }
        }

        /// <summary>
        /// Adds double to code creator
        /// </summary>
        /// <param name="list">List of double</param>
        /// <param name="lcode">List of code</param>
        public static void ToCodeCreator(this IEnumerable<double> list, List<string> lcode)
        {
            bool first = true;
            foreach (double a in list)
            {
                string s = a.StringValue();
                if (first)
                {
                    first = false;
                }
                else
                {
                    s = ", " + s;
                }
                lcode.Add(s);
            }
        }

        /// <summary>
        /// Adds strings to code creator
        /// </summary>
        /// <param name="list">List of strigs</param>
        /// <param name="lcode">List of code</param>
        public static void ToCodeCreator(this List<string> list, List<string> lcode)
        {
            int n = list.Count;
            for (int i = 0; i < n; i++)
            {
                string s = "\"" + list[i] + "\"";
                if (i < n - 1)
                {
                    s += ",";
                }
                lcode.Add(s);
            }
        }

        #region Dependent

        /// <summary>
        /// Gets dependent objects
        /// </summary>
        /// <param name="obj">Object</param>
        /// <param name="objectCondition">Object condition</param>
        /// <param name="arrowCondition">Arrow condition</param>
        /// <param name="sourceCondition">The "insert source" condition</param>
        /// <returns>List of dependent objects</returns>
        public static List<ICategoryObject> GetDependentObjects(this ICategoryObject obj,
            Func<ICategoryObject, bool> objectCondition, Func<ICategoryArrow, bool>
          arrowCondition, Func<ICategoryArrow, bool> sourceCondition)
        {
            List<ICategoryObject> l = new List<ICategoryObject>();
            obj.GetDependentObjects(objectCondition, arrowCondition, sourceCondition, l);
            return l;
        }

        /// <summary>
        /// Gets dependent objects
        /// </summary>
        /// <param name="obj">Object</param>
        /// <param name="objectCondition">Object condition</param>
        /// <param name="arrowCondition">Arrow condition</param>
        /// <param name="sourceCondition">Source inclide condition</param>
        /// <returns>List of dependent objects</returns>
        public static void GetDependentObjects(this ICategoryObject obj,
            Func<ICategoryObject, bool> objectCondition, Func<ICategoryArrow, bool>
          arrowCondition, Func<ICategoryArrow, bool>
          sourceCondition, List<ICategoryObject> output)
        {
            IDesktop root = obj.GetRootDesktop();
            if (root == null)
            {
                return;
            }
            IEnumerable<ICategoryArrow> arrows = root.CategoryArrows;
            IEnumerable<ICategoryObject> objects = root.CategoryObjects;
            obj.GetDependentObjects(arrows, objectCondition, arrowCondition, sourceCondition, output,
                objects.ToList());
        }



        /// <summary>
        /// Gets dependent objects
        /// </summary>
        /// <param name="obj">Object</param>
        /// <param name="arrows">Arrows</param>
        /// <param name="objectCondition">Object condition</param>
        /// <param name="arrowCondition">Arrow condition</param>
        /// <param name="sourceCondition">The "include source" condition</param>
        /// <returns>List of dependent objects</returns>
        public static List<ICategoryObject> GetDependentObjects(this ICategoryObject obj,
            IEnumerable<ICategoryArrow> arrows,
            Func<ICategoryObject, bool> objectCondition, Func<ICategoryArrow, bool>
          arrowCondition, Func<ICategoryArrow, bool>
          sourceCondition)
        {
            List<ICategoryObject> l = new List<ICategoryObject>();
            obj.GetDependentObjects(arrows, objectCondition, arrowCondition, sourceCondition, l);
            return l;
        }

        /// <summary>
        /// Gets all objects of defined type with defined attribute
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="desktop">The desktop</param>
        /// <param name="attrType">Type of attribute</param>
        /// <returns>Array of objects</returns>
        public static T[] GetAll<T, S>(this IDesktop desktop, Type attrType) where T : class where S : Attribute
        {
            T[] objects = desktop.GetAll<T>();
            List<T> l = new List<T>();
            foreach (T x in objects)
            {
                if (x.HasAttribute<S>())
                {
                    l.Add(x);
                }
            }
            return l.ToArray();
        }

        /// <summary>
        /// Gets intersection of desktop objects
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <param name="types">Types of objects</param>
        /// <returns>The intersection</returns>
        public static object[] GetIntersectObjects(this IDesktop desktop, Type[] types)
        {
            object[] objs = desktop.GetAllRelatedObjects();
            List<object> l = new List<object>();
            foreach (object o in objs)
            {
                foreach (Type t in types)
                {
                    TypeInfo ott = o.ToTypeInfo(); 
                    if (ott.IsSubclassOf(t))
                    {
                        l.Add(o);
                        goto fin;
                    }
                    IEnumerable<Type> inter = ott.ImplementedInterfaces;
                    foreach (Type ti in inter)
                    {
                        if (ti.Equals(t))
                        {
                            l.Add(o);
                            goto fin;
                        }
                    }
                }
            fin:
                continue;
            }
            return l.ToArray();
        }

  
        /// <summary>
        /// Set aliases of desktop
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="document">Document</param>
        public static void SetAliases(this IDesktop desktop, XElement document)
        {
            IEnumerable<XElement> nl = document.GetElementsByTagName("Aliases");
       
            Dictionary<string, string> d = new Dictionary<string, string>();
            foreach (XElement el in nl)
            {
                foreach (XElement e in el.GetChildNodes())
                {
                    d[e.Name.LocalName] = e.Value;
                }
                desktop.SetAliasValue(d["Name"], d["Value"].FromString(d["Type"]));
            }
        }

        /// <summary>
        /// Object from string
        /// </summary>
        /// <param name="str">String</param>
        /// <param name="type">Type</param>
        /// <returns>Object</returns>
        public static object FromString(this string str, object type)
        {
            double a = 0;
            if (type.Equals(a))
            {
                return ParseDouble(str);
            }
            return str;
        }

        /// <summary>
        /// Parses double
        /// </summary>
        /// <param name="str">String value</param>
        /// <returns>Double</returns>
        public static double ParseDouble(this string str)
        {
            return Double.Parse(str, 
                System.Globalization.CultureInfo.InvariantCulture);
        }



        /// <summary>
        /// Gets texts of elements
        /// </summary>
        /// <param name="element">Parent none</param>
        /// <param name="tag">Tag name</param>
        /// <returns>List of texts</returns>
        public static List<string> GetTexts(this XElement element, string tag)
        {
            List<string> l = new List<string>();
            IEnumerable<XElement> list = element.GetElementsByTagName(tag);
            foreach (XElement node in list)
            {
                l.Add(node.Value);
            }
            return l;
        }

        /// <summary>
        /// Sets texts to childen elements
        /// </summary>
        /// <param name="doc">Parent document</param>
        /// <param name="element">Parent element</param>
        /// <param name="tag">Tag name</param>
        /// <param name="list">List</param>
        public static void SetTexts(this XElement element, string tag, List<string> list)
        {
            foreach (string s in list)
            {
                XElement e = element.CreateXElement(tag);
                e.Value = s;
            }
        }


        /// <summary>
        /// Gets url
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Url</returns>
        public static string GetUrl(this IAssociatedObject obj)
        {
            List<IAssociatedObject> l = new List<IAssociatedObject>();
            return obj.GetUrl(l);
        }


        #endregion
  
        #region Source

        /// <summary>
        /// Gets source objects
        /// </summary>
        /// <param name="obj">Object</param>
        /// <param name="objectCondition">Object condition</param>
        /// <param name="arrowCondition">Arrow condition</param>
        /// <param name="sourceCondition">The "insert source" condition</param>
        /// <returns>List of dependent objects</returns>
        public static List<ICategoryObject> GetSourceObjects(this ICategoryObject obj,
            Func<ICategoryObject, bool> objectCondition, Func<ICategoryArrow, bool>
          arrowCondition, Func<ICategoryArrow, bool> sourceCondition)
        {
            List<ICategoryObject> l = new List<ICategoryObject>();
            obj.GetSourceObjects(objectCondition, arrowCondition, sourceCondition, l);
            return l;
        }

        /// <summary>
        /// Gets source objects
        /// </summary>
        /// <param name="obj">Object</param>
        /// <param name="objectCondition">Object condition</param>
        /// <param name="arrowCondition">Arrow condition</param>
        /// <param name="sourceCondition">Source inclide condition</param>
        /// <returns>List of dependent objects</returns>
        public static void GetSourceObjects(this ICategoryObject obj,
            Func<ICategoryObject, bool> objectCondition, Func<ICategoryArrow, bool>
          arrowCondition, Func<ICategoryArrow, bool>
          sourceCondition, List<ICategoryObject> output)
        {
            IDesktop root = obj.GetRootDesktop();
            if (root == null)
            {
                return;
            }
            IEnumerable<ICategoryArrow> arrows = root.GetObjectsAndArrows<ICategoryArrow>();
            IEnumerable<ICategoryObject> objects = root.GetObjectsAndArrows<ICategoryObject>();
            obj.GetSourceObjects(arrows, objectCondition, arrowCondition, sourceCondition, output,
                objects.ToList<ICategoryObject>());
        }

        /// <summary>
        /// Gets source objects
        /// </summary>
        /// <param name="obj">Object</param>
        /// <param name="arrows">Arrows</param>
        /// <param name="objectCondition">Object condition</param>
        /// <param name="arrowCondition">Arrow condition</param>
        /// <param name="sourceCondition">The "include source" condition</param>
        /// <returns>List of dependent objects</returns>
        public static List<ICategoryObject> GetSourceObjects(this ICategoryObject obj,
            IEnumerable<ICategoryArrow> arrows,
            Func<ICategoryObject, bool> objectCondition, Func<ICategoryArrow, bool>
          arrowCondition, Func<ICategoryArrow, bool>
          sourceCondition)
        {
            List<ICategoryObject> l = new List<ICategoryObject>();
            obj.GetSourceObjects(arrows, objectCondition, arrowCondition, sourceCondition, l);
            return l;
        }

        #endregion

        #region Decompose

        /// <summary>
        /// Decomposes collection
        /// </summary>
        /// <param name="collection">The collection</param>
        /// <param name="dictionary">The dictionary of objects</param>
        /// <returns>List of connected components</returns>
        public static List<IComponentCollection> Decompose(this IComponentCollection collection,
            Dictionary<object, IComponentCollection> dictionary)
        {
            Action<object, IComponentCollection> action = (object o, IComponentCollection cc) =>
                {
                    if (o is IObjectLabel)
                    {
                        dictionary[(o as IObjectLabel).Object] = cc;
                    }
                    else if (o is IArrowLabel)
                    {
                        dictionary[(o as IArrowLabel).Arrow] = cc;
                    }
                };
            return collection.Decompose(action);
        }

        /// <summary>
        /// Decomposes collection
        /// </summary>
        /// <param name="collection">The collection</param>
        /// <param name="action">Action</param>
        /// <returns>List of connected components</returns>
        public static List<IComponentCollection> Decompose(this IComponentCollection collection,
           Action<object, IComponentCollection> action = null)
        {
            List<IComponentCollection> list = new List<IComponentCollection>();
            List<List<object>> li = collection.GetConnectedList();
            IDesktop d = collection.Desktop;
            if (li.Count == 1)
            {
                list.Add(collection);
                if (action != null)
                {
                    foreach (List<object> l in li)
                    {
                        foreach (object o in l)
                        {
                            action(o, d);
                        }
                    }
                }
                return list;
            }
            foreach (List<object> l in li)
            {
                ComponentCollection cc = new ComponentCollection(l, d);
                list.Add(cc);
                if (action != null)
                {
                    foreach (object o in l)
                    {
                        action(o, cc);
                    }
                }
            }
            return list;
        }

        #endregion

        #endregion

        #region Public XML Members

        /// <summary>
        /// Gets elements by tag name
        /// </summary>
        /// <param name="element">Element</param>
        /// <param name="tag">Tag</param>
        /// <returns>Elements</returns>
        public static IEnumerable<XElement> GetElementsByTagName(this XElement element, string tag)
        {
            return element.Elements(XName.Get(tag));
        }



        /// <summary>
        /// Gets First element by tag name
        /// </summary>
        /// <param name="element">Element</param>
        /// <param name="tag">Tag</param>
        /// <returns>The first element</returns>
        public static XElement GetFirst(this XElement element, string tag)
        {
            IEnumerable<XElement> c = element.GetElementsByTagName(tag);
            foreach (XElement e in c)
            {
                return e;
            }
            return null;
        }


    /// <summary>
    /// Gets attribute
    /// </summary>
    /// <param name="element">Element</param>
    /// <param name="name">Name</param>
    /// <returns>Attribute</returns>
    public static string GetAttribute(this System.Xml.Linq.XElement element, string name)
        {
            return element.Attribute(System.Xml.Linq.XName.Get(name)).Value;
        }

        /// <summary>
        /// Creates XElement
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns>The element</returns>
        public static XElement CreateXElement(string tag)
        {
            return XElement.Parse("<" + tag + "/>");
        }

        /// <summary>
        /// Creates XElement
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <param name="obj">The object</param>
        /// <returns>The element</returns>
        public static XElement CreateXElement(this object obj, string tag)
        {
            XElement e = CreateXElement(tag);
            if (obj is XElement)
            {
                (obj as XElement).Add(e);
            }
            return e;
        }

        /// <summary>
        /// Gets child nodes
        /// </summary>
        /// <param name="element">Element</param>
        /// <returns>Child nodes</returns>
        public static IEnumerable<XElement> GetChildNodes(this XElement element)
        {
            IEnumerable<XElement> c = element.Elements();
            return c;
        }

        #endregion

        #region Private and Internal members

        private static IObjectContainer ParentContainer(INamedComponent nc)
        {
            IDesktop d = nc.Desktop;
            if (!(d is PureDesktop))
            {
                return null;
            }
            PureDesktop pd = d as PureDesktop;
            return pd.internalParent;
        }


        private static int GetOrder(INamedComponent nc, IDesktop desktop)
        {
            if (nc.Desktop == desktop)
            {
                return nc.Ord;
            }
            IObjectContainer oc = ParentContainer(nc);
            IAssociatedObject ao = oc as IAssociatedObject;
            INamedComponent comp = ao.Object as INamedComponent;
            return GetOrder(comp, desktop);
        }


        private static string GetUrl(this IAssociatedObject obj, List<IAssociatedObject> l)
        {
            if (obj == null)
            {
                return null;
            }
            if (l.Contains(obj))
            {
                return null;
            }
            l.Add(obj);
            Diagram.UI.Attributes.UrlAttribute attr = obj.GetAttribute<Diagram.UI.Attributes.UrlAttribute>();
            if (attr != null)
            {
                return attr.Url;
            }
             if (obj is IChildrenObject)
            {
                IAssociatedObject[] ch = (obj as IChildrenObject).Children;
                if (ch != null)
                {
                    foreach (IAssociatedObject aa in ch)
                    {
                        string s = GetUrl(aa, l);
                        if (s != null)
                        {
                            return s;
                        }
                    }
                }
            }
            object ob = obj.Object;
            if (ob is IObjectLabel)
            {
                IAssociatedObject aob = (ob as IObjectLabel).Object;
                if (!l.Contains(aob))
                {
                    return GetUrl(aob, l);
                }
            }
            return null;
        }

        /// <summary>
        /// Prepares collection
        /// </summary>
        /// <param name="collection">The collection</param>
        /// <param name="find">Find sign</param>
        static public void Prepare(this IComponentCollection collection, bool find = false)
        {
            collection.ForEach((IPreparation preparation) => { preparation.Prepare(); }, find);
        }


        /// <summary>
        /// Prepares an object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <param name="find">Find sign</param>
        static public void Prepare(this IAssociatedObject obj, bool find = false)
        {
            if (obj is IPreparation)
            {
                (obj as IPreparation).Prepare();
            }
            if (find)
            {
                IPreparation p = obj.Find<IPreparation>();
                if (p != null)
                {
                    p.Prepare();
                }
            }
        }

        /// <summary>
        /// Executes action
        /// </summary>
        /// <typeparam name="T">Type of variable</typeparam>
        /// <param name="obj">object</param>
        /// <param name="action">Action</param>
        /// <param name="find">Find sign</param>
        private static void Execute<T>(this object obj, Action<T> action, bool find) where T : class
        {
            if (obj == null)
            {
                return;
            }
            if (obj is T t)
            {
                action(t);
                return;
            }
            if (find)
            {
                if (obj is IAssociatedObject ao)
                {
                    T ta = ao.Find<T>();
                    if (ta != null)
                    {
                        action(ta);
                    }
                }
            }
        }

        private static void AddChildren(IChildrenObject co, List<object> l)
        {
            IAssociatedObject[] ao = co.Children;
            if (ao != null)
            {
                foreach (IAssociatedObject aa in ao)
                {
                    if (aa != null)
                    {
                        if (!l.Contains(aa))
                        {
                            l.Add(aa);
                        }
                    }
                    if (aa is IChildrenObject)
                    {
                        AddChildren(aa as IChildrenObject, l);
                    }
                }
            }
        }

        private static List<List<object>> GetConnectedList(this IComponentCollection collection)
        {
            List<List<object>> list = new List<List<object>>();
            Action<ICategoryObject> act = (ICategoryObject obj) =>
            {
                List<object> l = new List<object>();
                if (obj is IObjectContainer)
                {
                    IObjectContainer oc = obj as IObjectContainer;
                    oc.ForEach((object obb) =>
                    {
                        if (!(obb is IObjectContainer))
                        {
                            if (!l.Contains(obb))
                            {
                                l.Add(obb);
                            }
                        }
                    });
                    return;
                }
                if (!l.Contains(obj))
                {
                    l.Add(obj);
                }
                list.Add(l);
                if (obj is IChildrenObject)
                {
                    AddChildren(obj as IChildrenObject, l);
                }
            };
            IEnumerable<object> en = collection.AllComponents;
            foreach (object ob in en)
            {
                if (ob is IObjectLabel)
                {
                    act((ob as IObjectLabel).Object);
                }
            }
            Action<ICategoryArrow> arrowAction = (ICategoryArrow arrow) =>
                {
                    List<List<object>> ll = new List<List<object>>(list);
                    foreach (List<object> l in ll)
                    {
                        object s = arrow.Source;
                        object t = arrow.Target;
                        if (l.Contains(s))
                        {
                            l.Add(arrow);
                            if (!l.Contains(t))
                            {
                                List<List<object>> lll = new List<List<object>>(list);
                                foreach (List<object> lm in lll)
                                {
                                    if (lm.Contains(t))
                                    {
                                        l.AddRange(lm);
                                        list.Remove(lm);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                };
            collection.ForEach(arrowAction);
            List<List<object>> llist = new List<List<object>>();
            foreach (List<object> l in list)
            {
                List<object> ll = new List<object>();
                llist.Add(ll);
                foreach (object o in l)
                {
                    ll.Add((o as IAssociatedObject).Object);
                }
            }
            return llist;
        }

        /// <summary>
        /// Gets names of typed objects 
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="desktop">The desktop</param>
        /// <returns>Array of names</returns>
        static public string[] GetNames<T>(this IDesktop desktop) where T : class
        {
            T[] t = GetAll<T>(desktop);
            List<string> l = new List<string>();
            foreach (T obj in t)
            {
                IAssociatedObject ao = obj as IAssociatedObject;
                INamedComponent nc = ao.Object as INamedComponent;
                string n = nc.GetName(desktop);
                if (l.Contains(n))
                {
                    throw new Exception("Name " + n + " alerady exists");
                }
                l.Add(n);
            }
            return l.ToArray();
        }

    /*!!!    /// <summary>
        /// Gets all children
        /// </summary>
        /// <param name="childrenObject"></param>
        /// <returns></returns>
        public static IEnumerable<IAssociatedObject> GetAllChildren(this IChildrenObject childrenObject)
        {
            IAssociatedObject[] children = childrenObject.Children;
            foreach (IAssociatedObject child in children)
            {
                yield return child;
                if (child is IChildrenObject)
                {
                    IEnumerable<IAssociatedObject> en = (child as IChildrenObject).GetAllChildren();
                    foreach (IAssociatedObject ao in en)
                    {
                        yield return ao;
                    }
                }
            }
        }
        */
           



        #region Dependent

        private static void GetDependentObjects(this ICategoryObject obj, IEnumerable<ICategoryArrow> arrows,
           Func<ICategoryObject, bool> objectCondition, Func<ICategoryArrow, bool>
         arrowCondition, Func<ICategoryArrow, bool> sourceCondition, List<ICategoryObject> dependent)
        {
            foreach (var a in arrows)
            {
                if (!arrowCondition(a))
                {
                    continue;
                }
                var s = a.Source;
                var t = a.Target;
                if ((s != obj) & (t != obj))
                {
                    continue;
                }
                if (t == obj)
                {
                    if (sourceCondition != null)
                    {
                        if (sourceCondition(a))
                        {
                            if (objectCondition(s))
                            {
                                if (!dependent.Contains(s))
                                {
                                    dependent.Add(s);
                                    if (s is IChildrenObject cobj)
                                    {
                                        IEnumerable<ICategoryObject> en = 
                                            cobj.GetChildren<ICategoryObject>();
                                        foreach (ICategoryObject co in en)
                                        {
                                            if (!dependent.Contains(co))
                                            {
                                                if (objectCondition(co))
                                                {
                                                    dependent.Add(co);
                                                }
                                            }
                                        }
                                    }
                                    s.GetDependentObjects(arrows,
                                        objectCondition, arrowCondition, sourceCondition, dependent);
                                }
                            }
                        }
                    }
                    continue;
                }
                if (t == null)
                {
                    throw new Exception();
                }
                if (!objectCondition(t))
                {
                    continue;
                }
                if (dependent.Contains(t))
                {
                    continue;
                }
                dependent.Add(t);
                if (t is IChildrenObject cob)
                {
                    IEnumerable<ICategoryObject> en = cob.GetChildren<ICategoryObject>();
                    foreach (ICategoryObject co in en)
                    {
                        if (!dependent.Contains(co))
                        {
                            if (objectCondition(co))
                            {
                                dependent.Add(co);
                            }
                        }
                    }
                }
                t.GetDependentObjects(arrows, objectCondition, arrowCondition, sourceCondition, dependent);
            }
        }

        private static void GetDependent(this ICategoryObject obj, Dictionary<ICategoryObject, List<ICategoryObject>> dictionary,
            List<ICategoryObject> output)
        {
            if (output.Contains(obj))
            {
                return;
            }
            output.Add(obj);
            if (!dictionary.ContainsKey(obj))
            {
                return;
            }
            List<ICategoryObject> l = dictionary[obj];
            foreach (ICategoryObject co in l)
            {
                co.GetDependent(dictionary, output);
            }
        }

        private static void GetDependentObjects(this ICategoryObject obj,
            IEnumerable<ICategoryArrow> arrows,
            Func<ICategoryObject, bool> objectCondition, Func<ICategoryArrow, bool>
          arrowCondition, Func<ICategoryArrow, bool> sourceCondition, List<ICategoryObject> dependent,
            List<ICategoryObject> all)
        {
            obj.GetDependentObjects(arrows, objectCondition, arrowCondition, sourceCondition, dependent);
            foreach (ICategoryObject co in all)
            {
                if (dependent.Contains(co) & !(co is IChildrenObject))
                {
                    continue;
                }
                if (co is IChildrenObject ch)
                {
                    IEnumerable<IAssociatedObject> ao = ch.GetChildren<IAssociatedObject>();
                    if (ao != null)
                    {
                        foreach (object c in ao)
                        {
                            if (c is ICategoryObject)
                            {
                                ICategoryObject ca = c as ICategoryObject;
                                if (dependent.Contains(ca))
                                {
                                    if (objectCondition(co))
                                    {
                                        if (!dependent.Contains(co))
                                        {
                                            dependent.Add(co);
                                            co.GetDependentObjects(arrows, objectCondition,
                                                arrowCondition, sourceCondition, dependent, all);
                                        }
                                        goto m;
                                    }
                                }
                            }
                        }
                        continue;

                    m:
                        foreach (object c in ao)
                        {

                            if (c is ICategoryObject ca)
                            {
                                if (!dependent.Contains(ca))
                                {
                                    dependent.Add(ca);
                                    ca.GetDependentObjects(arrows, objectCondition,
                                        arrowCondition, sourceCondition, dependent, all);
                                }
                            }
                        }
                    }
                }
           }
        }

   
        #endregion

        #region Source

        private static void GetSourceObjects(this ICategoryObject obj, IEnumerable<ICategoryArrow> arrows,
           Func<ICategoryObject, bool> objectCondition, Func<ICategoryArrow, bool>
         arrowCondition, Func<ICategoryArrow, bool> sourceCondition, List<ICategoryObject> source)
        {
            foreach (ICategoryArrow a in arrows)
            {
                if (!arrowCondition(a))
                {
                    continue;
                }
                ICategoryObject tt = a.Target;
                bool b = tt == obj;
                if (!b)
                {
                    object ob = tt.Object;
                    if (ob is IObjectLabel)
                    {
                        IObjectLabel olb = ob as IObjectLabel;
                        ICategoryObject co = olb.Object;
                        if (co is IChildrenObject)
                        {
                            IChildrenObject cco = co as IChildrenObject;
                            IAssociatedObject[] aao = cco.Children;
                            if (aao != null)
                            {
                                foreach (object oob in aao)
                                {
                                    if (oob == obj)
                                    {
                                        b = true;
                                        if (!source.Contains(a.Source))
                                        {
                                            source.Add(a.Source);
                                        }
                                        foreach (object ooob in aao)
                                        {
                                            if (!source.Contains(ooob))
                                            {
                                                source.Add(ooob as ICategoryObject);
                                            }
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                if (!b)
                {
                    continue;
                }
                if (sourceCondition != null)
                {
                    if (sourceCondition(a))
                    {
                        ICategoryObject s = a.Source;
                        if (objectCondition(s))
                        {
                            if (!source.Contains(s))
                            {
                                source.Add(s);
                                s.GetSourceObjects(arrows,
                                    objectCondition, arrowCondition, sourceCondition, source);
                            }
                        }
                    }
                }
                continue;
                /* !!! TEMP OLD
                ICategoryObject t = a.Source;
                if (!objectCondition(t))
                {
                    continue;
                }
                if (source.Contains(t))
                {
                    continue;
                }
                source.Add(t);
                t.GetSourceObjects(arrows, objectCondition, arrowCondition, sourceCondition, source);
                */
            }
        }

        private static void GetSource(this ICategoryObject obj, Dictionary<ICategoryObject, List<ICategoryObject>> dictionary,
            List<ICategoryObject> output)
        {
            if (output.Contains(obj))
            {
                return;
            }
            output.Add(obj);
            if (!dictionary.ContainsKey(obj))
            {
                return;
            }
            List<ICategoryObject> l = dictionary[obj];
            foreach (ICategoryObject co in l)
            {
                co.GetSource(dictionary, output);
            }
        }


        private static void GetSourceObjects(this ICategoryObject obj,
            IEnumerable<ICategoryArrow> arrows,
            Func<ICategoryObject, bool> objectCondition, Func<ICategoryArrow, bool>
          arrowCondition, Func<ICategoryArrow, bool> sourceCondition, List<ICategoryObject> source,
            List<ICategoryObject> all)
        {
            obj.GetSourceObjects(arrows, objectCondition, arrowCondition, sourceCondition, source);
            foreach (ICategoryObject co in all)
            {
                if (source.Contains(co))
                {
                    continue;
                }
                if (!(co is IChildrenObject))
                {
                    continue;
                }
                IChildrenObject ch = co as IChildrenObject;
                IAssociatedObject[] ao = ch.Children;
                if (ao != null)
                {
                    foreach (object c in ao)
                    {

                        if (c is ICategoryObject)
                        {
                            ICategoryObject ca = c as ICategoryObject;
                            if (source.Contains(ca))
                            {
                                if (objectCondition(co))
                                {
                                    source.Add(co);
                                    co.GetSourceObjects(arrows, objectCondition,
                                        arrowCondition, sourceCondition, source, all);
                                    goto m;
                                }
                            }
                        }
                    }
                    continue;
                m:
                    foreach (object c in ao)
                    {

                        if (c is ICategoryObject)
                        {
                            ICategoryObject ca = c as ICategoryObject;
                            if (!source.Contains(ca))
                            {
                                source.Add(ca);
                                ca.GetSourceObjects(arrows, objectCondition,
                                    arrowCondition, sourceCondition, source, all);
                            }
                        }
                    }
                }
            }
        }

        #endregion


        /// <summary>
        /// Disposes associated object
        /// </summary>
        /// <param name="obj">Object to dispose</param>
        static internal void DisposeAssociatedObject(object obj)
        {
            if (obj is IAssociatedObject ob)
            {
                if (ob is IDisposable d)
                {
                    d.Dispose();
                    return;
                }
            }
            obj.RemoveObject();
        }


        private static IErrorHandler GetErrorHandler(object o, out object add)
        {
            add = null;
            if (o == null)
            {
                return null;
            }
            if (o is object[])
            {
                object[] ob = o as object[];
                if (ob.Length >= 1)
                {
                    object of = ob[0];
                    if (of is IErrorHandler)
                    {
                        if (ob.Length == 2)
                        {
                            add = ob[1];
                        }
                        return of as IErrorHandler;
                    }
                }
            }
            return null;
        }

        private static string ArrowNumToString(this object obj)
        {
            if (obj is object[])
            {
                object[] o = obj as object[];
                string[] s = new string[2];
                for (int i = 0; i < 2; i++)
                {
                    object ob = o[i];
                    if (ob is string)
                    {
                        s[i] = "\"" + ob + "\"";
                    }
                    else
                    {
                        s[i] = "(int)" + ob;
                    }
                }
                return "new object[] {" + s[0] + "," + s[1] + " }";
            }
            return "(int)" + obj;
        }

        /// <summary>
        /// Gets object or arrow
        /// </summary>
        /// <param name="obj">Prototype</param>
        /// <returns>Object or arrow</returns>
        private static object GetObject(IAssociatedObject obj)
        {
            if (!(obj is INamedComponent))
            {
                return obj;
            }
            INamedComponent nc = obj as INamedComponent;
            if (nc is IObjectLabel)
            {
                IObjectLabel l = nc as IObjectLabel;
                return l.Object;
            }
            if (nc is IArrowLabel)
            {
                IArrowLabel l = nc as IArrowLabel;
                return l.Arrow;
            }
            return null;
        }

        #endregion

        #region Object Comparer Class

        class ObjectComparerClassT<T> : IComparer<T>
        {
            #region IComparer<T> Members

            int IComparer<T>.Compare(T x, T y)
            {
                return StaticExtensionDiagramUI.Compare(x, y);
            }

            #endregion
        }

        class ObjectComparerClass : IComparer<object>
        {
            #region IComparer<object> Members

            int IComparer<object>.Compare(object x, object y)
            {
                return StaticExtensionDiagramUI.Compare(x, y);
            }

            #endregion
        }


        #endregion
    }
}
