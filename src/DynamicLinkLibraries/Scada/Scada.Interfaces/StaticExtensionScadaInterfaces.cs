using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

using Scada.Interfaces.Services;


namespace Scada.Interfaces
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionScadaInterfaces
    {

        #region Fields

        const string Name = "Name";

        const string Value = "Value";

        const string Inputs = "Inputs";
       
        const string Outputs = "Outputs";

        const string Events = "Events";
  
        const string Item = "Item";

        const string Objects = "Objects";


        /// <summary>
        /// Dictionary of types
        /// </summary>
        static public readonly Dictionary<Type, object> TypeDictionary =
           new Dictionary<Type, object>()
           {
               { typeof(double), (double)0 },
               { typeof(float),  (float)0 },
               { typeof(sbyte),  (sbyte)0 },
               { typeof(byte),  (byte)0 },
               { typeof(short),  (short)0 },
               { typeof(ushort),  (ushort)0 },
               { typeof(int),  (int)0 },
               { typeof(uint), (uint)0 },
               { typeof(long),  (long)0 },
               { typeof(ulong),  (ulong)0 },
               { typeof(bool),  false },
              { typeof(string), "" },
           };


        /// <summary>
        /// Detector of type
        /// </summary>
        static Dictionary<string, Type> typeDetector = new Dictionary<string, Type>();

        static private event Action<IScadaInterface> onScadaIsEnabled;

 
        #endregion

        #region Public Members

        #region Pure XML Members

        /// <summary>
        /// Gets elements by tag name
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="tagName">The tag name</param>
        /// <returns>The list</returns>
        public static List<XElement> GetElementsByTagName(this XElement element, string tagName)
        {
            IEnumerable<XElement> enu = element.Elements();
            List<XElement> list = new List<XElement>();
            foreach (XElement e in enu)
            {
                if (e.Name.ToString().Equals(tagName))
                {
                    list.Add(e);
                }
            }
            return list;
        }

        /// <summary>
        /// Adds items
        /// </summary>
        /// <param name="document">Document</param>
        /// <param name="tagName">Name of tag</param>
        /// <param name="items">Items</param>
        public static void AddItems(this XElement document, string tagName, IEnumerable<string> items)
        {
            XElement e = XElement.Parse("<" + tagName + "/>");
            document.Add(e);
            foreach (string item in items)
            {
                XElement el = XElement.Parse("<" + Item + "/>");
                el.Add(item);
                e.Add(el);
            }
        }

        /// <summary>
        /// Gets item list
        /// </summary>
        /// <param name="document">Document</param>
        /// <param name="tagName">Name of tag</param>
        /// <returns>Item list</returns>
        public static List<string> GetItems(this XElement document, string tagName)
        {
            List<string> l = new List<string>();
            List<XElement> nl = document.GetElementsByTagName(tagName);
            if (nl.Count == 0)
            {
                return l;
            }
            List<XElement> list = nl[0].GetElementsByTagName(Item);
            foreach (XElement e in list)
            {
                l.Add(e.InnerText());
            }
            return l;
        }

        /// <summary>
        /// Inner text of an element
        /// </summary>
        /// <param name="element">The element</param>
        /// <returns>The innner text</returns>
        public static string InnerText(this XElement element)
        {
            string s = element.ToString();
            int n = s.IndexOf('>') + 1;
            s = s.Substring(n);
            n = s.LastIndexOf('<');
            s = s.Substring(0, n);
            return s;
        }

        /// <summary>
        /// Sets name value
        /// </summary>
        /// <param name="element">Element</param>
        /// <param name="name">Name</param>
        /// <param name="value">Value</param>
        public static void SetNameValue(this XElement element, string name, string value)
        {
            XElement n = XElement.Parse("<" + Name + "/>");
            n.Add(name);
            element.Add(n);
            XElement v = XElement.Parse("<" + Value + "/>");
            v.Add(value);
            element.Add(v);
        }

        /// <summary>
        /// Gets name value
        /// </summary>
        /// <param name="element">Element</param>
        /// <param name="name">Name</param>
        /// <param name="value">Value</param>
        public static void GetNameValue(this XElement element, out string name, out string value)
        {
            name = element.GetElementsByTagName(Name)[0].InnerText();
            value = element.GetElementsByTagName(Value)[0].InnerText();
        }

        #endregion

        /// <summary>
        /// The change of enable status
        /// </summary>
        /// <param name="scada"></param>
        static public void EnableChange(this IScadaInterface scada)
        {
            onScadaIsEnabled?.Invoke(scada);
        }

        /// <summary>
        /// The scada enabled event
        /// </summary>
        static public event Action<IScadaInterface> OnScadaIsEnabled
        {
            add { onScadaIsEnabled += value; }
            remove { onScadaIsEnabled -= value; }
        }


        /// <summary>
        /// Input ouptut action
        /// </summary>
        /// <param name="input">Input</param>
        /// <param name="output">Output</param>
        /// <param name="compare">The "Compare" string</param>
        /// <returns>The action</returns>
        static public Action InputToOutput(this Func<object> input, Action<object> output,
            bool compare = true)
        {
            var io = new InputOutputLink(input, output);
            if (compare)
            {
                return io.UpdateCompare;
            }
            return io.Update;
        }

        /// <summary>
        /// Input ouptut action
        /// </summary>
        /// <param name="input">Input</param>
        /// <param name="output">Output</param>
        /// <param name="compare">The "Compare" string</param>
        /// <returns>The action</returns>
        static public Action InputToOutput(this Tuple<IScadaInterface, string> input,
            Tuple<IScadaInterface, string> output,
            bool compare = true)
        {
            var inp = input.Item1.GetOutput(input.Item2);
            var ou = output.Item1.GetInput(output.Item2);
            return inp.InputToOutput(ou, compare);
        }




        /// <summary>
        /// Adds event output
        /// </summary>
        /// <param name="scada">Scada</param>
        /// <param name="eventName">Name of event</param>
        /// <param name="outputName">Name of output</param>
        static public void AddEventOutput(this IScadaInterface scada, string eventName, string outputName)
        {
            if (!(scada is IEventOutput))
            {
                return;
            }
            Dictionary<string, List<string>> d = (scada as IEventOutput).EventOutput;
            List<string> l = null;
            if (d.ContainsKey(eventName))
            {
                l = d[eventName];
            }
            else
            {
                l = new List<string>();
                d[eventName] = l;
            }
            if (!l.Contains(outputName))
            {
                l.Add(outputName);
            }
        }

        /// <summary>
        /// Adds detector
        /// </summary>
        /// <param name="detector"></param>
        static public void Add(this Dictionary<string, Type> detector)
        {
            foreach (string key in detector.Keys)
            {
                typeDetector[key] = detector[key];
            }
        }

        /// <summary>
        /// Creates XML document from SCADA
        /// </summary>
        /// <param name="scada">The SCADA</param>
        /// <returns>The document</returns>
        public static XElement CreateXML(this IScadaInterface scada)
        {
            XElement x = XElement.Parse("<Scada/>");
            Dictionary<string, object>[] d = new Dictionary<string, object>[]
            {
                scada.Inputs, scada.Outputs
            };
            string[] ss = new string[] { Inputs, Outputs };
            for (int i = 0; i < 2; i++)
            {
                XElement inout =XElement.Parse("<" + ss[i] + "/>");
                x.Add(inout);
                Dictionary<string, object> inouts = d[i];
                foreach (string key in inouts.Keys)
                {
                    XElement e = XElement.Parse("<" + Item + "/>");
                    inout.Add(e);
                    Type t = inouts[key].ToType();
                    e.SetNameValue(key, t.AssemblyQualifiedName);
                }
            }
            x.AddItems(Events, scada.Events);
            XElement objs = XElement.Parse("<" + Objects + "/>");
            x.Add(objs);
            Dictionary<string, List<string>> dob = scada.Objects;
            foreach (string key in dob.Keys)
            {
                XElement xob = XElement.Parse("<Object/>");
                xob.AddItems("Name", new string[] { key });
                objs.Add(xob);
                xob.AddItems(Item, dob[key]);
            }
            return x;
        }

        /// <summary>
        /// Saves SCADA to file
        /// </summary>
        /// <param name="scada">The SCADA</param>
        /// <param name="filename">The filename</param>
        public static void SaveAsXml(this IScadaInterface scada, string filename)
        {
            /*
            XmlDocument doc = scada.CreateXML();
            doc.Save(filename);
            */
        }

        /// <summary>
        /// List of real SCADA parameters
        /// </summary>
        /// <param name="scada">The SCADA</param>
        /// <param name="isInput">True in case of input parameter</param>
        /// <returns>List of real parameters</returns>
        public static List<string> GetRealList(this IScadaInterface scada, bool isInput)
        {
            Dictionary<string, object> d = (isInput) ? scada.Inputs : scada.Outputs;
            List<string> l = new List<string>();
            foreach (string key in d.Keys)
            {
                Type t = d[key].DetectType();
                if (t == null)
                {
                    continue;
                }
                if (t.Equals(typeof(float)) | t.Equals(typeof(double)))
                {
                    l.Add(key);
                }
            }
            return l;
        }
    
        /// <summary>
        /// Gets list of types
        /// </summary>
        /// <param name="scada">Scada</param>
        /// <param name="type">Type</param>
        /// <param name="isInput">The "is input" list</param>
        /// <returns></returns>
        public static List<string> GetTypeList(this IScadaInterface scada, 
            Type type, bool isInput = false)
        {
            Dictionary<string, object> d = (isInput) ? scada.Inputs : scada.Outputs;
            List<string> l = new List<string>();
            foreach (string key in d.Keys)
            {
                Type t = d[key].DetectType();
                if (t == null)
                {
                    continue;
                }
                if (t.Equals(type))
                {
                    l.Add(key);
                }
            }
            return l;
        }

        /// <summary>
        /// Gets object list
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="scada">Scada</param>
        /// <returns>The list</returns>
        public static List<string> GetObjectList<T>(this IScadaInterface scada) where T : class
        {
            Type type = typeof(T);
            TypeInfo typeInfo = IntrospectionExtensions.GetTypeInfo(type);
            bool isInterface = typeInfo.IsInterface;
            List<string> l = new List<string>();
            Dictionary<string, List<string>> d = scada.Objects;
            foreach (string name in d.Keys)
            {
                List<string> lt = d[name];
                foreach (string t in lt)
                {
                    Type ty = t.DetectType();
                    TypeInfo ti = IntrospectionExtensions.GetTypeInfo(ty);
                    if (isInterface)
                    {
                        if (ti.ImplementedInterfaces.Contains(type))
                        {
                            l.Add(name);
                            continue;
                        }
                    }
                    if (type.Compare(ty))
                    {
                        l.Add(name);
                    }
                }
            }
            return l;
        }

        /// <summary>
        /// List of real SCADA parameters
        /// </summary>
        /// <param name="scada">The SCADA</param>
        /// <param name="isInput">True in case of input parameter</param>
        /// <returns>List of real parameters</returns>
        public static List<string> GetDataList(this IScadaInterface scada, bool isInput)
        {
            Dictionary<string, object> d = (isInput) ? scada.Inputs : scada.Outputs;
            List<string> l = new List<string>();
            foreach (string key in d.Keys)
            {
                l.Add(key);
            }
            return l;
        }

        /// <summary>
        /// Gets float output function
        /// </summary>
        /// <param name="scada">The SCADA</param>
        /// <param name="name">Function name</param>
        /// <returns>The function</returns>
        public static Func<float> GetFloatOutput(this IScadaInterface scada, string name)
        {
            Func<object> f = scada.GetOutput(name);
            return f.GetFloatOutput(scada.Outputs[name]);
        }


        /// <summary>
        /// Gets doubleoutput function
        /// </summary>
        /// <param name="scada">The SCADA</param>
        /// <param name="name">Function name</param>
        /// <returns>The function</returns>
        public static Func<double?> GetDoubleOutput(this IScadaInterface scada, string name)
        {
            Func<object> f = scada.GetOutput(name);
            return f.GetDoubleOutput(scada.Outputs[name]);
        }

        /// <summary>
        /// Gets float input function
        /// </summary>
        /// <param name="scada">The SCADA</param>
        /// <param name="name">The function name</param>
        /// <returns>The function</returns>
        public static Action<float> GetFloatInput(this IScadaInterface scada, string name)
        {
            Action<object> action = scada.GetInput(name);
            return action.GetFloatInput(scada.Inputs[name]);
        }

        /// <summary>
        /// Gets double input function
        /// </summary>
        /// <param name="scada">The SCADA</param>
        /// <param name="name">The function name</param>
        /// <returns>The function</returns>
        public static Action<double> GetDoubleInput(this IScadaInterface scada, string name)
        {
            Action<object> action = scada.GetInput(name);
            return action.GetDoubleInput(scada.Inputs[name]);
        }

        /// <summary>
        /// To  type name
        /// </summary>
        /// <param name="o">Object</param>
        /// <returns>Type name</returns>
        public static string ToTypeName(this object o)
        {
            Type t = o.ToType();
            return t.AssemblyQualifiedName;
        }

        /// <summary>
        /// Transforms dictionary to type name
        /// </summary>
        /// <param name="dictionary">The dictionary</param>
        /// <returns>Transformation result</returns>
        public static Dictionary<string, object> TransformToTypeName(this Dictionary<string, object> dictionary)
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            foreach (string key in dictionary.Keys)
            {
                d[key] = dictionary[key].ToTypeName();
            }
            return d;
        }

        /// <summary>
        /// Transform to type
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns>Transformation result</returns>
        public static Dictionary<string, object> TransformToType(this Dictionary<string, object> dictionary)
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            foreach (string key in dictionary.Keys)
            {
                d[key] = Type.GetType(dictionary[key] as string);
            }
            return d;
        }

        /// <summary>
        /// Transform to type object
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns>Transformation result</returns>
        public static Dictionary<string, object> TransformToTypeObject(this Dictionary<string, object> dictionary)
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            foreach (string key in dictionary.Keys)
            {
                Type t = Type.GetType(dictionary[key] as string);
                object o = t;
                if (TypeDictionary.ContainsKey(t))
                {
                    o = TypeDictionary[t];
                }
                d[key] = o;
            }
            return d;
        }


        #endregion

        #region Other members

        internal static Type DetectType(this object obj)
        {
            if (obj.Equals(""))
            {
                return typeof(string);
            }
            if (obj is string)
            {
                string str = obj + "";
                if (typeDetector.ContainsKey(str))
                {
                    return typeDetector[str];
                }
               // return null;
                return Type.GetType(str);
            }
            if (obj is Type)
            {
                return obj as Type;
            }
            return obj.GetType();
        }
        
        internal static Func<double> GeDoubleOutput(this Func<object> func, object type)
        {
            Type t = type.DetectType();


            if (t.Equals(typeof(float)))
            {
                return () => { return (float)func(); };
            }
            else
            {
                return () =>
                {
                    float a = (float)func();
                    return (float)a;
                };
            }
        }

        internal static Func<float> GetFloatOutput(this Func<object> func, object type)
        {
            Type t = type.DetectType();


            if (t.Equals(typeof(float)))
            {
                return () => { return (float)func(); };
            }
            else
            {
                return () =>
                {
                    double a = (double)func();
                    return (float)a;
                };
            }
        }

        internal static Func<double?> GetDoubleOutput(this Func<object> func, object type)
        {
            Type t = type.DetectType();
            if (t.Equals(typeof(double)))
            {
                return () => { return (double?)func(); };
            }
            else
            {
                return () =>
                {
                    float? a = (float?)func();
                    return (double?)a;
                };
            }
        }

        internal static Action<float> GetFloatInput(this Action<object> action, object type)
        {
            Type t = type.DetectType();
            if (t.Equals(typeof(float)))
            {
                return (float x) => { action(x); };
            }
            else
            {
                return (float x) =>
                {
                    double a = (double)x;
                    action(a);
                };
            }
        }

        internal static Action<double> GetDoubleInput(this Action<object> action, object type)
        {
            Type t = type.DetectType();
            if (t.Equals(typeof(double)))
            {
                return (double x) => { action(x); };
            }
            else
            {
                return (double x) =>
                {
                    float a = (float)x;
                    action(a);
                };
            }
        }         

        internal static Tuple<Dictionary<string, object>[], List<string>> Convert(this XElement doc)
        {
            string[] ss = new string[] { Inputs, Outputs };
            Dictionary<string, object>[] d = new Dictionary<string, object>[2];
            for (int i = 0; i < 2; i++)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                d[i] = dictionary;
                XElement el = doc.GetElementsByTagName(ss[i])[0] as XElement;
                foreach (XElement e in el.Elements())
                {
                    string name;
                    string value;
                    e.GetNameValue(out name, out value);
                    dictionary[name] = value;
                }
           }
            List<string> ev = new List<string>();
            XElement evl = doc.GetElementsByTagName(Events)[0];
            foreach (XElement e in evl.Elements())
            {
                ev.Add(e.InnerText());
            }
            return new Tuple<Dictionary<string, object>[], List<string>>(d, ev);
        }
        
        private static Type ToType(this object type)
        {
            if (type is Type)
            {
                return type as Type;
            }
            return type.GetType();
        }

        private static bool Compare(this Type source, Type target)
        {
            if (target == null)
            {
                return false;
            }
            if (source.Equals(target))
            {
                return true;
            }
            return Compare(source, IntrospectionExtensions.GetTypeInfo(target).BaseType);
        }

        #endregion

    }
}
