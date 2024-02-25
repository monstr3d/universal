using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;

namespace FormulaEditor.Variables
{
    /// <summary>
    /// Variable
    /// </summary>
    public class Variable : IOperationAcceptor, IObjectOperation, IPowered, IString
    {
        #region Fields

        object obj;

        object type;

        object[] inp = new object[0];

        /// <summary>
        /// Variable string
        /// </summary>
        protected string variableName;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="variableName">String</param>
        public Variable(object type, string variableName)
        {
            this.type = type;
            this.variableName = variableName;
        }

        #endregion

        #region IOperationAcceptor Members


        IObjectOperation IOperationAcceptor.Accept(object type)
        {
            return this;
        }

        #endregion

        #region Members

        /// <summary>
        /// Value
        /// </summary>
        public object Value
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
            }
        }


        #endregion

        #region IObjectOperation Members

        object[] IObjectOperation.InputTypes
        {
            get { return inp; }
        }

        object IObjectOperation.this[object[] x]
        {
            get { return obj; }
        }

        object IObjectOperation.ReturnType
        {
            get { return type; }
        }

        #endregion

        #region IPowered Members

        bool IPowered.IsPowered
        {
            get { return true; }
        }

        #endregion

        #region IString Members

        string IString.String
        {
            get { return variableName; }
        }

        #endregion

    }
}
