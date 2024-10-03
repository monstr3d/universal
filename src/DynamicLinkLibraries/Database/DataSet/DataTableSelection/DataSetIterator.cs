using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;

using BaseTypes;

using Diagram.UI;

using DataPerformer;
using DataPerformer.Interfaces;

using DataSetService;


namespace DataTableSelection
{

    /// <summary>
    /// Iterator obtained from data set
    /// </summary>
    /// <summary>
    /// Iterator obtained from data set
    /// </summary>
    [Serializable()]
    public class DataSetIterator : CategoryObject, ISerializable, IIterator, IDataSetConsumer, IMeasurements
    {

        #region Fields

        /// <summary>
        /// Data set
        /// </summary>
        protected DataSet dataSet;

        /// <summary>
        /// Iterator table
        /// </summary>
        protected DataTable table;

        /// <summary>
        /// Current row
        /// </summary>
        protected DataRow row;

        /// <summary>
        /// Current row number
        /// </summary>
        protected int current = -1;

        /// <summary>
        /// Reference to a table row
        /// </summary>
        protected DataRow[] rowreference = new DataRow[] { null };

        /// <summary>
        /// Factory
        /// </summary>
        protected IDataSetFactory factory;

        /// <summary>
        /// List of measurements
        /// </summary>
        protected List<IMeasurement> measurements = new List<IMeasurement>();

        /// <summary>
        /// On Add action
        /// </summary>
        protected Action<DataSet> onAdd = (DataSet dataSet) => { };

        /// <summary>
        /// On Remoe action
        /// </summary>
        protected Action<DataSet> onRemove = (DataSet dataSet) => { };

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public DataSetIterator()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public DataSetIterator(SerializationInfo info, StreamingContext context)
        {
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {

        }

        #endregion

        #region IIterator Members

        void IIterator.Reset()
        {
            Reset();
        }

        bool IIterator.Next()
        {
            if (table == null)
            {
                return false;
            }
            ++current;
            if (current >= table.Rows.Count)
            {
                return false;
            }
            row = table.Rows[current];
            rowreference[0] = row;
            return true;
        }

        #endregion

        #region IDataSetConsumer Members

        void IDataSetConsumer.Add(DataSet dataSet)
        {
            if (this.dataSet != null & dataSet != null)
            {
                throw new Exception();
            }
            this.dataSet = dataSet;
            table = dataSet.Tables[0];
            Reset();
            Init();
        }

        void IDataSetConsumer.Remove(DataSet dataSet)
        {
            this.dataSet = null;
        }

        /// <summary>
        /// Factory
        /// </summary>
        public IDataSetFactory Factory
        {
            get
            {
                return factory;
            }
            set
            {
                factory = value;
            }
        }

        event Action<DataSet> IDataSetConsumer.OnAdd
        {
            add { onAdd += value; }
            remove { onAdd -= value; }
        }

        event Action<DataSet> IDataSetConsumer.OnRemome
        {
            add { onRemove += value; }
            remove { onRemove -= value; }
        }

        #endregion

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get { return measurements.Count; }
        }

        IMeasurement IMeasurements.this[int n]
        {
            get { return measurements[n]; }
        }

        void IMeasurements.UpdateMeasurements()
        {
        }

        bool IMeasurements.IsUpdated
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

        #region Specific Members

        /// <summary>
        /// Resets itself
        /// </summary>
        void Reset()
        {
            current = -1;
 //           rowreference[0] = table.Rows[0];
        }

        /// <summary>
        /// Initialization
        /// </summary>
        protected void Init()
        {
            if (table == null)
            {
                return;
            }
            measurements.Clear();
            foreach (DataColumn c in table.Columns)
            {
                int ord = c.Ordinal;
                string name = c.ColumnName;
                object type = null;
                if (factory != null)
                {
                    type = factory.GetObjectType(c);
                }
                else
                {
                    type = c.DataType.GetObjectFromType();
                }
                IMeasurement m = new RowMeasurement(name, type, rowreference, ord);
                measurements.Add(m);
            }
        }


        #endregion

        #region RowMeasure class

        /// <summary>
        /// Measurement from data row
        /// </summary>
        class RowMeasurement : IMeasurement
        {
            string name;
            object type;
            DataRow[] row;
            int ordinal;

            Func<object> par;

            internal RowMeasurement(string name, object type, DataRow[] row, int ordinal)
            {
                this.name = name;
                this.type = type;
                this.row = row;
                this.ordinal = ordinal;
                par = Load;
            }

            #region IMeasurement Members

            Func<object> IMeasurement.Parameter
            {
                get { return par; }
            }

            string IMeasurement.Name
            {
                get { return name; }
            }

            object IMeasurement.Type
            {
                get { return type; }
            }

            #endregion

            #region Private Members

            object Get()
            {
                return row[0][ordinal];
            }

            object Load()
            {
                try
                {
                    object o = Get();
                    par = Get;
                    return o;
                }
                catch (Exception ex)
                {
                    ex.ShowError((int)-1);
                }
                return type.GetDefaultValue();

            }
        }

        #endregion

        #endregion

    }
}
