using System;
using BaseTypes;
using BaseTypes.Interfaces;

using RealMatrixProcessor;


namespace FormulaEditor
{
    public class TransposeRealMatrix : IObjectOperation, IPowered
    {

        object type;
        double[,] buffer;
        const Double a = 0;

        RealMatrix realMatrix = new();

        int col;

        int row;

        internal TransposeRealMatrix(int row, int col)
        {
            this.row = row;
            this.col = col;
            type = new ArrayReturnType(a, new int[] { col, row }, false);
            buffer = new double[col, row];
        }

        #region IObjectOperation Members

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] BaseTypes.Interfaces.IObjectOperation.InputTypes
        {
            get
            {
                return new object[]{ new ArrayReturnType(a, new int[] { row, col }, false)};
            }
        }

        object IObjectOperation.this[object[] x]
        {
            get 
            {
                double[,] y = x[0] as double[,];
                realMatrix.Transpose(y, buffer);
                return buffer;
            }
        }

        object IObjectOperation.ReturnType
        {
            get { return type; }
        }

        bool IPowered.IsPowered
        {
            get { return true; }
        }

        #endregion
    }
}
