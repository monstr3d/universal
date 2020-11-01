using System;
using System.Collections.Generic;

namespace Unity.Standard
{
    /// <summary>
    /// Indicator with limits
    /// </summary>
    public interface ILimits
    {
        /// <summary>
        /// Limits
        /// </summary>
        Dictionary<string, Tuple<float[], string[]>> Limits
        { get; }

        /// <summary>
        /// The exceeds sign
        /// </summary>
        bool Exceeds
        { get; }

        /// <summary>
        /// Active
        /// </summary>
        bool Active
        { set; }

     }
}
