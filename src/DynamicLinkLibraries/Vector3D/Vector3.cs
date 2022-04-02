using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        #endregion
    }
}
