using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Interfaces
{
    public interface ITimer
    {
        /// <summary>
        /// Time span
        /// </summary>
        TimeSpan TimeSpan
        {
            get;
        }

        /// <summary>
        /// Is enabled
        /// </summary>
        bool IsEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// Event
        /// </summary>
        event Action Event;
    }
}
