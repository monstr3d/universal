using System;
using System.Collections.Generic;

using CategoryTheory;

using Diagram.UI;

using DataPerformer.Portable.Measurements;
using DataPerformer.Interfaces;

using Motion6D.Interfaces;

using Vector3D;

using RealMatrixProcessor;

namespace Motion6D.Portable
{
    /// <summary>
    /// Relative measurements
    /// </summary>
    public class RelativeMeasurements : CategoryObject, IMeasurements, 
        IPostSetArrow
    {

        #region Fields

        EulerAngles angles = new EulerAngles();

        const double a = 0;

        double[] aux = new double[3];


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

        private IMeasurement measurementFrame;

        private IMeasurement[] measurements;

        private bool isUpdated;

        private double distance;

        private double[] relativeVelocity = new double[3];

        private double velocity;

        private Func<object>[] coordDel;

        private static readonly string[] names = new string[] {"x", "y", "z", "Distance", 
            "Vx", "Vy", "Vz", "Velocity", "Q0", "Q1", "Q2", "Q3", "Roll", "Pitch", "Yaw",
            "OMx", "OMy", "OMz", "A11", "A12", "A13", "A21", "A22", "A23", "A31", "A32", "A33"};

        private Action UpdateAll;

        private ReferenceFrame targetFrame;

        private ReferenceFrame relativeFrame;

        private IAngularVelocity angularVelocity;

        private IVelocity ivelocity;


        private ReferenceFrame sourceFrame;

        private double[] omegaRProduct = new double[3];

        private double[] matrixPosition = new double[3];

        private double[] matrixVelocity = new double[3];

        private double[] omegaRelative = new double[3];

        Action updFrame;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RelativeMeasurements()
        {
            measurementFrame = new Measurement(typeof(ReferenceFrame), GetFrame, "Frame",  this);
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
                updFrame();
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

        #region Public

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

        #endregion

        #region Private

        void UpdateFrame()
        {
            Array.Copy(relativePos, relativeFrame.Position, 3);
            Array.Copy(quaternion, relativeFrame.Quaternion, 4);
            angles.Set(quaternion);
        }

        void UpdateFrameAngularVelocity()
        {
            Array.Copy(omegaRelative, angularVelocity.Omega, 3);
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
            aTarget.Omega.Multiply(relativeFrame.Matrix, aux);
            double[] om = aSource.Omega;
            for (int i = 0; i < 3; i++)
            {
                omegaRelative[i] = om[i] - aux[i];
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

        object GetFrame()
        {
            return relativeFrame;
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

        object GetRoll()
        {
            return angles.roll;
        }

        object GetPitch()
        {
            return angles.pitch;
        }

        object GetYaw()
        {
            return angles.yaw;
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
            relativeFrame = targetFrame.GetRelative(sourceFrame);
            List<IMeasurement> lm = new List<IMeasurement>();
            lm.AddRange(measurements);
            lm.AddRange(CreateQuatenionMeasurements());
            lm.AddRange(CreateAngularVelicity());
            lm.Add(measurementFrame);
            measurements = lm.ToArray();
            updFrame = UpdateFrame;
            if (relativeFrame is IAngularVelocity)
            {
                angularVelocity = relativeFrame as IAngularVelocity;
                updFrame += UpdateFrameAngularVelocity;
            }
            if (relativeFrame is IVelocity)
            {
                ivelocity = relativeFrame as IVelocity;
            }


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
                        new Measurement(GetDistance, names[3], this)
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
            if (oSource != null & oTarget != null)
            {
                UpdateAll += UpdateRelativePosition;
            }
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
                if ((source is IVelocity) & (target is IVelocity))
                {
                    UpdateAll += UpdateVelocityRotation;
                }
            }
            return true;
        }

        void UpdateVelocityRotation()
        {
            ReferenceFrame f = ReferenceFrame.GetOwnFrame(target);
            f.CalculateRotatedPosition(relativeVelocity, aux);
            Array.Copy(aux, relativeVelocity, 3);
            Array.Copy(relativeVelocity, ivelocity.Velocity, 3);
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
            x.Multiply(m, aux);
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
            Array.Copy(relativeVelocity, ivelocity.Velocity, 3);
        }

        void UpdateQuaternion()
        {
            oTarget.Quaternion.QuaternionInvertMultiply(oSource.Quaternion, quaternion);
            Array.Copy(quaternion, relativeFrame.Quaternion, 3);
            relativeFrame.SetMatrix();
        }

        void AddAngularVelocity()
        {
            double[] om = aTarget.Omega;
            relativePos.VectorPoduct(om, omegaRProduct);
            relativeVelocity.PlusEqual( omegaRProduct);
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
                    meas.Add(new Measurement(pars[i], names[i], this));
                }
                else
                {
                    if (vel.Length < 3)
                    {
                        meas.Add(new Measurement(pars[i], names[i],this));
                    }
                    else
                    {
                        meas.Add(new MeasurementDerivation(pars[i], vel[i], names[i], this));
                    }
                }
            }
            if (vel == null)
            {
                meas.Add(new Measurement(GetDistance, names[3], this));
            }
            else
            {
                if (vel.Length < 4)
                {
                    meas.Add(new Measurement(GetDistance, names[3], this));
                }
                else
                {
                    meas.Add(new MeasurementDerivation(GetDistance, vel[3], names[3], this));
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
                        meas[i] = new MeasurementDerivation(pars[i], acc[i], names[i + 4], this);
                    }
                    else
                    {
                        meas[i] = new Measurement(pars[i], names[i + 4], this);
                    }
                }
                else
                {
                    meas[i] = new MeasurementDerivation(pars[i], acc[i], names[i + 4], this);
                }
            }
            meas[3] = new Measurement(GetVelocity, names[7], this);
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
                measurements[i] = new Measurement(parameters[i], names[15 + i], this);
            }
            return measurements;
        }

        IMeasurement[] CreateQuatenionMeasurements()
        {
            if ((oSource == null) | (oTarget == null))
            {
                return new IMeasurement[0];
            }
            Func<object>[] pars = new Func<object>[] { GetQ0, GetQ1, GetQ2, GetQ3, 
                GetRoll, GetPitch, GetYaw };
            IMeasurement[] m = new IMeasurement[pars.Length];
            for (int i = 0; i < m.Length; i++)
            {
                m[i] = new Measurement(pars[i], names[8 + i], this);
            }
            return m;
        }

        IMeasurement[] CreateAccMeasurements()
        {
            return new IMeasurement[0];
        }
   
        #endregion

        #endregion

    }
}