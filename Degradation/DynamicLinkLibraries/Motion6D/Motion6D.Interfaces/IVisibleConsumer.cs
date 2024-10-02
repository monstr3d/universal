using System;
using System.Collections.Generic;
using System.Text;

namespace Motion6D.Interfaces
{
    /// <summary>
    /// Consumer of visible 3D object
    /// </summary>
    public interface IVisibleConsumer
    {
        /// <summary>
        /// Adds visible object to consumer
        /// </summary>
        /// <param name="visible">Visible object to add</param>
        void Add(IVisible visible);

        /// <summary>
        /// Removes visible object from consumer
        /// </summary>
        /// <param name="visible">Visible object to remove</param>
        void Remove(IVisible visible);

        /// <summary>
        /// Post operation
        /// </summary>
        /// <param name="visible">Visible object</param>
        void Post(IVisible visible);

        /// <summary>
        /// Add event
        /// </summary>
        event Action<IVisible> OnAdd;

        /// <summary>
        /// Remove event
        /// </summary>
        event Action<IVisible> OnRemove;

        /// <summary>
        /// Post event
        /// </summary>
        event Action<IVisible> OnPost;

    }
}
