using System;
using System.Collections.Generic;

using UnityEngine;

namespace Unity.Standard
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
