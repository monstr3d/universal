using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes;
using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;
using RealMatrixProcessor;


namespace FormulaEditor
{
    public class RealMatrixPower : IObjectOperation, IPowered
    {
        ArrayReturnType type;
        double[,] result;
        double[,] buffer;
        double[,] mult;
        const Double a = 0;
        int dim;

        RealMatrix realMatrix = new();
        internal RealMatrixPower(int dim)
        {
            this.dim = dim;
            type = new ArrayReturnType(a, new int[] { dim, dim }, false);
            buffer = new double[dim, dim];
            result = new double[dim, dim];
            mult = new double[dim, dim];
        }

        #region IObjectOperation Members

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] BaseTypes.Interfaces.IObjectOperation.InputTypes
        {
            get
            {
                return new object[] { type, (int)0 };
            }
        }


        object IObjectOperation.this[object[] x]
        {
            get 
            {
                for (int i = 0; i < dim; i++)
                {
                    for (int j = 0; j < dim; j ++)
                    {
                        result[i, j] = 0;
                    }
                }
                for (int i = 0; i < dim; i++)
                {
                    result[i, i] = 1;
                }
                double[,] mat = x[0] as double[,];
                int n = (int)(double)x[1];
                if (n >= 0)
                {
                    mult = mat;
                }
                else
                {
                   realMatrix.Invert(mat, mult);
                    n = -n;
                }
                for (int i = 0; i < n; i++)
                {
                    realMatrix.Multiply(result, mult, buffer);
                    for (int k = 0; k < dim; k++)
                    {
                        for (int l = 0; l < dim; l++)
                        {
                            result[k, l] = buffer[k, l];
                        }
                    }
                }
                return result; 
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
