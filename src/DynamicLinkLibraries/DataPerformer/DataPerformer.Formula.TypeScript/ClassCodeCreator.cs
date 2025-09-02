using BaseTypes.Attributes;
using BaseTypes.CodeCreator.Interfaces;
 
using DataPerformer.Interfaces;

using Diagram.UI;
using Diagram.UI.CodeCreators.Interfaces;
using Diagram.UI.Interfaces;

using FormulaEditor.Interfaces;

namespace DataPerformer.Formula.TypeScript
{
    /// <summary>
    /// Creator of TS code
    /// </summary>
    [Language("TS")]
    internal class ClassCodeCreator : IClassCodeCreator
    {

       static internal CodeCreator CodeCreator
        {
            get;
        } = new CodeCreator();


    
        protected virtual string BaseClassString(string prefix, object obj)
        {
            return obj.GetType().Name;
        }






        static Diagram.UI.TypeScript.Performer performer = new();

        #region Ctor
        internal ClassCodeCreator()
        {
           this.AddClassCodeCreator();
            typeCreator = CodeCreator;
        }

        #endregion

        static readonly Dictionary<Func<object, bool>, Func<string, object, CodeCreator, List<string>>> dictionary =
         new Dictionary<Func<object, bool>, Func<string, object, CodeCreator, List<string>>>()
         {
                   { (object o) => { return o is VectorFormulaConsumer; } , CreateVectorConsumer },
                 { (object o) => { return o is DifferentialEquationSolver; } , CreateDifferentialSolver },
                 { (object o) => { return o is Recursive; } , CreateRecursive },
          };


        protected IDesktopCodeCreator DesktopCodeCreator
        { get; set; }



        List<string> IClassCodeCreator.CreateCode(string preffix, object obj, string volume)
        {
            foreach (Func<object, bool> key in dictionary.Keys)
            {
                if (key(obj))
                {
                    return dictionary[key](preffix, obj, CodeCreator);
                }
            }
            return null;
        }

        public static string SClassString(string preffix, object obj)
        {

            var s = "class " + preffix;
            var extends = "";
            switch (obj)
            {
                case Recursive:
                    extends = "RecursiveFormula";
                    break;
                case VectorFormulaConsumer:
                    extends = "VectorFormulaConsumer";
                    break;
                case DifferentialEquationSolver:
                    extends = "DifferentialEquationSolverFormula";
                    break;
                default:
                    throw new ErrorHandler.OwnNotImplemented();
            }
            if (extends != null)
            {
                s += " extends " + extends;
            }
            return s;
        }

        static ITypeCreator typeCreator;

        public static List<string> CreateTSVariableList(IMeasurements measurements)
        {
            var l = new List<string>();
            if (measurements is IStarted start)
            {
                start.Start(0);
            }
            var n = measurements.Count;
            for (int i = 0; i < n; i++)
            {
                var m = measurements[i];
                var name = "\"" + m.Name + "\"";
                var type = m.Type;
                var v = typeCreator.GetDefaultValue(type);
                var pr = m.Parameter();
                var st = performer.StringValue(pr);
                l.Add("this.addVariableValue(" + name + ", " + v + ", " + st + ");");

            }
            return l;
        }


        static List<string> CreateTreeCollection(string preffix, ITreeCollection obj, Diagram.TypeScript.CodeCreator creator)
        {
            var l = new List<string>();
            bool check = true;
            ITreeCollectionCodeCreator treeCollectionCodeCreator = CodeCreator;
            var lt = treeCollectionCodeCreator.CreateCode(obj, obj.Trees, preffix, "internal ", check);

            if (treeCollectionCodeCreator is IAdditionalClassCodeCreator add)
            {
                var classes = add.AdditionalCode;
                if (classes != null && classes.Count > 0)
                {
                    l.Add("");
                    l.Add("");
                    performer.Add(l, classes, 0);
                    l.Add("");
                    l.Add("");
                }
            }
            var cs = SClassString(preffix, obj);
            l.Add(cs);
            l.Add("{");
            performer.AddObjectConstructor(l);
            if (obj is IAlias ali)
            {
                var cc = creator as IAliasCodeCreator;
                var la = cc.Create("map", ali).Values.ToArray()[0];
                if (la.Count > 0)
                {
                    performer.Add(l, la, 2);
                }
                l.Add("\t\tthis.performer.setAliasMap(map, this);");
            }
            if (obj is IMeasurements m)
            {
                var la = CreateTSVariableList(m);
                performer.Add(l, la, 2);
            }


            if (obj is IInitialDictionary d) // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            {

                var dic = d.Dictionary;
                foreach (var k in dic)
                {
                    var iname = "\"" + k.Key + "\"";
                    // !!!!   l.Add("\t\tthis.initial.set(" + iname + ", " + k.Value + ");");
                }
            }
            l.Add("\t}");
            l.Add("");
            performer.Add(l, lt.Values.ToArray()[0], 1);
            AddPost(l);
            if (obj is IFeedbackCollectionHolder feedback)
            {
                var dcc = creator as IFeedbackCollectionCodeCreator;
                var ll = dcc.Create(feedback).Values.ToArray()[0];
                performer.Add(l, ll, 1);
            }

            l.Add("}");
            return l;
        }

        static List<string> CreateRecursive(string preffix, object obj, Diagram.TypeScript.CodeCreator cc)
        {
            return CreateTreeCollection(preffix, obj as ITreeCollection, cc);
        }


        static List<string> CreateDifferentialSolver(string preffix, object obj, Diagram.TypeScript.CodeCreator cc)
        {
            return CreateTreeCollection(preffix, obj as ITreeCollection, cc);
        }





        static void AddPost(List<string> l)
        {
            /*  l.Add("postSetArrow() : void {");
              l.Add("\tthis.init();");

              l.Add("}");
            */
        }


        static List<string> CreateVectorConsumer(string preffix, object obj, Diagram.TypeScript.CodeCreator cc)
        {
            return CreateTreeCollection(preffix, obj as ITreeCollection, cc);
        }

  
   

        public static Dictionary<string, List<string>> Create(string id, Dictionary<string, string> dictionary)
        {
            var l = new List<string>();
            l.Add("let " + id + " = new Map<string, string>(");
            int n = dictionary.Count;
            int i = 0;
            l.Add("[");
            if (n == 0)
            {
                l.Add("]);");
            }
            else
            {
                foreach (var t in dictionary)
                {
                    var s = "\t[\"" + t.Key + "\", \"" + t.Value + "\" ]";
                    if (i < (n - 1))
                    {
                        s += ',';
                    }
                    l.Add(s);
                    ++i;
                }
                l.Add("]);");
            }


            var d = new Dictionary<string, List<string>>();
            d["code"] = l;
            return d;
        }
 

    }
}