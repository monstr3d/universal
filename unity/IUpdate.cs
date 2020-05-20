using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Unity.Standard
{
    /// <summary>
    /// Update interface
    /// </summary>
    public interface IUpdate
    {
        /// <summary>
        /// Sets objects
        /// </summary>
        /// <param name="wrapper">Wrapper</param>
        /// <param name="mono">Script</param>
        void Set(MonoBehaviorWrapper wrapper, ReferenceFrameBehavior mono);

        /// <summary>
        /// Starts itself
        /// </summary>
        void Start();

        /// <summary>
        /// Updates
        /// </summary>
        void Update();
    }
}
