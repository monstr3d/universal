using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;

using Xml.Parser.Library;
using Simulink.Parser.Library;
using Xml.Drawing.Library.Interfaces;
using Xml.Drawing.Library.Classes;

namespace Simulink.Drawing.Library
{
    /// <summary>
    /// Drawing interface for Simulink
    /// </summary>
    public class SimulinkDrawing : IDrawingInterface, IDrawing, ISize
    {

        #region Fields

        const float EPS = 0.5F;

        XElement doc;

        XElement root;

        static readonly char[] sep = " ,".ToCharArray();

        private Font DefaultFont = new Font("Serif", 10, GraphicsUnit.Pixel);

        internal static readonly Pen DefaultPen = new Pen(Color.Black);

        private Brush DefaultForeBrush = new SolidBrush(Color.Black);
        
        private Brush DefaultBackBrush = new SolidBrush(Color.White);

        const string Defaults = "Defaults";

        private Dictionary<string, Action<XElement, Graphics>> drawBlock = new Dictionary<string, Action<XElement, Graphics>>();
        private Dictionary<string, Dictionary<string, Action<XElement, Graphics>>> drawIconBlock =
            new Dictionary<string, Dictionary<string, Action<XElement, Graphics>>>();


        private XElement[] children;

        private IDrawingInterface di;

        private IDrawing drawing;

        XElement system;

        private Bitmap bitmap;

        private Dictionary<string, XElement> blocks = new Dictionary<string, XElement>();

        //private Dictionary<XElement, int[][]> points = new Dictionary<XElement, int[][]>();

        //private Dictionary<XElement, int[][]> linepoints = new Dictionary<XElement, int[][]>();

        private List<Point> ap = new List<Point>();

  
        private const string ShowName = "ShowName";

        private const string off = SimulinkXmlParser.off;

        private Dictionary<XElement, Dictionary<bool, Dictionary<string, PortIO>>> ports 
            = new Dictionary<XElement, Dictionary<bool, Dictionary<string, PortIO>>>();


        private Dictionary<XElement, Path> paths = new Dictionary<XElement, Path>();

        private static Graphics etalon;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor from element
        /// </summary>
        /// <param name="e">The element</param>
        public SimulinkDrawing(XElement e)
        {
            root = e;
            Create();
        }

        /// <summary>
        /// Constructor from document
        /// </summary>
        /// <param name="doc">The document</param>
      /*  public SimulinkDrawing(XmlDocument doc)
        {
            this.doc = doc;
            root = doc.DocumentElement;
            Create();
        }*/

        static SimulinkDrawing()
        {
            Bitmap bmp = new Bitmap(2, 2);
            etalon = Graphics.FromImage(bmp);
        }

        #endregion

        #region Public

        /// <summary>
        /// Creates object from file
        /// </summary>
        /// <param name="filename">Filename</param>
        /// <returns>Created object</returns>
        public static SimulinkDrawing FromFile(string filename)
        {
            XElement doc = SimulinkXmlParser.Create(StaticExtensionXmlParserLibrary.TransformFile(filename));
            return new SimulinkDrawing(doc);
        }

        /// <summary>
        /// Creates object from Xml element
        /// </summary>
        /// <param name="e">The Xml element</param>
        /// <returns>Created object</returns>
        public static SimulinkDrawing FromElement(XElement e)
        {
            return new SimulinkDrawing(e);
        }


        /// <summary>
        /// Creates element from list of strings
        /// </summary>
        /// <param name="text">List of strings</param>
        /// <returns>Created object</returns>
        public static SimulinkDrawing FromText(IList<string> text)
        {
            XElement doc = SimulinkXmlParser.Create(text);
            return new SimulinkDrawing(doc);
        }

        /// <summary>
        /// Draws Simulink object
        /// </summary>
        /// <param name="g">Graphics for drawing</param>
        /// <param name="element">Xml representation of Simulink objec</param>
        public void DrawContainer(Graphics g, XElement element)
        {
            Xml.Drawing.Library.Static.StaticPerformer.Draw(element, this, g);        
        }

        /// <summary>
        /// The bitmap with drawing
        /// </summary>
        public Bitmap Bitmap
        {
            get
            {
                if (bitmap == null)
                {
                    int[] size = new int[] { 0, 0 };
                    Xml.Drawing.Library.Static.StaticPerformer.GetSize(system, this, size);
                    bitmap = new Bitmap(size[0] + 5, size[1] + 5);
                    Graphics g = Graphics.FromImage(bitmap);
                    g.FillRectangle(new SolidBrush(Color.White), 0, 0, bitmap.Width, bitmap.Height);
                    DrawContainer(g, system);
                    g.Dispose();

                }
                return bitmap;
            }
        }

        #endregion

        #region Drawing

        void DrawCircle(XElement element, Graphics graphics)
        {
            int[] pos = SimulinkXmlParser.GetPosition(element);
            Pen pen = di.GetPen(element);
            graphics.DrawEllipse(GetPen(element), pos[0], pos[1], pos[2] - pos[0], pos[3] - pos[1]);
        }

        void DrawRect(XElement element, Graphics graphics)
        {
            try
            {
                int[] pos = SimulinkXmlParser.GetPosition(element);
                Pen pen = di.GetPen(element);
                graphics.DrawRectangle(GetPen(element), pos[0], pos[1], pos[2] - pos[0], pos[3] - pos[1]);
            }
            catch (Exception)
            {
            }
        }

        static string[] ParseString(string s)
        {
            return SimulinkXmlParser.ParseString(s);
        }

        void DrawTransferFunc(XElement element, Graphics graphics)
        {
            try
            {
                int[] pos = SimulinkXmlParser.GetPosition(element);
                string[] snd = new string[2];
                SizeF[] size = new SizeF[2];
                Font font = GetFont(element);
                float w = 0;
              
                for (int i = 0; i < 2; i++)
                {
                    string[] ss = ParseString(
                    element.GetAttributeLocal(SimulinkXmlParser.Fraction[i]));
                    string str = "";
                    for (int j = 0; j < ss.Length; j++)
                    {
                        if (j > 0)
                        {
                            str += " + ";
                        }
                        str += ss[j];
                        if (j < ss.Length - 1)
                        {
                            str += "s";
                        }
                    }
                    snd[i] = str;
                    SizeF siz = graphics.MeasureString(str, font);
                    if (w < siz.Width)
                    {
                        w = siz.Width;
                    }
                    size[i] = siz;
                }
                int cx = (pos[0] + pos[2]) / 2;
                int cy = (pos[1] + pos[3]) / 2;
                int w2 = (int)(w / 2);
                Pen pen = GetPen(element);
                graphics.DrawLine(pen, cx - w2, cy, cx + w2, cy);
                int[] yy = new int[] { cy - (int)size[0].Height - 1, cy + 1 };
                Brush brush = GetForeBrush(element);
                for (int i = 0; i < 2; i++)
                {
                    float x = (float)cx - size[i].Width / 2;
                    graphics.DrawString(snd[i], font, brush, x, (float)yy[i]);
                }

            }
            catch (Exception)
            {
            }
        }

        void DrawMult(XElement element, Graphics graphics)
        {
            int[] pos = SimulinkXmlParser.GetPosition(element);
            Pen pen = di.GetPen(element);
            double dx = (pos[2] - pos[0]);
            double dy = (pos[3] - pos[1]);
            //int xl = (int)(dx * Math.Sqrt(0.5));
            int dxl = (int)(dx * Math.Sqrt(2) / 8);
            //int yl = (int)(dy * Math.Sqrt(0.5));
            int dyl = (int)(dy * Math.Sqrt(2) / 8);
            graphics.DrawLine(pen, pos[0] + dxl, pos[1] + dyl, pos[2] - dxl, pos[3] - dyl);
            graphics.DrawLine(pen, pos[0] + dxl, pos[3] - dyl, pos[2] - dxl, pos[1] + dyl); 
        }

        private int[][] GetInputsSum(XElement element)
        {
            int[][] nn = new int[3][];
            int[] p = GetPosition(element);
            int m = (p[0] + p[3]) / 2;
            nn[0] = new int[] { m, p[1] };
            nn[1] = new int[] { p[0], (p[1] + p[3]) / 2 };
            nn[2] = new int[] { m, p[3] };
            return nn;
        }


        private void DrawSingnature(XElement element, Graphics graphics)
        {
            string signature = element.GetAttributeLocal("Inputs");
            int[][] pp = GetInputsSum(element);
            Brush brush = GetForeBrush(element);
            Font font = GetFont(element);
            for (int i = 0; i < signature.Length; i++)
            {
                char s = signature[i];
                if (s == '|')
                {
                    continue;
                }
                int[] p = pp[i];
                string st = s + "";
                SizeF f = graphics.MeasureString(st, font);
                float dx = 0;
                float dy = 0;
                if (i == 1)
                {
                    dy = -f.Height / 2f;
                }
                else
                {
                    dy = -f.Height / 1.2f;
                    dx = -f.Width;
                }
                graphics.DrawString(s + "", font, brush, new PointF((float)p[0] + dx, (float)p[1] + dy));

            }
        }

        void DrawTriangle(XElement element, Graphics graphics)
        {
            int[] pos = SimulinkXmlParser.GetPosition(element);
            Pen pen = di.GetPen(element);
            Point[] p = new Point[] {new Point(pos[0], pos[1]), new Point(pos[0], pos[3]), new Point(pos[2], (pos[1] + pos[3]) / 2)};
            graphics.DrawPolygon(pen, p);
        }

        void DrawLine(XElement element, Graphics graphics)
        {
            if (!paths.ContainsKey(element))
            {
                return;
            }
            Path path = paths[element];
            path.Draw(graphics, ports);
        }



        /* void DrawLine(XElement element, Graphics graphics)
         {
             int[][] pp = GetPoints(element);
             if (pp == null)
             {
                 return;
             }
             List<Point> lp = new List<Point>();
             foreach (int[] p in pp)
             {
                 lp.Add(new Point(p[0], p[1]));
             }
             Pen pen = GetPen(element);
             graphics.DrawLines(pen, lp.ToArray());
             DrawEnd(element, 5f, graphics);
             if (element.Name.Equals("Branch"))
             {
                 Brush brush = new SolidBrush(Color.Black);
                 int[] pe = pp[0];
                 int ll = 3;
                 graphics.FillEllipse(brush, pe[0] - ll, pe[1] - ll, 2 * ll, 2 * ll); 
             }
         }*/




        #endregion

        #region Private

        private void DrawName(XElement element, Graphics graphics)
        {
            string s = GetShowName(element);
            if (s == null)
            {
                return;
            }
            int[] p = GetPosition(element);
            Font font = GetFont(element);
            Brush brush = GetForeBrush(element);
            graphics.DrawString(s, font, brush, (float)p[0], (float)p[3]);
        }


        string GetShowName(XElement element)
        {
            string sn = element.GetAttributeLocal(ShowName);
            if (sn.ToLower().Contains(off))
            {
                return null;
            }
            return SimulinkXmlParser.GetName(element);

        }


        void PrepareArrows(XElement element)
        {
            XElement[] el = SimulinkXmlParser.GetChildren(element);
            foreach (XElement e in el)
            {

                if (e.Name.Equals(SimulinkXmlParser.Block))
                {
                    blocks[e.GetAttributeLocal(SimulinkXmlParser.Name)] = e;
                }
            }
            foreach (XElement e in el)
            {
                if (e.Name.Equals(SimulinkXmlParser.Line))
                {
                    ProcessArrow(e);
                }
            }
        }

        void Add(Path path, int[] x)
        {
            path.Add(x);
        }



        void ProcessArrow(XElement element)
        {
            List<int[]> pstl = new List<int[]>();
            int[] xx = null;
            Path path = null;
            for (int i = 0; i < 2; i++)
            {
                string b = element.GetAttributeLocal(SimulinkXmlParser.SourceTarget[i]);
                string p = element.GetAttributeLocal(SimulinkXmlParser.SourceTargetPorts[i]);
                if (b.Length == 0)
                {
                    break;
                }
                PortIO pio = GetConnectionPort(b, p, i == 1);
                if (i == 0)
                {
                    path = new Path(pio);
                    paths[element] = path;
                }
                else
                {
                    path.Out = pio;
                }
             }
            int[][] pp = SimulinkXmlParser.GetPoints(element);
            xx = new int[]{0, 0};
            if (pp != null)
            {
             //   Array.Copy(pp[0], xx, xx.Length);
              //  path.Add(pp[0]);
                foreach (int[] p in pp)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        xx[i] += p[i];
                    }
                    path.Add(xx);
                }
            }
            XElement[] children = SimulinkXmlParser.GetChildren(element);
            foreach (XElement child in children)
            {
                if (child.Name.Equals("Branch"))
                {
                    Path pn = path.Create();
                    ProcessBrunch(pn, xx, child);
                }
            }
        }



        void ProcessBrunch(Path path, int[] begin, XElement element)
        {
            int[] x = new int[begin.Length];
            Array.Copy(begin, x, x.Length);
            int[] y = new int[]{0,0};//x[0], x[1]};
            int[][] pp = SimulinkXmlParser.GetPoints(element);
            path.Add(y);
            if (pp != null)
            {
                foreach (int[] p in pp)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        y[i] += p[i];
                    }
                    path.Add(y);
                }
            }
            string b = element.GetAttributeLocal(SimulinkXmlParser.SourceTarget[1]);
            string pb = element.GetAttributeLocal(SimulinkXmlParser.SourceTargetPorts[1]);
            if (b.Length > 0)
            {
               PortIO ff = GetConnectionPort(b, pb, true);
               path.Out = ff;
            }
        }



        int[] GetPosition(XElement element)
        {
            return SimulinkXmlParser.GetPosition(element);
        }

       /* private int[][] GetPoints(XElement element)
        {
            if (!points.ContainsKey(element))
            {
                return null;
            }
            return points[element];
        }*/

       


        private void CreateDrawingDelegates()
        {

            Action<XElement, Graphics> DrawTrans = DrawRect;
            DrawTrans += DrawTransferFunc;
            Action<XElement, Graphics> DrawSum = DrawRect;
            DrawSum += DrawSingnature;
            Action<XElement, Graphics> DrawCSum = DrawCircle;
            DrawCSum += DrawSingnature;
            Action<XElement, Graphics> DrawSin = DrawRect;
            Dictionary<string, Action<XElement, Graphics>> dr =
                new Dictionary<string, Action<XElement, Graphics>>()
            {
                {"TransferFcn", DrawTrans},
                {"Sum", DrawSum},
                {"Gain", DrawTriangle},
                {SimulinkXmlParser.SinStr, DrawSin}
            };
            Dictionary<string, Action<XElement, Graphics>> dri =
                new Dictionary<string, Action<XElement, Graphics>>()
            {
                {"rectangular", DrawRect},
                {"round", DrawCSum} 
           };
            foreach (string key in dri.Keys)
            {
                Dictionary<string, Action<XElement, Graphics>> dd = 
                    new Dictionary<string, Action<XElement, Graphics>>();
                drawIconBlock[key] = dd;
                foreach (string kk in dr.Keys)
                {
                    Action<XElement, Graphics> drr = dri[key];
                    drr += DrawName;
                    dd[kk] = drr;
                }

            }
            foreach (string key in dr.Keys)
            {
                Action<XElement, Graphics> d = dr[key];
                d += DrawName;
                drawBlock[key] = d;
            }
        }

        private void CreateChildren()
        {
            IEnumerable<XElement> nl = root.GetChildNodesLocal();
            List<XElement> l = new List<XElement>();
            foreach (XElement n in nl)
            {
                if (n is XElement)
                {
                    l.Add(n as XElement);
                }
            }
            children = l.ToArray();
        }

        private void GetSize(XElement element, int[] size)
        {
            size[0] = 0;
            size[1] = 0;
            if (paths.ContainsKey(element))
            {
                Path path = paths[element];
                path.GetSize(ref size[0], ref size[1], ports);
                return;
            }
            int[] p = GetPosition(element);
            if (p != null)
            {
                if (p.Length > 3)
                {

                    size[0] = p[2];
                    size[1] = p[3];
                    string s = GetShowName(element);
                    SizeF sf = etalon.MeasureString(s, DefaultFont);
                    size[0] += (int)sf.Width;
                    size[1] += (int)sf.Height;
                }
            }
            /*if (points.ContainsKey(element))
            {
                int[][] pp = points[element];
                foreach (int[] point in pp)
                {
                    if (point[0] > size[0])
                    {
                        size[0] = point[0];
                    }
                    if (point[1] > size[1])
                    {
                        size[1] = point[1];
                    }
                }
            }*/
         }


        private void CreateGraphicsStructure()
        {
            Dictionary<string, GraphicsStructure> d = new Dictionary<string, GraphicsStructure>();
            XElement r = root;
            while (true)
            {
                if (r.Name.Equals("Model"))
                {
                    break;
                }
                XElement p = r.Parent as XElement;
                if (p == null)
                {
                    break;
                }
                r = p;
            }
            XElement[] children = SimulinkXmlParser.GetChildren(r);
            foreach (XElement e in children)
            {
                string tn = e.Name.LocalName;
                if (tn.Contains(Defaults))
                {
                    string s = tn.Substring(0, tn.Length - Defaults.Length);
                    GraphicsStructure gs = CreateStucrure(e);
                    d[s] = gs;
                   
                }
            }
            if (d.ContainsKey(SimulinkXmlParser.Line))
            {
                d[SimulinkXmlParser.Branch] = d[SimulinkXmlParser.Line];
            }
            IDrawingInterface din = TagNameDrawingInterface.GetInterface(d);
            IList<IDrawingInterface> list = new List<IDrawingInterface>();
            list.Add(din);
            list.Add(this);
            di = new DrawingInterfaceList(list);
        }

        private PortIO GetConnectionPort(string block, string port, bool input)
        {
            XElement e = blocks[block];
            PortIO pio = new PortIO(e, port, input, ports);
            return pio;
        }



        GraphicsStructure CreateStucrure(XElement e)
        {
            string fn = e.GetAttributeLocal("FontName");
            string fs = e.GetAttributeLocal("FontSize");
            Font font = new Font(fn, float.Parse(fs), FontStyle.Regular);
            Pen pen = new Pen(Color.Black);
            Brush fore = new SolidBrush(Color.Black);
            Brush back = new SolidBrush(Color.White);

            return new GraphicsStructure(font, fore, back, pen);
        }


        void Create()
        {
            CreateChildren();
            CreateGraphicsStructure();
            drawing = this;
            system = root.GetFirstLocal("System") as XElement;
            PrepareArrows(system);
            CreateDrawingDelegates();
        }

        #endregion

        #region Ports


        int[] GetPort(XElement element, string port, bool input)
        {
            string blockType = SimulinkXmlParser.GetBlockType(element);
            string icon = element.GetAttributeLocal("IconShape");
            if (blockType.Equals("Sum") & icon.Equals("round"))
            {
                return GetSumPort(element, port, input);
            }
            return GetDefaultPort(element, port, input);
        }

        int[] GetDefaultPort(XElement element, string port, bool input)
        {
            int[] p = GetPosition(element);
            int n = 1;
            int m = 0;
            string pp = element.GetAttributeLocal("Ports");
            try
            {
                int[] nn = SimulinkXmlParser.ParseInt(pp);
               // n = (input) ? nn[0] : nn[1];
                m = Int32.Parse(port) - 1;
                if (input)
                {
                    int km = 0;
                    string s = element.GetAttributeLocal("MaxPort");
                    if (s.Length > 0)
                    {
                        km = Int32.Parse(s);
                    }
                    if (m > km)
                    {
                        km = m;
                    }
                    element.SetAttributeValue("MaxPort", km + "");
                }
                else
                {
                    string s = element.GetAttributeLocal("MaxPort");
                    if (s.Length > 0)
                    {
                        m += 1 + Int32.Parse(s);
                    }
                }
                int kk = 0;
                int side = 0;
                for (; side < nn.Length; side++)
                {
                    kk += nn[side];
                    if (m <= kk)
                    {
                        break;
                    }
                }
                int nk = nn[side];
                bool vertical = (side == 0 | side == 2);
                float len = (float)(vertical ? (p[3] - p[1]) : (p[2] - p[0]));
                float kl = len / (float)nk;
                float pos = (EPS + (float)m) * kl;
                int coord = p[side];
                if (vertical)
                {
                    return new int[] { coord, p[1] + (int)pos };
                }
                else
                {
                    return new int[] { p[1] + (int)pos, coord };
                }
            }
            catch (Exception)
            {
            }
            float k = (float)(p[3] - p[1]) / ((float)n/* - 1 + 2 * EPS*/);
            k = (float)p[1] + (EPS + (float)m) * k;
            int mm = (int)k;
            if (!input)
            {
                return new int[] { p[2], mm };
            }
            return new int[] { p[0], mm };
        }

        int[] GetSumPort(XElement element, string port, bool input)
        {
            if (!input)
            {
                return GetDefaultPort(element, port, input);
            }
            int[] p = GetPosition(element);
            int pn = Int32.Parse(port);
            int m = (p[3] + p[1]) / 2;
            if (pn == 1)
            {
                return new int[] { p[0], m };

            }
            int mb = (p[0] + p[2]) / 2;
            if (pn == 2)
            {
                return new int[] { mb, p[3] };
            }
            return new int[] { mb, p[1] };
        }




        #endregion

        #region Painter

        Font GetFont(XElement element)
        {
            return di.GetFont(element);
        }

        Brush GetForeBrush(XElement element)
        {
            return di.GetForegroundBrush(element);
        }

        Brush GetBackBrush(XElement element)
        {
            return di.GetBackgroundBrush(element);
        }


        Pen GetPen(XElement element)
        {
            return di.GetPen(element);
        }

        #endregion

        #region IDrawingInterface Members

        Font IDrawingInterface.GetFont(XElement element)
        {
            return DefaultFont;
        }

        Brush IDrawingInterface.GetForegroundBrush(XElement element)
        {
            return DefaultForeBrush;
        }

        Brush IDrawingInterface.GetBackgroundBrush(XElement element)
        {
            return DefaultBackBrush;
        }

        Pen IDrawingInterface.GetPen(XElement element)
        {
            return DefaultPen;
        }

        IDrawingInterface IDrawingInterface.GetDrawing(XElement element)
        {
            return this;
        }

        #endregion

        #region IDrawing Members

        Action<XElement, Graphics> IDrawing.GetDrawing(XElement element, out bool recursive)
        {
            string en = element.Name.LocalName;
            if (en.Equals(SimulinkXmlParser.Block))
            {
                string bn = SimulinkXmlParser.GetName(element);
                recursive = false;
                string type = SimulinkXmlParser.GetBlockType(element);
                string icon = element.GetAttributeLocal("IconShape");
                if (drawIconBlock.ContainsKey(icon))
                {
                    Dictionary<string, Action<XElement, Graphics>> dd = drawIconBlock[icon];
                    if (dd.ContainsKey(type))
                    {
                        return dd[type];
                    }
                }
                if (drawBlock.ContainsKey(type))
                {
                    return drawBlock[type];
                }
                else
                {
                    Action<XElement, Graphics> d = DrawRect;
                    d += DrawName;
                    return d;
                }
            }
            recursive = true;
            if (en.Equals(SimulinkXmlParser.Line) | en.Equals(SimulinkXmlParser.Branch))
            {
                return DrawLine;
            }
            return null;
        }

        #endregion

        #region ISize Members

        Action<XElement, int[]> ISize.GetSize(XElement element, out bool recursive)
        {
            recursive = false;
            if (element == system | element.Name.Equals("Line") | element.Name.Equals("Branch"))
            {
                recursive = true;
            }
            return GetSize;
        }

        #endregion


    }
}
