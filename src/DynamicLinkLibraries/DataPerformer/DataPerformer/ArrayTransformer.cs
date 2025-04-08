using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using BaseTypes;
using CategoryTheory;
using DataPerformer.Interfaces;
using DataPerformer.Portable;
using Diagram.UI;
using ErrorHandler;
using NamedTree;

namespace DataPerformer
{
    /// <summary>
    /// Transforms array to scalars
    /// </summary>
    [Serializable()]
    public class ArrayTransformer : CategoryObject, ISerializable, IMeasurements, IMeasurement,
        IDataConsumer, IPostSetArrow
    {
        #region Fields

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };

        private string meas = "";

        private bool isObjectType;
        
        private Array val;

        //private Array input;

        private object type;

        private const Double dtype = 0;

        IMeasurement measure;

        bool isUpdated;

        IDataConsumer cons = null;

        IMeasurements measurements;

        Action update = () =>
        {
        };


        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ArrayTransformer()
        {
            cons = this;
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected ArrayTransformer(SerializationInfo info, StreamingContext context)
        {
            cons = this;
            meas = info.GetString("Measure");
            isObjectType = info.GetBoolean("IsObjectType");
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Measure", meas);
            info.AddValue("IsObjectType", isObjectType);
        }

        #endregion

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get { return (type == null) ? 0 : 1; }
        }

        IMeasurement IMeasurements.this[int number]
        {
            get { return this; }
        }

        void IMeasurements.UpdateMeasurements()
        {
            Update();
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

        void IChildren<IMeasurements>.AddChild(IMeasurements measurements)
        {
            if (this.measurements == null)
            {
                this.measurements = measurements;
                return;
            }
            throw new Exception("Only one measurement is allowed");
        }

        void IChildren<IMeasurements>.RemoveChild(IMeasurements measurements)
        {
            if (measurements == this.measurements)
            {
                this.measurements = null;
            }
        }

        void IDataConsumer.UpdateChildrenData()
        {
            PureDesktop.PerformObjectAction(measurements.UpdateMeasurements, this);
        }

        int IDataConsumer.Count
        {
            get { return (measurements == null) ? 0 : 1; }
        }

        IMeasurements IDataConsumer.this[int n]
        {
            get { return measurements; }
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

        #endregion

        #region IMeasurement Members

        Func<object> IMeasurement.Parameter
        {
            get { return GetValue; }
        }

        string IMeasurement.Name
        {
            get { return "Array"; }
        }

        object IMeasurement.Type
        {
            get { return type; }
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            Post();
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// All measurements of this object
        /// </summary>
        public ICollection<string> Measurements
        {
            get
            {
                if (measurements == null)
                {
                    return new string[0];
                }
                Dictionary<string, object> mm = this.GetAllMeasurementsType();
                List<string> l = new List<string>();
                foreach (string key in mm.Keys)
                {
                    object o = mm[key];
                    if (o is ArrayReturnType)
                    {
                        l.Add(key);
                    }
                }
                return l.ToArray();
            }
        }

        /// <summary>
        /// The "is object array" sign
        /// </summary>
        public bool IsObjectArray
        {
            get
            {
                return isObjectType;
            }
            set
            {
                isObjectType = value;
                Post();
            }
        }

        /// <summary>
        /// Measure name
        /// </summary>
        public string Measure
        {
            get
            {
                return meas;
            }
            set
            {
                meas = value;
                Post();
            }
        }

        IEnumerable<IMeasurement> IChildren<IMeasurement>.Children => [this];

        IEnumerable<IMeasurements> IChildren<IMeasurements>.Children => [measurements];

        /// <summary>
        /// Updates itself
        /// </summary>
        protected void Update()
        {
            try
            {
                if (isUpdated)
                {
                    return;
                }
                cons.UpdateChildrenData();
                Array input = measure.Parameter() as Array;
                int n = input.Length;
                Array.Copy(input, val, n);
            }
            catch (Exception e)
            {
                e.HandleException(10);
                this.Throw(e);
            }
        }

        object GetValue()
        {
            return val;
        }

        void Post()
        {
            if (meas.Length > 0)
            {
                measure = this.FindMeasurement(meas, true);
                if (measure == null)
                {
                    val = null;
                    type = null;
                    meas = "";
                    return;
                }
                CreateType();
            }
        }

        void CreateType()
        {
            if (measure == null)
            {
                return;
            }
            object mt = measure.Type;
            if (!(mt is ArrayReturnType))
            {
                return;
            }
            ArrayReturnType at = mt as ArrayReturnType;
            type = new ArrayReturnType(at.ElementType, at.Dimension, isObjectType);
            if (isObjectType)
            {
                val = new object[at.Dimension[0]];

            }
            if (at.ElementType.Equals(dtype))
            {
                val = new double[at.Dimension[0]];
            }

        }

        void IChildren<IMeasurement>.AddChild(IMeasurement child)
        {
            throw new NotImplementedException();
        }

        void IChildren<IMeasurement>.RemoveChild(IMeasurement child)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
