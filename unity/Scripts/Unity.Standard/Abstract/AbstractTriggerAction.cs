using System;

using Scada.Interfaces;
using Unity.Standard.Interfaces;
using UnityEngine;

namespace Unity.Standard.Abstract
{
    /// <summary>
    /// Abstract trigger action
    /// </summary>
    public abstract class AbstractTriggerAction : ITriggerAction
    {
        #region Fields

        protected GameObject gameObject;

        protected IScadaInterface scada;

        #endregion

        /// <summary>
        /// Collider action
        /// </summary>
        public abstract Action<Collider> Action { get; }

        /// <summary>
        /// Sets parameters
        /// </summary>
        /// <param name="gameObject">Game object</param>
        /// <param name="scada">Scada</param>
        public virtual void Set(GameObject gameObject, IScadaInterface scada)
        {
            this.gameObject = gameObject;
            this.scada = scada;
        }
    }
}
