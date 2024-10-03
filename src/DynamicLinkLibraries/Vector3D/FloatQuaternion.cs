using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector3D.Interfaces;

namespace Vector3D
{
    public class FloatQuaternion : IFloatQuaternion
    {

        #region Fields

        protected float w;

        protected float x;

        protected float y;

        protected float z;

        #endregion

        #region Ctor

        /// <summary>
        /// Costructor from prototype
        /// </summary>
        /// <param name="quaternion">The prototype</param>
        public FloatQuaternion(IFloatQuaternion quaternion)
        {
            (this as IFloatQuaternion).Copy(quaternion);
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        protected FloatQuaternion()
        {

        }

        #endregion

        #region IFloatQuaternion Members

        float IFloatQuaternion.W
        {
            get
            {
                return w;
            }
        }

        float IFloatQuaternion.X
        {
            get
            {
                return x;
            }
        }

        float IFloatQuaternion.Y
        {
            get
            {
                return y;
            }
        }

        float IFloatQuaternion.Z
        {
            get
            {
                return x;
            }
        }

        void IFloatQuaternion.Copy(IFloatQuaternion quatetrnion)
        {
            w = quatetrnion.W;
            x = quatetrnion.X;
            y = quatetrnion.Y;
            z = quatetrnion.Z;
        }

        #endregion
    }
}
