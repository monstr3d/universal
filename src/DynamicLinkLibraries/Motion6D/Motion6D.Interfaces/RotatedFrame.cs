using System;
using System.Collections.Generic;
using System.Text;

using Motion6D.Interfaces;

namespace Motion6D
{
    /// <summary>
    /// Rotated frame
    /// </summary>
    public class RotatedFrame : ReferenceFrame, IAngularVelocity
    {
        /// <summary>
        /// Angular velocity
        /// </summary>
        protected double[] omega = new double[] { 0, 0, 0 };

        /// <summary>
        /// Auxiliary variable
        /// </summary>
        private static double[] vd = new double[4];

        #region IAngularVelocity Members


        /// <summary>
        /// Angular velocity of object
        /// </summary>
        public double[] Omega
        {
            get { return omega; }
        }

        #endregion

        #region Overriden Members



        /// <summary>
        /// Sets state
        /// </summary>
        /// <param name="baseFrame">Base frame</param>
        /// <param name="relative">Relative frame</param>
        public override void Set(ReferenceFrame baseFrame, ReferenceFrame relative)
        {
            base.Set(baseFrame, relative);
            IAngularVelocity ab = baseFrame as IAngularVelocity;
            IAngularVelocity ar = relative as IAngularVelocity;
            IOrientation ore = relative as IOrientation;
            double[,] m = ore.Matrix;
            double[] ob = ab.Omega;
            double[] or = ar.Omega;
            for (int i = 0; i < omega.Length; i++)
            {
                omega[i] = or[i];
                for (int j = 0; j < 3; j++)
                {
                    omega[i] += m[i, j] * ob[j];
                }
            }
        }

        #endregion

        #region Specific Members

        #endregion
    }
}
