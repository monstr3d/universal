using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Interfaces
{
    /// <summary>
    /// Log list
    /// </summary>
    public interface IListLog
    {
        /// <summary>
        /// List
        /// </summary>
        List<object> Log
        {
            get;
        }
    }
}
