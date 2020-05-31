using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Unity.Standard
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


    }
}
