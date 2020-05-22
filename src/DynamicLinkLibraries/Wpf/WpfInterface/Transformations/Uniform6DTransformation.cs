using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

using WpfInterface.Animated;
using WpfInterface.Interfaces;


namespace WpfInterface.Transformations
{
    /// <summary>
    /// Custom animation class for uniform 6D motion
    /// </summary>
    public class Uniform6DTransformation : AnimationTimeline
    {
        #region Fields

        /// <summary>
        /// Full transformation
        /// </summary>
        Transform3DGroup transform = new Transform3DGroup();

        /// <summary>
        /// Translation
        /// </summary>
        TranslateTransform3D translation = new TranslateTransform3D();

        /// <summary>
        /// Constant rotation
        /// </summary>
        RotateTransform3D rotate_const = new RotateTransform3D();

        /// <summary>
        /// Uniform rotation
        /// </summary>
        RotateTransform3D rotate_uniform = new RotateTransform3D();

        /// <summary>
        /// Quaternion of constant rotation
        /// </summary>
        QuaternionRotation3D quaternionConstRotation = new QuaternionRotation3D();

        /// <summary>
        /// Axis angle rotation for uniform rotation
        /// </summary>
        AxisAngleRotation3D angle_uniform = new AxisAngleRotation3D();

        /// <summary>
        /// Calculator
        /// </summary>
        Motion6D.Uniform6D.Uniform6DMotion calculator;

        double[] rotationAxis = new double[3];

        object loc = new object();

        private Queue<Tuple<TimeSpan, double[], double[]>> queue = new Queue<Tuple<TimeSpan, double[], double[]>>();
  
        public static readonly DependencyProperty FromProperty;
    
        public static readonly DependencyProperty ToProperty;

        AnimatableWrapper wrapper;

        IAnimatable animatable;

        DependencyProperty dependencyProperty;

        private bool isStopped = false;

        private double currentTime;

        private Motion6D.Interfaces.ReferenceFrame frame;

        private DateTime startTime;

        private TimeSpan forecast;

        private IAnimatedObject animated;

        private bool realtime;

        private double[] changeFrameTime;

     
        #endregion

        #region Ctor

         internal Uniform6DTransformation(AnimatableWrapper wrapper, Motion6D.Interfaces.ReferenceFrame frame,
            bool realtime, double[] changeFrameTime, TimeSpan forecastTime)
        {
            
            transform.Children.Add(rotate_uniform); // Adds uniform rotation
            transform.Children.Add(rotate_const);   // Adds constant rptation
            transform.Children.Add(translation);    // Adds translation  
            rotate_const.Rotation = quaternionConstRotation; // Setting quaterion for constant rotation
            rotate_uniform.Rotation = angle_uniform;         // Setting axis rotation for uniform rotation
            this.wrapper = wrapper;
            animatable = wrapper.Animatable;
            dependencyProperty = wrapper.DependencyProperty;
            this.frame = frame;
            this.changeFrameTime = changeFrameTime;
            From = 0;
            To = 1;
            calculator = new Motion6D.Uniform6D.Uniform6DMotion(frame, rotationAxis, 
                changeFrameTime, forecastTime.TotalSeconds, 
                wrapper.Animated.CoordinateError, wrapper.Animated.AngleError);
            animated = wrapper.Animated;
            forecast = animated.ForecastTime;
            this.realtime = realtime;
           if (realtime)
           {
               calculator.InitializePrediction(forecast.TotalSeconds);
           }
           calculator.Change += Motion_Change;
        }

  
        private Uniform6DTransformation(Uniform6DTransformation lm)
            : this(lm.wrapper, lm.frame, lm.realtime, lm.changeFrameTime, lm.forecast)
        {
            rotationAxis = lm.rotationAxis;
            queue = lm.queue;
            calculator = lm.calculator;
            currentTime = lm.currentTime;
            startTime = lm.startTime;
            From = lm.From;
            To = lm.To;
            Set();
        }


        #endregion

        #region Public Members

        /// <summary>
        /// From
        /// </summary>
        public double From
        {
            get
            {
                return (double)GetValue(Uniform6DTransformation.FromProperty);
            }
            set
            {
                SetValue(Uniform6DTransformation.FromProperty, value);
            }
        }

        /// <summary>
        /// To
        /// </summary>
        public double To
        {
            get
            {
                return (double)GetValue(Uniform6DTransformation.ToProperty);
            }
            set
            {
                SetValue(Uniform6DTransformation.ToProperty, value);
            }
        }

 
        #endregion

        #region Overriden Members

        /// <summary>
        /// Overriden calculation of current value
        /// </summary>
        /// <param name="defaultOriginValue">Default Origin Value</param>
        /// <param name="defaultDestinationValue">Default Destination Value</param>
        /// <param name="animationClock">Animation Clock</param>
        /// <returns>Transformation</returns>
        public override object GetCurrentValue(object defaultOriginValue,
                object defaultDestinationValue, AnimationClock animationClock)
        {
            SetProgressTime(animationClock.CurrentProgress.Value);
            return transform;
        }

        /// <summary>
        /// Type of target property
        /// </summary>
        public override Type TargetPropertyType
        {
            get { return typeof(Transform3D); }
        }

        /// <summary>
        /// Creates freezable instance
        /// </summary>
        /// <returns>Instance</returns>
        protected override Freezable CreateInstanceCore()
        {
            Uniform6DTransformation l = new Uniform6DTransformation(this);
            l.queue = queue;
            l.currentTime = currentTime;
            return l;
        }

        #endregion

        #region Internal Members

        /// <summary>
        /// Adds animation parameters
        /// </summary>
        /// <param name="parameters">Parameters</param>
        internal void Enqueue(Tuple<TimeSpan, double[], double[]> parameters)
        {
            lock (loc)
            {
                if (isStopped)
                {
                    return;
                }
                queue.Enqueue(parameters);
            }
        }

        internal void Stop()
        {
            lock (loc)
            {
                if (!isStopped)
                {
                    isStopped = true;
                    if (realtime)
                    {
                        this.Completed -= Linear6DMotion_RealtimeAnimationCompleted;
                        animatable.BeginAnimation(dependencyProperty, null);
                    }
                    else
                    {
                        this.Completed -= Linear6DMotion_RealtimeAnimationCompleted;
                        queue.Clear();
                        animatable.BeginAnimation(dependencyProperty, null);
                        isStopped = true;
                        wrapper.Finish();
                    }
                }
            }
        }

        internal void StartAnimation(double[] coord, double[] quaternion, DateTime start)
        {
            Action action = () => { StartAnimationPrivate(coord, quaternion, start); };
            this.Dispatcher.Invoke(action);
        }

        internal void StartRealtime(double time, DateTime start)
        {
            Action action = () => { StartRealtimePrivate(time, start); };
            this.Dispatcher.Invoke(action);
        }

        /// <summary>
        /// Time
        /// </summary>
        internal double Time
        {
            get
            {
             //   lock (loc)
             //   {
                    return currentTime;
            //    }
            }
        }

        /// <summary>
        /// Inits itself
        /// </summary>
        /// <param name="coord">Coordinates</param>
        /// <param name="quaternion">Quaternion</param>
        internal void Init(double[] coord, double[] quaternion)
        {
            calculator.Init(coord, quaternion);
        }

        internal void Event()
        {
            double time = (DateTime.Now - startTime).TotalSeconds;
            calculator.Interrupt(time);
        }

        #endregion

        #region Private Members
    

        static Uniform6DTransformation()
        {
            FromProperty = DependencyProperty.Register("From", typeof(double),
                typeof(Uniform6DTransformation));

            ToProperty = DependencyProperty.Register("To", typeof(double),
                typeof(Uniform6DTransformation));
        }

        void Motion_Change()
        {
            Dispatcher.Invoke(MotionChange);
        }

        void MotionChange()
        {
            animatable.BeginAnimation(dependencyProperty, null);
            animatable.BeginAnimation(dependencyProperty, this);
        }

        private void Set()
        {
            double[] quater1 = calculator.QuaternionBegin;
            Quaternion qua = new Quaternion(quater1[1], quater1[2], quater1[3], quater1[0]);
            SetProgressTime(currentTime);
            quaternionConstRotation.Quaternion = qua;
              System.Windows.Media.Media3D.Vector3D v =
                new System.Windows.Media.Media3D.Vector3D(rotationAxis[0],
                rotationAxis[1], rotationAxis[2]);
            angle_uniform.Axis = v;
            From = 0;
            To = 1;
        }

        /// <summary>
        /// Sets progress time
        /// </summary>
        /// <param name="progressTime">Progress time</param>
        private void SetProgressTime(double progressTime)
        {
            double angle;               // Angle of rotation
            double x, y, z;             // Coordinates of transformation
            calculator.SetTime(progressTime, out angle, out x, out y, out z); // Calculation of coordinates and angle
            angle_uniform.Angle = (180 / Math.PI) * angle;                    // Sets value of rotation angle
            double fromVal = From;
            double toVal = To;
            // Setting of coordinates of transformation
            translation.OffsetX = x;                   
            translation.OffsetY = y;
            translation.OffsetZ = z;
        }

  
        private void StartAnimationPrivate(double[] coord, double[] quaternion, DateTime start)
        {
            Tuple<TimeSpan, double[], double[]> parameters;
            lock (loc)
            {
                parameters = queue.Dequeue();
            }
            startTime = start;
            this.Duration = parameters.Item1;
            this.RepeatBehavior = new RepeatBehavior(1);
            calculator.Set(parameters.Item2, parameters.Item3);
            this.Completed += Linear6DMotion_AnimationCompleted;
            System.Windows.Media.Media3D.Vector3D v =
            new System.Windows.Media.Media3D.Vector3D(rotationAxis[0],
            rotationAxis[1], rotationAxis[2]);
            angle_uniform.Axis = v;
            angle_uniform.Angle = 0;
            Quaternion qua = new Quaternion(quaternion[1], quaternion[2], quaternion[3], quaternion[0]);
            quaternionConstRotation.Quaternion = qua;
            translation.OffsetX = coord[0];
            translation.OffsetY = coord[1];
            translation.OffsetZ = coord[2];
            From = 0;
            To = 1;
            animatable.BeginAnimation(dependencyProperty, this);
        }


        private void StartRealtimePrivate(double time, DateTime start)
        {
            startTime = start;
            this.Duration = forecast;
            this.RepeatBehavior = new RepeatBehavior(1);
            calculator.StartRealtime(time);
            this.Completed += Linear6DMotion_RealtimeAnimationCompleted;
            System.Windows.Media.Media3D.Vector3D v =
            new System.Windows.Media.Media3D.Vector3D(rotationAxis[0],
            rotationAxis[1], rotationAxis[2]);
            angle_uniform.Axis = v;
            angle_uniform.Angle = 0;
            double[] quaternion = calculator.QuaternionBegin;
            double[] coord = calculator.Begin;
            Quaternion qua = new Quaternion(quaternion[1], quaternion[2], quaternion[3], quaternion[0]);
            quaternionConstRotation.Quaternion = qua;
            translation.OffsetX = coord[0];
            translation.OffsetY = coord[1];
            translation.OffsetZ = coord[2];
            From = 0;
            To = 1;
            animatable.BeginAnimation(dependencyProperty, this);
        }

        void Linear6DMotion_RealtimeAnimationCompleted(object sender, EventArgs e)
        {
            if (isStopped)
            {
                return;
            }
            double time = (DateTime.Now - startTime).TotalSeconds;
            calculator.StepRealtime(time);
            Action action = () =>
                  {
                      animatable.BeginAnimation(dependencyProperty, this);
                  };
            Dispatcher.Invoke(action);
        }


        void Linear6DMotion_AnimationCompleted(object sender, EventArgs e)
        {
            Tuple<TimeSpan, double[], double[]> parameters;
            lock (loc)
            {
                if (queue.Count == 0)
                {
                    wrapper.Finish();
                    return;
                }
                parameters = queue.Dequeue();
            }
            calculator.SetNew(parameters.Item2, parameters.Item3);
            TimeSpan ts = startTime + parameters.Item1 - DateTime.Now;
            if (ts.Ticks < 0)
            {
                return;
            }
            Action action = () =>
            {
                Duration = ts;
                animatable.BeginAnimation(dependencyProperty, this);
            };
            Dispatcher.Invoke(action);

        }

        #endregion

    }
}