using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;

using Diagram.UI;

using BaseTypes;


using DataPerformer.Interfaces;
using DataPerformer.Portable;

namespace DataPerformer
{
    /// <summary>
    /// Object which assemblies variables to vector
    /// </summary>
    [Serializable()]
    public class VectorAssembly : CategoryObject, ISerializable, IDataConsumer, IMeasurement, IPostSetArrow, IMeasurements
    {

        #region Fields

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };
        
        /// <summary>
        /// Associated object
        /// </summary>
        protected object obj;

        /// <summary>
        /// Names of scalar variables
        /// </summary>
        protected string[] names;

        /// <summary>
        /// Scalar measures
        /// </summary>
        protected IMeasurement[] measures;

        /// <summary>
        /// External measurements
        /// </summary>
        protected IList<IMeasurements> measurements = new List<IMeasurements>();

        /// <summary>
        /// Return type
        /// </summary>
        protected ArrayReturnType type;

        /// <summary>
        /// The "is updated" sign
        /// </summary>
        protected bool isUpdated;

        /// <summary>
        /// Array values
        /// </summary>
        protected double[] val;

        /// <summary>
        /// Parameter
        /// </summary>
        protected Func<object> parameter;

        const Double a = 0;


        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public VectorAssembly()
        {
            parameter = GetValue;
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected VectorAssembly(SerializationInfo info, StreamingContext context)
            : this()
        {
            try
            {
                names = info.GetValue("Names", typeof(string[])) as string[];
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (names == null)
            {
                return;
            }
            info.AddValue("Names", names, typeof(string[]));
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            Post();
        }

        #endregion

        #region IDataConsumer Members

        void IDataConsumer.Add(IMeasurements measurements)
        {
            this.measurements.Add(measurements);
        }

        void IDataConsumer.Remove(IMeasurements measurements)
        {
            this.measurements.Remove(measurements); ;
        }

        void IDataConsumer.UpdateChildrenData()
        {
            foreach (IMeasurements m in measurements)
            {
                m.UpdateMeasurements();
            }
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

        #region IMeasurement Members

        Func<object> IMeasurement.Parameter
        {
            get { return parameter; }
        }

        string IMeasurement.Name
        {
            get { return "Vector"; }
        }

        object IMeasurement.Type
        {
            get { return type; }
        }

        #endregion

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get { return 1; }
        }

        IMeasurement IMeasurements.this[int n]
        {
            get { return this; }
        }

        void IMeasurements.UpdateMeasurements()
        {
            if (isUpdated)
            {
                return;
            }
            try
            {
                IDataConsumer c = this;
                c.UpdateChildrenData();
                for (int i = 0; i < val.Length; i++)
                {
                    val[i] = (double)measures[i].Parameter();
                }
            }
            catch (Exception e)
            {
                e.ShowError(10);
                this.Throw(e);
            }
            isUpdated = true;
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

        #region Specific Members

        /// <summary>
        /// Names of scalar variables
        /// </summary>
        public string[] Names
        {
            get
            {
                return names;
            }
            set
            {
                names = value;
                Post();
            }
        }

        /// <summary>
        /// Gets value
        /// </summary>
        /// <returns></returns>
        protected object GetValue()
        {
            return val;
        }


        private void Post()
        {
            if (names == null)
            {
                return;
            }
            measures = new IMeasurement[names.Length];
            for (int i = 0; i < names.GetLength(0); i++)
            {
                measures[i] = this.FindMeasurement(names[i], false);
            }
            val = new double[measures.Length];
            type = new ArrayReturnType(a, new int[] { measures.Length }, false);
        }

        #endregion

    }
}
