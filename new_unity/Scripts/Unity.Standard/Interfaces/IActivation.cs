using System;

using UnityEngine;

namespace Unity.Standard.Interfaces
{
    /// <summary>
    /// Activation
    /// </summary>
    public interface IActivation
    {
        /// <summary>
        /// Activation
        /// </summary>
        /// <param name="monoBehaviours">Mono Behaviours</param>
        void Activate(MonoBehaviour[] monoBehaviours);

        /// <summary>
        /// Level
        /// </summary>
        int Level
        { get; set; }

        /// <summary>
        /// Sets constants
        /// </summary>
        /// <param name="constants">Constants</param>
        /// <returns>Number of constants</returns>
        int SetConstants(float[] constants);

        /// <summary>
        /// Sets constants
        /// </summary>
        /// <param name="constants">Constants</param>
        /// <returns>Number of constants</returns>
        int SetConstants(string[] constants);

        /// <summary>
        /// Update
        /// </summary>
        Action Update { get; }

        /// <summary>
        /// Gets activation type from the level
        /// </summary>
        /// <param name="level">The level</param>
        /// <returns>The activation type</returns>
        Type GetActivationType(int level);

    }
}
