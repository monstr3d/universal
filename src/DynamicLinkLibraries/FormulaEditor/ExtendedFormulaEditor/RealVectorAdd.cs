using System;
using System.Collections.Generic;
using System.Text;

namespace FormulaEditor
{
    public class RealVectorAdd : RealVectorBinary
    {
        new internal static readonly RealVectorAdd Singleton = new RealVectorAdd();

        private RealVectorAdd(int dim)
            : base(dim)
        {
        }

        private RealVectorAdd()
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
                    buffer[i] = a[i] + b[i];
                }
                return buffer;
            }
        }

        protected override RealVectorBinary CreateOperation(int dim)
        {
            return new RealVectorAdd(dim);
        }
    }
}
