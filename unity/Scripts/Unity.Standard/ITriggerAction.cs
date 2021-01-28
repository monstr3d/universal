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
    public interface ITriggerAction
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
        Action<Collider> Action { get; }
        
    }
}
