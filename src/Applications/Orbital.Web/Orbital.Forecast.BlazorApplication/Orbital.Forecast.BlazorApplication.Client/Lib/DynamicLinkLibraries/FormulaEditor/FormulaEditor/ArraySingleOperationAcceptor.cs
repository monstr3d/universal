using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using BaseTypes;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    /// <summary>
    /// Acceptor of single array operation
    /// </summary>
    public class ArraySingleOperationAcceptor : IOperationAcceptor
    {

        private ArraySingleOperationType operationType;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="operationType">Operation type</param>
        public ArraySingleOperationAcceptor(ArraySingleOperationType operationType)
        {
            this.operationType = operationType;
        }

        #region IOperationAcceptor Members

        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="type">Return type</param>
        /// <returns>The operation</returns>
        public IObjectOperation Accept(object type)
        {
            if (!(type is ArrayReturnType))
            {
                return null;
            }
            object t = ArrayReturnType.GetBaseType(type);
            return new ArraySingleOperation(operationType, type);
        }

        #endregion
    }

}
