using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector3D.Interfaces;

namespace Vector3D
{
    /// <summary>
    /// Angular velocity
    /// </summary>
    public class AngularVelocity: IAngularVelocity
    {
        #region Fields

        protected double angularVelocityX;

        protected double angularVelocityY;

        protected double angularVelocityZ;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor from prototype
        /// </summary>
        /// <param name="angularVelicity">The prototype</param>
        public AngularVelocity(IAngularVelocity angularVelicity)
        {
            angularVelocityX = angularVelicity.AngularVelocityX;
            angularVelocityY = angularVelicity.AngularVelocityY;
            angularVelocityZ = angularVelicity.AngularVelocityZ;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        protected AngularVelocity()
        {

        }

        #endregion

        #region IAngularVelocity Members

        double IAngularVelocity.AngularVelocityX
        {
            get
            {
                return angularVelocityX;
            }
        }

        double IAngularVelocity.AngularVelocityY
        {
            get
            {
                return angularVelocityY;
            }
        }

        double IAngularVelocity.AngularVelocityZ
        {
            get
            {
                return angularVelocityZ;
            }
        }

        #endregion


    }
}
