using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormulaEditor;
using System.CodeDom.Compiler;
using System.Reflection;

using BaseTypes;

using FormulaEditor.Interfaces;
using FormulaEditor.CodeCreators;

namespace FormulaEditor.CSharp
{
    /// <summary>
    /// C# proxy factory
    /// </summary>
    public abstract class CSharpTreeCollectionProxyFactory : ITreeCollectionProxyFactory,
        ITreeCollectionCodeCreator
    {

        #region Fields

        private static ICodeCreator codeCreator;

        /// <summary>
        /// Local code creator
        /// </summary>
        protected ICodeCreator local;

        protected ITreeCollection collection = null;

        ObjectFormulaTree[] trees;

        protected Action<object> checkValue;


        protected string code;

        private static readonly object CSharpExtendedCodeCreator;

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

        ITreeCollectionProxy ITreeCollectionProxyFactory.CreateProxy(ITreeCollection collection, Action<object> checkValue)
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
            CreateCode();
            return Proxy;
        }

        #endregion

        #region ITreeCalculatorCodeCreator Members

        List<string> ITreeCollectionCodeCreator.CreateCode(ObjectFormulaTree[] trees, 
            string className, string constructorModifier, bool checkValue)
        {
            IList<string> variables;
            IList<string> initializers;
            List<string> l = new List<string>();
            l.Add(" : FormulaEditor.Interfaces.ITreeCollectionProxy");
            l.Add("{");

            IList<string> lt = PreCreateCode(out local, out variables, out initializers);
            /*foreach (string s in initializers)
            {
                l.Add("\t\t" + s);
            }*/

            //l.Add((CSharpCodeCreator.GetGuidClass(new Type[] { typeof(ITreeCollectionProxy) })));
            List<string> ltt = PostCreateCode(local, lt, variables, initializers, 
                constructorModifier + " " + className, 
                checkValue);
            //         CSharpCodeCreator.GetGuidClass(new Type[] { typeof(ITreeCollectionProxy) }));
            foreach (string s in ltt)
            {
                l.Add("\t" + s);
            }
            l.Add("");
            l.Add("}");
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
        protected abstract ITreeCollectionProxy Proxy
        {
            get;
        }
        public object IAliasName { get; private set; }

        #endregion


        #region Private Members

        private List<string> PostCreateCode(ICodeCreator local, IList<string> lcode,
           IList<string> variables, IList<string> initializers, string consturctor, bool checkValue = false)
        {
            List<string> l = new List<string>();
            l.Add("public void Update()");
            l.Add("{");
            foreach (string s in lcode)
            {
                l.Add("\t" + s);
            }
            // StaticCodeCreator.Add(sb, lcode);
            int nTree = local.Trees.Length;
            if (checkValue)
            {
                for (int i = 0; i < nTree; i++)
                {
                    l.Add("\tcheckValue(var_" + i + ");");
                }
            }
            l.Add("}");
            l.Add("");
            if (checkValue)
            {
                l.Add(consturctor + "(FormulaEditor.ObjectFormulaTree[] trees, BaseTypes.ObjectAction checkValue)");
                l.Add("{");
                l.Add("\tthis.trees = trees;");
                l.Add("\tthis.checkValue = checkValue;");
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
            l.Add("public FormulaEditor.GetValue this[FormulaEditor.ObjectFormulaTree tree]");
            l.Add("{ get { return dictionary[tree]; }}");
            l.Add("");
            l.Add("Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue> dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue>();");
            l.Add("");
            foreach (string s in variables)
            {
                l.Add("" + s);
            }
            if (checkValue)
            {
                l.Add("");
                l.Add("BaseTypes.ObjectAction checkValue;");
            }
           // l.Add("\t}");
            return l;
        }

        private IList<string> PreCreateCode(out ICodeCreator local,
             out IList<string> variables, out IList<string> initializers)
        {
            IList<string> lcode = CSharpCodeCreator.CreateCode(trees, codeCreator, 
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

        private void CreateCode()
        {
            IList<string> variables;
            IList<string> initializers;
            List<string> l = new List<string>();
            l.Add(CSharpCodeCreator.StandardHeader);
            l.Add(CSharpCodeCreator.GetGuidClass(new Type[] { typeof(ITreeCollectionProxy) }));
            IList<string> lt = PreCreateCode(out local, out variables, out initializers);
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
            func.Add("\treturn " + tid + ";");
            func.Add("}");
        }

        #endregion

    }
}