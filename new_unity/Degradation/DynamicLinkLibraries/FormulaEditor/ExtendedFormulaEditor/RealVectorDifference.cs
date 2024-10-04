using System;
using System.Collections.Generic;
using System.Text;

namespace FormulaEditor
{
    public class RealVectorDifference : RealVectorBinary
    {
        new internal static readonly RealVectorDifference Singleton = new RealVectorDifference();

        private RealVectorDifference(int dim)
            : base(dim)
        {
        }

        private RealVectorDifference()
        {
        }

        public override object this[object[] x]
        {
            get
            {
                double[] a = x[0] as double[];
                double[] b = x[1] as double[];
                for (int i = 0; i < buffer.Length; i++)
                {
                    buffer[i] = a[i] - b[i];
                }
                return buffer;
            }
        }

        protected override RealVectorBinary CreateOperation(int dim)
        {
            return new RealVectorDifference(dim);
        }
    }
}