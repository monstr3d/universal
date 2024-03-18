using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Interfaces
{
    /// <summary>
    /// Event and output
    /// </summary>
    public interface IEventReader
    {
        /// <summary>
        /// Types of data
        /// </summary>
        List<Tuple<string, object>> Types
        {
            get;
        }

        /// <summary>
        /// Event Data
        /// </summary>
        event Action<object[]> EventData;

        /// <summary>
        /// The "is enabled" sign
        /// </summary>
        bool IsEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// Names of events
        /// </summary>
        string[] EventNames
        {
            get;
        }

        /// <summary>
        /// Access to the named event
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IEventReader this[string name]
        {
            get;
        }

        /// <summary>
        /// Change event
        /// </summary>
        event Action Change;
         
    }
}
