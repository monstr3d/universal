using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytes.Exchange.Interfaces
{
    /// <summary>
    /// Writer of events
    /// </summary>
    public interface IEventWriter
    {
        /// <summary>
        /// Processed data
        /// </summary>
        /// <param name="data">data</param>
        void OnEvent(byte[] data);
 
    }
}
