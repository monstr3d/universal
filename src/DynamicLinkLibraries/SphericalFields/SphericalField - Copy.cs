using System;
using System.Collections.Generic;
using System.Text;

namespace SphericalFields
{
    /// <summary>
    /// Spherical field
    /// </summary>
    public abstract class SphericalField : LegendrePolynomial
    {
        #region Fields
        
        /// <summary>
        /// Cos coefficients
        /// </summary>
        protected double[][] ccoeff;

        /// <summary>
        /// Sin coefficients
        /// </summary>
        protected double[][] scoeff;

        /// <summary>
        /// Typical size
        /// </summary>
        protected double a;


        /// <summary>
        /// Array of cosin
        /// </summary>
        protected double[] cosArray;

        /// <summary>
        /// Array of sin
        /// </summary>
        protected double[] sinArray;
        

        
        #endregion

        #region Static Members

        /// <summary>
        /// Creates Spherical Field
        /// </summary>
        /// <param name="type">Field type</param>
        /// <returns>The type</returns>
        public static SphericalField CreateField(int type)
        {
            if (type == (int)SphericalType.Gradient)
            {
                return new SphericalGragient();
            }
            return new SphericalVectorPotentialGragient();
        }

        #endregion

        #region Abstract Members

        /// <summary>
        /// Calculates value of field
        /// </summary>
        /// <param name="ctheta">Cosine theta angle</param>
        /// <param name="stheta">Sine theta angle</param>
        /// <param name="cphi">Cosine phi angle</param>
        /// <param name="sphi">Sine phi angle</param>
        /// <param name="r"></param>
        public abstract void Caclulate(double ctheta, double stheta, double cphi, double sphi, double r);

        /// <summary>
        /// Sets parameters of the field
        /// </summary>
        /// <param name="n">The N parameter</param>
        /// <param name="m">The M parameter</param>
        /// <param name="a">The radius</param>
        /// <param name="ccoeff">Cosine coefficiens</param>
        /// <param name="scoeff">Sine coefficients</param>
        public abstract void Set(int n, int m, double a, double[][] ccoeff, double[][] scoeff);


        /// <summary>
        /// Type of field
        /// </summary>
        public abstract SphericalType SphericalType
        {
            get;
        }

        /// <summary>
        /// Value of field
        /// </summary>
        public abstract object Value
        {
            get;
        }

        #endregion

    }
}
