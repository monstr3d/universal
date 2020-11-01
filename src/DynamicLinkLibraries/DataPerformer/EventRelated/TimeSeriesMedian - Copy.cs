using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;

namespace DataPerformer.EventRelated
{
    /// <summary>
    /// Time series median
    /// </summary>
    [Serializable]
    public class TimeSeriesMedian : Event.Portable.Objects.TimeSeriesMedian, ISerializable, IPostSetArrow
    {

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TimeSeriesMedian()
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected TimeSeriesMedian(SerializationInfo info, StreamingContext context)
            : this()
        {
            Condition = info.GetString("Condition");
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Condition", Condition);
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            CreateMesurements();
            if (condition == null)
            {
                Condition = "";
            }
        }

        #endregion

    }
}
