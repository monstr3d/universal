using BaseTypes.Attributes;
using Diagram.UI.Interfaces;
using Diagram.UI;
using Diagram.UI.CodeCreators.Interfaces;
using CategoryTheory;
using DataPerformer.Interfaces;

namespace DataPerformer.Formula.Java
{
    [Language("Java")]
    internal class FeedbackCollectionCodeCreator : IFeedbackCollectionCodeCreator, IEnumerableCodeCreator<Tuple<int[], string>>
    {

        Performer performer = new Performer();

        IEnumerableCodeCreator<Tuple<int[], string>> cc;

        IDesktopCodeCreator dcc;
        internal FeedbackCollectionCodeCreator()
        {
            cc = this;
            this.AddFeedbackCreator();
        }

        Dictionary<string, List<string>> IFeedbackCollectionCodeCreator.Create(IFeedbackCollectionHolder holder)
        {
            if (dcc == null)
            {
                dcc = performer.GetLaguageObject<IDesktopCodeCreator>(this);
            }
            var enu = dcc.Enumeration;
            var ca = enu.Item1;
           var l  = Create(holder, ca);
            var d = new Dictionary<string, List<string>>();
            d["code"] = l;
            return d;
        }

        private List<string> Create(IFeedbackCollectionHolder holder, Dictionary<ICategoryObject, int> dic)
        {
            var dnn = new Dictionary<int, Tuple<int, String>>();
            var feedback = holder.Feedback;
            var l = new List<string>();
            var lt = new List<Tuple<int, string>>();
            var ltt = new List<Tuple<int[], string>>();
            if (feedback is IFeedbackAliasCollection fa)
            {
                var dm = fa.Measurements;
                feedback.Fill();
                var d = fa.Dictionary;
                var enu = fa.Aliases;

                if (d.Count > 0)
                {
                    var mm = holder as IMeasurements;
                    var nn = mm.Count;
                    l.Add("@Override");
                    l.Add("protected void createFeedback() {");
                    
                    foreach (var a in enu)
                    {
                        var an = a.AliasName;
                        var ali = an.Alias as ICategoryObject;
                        var n = dic[ali];
                        var val = a.Value;
                        for (var i = 0; i < nn; i++)
                        {
                            var mea = mm[i];
                            if (mea == val)
                            {
                                var name = an.Name;
                                var t = new Tuple<int, string>(i, name);
                                dnn[i] = t;
                                var tt = new Tuple<int[], string>(new int[] {n, i}, name);
                                ltt.Add(tt);
                            }
                        }
                    }
                    var list = cc.Create("list", ltt).Values.ToList()[0];
                    performer.Add(l, list, 1);
                    l.Add("\tsetFeedback(list);");
                    l.Add("}");
                 }
            }
            return l;
        }

        Dictionary<string, List<string>> IEnumerableCodeCreator<Tuple<int[], string>>.Create(string id, IEnumerable<Tuple<int[], string>> values)
        {
          var d = new Dictionary<string, List<string>>();
            var l = new List<string>();
            l.Add("java.util.List<general_service.Entry<int[], String>> " + id + " = new java.util.ArrayList<>();");
            foreach (var v in values)
            {
                var n = v.Item1;
                var s = id + ".add(new general_service.Entry(new int[] {" + n[0] + ", " + n[1] + "}, \"" + v.Item2 + "\" ));";
                l.Add(s);
            }
            d["code"] = l;
            return d;
        }
    }
}
