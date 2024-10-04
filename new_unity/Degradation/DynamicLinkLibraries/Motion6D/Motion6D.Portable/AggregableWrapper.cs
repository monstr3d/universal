using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


using CategoryTheory;
using Diagram.UI;

using DataPerformer;
using DataPerformer.Interfaces;

using Motion6D.Interfaces;
using DataPerformer.Portable.Measurements;
using System.Reflection;

namespace Motion6D.Portable
{
    /// <summary>
    /// Wrapper of mechanical aggregate
    /// </summary>
    public class AggregableWrapper : CategoryObject, 
        IReferenceFrame,  IStarted,
        IChildrenObject, IMeasurements, IPostSetArrow
    {
        #region Fields

        /// <summary>
        /// Aggregate
        /// </summary>
        protected IAggregableMechanicalObject aggregate;

        /// <summary>
        /// Childen
        /// </summary>
        private IAssociatedObject[] children;

        /// <summary>
        /// Measurements
        /// </summary>
        private IMeasurement[] measurements;

        /// <summary>
        /// Type of measure
        /// </summary>
        internal static readonly Double type = 0;

        /// <summary>
        /// Derivation of quaternion
        /// </summary>
        private double[] quaterDerivation = new double[4];

        /// <summary>
        /// Angular velocity
        /// </summary>
        private double[] omega = new double[3];

        /// <summary>
        /// Quaternion
        /// </summary>
        private double[] quaternion = new double[4];

        /// <summary>
        /// Auxiliary array
        /// </summary>
        private double[,] qq = new double[4, 4];

        /// <summary>
        /// Own frame
        /// </summary>
        private Motion6DAcceleratedFrame relative = new Motion6DAcceleratedFrame();

        /// <summary>
        /// Own frame
        /// </summary>
        private Motion6DAcceleratedFrame own = new Motion6DAcceleratedFrame();

        /// <summary>
        /// Childen frames
        /// </summary>
        private List<IPosition> childFrames = new List<IPosition>();

        /// <summary>
        /// Parent frame
        /// </summary>
        private IReferenceFrame parentFrame;

        /// <summary>
        /// Parameters of position
        /// </summary>
        private object positionParameters;



        #endregion

        #region Ctor


        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="aggregateType">Type of aggregate</param>
        public AggregableWrapper(string aggregateType)
        {
            Type type = Type.GetType(aggregateType);
            ConstructorInfo constructor = type.GetConstructor(new Type[0]);
            aggregate = constructor.Invoke(new object[0]) as IAggregableMechanicalObject;
            Prepare();
        }


        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="aggregate">Prototype</param>
        public AggregableWrapper(IAggregableMechanicalObject aggregate)
        {
            this.aggregate = aggregate;
            Prepare();
        }

        /// <summary>
        /// Protected constructor
        /// </summary>
        protected AggregableWrapper()
        {

        }


        #endregion

        #region IReferenceFrame Members

        ReferenceFrame IReferenceFrame.Own
        {
            get { return own; }
        }

        List<IPosition> IReferenceFrame.Children
        {
            get { return childFrames; }
        }

        #endregion

        #region IPosition Members

        double[] IPosition.Position
        {
            get { return own.Position; }
        }

        IReferenceFrame IPosition.Parent
        {
            get
            {
                return parentFrame;
            }
            set
            {
                if (value != null)
                {
                    if (!(value.Own is IAcceleration))
                    {
                        throw new Exception("You should set accelerated frame");
                    }
                }
                parentFrame = value;
            }
        }

        object IPosition.Parameters
        {
            get
            {
                return positionParameters;
            }
            set
            {
                positionParameters = value;
            }
        }

        void IPosition.Update()
        {
            own.Set(BaseFrame, relative);
        }

        #endregion

        #region IStarted Members

        void IStarted.Start(double time)
        {
            double[] state = aggregate.State;
            Array.Copy(state, relative.Position, 3);
            IVelocity v = relative;
            Array.Copy(state, 3, v.Velocity, 0, 3);
            Array.Copy(state, 6, relative.Quaternion, 0, 4);
            IAngularVelocity av = relative;
            Array.Copy(state, 10, av.Omega, 0, 3);
        }


        #endregion
 
        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            if (aggregate is IPostSetArrow)
            {
                IPostSetArrow p = aggregate as IPostSetArrow;
                p.PostSetArrow();
            }
        }

        #endregion

        #region IChildrenObject Members

        IAssociatedObject[] IChildrenObject.Children
        {
            get { return children; }
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
            Array.Copy(aggregate.State, 6, quaternion, 0, 4);
            Array.Copy(aggregate.State, 10, omega, 0, 3);
            Vector3D.StaticExtensionVector3D.CalculateDynamics(quaternion, quaterDerivation, omega, qq);
        }

        bool IMeasurements.IsUpdated
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// Child aggregate
        /// </summary>
        public IAggregableMechanicalObject Aggregate
        {
            get
            {
                return aggregate;
            }
        }

        /// <summary>
        /// prepares itself
        /// </summary>
        protected void Prepare()
        {
            children = new IAssociatedObject[] { aggregate as IAssociatedObject };
            createMeasurements();
        }

        /// <summary>
        /// Creates Measurements
        /// </summary>
        private void createMeasurements()
        {
            measurements = new IMeasurement[aggregate.Dimension];
            string[] s = { "X", "Y", "Z", "Vx", "Vy", "Vz", "Q0", "Q1", "Q2", "Q3", "OMGx", "OMGy", "OMGz" };
            int n = 0;
            int nc = 0;
            int nv = 0;
            for (int i = 0; i < 3; i++)
            {
                measurements[n] = new CoordinateMeasurement(aggregate, nc, nc, s[n]);
                ++n;
                ++nc;
            }
            for (int i = 0; i < 3; i++)
            {
                measurements[n] = new VelocityMeasurememt(aggregate, nv, s[n]);
                ++n;
                ++nv;
            }
            for (int i = 0; i < 4; i++)
            {
                measurements[n] = new QuaternionMeasurement(quaternion, quaterDerivation, i, s[n]);
                ++n;
                ++nc;
            }
            for (int i = 0; i < 3; i++)
            {
                measurements[n] = new VelocityMeasurememt(aggregate, n, s[n]);
                ++n;
                ++nv;
            }
            string sq = "q(";
            string sv = "Vq(";
            int q = 1;
            nc = 13;
            for (; nc < aggregate.Dimension; nc++)
            {
                string sn = sq + q + ")";
                measurements[n] = new CoordinateMeasurement(aggregate, nc, nc + 1, sn);
                sn = sv + q + ")";
                ++n;
                ++nc;
                measurements[n] = new VelocityMeasurememt(aggregate, nc, sn);
                ++n;
                ++q;
            }
        }

        internal Motion6DAcceleratedFrame OwnFrame
        {
            get
            {
                return relative;
            }
        }

        /// <summary>
        /// Base frame
        /// </summary>
        protected ReferenceFrame BaseFrame
        {
            get
            {
                if (parentFrame != null)
                {
                    return parentFrame.Own;
                }
                return Motion6DFrame.Base;
            }
        }



        #endregion

        #region Coordinate Measure Class

        class CoordinateMeasurement : IMeasurement, IDerivation 
        {
            #region Fields

            private Func<object> par;

            private string name;

            private int i;

            private int j;

            private IAggregableMechanicalObject aggregate;

            private IMeasurement derivation;

            #endregion

            #region Ctor

            internal CoordinateMeasurement(IAggregableMechanicalObject aggregate, int i, int j, string name)
            {
                this.aggregate = aggregate;
                this.name = name;
                this.i = i;
                this.j = j;
                par = coord;
                derivation = new Measurement(deriv, "", this);
            }

            #endregion

            #region IMeasurement Members

            Func<object> IMeasurement.Parameter
            {
                get { return par; }
            }

            string IMeasurement.Name
            {
                get { return name; }
            }

            object IMeasurement.Type
            {
                get { return type; }
            }

            #endregion

            #region IDerivation Members

            IMeasurement IDerivation.Derivation
            {
                get { return derivation; }
            }

            #endregion

            #region Specific Members

            object coord()
            {
                return aggregate.State[i];
            }

            object deriv()
            {
                return aggregate.State[j];
            }


            #endregion

        }


        #endregion

        #region Velocity Measure Class

        class VelocityMeasurememt : IMeasurement
        {
            #region Fields

            private Func<object> par;

            private string name;

            private int i;

            private IAggregableMechanicalObject aggregate;


            #endregion

            #region Ctor

            internal VelocityMeasurememt(IAggregableMechanicalObject aggregate, int i, string name)
            {
                this.aggregate = aggregate;
                this.name = name;
                this.i = i;
                par = velocity;
            }

            #endregion

            #region IMeasurement Members

            Func<object> IMeasurement.Parameter
            {
                get { return par; }
            }

            string IMeasurement.Name
            {
                get { return name; }
            }

            object IMeasurement.Type
            {
                get { return type; }
            }

            #endregion

            #region Specific Members

            object velocity()
            {
                return aggregate.State[i];
            }

            #endregion
        }


        #endregion

        #region Quaternion Measure Class

        class QuaternionMeasurement : IMeasurement, IDerivation
        {
            #region Fields

            private Func<object> par;

            private string name;

            private int i;

            private double[] quater;

            private double[] der;

            private IMeasurement derivation;

            #endregion

            #region Ctor

            internal QuaternionMeasurement(double[] quater, double[] der, int i, string name)
            {
                this.quater = quater;
                this.der = der;
                this.name = name;
                this.i = i;
                par = coord;
                derivation = new Measurement(deri, "", this);
            }

            #endregion

            #region IMeasurement Members

            Func<object> IMeasurement.Parameter
            {
                get { return par; }
            }

            string IMeasurement.Name
            {
                get { return name; }
            }

            object IMeasurement.Type
            {
                get { return type; }
            }

            #endregion

            #region Specific Members

            object coord()
            {
                return quater[i];
            }

            private object deri()
            {
                return der[i];
            }

            #endregion

            #region IDerivation Members

            IMeasurement IDerivation.Derivation
            {
                get { return derivation; }
            }

            #endregion
        }


        #endregion

    }
}
