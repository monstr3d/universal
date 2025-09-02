using System;
using System.Collections.Generic;
using System.Text;

namespace FormulaEditor
{
    public class RealMatixDifference : RealMatrixBinary
    {
        new static internal readonly RealMatixDifference Singleton = new RealMatixDifference(0, 0);

        private RealMatixDifference(int row, int col)
            : base(row, col)
        {
        }

        protected override RealMatrixBinary CreateOpreation(int row, int col)
        {
            return new RealMatixDifference(row, col);
        }

        public override object this[object[] x]
        {
            get
            {
                double[,] a = x[0] as double[,];
                double[,] b = x[1] as double[,];
                realMatrix.Difference(a, b, buffer);
                return buffer;
            }
        }
   }
}
