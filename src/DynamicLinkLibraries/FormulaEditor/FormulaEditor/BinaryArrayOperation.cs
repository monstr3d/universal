using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    /// <summary>
    /// Binary operation with array
    /// </summary>
    public class BinaryArrayOperation : ArrayOperation
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="operation">Base operation</param>
        /// <param name="typeA">Type of first variable</param>
        /// <param name="typeB">Type of second variable</param>
        public BinaryArrayOperation(IObjectOperation operation, object typeA, object typeB)
            : base(operation, new object[] { typeA, typeB })
        {
        }

        #region IObjectOperation Members


        /// <summary>
        /// The "is powered" sign
        /// </summary>
        public override bool IsPowered
        {
            get
            {
                return false;
            }
        }

        #endregion
    }
}
