using BaseTypes.Attributes;

using Diagram.UI;
using System.Collections.Generic;
using System;

namespace DataPerformer.Portable.CodeCreators
{
    [Language("C#")]
    class ClassCodeCreator : Diagram.UI.CodeCreators.BaseClassCodeCreator
    {

        internal ClassCodeCreator() : base(false)
        {
           
            this.AddClassCodeCreator();
            dictionary = new Dictionary<Func<object, bool>, Func<string, object, List<string>>>()
            {
                    { (o) => { return o is FilterWrapper & o.GetType().Name == "FilterWrapper"; } , CreateFilter },
             };

        }

        List<string> CreateDataConsunerIterate(string preffix, object obj)
        {
            var l = new List<string>();
            string pr = preffix;
            if (pr[pr.Length - 1] != '.')
            {
                pr = pr + ".";
            }
            var str = "DataPerformer.Portable.DataConsumerIterate";
            l.Add(str);
            DataConsumer c = obj as DataConsumer;
            l.Add("{");
            l.Add("internal CategoryObject() : base(" + c.ConsumerType + ")");
            l.Add("{");
            l.Add("}");
            l.Add("}");
            return l;
        }



        List<string> CreateFilter(string preffix, object obj)
        {
            var l = new List<string>();
            string pr = preffix;
            if (pr[pr.Length - 1] != '.')
            {
                pr = pr + ".";
            }
            var fv = obj as FilterWrapper;
            var count = fv.Filter.Count;
            l.Add("DataPerformer.Portable.FilterWrapper");
            l.Add("{");
            l.Add("");
            l.Add("\tinternal CategoryObject() : base(false)");
            l.Add("\t{");
            l.Add("\t\tkind = " + fv.Kind + ";");
            l.Add("\t\tInput = \"" + fv.Input + "\";");
            l.Add("\t\tSetFilter();");
            l.Add("\t\tfilter.Count = " + count + ";");
            l.Add("\t}");
            l.Add("}");
            return l;
        }

    
        #region IClassCodeCreator Members
     

        protected override  List<string> CreateCode(string preffix, object obj, string volume)
        {
            var ll = base.CreateCode(preffix, obj, volume);
            if (ll != null)
            {
                return ll;
            }
            string str = null;
            List<string> l = new ();
            switch (obj)
            {
                case SeriesBase seriesBase:
                    return Get(seriesBase);
                case ObjectTransformer objectTransformer:
                    return GetObjectTransformer(objectTransformer);
                case VectorAssembly vectorAssembly:
                    return Get(vectorAssembly);
                case  RandomGenerator random:
                    return Get(random);
                  default:
                    break;
            }

             if (str == null)
            {
                string th = obj.GetType().Name;

                if (th.Equals("DataConsumer"))
                {
                    if (obj is DataConsumerIterate)
                    {

                        return CreateDataConsunerIterate(preffix, obj);
                    }
                    str = "DataPerformer.Portable.DataConsumer";
                    l.Add(str);
                    DataConsumer c = obj as DataConsumer;
                    l.Add("{");
                    l.Add("internal CategoryObject() : base(" + c.ConsumerType + ")");
                    l.Add("{");
                    l.Add("}");
                    l.Add("}");
                    return l;
                }
            }
            if (str == null)
            {
                return null;
            }
            l.Add(str);
            l.Add("{");
            l.Add("}");
            return l;
        }

  
        List<string> Get(RandomGenerator random)
        {
            var l = new List<string>();
            string str = "DataPerformer.Portable.RandomGenerator";
            l.Add(str);
            l.Add("{");
            l.Add("\tinternal CategoryObject() : base()");
            l.Add("\t{");
            l.Add("\t}");
            l.Add("}");
            return (l);
        }

        List<string> Get(VectorAssembly assembly)
        {
            List<string> l = new();
            string str = "DataPerformer.Portable.VectorAssembly";
            l.Add(str);
            l.Add("{");
            l.Add("\tinternal CategoryObject() : base()");
            l.Add("\t{");
            l.Add("\t\tnames ="); 
            l.Add("\t\t[");
            var names = assembly.Names;
            bool beg = true;
            foreach (var name in names)
            {
                var s = beg ? "\t\t\t" : "\t\t\t, ";
                beg = false;
                s += "\"" + name + "\"";
                l.Add(s);
            }
            l.Add("\t\t];");
            l.Add("\t}");
            l.Add("}");
            return l;
        }


        List<string> Get(SeriesBase series)
        {
            List<string> l = new ();
            string str = "DataPerformer.Portable.SeriesBase";
            l.Add(str);
            l.Add("{");
            l.Add("\tinternal CategoryObject()");
            l.Add("\t{");
            l.Add("\t\tpoints = new List<double[]>()");
            l.Add("\t\t{");
            for (int i = 0; i < series.Count; i++)
            {
                string s = "\t\t\tnew double[] { " + series[i, 0].StringValue() + ", " +
                    series[i, 1].StringValue() + "}";
                if (i < series.Count - 1)
                {
                    s += ",";
                }
                l.Add(s);
            }
            l.Add("\t\t};");
            l.Add("}");
            l.Add("}");
            return l;
        }



        List<string>  GetObjectTransformer(ObjectTransformer transformer)
        {
            List<string> l = new List<string>();
            string str = "DataPerformer.Portable.ObjectTransformer";
            l.Add(str);
            l.Add("{");
            l.Add("internal CategoryObject()");
            l.Add("{");
            Dictionary<string, string> links = transformer.Links;
            int k = links.Count;
            int i = 0;
            l.Add("\tlinks = new Dictionary<string, string>()");
            l.Add("\t{");
            foreach (string key in links.Keys )
            {
                ++i;
                string ss = "\t\t{ \"" + key + "\",\"" + links[key] + "\"}";
                if (i != k)
                {
                    ss += ",";
                }
                l.Add(ss);
            }
            l.Add("\t};");
            l.Add("}");
            l.Add("}");
            return l;
        }

        #endregion
    }
}
