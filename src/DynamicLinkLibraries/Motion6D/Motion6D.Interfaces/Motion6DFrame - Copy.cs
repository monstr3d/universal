using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using Motion6D.Interfaces;

namespace Motion6D
{

    /// <summary>
    /// Moved reference frame
    /// </summary>
    public class Motion6DFrame : RotatedFrame, IVelocity
    {

        #region Fields

        /// <summary>
        /// Basic frame for all frames
        /// </summary>
        public static readonly Motion6DFrame Base = new Motion6DAcceleratedFrame();

        double[] velocity = new double[] { 0, 0, 0 };
        
        double[] hv = new double[3];

        //protected double[] relativeVelocity = new double[] { 0, 0, 0 };

        /// <summary>
        /// Derivation
        /// </summary>
        protected double[] der = new double[4];

        /// <summary>
        /// Quaternion derivation
        /// </summary>
        protected double[] qd = new double[4];

        #endregion

        #region Ctor

        #endregion

        #region IVelocity Members

        double[] IVelocity.Velocity
        {
            get { return velocity; }
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
            IOrientation bo = baseFrame as IOrientation;
            IOrientation ro = relative as IOrientation;
            IVelocity bv = baseFrame as IVelocity;
            IVelocity rv = relative as IVelocity;
            IAngularVelocity oa = baseFrame as IAngularVelocity;
            IAngularVelocity ra = relative as IAngularVelocity;
            double[] vb = bv.Velocity;
            double[] vr = rv.Velocity;
            double[,] mb = bo.Matrix;
            double[,] m = ro.Matrix;
            double[] om = oa.Omega;
            double[] pos = relative.Position;
            Vector3D.StaticExtensionVector3D.VectorPoduct(om, pos, hv);
            for (int i = 0; i < 3; i++)
            {
                velocity[i] = vb[i];
                for (int j = 0; j < 3; j++)
                {
                    velocity[i] += mb[i, j] * (vr[j] + hv[j]);
                }
            }
        }

        #endregion

    }
}
