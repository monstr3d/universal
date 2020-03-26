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
            IAcceleration ab = baseFrame as IAcceleration;
            IAcceleration ar = relative as IAcceleration;
            IAngularAcceleration arn = relative as IAngularAcceleration;
            IVelocity vb = baseFrame as IVelocity;
            IVelocity vr = relative as IVelocity;
            IAngularVelocity anb = baseFrame as IAngularVelocity;
            IAngularVelocity anr = relative as IAngularVelocity;
            double[] rp = Position;
            double[,] m = Matrix;
            double[] omr = anr.Omega;
            StaticExtensionVector3D.VectorPoduct(omr, vr.Velocity, tempV);
            double om2 = StaticExtensionVector3D.Square(omr);
            double[] eps = arn.AngularAcceleration;
            StaticExtensionVector3D.VectorPoduct(eps, rp, temp);
            for (int i = 0; i < 3; i++)
            {
                tempV[i] *= 2;
                tempV[i] += om2 * rp[i] + relativeAcceleration[i] + temp[i]; 
            }
            RealMatrix.Multiply(m, tempV, acceleration);
            double[] omb = anb.Omega;
            IOrientation orr = relative as IOrientation;
            double[,] mrr = orr.Matrix;
            RealMatrix.Multiply(omb, mrr, temp);
            StaticExtensionVector3D.VectorPoduct(temp, omr, tempV);
            for (int i = 0; i < 3; i++)
            {
                temp[i] = eps[i] + tempV[i];
            }
            RealMatrix.Multiply(temp, m, angularAcceleration);

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
