using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
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
    /// Object which assemblies variables to matrix
    /// </summary>
    [Serializable()]
    public class MatrixAssembly : CategoryObject,  ISerializable, IDataConsumer, 
        IMeasurement, IPostSetArrow, IMeasurements
    {

        #region Fields

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };
        
        /// <summary>
        /// Names of scalars
        /// </summary>
        protected string[,] names;

        /// <summary>
        /// Measures of scalars
        /// </summary>
        protected IMeasurement[,] measures;

        /// <summary>
        /// All measurements
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
        /// Values
        /// </summary>
        protected double[,] val;

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
        public MatrixAssembly()
        {
            parameter = GetValue;
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected MatrixAssembly(SerializationInfo info, StreamingContext context)
            : this()
        {
            try
            {
                names = info.GetValue("Names", typeof(string[,])) as string[,];
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
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
            info.AddValue("Names", names, typeof(string[,]));
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
            get { return "Matrix"; }
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
            IDataConsumer c = this;
            c.UpdateChildrenData();
            for (int i = 0; i < val.GetLength(0); i++)
            {
                for (int j = 0; j < val.GetLength(1); j++)
                {
                    val[i, j] = (double)measures[i, j].Parameter();
                }
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
        public string[,] Names
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

        IEnumerable<IMeasurement> IChildren<IMeasurement>.Children => [this];

        /// <summary>
        /// Gets value
        /// </summary>
        /// <returns>Value</returns>
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
            measures = new IMeasurement[names.GetLength(0), names.GetLength(1)];
            for (int i = 0; i < names.GetLength(0); i++)
            {
                for (int j = 0; j < names.GetLength(1); j++)
                {
                    measures[i, j] = this.FindMeasurement(names[i, j], false);
                }
            }
            val = new double[measures.GetLength(0), measures.GetLength(1)];
            type = new ArrayReturnType(a, new int[] { measures.GetLength(0), measures.GetLength(1) }, false);
        }

        void IChildren<IMeasurement>.AddChild(IMeasurement child)
        {
        }

        void IChildren<IMeasurement>.RemoveChild(IMeasurement child)
        {
        }


        #endregion

    }
}
