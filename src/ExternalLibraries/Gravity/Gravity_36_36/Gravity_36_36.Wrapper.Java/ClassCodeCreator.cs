using BaseTypes.Attributes;
using Diagram.UI;

namespace Gravity_36_36.Wrapper.Java
{
    [Language("Java")]
    internal class ClassCodeCreator : Diagram.Java.ClassCodeCreator
    {
        internal ClassCodeCreator() : base(false)
        {
            this.AddClassCodeCreator();
            dictionary = new Dictionary<Func<object, bool>, Func<string, object, List<string>>>()
         {
                   { (object o) => { return o is Gravity; } , CreateGravity }
              };

            classes = new Dictionary<string, string>()
            {
                {"Gravity", "external.gravity.Gravity36x36Transformer" }
            };
        }




        List<string> CreateGravity(string preffix, object obj)
        {
            var gr = obj as Gravity;
            var n0 = gr.N0 + "";
            var nk = gr.NK + "";
            var l = new List<string>() {

               "\tsetN0(" + n0 + ");",
               "\tsetNK(" + nk + ");",
                };
            var value = gr.Saver;
            int k = 0;
            var R = value[k] as double[]; ++k;
            var C = value[k] as double[]; ++k;
            var S = value[k] as double[]; ++k;
            var HP = value[k] as double[]; ++k;
            var CO = value[k] as double[]; ++k;
            var  SI = value[k] as double[]; ++k;
            var AR = value[k] as double[]; ++k;
            var  CF = value[k] as double[]; ++k;
            var PNK = value[k] as double[]; ++k;
            var ANAI = value[k] as double[]; ++k;
            Performer.Add(l, Get("R", R), 1);
            Performer.Add(l, Get("C", C), 1);
            Performer.Add(l, Get("S", S), 1);
            Performer.Add(l, Get("HP", HP), 1);
            Performer.Add(l, Get("CO", CO), 1);
            Performer.Add(l, Get("SI", SI), 1);
            Performer.Add(l, Get("AR", AR), 1);
            Performer.Add(l, Get("CF", CF), 1);
            Performer.Add(l, Get("PNK", PNK), 1);
            Performer.Add(l, Get("ANAI", ANAI), 1);
            l.Add("}");
            l.Add("}");
            return l;
        }

        public List<string> Get(string id, double[] x)
        {
            var l = new List<string>();
            l.Add("\t" + id + " = new double[] {");
            var ll = Performer.GetStrings(x);
            Performer.Add(l, ll, 2);
            l.Add("};");
            l.Add("");
            return l;
        }
    }
}
