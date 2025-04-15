using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Xml;

using Abstract3DConverters;
using Abstract3DConverters.Interfaces;
using ErrorHandler;


namespace Wpf.Loader
{
    public class XamlWrapper
    {

        protected Paths.Service.Service service = new();

        protected Service s = new();

        protected double[][] normals;

        protected IImageConverter imageConverter = ".xaml".GetImageConverter();


        protected object[] types = null;

        protected object[][] parameters;

        protected double[][] centers;

        protected double[,] Size
        {
            get;
            set;
        }

        protected System.Drawing.Color[] colors = null;


        protected string XamlProtected
        {
            get;
            set;
        }

        public Dictionary<string, byte[]> Attachment
        {
            get; protected set;
        }

        protected Dictionary<string, string> Urls
        {
            get;
        } = new();

        /// <summary>
        /// Textures
        /// </summary>
        public virtual Dictionary<string, byte[]> Textures
        {
            get;
            set;
        } = new Dictionary<string, byte[]>();

  
        public void Save(string filename)
        {
            using (var w = new StreamWriter(filename))
            {
                w.Write(Xaml);
            }
            var path = Path.GetDirectoryName(filename);
            SaveTextures(path);
        }



        public void  Load(string file)
        {
            string dir = Path.GetDirectoryName(file);
            var ext = Path.GetExtension(file).ToLower();
            if (!StaticExtensionWpfLoader.FileLoad.ContainsKey(ext))
            {
                return;
            }
            var func = StaticExtensionWpfLoader.FileLoad[ext];
            var t = func(file);
            SetFile(t.Item1, t.Item2, dir);
        }

        internal void SetFile(object xaml, Dictionary<string, byte[]> attach, string dir)
        {
            var doc = new XmlDocument();
            if (xaml is string s)
            {
                XamlProtected = s;
                doc.LoadXml(s);
            }
            if (xaml is XmlDocument dc)
            {
                doc = dc;
                var stream = new StringWriter();
                using var w = XmlWriter.Create(stream, new XmlWriterSettings
                {
                    //         NewLineChars = "\n",
                    OmitXmlDeclaration = true,


                });
                dc.WriteContentTo(w);
                stream.Flush();
                var stt = stream.ToString();
                XamlProtected = stt;
                var sb = new StringBuilder(stt);
                TextReader sr = new StringReader(stt);
                using var reader = XmlReader.Create(sr);
                var ddd = new XmlDocument();
                ddd.Load(reader);
            }
            Attachment = attach;
            Textures.Clear();
            string d = dir;
            var ds = d.Replace(Path.DirectorySeparatorChar, '/');
            if (d[d.Length - 1] != Path.DirectorySeparatorChar)
            {
                d += Path.DirectorySeparatorChar;
            }
            XmlNodeList nl = doc.GetElementsByTagName("ImageBrush");
            foreach (XmlElement e in nl)
            {
                string iso = e.GetAttribute("ImageSource");
                string fn = iso;
                fn = fn.Replace('/', Path.DirectorySeparatorChar);
                if (File.Exists(fn))
                {
                    fn = Path.Combine(ds, iso);
                    var iss = ReadImage(fn, dir, e);
                   
                    /*      using (var stream = System.IO.File.OpenRead(fn))
                          {
                              byte[] b = new byte[stream.Length];
                              stream.Read(b);
                              if (iso.Contains(dir))
                              {
                                  textures[iso.Substring(dir.Length + 1)] = b;
                              }
                              else
                              {
                                  textures[iso] = b;
                              }
                          }*/
                }
            }
            XamlProtected = doc.OuterXml;
        }

        string ReadImage(string iso, string dir, XmlElement element)
        {
            if (imageConverter != null)
            {
                var t = imageConverter.Convert(iso);
                if (t != null)
                {
                    var isss = Path.Combine(dir, Path.GetFileNameWithoutExtension(iso))
                        + Path.GetExtension(t.Item1);
                    var bt = t.Item2;
                    if (isss.Contains(dir))
                    {
                        isss = isss.Substring(dir.Length + 1);
                    }
                    else
                    {
                    }
                    Textures[isss] = bt;
                    element.SetAttribute("ImageSource", isss);
                    return isss;
                }
            }
            using var stream = File.OpenRead(iso);
            byte[] b = new byte[stream.Length];
            stream.ReadExactly(b);
            var iss = "";
            if (iso.Contains(dir))
            {
                iss = iso.Substring(dir.Length + 1);
            }
            else
            {
                iss = iso;
            }
            Textures[iss] = b;
            element.SetAttribute("ImageSource", iss);
            return iss;
        }

        /// <summary>
        /// Creates facets
        /// </summary>
        protected virtual void CreateFacets()
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
            colors = new System.Drawing.Color[facetCount];
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
        /// Xaml
        /// </summary>
        public virtual string Xaml
        {
            get
            {
                return XamlProtected;
            }
            set
            {
                XamlProtected = value;
                facetCount = -1;
                texture = null;
                CreateFacets();
                var visual = Visual;
                double[,] p = null;
                if (Size == null)
                {
                   p  = visual.GetSize();
                }
                if (!s.IsZero(p))
                {
                    Size = p;
                    return;
                }
                var doc = new XmlDocument();
                doc.LoadXml(value);
                var e = doc.GetElementsByTagName("MeshGeometry3D");
                foreach (XmlElement item in e)
                {
                    var ps = item.GetAttribute("Positions");
                    var d = s.Get3DSize(ps);
                    p = s.Get3DSize(p, d);
                }
                Size = p;
            }
        }

  
        /// <summary>
        /// Saves textures 
        /// </summary>
        /// <param name="directory">The directory</param>
        public void SaveTextures(string directory)
        {
            foreach (var key in Textures.Keys)
            {
                var b = Textures[key];
                var f = key.Replace('/', Path.DirectorySeparatorChar);
                if (f[0]  == Path.DirectorySeparatorChar)
                {
                    f = f.Substring(1);
                }
                var file = Path.Combine(directory, f);
                if (!file.Contains(directory))
                {
                    continue;
                }
                var ff = f.Replace('/', Path.DirectorySeparatorChar);
                ff = Path.Combine(directory, ff);
                var dd = Path.GetDirectoryName(ff);
                var di = new DirectoryInfo(dd);
                if (!di.Exists)
                {
                    di.Create();
                }
                using (var stream = File.OpenWrite(ff))
                {
                    stream.Write(b);
                }
            }
        }
        protected BoundaryParameters bp;

        protected Dictionary<string, string> Paths
        {
            get;
        }  = new Dictionary<string, string>();

        protected System.Drawing.Bitmap texture;

        protected void CreateSize()
        {
            Size = Visual.GetSize();
        }
        

        protected bool scaled = false;

        protected Action change = () => { };

        protected Action onStop = () => { };

        protected int aniCount;



        protected int facetCount = -1;

        public const int side = 5;

        protected MeshGeometry3D mesh;


        protected bool isColored = false;

        protected double[] areas;


        protected System.Drawing.Bitmap Texture
        {
            get
            {
                if (texture == null)
                {
                    texture = new System.Drawing.Bitmap(side * facetCount, side);
                }
                return texture;
            }
        }




        /// <summary>
        /// Process Xaml
        /// </summary>
        /// <param name="str">Xaml string</param>
        /// <returns>Processed Xaml</returns>
        protected string ProcessXaml(string str)
        {
            string st = str + "";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(st);
            XmlNodeList nl = doc.GetElementsByTagName("ImageBrush");
            var del = new List<XmlElement>();
            foreach (XmlElement e in nl)
            {
                string iso = e.GetAttribute("ImageSource");
                if (iso != null)
                {
                    if (iso.Length > 0)
                    {
                        if (!Textures.ContainsKey(iso))
                        {
                            var isi = service.FindEnd(iso, Textures.Keys);
                            if (isi == null)
                            {
                                del.Add(e);
                                continue;
                            }
                        }
                        if (Textures.ContainsKey(iso))
                        {
                            if (Urls.ContainsKey(iso))
                            {
                                throw new OwnException("Urls");
                                e.SetAttribute("ImageSource", Urls[iso]);
                                continue;
                            }
                            int n = iso.LastIndexOf('.');
                            string ext = iso.Substring(n);
                            string path = null;
                            if (Paths.ContainsKey(iso))
                            {
                                path = Paths[iso];
                                if (!File.Exists(path))
                                {
                                    using (var stream = File.OpenWrite(path))
                                    {
                                        byte[] b = Textures[iso];
                                        stream.Write(b, 0, b.Length);
                                    }
                                }
                            }
                            else
                            {
                                string fn = GenerateFileName(ext, out path);
                                using (var stream = File.OpenWrite(path))
                                {
                                    byte[] b = Textures[iso];
                                    stream.Write(b, 0, b.Length);
                                }
                            }
                            var k = st.Length;
                            path = s.TransformPathToPlatfom(path);
                            e.SetAttribute("ImageSource", path);
                            Paths[iso] = path;
                        }
                        else
                        {
                            string path = AppDomain.CurrentDomain.BaseDirectory + iso;
                            path = s.TransformPathToPlatfom(path);
                            e.SetAttribute("ImageSource", path);
                            Paths[iso] = path;
                            if (File.Exists(path))
                            {
                                ReadImage(iso, Path.GetDirectoryName(path), e);
                        /*        using (var stream = System.IO.File.OpenRead(path))
                                {
                                    byte[] b = new byte[stream.Length];
                                    stream.Read(b, 0, b.Length);
                                    Textures[iso] = b;
                                }*/
                            }

                        }
                    }
                }
            }
            foreach (var e in del)
            {
                var p = e.ParentNode as XmlElement;
                p.RemoveChild(e);
            }
            var l = new List<string>(Textures.Keys);
            foreach (string key in l)
            {
                if (!Paths.ContainsKey(key))
                {
                    Textures.Remove(key);
                }
            }
            del.Clear();
            foreach (XmlElement n in doc.GetElementsByTagName("ImageBrush"))
            {
                var so = n.GetAttribute("ImageSource");
                if (!File.Exists(so))
                {
                    del.Add(n.ParentNode as XmlElement);
                }
            }
            foreach (var d in del)
            {
                XmlElement ec = d.ParentNode as XmlElement;
                ec.RemoveChild(d);
            }
            var ret = doc.OuterXml;
            ret = ret.Replace("Name=\"", "x:Name=\"");
            ret = ret.Replace("Key=\"", "x:Key=\"");
            return ret;
        }


        protected virtual void Fill()
        {
            System.Drawing.Bitmap bmp = Texture;
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);
            if (colors == null)
            {
                return;
            }
            for (int i = 0; i < colors.Length; i++)
            {
                System.Drawing.Color c = colors[i];
                if (c != null)
                {
                    System.Drawing.Brush br = new System.Drawing.SolidBrush(c);
                    g.FillRectangle(br, i * side, 0, side, side);
                }

            }
        }

        /// <summary>
        /// Generates name of file
        /// </summary>
        /// <param name="ext">Extension</param>
        /// <param name="path">Path</param>
        /// <returns>File name</returns>
        protected virtual string GenerateFileName(string ext, out string path)
        {
            return StaticExtensionWpfLoader.GenerateFileName(ext, out path);
        }


        protected virtual System.Windows.Media.ImageBrush ImageBrush
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




        /// <summary>
        /// Visual object
        /// </summary>
        public virtual Visual3D Visual
        {
            get
            {
                bp = null;
                Visual3D v3d;
                string s = ProcessXaml(XamlProtected);
                var doc = new XmlDocument();
                doc.LoadXml(s);
                object ob = null;
                try
                {
                  ob = System.Windows.Markup.XamlReader.Parse(s);
                }
                catch (Exception ex)
                {
                    ex.HandleExceptionDouble("Xaml Wrapper Parse");
                }
                ModelVisual3D model = null;
                if (ob is Visual3D)
                {
                    v3d = ob as Visual3D;
                    StaticExtensionWpfLoader.SetStandardTransform(v3d);
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
                    StaticExtensionWpfLoader.SetStandardTransform(model);
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

    }
}
