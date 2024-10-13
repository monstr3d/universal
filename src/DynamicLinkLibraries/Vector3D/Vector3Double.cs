using System;

using RealMatrixProcessor;

namespace Vector3D
{
    /// <summary>
    /// 3D Vector
    /// </summary>
    public class Vector3Double
    {

        #region Fields

        double[] x = new double[3];

        RealMatrix realMatrix = new ();

        static RealMatrix rm = new();

 
        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Vector3Double()
        {

        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="vector">Copy vector</param>
        public Vector3Double(Vector3Double vector)
        {
            CopyFrom(vector.x, 0);
        }

        /// <summary>
        /// Constructor from array
        /// </summary>
        /// <param name="x">The array</param>
        public Vector3Double(double[] x)
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
        public void CopyFrom(Vector3Double vector)
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
        public double Norm
        { get => realMatrix.Norm(x); }

       
        #region Overloaded operators

  

        #endregion


        #endregion
    }
}
