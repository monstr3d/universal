using Diagram.Attributes;
using Diagram.UI;
using Diagram.UI.Interfaces;
using FormulaEditor.Interfaces;

namespace DataPerformer.Formula.TypeScript
{
    /// <summary>
    /// Creator of TS code
    /// </summary>
    [Language("TS")]
    internal class TSCodeCreator : IClassCodeCreator
    {
        static ITreeCollectionCodeCreator treeCollectionCodeCreator = new TSTreeCollectionCodeCreator();
        

        static Diagram.TypeScript.Performer performer = new ();
   
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
            bool check = true;
            var v = obj as VectorFormulaConsumer;
            List<string> l = new List<string>();
            var cs = performer.ClassString(preffix, "VectorFormulaConsumer");
            l.Add(cs);
            l.Add("{");
            performer.AddObjectConstructor(l);
            var la = performer.CreateTSAliasList("map", v);
            performer.Add(l, la, 2);
            l.Add("\t\tthis.performer.SetAliasMap(map, this);");
            bool beg = true;
            var feed = v.Feedback;
            la = performer.CreateMap<int>("feed", feed, "number");
            performer.Add(l, la, 2);
            l.Add("\t\tthis.performer.copyMap(feed, this.feedback);");

            int dim = v.Dimension;
            /*      
                  l.Add("\t\tformulaString = new string[]");
                  List<string> lf = new List<string>();
                  for (int i = 0; i < dim; i++)
                  {
                      string sf = v.GetFormula(i);
                      sf = sf.Replace("\r", "");
                      sf = sf.Replace("\n", "");
                      sf = sf.Replace("\"", "\\\"");
                      lf.Add(sf);
                  }
                  List<string> lt = lf.GetCSharpCodeArray();
                  foreach (string s in lt)
                  {
                      l.Add("\t\t" + s);
                  }
                  l.Add("\t\tisSerialized = true;");
                  l.Add("\t\tcalculateDerivation = " + v.CalculateDerivation.StringValue() + ";");
                  l.Add("\t\tderiOrder = " + v.DerivationOrder + ";");
                  l.Add("\t\targuments =  new List<string>()");
                  List<string> args = v.Arguments.GetCSharpCodeArray();

                  foreach (string s in args)
                  {
                      l.Add("\t\t" + s);
                  }
          //        lt = v.CreateCSharpAliasList();
                  l.Add("\t\tparameters =" + lt[0]);
                  for (int i = 1; i < lt.Count; i++)
                  {
                      l.Add("\t\t" + lt[i]);
                  }*/
            var args = performer.CreateList("this.arguments", v.Arguments);
            performer.Add(l, args, 2);
       //     l.Add("\t\tthis.performer.copyArray<string>(args, this.arguments);");
            la = performer.CreateMap<int>("ops", v.OperationNames, "number");
            performer.Add(l, la, 2);
            l.Add("\t\tthis.performer.copyMap(ops, this.operationNames);");
            l.Add("\t}");
            l.Add("");
          /*
            


            l.Add("\tcalculateTree(): void");
            l.Add("\t{");
            ITreeCollection tc = v;
            ITreeCollectionCodeCreator treeCollectionCodeCreator = new TSTreeCollectionCodeCreator();
            var lt = treeCollectionCodeCreator.CreateCode(tc.Trees, "Calculation", "internal ",
            check);
            performer.Add(l, lt, 2);
            l.Add("\t}");
          */
            l.Add("}");
            return l;
        }

    }
}
