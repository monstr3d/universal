using System.Collections.Generic;

using BaseTypes.Interfaces;

using Diagram.UI.Interfaces;
using Diagram.UI.Aliases;

using FormulaEditor;
using FormulaEditor.Interfaces;

namespace DataPerformer.Formula
{
    /// <summary>
    /// Variable linked to alias
    /// </summary>
    public class AliasNameVariable : IObjectOperation, IPowered, IOperationAcceptor, IDerivationOperation, ITreeCreator
    {
        #region Fields

        /// <summary>
        /// Alias
        /// </summary>
        protected IAlias alias;

        /// <summary>
        /// Name
        /// </summary>
        protected string name;

        /// <summary>
        /// Symbol
        /// </summary>r
        protected string symbol;

        /// <summary>
        /// Associated tree
        /// </summary>
        protected ObjectFormulaTree tree;

        /// <summary>
        /// Alias name
        /// </summary>
        protected IAliasName aliasName;


        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="symbol">Formula symbol</param>
        /// <param name="alias">Alias object</param>
        /// <param name="name">Alias name</param>
        public AliasNameVariable(string symbol, IAlias alias, string name)
        {
            this.alias = alias;
            this.name = name;
            this.symbol = symbol;
            tree = new ObjectFormulaTree(this, new List<ObjectFormulaTree>());
            aliasName = new AliasName(alias, name);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="symbol">Formula symbol</param>
        /// <param name="alias">Alias object</param>
        /// <param name="name">Alias name</param>
        public AliasNameVariable(char symbol, IAlias alias, string name)
            : this(symbol + "", alias, name)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="symbol">Formula symbol</param>
        /// <param name="alias">Alias object</param>
        public AliasNameVariable(char symbol, IAlias alias)
            : this(symbol + "", alias, symbol + "")
        {
        }

        #endregion

        #region IObjectOperation Members

        object[] IObjectOperation.InputTypes
        {
            get { return new object[0]; }
        }

        object IObjectOperation.this[object[] x]
        {
            get { return GetValue(); }
        }

        object IObjectOperation.ReturnType
        {
            get { return alias.GetType(name); }
        }

        bool IPowered.IsPowered
        {
            get { return true; }
        }

        #endregion

        #region IOperationAcceptor Members

        IObjectOperation IOperationAcceptor.Accept(object type)
        {
            return this;
        }

        #endregion

        #region IDerivationOperation Members

        ObjectFormulaTree IDerivationOperation.Derivation(ObjectFormulaTree tree, string s)
        {
            return ElementaryRealConstant.RealZero;
        }

        #endregion

        #region ITreeCreator Members

        ObjectFormulaTree ITreeCreator.Tree
        {
            get { return tree; }
        }

        #endregion

        #region Public Members

            /// <summary>
        /// Gets value
        /// </summary>
        /// <returns></returns>
        public object GetValue()
        {
            var value = alias[name];
            if (value == null)
            {

            }    
            return value;
        }

        /// <summary>
        /// Alias Name
        /// </summary>
        public IAliasName AliasName
        {
            get
            {
                return aliasName;
            }
        }

        #endregion
    }
}
