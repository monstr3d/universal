using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Windows.Media.Media3D;



namespace Collada.Wpf
{
    /// <summary>
    /// Collada converter
    /// </summary>
    public static partial class StaticExtensionColladaOld
    {

        #region Fields

        static string fileName;

        static private XmlDocument doc;

        static string directory;

        private static readonly char[] sep = "\r\n ".ToCharArray();

        private static event Action<Exception> onError = (Exception e) => { };

        private static event Action<Exception> onWarning = (Exception e) => { };

        private static Dictionary<string, XmlElement> parameters = new Dictionary<string, XmlElement>();


        #endregion


  

        #region Dictionary


        private static IdName idName;


  
        public static void Set(this IdName idName, object o)
        {
            if (o == null)
            {
                throw new Exception();
            }
            if (allObjects.ContainsKey(idName))
            {
          //      throw new Exception();
            }
            idName.Object = o;
            allObjects[idName] = o;
        }

        public static IEnumerable<KeyValuePair<T, object>> GetEnumerable<T>(this Dictionary<T, object> dictionray)
        {
            foreach (KeyValuePair<T, object> kvp in dictionray)
            {
                if (kvp.Value is Dictionary<T, object> d)
                {
                    var t = d.GetEnumerable<T>();
                    foreach (var tt in t)
                    {
                        yield return tt;
                    }
                }
                else
                {
                    yield return kvp;
                }
            }
        }

 
 

 


      
        
        #endregion

        #region Common

       public static void ColladaToXaml(this string fileName)
       {
            StaticExtensionCollada.Load(fileName);
            idName = null;
           directory = System.IO.Path.GetDirectoryName(fileName) +
               System.IO.Path.DirectorySeparatorChar;
           XmlDocument doc = new XmlDocument();
           doc.Load(fileName);
       }


       public static Dictionary<string, Visual3D> ColladaToVisual3D(this string fileName)
       {
            StaticExtensionCollada.Load(fileName);
            directory = System.IO.Path.GetDirectoryName(fileName) +
               System.IO.Path.DirectorySeparatorChar;
           XmlDocument doc = new XmlDocument();
           doc.Load(fileName);
        //   doc.ColladaToXaml();
           return doc.ColladaToVisual3D();
       }

        private static void Clear()
        {
            foreach (object[] o in functions.Values)
            {
                (o[1] as IDictionary).Clear();
            }
            parameters.Clear();
        }

   
        private static XmlElement FindByName(string tag, string name)
        {
            XmlNodeList nl = doc.DocumentElement.GetElementsByTagName(tag);
            foreach (XmlElement e in nl)
            {
                if (e.GetAttribute("name").Equals(name))
                {
                    return e;
                }
            }
            return null;
        }

        public static void ColladaToXaml(this XmlDocument doc)
        {
            StaticExtensionColladaOld.doc = doc;
            Clear();
            idName = doc.DocumentElement.SetDictionaryId();
            XmlNodeList p = doc.DocumentElement.GetElementsByTagName("newparam");
            foreach (XmlElement e in p)
            {
                parameters[e.GetAttribute("sid")] = e;
            }
            var l = new List<IdName>();
            foreach (var x in IdName.All)
            {
                if (l.Contains(x))
                {
                    throw new Exception();
                }
                if (!(x.Object is XmlElement))
                {
                   // throw new Exception();
                }
                l.Add(x);
            }
            foreach (IdName n in l)
            {
                XmlElement e = n.Xml;
                if (e == null)
                {
                    throw new Exception();
                }
                string tag = e.Name;
                if (functions.ContainsKey(tag))
                {
                    var o = tag.Process(e);
                    if (o != null)
                    {
                        n.Set(o);
                    }
                }
            }
            idName.SetSource();
            idName.Combine();
        }

        static void Combine(XmlNode node)
        {
            var nl = node.ChildNodes;
            foreach (XmlNode n in nl)
            {
                Combine(n);
            }
            if (node is XmlElement el)
            {
                if (el.GetAttribute("IsCombined") == "True")
                {

                }
                else
                {
                    var i = el.ToIdName();
                    i.Combine();
                    i.IsCombined = true;
                }
            }
        }

        static private void ToList(this KeyValuePair<IdName, object> kvp, List<KeyValuePair<IdName, object>> list)
        {
            if (kvp.Value is List<KeyValuePair<IdName, object>> lt)
            {
                foreach (var i in lt)
                {
                    i.ToList(list);
                }
                return;
            }
            list.Add(kvp);
        }

        static private void ToList(this List<KeyValuePair<IdName, object>> kvp, List<KeyValuePair<IdName, object>> list)
        {
            foreach (var v in kvp)
            {
                v.ToList(list);
            }

        }


        static public object Combine(this IdName name)
        {
            var o = name.Object;
            if (name.IsCombined)
            {
                return o;
            }
            XmlNode n = name.Xml;
            foreach (XmlNode nd in n.ChildNodes)
            {
                Combine(nd);
            }
            var l = new List<KeyValuePair<IdName, object>>();
            foreach (var i in name)
            {
                var ob = i.Object;
                if (ob == null)
                {
                    continue;
                }
                if (Compare(ob, o))
                {
                    continue;
                }
                if (ob is KeyValuePair<IdName, object> p)
                {
                    p.ToList(l);
                }
                else if (ob is List<KeyValuePair<IdName, object>> li)
                {
                    li.ToList(l);
                }
                else
                {
                    l.Add(new KeyValuePair<IdName, object>(i, ob));
                }
            }
            if (o == null)
            {
                name.IsCombined = true;
                name.Reset(l);
                return l;
            }
            Type t = o.GetType();
            var r =  name.Combine(t, o, l);
            name.Reset(r);
            name.IsCombined = true;
            return r;
        }

        public static object Combine(this IdName name, Type type, object o, List<KeyValuePair<IdName, object>> list)
        {
       

            Func<IdName, object, List<KeyValuePair<IdName, object>>, object> f = null;
            Type t = type;
            while (true)
            {
                if (t == null)
                {
                    break;
                }
                if (combine.ContainsKey(t))
                {
                    f = combine[t];
                    break;
                }
                t = t.BaseType;
            }
            if (f != null)
            {
                 return f(name, o, list);
            }
            return o;
        }

        #region Combines

        static object GetBlur(IdName name, object o,  List<KeyValuePair<IdName, object>> l)
        {
            return null;
        }

        static object GetArray(IdName name, object o, List<KeyValuePair<IdName, object>> l)
        {
            Array arr = o as Array;
            foreach (var p in l)
            {
                if (!arr.Compare(p.Value))
                {
                    throw new Exception();
                }
            }
            return o;
        }

        static object GetScene(IdName name, object o, List<KeyValuePair<IdName, object>> l)
        {
            var scene = o as Scene;
            var xml = scene.Xml;

            return o;
        }

        static object GetVisual3D(IdName name, object o, List<KeyValuePair<IdName, object>> l)
        {
            var visual3D = o as Visual3D;
            var xml = name.Xml;
            if (visual3D is ModelVisual3D mod)
            {
                var c = mod.Content;
                if (c is GeometryModel3D g3d)
                {
                    var g = g3d.Geometry;
                    if (g is MeshGeometry3D m3d)
                    {
                        name.Set(xml, m3d);
                    }
                }
            }

            return visual3D;
        }



        static object GetM3d(IdName name, object o, List<KeyValuePair<IdName, object>> l)
        {
            var xml = name.Xml;
            foreach (var p in l)
            {
                var k = p.Key.Xml;
                var att = k.Attributes;
            }
            return null;
        }

        #endregion

        #region Compare

        static public bool Compare(this Array array, object o)
        {
            if (o is Array ar)
            {
                if (array is double[] d1 && ar is double[] d2)
                    return d1.SequenceEqual(d2);
                if (array is float[] f1 && ar is float[] f2)
                    return f1.SequenceEqual(f2);
                if (array is int[] i1 && ar is int[] i2)
                    return i1.SequenceEqual(i2);
            }
            return false;
        }

        static bool Compare(this object o1, object o2)
        {
            if (o1 == null)
            {
                return (o2 == null);
            }
            
            object x = o2;
            if (o1 == x)
            {
                return true;
            }
            if (o1.Equals(x))
            {
                return true;
            }
            if (o1 is Array  a1)
            {
                if (x is Array a2)
                {
                    if (a1 is double[] d1 && a2 is double[] d2)
                    return d1.SequenceEqual(d2);
                    if (a1 is float[] f1 && a2 is float[] f2)
                        return f1.SequenceEqual(f2);
                    if (a1 is int[] i1 && a2 is int[] i2)
                        return i1.SequenceEqual(i2);
                }
            }
            return false;
        }



        #endregion


        public static Dictionary<string, Visual3D> ColladaToVisual3D(this XmlDocument doc)
        {
            doc.ColladaToXaml();
            Dictionary<string, Visual3D> d = new Dictionary<string, Visual3D>();
            return d;
            XmlElement e =  doc.GetElementsByTagName("library_visual_scenes")[0] as XmlElement;
            XmlNodeList nl = e.GetElementsByTagName("visual_scene");
            foreach (XmlElement el in nl)
            {
                Visual3D v = el.ToVisual3D();
                if (v != null)
                {
                    v.SetLight();
                 //   d[el.GetAttribute("id")] = v;
                }
            }
            return d;
        }




   

        private static IdName SetDictionaryId(this XmlElement element)
        {
            idName =  IdName.ToIdName(element);
            return idName;
        }
        

        private static void SetDictionaryId(this XmlNode node)
        {
            if (node is XmlElement e)
            {
                e.SetDictionaryId();
                return;
            }
            var nl = node.ChildNodes;
            foreach (XmlNode n in nl)
            {
                n.SetDictionaryId();
            }
        }


        #endregion


        #region Clone

        public static T[] CloneArray<T>(this T[] t) where T : struct
        {
            var tt = new T[t.Length];
            for (var i = 0; i < t.Length; i++)
            {
                tt[i] = t[i];
            }
            return tt;
        }

        public static T Clone<T>(this T obj) where T : class
        {
            if (obj is double[] d)
            {
                return d.CloneArray() as T;
            }
            if (obj is float[] f)
            {
                return f.CloneArray() as T;
            }
            if (obj is int[] i)
            {
                return i.CloneArray() as T;
            }
            var s = System.Windows.Markup.XamlWriter.Save(obj);
            return System.Windows.Markup.XamlReader.Parse(s) as T;
        }

        #endregion


        #region Events

        public static event Action<Exception> OnError
        {
            add { onError += value; }
            remove { onError -= value; }
        }
        
        public static event Action<Exception> OnWarning
        {
            add { onError += value; }
            remove { onError -= value; }
        }


        #endregion

        #region Convert
  

        static string[] Separate(this string str)
        {
            return str.Split(sep);
        }

        static string ToFileName(this string str)
        {
            return directory + str.Substring(str.LastIndexOf("/") + 1);
        }



        public static Dictionary<string, XmlElement> GetParameters(this XmlElement element)
        {
            Dictionary<string, XmlElement> d = new Dictionary<string, XmlElement>();
            XmlNodeList nl = element.GetElementsByTagName("newparam");
            foreach (XmlElement e in nl)
            {
                d[e.GetAttribute("sid")] = e;
            }
            return d;
        }

 
        static T ToReal<T>(this string s) where T : struct
        {
            object obj = null;
            var t = typeof(T);
            if (t == typeof(double))
            {
                obj = s.ToDouble();
            }
            else if (t == typeof(float))
            {
                obj = float.Parse(s);
            }
            else if (t == typeof(int))
            {
                obj = int.Parse(s);
            }
            return (T)obj;
        }

        static T[] ToRealArray<T>(this  XmlNode node) where T : struct
        {
            string str = node.InnerText;
            string[] ss = str.Split(sep);

            var l = new List<T>();
            foreach (string s in ss)
            {
                if (s.Length > 0)
                {
                    T a = s.ToReal<T>();
                    l.Add(a);
                }
            }
            return l.ToArray();

        }

  
        private static double ToDouble(this string str)
        {
            return Double.Parse(
                str.Replace(".",
                System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
        }

        private static XmlElement Find(this XmlElement element, string tag)
        {
            XmlNodeList nl = element.GetElementsByTagName(tag);
            if (nl.Count == 1)
            {
                return nl[0] as XmlElement;
            }
            return null;
        }

        private static double ToDouble(this XmlElement element)
        {
            if (element.Name.Equals("float"))
            {
                return element.InnerText.ToDouble();
            }
            XmlNodeList nl = element.GetElementsByTagName("float");
            if (nl.Count == 1)
            {
                return (nl[0] as XmlElement).ToDouble();
            }
            throw new Exception();
        }

        private static double ToDouble(this XmlElement element, string tag)
        {
            XmlNodeList nl = element.GetElementsByTagName(tag);
            if (nl.Count == 1)
            {
                return (nl[0] as XmlElement).ToDouble();
            }
             throw new Exception();
        }






     
        private static int ToInt(this string str)
        {
            return int.Parse(str);
        }


        private static int GetCount(this XmlElement e)
        {
            return e.GetAttribute("count").ToInt();
        }

        static XmlElement GetChild(this XmlElement element, string tag)
        {
            XmlNodeList nl = element.GetElementsByTagName(tag);
            if (nl.Count == 1)
            {
                return nl[0] as XmlElement;
            }
            return null;
        }

 
        private static T[] FindArray<T>(IdName name) where T : struct
        {
            if (!arrays.ContainsKey(name))
            {
                GetArray<T>(name, name.Xml);
            }
            return arrays[name] as T[];
        }


        public static T FindSource<T>(this XmlElement element) where T : class
        {
            string s = element.GetAttribute("source").Substring(1);
            return s.Find<T>();
        }

        public static T FindSourceChild<T>(this XmlElement element) where T : class
        {
            XmlElement e = element.GetChild("input");
            return e.FindSource<T>();
        }


        static public  Dictionary<string, object> FindInputs(this XmlElement element)
        {
            XmlNodeList nl = element.GetElementsByTagName("input");
            if (nl.Count == 0)
            {
                return null;
            }
            Dictionary<string, object> d = new Dictionary<string, object>();
            foreach (XmlElement e in nl)
            {
                string key = e.GetAttribute("semantic");
                XmlElement el = e.GetAttribute("source").Substring(1).Find();
                object o = e.GetAttribute("source").Substring(1).ToIdName().Find<object>();
                d[key] = o;
            }
            return d;
        }

        public static XmlElement Find(this string id)
        {
            return IdName.Get(id);
        }

        static public IdName ToIdName(this string id)
        {
            return IdName.GetIdName(id);
        }


        private static T Find<T>(this string name) where T : class
        {
            var idName = IdName.GetIdName(name);
            return Find<T>(idName);
        }

        private static T Find<T>(this IdName name) where T : class
        {
            if (sources.ContainsKey(name))
            {
                return sources[name] as T;
            }
            XmlElement e = name.Xml;
            object[] o = functions[e.Name];
            if (o[1] is Dictionary<IdName, object>)
            {
                Dictionary<IdName, object> dd = o[1] as Dictionary<IdName, object>;
                if (!dd.ContainsKey(name))
                {
                    (o[0] as Func<IdName, XmlElement, object>)(name, e);
                }
                return dd[name] as T;
            }
            Dictionary<IdName, T> d = o[1] as Dictionary<IdName, T>;
            if (!d.ContainsKey(name))
            {
                (o[0] as Func<IdName, XmlElement, object>)(name, e);
            }
            return d[name];
        }

 
        #endregion
 
        #region Models

        static public IdName GetSource(string id)
        {
            return sourcesId[id];
        }

    
        static public IdName ToIdName(this XmlElement element)
        {
            return IdName.ToIdName(element);
        }


        static object Process(this string tag, XmlElement element)
        {
            var idName = element.ToIdName();
            object[] o = functions[tag];
            IDictionary d = o[1] as IDictionary;
            var ob = (o[0] as Func<IdName, XmlElement, object>)(idName, element);
            return ob;
        }

        #endregion

        #region Materials


   
        #region Local Materials
/*
       private static Material GetDiffuse(XmlElement e)
        {
            DiffuseMaterial mat;
              return null;
        }

       private static Material GetSpecular(XmlElement e)
        {
            List<Material> l = new List<Material>();
            return null;
        }

       private static Material GetReflective(XmlElement e)
        {
            List<Material> l = new List<Material>();
            return null;
        }

       private static Material GetTransparent(XmlElement e)
        {
            List<Material> l = new List<Material>();
            return null;
        }
        */
        /*
                 <diffuse>
              <color>0.235294 0.337255 0.239216 1.000000</color>
            </diffuse>
            <specular>
              <color>0.235294 0.337255 0.239216 1.000000</color>
            </specular>
            <reflective>
              <color>1.000000 1.000000 1.000000 1.000000</color>
            </reflective>
            <reflectivity>
         
              <float>1.000000</float>
            </reflectivity>
            <transparent opaque="A_ONE">
              <color>0.000000 0.000000 0.000000 1.000000</color>
            </transparent>*/


        #endregion

        #endregion

    }
}