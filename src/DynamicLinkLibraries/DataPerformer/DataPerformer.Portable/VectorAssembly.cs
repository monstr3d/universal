using System;
using System.Collections.Generic;

using BaseTypes;

using CategoryTheory;

using Diagram.UI;

using DataPerformer.Interfaces;
using ErrorHandler;
using NamedTree;

namespace DataPerformer.Portable
{
    /// <summary>
    /// Object which assemblies variables to vector
    /// </summary>
    public class VectorAssembly : CategoryObject, IDataConsumer, IMeasurement, IPostSetArrow, 
        IMeasurements
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

  
        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            Post();
        }

        #endregion

        #region IDataConsumer Members

        void IChildren<IMeasurements>.AddChild(IMeasurements measurements)
        {
            this.measurements.Add(measurements);
        }

        void IChildren<IMeasurements>.RemoveChild(IMeasurements measurements)
        {
            this.measurements.Remove(measurements);
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
     // !!! DELETE            c.UpdateChildrenData();
                for (int i = 0; i < val.Length; i++)
                {
                    val[i] = (double)measures[i].Parameter();
                }
            }
            catch (Exception e)
            {
                e.HandleException(10);
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

        IEnumerable<IMeasurements> IChildren<IMeasurements>.Children => measurements;

        IEnumerable<IMeasurement> IChildren<IMeasurement>.Children => measures;

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

        void IChildren<IMeasurement>.AddChild(IMeasurement child)
        {
            throw new ErrorHandler.OwnException();

        }

        void IChildren<IMeasurement>.RemoveChild(IMeasurement child)
        {
        }

        #endregion

    }
}
