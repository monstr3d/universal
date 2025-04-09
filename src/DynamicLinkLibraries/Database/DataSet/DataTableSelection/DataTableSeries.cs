using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using System.Runtime.Serialization;

using CategoryTheory;


using Diagram.UI;

using BaseTypes;

using DataPerformer;

using DataPerformer.Interfaces;

using DataSetService;


namespace DataTableSelection
{
    /// <summary>
    /// Series obtained from data set
    /// </summary>
    [Serializable()]
    public class DataTableSeries : Series, IPostSetArrow, IDataSetConsumer, INamedCoordinates
    {

        #region Fields

        /// <summary>
        /// X - coordinate measure name
        /// </summary>
        new protected string x = "";

        /// <summary>
        /// X - coordinate measure name
        /// </summary>
        new protected string y = "";

        /// <summary>
        /// Data set
        /// </summary>
        protected DataSet dataSet;

        /// <summary>
        /// Data set factory
        /// </summary>
        protected IDataSetFactory factory;


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
        public DataTableSeries()
        {
        }



        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected DataTableSeries(SerializationInfo info, StreamingContext context)
        {
            x = info.GetValue("X", typeof(string)) as string;
            y = info.GetValue("Y", typeof(string)) as string;
        }


        #endregion

        #region Overriden Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("X", x, typeof(string));
            info.AddValue("Y", y, typeof(string));
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            Set();
            Post();
        }

        #endregion

        #region IDataSetConsumer Members

        void IDataSetConsumer.Add(DataSet dataSet)
        {
            if (this.dataSet != null & dataSet != null)
            {
                throw new ErrorHandler.OwnException("Data set already exists");
            }
            this.dataSet = dataSet;
        }

        void IDataSetConsumer.Remove(DataSet dataSet)
        {
            this.dataSet = null;
        }

        IDataSetFactory IDataSetConsumer.Factory
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

        #region INamedCoordinates Members

        IList<string> INamedCoordinates.GetNames(string coordinateName)
        {
            return Names;
        }

        string INamedCoordinates.X
        {
            get
            {
                return x;
            }
        }

        string INamedCoordinates.Y
        {
            get
            {
                return y;
            }
        }

        /// <summary>
        /// Sets parameters
        /// </summary>
        /// <param name="x"> X measure column name</param>
        /// <param name="y"> Y measure column name</param>
        void INamedCoordinates.Set(string x, string y)
        {
            this.x = x;
            this.y = y;
            Set();
        }

        void INamedCoordinates.Update()
        {
        }


        #endregion
 
        #region Specific Members

        /// <summary>
        /// X measure column name
        /// </summary>
        new public string X
        {
            get { return x; }
        }

        /// <summary>
        /// Y measure column name
        /// </summary>
        new public string Y
        {
            get { return y; }
        }

        /// <summary>
        /// Names of columns
        /// </summary>
        public List<string> Names
        {
            get
            {
                if (dataSet == null)
                {
                    return null;
                }
                return DataSetSelection.GetDoubleNames(dataSet);
            }
        }

        /// <summary>
        /// Sets parameters
        /// </summary>
        /// <param name="x"> X measure column name</param>
        /// <param name="y"> Y measure column name</param>
        public void Set(string x, string y)
        {
            this.x = x;
            this.y = y;
            Set();
        }

        /// <summary>
        /// Sets all parameters
        /// </summary>
        protected void Set()
        {
            points = new List<double[]>();
            if (dataSet != null)
            {
                DataTable table = dataSet.Tables[0];
                DataColumn cx = DataSetSelection.SelectColumn(x, dataSet);
                DataColumn cy = DataSetSelection.SelectColumn(y, dataSet);
                foreach (DataRow row in table.Rows)
                {
                    object ox = row[cx];
                    if (ox is DBNull)
                    {
                        continue;
                    }
                    object oy = row[cy];
                    if (oy is DBNull)
                    {
                        continue;
                    }
                    points.Add(new double[] { Convert(ox), Convert(oy) });
                }
            }
        }

        double Convert(object o)
        {
            if (o is DateTime)
            {
                DateTime dt = (DateTime)o;
                return dt.DateTimeToDay();
            }
            return (double)o;
        }

        #endregion

    }
}
