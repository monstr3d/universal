using System;
using System.Collections.Generic;

using NamedTree;

using RealMatrixProcessor;

using Vector3D;

namespace Motion6D.Interfaces
{
    /// <summary>
    /// Reference frame
    /// </summary>
    public class ReferenceFrame : IPosition, IOrientation
    {

        #region Fields

        protected static Performer StaticPerformer = new Performer();

        protected RealMatrix realMatrix = new ();

        protected Vector3DProcessor vp = new();

        protected static Vector3DProcessor vps = new ();

        /// <summary>
        /// Orientation quaternion
        /// </summary>
        protected double[] quaternion = new double[] { 1, 0, 0, 0 };

        /// <summary>
        /// Absolute position
        /// </summary>
        protected double[] position = new double[] { 0, 0, 0 };

        /// <summary>
        /// Orientation matrix
        /// </summary>
        protected double[,] matrix = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };

        /// <summary>
        /// Auxiliary array
        /// </summary>
        protected double[,] qq = new double[4, 4];

        /// <summary>
        /// Auxiliary array
        /// </summary>
        protected double[] p = new double[3];

        /// <summary>
        /// Parent frame
        /// </summary>
        protected IReferenceFrame parent;

        /// <summary>
        /// Parameters
        /// </summary>
        protected object parameters;

        /// <summary>
        /// Auxliary position
        /// </summary>
        private double[] auxPos = new double[3];

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        public ReferenceFrame()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="b">Auxiliary</param>
        private ReferenceFrame(bool b)
        {
        }

        event Action<IPosition> INode<IPosition>.OnAdd
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event Action<IPosition> INode<IPosition>.OnRemove
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region IPosition Members

        /// <summary>
        /// Absolute position
        /// </summary>
        public double[] Position
        {
            get { return position; }
        }

        /// <summary>
        /// Parent frame
        /// </summary>
        public virtual IReferenceFrame Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }

        /// <summary>
        /// Position parameters
        /// </summary>
        public virtual object Parameters
        {
            get
            {
                return parameters;
            }
            set
            {
                parameters = value;
            }
        }

        /// <summary>
        /// Gets frame of position
        /// </summary>
        /// <param name="position">The position</param>
        /// <returns>The frame of the position</returns>
        static internal ReferenceFrame GetFrame(IPosition position)
        {
            if (position is IReferenceFrame)
            {
                IReferenceFrame f = position as IReferenceFrame;
                return f.Own;
            }
            return GetParentFrame(position);
        }

 
        /// <summary>
        /// Parent frame
        /// </summary>
        /// <param name="position">Position</param>
        /// <returns>Parent frame</returns>
        static internal ReferenceFrame GetParentFrame(IPosition position)
        {
            if (position.Parent == null)
            {
                return Motion6DFrame.Base;
            }
            return StaticPerformer.GetParentOwn(position);
        }

        /// <summary>
        /// Gets relative frame
        /// </summary>
        /// <param name="baseFrame">Base frame</param>
        /// <param name="targetFrame">Target frame</param>
        /// <param name="relative">Relative frame</param>
        static public void GetRelativeFrame(ReferenceFrame baseFrame, ReferenceFrame targetFrame, ReferenceFrame relative)
        {
            double[] bp = baseFrame.Position;
            double[] tp = targetFrame.Position;
            double[,] bm = baseFrame.Matrix;
            double[] rp = relative.Position;
            for (int i = 0; i < 3; i++)
            {
                rp[i] = 0;
                for (int j = 0; j < 3; j++)
                {
                    rp[i] += bm[j, i] * (tp[i] - bp[i]);
                }
            }
            double[,] tm = targetFrame.Matrix;
            double[,] rm = relative.Matrix;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    rm[i, j] = 0;
                    for (int k = 0; k < 3; k++)
                    {
                        rm[i, j] += bm[k, i] * tm[k, j];
                    }
                }
            }
        }

        /// <summary>
        /// Parent frame
        /// </summary>
        /// <param name="position">Position</param>
        /// <returns>Parent frame</returns>
        static public ReferenceFrame GetOwnFrame(IPosition position)
        {
            if (position is IReferenceFrame)
            {
                IReferenceFrame f = position as IReferenceFrame;
                return f.Own;
            }
            return GetParentFrame(position);
        }

        /// <summary>
        /// Updates itself
        /// </summary>
        public virtual void Update()
        {
            ReferenceFrame p = ParentFrame;
            position = p.Position;
            quaternion = p.quaternion;
            matrix = p.matrix;
        }

        #endregion

        #region IOrientation Members

        /// <summary>
        /// Orientation quaternion
        /// </summary>
        public double[] Quaternion
        {
            get { return quaternion; }
        }

        /// <summary>
        /// Orientation matrix
        /// </summary>
        public double[,] Matrix
        {
            get { return matrix; }
        }


        #endregion

        #region Specific Members

        #region Public Members

        /// <summary>
        /// Gets relative position
        /// </summary>
        /// <param name="inPosition">Input position</param>
        /// <param name="outPosition">Output position</param>
        public void GetRelativePosition(double[] inPosition, double[] outPosition)
        {
            for (int i = 0; i < 3; i++)
            {
                auxPos[i] =  inPosition[i] - position[i];
            }
            for (int i = 0; i < 3; i++)
            {
                outPosition[i] = 0;
                for (int j = 0; j < 3; j++)
                {
                    outPosition[i] += matrix[j, i] * auxPos[j];
                }
            }
        }

        /// <summary>
        /// Gets relative frame
        /// </summary>
        /// <param name="baseFrame">Base frame</param>
        /// <param name="relativeFrame">Relative frame</param>
        /// <param name="result">Result frame</param>
        /// <param name="diff">Difference between coordinates</param>
        static public void GetRelative(ReferenceFrame baseFrame, ReferenceFrame relativeFrame, 
            ReferenceFrame result, double[] diff)
        {
            vps.QuaternionInvertMultiply(relativeFrame.quaternion, baseFrame.quaternion, result.quaternion);
            result.SetMatrix();
            for (int i = 0; i < 3; i++)
            {
                diff[i] = relativeFrame.position[i] - baseFrame.position[i];
            }
            double[,] m = baseFrame.Matrix;
            double[] p = result.position;
            for (int i = 0; i < 3; i++)
            {
                p[i] = 0;
                for (int j = 0; j < 3; j++)
                {
                    p[i] += m[j, i] * diff[j];
                }
            }

        }

        /// <summary>
        /// Gets relative frame
        /// </summary>
        /// <param name="baseFrame">Base frame</param>
        /// <param name="relativeFrame">Relative frame</param>
        /// <param name="result">Result frame</param>
        /// <param name="diff">Difference between coordinates</param>
        /// <param name="matrix4">The 4 * 4 perspective matrix</param>
        static public void GetRelative(ReferenceFrame baseFrame, ReferenceFrame relativeFrame,
             ReferenceFrame result, double[] diff, double[,] matrix4)
        {
            GetRelative(baseFrame, relativeFrame, result, diff);
            double[,] m = result.Matrix;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix4[i, j] = m[i, j];
                }
            }
            double[] p = result.position;
            for (int i = 0; i < 3; i++)
            {
                matrix4[3, i] = p[i];
                matrix4[i, 3] = 0;
            }
            matrix4[3, 3] = 1;
        }


        /// <summary>
        /// Gets relative frame
        /// </summary>
        /// <param name="baseFrame">Base frame</param>
        /// <param name="relativeFrame">Relative frame</param>
        /// <param name="result">Result frame</param>
        /// <param name="diff">Difference between coordinates</param>
        /// <param name="matrix4">The 4 * 4 perspective matrix</param>
        /// <param name="array16">One dimensional array that correspond to perspective matrix</param>
        static public void GetRelative(ReferenceFrame baseFrame, ReferenceFrame relativeFrame,
               ReferenceFrame result, double[] diff, double[,] matrix4, double[] array16)
        {
            GetRelative(baseFrame, relativeFrame, result, diff, matrix4);
            for (int i = 0; i < 4; i++)
            {
                int k = 4 * i;
                for (int j = 0; j < 4; j++)
                {
                    array16[k + j] = matrix4[i, j];
                }
            }
        }
        

        /// <summary>
        /// Calculates matrix for object view
        /// </summary>
        /// <param name="position">Relative position</param>
        /// <param name="rotation">Rotation angle</param>
        /// <returns>View matrix</returns>
        static public double[,] CalucateViewMatrix(double[] position, double rotation)
        {
            double[] r = position;
            double ap = 0;
            ap = r[0] * r[0] + r[2] * r[2];
            double a = ap + r[1] * r[1];
            ap = Math.Sqrt(ap);
            a = Math.Sqrt(a);
            double[] ez = { r[0] / a, r[1] / a, r[2] / a };
            double[] ex1 = null;
            if (ap < 0.00000000001)
            {
                ex1 = new double[] { 1.0, 0.0, 0.0 };
            }
            else
            {
                ex1 = new double[] { -r[2] / ap, 0, r[0] / ap };
            }
            double[] ey1 = {ez[1] * ex1[2] - ez[2] * ex1[1],
							   ez[2] * ex1[0] - ez[0] * ex1[2],
							   ez[0] * ex1[1] - ez[1] * ex1[0]};
            double[] ey = new double[3];
            double[] ex = new double[3];
            double alpha = rotation;
            alpha *= Math.PI / 180.0;
            alpha += Math.PI;
            double s = 0;
            double c = 1;
            double sD2 = Math.Sin(alpha / 2);
            double cD2 = Math.Cos(alpha / 2);
            double[] rc = { r[0], r[1] };
            r[0] = rc[0] * c - rc[1] * s;
            r[1] = rc[1] * s + rc[1] * c;
            ex = ex1;
            ey = ey1;
            double[][] m = { ex, ey, ez };
            double[] rr = { r[1], r[2], r[0] };

            double[,] mat = new double[4, 4];
            for (int i = 0; i < 3; i++)
            {
                mat[3, i] = r[i];
                for (int j = 0; j < 3; j++)
                {
                    mat[j, i] = m[j][i];
                }
            }

            double[][] temp = new double[3][];
            temp[0] = new double[] { c, s, 0 };
            temp[1] = new double[] { -s, c, 0 };
            temp[2] = new double[] { 0, 0, 1 };
            double[,] mh = new double[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    mh[i, j] = 0;
                    for (int k = 0; k < 3; k++)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            mh[i, j] += mat[i, k] * temp[k][l] * mat[j, l];
                        }
                    }
                }
            }
            double[,] mh1 = new double[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    mh1[i, j] = mat[i, j];
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    mat[i, j] = 0;
                    for (int k = 0; k < 3; k++)
                    {
                        mat[i, j] += mh[i, k] * mh1[k, j];
                    }
                }
            }

            for (int i = 0; i < 3; i++)
            {
                rr[i] = 0;
                for (int j = 0; j < 3; j++)
                {
                    rr[i] += mat[i, j] * mat[3, j];
                }
            }
            double[,] matr = new double[3, 3];
            double[] rp = new double[3];
            for (int i = 0; i < 3; i++)
            {
                rp[i] = mat[3, i];
                for (int j = 0; j < 3; j++)
                {
                    matr[i, j] = mat[j, i];
                }
            }
            double[,] qq = new double[4, 4];
            double[] e = vps.VectorNorm3d(rp);
            double[] q = new double[] { cD2, e[0] * sD2, e[1] * sD2, e[2] * sD2 };
            double[,] mq = new double[3, 3];
            vps.QuaternionToMatrix(q, mq, qq);
            double[,] mr = new double[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    mr[i, j] = 0;
                    for (int k = 0; k < 3; k++)
                    {
                        mr[i, j] += mq[i, k] * matr[k, j];
                    }
                }
            }
            return mr;
        }


        /// <summary>
        /// Calculates rotated position
        /// </summary>
        /// <param name="abs">Absolute position</param>
        /// <param name="rot">Rotated position</param>
        public void CalculateRotatedPosition(double[] abs, double[] rot)
        {
            for (int i = 0; i < 3; i++)
            {
                rot[i] = 0;
                for (int j = 0; j < 3; j++)
                {
                    rot[i] += matrix[j, i] * abs[j]; 
                }
            }
        }

        /// <summary>
        /// Sets state
        /// </summary>
        /// <param name="baseFrame">Base frame</param>
        /// <param name="relative">Relative frame</param>
        public virtual void Set(ReferenceFrame baseFrame, ReferenceFrame relative)
        {
            for (int i = 0; i < 3; i++)
            {
                position[i] = baseFrame.position[i];
                for (int j = 0; j < 3; j++)
                {
                    position[i] += baseFrame.matrix[i, j] * relative.position[j];
                }
            }
            vp.QuaternionMultiply(baseFrame.quaternion, relative.quaternion, quaternion);
            SetMatrix();
        }

        /// <summary>
        /// Sets matrix
        /// </summary>
        public void SetMatrix()
        {
            Norm();
            vp.QuaternionToMatrix(quaternion, matrix, qq);
        }


        /// <summary>
        /// Gets relative position
        /// </summary>
        /// <param name="position">The position</param>
        /// <param name="coordinates">Relative coordinates</param>
        public void GetPositon(IPosition position, double[] coordinates)
        {
            double[] p1 = this.position;
            double[] p2 = position.Position;
            for (int i = 0; i < 3; i++)
            {
                p[i] = p2[i] - p1[i];
            }
            for (int i = 0; i < 3; i++)
            {
                coordinates[i] = 0;
                for (int j = 0; j < 3; j++)
                {
                    coordinates[i] += matrix[i, j] * p[j];
                }
            }
        }

        #endregion

        #region Protected Members

        /// <summary>
        /// Quaternion normalization
        /// </summary>
        protected void Norm()
        {
            vp.QuaternionNormalize(quaternion);
        }

        void INode<IPosition>.Add(INode<IPosition> node)
        {
            throw new NotImplementedException();
        }

        void INode<IPosition>.Remove(INode<IPosition> node)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Parent frame
        /// </summary>
        protected virtual ReferenceFrame ParentFrame
        {
            get
            {
                if (parent == null)
                {
                    return Motion6D.Motion6DFrame.Base;
                }
                return parent.Own;
            }
        }

        INode<IPosition> INode<IPosition>.Parent { get => Parent; set => throw new NotImplementedException(); }
        IEnumerable<INode<IPosition>> INode<IPosition>.Nodes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        IPosition INode<IPosition>.Value => throw new NotImplementedException();

        #endregion

        #endregion

    }
}
