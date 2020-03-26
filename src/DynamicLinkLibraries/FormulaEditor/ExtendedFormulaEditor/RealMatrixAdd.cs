using System;
using System.Collections.Generic;
using System.Text;

namespace FormulaEditor
{
    public class RealMatrixAdd : RealMatrixBinary
    {

        new static internal readonly RealMatrixAdd Singleton = new RealMatrixAdd(0, 0);

        private RealMatrixAdd(int row, int col)
            : base(row, col)
        {
        }

        protected override RealMatrixBinary CreateOpreation(int row, int col)
        {
            return new RealMatrixAdd(row, col);
        }

        public override object this[object[] x]
        {
            get
            {
                double[,] a = x[0] as double[,];
                double[,] b = x[1] as double[,];
                RealMatrixProcessor.RealMatrix.Add(a, b, buffer);
                return buffer;
            }
        }
    }
}
