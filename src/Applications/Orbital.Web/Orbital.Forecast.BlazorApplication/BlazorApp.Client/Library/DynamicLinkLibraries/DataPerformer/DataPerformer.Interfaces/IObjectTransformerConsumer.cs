using System;
using System.Collections.Generic;
using System.Text;

namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Consumer of object transformer
    /// </summary>
    public interface IObjectTransformerConsumer
    {
        /// <summary>
        /// Adds transformer
        /// </summary>
        /// <param name="transformer">The transformer to add</param>
        void Add(IObjectTransformer transformer);


        /// <summary>
        /// Removes transformer
        /// </summary>
        /// <param name="transformer">The transformer to remove</param>
        void Remove(IObjectTransformer transformer);
    }
}
