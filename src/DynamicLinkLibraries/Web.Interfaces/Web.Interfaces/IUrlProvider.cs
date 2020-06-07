using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Interfaces
{
    /// <summary>
    /// Provider of uniform resource locator address
    /// </summary>
    public interface IUrlProvider
    {
        /// <summary>
        /// Uniform resource locator address
        /// </summary>
        string Url
        {
            get;
        }

        /// <summary>
        /// Change action
        /// </summary>
        event Action<string> Change;
    }
}
