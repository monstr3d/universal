using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPerformer.Interfaces.BufferedData.Interfaces
{
    /// <summary>
    /// Log direcrory
    /// </summary>
    public interface IBufferDirectory : IBufferItem
    {
        /// <summary>
        /// Children
        /// </summary>
        IEnumerable<IBufferItem> Children
        {
            get;
        }

    }
}
