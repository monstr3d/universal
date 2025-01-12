using System;

namespace DataPerformer.Interfaces.Attributes
{
    /// <summary>
    /// Type of iterator
    /// </summary>
    public class IteratorTypeAttribute : Attribute
    {
        /// <summary>
        /// Log
        /// </summary>
        public bool Log { get; set; } = false;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="log">Log</param>
        public IteratorTypeAttribute(bool log)
        {
            Log = log;
        }
    }
}
