using System;
using System.Runtime.Serialization;



namespace DataSetService
{

    /// <summary>
    /// Arrow between data set provider and data set consumer
    /// </summary>
    [Serializable()]
    public class DataSetArrow : Pure.DataSetArrow, ISerializable
    {


        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public DataSetArrow()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public DataSetArrow(SerializationInfo info, StreamingContext context)
        {
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        #endregion
    }

}
