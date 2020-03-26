using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes;
using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;


namespace FormulaEditor
{
    class MatrixAlgebraAcceptor : ElementaryFunctionOperation
    {
        internal static readonly MatrixAlgebraAcceptor Singleton = new MatrixAlgebraAcceptor();

        private MatrixAlgebraAcceptor()
            : base('-')
        {
        }

        public override IObjectOperation Accept(object type)
        {
            if (type is ArrayReturnType)
            {
                ArrayReturnType at = type as ArrayReturnType;
                if (!at.IsObjectType)
                {
                    int[] dim = at.Dimension;
                    if (dim.Length == 1)
                    {
                        return new RealVectorMinus(dim[0]);
                    }
                    if (dim.Length == 2)
                    {
                        return new RealMatrixMinus(dim[0], dim[1]);
                    }
                }
            }
            return base.Accept(type);
        }
        
    }
}
