using System;
using System.Collections.Generic;

using UnityEngine;

namespace Unity.Standard.Interfaces
{
    public interface IKeyListener
    {
        /// <summary>
        /// Keys
        /// </summary>
        List<KeyCode> Keys
        { get; }

        /// <summary>
        /// Action
        /// </summary>
        Action<KeyCode> Action
        { get; }
    }
}
