using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


using CategoryTheory;
using Diagram.UI;
using Diagram.UI.Aliases;

using DataPerformer.Portable;
using DataPerformer.Interfaces;

using Motion6D.Interfaces;

namespace Motion6D
{
    /// <summary>
    /// Aggregable object and data consumer
    /// </summary>
    public abstract class AggregableMechanicalObjectDataConsumer : CategoryObject, 
        IUpdatableObject, IPostSetArrow, IAggregableMechanicalObject, IDataConsumer
    {
        #region Fields

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };

        /// <summary>
        /// Type of variable
        /// </summary>
        static private readonly Double type = 0;

        /// <summary>
        /// Names of aliases
        /// </summary>
        protected Dictionary<int, string> aliasNames = new Dictionary<int,string>();

        /// <summary>
        /// Aliases
        /// </summary>
        private Dictionary<int, AliasName> aliases = new Dictionary<int, AliasName>();

        /// <summary>
        /// Initial state vector
        /// </summary>
        protected double[] initialState;

        /// <summary>
        /// State
        /// </summary>
        protected double[] state;

        /// <summary>
        /// Children
        /// </summary>
        protected Dictionary<IAggregableMechanicalObject, int[]> children =
            new Dictionary<IAggregableMechanicalObject, int[]>();
        
        /// <summary>
        /// Parent
        /// </summary>
        protected IAggregableMechanicalObject parent;

        /// <summary>
        /// Measurements
        /// </summary>
        protected List<IMeasurements> measurements = new List<IMeasurements>();

        /// <summary>
        /// 
        /// </summary>
        protected double[] connectionForce = new double[6];


        #endregion

        #region IUpdatableObject Members

        /// <summary>
        /// The update operation
        /// </summary>
        public virtual Action Update
        {
            get
            {
                return SetAliases;
            }
        }

        /// <summary>
        /// The "should update" sign
        /// </summary>
        public virtual bool ShouldUpdate
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

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            Post();
        }

        #endregion

        #region IAggregableMechanicalObject Members

        /// <summary>
        /// Number of degrees of freedom
        /// </summary>
        public abstract int Dimension
        {
            get;
        }

        /// <summary>
        /// Internal acceleration
        /// </summary>
        public abstract double[] InternalAcceleration
        {
            get;
        }

        /// <summary>
        /// Number of connections
        /// </summary>
        public abstract int NumberOfConnections
        {
            get;
        }

        /// <summary>
        /// State of connection 
        /// x[0] - position, x[1] - quaternion, 
        /// x[2] - linear velocity, x[3] - angular velocity 
        /// </summary>
        /// <param name="numOfConnection">Number of connection</param>
        /// <returns>State of connection</returns>
        public abstract double[] this[int numOfConnection]
        {
            get;
            set;
        }

        /// <summary>
        /// Calculates transformation matrix from genrealized coordinates to
        /// acceleration of connection
        /// </summary>
        /// <param name="numOfConnection">Number of connection</param>
        /// <returns>The transformation matrix</returns>
        public abstract double[,] GetAccelerationMatrix(int numOfConnection);

        /// <summary>
        /// State of object
        /// </summary>
        public virtual double[] State
        {
            get { return state; }
        }

        /// <summary>
        /// Gets matrix of forces
        /// </summary>
        /// <param name="numOfConnection">Number of connection</param>
        /// <returns>The matrix of forces</returns>
        public abstract double[,] GetForcesMatrix(int numOfConnection);

        /// <summary>
        /// Gets internal acceleration
        /// </summary>
        /// <param name="numOfConnection">Number of connection</param>
        /// <returns>Internal accceleration</returns>
        public abstract double[] GetInternalAcceleration(int numOfConnection);


        /// <summary>
        /// Gets connection force
        /// </summary>
        /// <param name="numOfConnection">Number of connection</param>
        /// <returns>Connection force</returns>
        public virtual double[] GetConnectionForce(int numOfConnection)
        {
            return connectionForce;
        }

        /// <summary>
        /// Children objects
        /// </summary>
        Dictionary<IAggregableMechanicalObject, int[]> IAggregableMechanicalObject.Children
        {
            get { return children; }
        }

        /// <summary>
        /// The is constant sign
        /// </summary>
        public abstract bool IsConstant
        {
            get;
        }


        /// <summary>
        /// Parent object
        /// </summary>
        IAggregableMechanicalObject IAggregableMechanicalObject.Parent
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

        #region IUpdatableObject Members

        Action IUpdatableObject.Update
        {
            get
            {
                return this.Update;
            }
        }

        bool IUpdatableObject.ShouldUpdate
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// Initial state vector
        /// </summary>
        public virtual double[] InitialState
        {
            get
            {
                return initialState;
            }
            set
            {
                if (value.Length != Dimension)
                {
                    throw new Exception();
                }
                initialState = value;
            }
        }
 
        /// <summary>
        /// All aliases
        /// </summary>
        public IList<string> AllAliases
        {
            get
            {
                return this.GetAliases(type);
            }
        }

        /// <summary>
        /// All measurements
        /// </summary>
        public IList<string> AllMeasurements
        {
            get
            {
                return this.GetAllMeasurements(type);
            }
        }

        /// <summary>
        /// Names of aliases
        /// </summary>
        public Dictionary<int, string> AliasNames
        {
            get
            {
                return aliasNames;
            }
            set
            {
                aliasNames = value;
                setAliases();
            }
        }

        /// <summary>
        /// Post opreation
        /// </summary>
        protected virtual void Post()
        {
            setAliases();
        }

        /// <summary>
        /// Updates itself
        /// </summary>
        protected virtual void UpdateAggregate()
        {
            SetAliases();
            this.FullReset();
            measurements.UpdateChildrenData();
        }

        /// <summary>
        /// Serializes itself
        /// </summary>
        /// <param name="info">Serialization info</param>
        protected void Serialize(SerializationInfo info)
        {
            info.AddValue("AliasNames", aliasNames, typeof(Dictionary<int, string>));
        }

        /// <summary>
        /// Deserializes itself
        /// </summary>
        /// <param name="info">Serialization info</param>
        protected void Deserialize(SerializationInfo info)
        {
            aliasNames = info.GetValue("AliasNames", typeof(Dictionary<int, string>)) as Dictionary<int, string>;
        }


        /// <summary>
        /// Sets aliases
        /// </summary>
        protected void SetAliases()
        {
            foreach (int key in aliases.Keys)
            {
                AliasName an = aliases[key];
                an.SetValue(state[key]);
            }
        }


        /// <summary>
        /// Sets aliases
        /// </summary>
        protected void setAliases()
        {
            aliases.Clear();
            foreach (int key in aliasNames.Keys)
            {
                aliases[key] = this.FindAliasName(aliasNames[key], false);
            }
        }

        #endregion

     }
}
