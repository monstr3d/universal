using System;

using UnityEngine;

using Scada.Interfaces;

namespace Unity.Standard
{

    /// <summary>
    /// Updates Rect transformation
    /// </summary>
    public interface IUpdateGameObject
    {
        /// <summary>
        /// Sets parameters
        /// </summary>
        /// <param name="obj">Measurement object</param>
        /// <param name="indicator">Indicator</param>
        /// <param name="scada">SCADA</param>
        void Set(object[] obj, Component indicator, IScadaInterface scada);

        /// <summary>
        /// Update action
        /// </summary>
        Action Update { get; }

        /// <summary>
        /// Constants
        /// </summary>
        float[] Constants
        {
            get;
        }

        /// <summary>
        /// Sets constants
        /// </summary>
        /// <param name="Offset">Off set</param>
        /// <param name="constants"></param>
        /// <returns>Resul offset</returns>
        int SetConstants(int offset, float[] constants);

    }
}
