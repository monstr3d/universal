using Diagram.Attributes;
using Diagram.UI;
using Diagram.UI.Interfaces;

namespace DataPerformer.Formula.TypeScript
{
    /// <summary>
    /// Creator of TS code
    /// </summary>
    [Language("TS")]
    internal class TSCodeCreator : IClassCodeCreator
    {
        static  Diagram.TypeScript.Performer performer = new Diagram.TypeScript.Performer();
        static Performer perf = new();

        #region Ctor
        internal TSCodeCreator()
        {
            this.AddCodeCreator();
        }
        #endregion

        static readonly Dictionary<Func<object, bool>, Func<string, object, List<string>>> dictionary =
         new Dictionary<Func<object, bool>, Func<string, object, List<string>>>()
         {
                   { (object o) => { return o is VectorFormulaConsumer; } , CreateVectorConsumer },
             //    { (object o) => { return o is DifferentialEquationSolver; } , CreateDiffrerentialSolver },
                 { (object o) => { return o is Recursive; } , CreateRecursive },
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
            return null;
        }

        static List<string> CreateRecursive(string preffix, object obj)
        {
            List<string> l = new List<string>();
            var s = performer.ClassString(preffix, "Recursive");
            l.Add(s);
            l.Add("{");
            performer.AddObjectConstructor(l);
            l.Add("\t}");
            l.Add("}");
            return l;
        }


        static List<string> CreateVectorConsumer(string preffix, object obj)
        {

            var vc = obj as VectorFormulaConsumer;
            List<string> l = new List<string>();
            var s = performer.ClassString(preffix, "VectorFormulaConsumer");
            l.Add(s);
            l.Add("{");
            performer.AddObjectConstructor(l);
            var la = perf.CreateTSAliasList("map", vc);
            foreach (var k in la)
            {
                l.Add("\t\t" + k);
            }
            l.Add("\t\tthis.performer.SetAliasMap(map, this);");
            l.Add("\t}");
            l.Add("}");
            return l;
        }

    }
}
