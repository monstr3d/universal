using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Hoder of measurement
    /// </summary>
    public interface IMeasurementHolder
    {
        /// <summary>
        /// Measurement
        /// </summary>
        IMeasurement Measurement
        { get; }
    }
}
