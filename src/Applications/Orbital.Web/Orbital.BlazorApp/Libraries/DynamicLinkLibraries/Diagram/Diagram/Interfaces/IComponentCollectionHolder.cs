using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Holder of component collection
    /// </summary>
    public interface IComponentCollectionHolder
    {
        /// <summary>
        /// Component collection
        /// </summary>
        IComponentCollection ComponentCollection
        {
            get;
            set;
        }
    }
}
