using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Media.Media3D;

using BaseTypes;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;

using SerializationInterface;

using Motion6D;
using Motion6D.Interfaces;

using Event.Interfaces;

using Animation.Interfaces.Enums;

using WpfInterface.Interfaces;
using WpfInterface.Wpf;
using WpfInterface.Animated;
using Motion6D.Portable.Interfaces;

namespace WpfInterface.Objects3D
{
    [Serializable()]
    public class WpfShape : CategoryObject, ISerializable, IChildrenObject, IWpfVisible, IFacet,
        ICameraConsumer, IPositionObject, IEventHandler, 
        IAnimatedObject, IAllowCodeCreation
    {

        #region Fields

        protected string xaml;

        protected int facetCount = -1;

        const int side = 5;

        MeshGeometry3D mesh;

        AnimatableWrapper[] animatableChildren = new AnimatableWrapper[0];

        protected bool isColored = false;

        private double[] areas;

        private Dictionary<Motion6D.Portable.Camera, Visual3D>
            visuals = new Dictionary<Motion6D.Portable.Camera, Visual3D>();

        private double[][] normals;

        private BoundaryParameters bp;

        protected Dictionary<string, string> paths = new Dictionary<string, string>();

        private object[] types = null;

        private object[][] parameters;

        private double[][] centers;

        Color[] colors = null;

        protected IAssociatedObject[] ch;

        Bitmap texture;

        protected FieldConsumer3D consumer;

        public const string deleteTexture = "delete_texture_file_";

        protected Dictionary<string, string> urls = new Dictionary<string, string>();

        protected bool scaled = false;

        Action change = () => { };

        Action onStop = () => { };

        int aniCount;

        protected bool allowCodeCreation = false;

        /// <summary>
        /// Textures
        /// </summary>
        protected Dictionary<string, byte[]> textures = new Dictionary<string, byte[]>();

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
                e.ShowError(10);
            }
            try
            {
                Xaml = info.GetString("Xaml");
                isColored = info.GetBoolean("IsColored");
                consumer = info.Deserialize<Motion6D.FieldConsumer3D>("FieldConsumer");
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
            info.AddValue("Xaml", xaml);
            info.AddValue("IsColored", isColored);
            info.Serialize<Motion6D.FieldConsumer3D>("FieldConsumer", consumer);
            info.AddValue("Scaled", scaled);
            SaveTextures(info);
            info.AddValue("ForecastTime", forecastTime, typeof(TimeSpan));
            info.AddValue("CoordinateError", coordinateError);
            info.AddValue("AngleError", angleError);
        }

        #endregion

        #region IChildrenObject Members

        IAssociatedObject[] IChildrenObject.Children
        {
            get { return ch; }
        }

        #endregion

        #region IWpfVisible Members

        public virtual Visual3D GetVisual(Motion6D.Portable.Camera camera)
        {
            Visual3D v3d = Visual;
            visuals[camera] = v3d;
            if (!scaled)
            {
                return v3d;
            }
            double sc = camera.Scale;
            if (sc == 1)
            {
                return v3d;
            }
            v3d.Multiply(sc);
            return v3d;
        }

        /// <summary>
        /// Textures
        /// </summary>
        public virtual Dictionary<string, byte[]> Textures
        {
            get
            {
                return textures;
            }
        }

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
            colors[n] = StaticExtensionWpfInterface.GetColor(alpha, red, green, blue);
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

        void IEventHandler.Add(IEvent ev)
        {
            allEvents.Add(ev);
        }

        void IEventHandler.Remove(IEvent ev)
        {
            allEvents.Remove(ev);
        }

        IEnumerable<IEvent> IEventHandler.Events
        {
            get
            {
                foreach (IEvent ev in allEvents)
                {
                    yield return ev;
                }
            }
        }

        event Action<IEvent> IEventHandler.OnAdd
        {
            add { }
            remove { }
        }

        event Action<IEvent> IEventHandler.OnRemove
        {
            add { }
            remove { }
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
                return textures.Keys;
            }
        }

        public void Load(string filename)
        {
            string dir = Path.GetDirectoryName(filename);
            Visual3D v = filename.ToVisual3D();
            string xaml;
            if (v != null)
            {
                xaml = System.Windows.Markup.XamlWriter.Save(v);
            }
            else
            {
                using (TextReader reader = new StreamReader(filename))
                {
                    xaml = reader.ReadToEnd();
                }
            }
            SetFile(xaml, dir);
        }

        /// <summary>
        /// Xaml
        /// </summary>
        public string Xaml
        {
            get
            {
                return xaml;
            }
            set
            {
                xaml = value;
                facetCount = -1;
                texture = null;
                CreateFacets();
            }
        }

        /// <summary>
        /// Public access to visual
        /// </summary>
        public Visual3D PublicVisual
        {
            get
            {
                return Visual;
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
            textures = info.Deserialize<Dictionary<string, byte[]>>("Textures");
        }

        /// <summary>
        /// Saves textures
        /// </summary>
        /// <param name="info">Serialization info</param>
        protected virtual void SaveTextures(SerializationInfo info)
        {
            info.Serialize<Dictionary<string, byte[]>>("Textures", textures);
        }

        /// <summary>
        /// Creates facets
        /// </summary>
        protected void CreateFacets()
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
        /// Process Xaml
        /// </summary>
        /// <param name="str">Xaml string</param>
        /// <returns>Processed Xaml</returns>
        protected string ProcessXaml(string str)
        {
            string s = str + "";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(s);
            XmlNodeList nl = doc.GetElementsByTagName("ImageBrush");
            foreach (XmlElement e in nl)
            {
                string iso = e.GetAttribute("ImageSource");
                if (iso != null)
                {
                    if (iso.Length > 0)
                    {
                        if (textures.ContainsKey(iso))
                        {
                            if (urls.ContainsKey(iso))
                            {
                                e.SetAttribute("ImageSource", urls[iso]);
                                continue;
                            }
                            int n = iso.LastIndexOf('.');
                            string ext = iso.Substring(n);
                            string path = null;
                            if (paths.ContainsKey(iso))
                            {
                                path = paths[iso];
                                if (!File.Exists(path))
                                {
                                    using (Stream stream = File.OpenWrite(path))
                                    {
                                        byte[] b = textures[iso];
                                        stream.Write(b, 0, b.Length);
                                    }
                                }
                            }
                            else
                            {
                                string fn = GenerateFileName(ext, out path);
                                using (Stream stream = File.OpenWrite(path))
                                {
                                    byte[] b = textures[iso];
                                    stream.Write(b, 0, b.Length);
                                }
                            }
                            e.SetAttribute("ImageSource", path);
                            paths[iso] = path;
                        }
                        else
                        {
                            string path = AppDomain.CurrentDomain.BaseDirectory + iso;
                            e.SetAttribute("ImageSource", path);
                            paths[iso] = path;
                            if (File.Exists(path))
                            {
                                using (Stream stream = File.OpenRead(path))
                                {
                                    byte[] b = new byte[stream.Length];
                                    stream.Read(b, 0, b.Length);
                                    textures[iso] = b;
                                }
                            }

                        }
                    }
                }
            }
            return doc.OuterXml;
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

        /// <summary>
        /// Visual object
        /// </summary>
        protected virtual Visual3D Visual
        {
            get
            {
                bp = null;
                Visual3D v3d;
                string s = ProcessXaml(xaml);
                object ob = System.Windows.Markup.XamlReader.Parse(s);
                ModelVisual3D model = null;
                if (ob is Visual3D)
                {
                    v3d = ob as Visual3D;
                    StaticExtensionWpfInterface.SetStandardTransform(v3d);
                    if (v3d is ModelVisual3D)
                    {
                        model = v3d as ModelVisual3D;
                    }
                }
                else
                {
                    bp = ob as BoundaryParameters;
                    model = new ModelVisual3D();
                    Model3DGroup group = new Model3DGroup();
                    GeometryModel3D geom = new GeometryModel3D();
                    mesh = bp.Mesh;
                    mesh.Create(out areas, out centers);
                    geom.Geometry = bp.Mesh;
                    group.Children.Add(geom);
                    model.Content = group;
                    geom.Material = bp.Material;
                    model.Content = geom;
                    StaticExtensionWpfInterface.SetStandardTransform(model);
                    v3d = model;
                }
                if (isColored)
                {
                    if (model != null)
                    {
                        if (model.Content is GeometryModel3D)
                        {
                            GeometryModel3D gm = model.Content as GeometryModel3D;
                            MaterialGroup gr = new MaterialGroup();
                            //gr.Children.Add(gm.Material);
                            gm.Material = gr;
                            EmissiveMaterial mat = new EmissiveMaterial();
                            mat.Brush = ImageBrush;
                            gr.Children.Add(mat);
                            double h = 1.0 / ((double)facetCount);
                            mesh.TextureCoordinates.Clear();
                            for (int i = 0; i < facetCount; i++)
                            {
                                double x = i * side;
                                mesh.TextureCoordinates.Add(new System.Windows.Point(x, 0));
                                double x1 = x + side;
                                mesh.TextureCoordinates.Add(new System.Windows.Point(x1, side));
                                mesh.TextureCoordinates.Add(new System.Windows.Point(x1, 0));
                            }
                        }
                    }
                }
                return v3d;
            }
        }

        #endregion

        #region Private Members
        
        internal void SetFile(string xaml, string dir)
        {
            string d = dir;
            if (d[d.Length - 1] != Path.DirectorySeparatorChar)
            {
                d += Path.DirectorySeparatorChar;
            }
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xaml);
            XmlNodeList nl = doc.GetElementsByTagName("ImageBrush");
            foreach (XmlElement e in nl)
            {
                string iso = e.GetAttribute("ImageSource");
                if (iso.Contains('/'))
                {
                    iso = iso.Substring(iso.LastIndexOf('/') + 1);
                    e.SetAttribute("ImageSource", iso);
                }
                string fn = d + iso;
                if (!File.Exists(fn))
                {
                    continue;
                }
                Stream stream = File.OpenRead(fn);
                byte[] b = new byte[stream.Length];
                stream.Read(b, 0, b.Length);
                textures[iso] = b;
            }
            Xaml = doc.OuterXml;
        }

        private Bitmap Texture
        {
            get
            {
                if (texture == null)
                {
                    texture = new Bitmap(side * facetCount, side);
                }
                return texture;
            }
        }

        private void AniCount()
        {
            --aniCount;
            if (aniCount == 0)
            {
                onStop();
            }
        }

        private void Fill()
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

        private string GenerateFileName(string ext, out string path)
        {
            string ss = Guid.NewGuid() + "";
            ss = ss.Replace('-', '_');
            ss = deleteTexture + ss + ext;
            string fn = AppDomain.CurrentDomain.BaseDirectory;
            if (fn[fn.Length - 1] != Path.DirectorySeparatorChar)
            {
                fn += Path.DirectorySeparatorChar;
            }
            path = fn + ss;
            return ss;
        }

        System.Windows.Media.ImageBrush ImageBrush
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

    
 
        #endregion

        #endregion


    }
}
