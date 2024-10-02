using System;
using System.Collections.Generic;
using System.Text;

namespace FormulaEditor
{
    /// <summary>
    /// Constants used in formula editor
    /// </summary>
    public enum FormulaConstants
    {
        /// <summary>
        /// Reserved
        /// </summary>
        Reserved, 
        /// <summary>
        /// Variable
        /// </summary>
        Variable, 
        /// <summary>
        /// Special
        /// </summary>
        Special, 
        /// <summary>
        /// Binary
        /// </summary>
        Binary, 
        /// <summary>
        /// Unary
        /// </summary>
        Unary, 
        /// <summary>
        /// Number
        /// </summary>
        Number, 
        /// <summary>
        /// Service
        /// </summary>
        Service, 
        /// <summary>
        /// Series
        /// </summary>
        Series, 
        /// <summary>
        /// Indexed
        /// </summary>
        Indexed, 
        /// <summary>
        /// Powered
        /// </summary>
        Powered, 
        /// <summary>
        /// Field
        /// </summary>
        Field,
        /// <summary>
        /// Boolean
        /// </summary>
        Boolean
    }

    /// <summary>
    /// Direction of binary association
    /// </summary>
    public enum BinaryAssociationDirection
    {
        /// <summary>
        /// Right to left direction
        /// </summary>
        RightLeft, 
        /// <summary>
        /// Left to right direction
        /// </summary>
        LeftRight
    }

}
