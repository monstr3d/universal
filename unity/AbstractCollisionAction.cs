using System;

using UnityEngine;

using Scada.Interfaces;


namespace Unity.Standard
{
    /// <summary>
    /// Abstract trigger action
    /// </summary>
    public abstract class AbstractCollisionAction : ICollisionAction
    {
        #region Fields

        protected GameObject gameObject;

        protected Component collisionIndicator;

        protected IScadaInterface scada;

        protected float[] constants = new float[0];

        #endregion

        /// <summary>
        /// Collider action
        /// </summary>
        public abstract Action<Collision> Action { get; }

        /// <summary>
        /// Constants
        /// </summary>
        float[] ICollisionAction.Constants => constants;

        /// <summary>
        /// Sets constants
        /// </summary>
        /// <param name="offset">Offset</param>
        /// <param name="constants">Constants</param>
        /// <returns>New offset </returns>
        public virtual int SetConstants(int offset, float[] constants)
        {
            return constants.SetConstants(offset, this.constants);
        }


        /// <summary>
        /// Sets parameters
        /// </summary>
        /// <param name="gameObject">Game object</param>
        /// <param name="collisionIndicator">Collision Indicator</param>
        /// <param name="scada">Scada</param>
        public virtual void Set(GameObject gameObject, Component collisionIndicator, 
            IScadaInterface scada)
        {
            this.gameObject = gameObject;
            this.scada = scada;
            this.collisionIndicator = collisionIndicator;
        }
    }
}
