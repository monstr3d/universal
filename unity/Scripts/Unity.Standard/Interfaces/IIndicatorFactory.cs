using System;
using UnityEngine;

namespace Unity.Standard.Interfaces
{
    /// <summary>
    /// Factory of indicators
    /// </summary>
    public interface IIndicatorFactory
    {
        /// <summary>
        /// Gets indicator from game oject
        /// </summary>
        /// <param name="gameObject">The game object</param>
        /// <returns>The indicator</returns>
        IIndicator Get(GameObject gameObject);

    }
}
