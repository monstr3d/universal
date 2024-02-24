using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Interfaces
{
    /// <summary>
    /// Writer of events
    /// </summary>
    public interface IEventWriter
    {
        /// <summary>
        /// Types of data
        /// </summary>
        List<Tuple<string, object>> Types
        {
            get;
            set;
        }

        /// <summary>
        /// Processed data
        /// </summary>
        /// <param name="data">data</param>
        void OnEvent(object[] data);
 
    }
}
