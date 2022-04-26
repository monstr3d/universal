using System;

using RealMatrixProcessor;

namespace Vector3D
{
    /// <summary>
    /// 3D Vector
    /// </summary>
     public class Vector3
    {

        #region Fields

        double[] x = new double[3];

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Vector3()
        {

        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="vector">Copy vector</param>
        public Vector3(Vector3 vector)
        {
            CopyFrom(vector.x, 0);
        }

        /// <summary>
        /// Constructor from array
        /// </summary>
        /// <param name="x">The array</param>
        public Vector3(double[] x)
        {
            CopyFrom(x, 0);
        }


        #endregion

        #region Public Members


        /// <summary>
        /// Access to a component
        /// </summary>
        /// <param name="index">Index of the component</param>
        /// <returns>The component</returns>
        public double this[int index]
        { get => x[index]; set => x[index] = value; }

        /// <summary>
        /// Copy to from vetor
        /// </summary>
        /// <param name="vector">The array</param>
        public void CopyFrom(Vector3 vector)
        {
            Array.Copy(vector.x, x, 3);
        }

        /// <summary>
        /// Copy to an array
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="offset">The offset</param>
        public void CopyTo(double[] array, int offset)
        {
            Array.Copy(x, 0, array, offset, 3);
        }


        /// <summary>
        /// Copy from an array
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="offset">The offset</param>
        public void CopyFrom(double[] array, int offset)
        {
            Array.Copy(array, offset, x, 0, 3);
        }

        /// <summary>
        /// Norm
        /// </summary>
        public  double Norm
        { get => x.Norm(); }

        #region Overloaded operators

        /// <summary>
        /// Substraction
        /// </summary>
        /// <param name="a">Left part</param>
        /// <param name="b">Right part</param>
        /// <returns>The substractin result</returns>
        public static Vector3 operator * (double a, Vector3 b)
        {
            double[] x = new double[3];
            b.CopyTo(x, 0);
            double[] y = new double[3];
            RealMatrix.Multiply(y, a);
            return new Vector3(y);
        }


        /// <summary>
        /// Substraction
        /// </summary>
        /// <param name="a">Left part</param>
        /// <param name="b">Right part</param>
        /// <returns>The substractin result</returns>
        public static Vector3 operator - (Vector3 a, Vector3 b)
        {
            double[] x = new double[3];
            RealMatrix.Difference(a.x, b.x, x);
            return new Vector3(x);
        }

        /// <summary>
        /// Addition
        /// </summary>
        /// <param name="a">Left part</param>
        /// <param name="b">Right part</param>
        /// <returns>The addition result</returns>
        public static Vector3 operator + (Vector3 a, Vector3 b)
        {
            double[] x = new double[3];
            RealMatrix.Add(a.x, b.x, x);
            return new Vector3(x);
        }


        /// <summary>
        /// Scalar product
        /// </summary>
        /// <param name="a">Left part</param>
        /// <param name="b">Right part</param>
        /// <returns>The substractin result</returns>
        public static double operator | (Vector3 a, Vector3 b)
        {
            return a.x.ScalarProduct(b.x);
        }


        #endregion


        #endregion
    }
}
