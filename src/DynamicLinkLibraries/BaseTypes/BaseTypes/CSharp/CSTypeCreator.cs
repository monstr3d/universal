using System;
using System.Collections.Generic;
using System.Reflection;


using BaseTypes.Interfaces;

namespace BaseTypes.CSharp
{
    public class CSTypeCreator : ITypeCreator
    {
        #region Fields

        static private readonly Dictionary<Type, string> dictionary =
            new Dictionary<Type, string>()
            {
               { typeof(double), "double" },
               { typeof(float), "float" },
               { typeof(sbyte), "sbyte" },
               { typeof(byte), "byte" },
               { typeof(short), "short" },
               { typeof(ushort), "ushort" },
               { typeof(int), "int" },
               { typeof(uint), "uint" },
               { typeof(long), "long" },
               { typeof(ulong), "ulong" },
               { typeof(bool), "bool" },
              { typeof(string), "string" },
            };

        static private readonly Dictionary<string, string> defaultValue = new Dictionary<string, string>()
        {
            {"False", "false"},
            {"True", "true"},
            {"\"\"", "\"\""},
        };


        #endregion

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
            if (dictionary.ContainsKey(type))
            {
                return dictionary[type];
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

        #endregion
    }
}
