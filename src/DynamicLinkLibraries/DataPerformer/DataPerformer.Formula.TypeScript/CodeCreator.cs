using DataPerformer.Interfaces;
using Diagram.UI.Attributes;
using FormulaEditor;
using FormulaEditor.CodeCreators;
using FormulaEditor.CodeCreators.Interfaces;
using FormulaEditor.CSharp;
using FormulaEditor.Interfaces;
using System.Text;

namespace DataPerformer.Formula.TypeScript
{


    public class CodeCreator : Diagram.TypeScript.CodeCreator, ITreeCollectionCodeCreator
    {
        public CodeCreator() : base(false) { }

        #region Fields
        
        static Diagram.UI.TypeScript.Performer performer = new();


        protected Dictionary<string, int> Output
        {
            get;
            set;
        }

        protected object Object
        {
            get;
            set;
        }

        private static ITreeCodeCreator codeCreator = TypeScript.TreeCodeCreator.CodeCreator;

        /// <summary>
        /// Local code creator
        /// </summary>
        protected ITreeCodeCreator local;

        protected ITreeCollection collection = null;

        ObjectFormulaTree[] trees;

        protected Func<object, bool> checkValue;


        protected string code;


#endregion


        #region ITreeCalculatorCodeCreator Members

        Dictionary<string, List<string>> ITreeCollectionCodeCreator.CreateCode(object obj, ObjectFormulaTree[] trees,
            string className, string constructorModifier, bool checkValue)
        {
            Object = obj;
            this.trees = trees;
            IList<string> variables;
            IList<string> initializers;
            List<string> l = new List<string>();
            //          l.Add(" : FormulaEditor.Interfaces.ITreeCollectionProxy");
            //        local = null;
            var lt = PreCreateCode(obj, out local, out variables, out initializers, className);
            List<string> ltt = PostCreateCode(local, obj, lt, variables, initializers,
                         constructorModifier + " " + className,
                         checkValue);
            var ltr = local.Trees;
            performer.Add(l, ltt, 0);
            var output = new Dictionary<string, Tuple<int, object>>();
            if (obj is IStringTreeDictionary dictionary)
            {
                output = DataPerformerFormula.GetOutput(dictionary, ltr);
            }
            else if (obj is IMeasurements mm)
            {
                output = DataPerformerFormula.GetOutput(mm, ltr);
            }
            var ll = new List<string>();
            ll.Add("save() : void {");
            var s = "\tvar v = this.variables;";
            var attr = performer.GetAttribute<CodeCreatorAttribute>(obj);
            if (attr != null)
            {
                if (attr.IsSysemOfDifferentialEquations)
                {
                    s = "\tvar v = this.derivations;";
                }
            }
            ll.Add(s);
            var mea = obj as IMeasurements;
            var kk = 0;
            foreach (var k in output)
            {
                var st = "x" + kk;
                ++kk;
                ll.Add("\tvar " + st + " = v.get(" + "\"" + k.Key + "\");");
                ll.Add("\t" + st + "?.setIValue(this.get_" + k.Value.Item1 + "());");
            }
            ll.Add("}");
            l.AddRange(ll);
            l.Add("");
            var d = new Dictionary<string, List<string>>();
            d["code"] = l;
            return d;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Creator of code
        /// </summary>
        public static ITreeCodeCreator TreeCodeCreator
        {
            get
            {
                return codeCreator;
            }
            set
            {
                codeCreator = value;
            }
        }

        #endregion

        #region Protected Members

        /// <summary>
        /// Proxy
        /// </summary>
        public object IAliasName { get; private set; }

        #endregion

        #region Private Members

        private List<string> PostCreateCode(ITreeCodeCreator local, object ob, IList<string> lcode,
           IList<string> variables, IList<string> initializers, string consturctor, bool checkValue = true)
        {
            List<string> l = new();
            performer.Add(l, lcode as List<string>, 1);
            int nTree = local.Trees.Length;
            l.Add("");
            if (checkValue)
            {
            }
            else
            {
                l.Add(consturctor + "(FormulaEditor.ObjectFormulaTree[] trees)");
                l.Add("{");
                l.Add("\tthis.trees = trees;");
            }
            l.Add("init() : void");
            l.Add("{");
            if (ob is IMeasurements)
            {
                l.Add("\tvar all = this.getAllMeasurements();");
            }
            performer.Add(l, initializers as List<string>, 1);
            l.Add("}");
            l.Add("");
            foreach (string s in variables)
            {
                l.Add("" + s);
            }
            if (checkValue)
            {
            }
            return l;
        }

        private List<string> PreCreateCode(object obj, out ITreeCodeCreator local,
             out IList<string> variables, out IList<string> initializers, string current)
        {
            var lcode = TypeScript.TreeCodeCreator.CreateCode(obj, trees, codeCreator,
                out local, out variables, out initializers, current);
            ObjectFormulaTree[] tr = local.Trees;
            foreach (ObjectFormulaTree tree in tr)
            {
                AddTree(tree, initializers, variables);
            }
            if (checkValue != null)
            {
            }
            var l = new List<string>();
            l.Add("calculateTree() : void");
            l.Add("{");
            l.Add("\tthis.success = true;");
            performer.Add(l, lcode as List<string>, 1);
            l.Add("}");
            return l;
        }

        private void CreateCode(object obj, string current)
        {
            IList<string> variables;
            IList<string> initializers;
            List<string> l = new List<string>();
            l.Add(CSharpCodeCreator.StandardHeader);
            l.Add(CSharpCodeCreator.GetGuidClass(new Type[] { typeof(ITreeCollectionProxy) }));
            local = null;
            IList<string> lt = PreCreateCode(obj, out local, out variables, out initializers, current);
            l.Add("\t\t");
            List<string> ltt = PostCreateCode(local, obj, lt, variables, initializers, "public Calculate", checkValue != null);
            StringBuilder sb = new StringBuilder();
            foreach (string s in ltt)
            {
                l.Add("\t\t" + s);
            }
            l.Add("");
            l.Add("\t}");
            l.Add("}");
            foreach (string s in l)
            {
                sb.Append(s + Environment.NewLine);
            }
            code = sb + "";
        }

        private void AddTree(ObjectFormulaTree tree, IList<string> init, IList<string> func)
        {
            int n = StaticCodeCreator.GetNumber(local, tree);
            string tid = local[tree];
            string f = "get_" + n;
            // init.Add("this.mapOperations.set(" + n + ", this." + f + ");");
            func.Add("");
            func.Add(f + "() : any");
            func.Add("{");
            func.Add("\treturn this.success ? this." + tid + " : undefined;");
            func.Add("}");
        }

        #endregion

    }
}
