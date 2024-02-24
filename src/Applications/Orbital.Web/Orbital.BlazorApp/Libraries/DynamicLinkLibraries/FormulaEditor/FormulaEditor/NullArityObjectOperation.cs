using System;
using System.Collections.Generic;
using System.Text;

using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    /// <summary>
    /// Standard null arity operation
    /// </summary>
    public class NullArityObjectOperation : INullArityOperation
    {
        /// <summary>
        /// The associated object
        /// </summary>
        protected Object obj;

        /// <summary>
        /// The associated object
        /// </summary>
        public object Object
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

        /// <summary>
        /// Arity of this operation
        /// </summary>
        object[] BaseTypes.Interfaces.IObjectOperation.InputTypes
        {
            get
            {
                return new object[0];
            }
        }

        /// <summary>
        /// Return type
        /// </summary>
        public object ReturnType
        {
            get
            {
                return obj;
            }
        }


        /// <summary>
        /// Calculates result of this operation
        /// </summary>
        public object this[object[] o]
        {
            get
            {
                return obj;
            }
        }

    }
}
