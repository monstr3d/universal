using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Runtime.Serialization;
using System.Data.Common;

using CategoryTheory;


namespace DataSetService
{

    /// <summary>
    /// Arrow between data set provider and data set consumer
    /// </summary>
    [SerializableAttribute()]
    public class DataSetArrow : CategoryArrow, ISerializable, IDisposable
    {

        #region Fields

         /// <summary>
        /// Source
        /// </summary>
        protected IDataSetConsumer source;

        /// <summary>
        /// Target
        /// </summary>
        protected IDataSetProvider target;

        #endregion

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

        #region ICategoryArrow Members

        /// <summary>
        /// The source of this arrow
        /// </summary>
        public override ICategoryObject Source
        {
            get
            {
                return source as ICategoryObject;
            }
            set
            {
                source = value.GetSource<IDataSetConsumer>(); 
            }
        }

        /// <summary>
        /// The target of this arrow
        /// </summary>
        public override ICategoryObject Target
        {
            get
            {
                return target as ICategoryObject;
            }
            set
            {
                target = value.GetTarget<IDataSetProvider>();
                source.Factory = target.Factory;
                source.Add(target.DataSet);
            }
        }


        #endregion

        #region IDisposable Members

        /// <summary>
        /// The post remove operation
        /// </summary>
        void IDisposable.Dispose()
        {
            if (source != null & target != null)
            {
                if (target.DataSet != null)
                {
                    source.Remove(target.DataSet);
                }
            }
        }

        #endregion
    }

}
