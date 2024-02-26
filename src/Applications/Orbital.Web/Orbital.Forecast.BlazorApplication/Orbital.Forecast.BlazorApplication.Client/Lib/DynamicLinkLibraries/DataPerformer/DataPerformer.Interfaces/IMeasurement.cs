using System;
using System.Collections.Generic;
using System.Text;

namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Elementary unit of data exchange
    /// </summary>
    public interface IMeasurement
    {
        /// <summary>
        /// Function which returns unit of data
        /// </summary>
        Func<object> Parameter
        {
            get;
        }

        /// <summary>
        /// The name of data unit
        /// </summary>
        string Name
        {
            get;
        }  

        /// <summary>
        /// Type of parameter
        /// </summary>
        object Type
        {
            get;
        }
    }
}
