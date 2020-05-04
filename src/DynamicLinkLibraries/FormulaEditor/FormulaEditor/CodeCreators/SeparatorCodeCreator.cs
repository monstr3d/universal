﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormulaEditor.Interfaces;
using BaseTypes.Interfaces;

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
        public override IList<string> CreateCode(ObjectFormulaTree tree, string ret, 
            string[] parameters, out IList<string> variables, out IList<string> initializers)
        {
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
                variables = null;
                initializers = null;
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
                    initializers = new List<string>()
                   {
                       "measurement" + sp + " = " +
                        "DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees["
                        + k + "]);"
                   };
                    variables = new List<string>()
                   {
                       "DataPerformer.Interfaces.IMeasurement measurement" + sp + ";"
                   };
                    string str = ret + " = " + st + "measurement" + sp + sep[1];
                    return new List<string>() { str };
                }
                if (sep[0].Equals(" = aliasName") & sep[1].Equals(".Value;"))
                {
                    string str = ret + " = " + st + "aliasName" + sp + sep[1];
                   initializers = new List<string>()
                   {
                       "aliasName" + sp + " = " +  
                        "DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[" 
                        + k + "]);"
                   };
                    variables = new List<string>()
                   {
                       "Diagram.UI.Interfaces.IAliasName aliasName" + sp + ";"
                   };
                    return new List<string>() { str };
                }
            }
            variables = new List<string>();
            initializers = new List<string>();

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
            return l;
        }

        #endregion

    



    }
}
