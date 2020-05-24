using Scada.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Unity.Standard
{
    /// <summary>
    /// Trigger action
    /// </summary>
    public interface ICollisionAction
    {
        /// <summary>
        /// Sets parameters
        /// </summary>
        /// <param name="gameObject">Game object</param>
        /// <param name="scada">Scada</param>
        void Set(GameObject gameObject, IScadaInterface scada);

        /// <summary>
        /// Collider action
        /// </summary>
        Action<Collision> Action { get; }

        /// <summary>
        /// Constants
        /// </summary>
        float[] Constants { get; }

        /// <summary>
        /// Sets constants
        /// </summary>
        /// <param name="offset">Offset</param>
        /// <param name="constants">Constants</param>
        /// <returns>New offset </returns>
        int SetConstants(int offset, float[] constants);
 
        
    }
}
