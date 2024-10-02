using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;


namespace FormulaEditor
{
    /// <summary>
    /// Variable associated with dictionary
    /// </summary>
    public class DictionaryVariable : IObjectOperation, IPowered, IOperationAcceptor
    {

        #region Fields

        /// <summary>
        /// Name of variable
        /// </summary>
        protected string name;

        /// <summary>
        /// Dictionary
        /// </summary>
        private IDictionary<string, object> dictionary;

        /// <summary>
        /// Return type
        /// </summary>
        protected object type;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Variable name</param>
        /// <param name="dictionary">Dictionary</param>
        /// <param name="type">Type of variable</param>
        public DictionaryVariable(string name, IDictionary<string, object> dictionary, object type)
        {
            this.name = name;
            this.dictionary = dictionary;
            this.type = type;
        }

        #endregion

        #region IObjectOperation Members

        object[] BaseTypes.Interfaces.IObjectOperation.InputTypes
        {
            get { return new object[0]; }
        }

        object IObjectOperation.this[object[] x]
        {
            get { return dictionary[name]; }
        }

        object IObjectOperation.ReturnType
        {
            get { return type; }
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
    }
}
