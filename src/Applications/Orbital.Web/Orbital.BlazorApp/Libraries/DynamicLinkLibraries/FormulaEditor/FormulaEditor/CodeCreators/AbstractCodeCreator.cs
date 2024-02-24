using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using FormulaEditor.Interfaces;
using BaseTypes.Interfaces;

namespace FormulaEditor.CodeCreators
{
    /// <summary>
    /// Abstract creator of code
    /// </summary>
    public abstract class AbstractCodeCreator : ICodeCreator
    {
        #region Fields

        /// <summary>
        /// Trees
        /// </summary>
        protected ObjectFormulaTree[] trees;

        /// <summary>
        /// Identificators of trees
        /// </summary>
        protected Dictionary<ObjectFormulaTree, string> ident =
            new Dictionary<ObjectFormulaTree, string>();

        /// <summary>
        /// Creators
        /// </summary>
        protected ICodeCreator[] creators;

        /// <summary>
        /// Creator
        /// </summary>
        protected ICodeCreator codeCreator;

        /// <summary>
        /// Optional operations
        /// </summary>
        protected List<ObjectFormulaTree> optional = new List<ObjectFormulaTree>();

        /// <summary>
        /// Dictionary
        /// </summary>
        protected Dictionary<ObjectFormulaTree, int> dictionary = 
            new Dictionary<ObjectFormulaTree, int>();

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="trr">Collection of trees</param>
        protected AbstractCodeCreator(ObjectFormulaTree[] trr)
        {
            codeCreator = this;
            ObjectFormulaTree[] t = trr;
            if (t == null)
            {
                t = new ObjectFormulaTree[0];
            }
            trees = ObjectFormulaTree.CreateList(t, optional).ToArray();
            int i = 0;
            foreach (ObjectFormulaTree tr in trees)
            {
                ident[tr] = "var_" + i;
                dictionary[tr] = i;
                ++i;
            }
        }

        #endregion

        #region ICodeCreator Members

        /// <summary>
        /// Creates Code from tree
        /// </summary>
        /// <param name="tree">The tree</param>
        /// <param name="ret">Return value</param>
        /// <param name="parameters">Parameters</param>
        /// <param name="variables">Variables</param>
        /// <param name="initializers">Initializers</param>
        /// <returns>List of code</returns>
        public virtual IList<string> CreateCode(ObjectFormulaTree tree, string ret,
            string[] parameters, out IList<string> variables,
            out IList<string> initializers)
        {
            variables = null;
            initializers = null;
            if (creators == null)
            {
                return null;
            }
            foreach (ICodeCreator cc in creators)
            {
                IList<string> l = cc.CreateCode(tree, ret, parameters, out variables, out initializers);
                if (l != null)
                {
                    return l;
                }
            }
            return null;
        }

        /// <summary>
        /// Identifier of tree
        /// </summary>
        public string this[ObjectFormulaTree tree]
        {
            get { return ident[tree]; }
        }

        /// <summary>
        /// Creates Creator
        /// </summary>
        /// <param name="trees">Trees</param>
        /// <returns>Creator</returns>
        public abstract ICodeCreator Create(ObjectFormulaTree[] trees);

        /// <summary>
        /// Trees
        /// </summary>
        public ObjectFormulaTree[] Trees
        {
            get { return trees; }
        }

        int ICodeCreator.GetNumber(ObjectFormulaTree tree)
        {
            return dictionary[tree];
        }

        /// <summary>
        /// Optional trees
        /// </summary>
        public List<ObjectFormulaTree> Optional
        {
            get { return optional; }
        }

        #region Abstract Members

        /// <summary>
        /// Gets constant string representation of value of tree 
        /// </summary>
        /// <param name="tree">The tree</param>
        /// <returns>String representation</returns>
        public abstract string GetConstValue(ObjectFormulaTree tree);

        /// <summary>
        /// Type creator
        /// </summary>
        protected abstract ITypeCreator TypeCreator
        {
            get;
        }

        #endregion

        #endregion
    }
}
