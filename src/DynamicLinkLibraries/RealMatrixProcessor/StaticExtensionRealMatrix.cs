using System.Collections.Generic;


namespace RealMatrixProcessor
{
	/// <summary>
	/// Operations with real matrix
	/// </summary>
	public static class StaticExtensionRealMatrix
	{

        static private RealMatrix realMatrix = new();

        /// <summary>
        /// Normalization of vector
        /// </summary>
        /// <param name="inp">Input</param>
        /// <param name="outp">Output</param>
        /// <param name="offset">Offset</param>
        public static double Normalize(this double[] inp, double[] outp, int offset)
        {
            return realMatrix.Normalize(inp, outp, offset);
        }

        /// <summary>
        /// Inverts matrix
        /// </summary>
        /// <param name="a">Matrix to invert</param>
        /// <param name="aInverted">Result of inversion</param>
		public static void Invert(this double[,] a, double[,] aInverted)
		{
            realMatrix.Invert(a, aInverted);
		}

        /// <summary>
        /// Calculates determinant of matrix
        /// </summary>
        /// <param name="a">The matrix</param>
        /// <returns>The determinant</returns>
		static public double Det(this double[,] a)
        {
            return realMatrix.Det(a);
        }

        /// <summary>
        /// Scalar product
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>The product</returns>
        static double ScalarProduct(this double[] x, double[] y)
        {
            return realMatrix.ScalarProduct(x, y);
        }

        /// <summary>
        /// Multiplication of vector by coefficient
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <param name="coefficient">Coefficient</param>
        static public void Multiply(this double[] vector, double coefficient)
        {
            realMatrix.Multiply(vector, coefficient);
        }

        /// <summary>
        /// Matrix product
        /// </summary>
        /// <param name="a">First term</param>
        /// <param name="b">Second term</param>
        /// <param name="c">Product</param>
        static public void Multiply(this double[,] a, double[,] b, double[,] c)
		{
            realMatrix.Multiply(a, b, c);
		}
 
        /// <summary>
        /// Square of vector
        /// </summary>
        /// <param name="vector">The vector</param>
        /// <returns>Square</returns>
        public static double Square(this double[] vector)
        {
            return realMatrix.Square(vector);
        }

        /// <summary>
        /// Norm of vector
        /// </summary>
        /// <param name="vector">The vector</param>
        /// <returns>Norm</returns>
        public static double Norm(this double[] vector)
        {
            return realMatrix.Norm(vector);
        }

        /// <summary>
        /// Matrix - vector product
        /// </summary>
        /// <param name="matrix">The matrix</param>
        /// <param name="vector">The vector</param>
        /// <param name="product">The product</param>
		static public void Multiply(this double[,] matrix, double[] vector, double[] product)
		{
            realMatrix.Multiply(matrix, vector, product);   
		}

        /// <summary>
        /// Vector - matrix product
        /// </summary>
        /// <param name="vector">The vector</param>
        /// <param name="matrix">The matrix</param>
        /// <param name="product">The product</param>
		static public void Multiply(this double[] vector, double[,] matrix, double[] product)
		{
            realMatrix.Multiply(vector, matrix, product);
		}

        /// <summary>
        /// Matrix - vector multiplication
        /// </summary>
        /// <param name="matrix">Matrix</param>
        /// <param name="vector">Vector</param>
        /// <param name="vectorOffset">Vector offset</param>
        /// <param name="product">Result</param>
        /// <param name="productOffset">Result offset</param>
        static public void Multiply(this double[,] matrix, double[] vector, int vectorOffset, double[] product,
            int productOffset)
        {
            realMatrix.Multiply(matrix, vector, vectorOffset, product, productOffset);
        }

        /// <summary>
        /// Multiplication
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <param name="matrix">Matrix</param>
        /// <param name="vectorOffset">Vector offset</param>
        /// <param name="product">Product</param>
        /// <param name="productOffset">Product offset</param>
       static public void Multiply(this double[] vector, double[,] matrix, int vectorOffset, double[] product, 
           int productOffset)
        {
            realMatrix.Multiply(vector, matrix, vectorOffset, product, productOffset);
        }

        /// <summary>
        /// Transposition of matrix
        /// </summary>
        /// <param name="x">Matrix to transpose</param>
        /// <param name="y">Transposed matrix</param>
        public static void Transpose(this double[,] x, double[,] y)
        {
            realMatrix.Transpose(x, y);
        }

        /// <summary>
        /// Performing following matrix operation B - Ht A H; Where H is transposed H
        /// </summary>
        /// <param name="h">The H matrix</param>
        /// <param name="a">The A matrix</param>
        /// <param name="result">The B matrix</param>
        public static void HtAH(this double[,] h, double[,] a, double[,] result)
        {
            realMatrix.HtAH(h, a, result);  
        }

        /// <summary>
        /// Sum of matrixes
        /// </summary>
        /// <param name="x">First term</param>
        /// <param name="y">Second term</param>
        /// <param name="z">Sum</param>
        public static void Add(this double[,] x, double[,] y, double[,] z)
        {
            realMatrix.Add(x, y, z);
        }

        /// <summary>
        /// Sum of vercors
        /// </summary>
        /// <param name="x">First term</param>
        /// <param name="y">Second term</param>
        /// <param name="z">The sum</param>
        public static void Add(this double[] x, double[] y, double[] z)
        {
            realMatrix.Add(x, y, z);
        }

        /// <summary>
        /// Sum of vetros
        /// </summary>
        /// <param name="vector1">First vector</param>
        /// <param name="offset1">First offset</param>
        /// <param name="vector2">Second vector</param>
        /// <param name="offset2">Second offset</param>
        /// <param name="sum">Sum</param>
        /// <param name="offsetSum">Sum offset</param>
        /// <param name="length">Length of vector</param>
        public static void Add(this double[] vector1, int offset1, double[] vector2, int offset2, double[] sum,
            int offsetSum, int length)
        {
            realMatrix.Add(vector1, offset1, vector2, offset2, sum, offsetSum, length);
        }

        /// <summary>
        /// Matrix substraction
        /// </summary>
        /// <param name="x">First term</param>
        /// <param name="y">Second term</param>
        /// <param name="z">Difference</param>
        public static void Difference(this double[,] x, double[,] y, double[,] z)
        {
            realMatrix.Difference(x, y, z);
        }

        /// <summary>
        /// Vector substraction
        /// </summary>
        /// <param name="x">First term</param>
        /// <param name="y">Second term</param>
        /// <param name="z">Difference</param>
        public static void Difference(this double[] x, double[] y, double[] z)
        {
            realMatrix.Difference(x, y, z);
        }

        /// <summary>
        /// Normalizes vector x
        /// </summary>
        /// <param name="x">Vector for normalization</param>
        public static void Normalize(this double[] x)
        {
            realMatrix.Normalize(x);
        }

        /// <summary>
        /// Normalization of vector
        /// </summary>
        /// <param name="x">The vector</param>
        /// <param name="offset">Offset</param>
        /// <param name="length">Length</param>
        public static void Normalize(this double[] x, int offset, int length)
        {
            realMatrix.Normalize(x, offset, length);
        }

        /// <summary>
        /// Lagrange interpolation
        /// </summary>
        /// <param name="t">Argument</param>
        /// <param name="degree">degree</param>
        /// <param name="begin">begin index</param>
        /// <param name="x">Coefficients</param>
        /// <returns>Value of interpolated polynom</returns>
        public static double LagrangeInterpolation(this double t, int degree, int begin, object[,] x)
        {
            return realMatrix.LagrangeInterpolation(t, degree, begin, x);
        }

        /// <summary>
        /// Lagrange interpolation
        /// </summary>
        /// <param name="t">Argument</param>
        /// <param name="degree">degree</param>
        /// <param name="begin">begin index</param>
        /// <param name="x">Coefficients</param>
        /// <returns>Value of interpolated polynom</returns>
        public static double LagrangeInterpolation(this double t, int degree, int begin, IList<object[]> x)
        {
            return realMatrix.LagrangeInterpolation(t, degree, begin, x);
        }


        /// <summary>
        /// LU decomposition of matrix
        /// </summary>
        /// <param name="A">The matrix</param>
        /// <param name="indx">Decomposition indx</param>
        /// <returns>True in success and false otherwise</returns>
        public static bool LU_Factor(this double[,] A, int[] indx)
        {
            return realMatrix.LU_Factor(A, indx);
         }

        /// <summary>
        /// Solution of linear equations by LU Decomposition
        /// </summary>
        /// <param name="A">Matrix</param>
        /// <param name="indx">Decomposition index</param>
        /// <param name="b">Right part</param>
        /// <returns>True in success and false otherwise</returns>
        public static bool LU_Solve(this double[,] A, int[] indx, double[] b)
        {
            return realMatrix.LU_Solve(A, indx, b);
        }

        /// <summary>
        /// += operation for arrays
        /// </summary>
        /// <param name="x">First argument</param>
        /// <param name="y">Secong Argument</param>
        public static void PlusEqual(this double[] x, double[] y)
        {
            realMatrix.PlusEqual(x, y);
        }

        /// <summary>
        /// -= operation for arrays
        /// </summary>
        /// <param name="x">First argument</param>
        /// <param name="y">Secong Argument</param>
        public static void MinusEqual(this double[] x, double[] y)
        {
            realMatrix.MinusEqual(x, y);
        }

        /// <summary>
        /// Solves system of linear equations
        /// </summary>
        /// <param name="a">Matrix of equations</param>
        /// <param name="b">Right part</param>
        /// <param name="indx">Auxiliary array</param>
        /// <returns>True in succces and false otherwise</returns>
        public static bool Solve(this double[,] a, double[] b, int[] indx)
        {
            return realMatrix.Solve(a, b, indx);
        }

        /// <summary>
        /// Gets main minor of matrix
        /// </summary>
        /// <param name="matrix">The matrix</param>
        /// <param name="order">Order of minor</param>
        /// <returns>The minor</returns>
        public static double[,] GetMainMinor(this double[,] matrix, int order)
        {
            return realMatrix.GetMainMinor(matrix, order);
        }

        /// <summary>
        /// Kalman filter
        /// </summary>
        /// <param name="state">State</param>
        /// <param name="delta">Delta</param>
        /// <param name="transition">Transition matrix</param>
        /// <param name="partial">Partial derivation matrix</param>
        /// <param name="covariation">Covariation matrix</param>
        /// <param name="errorCovariation">State error covariation</param>
        /// <param name="measurementCovariation">Measurements error covariation</param>
        /// <param name="coefficient">Auxiliary variable</param>
        /// <param name="partialTrans">Auxiliary variable</param>
        /// <param name="partialPeer">Auxiliary variable</param>
        /// <param name="errorCovariationPeer">Auxiliary variable</param>
        /// <param name="errorCovariationPeerPlus">Auxiliary variable</param>
        /// <param name="statePeer">Auxiliary variable</param>
        /// <param name="covariationPeer">Auxiliary variable</param>
        /// <param name="covariationPeerPlus">Auxiliary variable</param>
        public static void KalmanFilter(double[] state, double[] delta,
            double[,] transition, double[,] partial, double[,] covariation,
            double[,] errorCovariation, double[,] measurementCovariation, double[,] coefficient, double[,] partialTrans,
            double[,] partialPeer, double[,] errorCovariationPeer, double[,] errorCovariationPeerPlus,
            double[] statePeer, double[,] covariationPeer, double[,] covariationPeerPlus)
        {
            realMatrix.KalmanFilter(state, delta, transition, partial, covariation, errorCovariation, measurementCovariation,
                coefficient, partialTrans, partialPeer, errorCovariationPeer, errorCovariationPeerPlus, statePeer, covariationPeer,
                covariationPeerPlus);    
        }


        //c diagonalisation of positive defined matrix A (N*N)
        //c A=S*B*St (1) (B - diagonal matrix, S- orthogonal one)
        //c N - dimension
        //c RHO - accuracy
        //c A(N,N) - input - matrix A, output - matrix B (see (1))
        //c S(N,N) - orthogonal matrix (see (1)) 
        //      dimension A(n,n),S(n,n)


        /// <summary>
        /// Diagonalization by Jacoby method 
        /// a=s*b*st (1) (b - diagonal matrix, s- orthogonal one)
        /// </summary>
        /// <param name="a">Diagonal matrix</param>
        /// <param name="s">Orthogonal matrix</param>
        /// <param name="eps">Accuracy</param>
        static public void Jacoby(double[,] a, double[,] s, double eps)
        {
            realMatrix.Jacoby(a, s, eps);
        }
    }
}
 

