using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

using Motion6D;

using WpfInterface.Interfaces;
using WpfInterface.Transformations;

namespace WpfInterface.Animated
{
    /// <summary>
    /// Wrapper of animatable object
    /// </summary>
    public class AnimatableWrapper : IDisposable
    {
        #region Fields

        private IAnimatable animatable;

        private DependencyProperty dependencyProperty;

        private object value;

        private Action change = () => { };

        private IAnimatedObject animatedObject;

        private Uniform6DTransformation transformation;

        private Action finish = () => { };

        double[] auxQuaternion = new double[4];
        
        bool isStopped = false;

        object loc = new object();

        #endregion

        #region Ctor

       internal AnimatableWrapper(IAnimatable animatable, DependencyProperty dependencyProperty, 
            IAnimatedObject animatedObject, bool realtime, double[] changeFrameTime)
        {
            this.animatable = animatable;
            this.dependencyProperty = dependencyProperty;
            value = (animatable as DependencyObject).GetValue(dependencyProperty);
            this.animatedObject = animatedObject;
            transformation = new Uniform6DTransformation(this,animatedObject.ReferenceFrame, 
                realtime, changeFrameTime, animatedObject.ForecastTime);
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Animatable
        /// </summary>
        public IAnimatable Animatable
        {
            get
            {
                return animatable;
            }
        }

        /// <summary>
        /// Dependency property
        /// </summary>
        public DependencyProperty DependencyProperty
        {
            get
            {
                return dependencyProperty;
            }
        }

  
        #endregion

        #region Internal Members

        internal IAnimatedObject Animated
        {
            get
            {
                return animatedObject;
            }
        }

        internal void Stop()
        {
            lock (loc)
            {
                transformation.Stop();
                isStopped = true;
                finish();
            }
        }
        
        internal void StartRealtime(double time, DateTime start)
        {
            transformation.StartRealtime(time, start);
        }

        internal void Init(double[] coord, double[] quaternion)
        {
            transformation.Init(coord, quaternion);
        }
      
        internal void StartAnimation(double[] coord, double[] quaternion, DateTime start)
        {
            transformation.StartAnimation(coord, quaternion, start);
        }
    

        internal void Enqueue(Tuple<TimeSpan, double[], double[]> parameters)
        {
             transformation.Enqueue(parameters);
        }

        internal void Finish()
        {
            finish();
        }

        internal event Action OnFinish
        {
            add { finish += value; }
            remove { finish -= value; }
        }

        internal  Action Event
        {
            get
            {
                return transformation.Event;
            }
        }

 
        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            (animatable as DependencyObject).SetValue(dependencyProperty, value);
            animatedObject.Change -= change;
        }

        #endregion
    }
}
