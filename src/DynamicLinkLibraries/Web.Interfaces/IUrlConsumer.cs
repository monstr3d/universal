using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Interfaces
{
    /// <summary>
    /// Consumer of uniform resource locator address
    /// </summary>
    public interface IUrlConsumer
    {
        /// <summary>
        /// Uniform resource locator address
        /// </summary>
        string Url
        {
            set;
        }

        /// <summary>
        /// Change action
        /// </summary>
        event Action<string> Change;
    }
}
