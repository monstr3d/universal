using System;
using System.Collections.Generic;
using System.Linq;

using BaseTypes.Attributes;

using Diagram.UI;

namespace DataPerformer.Portable.TypeScript
{
    /// <summary>
    /// Creator of TS code
    /// </summary>
    [Language("TS")]
    public class ClassCodeCreator : Diagram.UI.TypeScript.ClassCodeCreator
    {
        
        protected Diagram.UI.TypeScript.Performer performer = new();

        #region Ctor

        protected ClassCodeCreator(bool b) : base(true) { }
        internal ClassCodeCreator() : base(false)
        {
            dictionary = new Dictionary<Func<object, bool>, Func<string, object, List<string>>>()
         {
                      { (object o) => { return o is ObjectTransformer; } , CreateObjectTransformer },
                   { (object o) => { return o is RandomGenerator; } , CreateRandomGenerator},
                { (object o) => { return o is FilterWrapper; } ,CreateFilterWrapper},
             { (object o) => { return o is DataLink; } ,CreateDataLink},
              { (object o) => { return o is ObjectTransformerLink; } , CreateObjectTransformerLink},
               { (object o) => { return o is IteratorConsumerLink; } , CreateIteratorConsumerLink},
         };
            this.AddClassCodeCreator();
        }

        #endregion

        protected string DoubleToString(double d)
        {
            return performer.DoubleToString(d);
        }

        protected override List<string> CreateCode(string preffix, object obj, string volume)
        {
           var l = base.CreateCode(preffix, obj, volume);
            if (l != null)
            {
                return l;
            }
            string th = obj.GetType().Name;
            if (th.Equals("DataConsumer"))
            {
                DataConsumer c = obj as DataConsumer;
                return CreateDataConsumer(preffix, obj);
            }
            return null;
        }

        List<string> CreateFilterWrapper(string preffix, object obj)
        {
            List<string> l = new List<string>();
            var filter = obj as FilterWrapper;
            var s = performer.ClassString(preffix, "SequenceFilterWrapper");
            l.Add(s);
            l.Add("{");
            performer.AddObjectConstructor(l);
            var count = filter.Filter.Count;
            l.Add("\t\tthis.count = " + count);
            l.Add("\t\tthis.input = \"" + filter.Input + "\"");
            var kind = filter.Kind;
            if (kind == 0)
            {
                l.Add("\t\tthis.type = SequenceFilterType.Avarage");
            }
            else
            {
                l.Add("\t\tthis.type = SequenceFilterType.Donchian");
                var st = filter.Kind == 1 ? "true" : "false";
                l.Add("\t\tthis.mimax = " + st);

            }
            l.Add("\t}");
            l.Add("}");
            return l;
        }



        List<string> CreateObjectTransformer(string preffix, object obj)
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


        List<string> CreateDataConsumer(string preffix, object obj)
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

         List<string> CreateRandomGenerator(string preffix, object obj)
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

        List<string> CreateObjectTransformerLink(string preffix, object obj)
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


        List<string> CreateDataLink(string preffix, object obj)
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

         List<string> CreateIteratorConsumerLink(string preffix, object obj)
        {

            List<string> l = new List<string>();
            var s = performer.ClassString(preffix, "IteratorConsumerLink");
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

