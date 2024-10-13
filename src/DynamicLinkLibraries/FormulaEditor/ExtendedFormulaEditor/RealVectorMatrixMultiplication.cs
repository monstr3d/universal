using System;

using BaseTypes;
using BaseTypes.Interfaces;

using RealMatrixProcessor;


namespace FormulaEditor
{
    public class RealVectorMatrixMultiplication : IObjectOperation
    {
        RealMatrix realMatrix = new();

        const Double a = 0;
        ArrayReturnType type;
        double[] buffer;


        internal RealVectorMatrixMultiplication(int dim)
        {
            buffer = new double[dim];
            type = new ArrayReturnType(a, new int[] { dim }, false);
        }

        #region IObjectOperation Members

        public virtual object[] InputTypes
        {
            get { return new object[2]; }
        }

        object IObjectOperation.this[object[] x]
        {
            get 
            {
                double[,] m = x[0] as double[,];
                double[] y = x[1] as double[];
                realMatrix.Multiply(m, y, buffer);
                return buffer;
            }
        }

        object IObjectOperation.ReturnType
        {
            get { return type; }
        }

        #endregion
    }
}
