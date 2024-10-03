using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Data;

using CategoryTheory;

using SerializationInterface;


namespace DataSetService
{
    /// <summary>
    /// Data provider from xml
    /// </summary>
    [Serializable()]
    public class SavedDataProvider : CategoryObject, ISerializable, IDataSetProvider
    {

        #region Fields

        /// <summary>
        /// Data set
        /// </summary>
        protected DataSet dataSet = new DataSet();

        /// <summary>
        /// Change event
        /// </summary>
        protected Action<DataSet> change = (DataSet ds) => { };


        #endregion

        #region Ctor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SavedDataProvider()
        {
        
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected SavedDataProvider(SerializationInfo info, StreamingContext context)
        {
            dataSet = info.Deserialize<DataSet>("DataSet");
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.Serialize<DataSet>("DataSet", dataSet);
        }

        #endregion

        #region IDataSetProvider Members

        DataSet IDataSetProvider.DataSet
        {
            get { return dataSet; }
        }

        IDataSetFactory IDataSetProvider.Factory
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        event Action<DataSet> IDataSetProvider.Change
        {
            add { change += value; }
            remove { change -= value; }
        }

        #endregion

        #region Members

        /// <summary>
        /// Sets Data set
        /// </summary>
        /// <param name="dataSet"></param>
        public void Set(DataSet dataSet)
        {
            this.dataSet = dataSet;
            change(dataSet);
        }

        #endregion

    }
}
