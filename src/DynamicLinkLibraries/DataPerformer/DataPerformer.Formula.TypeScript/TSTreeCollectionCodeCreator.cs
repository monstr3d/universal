using System.Text;
using Diagram.Interfaces;
using FormulaEditor;
using FormulaEditor.CodeCreators;
using FormulaEditor.CSharp;
using FormulaEditor.Interfaces;

namespace DataPerformer.Formula.TypeScript
{
    internal class TSTreeCollectionCodeCreator : ITreeCollectionCodeCreator, IAdditionalClassCodeCreator
    {

        #region Fields

    static FormulaEditor.Performer  formulaPerformer = new FormulaEditor.Performer();


        Diagram.TypeScript.Performer performer = new();
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

        private static ICodeCreator codeCreator = TypeScriptCodeCreator.CodeCreator;

        /// <summary>
        /// Local code creator
        /// </summary>
        protected ICodeCreator local;

        protected ITreeCollection collection = null;

        ObjectFormulaTree[] trees;

        protected Func<object, bool> checkValue;

        List<string> classes;


        protected string code;


        #endregion


        #region ITreeCalculatorCodeCreator Members

        List<string> ITreeCollectionCodeCreator.CreateCode(object obj, ObjectFormulaTree[] trees,
            string className, string constructorModifier, bool checkValue)
        {
            Object = obj;
            this.trees = trees;
            IList<string> variables;
            IList<string> initializers;
            List<string> l = new List<string>();
            //          l.Add(" : FormulaEditor.Interfaces.ITreeCollectionProxy");
            //        local = null;
            var lt = PreCreateCode(obj, out local, out variables, out initializers, out classes, className);
           List<string> ltt = PostCreateCode(local, lt, variables, initializers,
                        constructorModifier + " " + className,
                        checkValue);
            formulaPerformer.Add(l, ltt, 0);
            l.Add("");
            return l;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Creator of code
        /// </summary>
        public static ICodeCreator CodeCreator
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

        List<string> IAdditionalClassCodeCreator.AdditionalCode => classes;

        #endregion


        #region Private Members

        private List<string> PostCreateCode(ICodeCreator local, IList<string> lcode,
           IList<string> variables, IList<string> initializers, string consturctor, bool checkValue = true)
        {
            List<string> l = new();
            formulaPerformer.Add(l, lcode as List<string>, 1);
            int nTree = local.Trees.Length;
            if (checkValue)
            {
                /*    for (int i = 0; i < nTree; i++)
                    {
                        l.Add("\tcheckValue(var_" + i + ");");
                    */
            }
       //     l.Add("}");
            l.Add("");
            if (checkValue)
            {
              /*  l.Add(consturctor + "(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)");
                l.Add("{");
                l.Add("\tsuccess = true;");
                l.Add("\tthis.trees = trees;");
                l.Add("\tthis.checkValue = checkValue;");
                l.Add("\tthis.dataPerformerFormula = dataPerformerFormula;");
              */
            }
            else
            {
                l.Add(consturctor + "(FormulaEditor.ObjectFormulaTree[] trees)");
                l.Add("{");
                l.Add("\tthis.trees = trees;");
            }
            l.Add("init() : void");
            l.Add("{");
            formulaPerformer.Add(l, initializers as List<string>, 1);
            l.Add("}");
      /*      l.Add("");
            l.Add("public Func<object> this[FormulaEditor.ObjectFormulaTree tree]");
            l.Add("{ get { return dictionary[tree]; }}");
            l.Add("");
            l.Add("Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();");
            l.Add("");*/
            foreach (string s in variables)
            {
                l.Add("" + s);
            }
            if (checkValue)
            {
            }
            // l.Add("\t}");
            return l;
        }

        private List<string> PreCreateCode(object obj, out ICodeCreator local,
             out IList<string> variables, out IList<string> initializers, out List<string> classes, string current)
        {
            var lcode = TypeScriptCodeCreator.CreateCode(obj, trees, codeCreator,
                out local, out variables, out initializers, out classes, current);
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
            formulaPerformer.Add(l, lcode as List<string>, 1);
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
            IList<string> lt = PreCreateCode(obj, out local, out variables, out initializers, out classes, current);
            l.Add("\t\t");
            List<string> ltt = PostCreateCode(local, lt, variables, initializers, "public Calculate", checkValue != null);
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
