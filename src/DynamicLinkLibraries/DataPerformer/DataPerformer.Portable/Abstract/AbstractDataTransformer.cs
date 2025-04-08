using System;
using System.Collections.Generic;

using CategoryTheory;

using DataPerformer.Interfaces;
using NamedTree;
using RealMatrixProcessor;

namespace DataPerformer.Portable.Abstract
{
    /// <summary>
    /// Base class for data transformation
    /// </summary>
    public abstract class AbstractDataTransformer : CategoryObject, IDataConsumer, IMeasurements
    {

        #region Fields

        protected RealMatrix realMatrix = new();
        protected  static RealMatrix rm = new();

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };

        /// <summary>
        /// The "is updated" sign
        /// </summary>
        bool isUpdated = false;

        /// <summary>
        /// External mrasurements
        /// </summary>
        protected List<IMeasurements> measurements = new List<IMeasurements>();

        /// <summary>
        /// Dependent objects
        /// </summary>
        protected List<object> l = new List<object>();

        /// <summary>
        /// Output measurements
        /// </summary>
        protected IMeasurement[] mea = new IMeasurement[0];

        /// <summary>
        /// Runtime
        /// </summary>
        protected IDataRuntime runtime;

        protected bool isSerialized = false;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        protected AbstractDataTransformer()
        {
            Interfaces.IDataRuntimeFactory factory = StaticExtensionDataPerformerPortable.Factory;
            Diagram.UI.Interfaces.IComponentCollection collection =
           factory.CreateCollection(this, 0, StaticExtensionDataPerformerInterfaces.Calculation);
            //!!!  runtime = this.CreateRuntime(StaticExtensionDataPerformerInterfaces.Calculation);

        }

        #endregion

        #region IDataConsumer Members
       void IChildren<IMeasurements>.AddChild(IMeasurements measurements)
        {
            this.measurements.Add(measurements);
            // this.measurements.GetDependent(l, dependent);
            if (!isSerialized)
            {
                runtime = this.CreateRuntime(StaticExtensionDataPerformerInterfaces.Calculation);
            }
        }

        void IChildren<IMeasurements>.RemoveChild(IMeasurements measurements)
        {
            this.measurements.Remove(measurements);
            //this.measurements.GetDependent(l, dependent);
            if (!isSerialized)
            {
                CreateRuntime();
            }
        }

        void IDataConsumer.UpdateChildrenData()
        {
            /* foreach (IMeasurements m in dependent)
             {
                 m.IsUpdated = false;
                 m.UpdateMeasurements();
             }*/
            runtime.UpdateAll();
        }

        int IDataConsumer.Count
        {
            get { return measurements.Count; }
        }

        IMeasurements IDataConsumer.this[int number]
        {
            get { return measurements[number]; }
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

        event Action<IMeasurements> IChildren<IMeasurements>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IMeasurements> IChildren<IMeasurements>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IMeasurement> IChildren<IMeasurement>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IMeasurement> IChildren<IMeasurement>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }

        #endregion

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get { return mea.Length; }
        }

        IMeasurement IMeasurements.this[int number]
        {
            get { return mea[number]; }
        }

        /// <summary>
        /// Updates measurements data
        /// </summary>
        public abstract void UpdateMeasurements();

        /// <summary>
        /// Shows, wreather the object is updated
        /// </summary>
        public bool IsUpdated
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

        IEnumerable<IMeasurements> IChildren<IMeasurements>.Children => measurements;

        IEnumerable<IMeasurement> IChildren<IMeasurement>.Children => mea;

        #endregion

        #region Protected Members

        /// <summary>
        /// Creates runtime
        /// </summary>
        protected void CreateRuntime()
        {
            Interfaces.IDataRuntimeFactory factory = StaticExtensionDataPerformerPortable.Factory;
            // Diagram.UI.Interfaces.IComponentCollection collection =
            // factory.CreateCollection(this, 0, StaticExtensionDataPerformerInterfaces.Calculation);
            // runtime = factory.Create(collection, 0, StaticExtensionDataPerformerInterfaces.Calculation);
            runtime = this.CreateRuntime(StaticExtensionDataPerformerInterfaces.Calculation);
        }

        void IChildren<IMeasurement>.AddChild(IMeasurement child)
        {
            
        }

        void IChildren<IMeasurement>.RemoveChild(IMeasurement child)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

