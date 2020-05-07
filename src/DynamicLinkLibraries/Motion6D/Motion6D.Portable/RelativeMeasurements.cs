using System;
using System.Collections.Generic;
using System.Text;

using CategoryTheory;

using Diagram.UI;

using DataPerformer.Portable.Measurements;
using DataPerformer.Interfaces;

using Motion6D.Interfaces;

namespace Motion6D.Portable
{
    /// <summary>
    /// Relative measurements
    /// </summary>
    public class RelativeMeasurements : CategoryObject, IMeasurements, IPostSetArrow
    {

        #region Fields

        const Double a = 0;


        private IPosition source;


        private IPosition target;

        private IVelocity vSource;

        private IVelocity vTarget;

        private IOrientation oSource;

        private IOrientation oTarget;

        private IAngularVelocity aSource;

        private IAngularVelocity aTarget;


        private double[] relativePos = new double[3];

        private double[] relative = new double[3];

        private double[] quaternion = new double[4];



        private IMeasurement[] measurements;

        private bool isUpdated;

        private double distance;

        private double[] relativeVelocity = new double[3];

        private double velocity;

        private Func<object>[] coordDel;

        private static readonly string[] names = new string[] {"x", "y", "z", "Distance", "Vx", "Vy", "Vz", "Velocity", "Q0", "Q1", "Q2", "Q3",
                                                                  "OMx", "OMy", "OMz", "A11", "A12", "A13", "A21", "A22", "A23", "A31", "A32", "A33"};

        private Action UpdateAll;

        private ReferenceFrame targetFrame;

        private ReferenceFrame relativeFrame = new ReferenceFrame();

        private ReferenceFrame sourceFrame;

        private double[] omegaRProduct = new double[3];

        private double[] matrixPosition = new double[3];

        private double[] matrixVelocity = new double[3];

        private double[] omegaRelative = new double[3];

        #endregion

        #region Ctor


        /// <summary>
        /// Default constructor
        /// </summary>
        public RelativeMeasurements()
        {
            coordDel = new Func<object>[] { GetX, GetY, GetZ };
        }


        #endregion

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get { return measurements.Length; }
        }

        IMeasurement IMeasurements.this[int n]
        {
            get { return measurements[n]; }
        }

        void IMeasurements.UpdateMeasurements()
        {
            try
            {
                UpdateAll();
            }
            catch (Exception e)
            {
                e.ShowError(10);
                this.Throw(e);
            }
        }




        bool IMeasurements.IsUpdated
        {
            get
            {
                return isUpdated;
            }
            set
            {
                isUpdated = value;
            }
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            CreateMeasurements();
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// Source Position
        /// </summary>
        public IPosition Source
        {
            get
            {
                return source;
            }
            set
            {
                if (source != null & value != null)
                {
                    throw new Exception("Souce already exists");
                }
                source = value;
                GetParameters(source, ref vSource, ref oSource, ref aSource);
                CreateMeasurements();
            }
        }

        /// <summary>
        /// Target position
        /// </summary>
        public IPosition Target
        {
            get
            {
                return target;
            }
            set
            {
                if (target != null & value != null)
                {
                    throw new Exception("Target already exists");
                }
                target = value;
                GetParameters(target, ref vTarget, ref oTarget, ref aTarget);
                CreateMeasurements();
            }
        }

        void updDistance()
        {
            double[] y = source.Position;
            double[] x = target.Position;
            double dist = 0;
            for (int i = 0; i < 3; i++)
            {
                double dd = y[i] - x[i];
                dist += dd * dd;
                relativePos[i] = dd;
            }
            distance = Math.Sqrt(dist);
        }

        void UpdateAngularVelocity()
        {
            Vector3D.StaticExtensionVector3D.QuaternionInvertOmega(quaternion, aSource.Omega, omegaRelative);
            double[] om = aTarget.Omega;
            for (int i = 0; i < 3; i++)
            {
                omegaRelative[i] = om[i] - omegaRelative[i];
            }
        }

        void UpdateRelativePosition()
        {
            double[] y = source.Position;
            double[] x = target.Position;
            double dist = 0;
            for (int i = 0; i < 3; i++)
            {
                double dd = y[i] - x[i];
                dist += dd * dd;
                relative[i] = dd;
            }
            distance = Math.Sqrt(dist);
            ReferenceFrame f = ReferenceFrame.GetOwnFrame(target);
            f.CalculateRotatedPosition(relative, relativePos);
        }



        object GetDistance()
        {
            return distance;
        }

        object GetVelocity()
        {
            return velocity;
        }

        object GetX()
        {
            return relativePos[0];
        }

        object GetY()
        {
            return relativePos[1];
        }

        object GetZ()
        {
            return relativePos[2];
        }

        object GetVx()
        {
            return relativeVelocity[0];
        }

        object GetVy()
        {
            return relativeVelocity[1];
        }

        object GetVz()
        {
            return relativeVelocity[2];
        }

        object GetQ0()
        {
            return quaternion[0];
        }

        object GetQ1()
        {
            return quaternion[1];
        }

        object GetQ2()
        {
            return quaternion[2];
        }

        object GetQ3()
        {
            return quaternion[3];
        }


        object GetOmegaX()
        {
            return omegaRelative[0];
        }


        object GetOmegaY()
        {
            return omegaRelative[1];
        }


        object GetOmegaZ()
        {
            return omegaRelative[2];
        }


        void GetParameters(IPosition p, ref IVelocity velocity, ref IOrientation orientation, ref IAngularVelocity om)
        {
            velocity = null;
            orientation = null;
            om = null;
            IPosition pa = p;
            if (p is IReferenceFrame)
            {
                IReferenceFrame f = p as IReferenceFrame;
                pa = f.Own;
            }
            if (pa is IVelocity)
            {
                velocity = pa as IVelocity;
            }
            else
            {
                velocity = null;
            }
            if (pa is IOrientation)
            {
                orientation = pa as IOrientation;
            }
            else
            {
                orientation = null;
            }
            if (pa is IAngularVelocity)
            {
                om = pa as IAngularVelocity;
            }
            else
            {
                om = null;
            }
        }

        void PostCreateMeasurements()
        {
            CreateConside();
            IMeasurement[] acc = CreateAccMeasurements();
            IMeasurement[] vel = CreateVelocityMeasurements(acc);
            IMeasurement[] coord = CreateCoordMeasurements(vel);
            if (vel != null)
            {
                if (vel.Length > 0)
                {
                    measurements = new IMeasurement[8];
                    Array.Copy(coord, measurements, 4);
                    Array.Copy(vel, 0, measurements, 4, 4);
                    UpdateAll = UpdateCoinDistance;
                    UpdateAll += UpdateCoinVelocity;
                    if (oTarget != null)
                    {
                        UpdateAll += UpdateOrientationCoordinates;
                    }
                    if (oTarget != null)
                    {
                        UpdateAll += UpdateOrientationVelocity;
                    }
                    if (aTarget != null)
                    {
                        UpdateAll += AddAngularVelocity;
                    }
                    if ((oSource != null) & (oTarget != null))
                    {
                        UpdateAll += UpdateQuaternion;
                    }
                    if ((aSource != null) & (aTarget != null))
                    {
                        UpdateAll += UpdateAngularVelocity;
                    }
                }
                else
                {
                    measurements = new IMeasurement[4];
                    Array.Copy(coord, measurements, 4);
                }
            }
            else
            {
                measurements = new IMeasurement[4];
                Array.Copy(coord, measurements, 4);
            }
            List<IMeasurement> lm = new List<IMeasurement>();
            lm.AddRange(measurements);
            lm.AddRange(CreateQuatenionMeasurements());
            lm.AddRange(CreateAngularVelicity());
            measurements = lm.ToArray();
        }

        private void CreateMeasurements()
        {
            measurements = new IMeasurement[0];
            if (source == null | target == null)
            {
                return;
            }
            if (!CreateConside())
            {
                return;
            }
            Func<object> mpd = GetDistance;
            GetParameters(target, ref vTarget, ref oTarget, ref aTarget);
            GetParameters(source, ref vSource, ref oSource, ref aSource);
            CreateConside();
            sourceFrame = ReferenceFrame.GetOwnFrame(source);
            targetFrame = ReferenceFrame.GetOwnFrame(target);
            PostCreateMeasurements();
        }


        bool CreateConside()
        {

            if (!(target is IReferenceFrame))
            {
                if (target is IPosition)
                {
                    UpdateAll = UpdateCoinDistance;
                    measurements = new IMeasurement[]
                    {
                        new Measurement(GetDistance, names[3])
                    };
                }
                return false;
            }
            IReferenceFrame f = target as IReferenceFrame;
            ReferenceFrame o = f.Own;
            ReferenceFrame p = ReferenceFrame.GetOwnFrame(source);
            if (p == o)
            {
                return false;
            }
            UpdateAll = UpdateCoinDistance;
            if ((source is IVelocity) & (target is IVelocity))
            {
                vSource = source as IVelocity;
                UpdateAll += UpdateCoinVelocity;
            }
            if (oTarget != null)
            {
                UpdateAll += UpdateOrientationCoordinates;
            }
            if (oTarget != null)
            {
                UpdateAll += UpdateOrientationVelocity;
            }
            if (aTarget != null)
            {
                UpdateAll += AddAngularVelocity;
            }

            if ((oSource != null) & (oTarget != null))
            {
                UpdateAll += UpdateQuaternion;
            }
            return true;
        }

        void UpdateCoinDistance()
        {
            double[] y = source.Position;
            double[] x = target.Position;
            double a = 0;
            for (int i = 0; i < 3; i++)
            {
                double z = y[i] - x[i];
                relativePos[i] = z;
                a += z * z;
            }
            distance = Math.Sqrt(a);
        }

        void UpdateOrientation(double[] x, double[] aux)
        {
            double[,] m = oTarget.Matrix;
            RealMatrixProcessor.RealMatrix.Multiply(x, m, aux);
            Array.Copy(aux, x, 3);
        }


        void UpdateOrientationCoordinates()
        {
            UpdateOrientation(relativePos, matrixPosition);
        }


        void UpdateOrientationVelocity()
        {
            UpdateOrientation(relativeVelocity, matrixVelocity);
        }

        void UpdateCoinVelocity()
        {
            double[] vs = vSource.Velocity;
            double[] vt = vTarget.Velocity;
            double a = 0;
            for (int i = 0; i < 3; i++)
            {
                double x = vs[i] - vt[i];
                relativeVelocity[i] = x;
                a += x * relativePos[i];
            }
            velocity = a / distance;
        }

        void UpdateQuaternion()
        {
            Vector3D.StaticExtensionVector3D.QuaternionInvertMultiply(oSource.Quaternion, oTarget.Quaternion, quaternion);
        }

        void AddAngularVelocity()
        {
            double[] om = aTarget.Omega;
            Vector3D.StaticExtensionVector3D.VectorPoduct(relativePos, om, omegaRProduct);
            RealMatrixProcessor.RealMatrix.PlusEqual(relativeVelocity, omegaRProduct);
        }


        IMeasurement[] zero
        {
            get
            {
                return new IMeasurement[0];
            }
        }

        IMeasurement[] CreateCoordMeasurements(IMeasurement[] vel)
        {
            Func<object>[] pars = new Func<object>[] { GetX, GetY, GetZ };
            List<IMeasurement> meas = new List<IMeasurement>();
            for (int i = 0; i < 3; i++)
            {
                if (vel == null)
                {
                    meas.Add(new Measurement(pars[i], names[i]));
                }
                else
                {
                    if (vel.Length < 3)
                    {
                        meas.Add(new Measurement(pars[i], names[i]));
                    }
                    else
                    {
                        meas.Add(new MeasurementDerivation(pars[i], vel[i], names[i]));
                    }
                }
            }
            if (vel == null)
            {
                meas.Add(new Measurement(GetDistance, names[3]));
            }
            else
            {
                if (vel.Length < 4)
                {
                    meas.Add(new Measurement(GetDistance, names[3]));
                }
                else
                {
                    meas.Add(new MeasurementDerivation(GetDistance, vel[3], names[3]));
                }
            }
            return meas.ToArray();

        }




        IMeasurement[] CreateVelocityMeasurements(IMeasurement[] acc)
        {
            if ((vSource == null) | (vTarget == null))
            {
                return new IMeasurement[0];
            }
            Func<object>[] pars = new Func<object>[] { GetVx, GetVy, GetVz };
            IMeasurement[] meas = new IMeasurement[4];
            for (int i = 0; i < 3; i++)
            {
                if (acc != null)
                {
                    if (acc.Length > 0)
                    {
                        meas[i] = new MeasurementDerivation(pars[i], acc[i], names[i + 4]);
                    }
                    else
                    {
                        meas[i] = new Measurement(pars[i], names[i + 4]);
                    }
                }
                else
                {
                    meas[i] = new MeasurementDerivation(pars[i], acc[i], names[i + 4]);
                }
            }
            meas[3] = new Measurement(GetVelocity, names[7]);
            return meas;
        }

        IMeasurement[] CreateAngularVelicity()
        {
            if ((aSource == null) | (aTarget == null))
            {
                return new IMeasurement[0];
            }
            IMeasurement[] measurements = new IMeasurement[3];
            Func<object>[] parameters = new Func<object>[] { GetOmegaX, GetOmegaY, GetOmegaZ };
            for (int i = 0; i < parameters.Length; i++)
            {
                measurements[i] = new Measurement(parameters[i], names[12 + i]);
            }
            return measurements;
        }

        IMeasurement[] CreateQuatenionMeasurements()
        {
            if ((oSource == null) | (oTarget == null))
            {
                return new IMeasurement[0];
            }
            Func<object>[] pars = new Func<object>[] { GetQ0, GetQ1, GetQ2, GetQ3 };
            IMeasurement[] m = new IMeasurement[pars.Length];
            for (int i = 0; i < m.Length; i++)
            {
                m[i] = new Measurement(pars[i], names[8 + i]);
            }
            return m;
        }

        IMeasurement[] CreateAccMeasurements()
        {
            return new IMeasurement[0];
        }


        #endregion

    }
}