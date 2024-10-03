using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Diagram.UI;
using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;

using Animation.Interfaces;
using Animation.Interfaces.Enums;

using WpfInterface.Interfaces;

namespace WpfInterface.Factory
{
    public class AnimationDriver : IAnimationDriver
    {

        #region Fields

   
        public static readonly AnimationDriver Singleton = new AnimationDriver();

         Action onStop = () => { };

    
  
        #endregion


        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        protected AnimationDriver()
        {

        }

        #endregion 


        #region IAnimationDriver Members

        object IAnimationDriver.StartAnimation(IComponentCollection collection, string[] reasons,
            AnimationType animationType, TimeSpan pause, double timeScale, bool realTime, bool absoluteTime)
        {
            List<IAnimatedObject> l = new List<IAnimatedObject>();
            IAsynchronousCalculation calc = null;
            double[] changeFrameTime = new double[1];
            
            if (realTime)
            {
                collection.ForEach((IAnimatedObject animated) =>
                {
                    animated.InitRealtime(animationType, changeFrameTime);
                    l.Add(animated);
                });
                if (animationType == AnimationType.Asynchronous)
                {
                    calc = new Animated.WpfAsynchronousRealtimeAnimatedCalculation(l.ToArray(), 1, changeFrameTime, collection);
                }
            }
            else
            {
                collection.ForEach<IAnimatedObject>((IAnimatedObject animated) =>
                {
                    animated.InitAnimation(animationType);
                      l.Add(animated);
                     animated.InitAnimation(animationType);
                 });
                if (animationType == AnimationType.Synchronous)
                {
                     if (pause > TimeSpan.FromSeconds(0))
                    {
                        calc = new DataPerformer.AsynchronousCalculation.PauseAsynchronousCalculation(pause);
                        collection = null;
                    }
                }
                else
                {
                    calc = new Animated.WpfAsynchronousAnimatedCalculation(l.ToArray(), timeScale, collection);
                }
            }
            if (l.Count == null)
            {
                return null;
            }
            return calc;
        }

        bool IAnimationDriver.SuppotrsAsynchronous
        {
            get { return true; }
        }
 

        #endregion

        #region Private

        /*
        private void Stop()
        {
            if (collection == null)
            {
                return;
            }
            --count;
            if (count == 0)
            {
                collection.ForEach<IAnimatedObject>((IAnimatedObject animated) =>
                {
                    animated.OnStop -= Stop;

                });
                collection = null;
                onStop();
            }
        }*/

        #endregion

    }
}
