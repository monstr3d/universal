using System;
using System.Collections.Generic;
using System.Text;

using Motion6D.Interfaces;

namespace Motion6D.Portable
{
    /// <summary>
    /// Moved frame
    /// </summary>
    public class MovedFrame : ReferenceFrame, IVelocity
    {
        #region Fields

        /// <summary>
        /// Velocity vector
        /// </summary>
        protected double[] velocity = new double[] { 0, 0, 0 };

        //protected double[] relativeVelocity = new double[] { 0, 0, 0 };

        #endregion

        #region IVelocity Members

        /// <summary>
        /// Velocity
        /// </summary>
        public double[] Velocity
        {
            get { return velocity; }
        }

        /*double[] IVelocity.RevativeVelocity
        {
            get
            {
                return relativeVelocity;
            }
        }*/


        #endregion

        /// <summary>
        /// Sets state
        /// </summary>
        /// <param name="baseFrame">Base frame</param>
        /// <param name="relative">Relative frame</param>
        public override void Set(ReferenceFrame baseFrame, ReferenceFrame relative)
        {
            base.Set(baseFrame, relative);
        }
    }
}
