using Diagram.Attributes;
using Diagram.UI;
using Diagram.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPerformer.Portable.TypeScript
{
    /// <summary>
    /// Creator of TS code
    /// </summary>
    [Language("TS")]
    internal class TSCodeCreator : IClassCodeCreator
    {
        static Diagram.TypeScript.Performer performer = new Diagram.TypeScript.Performer();


        #region Ctor
        internal TSCodeCreator()
        {
            this.AddCodeCreator();
        }
        #endregion

        static readonly Dictionary<Func<object, bool>, Func<string, object, List<string>>> dictionary =
         new Dictionary<Func<object, bool>, Func<string, object, List<string>>>()
         {
                   { (object o) => { return o is DataLink; } ,CreateDataLink},
                   { (object o) => { return o is RandomGenerator; } , CreateRandomGenerator},
             //    { (object o) => { return o is Recursive; } , CreateRecursive },
         };

        List<string> IClassCodeCreator.CreateCode(string preffix, object obj)
        {
            foreach (Func<object, bool> key in dictionary.Keys)
            {
                if (key(obj))
                {
                    return dictionary[key](preffix, obj);
                }
            }
            string th = obj.GetType().Name;
            if (th.Equals("DataConsumer"))
            {
                DataConsumer c = obj as DataConsumer;
                return CreateDataConsumer(preffix, obj);
            }
            return null;
        }

        static List<string> CreateDataConsumer(string preffix, object obj)
        {
            List<string> l = new List<string>();
            var s = performer.ClassString(preffix, "DataConsumer");
            l.Add(s);
            l.Add("{");
            performer.AddObjectConstructor(l);
            l.Add("\t}");
            l.Add("}");
            return l;
        }

        static List<string> CreateRandomGenerator(string preffix, object obj)
        {
            List<string> l = new List<string>();
            var s = performer.ClassString(preffix, "RandomGenerator");
            l.Add(s);
            l.Add("{");
            performer.AddObjectConstructor(l);
            l.Add("\t}");
            l.Add("}");
            return l;
        }

   

        public S Convert<T, S>(T obj)
        {
            var o = (object)obj;
            return (S)o;
        }


        static List<string> CreateDataLink(string preffix, object obj)
        {

            List<string> l = new List<string>();
            var s = performer.ClassString(preffix, "DataLink");
            l.Add(s);
            l.Add("{");
            performer.AddObjectConstructor(l);
            l.Add("\t}");
            l.Add("}");
            return l;
        }

    }
}

