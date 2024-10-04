using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector3D.Interfaces;

namespace Vector3D
{
    /// <summary>
    /// Data of acceleration
    /// </summary>
    public class AccelerationData : IAccelerationData
    {


        #region Ctor

        /// <summary>
        /// Constructor from prototype
        /// </summary>
        /// <param name="data">The prototype</param>
        public AccelerationData(IAccelerationData data)
        {
            (this as IAccelerationData).Copy(data);
        }


        protected AccelerationData()
        {

        }

        #endregion

        /// <summary>
        /// X component of acceleration
        /// </summary>
        protected double accelerationX;

        /// <summary>
        /// Y component of acceleration
        /// </summary>
        protected double accelerationY;

        /// <summary>
        /// Z component of acceleration
        /// </summary>
        protected double accelerationZ;

        double IAccelerationData.AccelerationX
        {
            get
            {
                return accelerationX;
            }
        }

        double IAccelerationData.AccelerationY
        {
            get
            {
                return accelerationY;
            }
        }

        double IAccelerationData.AccelerationZ
        {
            get
            {
                return accelerationZ;
            }
        }

        void IAccelerationData.Copy(IAccelerationData accelerationData)
        {
            accelerationX = accelerationData.AccelerationX;
            accelerationY = accelerationData.AccelerationY;
            accelerationZ = accelerationData.AccelerationZ;
        }
    }
}
