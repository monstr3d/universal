using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPerformer.Interfaces.BufferedData.Interfaces
{
    /// <summary>
    /// Change of log item
    /// </summary>
    public interface IChangeBufferItem
    {

        /// <summary>
        /// Change log item
        /// </summary>
        event Action<IBufferItem> Change;
    }
}
