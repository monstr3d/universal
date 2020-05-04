using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    /// <summary>
    /// Array operation with many variables
    /// </summary>
    public class MultiVariableArrayOperationAcceptor : IMultiVariableOperationAcceptor, IMultiVariableOperation, IPowered
    {

        #region Fields

        private IMultiVariableOperationAcceptor acceptor;

        private IMultiVariableOperation operation;
        private IMultiVariableOperation op;

        /// <summary>
        /// Array of variables
        /// </summary>
        protected object[] y;

        /// <summary>
        /// Types of variables
        /// </summary>
        protected object[] types;

        /// <summary>
        /// Type of return value
        /// </summary>
        protected ArrayReturnType returnType;

        /// <summary>
        /// Return value
        /// </summary>
        protected object returnValue;

        /// <summary>
        /// Is Array signs
        /// </summary>
        protected bool[] isArray;

        /// <summary>
        /// Length
        /// </summary>
        protected int length = 0;

        /// <summary>
        /// Rank
        /// </summary>
        protected int[] rank;

        /// <summary>
        /// Array of ranks
        /// </summary>
        protected int[][] ranks;

        /// <summary>
        /// Array of arrays
        /// </summary>
        protected object[][] yy;

        /// <summary>
        /// Base array
        /// </summary>
        protected object[] yt;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="acceptor">Prototype acceptor</param>
        public MultiVariableArrayOperationAcceptor(IMultiVariableOperationAcceptor acceptor)
        {
            this.acceptor = acceptor;
        }


        #region IMultiVariableOperationAcceptor Members

        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <returns>Accepted operation</returns>
        public IMultiVariableOperation AcceptOperation(MathSymbol symbol)
        {
            operation = acceptor.AcceptOperation(symbol);
            return this;
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
                    op = acceptor.Accept(a) as IMultiVariableOperation;
                    if (op == null)
                    {
                        return null;
                    }
                    types = new object[] { type };
                    ArrayOperation.CreateAllArrays(op, types, out y, out yy, out rank, out ranks);
                    returnType = new ArrayReturnType(op.ReturnType, rank, true);
                    return this;
                }
            }
            return null;
        }

        #endregion

        #region IMultiVariableOperation Members

        /// <summary>
        /// Accept operation
        /// </summary>
        /// <param name="types">Types of operands</param>
        /// <returns>Operation</returns>
        public IObjectOperation Accept(object[] types)
        {
            this.types = types;
            if (acceptor is IMultiVariableOperation)
            {
                IMultiVariableOperation ma = acceptor as IMultiVariableOperation;
                IObjectOperation ownOp = ma.Accept(types);
                if (ownOp != null)
                {
                    return ownOp;
                }
            }
            if (types == null)
            {
                return acceptor.Accept(null);
            }
            object[] t = new object[types.Length];
            bool isArray = false;
            for (int i = 0; i < t.Length; i++)
            {
                t[i] = ArrayReturnType.GetBaseType(types[i]);
                if (types[i] is ArrayReturnType)
                {
                    isArray = true;
                }
            }
            IObjectOperation opr = operation.Accept(t);
            if (opr == null)
            {
                return null;
            }
            if (!isArray)
            {
                return opr;
            }
            ArrayOperation.CreateAllArrays(opr, types, out y, out yy, out rank, out ranks);
            returnType = new ArrayReturnType(opr.ReturnType, rank, true);
            returnValue = y;
            if (types != null)
            {
                if (types.Length > 0)
                {
                    yt = new object[types.Length];
                }
            }
            return this;
        }

        #endregion

        #region IObjectOperation Members

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
        /// Calculates result of this operation
        /// </summary>
        public object this[object[] x]
        {
            get
            {
                ArrayOperation.PerformOperation(operation, returnValue as object[], x, yy,
                    rank.Length, ranks, rank, yt);
                return returnValue;
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

        /// <summary>
        /// The "is powered" sign
        /// </summary>
        bool IPowered.IsPowered
        {
            get
            {
                return op.IsPowered();
            }
        }

        #endregion


    }
}
