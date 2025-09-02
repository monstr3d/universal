using BaseTypes.Attributes;
using Diagram.UI;
using Diagram.UI.CodeCreators.Interfaces;
using Diagram.UI.Interfaces;
using System;
using System.Collections.Generic;

namespace DataPerformer.Portable.TypeScript
{
    /// <summary>
    /// Creator of TS code
    /// </summary>
    [Language("TS")]
    internal class ClassCodeCreator : IClassCodeCreator
    {
        static Diagram.UI.TypeScript.Performer performer = new Diagram.UI.TypeScript.Performer();


        #region Ctor
        internal ClassCodeCreator()
        {
           this.AddClassCodeCreator();
        }
        #endregion

        static readonly Dictionary<Func<object, bool>, Func<string, object, List<string>>> dictionary =
         new Dictionary<Func<object, bool>, Func<string, object, List<string>>>()
         {
                      { (object o) => { return o is ObjectTransformer; } , CreateObjectTransformer },
              { (object o) => { return o is DataLink; } ,CreateDataLink},
                   { (object o) => { return o is RandomGenerator; } , CreateRandomGenerator},
               { (object o) => { return o is ObjectTransformerLink; } , CreateObjectTransformerLink},
         };


        protected IDesktopCodeCreator DesktopCodeCreator
        { get; set; }

 


        List<string> IClassCodeCreator.CreateCode(string preffix, object obj, string volume)
        {
            foreach (var val in dictionary)
            {
                if (val.Key(obj))
                {
                    return val.Value(preffix, obj);
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

        static List<string> CreateObjectTransformer(string preffix, object obj)
        {
            List<string> l = new List<string>();
           var ot = obj as ObjectTransformer;
            var s = performer.ClassString(preffix, "ObjectTransformer");
            var ll = performer.CreateStringDictionary("map", ot.Links);
            l.Add(s);
            l.Add("{");
            performer.AddObjectConstructor(l);
            performer.Add(l, ll, 1);
            l.Add("\t\tthis.setLinks(map);");
            l.Add("\t}");
            l.Add("}");
            return l;
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

        static List<string> CreateObjectTransformerLink(string preffix, object obj)
        {

            List<string> l = new List<string>();
            var s = performer.ClassString(preffix, "ObjectTransformerLink");
            l.Add(s);
            l.Add("{");
            performer.AddObjectConstructor(l);
            l.Add("\t}");
            l.Add("}");
            return l;
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

        protected virtual string ClassString(string prefix, object obj)
        {
            return "";
        }


  
        protected virtual string BaseClassString(string prefix, object obj)
        {
            return obj.GetType().Name;
        }
    }
}

