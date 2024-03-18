using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes;
using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;


namespace FormulaEditor
{
    public class RealMatrixMinus : IObjectOperation
    {
        double[,] buffer;
        ArrayReturnType type;
        const Double a = 0;

        internal RealMatrixMinus(int row, int col)
        {
            type = new ArrayReturnType(a, new int[] { row, col }, false);
            buffer = new double[row, col];
        }

        #region IObjectOperation Members

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] IObjectOperation.InputTypes
        {
            get
            {
                return new object[] { type };
            }
        }

        object IObjectOperation.this[object[] x]
        {
            get 
            {
                double[,] a = x[0] as double[,];
                for (int i = 0; i < buffer.GetLength(0); i++)
                {
                    for (int j = 0; j < buffer.GetLength(1); j++)
                    {
                        buffer[i, j] = -a[i, j];
                    }
                }
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
