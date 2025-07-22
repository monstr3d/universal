using Diagram.Attributes;
using Diagram.Interfaces;
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

        static FormulaEditor.Performer formulaPerformer = new FormulaEditor.Performer();
        

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

        static void AddPost(List<string> l)
        {
            l.Add("postSetArrow() : void {");
            l.Add("\tthis.init();");
            l.Add("}");

        }


        static List<string> CreateVectorConsumer(string preffix, object obj)
        {
            bool check = true;
            var v = obj as VectorFormulaConsumer;
            var dpf = new DataPerformerFormula(v);
            var mea = dpf.Output;
            ITreeCollection tc = v;
            ITreeCollectionCodeCreator treeCollectionCodeCreator = new TSTreeCollectionCodeCreator();
            var lt = treeCollectionCodeCreator.CreateCode(v, tc.Trees, preffix, "internal ",
            check);
            var add = treeCollectionCodeCreator as IAdditionalClassCodeCreator;
            List<string> l = new List<string>();
            var classes = add.AdditionalCode;
            if (classes.Count > 0)
            {
                l.Add("");
                l.Add("");
                formulaPerformer.Add(l, classes, 0);
                l.Add("");
                l.Add("");
            }
            var cs = performer.ClassString(preffix, "VectorFormulaConsumer");
            l.Add(cs);
            l.Add("{");
            performer.AddObjectConstructor(l);
            var la = performer.CreateTSAliasList("map", v);
            formulaPerformer.Add(l, la, 2);
            l.Add("\t\tthis.performer.setAliasMap(map, this);");
            bool beg = true;
            var feed = v.Feedback;
            la = performer.CreateMap<int>("feed", feed, "number");
            formulaPerformer.Add(l, la, 2);
            l.Add("\t\tthis.performer.copyMap(feed, this.feedback);");

            int dim = v.Dimension;
            var args = performer.CreateList("this.arguments", v.Arguments);
            formulaPerformer.Add(l, args, 2);
       //     l.Add("\t\tthis.performer.copyArray<string>(args, this.arguments);");
            la = performer.CreateMap<int>("ops", v.OperationNames, "number");
            formulaPerformer.Add(l, la, 2);
            l.Add("\t\tthis.performer.copyMap(ops, this.operationNames);");
            l.Add("\t}");
            l.Add("");
            formulaPerformer.Add(l, lt, 1);
            AddPost(l);
            l.Add("}");
            return l;
        }

    }
}
