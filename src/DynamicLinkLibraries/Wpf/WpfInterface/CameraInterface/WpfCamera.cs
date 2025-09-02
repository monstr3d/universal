using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

using Diagram.UI;

using DataPerformer.Interfaces;
using DataPerformer.Interfaces.Attributes;

using Event.Interfaces;

using Animation.Interfaces.Enums;

using Motion6D;
using Motion6D.Interfaces;

using WpfInterface.Interfaces;
using WpfInterface.Animated;
using Wpf.Loader;
using NamedTree;




namespace WpfInterface.CameraInterface
{
    /// <summary>
    /// WPF implementation of virtual video camera
    /// </summary>
    [Serializable()]
    [CalculationReasons(new string[] { "Animation", StaticExtensionEventInterfaces.Realtime })]
    public class WpfCamera : Motion6D.Camera, ISerializable,
        IUpdatableObject, IObjectTransformer, IMeasurements,
        IEventHandler, IAnimatedObject
    {

        #region Fields


        /// <summary>
        /// Inputs
        /// </summary>
        static private readonly string[] inp = new string[] { "X", "Y", "Z", "Width" };

        /// <summary>
        /// Outputs
        /// </summary>
        static private readonly string[] outp = new string[] { "X", "Y" };

        double[] inpos = new double[3];

        double[] outpos = new double[3];



        const Double a = 0;

        private static bool show = true;

        /// <summary>
        /// The "update bitmap" sign
        /// </summary>
        protected bool updateBmp = true;


        private UserControl control;

        Viewport3D viewport;

        PerspectiveCamera pCamera = new PerspectiveCamera();


        AnimatableWrapper[] animatableChildren = new AnimatableWrapper[1];


        object parentControl;

        private Dictionary<IPosition, Visual3D> dict = new Dictionary<IPosition, Visual3D>();


        #region Fields


        /// <summary>
        /// BackGround
        /// </summary>
        private string backgound = "";

        Action onStop = () => { };

        private Action update;

        #region Realtime animation

        /// Forecast time
        /// </summary>
        TimeSpan forecastTime = TimeSpan.FromSeconds(1);

        /// <summary>
        /// Error of coordinate
        /// </summary>
        double coordinateError = 1;

        /// <summary>
        /// Error of angle
        /// </summary>
        double angleError = Math.PI / 180;

        /// <summary>
        /// Time of frame change
        /// </summary>
        double[] changeFrameTime;

        List<IEvent> allEvents = new List<IEvent>();

        List<IEvent> animationEvents = new List<IEvent>();

        bool suppotrsAnimation = false;

        #endregion


        #endregion

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        public WpfCamera()
        {
            cameraPositon = this;
        }



        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        private WpfCamera(SerializationInfo info, StreamingContext context)
            : this()
        {
            try
            {
                width = (int)info.GetValue("Width", typeof(int));
                height = (int)info.GetValue("Height", typeof(int));
                fieldOfView = (double)info.GetValue("Angle", typeof(double));
                updateBmp = (bool)info.GetValue("UpdateBmp", typeof(bool));
                backgound = info.GetString("CameraBackground");
                near = info.GetDouble("NearPlaneDistance");
                far = info.GetDouble("FarPlaneDistance");
                try
                {
                    Scale = info.GetDouble("Scale");
                }
                catch (Exception)
                {
                }
                try
                {
                    forecastTime = (TimeSpan)info.GetValue("ForecastTime", typeof(TimeSpan));
                    coordinateError = info.GetDouble("CoordinateError");
                    angleError = info.GetDouble("AngleError");

                }
                catch (Exception)
                {
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Width", width, typeof(int));
            info.AddValue("Height", height, typeof(int));
            info.AddValue("Angle", fieldOfView, typeof(double));
            info.AddValue("UpdateBmp", updateBmp, typeof(bool));
            info.AddValue("CameraBackground", backgound);
            info.AddValue("NearPlaneDistance", near);
            info.AddValue("FarPlaneDistance", far);
            info.AddValue("Scale", Scale);
            info.AddValue("ForecastTime", forecastTime, typeof(TimeSpan));
            info.AddValue("CoordinateError", coordinateError);
            info.AddValue("AngleError", angleError);
        }

        #endregion

        #region IUpdatableObject Members

        Action IUpdatableObject.Update
        {
            get
            {
                return update;
            }
        }

        bool IUpdatableObject.ShouldUpdate
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        #endregion

        #region IObjectTransformer Members

        string[] IObjectTransformer.Input
        {
            get { return inp; }
        }

        string[] IObjectTransformer.Output
        {
            get { return outp; }
        }

        object IObjectTransformer.GetInputType(int i)
        {
            return a;
        }

        object IObjectTransformer.GetOutputType(int i)
        {
            return a;
        }

        /// <summary>
        /// Calculation
        /// </summary>
        /// <param name="input">Input</param>
        /// <param name="output">Output</param>
        void IObjectTransformer.Calculate(object[] input, object[] output)
        {
            for (int i = 0; i < 3; i++)
            {
                inpos[i] = (double)input[i];
            }
            double w = (double)input[3] / (2 * sin);
            // 3D to 3D transformation
            BaseFrame.GetRelativePosition(inpos, outpos);

            // 3D to 2D transformation
            double x = Math.Atan2(outpos[0], -outpos[2]) * w;
            double y = Math.Atan2(outpos[1], -outpos[2]) * w;
            output[0] = x;
            output[1] = y;
        }

        #endregion

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get { return 0; }
        }

        IMeasurement IMeasurements.this[int number]
        {
            get { return null; }
        }

        void IMeasurements.UpdateMeasurements()
        {
        }

        bool IMeasurements.IsUpdated
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        #endregion

        #region IEventHandler Members

        void  IChildren<IEvent>.AddChild(IEvent ev)
        {
            allEvents.Add(ev);
        }

        void IChildren<IEvent>.RemoveChild(IEvent ev)
        {
            allEvents.Remove(ev);
        }

        #endregion

        #region IAnimatedObject Members

        void IAnimatedObject.InitAnimation(AnimationType animationType)
        {
            if (animationType == AnimationType.Asynchronous)
            {
                animatableChildren[0] = new AnimatableWrapper(pCamera,
                    PerspectiveCamera.TransformProperty, this, false, null);
                animatableChildren[0].OnFinish += Stop;
                update = null;
            }
            else
            {
                animatableChildren[0] = null;
                update = UpdateImage;
                SetTransform();
            }
        }

        void IAnimatedObject.InitRealtime(AnimationType animationType, double[] changeFrameTime)
        {
            this.changeFrameTime = changeFrameTime;
            if (animationType == AnimationType.Synchronous)
            {
                update = UpdateImage;
                animatableChildren[0] = null;
            }
            else
            {
                update = null;
                animatableChildren[0] = new AnimatableWrapper(pCamera,
                    PerspectiveCamera.TransformProperty, this, true, changeFrameTime);
                animatableChildren[0].OnFinish += Stop;
                update = null;
            }
        }

        AnimatableWrapper[] IAnimatedObject.Children
        {
            get { return animatableChildren; }
        }

        protected event Action change;

        event Action IAnimatedObject.Change
        {
            add { change += value; }
            remove { change -= value; }
        }

        /// <summary>
        /// Stops animation
        /// </summary>
        void IAnimatedObject.StopAnimation()
        {
            if (animatableChildren[0] != null)
            {
                animatableChildren[0].Stop();
            }
            animatableChildren[0] = null;
        }

        event Action IAnimatedObject.OnStop
        {
            add { onStop += value; }
            remove { onStop -= value; }
        }

        event Action<IMeasurement> IChildren<IMeasurement>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IMeasurement> IChildren<IMeasurement>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }

        bool IAnimatedObject.SupportsAnimationEvents
        {
            get
            {
                return suppotrsAnimation;
            }
            set
            {
                if (suppotrsAnimation == value)
                {
                    return;
                }
                if (animatableChildren[0] == null)
                {
                    return;
                }
                suppotrsAnimation = value;
                if (value)
                {
                    foreach (IEvent ev in allEvents)
                    {
                        foreach (AnimatableWrapper wrapper in animatableChildren)
                        {
                            ev.Event += wrapper.Event;
                        }
                        animationEvents.Add(ev);
                    }
                }
                else
                {
                    foreach (IEvent ev in animationEvents)
                    {
                        foreach (AnimatableWrapper wrapper in animatableChildren)
                        {
                            ev.Event -= wrapper.Event;
                        }
                    }
                    animationEvents.Clear();
                }
            }
        }

        #endregion

        #region ILinear6DForecast Members

        ReferenceFrame ILinear6DForecast.ReferenceFrame
        {
            get { return this.GetFrame(); }
        }

        TimeSpan ILinear6DForecast.ForecastTime
        {
            get { return forecastTime; }
            set { forecastTime = value; }
        }

        double ILinear6DForecast.CoordinateError
        {
            get { return coordinateError; }
            set { coordinateError = value; }
        }

        double ILinear6DForecast.AngleError
        {
            get { return angleError; }
            set { angleError = value; }
        }

        #endregion

        #region Overriden

        /// <summary>
        /// Sets a calculation reason
        /// </summary>
        protected override void SetCalculationReason()
        {
            if (calculationReason == StaticExtensionEventInterfaces.Realtime)
            {
                update = UpdateImage;
            }
        }



        public override void UpdateImage()
        {
            if (!show)
            {
                return;
            }
            if (control == null)
            {
                return;
            }
            Action a = UpdateAction;
            control.Dispatcher.Invoke(a);//, System.Windows.Threading.DispatcherPriority.Send);
        }

        /// <summary>
        /// Dynamically adds visible
        /// </summary>
        /// <param name="position">Position of visible to add</param>
        public override void DynamicalAdd(SerializablePosition position)
        {
            if (!show)
            {
                return;
            }
            AddVisible(position);
            IWpfVisible v = position.Parameters as IWpfVisible;
            Action act = () =>
            {
                Visual3D vis = v.GetVisual(this);
                if (vis != null)
                {
                    viewport.Children.Add(vis);
                }
                dict[position] = vis;
            };
            control.Dispatcher.Invoke(act);
        }

        /// <summary>
        /// Dynamically removes visible
        /// </summary>
        /// <param name="position">Position of visible to add</param>
        public override void DynamicalRemove(SerializablePosition position)
        {
            RemoveVisible(position);
            IWpfVisible v = position.Parameters as IWpfVisible;
            Action act = () =>
            {
                Visual3D vis = v.GetVisual(this);
                if (vis != null)
                {
                    viewport.Children.Remove(vis);
                }
                dict.Remove(position);
            };
            control.Dispatcher.Invoke(act);
        }

        #endregion

        #region Public Members



        public override double FarPlaneDistance
        {
            get
            {
                return far;
            }
            set
            {
                far = value;
                pCamera.FarPlaneDistance = value;
            }
        }

        public string CameraBackground
        {
            get
            {
                return backgound;
            }
            set
            {
                backgound = value;
            }
        }

        public void Set(UserControl control, object parentControl, Action<object, Action> update)
        {
            CreateAll();
            this.control = control;
            control.Content = viewport;
            this.parentControl = parentControl;
            updateImage = update;
        }

        public override double FieldOfView
        {
            get
            {
                return fieldOfView;
            }
            set
            {
                fieldOfView = value;
                pCamera.FieldOfView = value;
                sin = Math.Sin(Math.PI * fieldOfView / 360.0);
            }
        }

        public override double NearPlaneDistance
        {
            get
            {
                return near;
            }
            set
            {
                near = value;
                pCamera.NearPlaneDistance = value;
            }
        }


        #endregion

        #region Internal Members

        internal UserControl Control
        {
            get
            {
                if (show)
                {
                    return control;
                }
                return null;
            }

        }

        IEnumerable<IMeasurement> IChildren<IMeasurement>.Children =>[];

        internal void Init()
        {
            int count = Count;
            FieldOfView = fieldOfView;
            viewport.Children.Clear();
            dict.Clear();
            for (int i = 0; i < count; i++)
            {
                SerializablePosition p = this[i] as SerializablePosition;
                IWpfVisible v = p.Parameters as IWpfVisible;
                Visual3D vis = v.GetVisual(this);
                if (vis != null)
                {
                    dict[p] = vis;
                    viewport.Children.Add(vis);
                }
            }
        }


        #endregion

        #region Private Members

        private void Stop()
        {
            onStop();
        }

        void Set()
        {
            int count = Count;
            cameraPositon.SetTransform(pCamera.Transform as MatrixTransform3D);
            for (int i = 0; i < count; i++)
            {
                IPosition p = this[i];
                Visual3D vis = dict[p];
                if (vis != null)
                {
                    p.SetTransform(vis.Transform as MatrixTransform3D);
                }
            }
        }


        void SetTransform()
        {
            int count = Count;
            pCamera.Transform = StaticExtensionWpfLoader.StandardTransform;
            cameraPositon.SetTransform(pCamera.Transform as MatrixTransform3D);
            for (int i = 0; i < count; i++)
            {
                IPosition p = this[i];
                Visual3D vis = dict[p];
                if (vis != null)
                {
                    vis.SetStandardTransform();
                }
            }


        }

        private void UpdateAction()
        {
            Set();
        }

        void CreateAll()
        {
            viewport = new Viewport3D();
            viewport.Name = "Viewport";
            viewport.Camera = pCamera;
            pCamera.LookDirection = new System.Windows.Media.Media3D.Vector3D(0, 0, -1);
            pCamera.UpDirection = new System.Windows.Media.Media3D.Vector3D(0, 1, 0);
            pCamera.NearPlaneDistance = near;
            pCamera.FarPlaneDistance = far;
            pCamera.Transform = new MatrixTransform3D();
            Init();
        }

        void IChildren<IMeasurement>.AddChild(IMeasurement child)
        {
            throw new ErrorHandler.OwnException();

        }

        void IChildren<IMeasurement>.RemoveChild(IMeasurement child)
        {
        }

        #endregion

    }
}

