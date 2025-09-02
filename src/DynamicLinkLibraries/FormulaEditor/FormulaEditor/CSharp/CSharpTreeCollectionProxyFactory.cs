using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes;

using FormulaEditor.Interfaces;
using FormulaEditor.CodeCreators;
using FormulaEditor.CodeCreators.Interfaces;

namespace FormulaEditor.CSharp
{
    /// <summary>
    /// C# proxy factory
    /// </summary>
    public abstract class CSharpTreeCollectionProxyFactory : ITreeCollectionProxyFactory,
        ITreeCollectionCodeCreator
    {

        #region Fields

        private static ITreeCodeCreator codeCreator;

        /// <summary>
        /// Local code creator
        /// </summary>
        protected ITreeCodeCreator local;

        protected ITreeCollection collection = null;

        ObjectFormulaTree[] trees;

        protected Func<object, bool> checkValue;


        protected string code;

     
        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        protected CSharpTreeCollectionProxyFactory()
        {
            
        }

        #endregion

        #region ITreeCollectionProxyFactory Members

        ITreeCollectionProxy ITreeCollectionProxyFactory.CreateProxy(ITreeCollection collection, Func<object, bool> checkValue)
        {
            this.collection = collection;
            this.checkValue = checkValue;
            List<ObjectFormulaTree> lt = new List<ObjectFormulaTree>();
            ObjectFormulaTree[] tt = collection.Trees;
            foreach (ObjectFormulaTree t in tt)
            {
                if (t.ReturnType.IsEmpty())
                {
                    continue;
                }
                lt.Add(t);
            }
            trees = lt.ToArray();
            CreateCode(collection);
            return Proxy;
        }

        #endregion

        #region ITreeCalculatorCodeCreator Members

        Dictionary<string, List<string>> ITreeCollectionCodeCreator.CreateCode(object obj, ObjectFormulaTree[] trees, 
            string className, string constructorModifier, bool checkValue)
        {
            this.trees = trees;
            IList<string> variables;
            IList<string> initializers;
            List<string> l = new List<string>();
            l.Add(" : FormulaEditor.Interfaces.ITreeCollectionProxy");
            l.Add("{");
            local = null;
            IList<string> lt = PreCreateCode(obj, out local, out variables, out initializers);
            List<string> ltt = PostCreateCode(local, lt, variables, initializers, 
                constructorModifier + " " + className, 
                checkValue);
            foreach (string s in ltt)
            {
                l.Add("\t" + s);
            }
            l.Add("");
            l.Add("}");
            var d = new Dictionary<string, List<string>>();
            d["code"] = l;
            return d;
       }

        #endregion

        #region Public Members

        /// <summary>
        /// Creator of code
        /// </summary>
        public static ITreeCodeCreator CodeCreator
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
        protected abstract ITreeCollectionProxy Proxy
        {
            get;
        }
        public object IAliasName { get; private set; }

        #endregion

        #region Private Members

        private List<string> PostCreateCode(ITreeCodeCreator local, IList<string> lcode,
           IList<string> variables, IList<string> initializers, string consturctor, bool checkValue = true)
        {
            List<string> l = new()
            {
                "public bool Success { get => success; }",
                "",
                "public void Update()",
                "{",
                "\tsuccess = true;",
            };
            foreach (string s in lcode)
            {
                l.Add("\t" + s);
            }
            // StaticCodeCreator.Add(sb, lcode);
            int nTree = local.Trees.Length;
            if (checkValue)
            {
            /*    for (int i = 0; i < nTree; i++)
                {
                    l.Add("\tcheckValue(var_" + i + ");");
                */
            }
            l.Add("}");
            l.Add("");
            if (checkValue)
            {
                l.Add(consturctor + "(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)");
                l.Add("{");
                l.Add("\tsuccess = true;");
                l.Add("\tthis.trees = trees;");
                l.Add("\tthis.checkValue = checkValue;");
                l.Add("\tthis.dataPerformerFormula = dataPerformerFormula;");
            }
            else
            {
                l.Add(consturctor + "(FormulaEditor.ObjectFormulaTree[] trees)");
                l.Add("{");
                l.Add("\tthis.trees = trees;");
            }
            foreach (string s in initializers)
            {
                l.Add("\t" + s);
            } 
            l.Add("}");
            l.Add("");
            l.Add("public Func<object> this[FormulaEditor.ObjectFormulaTree tree]");
            l.Add("{ get { return dictionary[tree]; }}");
            l.Add("");
            l.Add("Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();");
            l.Add("");
            foreach (string s in variables)
            {
                l.Add("" + s);
            }
            if (checkValue)
            {
                l.Add("");
                l.Add("Func<object, bool> checkValue = (o) => false;");
                l.Add("object variable;");
                l.Add("bool success = true;");
                l.Add("DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = null;");

            }
            // l.Add("\t}");
            return l;
        }

        private IList<string> PreCreateCode(object obj, out ITreeCodeCreator local,
             out IList<string> variables, out IList<string> initializers)
        {
            IList<string> lcode = CSharpCodeCreator.CreateCode(obj, trees, codeCreator, 
                out local, out variables, out initializers);
            ObjectFormulaTree[] tr = local.Trees;
            foreach (ObjectFormulaTree tree in tr)
            {
                AddTree(tree, initializers, variables);
            }
            if (checkValue != null)
            {
            }
            return lcode;
        }

        private void CreateCode(object obj)
        {
            IList<string> variables;
            IList<string> initializers;
            List<string> l = new List<string>();
            l.Add(CSharpCodeCreator.StandardHeader);
            l.Add(CSharpCodeCreator.GetGuidClass(new Type[] { typeof(ITreeCollectionProxy) }));
            local = null;
            IList<string> lt = PreCreateCode(obj, out local, out variables, out initializers);
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
            string f = "Get_" + n;
            init.Add("dictionary[trees[" + n + "]] = " + f + ";");
            func.Add("");
            func.Add("object " + f + "()");
            func.Add("{");
            func.Add("\treturn success ? " + tid + " : null;");
            func.Add("}");
        }

        #endregion

    }
}