using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


using CategoryTheory;
using Diagram.UI;

using DataPerformer.Portable;
using DataPerformer.Portable.Measurements;
using DataPerformer.Interfaces;

using Motion6D.Interfaces;
using Motion6D.Portable;

namespace Motion6D
{
    /// <summary>
    /// Reference frame controlled by data
    /// </summary>
    [Serializable()]
    public class ReferenceFrameDataBase : RigidReferenceFrame,
        IDataConsumer, IPostSetArrow
    {

        #region Fields

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };

        /// <summary>
        /// Associates obhect
        /// </summary>
        protected object obj;

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

  

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ReferenceFrameDataBase()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected ReferenceFrameDataBase(SerializationInfo info, StreamingContext context)
        {
            parameters = info.GetValue("Parameters", typeof(List<string>)) as List<string>;
            isSerialized = true;
        }

        #endregion
 
        #region IDataConsumer Members

        void IDataConsumer.Add(IMeasurements measurements)
        {
            measurementsData.Add(measurements);
            onChangeInput();
        }

        void IDataConsumer.Remove(IMeasurements measurements)
        {
            measurementsData.Remove(measurements);
            onChangeInput();
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
                e.ShowError(10);
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

        void IPostSetArrow.PostSetArrow()
        {
             SetParameters();
        }

        #endregion

        #region Overriden Members

        /// <summary>
        /// Post load position
        /// </summary>
        public override void PostLoadPosition()
        {
            CreateFrame();
        }


        /// <summary>
        /// Implementation of serialization
        /// </summary>
        /// <param name="info">Serialization Info</param>
        /// <param name="context">Streaming Context</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Parameters", parameters, typeof(List<string>));
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
                if (isSerialized)
                {
                   // isSerialized = false;
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
                    x[i] = (double)measurements[i].Parameter();
                }
                if (relative is IVelocity)
                {
                    IVelocity vel = relative as IVelocity;
                    double[] v = vel.Velocity;
                    for (int i = 0; i < 3; i++)
                    {
                        IDerivation d = measurements[i] as IDerivation;
                        v[i] = Measurement.GetDouble(d.Derivation);
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
                        der[i] = Measurement.GetDouble(d.Derivation);
                    }
                    Vector3D.StaticExtensionVector3D.CalculateDynamics(or.Quaternion, der, om, qd);
                }
                if (relative is IAcceleration)
                {
                    IAcceleration acc = relative as IAcceleration;
                    IAngularAcceleration anc = relative as IAngularAcceleration;
                    double[] linacc = acc.RelativeAcceleration;
                    for (int i = 0; i < linacc.Length; i++)
                    {
                        linacc[i] = Measurement.GetDouble(secondDeriM[i]);
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        angsec[i] = Measurement.GetDouble(secondDeriM[i + 3]);
                    }
                    IAngularVelocity av = relative as IAngularVelocity;
                    double[] om = av.Omega;
                    IOrientation or = relative as IOrientation;
                    double[] angacc = anc.AngularAcceleration;
                    Vector3D.StaticExtensionVector3D.CalculateAcceleratedDynamics(or.Quaternion, der, om, qd, angsec, angacc);
                }
                base.Update();
            }
            catch (Exception exception)
            {
                exception.ShowError(10);
   //!!!  OLD           this.Throw(ex);
            }
        }

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


        #endregion

        #region Specific Members

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
        }

        #endregion
    }
}
