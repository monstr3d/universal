using BaseTypes.Attributes;
using Diagram.UI;
using Diagram.UI.CodeCreators.Interfaces;
using Diagram.UI.Interfaces;

namespace Gravity_36_36.Wrapper.TypeScript
{
    [Language("TS")]
    internal class ClassCodeCreator : IClassCodeCreator
    {


        static Diagram.UI.TypeScript.Performer performer = new();

        internal ClassCodeCreator()
        {
            this.AddClassCodeCreator();
        }


        protected IDesktopCodeCreator DesktopCodeCreator
        { get; set; }


        List<string> IClassCodeCreator.CreateCode(string preffix, object obj, string volume)
        {
            if (obj is  Gravity gravity)
            {
                var l = CreateObjectTransformer(preffix, gravity);
                return l;
            }
            return null;

        }

        protected virtual string BaseClassString(string prefix, object obj)
        {
            return obj.GetType().Name;
        }

        static List<string> CreateObjectTransformer(string preffix, Gravity gravity)
        {
            var n0 = gravity.N0 + "";
            var nk = gravity.NK + "";
            var l = new List<string>();

            var s = performer.ClassString(preffix, "GravityCategoryObject");
            l.Add(s);
            l.Add("{");
            performer.AddObjectConstructor(l);
            var ll = new List<string>() {

               "\tthis.SetN0(" + n0 + ");",
               "\tthis.SetNK(" + nk + ");",
                };
            performer.Add(l, ll, 0);

            var value = gravity.Saver;
            int k = 0;
            var R = value[k] as double[]; ++k;
            var C = value[k] as double[]; ++k;
            var S = value[k] as double[]; ++k;
            var HP = value[k] as double[]; ++k;
            var CO = value[k] as double[]; ++k;
            var SI = value[k] as double[]; ++k;
            var AR = value[k] as double[]; ++k;
            var CF = value[k] as double[]; ++k;
            var PNK = value[k] as double[]; ++k;
            var ANAI = value[k] as double[]; ++k;
            performer.Add(l, Get("R", R), 1);
            performer.Add(l, Get("C", C), 1);
            performer.Add(l, Get("S", S), 1);
            performer.Add(l, Get("HP", HP), 1);
            performer.Add(l, Get("CO", CO), 1);
            performer.Add(l, Get("SI", SI), 1);
            performer.Add(l, Get("AR", AR), 1);
            performer.Add(l, Get("CF", CF), 1);
            performer.Add(l, Get("PNK", PNK), 1);
            performer.Add(l, Get("ANAI", ANAI), 1);
            l.Add("}");
            l.Add("}");
            return l;
        }


        public static List<string> Get(string id, double[] x)
        {
            var l = new List<string>();
            var r = "\tthis." + id; 
            l.Add(r + " = [];");
            foreach (var v in x)
            {
                var s = performer.DoubleToString(v);
                l.Add(r + ".push(" + s + ");");
            }
            l.Add("");
            return l;
        }
    }
}

