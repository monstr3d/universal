using System.Collections.Generic;
using System.Linq;
using FormulaEditor.CodeCreators.Interfaces;

namespace FormulaEditor.CodeCreators
{
    /// <summary>
    /// Creator of code from IOperationSeparatorCreator.
    /// </summary>
    public abstract class SeparatorCodeCreator : AbstractCodeCreator
    {
        #region

        /// <summary>
        /// Base separator creator
        /// </summary>
        protected IOperationSeparatorCreator separatorCreator;

        #endregion

        #region Ctor

        protected SeparatorCodeCreator() : base() 
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="trees">Trees</param>
        protected SeparatorCodeCreator(ObjectFormulaTree[] trees)
            : base(trees)
        {

        }

        #endregion

        #region Public Members

        /// <summary>
        /// Creates Code from tree
        /// </summary>
        /// <param name="tree">The tree</param>
        /// <param name="ret">Return value</param>
        /// <param name="parameters">Parameters</param>
        /// <param name="variables">Variables</param>
        /// <param name="initializers">Initializers</param>
        /// <returns>List of code</returns>
        protected override Dictionary<string, List<string>> CreateCode(object obj, ObjectFormulaTree tree, string ret, 
            string[] parameters)
        {
            var d = new Dictionary<string, List<string>>();
            /* !!!
            if (tree.Operation is OptionalOperation)
            {
                variables = null;
                initializers = null;
                return null;
            }
            //*/
            string[] sep = separatorCreator[tree];
            if (sep == null)
            {
                return null;
            }
            List<string> l = new List<string>();
            string tt = TypeCreator.GetType(tree.ReturnType);
            string st = "";
            if (!tt.Equals("object"))
            {
                st = "(" + tt + ")";
            }
            string sp = ret.Substring(4);
            int k = int.Parse(sp);
            if (sep.Length == 2)
            {
                string[] ss =  new string[] { " = measurement", ".Parameter();" };
                if (sep[0].Equals(ss[0]) & sep[1].Equals(ss[1]))
                {
                    var initializers = new List<string>()
                   {
                       "measurement" + sp + " = " +
                        "dataPerformerFormula.ToMeasurement(trees["
                        + k + "]);"
                   };
                    d["initializers"] = initializers;
                    
                    var variables = new List<string>()
                   {
                       "DataPerformer.Interfaces.IMeasurement measurement" + sp + ";"
                   };
                    d["variables"] = variables;
                    string[] str = new string[]
                        {
                        "variable = measurement" + sp + sep[1],
                               "if (checkValue(variable)) { success = false; return; }",
                          ret + " = " + st + "variable;"
                        };
                    d["code"] = str.ToList();
                    return d;
                }
                if (sep[0].Equals(" = aliasName") & sep[1].Equals(".Value;"))
                {
                    string[] str = new string[] {"variable = aliasName" + sp + sep[1],
                        "if (checkValue(variable)) { success = false; return; }",
                    ret + " = " + st + "variable;" };
                   var initializers = new List<string>()
                   {
                       "aliasName" + sp + " = " +
                        "dataPerformerFormula.ToAliasName(trees["
                        + k + "]);"
                   };
                    d["initializers"] = initializers;

                   var  variables = new List<string>()
                   {
                       "Diagram.UI.Interfaces.IAliasName aliasName" + sp + ";"
                   };
                    d["variables"] = variables;
                    d["code"] = str.ToList();
                    return d;
                }
            }
            string s = ret;
            int n = sep.Length;
            int m = parameters.Length;
            for (int i = 0; i < n; i++)
            {
                s += sep[i];
                if (i < m)
                {
                    s += parameters[i];
                }
            }
            l.Add(s);
            return new Dictionary<string, List<string>> { { "code", l } };
        }

        #endregion

    }
}
