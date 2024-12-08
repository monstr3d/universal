using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Xml;
using System.Windows.Media.TextFormatting;
using System.Security.Policy;
using System.Drawing;

namespace Wpf.Loader
{
    public class XamlWrapper
    {

        protected double[][] normals;


        protected object[] types = null;

        protected object[][] parameters;

        protected double[][] centers;

        protected double[,] size;

        protected System.Drawing.Color[] colors = null;


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

        protected string xaml;


        protected Dictionary<string, byte[]> textures = new Dictionary<string, byte[]>();

        public void  Load(string file)
        {
            string dir = Path.GetDirectoryName(file);
            Visual3D v = file.ToVisual3D();
            string xaml;
            if (v != null)
            {
                xaml = System.Windows.Markup.XamlWriter.Save(v);
            }
            else
            {
                using (TextReader reader = new StreamReader(file))
                {
                    xaml = reader.ReadToEnd();
                }
            }
            SetFile(xaml, dir);

        }

        internal void SetFile(string xaml, string dir)
        {
            string d = dir;
            var ds = d.Replace(Path.DirectorySeparatorChar, '/');
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
                    //iso = iso.Substring(iso.LastIndexOf('/') + 1);
                    iso = iso.Substring(ds.Length + "file://".Length + 1);
                    e.SetAttribute("ImageSource", iso);
                }
                string fn = ds + iso;
                fn = fn.Replace('/', Path.DirectorySeparatorChar);
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
                var file = Path.Combine(directory, key);
                if (!file.Contains(directory))
                {
                    continue;
                }
                using (var stream = File.OpenWrite(Path.Combine(directory, key)))
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

        public const string deleteTexture = "delete_texture_file_";

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


        protected virtual string GenerateFileName(string ext, out string path)
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
                object ob = System.Windows.Markup.XamlReader.Parse(s);
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
