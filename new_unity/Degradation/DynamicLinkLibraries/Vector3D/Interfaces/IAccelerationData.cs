using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector3D.Interfaces
{
    public interface IAccelerationData
    {
        /// <summary>
        /// X component of acceleration
        /// </summary>
        double AccelerationX
        { get; }

        /// <summary>
        /// Y component of acceleration
        /// </summary>
        double AccelerationY
        { get; }

        /// <summary>
        /// Z component of acceleration
        /// </summary>
        double AccelerationZ
        { get; }

        /// <summary>
        /// Copy of acceleromer
        /// </summary>
        /// <param name="accelerationData">The prorotype</param>
        void Copy(IAccelerationData accelerationData);

    
    }
}
