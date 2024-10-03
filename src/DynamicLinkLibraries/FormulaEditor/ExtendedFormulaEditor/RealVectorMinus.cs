using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes;
using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;


namespace FormulaEditor
{
    public class RealVectorMinus : IObjectOperation
    {

        double[] buffer;
        ArrayReturnType type;
        const Double a = 0;


        internal RealVectorMinus(int dim)
        {
            buffer = new double[dim];
            type = new ArrayReturnType(a, new int[] { dim }, false);
        }

        #region IObjectOperation Members

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] BaseTypes.Interfaces.IObjectOperation.InputTypes
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
                double[] y = x[0] as double[];
                for (int i = 0; i < buffer.Length; i++)
                {
                    buffer[i] = y[i];
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