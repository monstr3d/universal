using System.Collections.Generic;

namespace Event.Log.Database.Interfaces
{
    /// <summary>
    /// Log data
    /// </summary>
    public interface ILogData : ILogItem
    {
        /// <summary>
        /// File name
        /// </summary>
        string FileName
        {
            get;
        }

        /// <summary>
        /// Creates enumerable
        /// </summary>
        /// <param name="begin">Begin</param>
        /// <param name="end">End</param>
        /// <returns>The enumerable</returns>
        IEnumerable<byte[]> Create(uint begin, uint end);

        /// <summary>
        /// Type
        /// </summary>
        int Type
        {
            get;
            set;
        }

        /// <summary>
        /// Length
        /// </summary>
        int Length
        {
            get;
        }
    }
}
