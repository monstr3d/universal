using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

using Animation.Interfaces.Enums;

using Motion6D;
using Motion6D.Interfaces;

using WpfInterface.Animated;

namespace WpfInterface.Interfaces
{
    /// <summary>
    /// Animated object
    /// </summary>
    interface IAnimatedObject : ILinear6DForecast
    {
        /// <summary>
        /// Initialze animation
        /// </summary>
        void InitAnimation(AnimationType animationType);

        /// <summary>
        /// Initialze animation
        /// </summary>
        /// <param name="animationType">Type of animation</param>
        /// <param name="changeFrameTime">Time of frame change</param>
        void InitRealtime(AnimationType animationType, double[] changeFrameTime);

        /// <summary>
        /// Children
        /// </summary>
        AnimatableWrapper[] Children
        {
            get;
        }

        /// <summary>
        /// Change event
        /// </summary>
        event Action Change;

        /// <summary>
        /// Stops animation
        /// </summary>
        void StopAnimation();

        /// <summary>
        /// On stop action
        /// </summary>
        event Action OnStop;

        /// <summary>
        /// Supports animation events
        /// </summary>
        bool SupportsAnimationEvents
        {
            get;
            set;
        }

     }
}
