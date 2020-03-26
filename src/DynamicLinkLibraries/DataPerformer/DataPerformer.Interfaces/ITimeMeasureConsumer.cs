using System;
using System.Collections.Generic;
using System.Text;

namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Consumer of time
    /// </summary>
    public interface ITimeMeasureConsumer
    {
        /// <summary>
        /// Time measure
        /// </summary>
        IMeasurement Time
        {
            get;
            set;
        }
    }
}
