using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Unity.Standard
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
