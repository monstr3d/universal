using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using FormulaEditor.Operations.Fiction;

namespace FormulaEditor
{
    /// <summary>
    /// Binary operation acceptor with array
    /// </summary>
    public class BinaryArrayOperationAcceptor : IBinaryAcceptor, IChildTreeCreator
    {
        #region Fields

        /// <summary>
        /// Operation acceptor
        /// </summary>
        private IBinaryAcceptor acceptor;


        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="acceptor">Prototype acceptor</param>
        public BinaryArrayOperationAcceptor(IBinaryAcceptor acceptor)
        {
            this.acceptor = acceptor;
        }

        #endregion

        #region IBinaryAcceptor Members

        IObjectOperation IBinaryAcceptor.Accept(object typeA, object typeB)
        {
            IObjectOperation ownOp = acceptor.Accept(typeA, typeB);
            if (ownOp != null)
            {
                return ownOp;
            }
            if (typeA.IsDynamicalArray())
            {
                ArrayReturnType art = typeA as ArrayReturnType;
                IObjectOperation opr = acceptor.Accept(art.ElementType, typeB);
                if (opr != null)
                {
                    IObjectOperation opp = 
                        StaticExtensionFormulaEditor.GetDynamicalBinaryLeft(typeA, typeB, opr);
                    if (opp != null)
                    {
                        return opp;
                    }
                    return new DynamicalArrayBinaryLeftOperation(typeA, typeB, opr);
                }
                if (typeB.IsDynamicalArray())
                {
                    ArrayReturnType artb = typeB as ArrayReturnType;
                    IObjectOperation oprf = acceptor.Accept(art.ElementType, artb.ElementType);
                    return new BinaryFictionOperation(oprf, typeA, typeB);
                }
            }
            if (typeB.IsDynamicalArray())
            {
                ArrayReturnType art = typeB as ArrayReturnType;
                IObjectOperation opr = acceptor.Accept(typeA, art.ElementType);
                if (opr != null)
                {
                    IObjectOperation opp =
                            StaticExtensionFormulaEditor.GetDynamicalBinaryRight(typeA, typeB, opr);
                    if (opp != null)
                    {
                        return opp;
                    }
                    return new DynamicalArrayBinaryRightOperation(typeA, typeB, opr);
                }
            }
            object[] t = new object[] { typeA, typeB };
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] is ArrayReturnType)
                {
                    ArrayReturnType at = t[i] as ArrayReturnType;
                    if (!at.IsObjectType)
                    {
                       IObjectOperation opb = acceptor.Accept(typeA, typeB);
                       if (opb != null)
                       {
                           return opb;
                       }
                    }
                }
            }
            object[] types = new object[] { typeA, typeB };
            for (int i = 0; i < 2; i++)
            {
                types[i] = ArrayReturnType.GetBaseType(types[i]);
            }
            IObjectOperation op = acceptor.Accept(types[0], types[1]);
            if (op != null)
            {
                return new BinaryArrayOperation(op, typeA, typeB);
            }
            return null;
        }

        #endregion

        #region IChildTreeCreator Members

        ObjectFormulaTree IChildTreeCreator.this[ObjectFormulaTree[] children]
        {
            get
            {
                if (acceptor is IChildTreeCreator)
                {
                    return (acceptor as IChildTreeCreator)[children];
                }
                return null;
            }
        }

        #endregion

    }
}
