using System.Reflection;

using BaseTypes;
using BaseTypes.Attributes;
using BaseTypes.CodeCreator.Interfaces;
using Diagram.UI;
using Diagram.UI.Interfaces;

namespace Diagram.TypeScript
{
    [Language("TS")]
    public class CodeCreator : ITypeCreator, IDictionaryCodeCreator<string, string>,
        IDictionaryCodeCreator<string, object>, 
        IEnumerableCodeCreator<string>, IAliasCodeCreator, 
        IFeedbackCollectionCodeCreator

    {
        #region Fields

        public static ITypeCreator TypeCreator
        {
            get;

        } = new CodeCreator();


        static protected UI.TypeScript.Performer performer = new();




        static public readonly Dictionary<Type, string> Dictionary =
            new Dictionary<Type, string>()
            {
               { typeof(double), "number" },
               { typeof(float), "number" },
               { typeof(sbyte), "number" },
               { typeof(byte), "byte" },
               { typeof(short), "number" },
               { typeof(ushort), "number" },
               { typeof(int), "number" },
               { typeof(uint), "number" },
               { typeof(long), "number" },
               { typeof(ulong), "number" },
               { typeof(bool), "boolean" },
              { typeof(string), "string" },
            };

        static private readonly Dictionary<string, string> defaultValue = new Dictionary<string, string>()
        {
            {"False", "false"},
            {"True", "true"},
            {"\"\"", "\"\""},
        };


        #endregion

        protected  CodeCreator(bool b)
        {
            
        }


        private CodeCreator()
        {
           this.AddTypeCreator();
        }

        #region ITypeCreator Members

        /// <summary>
        /// Get string type of object
        /// </summary>
        /// <param name="o">Object</param>
        /// <returns>The string type</returns>
        public string GetType(object o)
        {
            if (o is ArrayReturnType)
            {
                ArrayReturnType t = o as ArrayReturnType;
                string st = "object";
                if (!t.IsObjectType)
                {
                    st = GetType(t.ElementType);
                }
                st += "[";
                int[] n = t.Dimension;
                for (int i = 0; i < n.Length - 1; i++)
                {
                    st += ',';
                }
                st += ']';
                return st;
            }
            Type type = o.GetType();
            if (Dictionary.ContainsKey(type))
            {
                return Dictionary[type];
            }
            if (o is Type)
            {
                Type t = o as Type;
                return t.FullName;
            }
            return "object";
        }

        /// <summary>
        /// Gets default value of object
        /// </summary>
        /// <param name="o">The object</param>
        /// <returns></returns>
        public string GetDefaultValue(object o)
        {
            if (o.GetType().ToString().Contains("System.Tuple"))
            {
                return "";
            }
            string ot = o.GetDefaultStringValue();
            if (ot != null)
            {
                return ot;
            }
            if (o is ArrayReturnType)
            {
                ArrayReturnType t = o as ArrayReturnType;
                string st = "object";
                if (!t.IsObjectType)
                {
                    st = GetType(t.ElementType);
                }
                st = "new " + st + "[";
                int[] n = t.Dimension;
                for (int i = 0; i < n.Length; i++)
                {
                    int k = n[i];
                    if (k < 0)
                    {
                        k = 0;
                    }
                    st += k;
                    if (i < n.Length - 1)
                    {
                        st += ',';
                    }
                }
                st += ']';
                return st;
            }
            if (o is DateTime)
            {
                return "new DateTime((long)0, DateTimeKind.Utc)";
            }
            string s = o + "";
            if (defaultValue.ContainsKey(s))
            {
                return defaultValue[s];
            }
            if (o is Type)
            {
                Type t = o as Type;
                TypeInfo ti = IntrospectionExtensions.GetTypeInfo(t);
                if (ti.IsClass | ti.IsInterface | ti.IsAbstract)
                {
                    return "null";
                }
                else
                {
                    return "";
                }
            }
            if (s.Equals("System.Object"))
            {
                return "";
            }
            return s;
        }

        string ITypeCreator.GetStringValue(object o)
        {
            return (o is string) ? "\"" + o + "\"" : "" + o;
        }

        #endregion
        Dictionary<string, List<string>> IDictionaryCodeCreator<string, object>.Create(string id, Dictionary<string, object> dictionary)
        {
            List<string> l = new List<string>();
            l.Add("let " + id + " = new Map<string, any>(");
            int n = dictionary.Count;
            l.Add("[");
            if (n == 0)
            {
                l.Add("]);");
            }
            else
            {
                int i = 0;
                foreach (var item in dictionary)
                {
                    string s = item.Key;
                    s = "\t[\"" + s + "\", " + performer.StringValue(item.Value) + " ]";
                    if (i < (n - 1))
                    {
                        s += ',';
                    }
                    l.Add(s);
                }
                l.Add("]);");
            }
            Dictionary<string, List<string>> d = new();
            d["code"] = l;
            return d;
        }

        Dictionary<string, List<string>> IDictionaryCodeCreator<string, string>.Create(string id, Dictionary<string, string> dictionary)
        {
            return Create(id, dictionary);
        }


        public static Dictionary<string, List<string>> Create(string id, Dictionary<string, string> dictionary)
        {
            var l = new List<string>();
            l.Add("let " + id + " = new Map<string, string>(");
            int n = dictionary.Count;
            int i = 0;
            l.Add("[");
            if (n == 0)
            {
                l.Add("]);");
            }
            else
            {
                foreach (var t in dictionary)
                {
                    var s = "\t[\"" + t.Key + "\", \"" + t.Value + "\" ]";
                    if (i < (n - 1))
                    {
                        s += ',';
                    }
                    l.Add(s);
                    ++i;
                }
                l.Add("]);");
            }


            var d = new Dictionary<string, List<string>>();
            d["code"] = l;
            return d;
        }

        Dictionary<string, List<string>> IFeedbackCollectionCodeCreator.Create(IFeedbackCollectionHolder holder)
        {
            var d = new Dictionary<string, List<string>>();
            d["code"] = Create(holder);
            return d;
        }

        Dictionary<string, List<string>> Create(string id, IAlias alias)
        {
            UI.Performer p = new UI.Performer();
            IDictionaryCodeCreator<string, object> d = this;
            var dp = p.FromAlias(alias);
            var cd = d.Create("map", dp);
            return cd;
        }

        Dictionary<string, List<string>> IAliasCodeCreator.Create(string id, IAlias alias)
        {
            return Create(id, alias);

        }

        IDictionaryCodeCreator<string, string> dcc => this;



        private List<string> Create(IFeedbackCollectionHolder holder)
        {
            var feedback = holder.Feedback;
            var l = new List<string>();
            if (feedback is IFeedbackAliasCollection fa)
            {
                feedback.Fill();
                var d = fa.Dictionary;
                if (d.Count > 0)
                {
                    l.Add("setFeedback(): void {");
                    var ll = dcc.Create("map", fa.Dictionary).Values.ToArray()[0];
                    ll.Add("this.feedback = new FeedbackAliasCollection(map, this, this);");
                    performer.Add(l, ll, 1);
                    l.Add("}");
                }
            }
            return l;
        }

        Dictionary<string, List<string>> IEnumerableCodeCreator<string>.Create(string id, IEnumerable<string> values)
        {
            return new Dictionary<string, List<string>>();  
        }
    }
}
