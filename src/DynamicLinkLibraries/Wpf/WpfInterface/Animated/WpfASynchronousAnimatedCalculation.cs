﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Diagram.UI.Interfaces;

using DataPerformer.Interfaces;
using DataPerformer;

using WpfInterface.Interfaces;

namespace WpfInterface.Animated
{
    /// <summary>
    /// Calculation for WPF synchronous animation
    /// </summary>
    class WpfAsynchronousAnimatedCalculation : IAsynchronousCalculation
    {
        #region Fields

      //  Func<double, TimeSpan> timeTransform;

        AnimatableWrapper[] wrappers;

        IAnimatedObject[] objects;

        int count = 0;

        Action finish = () => { };

        double timeScale;

        double start;

        Action<double> step;

        bool isRunning = true;

        Action onInterrupt = () => { };

        #endregion

        #region Ctor

        internal WpfAsynchronousAnimatedCalculation(IAnimatedObject[] objects, double timeScale, IComponentCollection collection = null)
        {
            this.objects = objects;
            List<AnimatableWrapper> l = new List<AnimatableWrapper>();
            foreach (IAnimatedObject ob in objects)
            {
                foreach (AnimatableWrapper wrapper in ob.Children)
                {
                    l.Add(wrapper);
                    wrapper.OnFinish += StopAction;
                    ++count;
                }
            }
            wrappers = l.ToArray();
            step = StartAnimation;
            this.timeScale = timeScale;
        }

        #endregion

        #region IAsynchronousCalculation

        void IAsynchronousCalculation.Start(double time)
        {
            start = time;
            StartAll();
        }

        Action<double> IAsynchronousCalculation.Step
        {
            get
            {
                return StepAction;
            }
        }

        event Action IAsynchronousCalculation.Finish
        {
            add { finish += value; }
            remove { }
        }

        void IAsynchronousCalculation.Interrupt()
        {
            StopFinal();
            onInterrupt();
        }

        void IAsynchronousCalculation.Suspend()
        {

        }

        bool IAsynchronousCalculation.IsRunning
        {
            get { return isRunning; }
        }

        event Action IAsynchronousCalculation.OnSuspend
        {
            add {  }
            remove {  }
        }

        event Action IAsynchronousCalculation.OnInterrupt
        {
            add { onInterrupt += value; }
            remove { onInterrupt -= value; }
        }

        #endregion

        #region Private Members

        private void StopAnimation()
        {
            if (count == 0)
            {
                return;
            }
            --count;
            if (count == 0)
            {
                isRunning = false;
                foreach (AnimatableWrapper animated in wrappers)
                {
                    animated.OnFinish -= StopAction;
                }
                finish();
            }
        }


        private void StartAll()
        {
            foreach (IAnimatedObject animated in objects)
            {
                double[] position = animated.ReferenceFrame.Position;
                double[] quaternion = animated.ReferenceFrame.Quaternion;
                foreach (AnimatableWrapper wrapper in animated.Children)
                {
                    wrapper.Init(position, quaternion);
                }
            }
   
        }

        private void StepAction(double time)
        {
            step(time);
        }
        

        private void StartAnimation(double time)
        {
            Go(time);
            DateTime startAnimation = DateTime.Now;
            foreach (IAnimatedObject animated in objects)
            {
                double[] position = animated.ReferenceFrame.Position;
                double[] quaternion = animated.ReferenceFrame.Quaternion;
                foreach (AnimatableWrapper wrapper in animated.Children)
                {
                    wrapper.StartAnimation(position, quaternion, startAnimation);
                }
            }
            step = Go;
        }

        private void Go(double time)
        {
            double t = timeScale * (time - start);
            TimeSpan ts = TimeSpan.FromSeconds(t);
            foreach (IAnimatedObject obj in objects)
            {
                obj.Enqueue(ts);
            }
        }

        private void StopAction()
        {
            if (!isRunning)
            {
                return;
            }
            --count;
            if (count == 0)
            {
                StopFinal();
            }
        }

        void StopFinal()
        {
            isRunning = false;
            foreach (IAnimatedObject animated in objects)
            {
                animated.OnStop -= StopAction;
            }
            foreach (AnimatableWrapper wrapper in wrappers)
            {
                wrapper.Stop();
            }
            finish();
        }

        #endregion



     }
}
