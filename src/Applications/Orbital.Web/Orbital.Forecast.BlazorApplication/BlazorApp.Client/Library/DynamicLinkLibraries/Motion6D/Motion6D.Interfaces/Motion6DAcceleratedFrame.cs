using System;
using System.Collections.Generic;
using System.Text;

using Vector3D;
using RealMatrixProcessor;
using Motion6D.Interfaces;

namespace Motion6D
{
    /// <summary>
    /// Accelerated reference frame
    /// </summary>
    public class Motion6DAcceleratedFrame : Motion6DFrame, IAcceleration, IAngularAcceleration
    {
        #region Fields


        double[] relativeAcceleration = new double[] { 0, 0, 0 };

        double[] acceleration = new double[] { 0, 0, 0 };

        double[] angularAcceleration = new double[] { 0, 0, 0 };

        double[] temp = new double[3];
        
        double[] tempV = new double[3];

        #endregion

        #region Overriden

        /// <summary>
        /// Sets state
        /// </summary>
        /// <param name="baseFrame">Base frame</param>
        /// <param name="relative">Relative frame</param>
        public override void Set(ReferenceFrame baseFrame, ReferenceFrame relative)
        {
            base.Set(baseFrame, relative);
            IAngularAcceleration arn = relative as IAngularAcceleration;
            IVelocity relativeVelocity = relative as IVelocity;
            IAngularVelocity baseAngulatVelocity = baseFrame as IAngularVelocity;
            IAngularVelocity relativeAngularVelocity = relative as IAngularVelocity;
            double[] rp = Position;
            double[,] m = Matrix;
            double[] relativeOmega = relativeAngularVelocity.Omega;
            double[] baseOmega = baseAngulatVelocity.Omega;
            StaticExtensionVector3D.VectorPoduct(baseOmega, relativeVelocity.Velocity, tempV);
            double om2 = StaticExtensionVector3D.Square3d(baseOmega);
            double[] eps = arn.AngularAcceleration;
            StaticExtensionVector3D.VectorPoduct(eps, rp, temp);
            for (int i = 0; i < 3; i++)
            {
                tempV[i] *= 2;
                tempV[i] += om2 * rp[i] + relativeAcceleration[i] + temp[i]; 
            }
            StaticExtensionRealMatrix.Multiply(m, tempV, acceleration);
            IOrientation relativeOrientation = relative;
            double[,] relativeMatrix = relativeOrientation.Matrix;
            StaticExtensionRealMatrix.Multiply(baseOmega, relativeMatrix, temp);
            StaticExtensionVector3D.VectorPoduct(temp, relativeOmega, tempV);
            for (int i = 0; i < 3; i++)
            {
                temp[i] = eps[i] + tempV[i];
            }
            StaticExtensionRealMatrix.Multiply(temp, m, angularAcceleration);
        }

        #endregion

        #region IAcceleration Members

        double[] IAcceleration.LinearAcceleration
        {
            get { return acceleration; }
        }

        double[] IAcceleration.RelativeAcceleration
        {
            get { return relativeAcceleration; }
        }

        #endregion

        #region IAngularAcceleration Members

        double[] IAngularAcceleration.AngularAcceleration
        {
            get { return angularAcceleration; }
        }

        #endregion
    }
}
