using System;
using System.Collections.Generic;
using System.Text;

namespace Motion6D.Portable
{
    class CovariantVectorFieldTransformer : FieldTransformer
    {
        private double[,] matrix;

        private double[] v = new double[3];

        internal override void Set(ReferenceFrame relative)
        {
            matrix = relative.Matrix;
        }

        internal override object Transform(object o)
        {
            double[] x = o as double[];
            for (int i = 0; i < 3; i++)
            {
                v[i] = 0;
                for (int j = 0; j < 3; j++)
                {
                    v[i] += matrix[j, i] * x[j];
                }
            }
            return v;
        }
    }
}
