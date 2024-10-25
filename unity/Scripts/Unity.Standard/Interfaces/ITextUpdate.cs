using System;

using Scada.Interfaces;

using UnityEngine.UI;

namespace Unity.Standard.Interfaces
{
    /// <summary>
    /// Updates text
    /// </summary>
    public interface ITextUpdate
    {

        /// <summary>
        /// Creates Text action
        /// </summary>
        /// <param name="scada">Scada</param>
        /// <param name="parameter">Parameter</param>
        /// <param name="format">Format</param>
        /// <param name="comment">Comment</param>
        /// <param name="text">Text</param>
        /// <param name="scale">Scale</param>
        /// <returns>The action</returns>
        Action Create(IScadaInterface scada, 
            string parameter, string format, Text text, float scale = 0);

    }
}
