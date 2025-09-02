using BaseTypes.Attributes;
using Diagram.Interfaces;
using Diagram.UI;
using Diagram.UI.CodeCreators.Interfaces;
using Diagram.UI.Interfaces;
using ErrorHandler;

namespace Diagram.Java
{
    [Language("Java")]
    public class ClassCodeCreator : IClassCodeCreator, IDictionaryCodeCreator<string, string>,
        IEnumerableCodeCreator<int[]>, 
        IEnumerableCodeCreator<Tuple<int, string>>,  ICurrentObject
    {
        protected static IDictionaryCodeCreator<string, string> dictionaryStringStringCodeCreator;

        protected static IEnumerableCodeCreator<int[]> enumerableIntCodeCreator;
        
        protected static IEnumerableCodeCreator<Tuple<int, string>> enumerableIntStringCodeCreator;


        protected UI.Performer Performer
        {
            get;
            set;
        } = new Performer();


        protected Dictionary<Func<object, bool>, Func<string, object, List<string>>> dictionary;

        protected Dictionary<string, string> classes;

        void Init()
        {
            dictionaryStringStringCodeCreator = this;
            enumerableIntCodeCreator = this;
            enumerableIntStringCodeCreator = this;

        }

        protected ClassCodeCreator(bool b)
        {
            Init();
        }

        public ClassCodeCreator()
        {
            Init();
            classes = new Dictionary<string, string>()
            {
               
            };

            dictionary = new Dictionary<Func<object, bool>, Func<string, object, List<string>>>()
         {
          };
   
        }

        #region Interface


        protected IDesktopCodeCreator DesktopCodeCreator
        { get; set; }

   
        List<string> IClassCodeCreator.CreateCode(string preffix, object obj, string volume)
        {
            return CreateCode(preffix, obj, volume);
        }


        #endregion

        #region Protected Members

        protected bool DetectType(object o, string type)
        {
            return o.GetType().Name == type;
        }

  
        protected virtual object CurrentObject
        {
            get;
            set;
        }

        object ICurrentObject.CurrentObject => CurrentObject;

        protected List<string> CreateExt(string preffix, object ob)
        {
            var creator = Performer.GetLaguageObject<IClassCodeCreator>("Java");
            var s = creator.CreateCode(preffix, ob, "BaseClassName")[0];
            var l = new List<string>();
            l.Add("protected class " + preffix + " extends " + s);
            l.Add("{");
            l.Add("\tpublic " + preffix + "(String name, IDesktop desktop) {");
            l.Add("\t\tsuper(name,  desktop);");
            return l;
        }

        protected virtual List<string> CreateCode(string prefix, object obj, string volume)
        {
            foreach (Func<object, bool> key in dictionary.Keys)
            {
                if (key(obj))
                {
                    if (volume != null)
                    {
                        if (volume == "BaseClassName")
                        {
                            var t = obj.GetType().Name;
                            var s = classes[t];
                            return new List<string> { s };

                        }
                        else if (volume == "constructor")
                        {
                            var t = obj.GetType().Name;
                            var s = classes[t];
                            var lc = new List<string>();
                         //   lc.Add(prefix + "(String name, IDesktop desktop) {");
                         //   lc.Add("\tsuper(name, desktop);");
                            return lc;
                        }
                        else if (volume == "post")
                        {
                            var t = obj.GetType().Name;
                            var s = classes[t];
                            var lc = new List<string>();
                            //   lc.Add(prefix + "(String name, IDesktop desktop) {");
                            //   lc.Add("\tsuper(name, desktop);");
                            return lc;
                        }
                        else
                        {
                            throw new OwnNotImplemented();
                        }
                    }
                    var l = CreateExt(prefix, obj);
                    var ll = dictionary[key](prefix, obj);
                    Performer.Add(l, ll, 2);
    //                l.Add("}");
                    l.Add("");
                    return l;
                }
            }
            return null;
        }


        #endregion

        #region  Creators

        static List<string> CreateDataLink(string preffix, object obj)
        {
            return new List<string>() { "}" };
        }


        static List<string> CreateDataConsumer(string preffix, object obj)
        {
            return new List<string>();
        }

        Dictionary<string, List<string>> IDictionaryCodeCreator<string, string>.Create(string id, 
            Dictionary<string, string> dictionary)
        {
            var n = dictionary.Count;
            var l = new List<string>();
            l.Add("var " + id + " = new java.util.HashMap<String, String>() {");
            l.Add("\t{");
            foreach (var i in dictionary)
            {
                l.Add("\t\tput(\""+ i.Key + "\", \""  + i.Value + "\");");
            }
            l.Add("\t}");
            l.Add("};");
            var d = new Dictionary<string, List<string>>();
            d["code"] = l;
            return d;
        }

        Dictionary<string, List<string>> IEnumerableCodeCreator<int[]>.Create(string id, IEnumerable<int[]> values)
        {
            var l = new List<string>();
            l.Add("int[] x = null;");
            l.Add("java.util.ArrayList<int[]> " + id + " = new java.util.ArrayList<>();");
            foreach (var x in values)
            {
                l.Add("x = new int[]{");
                var n = x.Length;
                for (int i = 0; i < n; i++)
                {
                    var s = x[i] + "";
                    if (i < n - 1)
                    {
                        s += ",";
                    }
                    l.Add(s);
                }
                l.Add("};");
                l.Add(id + ".add(x);");

            }
            var d = new Dictionary<string, List<string>>();
            d["code"] = l;
            return d;
        }

        Dictionary<string, List<string>> IEnumerableCodeCreator<Tuple<int, string>>.Create(string id, IEnumerable<Tuple<int, string>> values)
        {
            var d = new Dictionary<string, List<string>>();
            var l = new List<string>();
            l.Add("var " + id + "array = new java.util.ArrayList<general_service.Enrty<int[], String>>();");
            foreach (var x in values)
            {
                l.Add(id + ".add(new general_service.Enrty<>(new int[]{" + x.Item1 + "}, \"" + x.Item2 + "\"));");
            }
            d["code"] = l;
            return d;
        }

   

        #endregion

    }
}
