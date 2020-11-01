using System;
using System.Collections.Generic;
using System.Text;


using BaseTypes;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Attributes;

namespace FormulaEditor
{

    /// <summary>
    /// Array operation acceptor with array
    /// </summary>
    public class ArrayOperationAcceptor : IOperationAcceptor
    {
        #region Fields

        /// <summary>
        /// Operation acceptor
        /// </summary>
        private IOperationAcceptor acceptor;


        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="acceptor">Prototype acceptor</param>
        public ArrayOperationAcceptor(IOperationAcceptor acceptor)
        {
            this.acceptor = acceptor;
        }
        #endregion

        #region IOperationAcceptor Members

        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="type">Argument type</param>
        /// <returns>The operation</returns>
        public IObjectOperation Accept(object type)
        {
            IObjectOperation ownOp = acceptor.Accept(type);
            if (ownOp != null)
            {
                return ownOp;
            }
            if (type is ArrayReturnType)
            {
                ArrayReturnType a = type as ArrayReturnType;
                if (a.IsObjectType)
                {
                    IObjectOperation op = acceptor.Accept(a.ElementType);
                    if (op == null)
                    {
                        return null;
                    }
                    IObjectOperation dop = GetDynamicalOperation(a, op);
                    if (dop != null)
                    {
                        return dop;
                    }
                   return new ArrayOperation(op, new object[] { type });
                }
            }
            IObjectOperation ope = acceptor.Accept(type);
            if (ope != null)
            {
                return ope;
            }
            if (type is ArrayReturnType)
            {
                ArrayReturnType a = type as ArrayReturnType;
                IObjectOperation op = acceptor.Accept(a.ElementType);
                if (op == null)
                {
                    return null;
                }
                IObjectOperation dop = GetDynamicalOperation(a, op);
                if (dop != null)
                {
                    return dop;
                }
                return new ArrayOperation(op, new object[] { type });
            }
            return null;
        }

        #endregion

        #region Private Methods

        private IObjectOperation GetDynamicalOperation(ArrayReturnType type, IObjectOperation operation)
        {
            if (type.IsDynamicalArray())
            {
                IObjectOperation op = StaticExtensionFormulaEditor.GetUnaryParallel(type, operation);
                if (op != null)
                {
                    return op;
                }
                return new DynamicalArrayUnaryOperation(type, operation);
            }
            return null;            
        }

    
        #endregion

    }

}
