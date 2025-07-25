﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Windows.Media.Media3D;

using BaseTypes;

using CategoryTheory;

using Diagram.UI.Interfaces;

using SerializationInterface;

using Motion6D;
using Motion6D.Interfaces;

using Event.Interfaces;

using Animation.Interfaces.Enums;

using WpfInterface.Interfaces;
using WpfInterface.Animated;
using Motion6D.Portable.Interfaces;
using Wpf.Loader;
using System.Windows.Markup;
using ErrorHandler;
using NamedTree;

namespace WpfInterface.Objects3D
{
    [Serializable()]
    public class WpfShape : XamlWrapper, ICategoryObject, ISerializable, IChildren<IAssociatedObject>, IWpfVisible, IFacet,
        ICameraConsumer, IPositionObject, IEventHandler, 
        IAnimatedObject, IAllowCodeCreation, IPostDeserialize
    {

        #region Fields

        CategoryTheory.Performer performer = new();


        object obj;

        AnimatableWrapper[] animatableChildren = new AnimatableWrapper[0];

        private Dictionary<Motion6D.Portable.Camera, Visual3D>
            visuals = new Dictionary<Motion6D.Portable.Camera, Visual3D>();

   
        protected IAssociatedObject[] ch;


        protected FieldConsumer3D consumer;

  
        protected bool allowCodeCreation = false;


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

        List<IEvent> allEvents = new List<IEvent>();

        List<IEvent> animationEvents = new List<IEvent>();

        bool suppotrsAnimation = false;


        #endregion

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public WpfShape()
        {
            CreateFieldConsumer();
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        private WpfShape(SerializationInfo info, StreamingContext context)
        {
            try
            {
                LoadTextures(info);
            }
            catch (Exception e)
            {
                e.HandleException(10);
            }
            try
            {
                XamlProtected = info.GetString("Xaml");
                isColored = info.GetBoolean("IsColored");
                consumer = info.Deserialize<FieldConsumer3D>("FieldConsumer");
                ch = new IAssociatedObject[] { consumer };
                try
                {
                    scaled = info.GetBoolean("Scaled");
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
                try
                {
                    Attachment = info.GetValue("Attachment", typeof(Dictionary<string, byte[]>))
                        as Dictionary<string, byte[]>;
                }
                catch
                {

                }
                try
                {


                    var f = info.GetValue("LightColor", typeof(float[])) as float[];
                    LightColor = System.Windows.Media.Color.FromScRgb(f[0], f[1], f[2], f[3]);
                    HasLight = info.GetBoolean("HasLight");
                }
                catch
                {

                }
            }
            catch (Exception)
            {
                CreateFieldConsumer();
            }
        }

        #endregion

        #region IAllowCodeCreation Members

        bool IAllowCodeCreation.AllowCodeCreation => allowCodeCreation;

        #endregion

        #region ISerializable Members

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Xaml", XamlProtected);
            info.AddValue("IsColored", isColored);
            info.Serialize<FieldConsumer3D>("FieldConsumer", consumer);
            info.AddValue("Scaled", scaled);
            SaveTextures(info);
            info.AddValue("ForecastTime", forecastTime, typeof(TimeSpan));
            info.AddValue("CoordinateError", coordinateError);
            info.AddValue("AngleError", angleError);
            info.AddValue("Attachment", Attachment, typeof(Dictionary<string, byte[]>));
            var c = LightColor;
            float[] f = [c.ScA, c.ScR, c.ScG, c.ScB];
            info.AddValue("LightColor", f, typeof(float[]));
            info.AddValue("HasLight", HasLight);

        }

        #endregion

        #region IChildrenObject Members

        

        #endregion

        #region IAssociatedObject Members

        object IAssociatedObject.Object { get => obj; set => obj = value; }


        #endregion

        #region IWpfVisible Members

        public virtual Visual3D GetVisual(Motion6D.Portable.Camera camera)
        {
            Visual3D v3d = Visual;
            visuals[camera] = v3d;
            if (!scaled)
            {
                var s = XamlWriter.Save(v3d);
                SetLight(v3d);
                var s1 = XamlWriter.Save(v3d);
                return v3d;
            }
            double sc = camera.Scale;
            if (sc == 1)
            {
                SetLight(v3d);
                return v3d;
            }
            v3d.Multiply(sc);
            SetLight(v3d);
            return v3d;
        }

        #endregion

        #region IVisible Members

        /// <summary>
        /// SSSSize
        /// </summary>
        double[,] IVisible.Size => Size;


        #endregion

        #region IFacet Members

        int IFacet.Count
        {
            get
            {
                return facetCount;
            }
        }

        int IFacet.ParametersCount
        {
            get
            {
                if (types == null)
                {
                    return 0;
                }
                return types.Length;
            }
        }

        object IFacet.GetType(int n)
        {
            return types[n];
        }

        object IFacet.this[int facet, int parameter]
        {
            get { return parameters[parameter][facet]; }
        }

        double[] IFacet.this[int n]
        {
            get { return centers[n]; }
        }

        void IFacet.SetColor(int n, double alpha, double red, double green, double blue)
        {
            colors[n] = StaticExtensionWpfLoader.GetColor(alpha, red, green, blue);
        }

        string IFacet.Id
        {
            get
            {
                return "";
            }
            set
            {
                if (System.IO.File.Exists(value))
                {
                    Load(value);
                }
            }
        }

        double IFacet.GetArea(int n)
        {
            return areas[n];
        }

        double[] IFacet.GetNormal(int n)
        {
            return normals[n];
        }


        bool IFacet.IsColored
        {
            get
            {
                return isColored;
            }
            set
            {
                if (isColored == value)
                {
                    return;
                }
                isColored = value;
            }
        }

        #endregion

        #region ICameraConsumer Members

        void ICameraConsumer.Add(Motion6D.Portable.Camera camera)
        {
            GetVisual(camera);
        }

        void ICameraConsumer.Remove(Motion6D.Portable.Camera camera)
        {
            visuals.Remove(camera);
        }

        #endregion

        #region IPositionObject Members

        IPosition IPositionObject.Position
        {
            get
            {
                IPositionObject po = consumer;
                return po.Position;
            }
            set
            {
                IPositionObject po = consumer;
                po.Position = value;
            }
        }

        #endregion

        #region IEventHandler Members

        void IChildren<IEvent>.AddChild(IEvent ev)
        {
            allEvents.Add(ev);
        }

        void  IChildren<IEvent>.RemoveChild(IEvent ev)
        {
            allEvents.Remove(ev);
        }

        IEnumerable<IEvent> IChildren<IEvent>.Children
        {
            get
            {
                foreach (IEvent ev in allEvents)
                {
                    yield return ev;
                }
            }
        }

  
        #endregion

        #region IAnimatedObject Members

        void IAnimatedObject.InitAnimation(AnimationType animationType)
        {
            if (animationType == AnimationType.Asynchronous)
            {
                List<AnimatableWrapper> l = new List<AnimatableWrapper>();
                foreach (Visual3D visual in visuals.Values)
                {
                    AnimatableWrapper aw = new AnimatableWrapper(visual, 
                        Visual3D.TransformProperty, this, false, null);
                    aw.OnFinish += AniCount;
                    l.Add(aw);
                }
                animatableChildren = l.ToArray();
                aniCount = l.Count;
            }
            else
            {
                animatableChildren = new AnimatableWrapper[0];
            }
        }

        void IAnimatedObject.InitRealtime(AnimationType animationType, double[] changeFrameTime)
        {
            if (animationType == AnimationType.Asynchronous)
            {
                List<AnimatableWrapper> l = new List<AnimatableWrapper>();
                foreach (Visual3D visual in visuals.Values)
                {
                    AnimatableWrapper aw =
                        new AnimatableWrapper(visual, Visual3D.TransformProperty, this, true, changeFrameTime);
                    aw.OnFinish += AniCount;
                    l.Add(aw);
                }
                animatableChildren = l.ToArray();
                aniCount = l.Count;
            }
            else
            {
                animatableChildren = new AnimatableWrapper[0];
            }

        }

        AnimatableWrapper[] IAnimatedObject.Children
        {
            get { return animatableChildren; }
        }

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
            foreach (AnimatableWrapper aw in animatableChildren)
            {
                aw.Stop();
            }
            animatableChildren = new AnimatableWrapper[0];
        }

        event Action IAnimatedObject.OnStop
        {
            add { onStop += value; }
            remove { onStop -= value; }
        }

        event Action<IAssociatedObject> IChildren<IAssociatedObject>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IAssociatedObject> IChildren<IAssociatedObject>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IEvent> IChildren<IEvent>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IEvent> IChildren<IEvent>.OnRemove
        {
            add
            {
                throw new WriteProhibitedException();
            }

            remove
            {
                throw new WriteProhibitedException();
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

        #region IPostDeserialize Members

        void IPostDeserialize.PostDeserialize()
        {
            Post();
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

        #region Specific Members

        #region Public Members
        /// <summary>
        /// Color of light
        /// </summary>
        public System.Windows.Media.Color LightColor
        {
            get;
            set;
        } = System.Windows.Media.Color.FromScRgb(1, 1, 1, 1);

        /// <summary>
        /// The "has light" sign
        /// </summary>
        public bool HasLight
        {

            get;
            set;
        } = false;



        /// <summary>
        /// The is scaled sign
        /// </summary>
        public bool IsScaled
        {
            get
            {
                return scaled;
            }
            set
            {
                scaled = value;
            }
        }

        public IEnumerable<string> TextureKeys
        {
            get
            {
                return Textures.Keys;
            }
        }

  


        #endregion

        #region Protected Members

        /// <summary>
        /// Loads textures
        /// </summary>
        /// <param name="info">Serialization info</param>
        protected virtual void LoadTextures(SerializationInfo info)
        {
            Textures = info.Deserialize<Dictionary<string, byte[]>>("Textures");
            try
            {
     //           TexturesMap = info.Deserialize<Dictionary<string, string>>("TexturesMap");
            }
            catch
            {

            }
        }

        /// <summary>
        /// Saves textures
        /// </summary>
        /// <param name="info">Serialization info</param>
        protected virtual void SaveTextures(SerializationInfo info)
        {
            info.Serialize<Dictionary<string, byte[]>>("Textures", Textures);
        }

        /// <summary>
        /// Post operation
        /// </summary>
        protected virtual void Post()
        {
            Xaml = XamlProtected;
        }

        /// <summary>
        /// Creates facets
        /// </summary>
        protected override void CreateFacets()
        {
            if (facetCount > 0)
            {
                return;
            }
            Visual3D v3d = Visual;
            if (mesh == null)
            {
                return;
            }
            mesh.Create(out areas, out centers);
            Vector3DCollection coll = mesh.Normals;
            facetCount = coll.Count;
            colors = new Color[facetCount];
            int n = coll.Count;
            normals = new double[n][];
            for (int i = 0; i < n; i++)
            {
                System.Windows.Media.Media3D.Vector3D v = coll[i];
                double[] x = new double[] { v.X, v.Y, v.Z };
                normals[i] = x;
            }
            if (bp == null)
            {
                return;
            }
            List<object> tt = new List<object>();
            List<List<object>> par = new List<List<object>>();
            System.Windows.Media.Int32Collection ic = bp.DoubleIndex;
            System.Windows.Media.DoubleCollection dc = bp.DoubleParameters;
            Double a = 0;
            int kk = 0;
            foreach (int i in ic)
            {
                tt.Add(new ArrayReturnType(a, new int[] { i }, false));
                List<object> pp = new List<object>();
                par.Add(pp);
                for (int j = 0; j < facetCount; j++)
                {
                    double[] x = new double[i];
                    pp.Add(x);
                    for (int k = 0; k < i; k++)
                    {
                        x[k] = dc[kk];
                        ++kk;
                    }
                }

            }
            types = tt.ToArray();
            parameters = new object[par.Count][];
            for (int i = 0; i < par.Count; i++)
            {
                parameters[i] = par[i].ToArray();
            }
        }



        /// <summary>
        /// Creates field consumer
        /// </summary>
        protected void CreateFieldConsumer()
        {
            if (consumer == null)
            {
                consumer = new Motion6D.FieldConsumer3D(this);
                ch = new IAssociatedObject[] { consumer };
            }
        }


        #endregion

        #region Private Members

        private void AniCount()
        {
            --aniCount;
            if (aniCount == 0)
            {
                onStop();
            }
        }

        protected override void Fill()
        {
            PhysicalField.Interfaces.IFieldConsumer fc = consumer;
            fc.Consume();
            Bitmap bmp = Texture;
            Graphics g = Graphics.FromImage(bmp);
            if (colors == null)
            {
                return;
            }
            for (int i = 0; i < colors.Length; i++)
            {
                Color c = colors[i];
                if (c != null)
                {
                    Brush br = new SolidBrush(c);
                    g.FillRectangle(br, i * side, 0, side, side);
                }

            }
        }

        /// <summary>
        /// Image brush
        /// </summary>
        protected override System.Windows.Media.ImageBrush ImageBrush
        {
            get
            {
                Fill();
                string fn = null;
                GenerateFileName(".bmp", out fn);
                texture.Save(fn, System.Drawing.Imaging.ImageFormat.Bmp);
                System.Windows.Media.Imaging.BitmapImage bi = new System.Windows.Media.Imaging.BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(fn);
                bi.EndInit();
                System.Windows.Media.ImageBrush brush
                     = new System.Windows.Media.ImageBrush(bi);
                brush.Stretch = System.Windows.Media.Stretch.UniformToFill;
                brush.TileMode = System.Windows.Media.TileMode.Tile;
                brush.ViewboxUnits = System.Windows.Media.BrushMappingMode.RelativeToBoundingBox;
                brush.Viewport = new System.Windows.Rect(0, 0, (double)(facetCount * side), (double)side);
                brush.Opacity = 1;
                return brush;
            }
        }

        string INamed.Name { get => performer.GetAssociatedName(this); set => throw new WriteProhibitedException(); }

        IEnumerable<IAssociatedObject> IChildren<IAssociatedObject>.Children => ch;

       



        #endregion

        private void SetLight(Visual3D v3d)
        {
            if (!HasLight)
            {
                return;
            }
            if (v3d is ModelVisual3D m3d)
            {
                foreach (var child in m3d.Children)
                {
                    if (child == v3d)
                    {
                        continue;
                    }
                    if (child is Visual3D v)
                    {
                        SetLight(v);
                    }
                }
                ModelVisual3D m = new ModelVisual3D();
                AmbientLight l = new AmbientLight(LightColor);
                m.Content = l;
                m3d.Children.Insert(0, m);
            }
        }

        void IChildren<IAssociatedObject>.AddChild(IAssociatedObject child)
        {
        }

        void IChildren<IAssociatedObject>.RemoveChild(IAssociatedObject child)
        {
        }

 
        #endregion


    }
}
