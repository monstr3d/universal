using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes;
using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    public class ScalarVectorProduct : IObjectOperation
    {
        #region Fields

        static private readonly Double a = 0;

        private ArrayReturnType type;


        protected double[] result;

        #endregion

        #region Ctor

        internal ScalarVectorProduct(int dimension)
        {
            if (dimension < 0)
            {
                return;
            }
            type = new ArrayReturnType(a, new int[] { dimension }, false);
            result = new double[dimension];
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
                return new object[] { a, type };
            }
        }


        public virtual object this[object[] x]
        {
            get
            {
                double a = (double)x[0];
                double[] b = x[1] as double[];
                for (int i = 0; i < b.Length; i++)
                {
                    result[i] = a * b[i];
                }
                return result;
            }
        }

        object IObjectOperation.ReturnType
        {
            get { return type; }
        }

        #endregion
    }
}
