using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Interfaces
{
    /// <summary>
    /// Constant url
    /// </summary>
    public interface IConstantUrl : IUrlConsumer, IUrlProvider
    {
        /// <summary>
        /// Constant URL
        /// </summary>
        string ConstantUrl
        {
            get;
            set;
        }
    }
}
