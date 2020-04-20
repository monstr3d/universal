using System;
using System.Collections.Generic;
using System.Text;

namespace SphericalFields
{
    /// <summary>
    /// Spherical vector field
    /// </summary>
    public abstract class SphericalVectorField : SphericalField
    {
        #region Fields

        /// <summary>
        /// Spherical vector field
        /// </summary>
        protected double[] sphericalVector = new double[3]; 

        #endregion

        #region Overriden Members

        abstract public override void Caclulate(double ctheta, double stheta, double cphi, double sphi, double r);

        abstract public override void Set(int n, int m, double a, double[][] ccoeff, double[][] scoeff);

        abstract public override SphericalType SphericalType
        {
            get;
        }
 
        public override object Value
        {
            get { return sphericalVector; }
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// Spherical vector
        /// </summary>
        public double[] SphericalVector
        {
            get
            {
                return sphericalVector;
            }
        }

        #endregion
    }
}
