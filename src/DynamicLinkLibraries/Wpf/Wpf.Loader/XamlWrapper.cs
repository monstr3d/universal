using System.Drawing;
using System.Text;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Xml;

using ErrorHandler;


namespace Wpf.Loader
{
    public class XamlWrapper
    {

        protected Paths.Service.Service service = new();

        protected double[][] normals;


        protected object[] types = null;

        protected object[][] parameters;

        protected double[][] centers;

        protected double[,] size;

        protected Color[] colors = null;

        protected string xaml;


        protected Dictionary<string, byte[]> textures = new Dictionary<string, byte[]>();

 


        public Dictionary<string, byte[]> Attachment
        {
            get; protected set;
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

        public void Save(string filename)
        {
            using (var w = new System.IO.StreamWriter(filename))
            {
                w.Write(Xaml);
            }
            var path = System.IO.Path.GetDirectoryName(filename);
            SaveTextures(path);
        }



        public void  Load(string file)
        {
            string dir = System.IO.Path.GetDirectoryName(file);
            var ext = System.IO.Path.GetExtension(file).ToLower();
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
                this.xaml = s;
                doc.LoadXml(s);
            }
            if (xaml is XmlDocument dc)
            {
                doc = dc;
                var stream = new System.IO.StringWriter();
                using var w = XmlWriter.Create(stream, new XmlWriterSettings
                {
                    //         NewLineChars = "\n",
                    OmitXmlDeclaration = true,


                });
                dc.WriteContentTo(w);
                stream.Flush();
                var stt = stream.ToString();
                this.xaml = stt;
                var sb = new StringBuilder(stt);
                System.IO.TextReader sr = new System.IO.StringReader(stt);
                using var reader = XmlReader.Create(sr);
                var ddd = new XmlDocument();
                ddd.Load(reader);
             }
            Attachment = attach;
            textures.Clear();
            string d = dir;
            var ds = d.Replace(System.IO.Path.DirectorySeparatorChar, '/');
            if (d[d.Length - 1] != System.IO.Path.DirectorySeparatorChar)
            {
                d += System.IO.Path.DirectorySeparatorChar;
            }
            XmlNodeList nl = doc.GetElementsByTagName("ImageBrush");
            foreach (XmlElement e in nl)
            {
                string iso = e.GetAttribute("ImageSource");
                string fn = ds + iso;
                fn = fn.Replace('/', System.IO.Path.DirectorySeparatorChar);
                if (!System.IO.File.Exists(fn))
                {
                    fn = System.IO.Path.Combine(ds, iso);
                    if (!System.IO.File.Exists(fn))
                    {
                        continue;
                    }
                }
                using (var stream = System.IO.File.OpenRead(fn))
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
                }
            }
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
                return xaml;
            }
            set
            {
                xaml = value;
                facetCount = -1;
                texture = null;
                CreateFacets();
                if (size == null)
                {
                    size = Visual.GetSize();
                }
            }
        }

  
        /// <summary>
        /// Saves textures 
        /// </summary>
        /// <param name="directory">The directory</param>
        public void SaveTextures(string directory)
        {
            foreach (var key in textures.Keys)
            {
                var b = textures[key];
                var f = key.Replace('/', System.IO.Path.DirectorySeparatorChar);
                if (f[0]  == System.IO.Path.DirectorySeparatorChar)
                {
                    f = f.Substring(1);
                }
                var file = System.IO.Path.Combine(directory, f);
                if (!file.Contains(directory))
                {
                    continue;
                }
                var ff = f.Replace('/', System.IO.Path.DirectorySeparatorChar);
                ff = System.IO.Path.Combine(directory, ff);
                var dd = System.IO.Path.GetDirectoryName(ff);
                var di = new System.IO.DirectoryInfo(dd);
                if (!di.Exists)
                {
                    di.Create();
                }
                using (var stream = System.IO.File.OpenWrite(ff))
                {
                    stream.Write(b, 0, b.Length);
                }
            }
        }
        protected BoundaryParameters bp;

        protected Dictionary<string, string> paths = new Dictionary<string, string>();

        protected System.Drawing.Bitmap texture;

        protected void CreateSize()
        {
            size = Visual.GetSize();
        }


        protected Dictionary<string, string> urls = new Dictionary<string, string>();

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
            string s = str + "";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(s);
            XmlNodeList nl = doc.GetElementsByTagName("ImageBrush");
            var del = new List<XmlElement>();
            foreach (XmlElement e in nl)
            {
                string iso = e.GetAttribute("ImageSource");
                if (iso != null)
                {
                    if (iso.Length > 0)
                    {
                        var isi = service.FindEnd(iso, textures.Keys);
                        if (isi == null)
                        {
                            del.Add(e);
                            continue;
                        }
                        iso = isi;
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
                                if (!System.IO.File.Exists(path))
                                {
                                    using (var stream = System.IO.File.OpenWrite(path))
                                    {
                                        byte[] b = textures[iso];
                                        stream.Write(b, 0, b.Length);
                                    }
                                }
                            }
                            else
                            {
                                string fn = GenerateFileName(ext, out path);
                                using (var stream = System.IO.File.OpenWrite(path))
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
                            if (System.IO.File.Exists(path))
                            {
                                using (var stream = System.IO.File.OpenRead(path))
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
            foreach (var e in del)
            {
                var p = e.ParentNode as XmlElement;
                p.RemoveChild(e);
            }
            var l = new List<string>(textures.Keys);
            foreach (string key in l)
            {
                if (!paths.ContainsKey(key))
                {
                    textures.Remove(key);
                }
            }
            del.Clear();
            foreach (XmlElement n in doc.GetElementsByTagName("ImageBrush"))
            {
                var so = n.GetAttribute("ImageSource");
                if (!System.IO.File.Exists(so))
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
            Bitmap bmp = Texture;
            Graphics g = Graphics.FromImage(bmp);
            if (colors == null)
            {
                return;
            }
            for (int i = 0; i < colors.Length; i++)
            {
                System.Drawing.Color c = colors[i];
                if (c != null)
                {
                    System.Drawing.Brush br = new SolidBrush(c);
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
                string s = ProcessXaml(xaml);
                var doc = new XmlDocument();
                doc.LoadXml(s);
                object ob = null;
                try
                {
                  ob = System.Windows.Markup.XamlReader.Parse(s);
                }
                catch (Exception ex)
                {
                    ex.ShowError();
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
