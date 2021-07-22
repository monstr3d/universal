using System;
using System.Collections.Generic;

using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;
using DataPerformer.Portable;

using Motion6D.Interfaces;

using Vector3D;
using RealMatrixProcessor;

namespace Motion6D.Portable.Aggregates
{
    /// <summary>
    /// Rigid body aggregate
    /// </summary>
    public class RigidBody : AggregableMechanicalObjectDataConsumer, IStarted, 
        INormalizable, IOrientation, IAlias
    {
        #region Fields

        /// <summary>
        /// Connections ccordinates
        /// </summary>
        protected double[][] connections;

        /// <summary>
        /// Inverted mass
        /// </summary>
        protected double invertedMass = 1;

        /// <summary>
        /// Mass
        /// </summary>
        protected double mass = 1;

        protected string[] names = { "X", "Y", "Z", "Vx", "Vy", "Vz", "Roll", "Pitch", "Yaw", "OMGx", "OMGx", "OMGz" };

        protected Dictionary<string, int> alinames = new Dictionary<string, int>();

        /// <summary>
        /// Moment of inertia
        /// </summary>
        protected double[,] momentOfInertia = new double[,]
            {{1, 0, 0},
            {0, 1, 0},
            {0, 0, 1}};

        /// <summary>
        /// Inverted moment of inertia
        /// </summary>
        protected double[,] invertedMomentOfInertia = new double[,]
            {{1, 0, 0},
            {0, 1, 0},
            {0, 0, 1}};

        /// <summary>
        /// Measurements of external accelations
        /// </summary>
        private IMeasurement[] inertialAccelationMea = new IMeasurement[3];

        /// <summary>
        /// String representation of measures
        /// </summary>
        protected string[] inerialAccelerationStr = new string[3];

        /// <summary>
        /// Measures of forces
        /// </summary>
        private IMeasurement[] forces = new IMeasurement[6];

        /// <summary>
        /// String of forces
        /// </summary>
        protected string[] forcesStr = new string[6];

        /// <summary>
        /// States of connections
        /// </summary>
        private double[][] connectionStates;

        /// <summary>
        /// Matrixes of acceleration
        /// </summary>
        protected double[][,] accelreationMatrixes;

        /// <summary>
        /// Matrixes of forces
        /// </summary>
        protected double[][,] forcesMatrixes;

        /// <summary>
        /// Internal acceleration
        /// </summary>
        protected double[] internalAcceleration = new double[6];


        /// <summary>
        /// Array of transformation matrixes
        /// </summary>
        private double[][,] transformationMatrixes;

        /// <summary>
        /// Internal accelerations
        /// </summary>
        protected double[][] internalAccelerations;

        /// <summary>
        /// auxiliary vector
        /// </summary>
        protected double[] v3d = new double[3];

        /// <summary>
        /// auxiliary vector
        /// </summary>
        protected double[] v3d1 = new double[3];

        /// <summary>
        /// auxiliary vector
        /// </summary>
        protected double[] v3d2 = new double[3];

        /// <summary>
        /// omega
        /// </summary>
        private double[] omega = new double[3];

        /// <summary>
        /// Additional omega
        /// </summary>
        private double[] omegaAdd = new double[3];

        /// <summary>
        /// Additional omega
        /// </summary>
        private double[] omegaAddP = new double[3];

        /// <summary>
        /// Auxiliary matrix
        /// </summary>
        private double[,] auxiliaryMatrix = new double[3, 3];

        /// <summary>
        /// Auxiliary matrix add
        /// </summary>
        private double[,] auxiliaryMatrixAdd = new double[3, 3];

        /// <summary>
        /// Auxiliary quaternion
        /// </summary>
        private double[] quater = new double[4];

        /// <summary>
        /// Auxiliary quaternion
        /// </summary>
        private double[] quaterAdd = new double[4];

        /// <summary>
        /// Auxiliary quaternion
        /// </summary>
        private double[] quaterAddP = new double[4];

        event Action<IAlias, string> change;





        /// <summary>
        /// Matrix for quaternion transformation
        /// </summary>
        private double[,] qq = new double[4, 4];

        /// <summary>
        /// Square of angular velocity
        /// </summary>
        private double omega2;

        /// <summary>
        /// Orientation matrix
        /// </summary>
        protected double[,] orientation = new double[3, 3];

        /// <summary>
        /// Transposed ori
        /// </summary>
        protected double[,] transposedOrientation = new double[3, 3];

        /// <summary>
        /// Auxiliary matrix
        /// </summary>
        protected double[,] auxMatrix = new double[3, 3];

 
        protected Action AddForce =  () =>
        {

        };

        protected Action AddMomentum =  () =>
        {

        };

        #endregion

        #region Ctor

 
        protected RigidBody()
            : this(true)
        {

        }

        /// <summary>
        /// Default constructor
        /// </summary>
        protected RigidBody(bool setForce)
            : this(13, setForce)
        {
            Post();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="n">Number of variables</param>
        protected RigidBody(int n, bool setForce)
        {
            for (int i = 0; i < names.Length; i++)
            {
                alinames[names[i]] = i;
            }
            initialState = new double[n];
            for (int i = 0; i < n; i++)
            {
                initialState[i] = 0;
            }
            initialState[6] = 1;
            state = new double[n];
            Array.Copy(initialState, state, n);
            if (setForce)
            {
                AddForce += AddForceFunc;
                AddMomentum += AddMomentumFunc;
            }
        }


        #endregion

        #region IStarted Members

        void IStarted.Start(double time)
        {
            Array.Copy(InitialState, state, state.Length);
            PostStart(time);
        }

        #endregion

        #region INormalizable Members



        public virtual void Normalize()
        {
            RealMatrixProcessor.RealMatrix.Normalize(state, 6, 4);
            SetConnectionStates();
        }

        #endregion

        #region IOrientation Members

        double[] IOrientation.Quaternion
        {
            get { return quater; }
        }

        double[,] IOrientation.Matrix
        {
            get { return orientation; }
        }

        #endregion

        #region IAlias Members

        IList<string> IAlias.AliasNames => names;

        object IAlias.this[string name] { get => GetAliasValue(name); set => SetAliasValue(name, value); }

        event Action<IAlias, string> IAlias.OnChange
        {
            add
            {
                change += value;
            }

            remove
            {
                change -= value;
            }
        }

        object IAlias.GetType(string name)
        {
            return GetAliasType(name);
        }

        #endregion

        #region Overriden Members

        public override int Dimension
        {
            get { return 13; }
        }

        public override double[] InternalAcceleration
        {
            get { return internalAcceleration; }
        }

        public override int NumberOfConnections
        {
            get
            {
                if (connections == null)
                {
                    return 0;
                }
                return connections.GetLength(0);
            }
        }

        public override double[] this[int numOfConnection]
        {
            get
            {
                if (connections == null)
                {
                    return null;
                }
                return connectionStates[numOfConnection];
            }
            set
            {
                if ((connections == null) | (value == null))
                {
                    return;
                }
                SetStateByConnection(value, numOfConnection);
            }
        }

        public override double[,] GetAccelerationMatrix(int numOfConnection)
        {
            return accelreationMatrixes[numOfConnection];
        }

        public override double[,] GetForcesMatrix(int numOfConnection)
        {
            return forcesMatrixes[numOfConnection];
        }

        public override double[] GetInternalAcceleration(int numOfConnection)
        {
            return internalAccelerations[numOfConnection];
        }

        public override bool IsConstant
        {
            get { return true; }
        }


        protected override void Post()
        {
            base.Post();
            CreateConnections();
            CreateMesurements();
            InvertMoment();
            CreateArrays();
        }

 
        public override Action Update => update;
  
        protected virtual void SetProperties(object[] o)
        {
            momentOfInertia = o[0] as double[,];
            momentOfInertia.Invert(invertedMomentOfInertia);
            if (o[1] != null)
            {
                connections = o[1] as double[][];
                if (connections != null)
                {
                    connectionStates = CreateArray(connections.Length, 13);
                }
            }
            aliasNames = o[2] as Dictionary<int, string>;
            inerialAccelerationStr = o[3] as string[];
            forcesStr = o[4] as string[];
            mass = (double)o[5];
            invertedMass = 1 / mass;
            InitialState = o[6] as double[];
            CreateArrays();
        }


        #endregion

        #region Specific Members

 
        EulerAngles angles = new EulerAngles();

        protected virtual object GetAliasValue(string name)
        {
            int i = alinames[name];
            if (i < 6)
            {
                return initialState[i];
            }
            if (i < 9)
            {
                angles.Set(6, initialState);
                switch (i - 6)
                {
                    case 0: return angles.roll;
                    case 1: return angles.pitch;
                    case 2: return angles.yaw;
                }
            }
            return initialState[i - 1];
        }


        protected virtual void SetAliasValue(string name, object value)
        {
            double v = (double)value;
            int i = alinames[name];
            if (i < 6)
            {
                initialState[i] = v;
            }
            if (i < 9)
            {
                angles.Set(6, initialState);
                switch (i - 6)
                {
                    case 0:
                        angles.roll = v;
                        break;
                    case 1:
                        angles.pitch = v;
                        break;
                    case 2:
                        angles.yaw = v;
                        break;
                }
                angles.ToQuaternion(6, initialState);
            }
            else
            {
                initialState[i + 1] = v;
            }
            Array.Copy(initialState, state, state.Length);
        }


        protected virtual object GetAliasType(string name)
        {
            return (double)0;
        }

        protected virtual void PostStart(double time)
        {

        }


        public void Set(Dictionary<int, string> aliasNames, string[] forcesStr, string[] inerialAccelerationStr,
            double[][] connections, double[,] momemtOfInertia, double mass, double[] initialState)
        {
            this.aliasNames = aliasNames;
            this.forcesStr = forcesStr;
            this.inerialAccelerationStr = inerialAccelerationStr;
            this.connections = connections;
            this.momentOfInertia = momemtOfInertia;
            RealMatrixProcessor.RealMatrix.Invert(momemtOfInertia, invertedMomentOfInertia);
            this.mass = mass;
            invertedMass = 1 / mass;
            this.initialState = initialState;
            if (GetType().Name.Equals("RigidBody"))
            {
                Post();
            }
        }

        /// <summary>
        /// Inertial acceleration string
        /// </summary>
        public IEnumerable<string> InertialAcceleration
        {
            get
            {
                return inerialAccelerationStr;
            }
        }

        /// <summary>
        /// Forces
        /// </summary>
        public IEnumerable<string> ForcesStr
        {
            get
            {
                return forcesStr;
            }
        }


        /// <summary>
        /// Connections
        /// </summary>
        public double[][] Connections
        {
            get
            {
                if (connections == null)
                {
                    return null;
                }
                double[][] c = new double[connections.Length][];
                for (int i = 0; i < connections.Length; i++)
                {
                    double[] x = connections[i];
                    double[] y = new double[x.Length];
                    Array.Copy(x, y, x.Length);
                    c[i] = y;
                }

                return c;
            }
        }

        /// <summary>
        /// Gets connection coordinates
        /// </summary>
        /// <param name="num">Number of connection</param>
        /// <returns>Connection coordinates</returns>
        public double[] GenConnection(int num)
        {
            double[] x = new double[7];
            double[] c = connections[num];
            Array.Copy(c, x, 7);
            return x;
        }

        /// <summary>
        /// Mass
        /// </summary>
        public double Mass
        {
            get
            {
                return mass;
            }
        }

        /// <summary>
        /// Moment of inertia
        /// </summary>
        public double[,] MomentOfInertia
        {
            get
            {
                return momentOfInertia;
            }
        }

        public string[] Forces
        {
            get
            {
                return forcesStr;
            }
        }

        public string[] Inretial
        {
            get
            {
                return inerialAccelerationStr;
            }
        }
       private void SetOrientation()
        {
            Array.Copy(state, 6, quater, 0, 4);
            StaticExtensionVector3D.QuaternionToMatrix(quater, orientation, qq);
            RealMatrixProcessor.RealMatrix.Transpose(orientation, transposedOrientation);
        }


        /// <summary>
        /// Creates connections
        /// </summary>
        private void CreateConnections()
        {
            if (connections == null)
            {
                return;
            }
            CreateArrays();
        }

        private void CreateMesurements()
        {
            if (forcesStr != null)
            {
                forces = this.FindMeasurements(forcesStr, true);
            }
            if (inerialAccelerationStr != null)
            {
                inertialAccelationMea = this.FindMeasurements(inerialAccelerationStr, true);
            }
        }

        private void InvertMoment()
        {
            RealMatrixProcessor.RealMatrix.Invert(momentOfInertia, invertedMomentOfInertia);
        }

        private static double[][] CreateArray(int n, int m)
        {
            double[][] arr = new double[n][];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new double[m];
            }
            return arr;
        }


        private static double[][,] CreateArray(int n, int m, int k)
        {
            double[][,] arr = new double[n][,];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new double[m, k];
            }
            return arr;
        }

        private void CreateArrays()
        {
            if (connections == null)
            {
                return;
            }
            IAggregableMechanicalObject agg = this;
            int dim = agg.Dimension;
            int n = connections.GetLength(0);
            internalAccelerations = CreateArray(n, 6);
            forcesMatrixes = CreateArray(n, (dim - 1) / 2, 6);
            accelreationMatrixes = CreateArray(n, 6, (dim - 1) / 2);
            connectionStates = CreateArray(n, 13);
            transformationMatrixes = new double[n][,];
            SetForcesMatrix();
        }

        protected virtual void SetForcesMatrix()
        {
            int n = connections.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                SetForcesMatrix(i);
            }
        }

        protected void NormalizeInitialQuaternion()
        {
            double a = 0;
            for (int i = 3; i < 7; i++)
            {
                double x = InitialState[i];
                a += x * x;
            }
            a = 1 / Math.Sqrt(a);
            for (int i = 3; i < 7; i++)
            {
                InitialState[i] *= a;
            }
        }

        protected virtual void SetConnectionStates()
        {
            Array.Copy(state, 6, quater, 0, 4);
            Array.Copy(state, 10, omega, 0, 3);
            SetOrientation();
            if (connections == null)
            {
                return;
            }
            for (int i = 0; i < connections.Length; i++)
            {
                SetConnectionState(connectionStates[i], i);
            }
        }

        /// <summary>
        /// Sets connection state
        /// </summary>
        /// <param name="connectionState">Connection state</param>
        /// <param name="numberOfConnection">Number of connection</param>
        protected void SetConnectionState(double[] connectionState, int numberOfConnection)
        {
            double[] connection = connections[numberOfConnection];
            Array.Copy(state, connectionState, 13);

            // Position
            Array.Copy(connection, v3d, 3);
            RealMatrixProcessor.RealMatrix.Multiply(orientation, v3d, v3d1);
            for (int i = 0; i < 3; i++)
            {
                connectionState[i] += v3d1[i];
            }

            // Orientation
            Array.Copy(connection, 3, quaterAdd, 0, 4);
            StaticExtensionVector3D.QuaternionMultiply(quater, quaterAdd, quaterAddP);
            Array.Copy(quaterAddP, 0, connectionState, 6, 4);

            // Velocity
            Array.Copy(state, v3d, 3);
            Array.Copy(state, 10, v3d1, 0, 3);
            StaticExtensionVector3D.VectorPoduct(v3d, v3d1, v3d2);
            RealMatrixProcessor.RealMatrix.Multiply(orientation, v3d2, v3d);
            for (int i = 0; i < 3; i++)
            {
                connectionState[i + 3] += v3d[i];
            }

            // Angular velocity
            Array.Copy(state, 10, v3d, 0, 3);
            RealMatrixProcessor.RealMatrix.Multiply(orientation, v3d, v3d1);
            Array.Copy(v3d1, 0, connectionState, 10, 3);

        }


        private void Transform(double[,] trans, double[] vector, double[] result, int offset)
        {
            Array.Copy(vector, offset, v3d, 0, 3);
            RealMatrixProcessor.RealMatrix.Multiply(trans, v3d, result);
        }


        private void Transform(double[,] trans, double[] vector, double[] result, int source, int target)
        {
            Array.Copy(vector, source, v3d, 0, 3);
            RealMatrixProcessor.RealMatrix.Multiply(trans, v3d, v3d1);
            Array.Copy(v3d, 0, result, target, 3);
        }

        /// <summary>
        /// Sets state by connection state
        /// </summary>
        /// <param name="conn">Connetion state</param>
        /// <param name="number">Connection number</param>
        protected void SetStateByConnection(double[] connectionExternal, int number)
        {
            double[] connectionInrernal = connections[number];

            //  Orientation
            Array.Copy(connectionExternal, 6, quaterAdd, 0, 4);
            Array.Copy(connectionInrernal, 3, quaterAddP, 0, 4);
            StaticExtensionVector3D.QuaternionInvertMultiply(quaterAddP, quaterAdd, quater);
            Array.Copy(quater, 0, state, 6, 4);
            SetOrientation();

            // Position
            Array.Copy(connectionInrernal, v3d, 3);
            RealMatrixProcessor.RealMatrix.Multiply(orientation, v3d, v3d1);
            for (int i = 0; i < 3; i++)
            {
                state[i] = connectionExternal[i] - v3d1[i];
            }

            // Angular velocity
            Array.Copy(connectionExternal, 10, v3d1, 0, 3);
            RealMatrixProcessor.RealMatrix.Multiply(v3d1, orientation, omega);
            Array.Copy(omega, 0, state, 10, 3);

            // Velocity
            Array.Copy(connectionExternal, 3, state, 3, 3);
            Array.Copy(connectionInrernal, v3d, 3);
            StaticExtensionVector3D.VectorPoduct(omega, v3d, v3d1);
            RealMatrixProcessor.RealMatrix.Multiply(orientation, v3d, v3d2);
            for (int i = 0; i < 3; i++)
            {
                state[i + 3] -= v3d2[i];
            }
        }



        protected void SetForcesMatrix(int n)
        {
            double[] internalConnection = connections[n];
            Array.Copy(internalConnection, 3, quater, 0, 4);
            double[,] tm = new double[3, 3];
            StaticExtensionVector3D.QuaternionToMatrix(quater, tm, qq);
            transformationMatrixes[n] = tm;

            double[,] fm = forcesMatrixes[n];

            // Zero
            for (int i = 0; i < fm.GetLength(0); i++)
            {
                for (int j = 0; j < fm.GetLength(1); j++)
                {
                    fm[i, j] = 0;
                }
            }

            // Force to linear acceleration
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    fm[i, j] = tm[i, j] * invertedMass;
                }
            }

            // Momentum to angular acceleration
            RealMatrixProcessor.RealMatrix.Multiply(invertedMomentOfInertia, tm, auxiliaryMatrix);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    fm[i + 3, j + 3] = auxiliaryMatrix[i, j];
                }
            }

            // Force to angular acceleration
            Array.Copy(internalConnection, v3d, 3);
            StaticExtensionVector3D.SO3VectorToSO3Matrix(v3d, auxiliaryMatrix);
            RealMatrixProcessor.RealMatrix.Multiply(auxiliaryMatrix, tm, auxiliaryMatrixAdd);
            RealMatrixProcessor.RealMatrix.Multiply(invertedMomentOfInertia, auxiliaryMatrixAdd, auxiliaryMatrix);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    fm[i + 3, j] = auxiliaryMatrix[i, j];
                }
            }

            SetAccelerationMatrix(n);
        }

        protected virtual void SetAccelerationMatrix(int n)
        {
            double[,] am = accelreationMatrixes[n];
            double[,] t = transformationMatrixes[n];

            // Angular
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    double a = t[j, i];
                    am[i + 3, j + 3] = a;
                    am[i, j] = a;
                }
            }

            double[] conn = connections[n];
            Array.Copy(conn, v3d, 3);
            StaticExtensionVector3D.SO3VectorToSO3Matrix(v3d, auxiliaryMatrix);
            RealMatrixProcessor.RealMatrix.Multiply(auxiliaryMatrix, t, auxiliaryMatrixAdd);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    am[i, j + 3] = auxiliaryMatrixAdd[i, j];
                }
            }
        }

        private void AddForceFunc()
        {
            for (int i = 0; i < 3; i++)
            {
                double a = 0;
                v3d[i] = 0;
                IMeasurement m = inertialAccelationMea[i];
                if (m != null)
                {
                    a += (double)m.Parameter();
                }
                m = forces[i];
                if (m != null)
                {
                    a += invertedMass * (double)m.Parameter();
                }
                v3d[i] = a;
            }
            orientation.Multiply(v3d, v3d1);
            for (int i = 0; i < 3; i++)
            {
                internalAcceleration[i] += v3d[i]; /// !!!
            }
        }

        private void AddMomentumFunc()
        {
            for (int i = 0; i < 3; i++)
            {
                IMeasurement m = forces[i + 3];
                if (m != null)
                {
                    v3d[i] += (double)m.Parameter();
                }
            }
        }

        protected virtual void CalculateInternalAccelerations()
        {
            for (int i = 0; i < internalAcceleration.Length; i++)
            {
                internalAcceleration[i] = 0;
            }
            AddForce();
            Array.Copy(state, 10, omega, 0, 3);
            momentOfInertia.Multiply(omega, omegaAdd);
            omega.VectorPoduct(omegaAdd, omegaAddP);
            for (int i = 0; i < 3; i++)
            {
                internalAcceleration[i + 3] += omegaAddP[i];
            }
            for (int i = 0; i < 3; i++)
            {
                v3d[i] = 0;
            }
            AddMomentum();
            RealMatrix.Multiply(invertedMomentOfInertia, v3d, omegaAdd);
            for (int i = 0; i < 3; i++)
            {
                internalAcceleration[i + 3] += omegaAdd[i];
            }
            omega2 = 0;
            for (int i = 0; i < 3; i++)
            {
                omega2 += omega[i] * omega[i];
            }
            if (connections == null)
            {
                return;
            }
            int n = connections.Length;
            for (int i = 0; i < n; i++)
            {
                CalculateInternalAccelerations(i);
            }
        }

        protected virtual void CalculateInternalAccelerations(int n)
        {
            double[] acc = internalAccelerations[n];
            double[] x = connections[n];

            // Angular acceleration
            Array.Copy(internalAcceleration, 3, v3d, 0, 3);
            v3d.Multiply(orientation, v3d1);
            Array.Copy(v3d1, 0, acc, 3, 3);

            // Linear acceleration
            Array.Copy(internalAcceleration, 3, v3d, 0, 3);
            Array.Copy(x, v3d1, 3);
            StaticExtensionVector3D.VectorPoduct(v3d, v3d1, v3d2);
            RealMatrixProcessor.RealMatrix.Multiply(v3d2, orientation, v3d1);
            for (int i = 0; i < 3; i++)
            {
                acc[i] = internalAcceleration[i] + v3d1[i];
            }
            Array.Copy(x, v3d1, 3);
            omega.VectorPoduct(v3d1, v3d2);
            omega.VectorPoduct(v3d2, v3d1);
            v3d1.Multiply(orientation, v3d);
            for (int i = 0; i < 3; i++)
            {
                acc[i] += v3d[i];
            }
        }


        #endregion

        #region Private Members

        /// <summary>
        /// Updates itself
        /// </summary>
        void update()
        {
            base.Update();
            CalculateInternalAccelerations();
        }

 

        #endregion

    }
}
