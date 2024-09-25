using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using Diagram.UI;
using Diagram.UI.Aliases;


using DataPerformer.Portable;
using DataPerformer.Portable.Measurements;
using DataPerformer.Interfaces;

using RealMatrixProcessor;

using Vector3D;

using Motion6D.Interfaces;

namespace Motion6D
{
    /// <summary>
    /// Reference frame of inertial object
    /// The object have nonzero moment of inertia
    /// </summary>
    [Serializable()]
    public class InertialReferenceFrame : RigidReferenceFrame, IDifferentialEquationSolver, 
        IDataConsumer, IStarted, IVelocity, IOrientation, IAngularVelocity
    {
        #region Fields

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };
        
        /// <summary>
        /// Acceleration string
        /// </summary>
        string[] forcesString = new string[12];

 
        /// <summary>
        /// Moment of inertia string
        /// </summary>
        string[] momentOfInertia = new string[7];

        /// <summary>
        /// State string
        /// </summary>
        string[] state = new string[19];

 
        /// <summary>
        /// Initial conditions
        /// </summary>
        private double[] initialConditions = new double[] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 };

        /// <summary>
        /// Internal measurements
        /// </summary>
        private IMeasurement[] internalMeasurements = new IMeasurement[13]; 

        /// <summary>
        /// External measures
        /// </summary>
        private IMeasurement[] measures = new IMeasurement[12];

        /// <summary>
        /// Measure of inretia
        /// </summary>
        private IMeasurement[] inertia = new IMeasurement[7];

        /// <summary>
        /// Measurements
        /// </summary>
        private List<IMeasurements> measurements = new List<IMeasurements>();

        /// <summary>
        /// The "is updated" sign
        /// </summary>
        private bool isUpdated = false;

        /// <summary>
        /// External aliases
        /// </summary>
        private AliasName[] aln = new AliasName[19];

        /// <summary>
        /// Linear acceleration
        /// </summary>
        private double[] linAccAbsolute = new double[3];

        /// <summary>
        /// Linear accelration
        /// </summary>
        private double[] linAccRelative = new double[3];

        /// <summary>
        /// Angular acceleration
        /// </summary>
        private double[] epsRelative = new double[3];


        /// <summary>
        /// Angular acceleration
        /// </summary>
        private double[] epsAbsolute = new double[3];

        private double[] aux4d = new double[4];


        private double[] quaternionDervation = new double[4];

 
        /// <summary>
        /// Auxiliary massive for intermediate calculations
        /// </summary>
        private double[] aux = new double[3];

        private double[] aux1 = new double[3];
        
        private double[] aux2 = new double[3];


        /// <summary>
        /// Auxiliary massive for derivations of quaternions
        /// </summary>
        private double[] qdr = new double[4];

        /// <summary>
        /// Auxiliary massive for intermediate calculations
        /// </summary>
        private double[] qad = new double[4];

        /// <summary>
        /// The -1st power of mass of the object
        /// </summary>
        private double unMass = 1;

 
        /// <summary>
        /// The tensor of inertia
        /// </summary>
        private double[,] J = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };

        /// <summary>
        /// Inverted matrix of inertia tensor (it is useful, because less calculations are involved)
        /// </summary>
        private double[,] L = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };

        /// <summary>
        /// Auxiliary matrix (it seems that this matrix could be useful, too)
        /// </summary>
        private double[,] am = new double[4, 4];

        /// <summary>
        /// Forces and moments, acting on the body
        /// </summary>
        private double[] forces = new double[12];

        /// <summary>
        /// Velocity
        /// </summary>
        new private double[] velocity = new double[3];

        /// <summary>
        /// Relative velocity
        /// </summary>
        private double[] relativeVelocity = new double[3];

        /// <summary>
        /// Quaternion
        /// </summary>
        private double[] quater = new double[] { 1, 0, 0, 0 };

        /// <summary>
        /// Transition matrix
        /// </summary>
        private double[,] transitionMatrix = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };

        /// <summary>
        /// State
        /// </summary>
        private double[] vector = new double[13];

        /// <summary>
        /// Angular velocity
        /// </summary>
        new private double[] omega = new double[] { 0, 0, 0 };

        private static readonly List<string> vars = 
        new List<string>(){ "X", "Y", "Z", "Vx", "Vy", "Vz", "Q0", "Q1", "Q2", "Q3", "OMGx", "OMGy", "OMGz" };

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public InertialReferenceFrame()
        {
            ClearAliases();
             init();
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization Info</param>
        /// <param name="context">Streaming Context</param>
        protected InertialReferenceFrame(SerializationInfo info, StreamingContext context)
            : this()
        {
            forcesString = info.GetValue("Acceleration", typeof(string[])) as string[];
            momentOfInertia = info.GetValue("MomentOfInertia", typeof(string[])) as string[];
            state = info.GetValue("State", typeof(string[])) as string[];
            initialConditions = info.GetValue("InitialConditions", typeof(double[])) as double[];
        }

        #endregion

        #region Overriden Members

        /// <summary>
        /// Implementation of serialization
        /// </summary>
        /// <param name="info">Serialization Info</param>
        /// <param name="context">Streaming Context</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Acceleration", forcesString, typeof(string[]));
            info.AddValue("MomentOfInertia", momentOfInertia, typeof(string[]));
            info.AddValue("State", state, typeof(string[]));
            info.AddValue("InitialConditions", initialConditions, typeof(double[]));
        }

        /*public override double[,] RelativeMatrix
        {
            get
            {
                return base.RelativeMatrix;
            }
            set
            {
                base.RelativeMatrix = value;
              /  for (int i = 0; i < 4; i++)
                {
                    initialConditions[i + 6] = relativeQuaternion[i];
                }
            }
        }*/

        #endregion

        #region IDifferentialEquationSolver Members

        void IDifferentialEquationSolver.CalculateDerivations()
        {
            //IReferenceFrame f = this;
            //ReferenceFrame frame = f.Own;
            SetAliases();
            IDataConsumer cons = this;
            int i = 0;

            cons.Reset();

            cons.UpdateChildrenData();

            //Filling of massive of forces and moments using results of calculations of formula trees 
            for (i = 0; i < 12; i++)
            {
                forces[i] = (double)measures[i].Parameter();
            }

            //Filling the part, responding to derivation of radius-vector
            /*for (i = 0; i < 3; i++)
            {
                result[i, 1] = result[3 + i, 0];
            }*/

            int k = 0;
            for (i = 0; i < 3; i++)
            {
                for (int j = i; j < 3; j++)
                {
                    IMeasurement min = inertia[k];
                    ++k;
                    if (min != null)
                    {
                        double jin = (double)min.Parameter();
                        J[i, j] = jin;
                        J[j, i] = jin;
                    }
                }
            }
            IMeasurement mm = inertia[6];
            if (mm != null)
            {
                unMass = (double)mm.Parameter();
                unMass = 1 / unMass;
            }

            //Filling the part, responding to derivation of linear velocity 
            for (i = 0; i < 3; i++)
            {
                linAccAbsolute[i] = forces[6 + i] * unMass;
            }
            double[,] T = Relative.Matrix;
            StaticExtensionRealMatrix.Multiply(linAccAbsolute, T, aux);
            for (i = 0; i < 3; i++)
            {
                linAccAbsolute[i] = forces[i] * unMass + aux[i];
            }
            StaticExtensionRealMatrix.Multiply(J, omega, aux);
            StaticExtensionVector3D.VectorPoduct(omega, aux, aux1);
            StaticExtensionRealMatrix.Add(aux1, 0, forces, 9, aux, 0, 3);
            Array.Copy(forces, 3, aux1, 0, 3);
            StaticExtensionRealMatrix.Multiply(aux1, T, aux2);
            StaticExtensionRealMatrix.Add(aux2, 0, forces, 9, aux1, 0, 3);
            StaticExtensionRealMatrix.Add(aux1, 0, aux, 0, aux2, 0, 3);
            StaticExtensionRealMatrix.Multiply(L, aux2, epsRelative);
            aux4d[0] = 0;
            Array.Copy(omega, 0, aux4d, 1, 3);
            StaticExtensionVector3D.QuaternionInvertMultiply(relativeQuaternion, aux4d, quaternionDervation);
            for (i = 0; i < 3; i++)
            {
                quaternionDervation[i] *= 0.5;
            }
            SetRelative();
            Update();
        }

        void IDifferentialEquationSolver.CopyVariablesToSolver(int offset, double[] variables)
        {
            
            Array.Copy(variables, offset, relativePosition, 0, 3);
            Array.Copy(variables, offset + 3, relativeVelocity, 0, 3);
            StaticExtensionRealMatrix.Normalize(variables, offset + 6, 4);
            Array.Copy(variables, offset + 6, relativeQuaternion, 0, 4);
            Array.Copy(variables, offset + 10, omega, 0, 3);
            SetRelative();
        }


        int VariablesCount
        {
            get
            {
                IMeasurements m = this;
                return m.Count;
            }
        }


        #endregion

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get { return internalMeasurements.Length; }
        }

        IMeasurement IMeasurements.this[int n]
        {
            get { return internalMeasurements[n]; }
        }

        void IMeasurements.UpdateMeasurements()
        {
            
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

        #region IDataConsumer Members

        void IDataConsumer.Add(IMeasurements measurements)
        {
            this.measurements.Add(measurements);
        }

        void IDataConsumer.Remove(IMeasurements measurements)
        {
            this.measurements.Remove(measurements);
        }

        void IDataConsumer.UpdateChildrenData()
        {
            measurements.UpdateChildrenData();
        }

        int IDataConsumer.Count
        {
            get { return measurements.Count; }
        }

        IMeasurements IDataConsumer.this[int n]
        {
            get { return measurements[n]; }
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

        #region IStarted Members

        void IStarted.Start(double time)
        {
            Array.Copy(initialConditions, relativePosition, 3);
            Array.Copy(initialConditions, 3, relativeVelocity, 0, 3);
            Array.Copy(initialConditions, 6, relativeQuaternion, 0, 4);
            Array.Copy(initialConditions, 10, omega, 0, 3);
            Copy6DPosition();
            Own.SetMatrix();
            Update();
            SetAliases();
        }

        #endregion

        #region IVelocity Members

        double[] IVelocity.Velocity
        {
            get { return velocity; }
        }
/*
        double[] IVelocity.RevativeVelocity
        {
            get { return relativeVelocity; }
        }
*/
        #endregion

        #region IOrientation Members

        double[] IOrientation.Quaternion
        {
            get { return quater; }
        }

        double[,] IOrientation.Matrix
        {
            get { return transitionMatrix; }
        }

        #endregion

        #region IAngularVelocity Members

        double[] IAngularVelocity.Omega
        {
            get { return omega; }
        }

        #endregion

        #region IPostSetArrow Members

        /// <summary>
        /// The operation that performs after arrows setting
        /// </summary>
       /* public override void PostSetArrow()
        {
            base.PostSetArrow();
            post();
        }*/

        #endregion

        #region Specific Members

        /// <summary>
        /// Sets parameters and aliases
        /// </summary>
        /// <param name="forcesString">Forces</param>
        /// <param name="momentOfInertia">Moment of inertia</param>
        /// <param name="state">State</param>
        public void Set(string[] forcesString, string[] momentOfInertia, string[] state)
        {
            this.forcesString = forcesString;
            this.momentOfInertia = momentOfInertia;
            this.state = state;
            post();
        }

        /// <summary>
        /// String of forces
        /// </summary>
        public string[] Forces
        {
            get
            {
                return forcesString;
            }
        }

        /// <summary>
        /// String of moments
        /// </summary>
        public string[] Inretia
        {
            get
            {
                return momentOfInertia;
            }
        }

        /// <summary>
        /// String of state parameters
        /// </summary>
        public string[] State
        {
            get
            {
                return state;
            }
        }

        /// <summary>
        /// Initial conditions
        /// </summary>
        public double[] Initial
        {
            get
            {
                return initialConditions;
            }
        }



        private void post()
        {
            measures = this.FindMeasurements(forcesString, true);
            inertia = this.FindMeasurements(momentOfInertia, true);
            aln = this.FindAliases(state, false);
        }

        /// <summary>
        /// Sets aliases
        /// </summary>
        private void SetAliases()
        {
            ReferenceFrame own = Own;
            IVelocity v = own as IVelocity;
            IOrientation o = own as IOrientation;
            IAngularVelocity av = own as IAngularVelocity;
            aln.SetAliases(0, own.Position, 0, 3);
            aln.SetAliases(3, v.Velocity, 0, 3);
            aln.SetAliases(6, o.Quaternion, 0, 4);
            aln.SetAliases(10, av.Omega, 0, 3);
            aln.SetAliases(13, relativeVelocity, 0, 3);
            aln.SetAliases(16, omega, 0, 3);
        }

        #region Measure Parametres

        private object x()
        {
            return relativePosition[0];
        }

        private object y()
        {
            return relativePosition[1];
        }

        private object z()
        {
            return relativePosition[2];
        }

        private object Vx()
        {
            return relativeVelocity[0];
        }

        private object Vy()
        {
            return relativeVelocity[1];
        }

        private object Vz()
        {
            return relativeVelocity[2];
        }

        private object Q0()
        {
            return relativeQuaternion[0];
        }

        private object Q1()
        {
            return relativeQuaternion[1];
        }

        private object Q2()
        {
            return relativeQuaternion[2];
        }

        private object Q3()
        {
            return relativeQuaternion[3];
        }

        private object DQ0()
        {
            return quaternionDervation[0];
        }

        private object DQ1()
        {
            return quaternionDervation[1];
        }

        private object DQ2()
        {
            return quaternionDervation[2];
        }

        private object DQ3()
        {
            return quaternionDervation[3];
        }

 
        private object OMx()
        {
            return omega[0];
        }

        private object OMy()
        {
            return omega[1];
        }

        private object OMz()
        {
            return omega[2];
        }

       /* private object xd()
        {
            return result[0, 1];
        }

        private object yd()
        {
            return result[1, 1];
        }

        private object zd()
        {
            return result[2, 1];
        }*/

        private object Ax()
        {
            return linAccAbsolute[0];
        }
        

        private object Ay()
        {
            return linAccAbsolute[1];
        }

        private object Az()
        {
            return linAccAbsolute[2];
        }

        private object DOMx()
        {
            return epsRelative[0];
        }

        private object DOMy()
        {
            return epsRelative[1];
        }

        private object DOMz()
        {
            return epsRelative[2];
        }

     /*   private object sd()
        {
            return result[9, 1];
        }

        private object md()
        {
            return result[10, 1];
        }

        private object nd()
        {
            return result[11, 1];
        }

        private object od()
        {
            return result[12, 1];
        }
        
        private object ld()
        {
            return result[13, 1];
        }*/

        #endregion


        private void SetRelative()
        {
            ReferenceFrame relative = Relative;
            Array.Copy(relativePosition, relative.Position, 3);
            IVelocity v = relative as IVelocity;
           // Array.Copy(relativeVelocity, v.RevativeVelocity, 3);
            Array.Copy(relativeQuaternion, relative.Quaternion, 3);
            IOrientation or = relative as IOrientation;
            Array.Copy(relativeQuaternion, or.Quaternion, 4);
            relative.SetMatrix();
        }

        private void init()
        {
            Double a = 0;
            internalMeasurements[0] = new MeasurementDerivation(a, x, new Measurement(Vx, "", this), "x", this);
            internalMeasurements[1] = new MeasurementDerivation(a, y, new Measurement(Vy, "", this), "y", this);
            internalMeasurements[2] = new MeasurementDerivation(a, z, new Measurement(Vz, "", this), "x", this);
            internalMeasurements[3] = new MeasurementDerivation(a, Vx, new Measurement(Ax, "", this), "vx", this);
            internalMeasurements[4] = new MeasurementDerivation(a, Vy, new Measurement(Ay, "", this), "vy", this);
            internalMeasurements[5] = new MeasurementDerivation(a, Vz, new Measurement(Az, "", this), "vz", this);
            internalMeasurements[6] = new MeasurementDerivation(a, Q0, new Measurement(DQ0, "", this), "q0", this);
            internalMeasurements[7] = new MeasurementDerivation(a, Q1, new Measurement(DQ1, "", this), "q1", this);
            internalMeasurements[8] = new MeasurementDerivation(a, Q2, new Measurement(DQ2, "", this), "q2", this);
            internalMeasurements[9] = new MeasurementDerivation(a, Q3, new Measurement(DQ3, "", this), "q3", this);
            internalMeasurements[10] = new MeasurementDerivation(a, OMx, new Measurement(DOMx, "", this), "omx", this);
            internalMeasurements[11] = new MeasurementDerivation(a, OMy, new Measurement(DOMy, "", this), "omy", this);
            internalMeasurements[12] = new MeasurementDerivation(a, OMz, new Measurement(DOMz, "", this), "omz", this);
        }


        #endregion

        #region IStateDoubleVariables Members

        List<string> IStateDoubleVariables.Variables
        {
            get { return vars; }
        }

        double[] IStateDoubleVariables.Vector
        {
            get
            {
                Array.Copy(relativePosition, 0, vector, 0, 3);
                Array.Copy(relativeVelocity, 0, vector, 3, 3);
                Array.Copy(relativeQuaternion, 0, vector, 7, 3);
                Array.Copy(omega, 0, vector, 10, 3);
                return vector;
            }
            set
            {
                Array.Copy(value, relativePosition, 3);
                Array.Copy(value, 3, relativeVelocity, 0, 3);
                Array.Copy(value, 6, relativeQuaternion, 0, 4);
                Array.Copy(value, 10, omega, 0, 3);
                Copy6DPosition();
                Own.SetMatrix();
            }
        }

        void IStateDoubleVariables.Set(double[] input, int offset, int length)
        {
            Array.Copy(input, offset,  relativePosition, 0, 3);
            Array.Copy(input, 3 + offset, relativeVelocity, 0, 3);
            Array.Copy(input, 6 + offset, relativeQuaternion, 0, 4);
            Array.Copy(input, 10 + offset, omega, 0, 3);
            Copy6DPosition();
            Own.SetMatrix();
        }


        #endregion
    }
}
