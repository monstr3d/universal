using System;
using System.Runtime.Serialization;
using System.Windows.Forms;

using CategoryTheory;

using DataPerformer.Event.Portable.Objects;
using DataPerformer.UI.UserControls;

using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

namespace DataPerformer.UI.Labels
{
    /// <summary>
    /// Label of time series median
    /// </summary>
    [Serializable]
    public class TimeSeriesMedianLabel : UserControlBaseLabel,  IPostSet
    {

        #region Fields

        TimeSeriesMedian median;

        UserControlTimeSeriesMedian userControl;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TimeSeriesMedianLabel()
            : base(typeof(EventRelated.TimeSeriesMedian), "", ResourceImage.Median)
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected TimeSeriesMedianLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        #endregion

        #region Overriden


        /// <summary>
        /// Internal control
        /// </summary>
        protected override UserControl Control
        {
            get
            {
                userControl = new UserControlTimeSeriesMedian();
                return userControl;
            }
        }

        /// <summary>
        /// Object
        /// </summary>
        protected override ICategoryObject Object
        {
            get
            {
                return median;
            }
            set
            {
                if (!(value is TimeSeriesMedian))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                median = value as TimeSeriesMedian;
                if (userControl != null)
                {
                    userControl.TimeSeriesMedian = median;
                }
             }
        }

        #endregion


        #region IPostSet Members

        void IPostSet.Post()
        {
            userControl.TimeSeriesMedian = median;
        }

        #endregion

    }
}