﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animation.Interfaces.Enums
{
    /// <summary>
    /// Type of action
    /// </summary>
    public enum ActionType
    {
        /// <summary>
        /// Calculation
        /// </summary>
        Calculation,
        /// <summary>
        /// Animation
        /// </summary>
        Animation
    }


    /// <summary>
    /// Type of animation
    /// </summary>
    public enum AnimationType
    {
        /// <summary>
        /// Synchronous
        /// </summary>
        Synchronous,

        /// <summary>
        /// Asynchronous
        /// </summary>
        Asynchronous
    }
}
