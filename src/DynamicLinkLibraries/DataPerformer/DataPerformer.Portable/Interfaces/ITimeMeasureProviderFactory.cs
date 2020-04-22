using BaseTypes.Attributes;
using DataPerformer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPerformer.Portable.Interfaces
{

    /// <summary>
    /// Factory of the time measurement 
    /// </summary>
    public interface ITimeMeasureProviderFactory
    {
        /// <summary>
        /// Creates Realtime provider
        /// <param name="timeUnit">Time unit</param>
        /// <param name="isAbsoluteTime">The "is absolute time" sign</param>
        /// <param name="stepAction">Step Action</param>
        /// <param name="dataConsumer">Data Consumer</param>
        /// <param name="log">log</param>
        /// <param name="reason">Reason</param>
        /// <returns>The Realtime provider</returns>
        ITimeMeasureProvider Create(bool isAbsolute, TimeType timeUnit, string reason);

    }
}
