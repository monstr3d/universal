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
    /// Single operation with array variable
    /// </summary>
    public class ArraySingleOperation : IObjectOperation
    {
        private object returnType;
        private ArraySingleOperationType operationType;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="operationType">Operation type</param>
        /// <param name="type">Type of return</param>
        public ArraySingleOperation(ArraySingleOperationType operationType, object type)
        {
            this.operationType = operationType;
            ArrayReturnType art = type as ArrayReturnType;
            object t = art.ElementType;
            if (t is Double)
            {
                Double a = 0;
                returnType = a;
            }
        }

        #region IObjectOperation Members

        /// <summary>
        /// Types of input parameters
        /// </summary>
        public virtual object[] InputTypes
        {
            get { return new object[] { returnType }; }
        }


        /// <summary>
        /// Calculation
        /// </summary>
        /// <param name="x">Arguments</param>
        /// <returns>Return value of operation</returns>
        public object this[object[] x]
        {
            get
            {
                double a = 0;
                object[] y = x[0] as object[];
                if (operationType == ArraySingleOperationType.Sum)
                {
                    for (int i = 0; i < y.Length; i++)
                    {
                        a += (double)y[i];
                    }
                    return a;
                }
                if (operationType == ArraySingleOperationType.Product)
                {
                    a = 1;
                    for (int i = 0; i < y.Length; i++)
                    {
                        a += (double)y[i];
                    }
                    return a;
                }
                return null;
            }
        }

        /// <summary>
        /// Return type
        /// </summary>
        public object ReturnType
        {
            get
            {
                return returnType;
            }
        }

 
        #endregion

        #region Own Methods

        /// <summary>
        /// Operation type
        /// </summary>
        public ArraySingleOperationType Type
        {
            get
            {
                return operationType;
            }
        }


        #endregion
    }

    /// <summary>
    /// Types of single array operations
    /// </summary>
    public enum ArraySingleOperationType
    {
        /// <summary>
        /// Sum
        /// </summary>
        Sum, 
        /// <summary>
        /// Product
        /// </summary>
        Product
    }

}
