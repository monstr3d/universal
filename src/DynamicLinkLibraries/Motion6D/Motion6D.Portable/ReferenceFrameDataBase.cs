using System;
using System.Collections.Generic;

using CategoryTheory;
using Diagram.UI;

using DataPerformer.Portable;
using DataPerformer.Portable.Measurements;
using DataPerformer.Interfaces;

using Motion6D.Interfaces;
using ErrorHandler;

namespace Motion6D.Portable
{
    /// <summary>
    /// Reference frame controlled by data
    /// </summary>
    public class ReferenceFrameDataBase : RigidReferenceFrame,
        IDataConsumer, IMeasurements, IStarted
    {

        #region Fields

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput;

        /// <summary>
        /// Associated object
        /// </summary>
        protected object obj;

        /// <summary>
        /// Output measurements
        /// </summary>
        protected IMeasurement[] outmeasurements = new IMeasurement[0];

        /// <summary>
        /// Names of parametrers
        /// </summary>
        new protected List<string> parameters = new List<string>();

        /// <summary>
        /// Auxiliary variable
        /// </summary>
        protected double[,] qd = new double[4, 4];

        /// <summary>
        /// Auxiliary variable
        /// </summary>
        private double[] der = new double[4];

        /// <summary>
        /// External measurements
        /// </summary>
        protected List<IMeasurements> measurementsData = new List<IMeasurements>();

        /// <summary>
        /// Measurementrs
        /// </summary>
        protected IMeasurement[] measurements = new IMeasurement[7];

        /// <summary>
        /// Second derivations
        /// </summary>
        protected double[] secondDeri = new double[7];

        /// <summary>
        /// Second derivations' measurements
        /// </summary>
        protected IMeasurement[] secondDeriM;

        /// <summary>
        /// Auxiliary variable
        /// </summary>
        protected double[] angsec = new double[4];

 
        IAngularVelocity angularVelocity;

        new IVelocity velocity;

        private Func<object>[] coordDel;

        private Func<object>[] oriDel;

        private Func<object>[] velocityDel;

        private Func<object>[] angularDel;


        private static readonly string[] names = new string[] {"x", "y", "z",  
        "Vx", "Vy", "Vz",  "Q0", "Q1", "Q2", "Q3",
                    "OMx", "OMy", "OMz", "A11", "A12", "A13", "A21", "A22", "A23", "A31", "A32", "A33"};


        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ReferenceFrameDataBase()
        {
            ClearAliases();
            coordDel = new Func<object>[] { GetX, GetY, GetZ };
            oriDel = new Func<object>[] { GetQ0, GetQ1, GetQ2, GetQ3 };
            velocityDel = new Func<object>[] { GetVx, GetVy, GetVz };
            angularDel = new Func<object>[] { GetOmegaX, GetOmegaY, GetOmegaZ };
        }


        #endregion

        #region IDataConsumer Members

        void IDataConsumer.Add(IMeasurements measurements)
        {
            measurementsData.Add(measurements);
            onChangeInput?.Invoke();
        }

        void IDataConsumer.Remove(IMeasurements measurements)
        {
            measurementsData.Remove(measurements);
            onChangeInput?.Invoke();
        }

        void IDataConsumer.UpdateChildrenData()
        {
            try
            {
                foreach (IMeasurements m in measurementsData)
                {
                    m.UpdateMeasurements();
                }
            }
            catch (Exception e)
            {
                e.HandleException(10);
                this.Throw(e);
            }
        }

        int IDataConsumer.Count
        {
            get { return measurementsData.Count; }
        }

        IMeasurements IDataConsumer.this[int n]
        {
            get { return measurementsData[n]; }
        }

        void IDataConsumer.Reset()
        {
            this.FullReset();
        }

        event Action IDataConsumer.OnChangeInput
        {
            add { onChangeInput += value; }
            remove { onChangeInput -= value; }
        }

        #endregion

        #region IPostSetArrow Members

        public override void PostSetArrow()
        {
             SetParameters();
        }

        #endregion

        #region IMeasurements Members

        int IMeasurements.Count => outmeasurements.Length;

        bool IMeasurements.IsUpdated { get => true; set { } }

        IMeasurement IMeasurements.this[int number] => outmeasurements[number];


        void IMeasurements.UpdateMeasurements()
        {
            
        }

        #endregion

        #region IStart Members

        /// <summary>
        /// Starts this object
        /// </summary>
        /// <param name="time">Start time</param>
        void IStarted.Start(double time)
        {
            Start(time);
        }

        #endregion

        #region Overriden Members

        /// <summary>
        /// Post load position
        /// </summary>
        public override void PostLoadPosition()
        {
          //  CreateFrame();
        }

        /// <summary>
        /// Parent frame
        /// </summary>
        public override IReferenceFrame Parent
        {
            get
            {
                return parent;
            }
            set
            {
                if (value != null & parent != null)
                {
                    throw new Exception("Root");
                }
                parent = value;
                if (parent == null)
                {
                    owp = Motion6DFrame.Base;
                    return;
                }
                if (IsSerialized)
                {
                    IsSerialized = false;
                    return;
                }
                CreateFrame();
            }
        }

        /// <summary>
        /// Creates frame
        /// </summary>
        protected override void CreateFrame()
        {
            int order = 2;
            List<IMeasurement> lm = new List<IMeasurement>();
            for (int i = 0; i < measurements.Length; i++)
            {
                IMeasurement m = measurements[i];
                int n = m.GetDerivativeOrder();
                if (n < order)
                {
                    order = n;
                }
            }
            if (order == 2)
            {
                base.CreateFrame();
                secondDeriM = new IMeasurement[7];
                for (int i = 0; i < secondDeriM.Length; i++)
                {
                    secondDeriM[i] = measurements[i].GetHigherDerivative(2);
                }
                return;
            }
            secondDeriM = null;
            bool velocity = IsVelocity;                 // Velocity support
            bool angularVelocty = IsAngularVelocity;    // Angular velocity support
            if (velocity & angularVelocty)              // If both velocity and angular velocity are supported
            {
                // Motion6DFrame implements both IVelocity and IAngularVelocity
                Relative = new Motion6DFrame();   // Relative reference frame      
                owp = new Motion6DFrame();        // Own reference frame
            }
            else if (angularVelocty)              // If angular velocity is supported
            {
                // RotatedFrame implements IAngularVelocity
                Relative = new RotatedFrame();    // Relative reference frame  
                owp = new RotatedFrame();         // Own reference frame
            }
            else if (velocity)                      // If velocity is supported
            {
                // MovedFrame implements IVelocity
                Relative = new MovedFrame();
                owp = new MovedFrame();
            }
            else
            {
                Relative = new ReferenceFrame();  // Relative reference frame  
                owp = new ReferenceFrame();       // Own reference frame
            }
       }


        /// <summary>
        /// Updates itself
        /// </summary>
        public override void Update()
        {
            try
            {
                this.FullReset();
                IDataConsumer cons = this;
                cons.UpdateChildrenData();
                ReferenceFrame relative = Relative;
                IPosition p = relative;
                double[] x = p.Position;
                ReferenceFrame parent = this.GetParentFrame();
                for (int i = 0; i < 3; i++)
                {
                    var o = measurements[i].Parameter();
                    if (o == null)
                    {
                        return;
                    }
                    x[i] = (double)o;
                }
                if (relative is IVelocity)
                {
                    IVelocity vel = relative as IVelocity;
                    double[] v = vel.Velocity;
                    for (int i = 0; i < 3; i++)
                    {
                        var d = measurements[i] as IDerivation;
                        v[i] = d.Derivation.ToDouble();
                    }
                }
                double[] qua = relative.Quaternion;
                for (int i = 0; i < qua.Length; i++)
                {
                    IMeasurement m = measurements[i + 3];
                    qua[i] = (double)m.Parameter();
                }
                relative.SetMatrix();
                if (relative is IAngularVelocity)
                {
                    IAngularVelocity av = relative as IAngularVelocity;
                    double[] om = av.Omega;
                    IOrientation or = relative as IOrientation;
                    for (int i = 0; i < 4; i++)
                    {
                        IDerivation d = measurements[i + 3] as IDerivation;
                        der[i] = d.Derivation.ToDouble();
                    }
                    vp.CalculateDynamics(or.Quaternion, der, om, qd);
                }
                if (relative is IAcceleration)
                {
                    IAcceleration acc = relative as IAcceleration;
                    IAngularAcceleration anc = relative as IAngularAcceleration;
                    double[] linacc = acc.RelativeAcceleration;
                    for (int i = 0; i < linacc.Length; i++)
                    {
                       linacc[i] = secondDeriM[i].ToDouble();
                    }
                    for (int i = 0; i < 4; i++)
                    {
                       angsec[i] = secondDeriM[i + 3].ToDouble();
                    }
                    IAngularVelocity av = relative as IAngularVelocity;
                    double[] om = av.Omega;
                    IOrientation or = relative as IOrientation;
                    double[] angacc = anc.AngularAcceleration;
                    vp.CalculateAcceleratedDynamics(or.Quaternion, der, om, qd, angsec, angacc);
                }
                base.Update();
            }
            catch (Exception exception)
            {
                exception.HandleException(10);
           }
        }

   

        #endregion

        #region Specific Members

        #region Public Members

        /// <summary>
        /// All measurements
        /// </summary>
        public List<string> AllMeasurements
        {
            get
            {
                IDataConsumer c = this;
                List<string> list = new List<string>();
                for (int i = 0; i < c.Count; i++)
                {
                    IMeasurements m = c[i];
                    IAssociatedObject ao = m as IAssociatedObject;
                    string on = this.GetRelativeName(ao) + ".";
                    for (int j = 0; j < m.Count; j++)
                    {
                        string s = on + m[j].Name;
                        list.Add(s);
                    }
                }
                return list;
            }
        }

        /// <summary>
        /// Count of input parametese
        /// </summary>
        protected virtual int ParametersCount
        {
            get
            {
                return 7;
            }
        }


        /// <summary>
        /// Parameters
        /// </summary>
        new public List<string> Parameters
        {
            get
            {
                return parameters;
            }
            set
            {
                if (value.Count != ParametersCount)
                {
                    throw new Exception();
                }
                parameters = value;
                SetParameters();
            }

        }

        #endregion

        #region Protected Members

        /// <summary>
        /// Detects velocity support of ReferenceFrameData class
        /// </summary>
        protected override bool IsVelocity
        {
            get
            {
                if (!base.IsVelocity) // If parent frame does not support velocity calculation
                {
                    return false;
                }
                for (int i = 0; i < 3; i++)
                {
                    // If derivative order is less that 1
                    if (measurements[i].GetDerivativeOrder() < 1)
                    {
                        // Then velocity is not supported
                        return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// Detects angular velocity support
        /// </summary>
        protected override bool IsAngularVelocity
        {
            get
            {
                if (!base.IsAngularVelocity)
                {
                    return false;
                }
                for (int i = 3; i < 7; i++)
                {
                    // If derivative order is less that 1
                    if (measurements[i].GetDerivativeOrder() < 1)
                    {
                        return false;
                    }
                }
                return true;
            }
        }


        /// <summary>
        /// Starts itself
        /// </summary>
        /// <param name="time">Start time</param>
        virtual protected void Start(double time)
        {
            Update();
        }

        /// <summary>
        /// Sets parameters
        /// </summary>
        protected void SetParameters()
        {
            IDataConsumer c = this;
            for (int i = 0; i < parameters.Count; i++)
            {
                string p = parameters[i];
                for (int j = 0; j < c.Count; j++)
                {
                    IMeasurements m = c[j];
                    IAssociatedObject ao = m as IAssociatedObject;
                    string on = this.GetRelativeName(ao) + ".";
                    for (int k = 0; k < m.Count; k++)
                    {
                        IMeasurement mea = m[k];
                        string s = on + mea.Name;
                        if (s.Equals(p))
                        {
                            measurements[i] = mea;
                        }
                    }
                }
            }
            CreateFrame();
            CreateMeasurements();
        }

        #endregion

        #region Private Members

        void CreateMeasurements()
        {
            List<IMeasurement> lm = new List<IMeasurement>();
            lm.Add(new Measurement(typeof(ReferenceFrame), GetFrame, "Frame", this));
            for (int i = 0; i < 3; i++)
            {
                lm.Add(new Measurement(coordDel[i], names[i], this));
            }
            for (int i = 0; i < 4; i++)
            {
                lm.Add(new Measurement(oriDel[i], names[i + 6], this));
            }
            if (own is IVelocity)
            {
                velocity = own as IVelocity;
                for (int i = 0; i < 3; i++)
                {
                    lm.Add(new Measurement(velocityDel[i], names[i + 3], this));
                }
            }
            if (own is IAngularVelocity)
            {
                angularVelocity = own as IAngularVelocity;
                for (int i = 0; i < 3; i++)
                {
                    lm.Add(new Measurement(angularDel[i], names[i + 10], this));
                }
            }
            outmeasurements = lm.ToArray();
        }

        object GetFrame()
        {
            return own;
        }


        object GetX()
        {
            return own.Position[0];
        }

        object GetY()
        {
            return own.Position[1];
        }

        object GetZ()
        {
            return own.Position[2];
        }

        object GetVx()
        {
            return velocity.Velocity[0];
        }

        object GetVy()
        {
            return velocity.Velocity[1];
        }

        object GetVz()
        {
            return velocity.Velocity[2];
        }

        object GetQ0()
        {
            return own.Quaternion[0];
        }

        object GetQ1()
        {
            return own.Quaternion[1];
        }

        object GetQ2()
        {
            return own.Quaternion[2];
        }

        object GetQ3()
        {
            return own.Quaternion[3];
        }


        object GetOmegaX()
        {
            return angularVelocity.Omega[0];
        }


        object GetOmegaY()
        {
            return angularVelocity.Omega[1];
        }


        object GetOmegaZ()
        {
            return angularVelocity.Omega[2];
        }

        #endregion

        #endregion

    }
}
