using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bytes.Exchange.Interfaces
{
    /// <summary>
    /// Event and output
    /// </summary>
    public interface IEventReader
    {
        /// <summary>
        /// Event Data
        /// </summary>
        event Action<byte[]> EventData;

        /// <summary>
        /// The "is enabled" sign
        /// </summary>
        bool IsEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// Change event
        /// </summary>
        event Action Change;
         
    }
}
