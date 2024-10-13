using System;

namespace RealMatrixProcessor
{
    public class FixedMultiplier
    {
        #region Fields

        double[,] matrix;
     
        RealMatrix realMatrix = new();

        int n;

        Action<double[,], double[,]> action = null;

        #endregion

        public FixedMultiplier(double[,] matrix, bool left)
        {
            this.matrix = matrix;
            action = left ? Left : Right;
        }

        #region Public

        public void Process(double[,] matrix, double[,] result)
        {
            action(matrix, result);
        }

        #endregion

        void Left(double[,] matrix, double[,] result)
        {
            realMatrix.Multiply(this.matrix, matrix, result);
        }

        void Right(double[,] matrix, double[,] result)
        {
            realMatrix.Multiply(matrix, this.matrix, result);
        }

    }
}
