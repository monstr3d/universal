using System;
using System.Collections.Generic;
using System.Linq;

using BaseTypes.CodeCreator.Interfaces;
using ErrorHandler;
using FormulaEditor.CodeCreators.Interfaces;

namespace FormulaEditor.CodeCreators
{
    /// <summary>
    /// Abstract creator of code
    /// </summary>
    public abstract class AbstractCodeCreator : ITreeCodeCreator
    {
        #region Fields



        /// <summary>
        /// Trees
        /// </summary>
        protected ObjectFormulaTree[] trees;

        /// <summary>
        /// Identifiers of trees
        /// </summary>
        protected Dictionary<ObjectFormulaTree, string> ident =
            new Dictionary<ObjectFormulaTree, string>();

        /// <summary>
        /// Creators
        /// </summary>
        protected ITreeCodeCreator[] creators;

        /// <summary>
        /// Creator
        /// </summary>
        protected ITreeCodeCreator codeCreator;

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

        protected AbstractCodeCreator()
        {
            codeCreator = this;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="trr">Collection of trees</param>
        protected AbstractCodeCreator(ObjectFormulaTree[] trr) : this()
        {
            Set(trr);
        }

        #endregion

        #region ICodeCreator Members

        /// <summary>
        /// Creates Code from tree
        /// </summary>
        /// <param name="tree">The tree</param>
        /// <param name="ret">Return value</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>List of code</returns>
        protected virtual Dictionary<string, List<string>> CreateCode(object obj, ObjectFormulaTree tree, string ret,
            string[] parameters)
        {
            if (creators == null)
            {
                return null;
            }
            foreach (var cc in creators)
            {
                var l = cc.CreateCode(obj, tree, ret, parameters);
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
        public abstract ITreeCodeCreator Create(object obj, ObjectFormulaTree[] trees);

        /// <summary>
        /// Trees
        /// </summary>
        public ObjectFormulaTree[] Trees
        {
            get { return trees; }
        }

        int ITreeCodeCreator.GetNumber(ObjectFormulaTree tree)
        {
            if (!dictionary.ContainsKey(tree))
            {
                throw new OwnNotImplemented();
            }
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

        protected virtual object Object { get; set; }


        /// <summary>
        /// Gets constant string representation of value of tree 
        /// </summary>
        /// <param name="tree">The tree</param>
        /// <returns>String representation</returns>
        public abstract string GetConstValue(ObjectFormulaTree tree);

        Dictionary<string, List<string>> ITreeCodeCreator.CreateCode(object obj, ObjectFormulaTree tree, string ret, params string[] parameters)
        {
            return CreateCode(obj, tree, ret, parameters);
        }

        /// <summary>
        /// Type creator
        /// </summary>
        protected abstract ITypeCreator TypeCreator
        {
            get;
        }
        object ITreeCodeCreator.Object { get => Object; set => Object = value; }

        protected virtual void Set(ObjectFormulaTree[] trr)
        {
            ident.Clear();
            dictionary.Clear();
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

            #endregion

            #endregion
        }
    }
}
