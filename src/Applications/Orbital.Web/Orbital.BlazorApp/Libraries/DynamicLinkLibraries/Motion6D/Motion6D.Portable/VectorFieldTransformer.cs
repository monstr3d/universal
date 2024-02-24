using Motion6D.Portable.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Motion6D.Portable
{
    class VectorFieldTransformer : IFieldTransformer
    {
        private double[] result = new double[3];


        #region IFieldTransformer Members

        object IFieldTransformer.Transform(double[,] transformMatrix, object value)
        {
            double[] x = value as double[];
            for (int i = 0; i < 3; i++)
            {
                result[i] = 0;
                for (int j = 0; j < 3; j++)
                {
                    result[i] += transformMatrix[i, j] * x[j];
                }
            }
            return result;
        }

        #endregion
    }
}
