using System;
using System.Collections.Generic;
using System.Text;

namespace Motion6D.Interfaces
{
    /// <summary>
    /// Consumer of facet
    /// </summary>
    public interface IFacetConsumer
    {
        /// <summary>
        /// Facet
        /// </summary>
        IFacet Facet
        {
            get;
            set;
        }
    }
}
