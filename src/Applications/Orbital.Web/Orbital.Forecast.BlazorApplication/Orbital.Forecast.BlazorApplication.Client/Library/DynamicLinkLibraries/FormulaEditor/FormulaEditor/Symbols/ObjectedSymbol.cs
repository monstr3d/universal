using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;

namespace FormulaEditor.Symbols
{
    /// <summary>
    /// Symbol linked with object
    /// </summary>
    public class ObjectedSymbol : MathSymbol, INullArityOperation, IOperationAcceptor
    {

        /// <summary>
        /// Associated object
        /// </summary>
        protected object obj;


        private static readonly Guid guid = new Guid();
        
        private static readonly object[] types = new object[0];


        /// <summary>
        /// The Interfaces.ICloneable interface implementation
        /// </summary>
        /// <returns>A clone of itself</returns>
        public override object Clone()
        {
            ObjectedSymbol s = new ObjectedSymbol();
            s.obj = obj;
            return s;
        }

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
        /// Index of subscript
        /// </summary>
        public int SubscriptIndex
        {
            get
            {
                MathFormula f = this[0];
                string s = "";
                for (int i = 0; i < f.Count; i++)
                {
                    s += f[i].Symbol;
                }
                return Int32.Parse(s);
            }
        }

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] BaseTypes.Interfaces.IObjectOperation.InputTypes
        {
            get
            {
                return types;
            }
        }

        /// <summary>
        /// Return type
        /// </summary>
        public object ReturnType
        {
            get
            {
                if (obj is Guid)
                {
                    return guid;
                }
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

        #region IOperationAcceptor Members

        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="type">Argument type</param>
        /// <returns>The operation</returns>
        public IObjectOperation Accept(object type)
        {
            return this;
        }

        #endregion

    }
}
