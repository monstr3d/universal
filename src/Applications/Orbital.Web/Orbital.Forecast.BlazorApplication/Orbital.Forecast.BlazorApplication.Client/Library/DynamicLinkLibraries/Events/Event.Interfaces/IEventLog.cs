using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Interfaces
{
    /// <summary>
    /// Event log
    /// </summary>
    public interface IEventLog
    {
        /// <summary>
        /// New log
        /// </summary>
        IEventLog NewLog
        {
            get;
        }

        /// <summary>
        /// Writes data
        /// </summary>
        /// <param name="data"></param>
        /// <param name="time"></param>
        void Write(Dictionary<string, object> data, DateTime time);

        /// <summary>
        /// Writes event
        /// </summary>
        /// <param name="ev">Event</param>
        /// <param name="name">Name</param>
        /// <param name="time">Time</param>
        void Write(IEvent ev, string name, DateTime time);

        /// <summary>
        /// Writes event reader
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="name">The name</param>
        /// <param name="output">The output</param>
        /// <param name="time">Time</param>
        void Write(IEventReader reader, string name, object[] output, DateTime time);
    }
}
