using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Drawing;
using Simulink.Parser.Library;

namespace Simulink.Drawing.Library
{
    class Path
    {

        const float EPS = 0.5f;
        PortIO pin;

        PortIO pou;

        List<int[]> points = new List<int[]>();


        int[][] pointsDraw;

        Path parent;

        int[] x1 = null;


        List<Path> children;

        private Path()
        {
        }

        internal Path(PortIO pin)
        {
            this.pin = pin;
            children = new List<Path>();
        }

        internal void Add(int[] k)
        {
            int[] x = new int[k.Length];
            Array.Copy(k, x, k.Length);
            points.Add(x);
        }


        internal Path Create()
        {
            Path p = new Path();
            p.parent = this;
            Path root = Root;
            root.children.Add(p);
            return p;
        }

        internal PortIO Out
        {
            set
            {
                pou = value;
            }
        }

        internal void Draw(Graphics graphics, 
            Dictionary<XElement, Dictionary<bool, Dictionary<string, PortIO>>> 
            dic)
        {
            if (pointsDraw == null)
            {
                CreatePoints(dic);
            }
            Draw(graphics);
        }

        void Add(int[] x, List<int[]> l)
        {
            int[] a = new int[x.Length];
            Array.Copy(x, a, a.Length);
            l.Add(a);
        }

        void Draw(Graphics graphics)
        {
            int[][] pp = pointsDraw;
            if (pp == null)
            {
                return;
            }
            List<Point> lp = new List<Point>();
            foreach (int[] p in pp)
            {
                lp.Add(new Point(p[0], p[1]));
            }
            //Pen pen = GetPen(element);
            Pen pen = SimulinkDrawing.DefaultPen;
            graphics.DrawLines(pen, lp.ToArray());
            if (pou != null)
            {
                DrawEnd(5f, graphics);
            }
            if (parent != null)
            {
                Brush brush = new SolidBrush(Color.Black);
                int[] pe = pp[0];
                int ll = 3;
                graphics.FillEllipse(brush, pe[0] - ll, pe[1] - ll, 2 * ll, 2 * ll);
            }
            if (children == null)
            {
                return;
            }
            foreach (Path path in children)
            {
                path.Draw(graphics);
            }
        }

        void CreatePoints(Dictionary<XElement, Dictionary<bool, Dictionary<string, PortIO>>> dic)
        {
            List<int[]> l = new List<int[]>();
            int[] x = null;
            if (x1 != null)
            {
                x = x1;
                Add(x, l);
            }
            else if (pin != null)
            {
                x = GetDefaultPort(pin.Element, pin.Port, false, dic);
                Add(x, l);
            }
            else
            {
                PortIO pio = Root.pin;
                x = GetDefaultPort(pio.Element, pio.Port, false, dic);
            }
            int[] kk = new int[2];
            foreach (int[] pp in points)
            {
                Array.Copy(x, kk, kk.Length);
                for (int i = 0; i < kk.Length; i++)
                {
                    kk[i] += pp[i];
                }
                Add(kk, l);
            }
            if (pou != null)
            {
                int[] y = GetDefaultPort(pou.Element, pou.Port + "", true, dic);
                Add(y, l);
            }
            pointsDraw = l.ToArray();
            if (children == null)
            {
                return;
            }
            foreach (Path path in children)
            {
                path.x1 = pointsDraw[pointsDraw.Length - 1];
                path.CreatePoints(dic);
            }
        }


      //  void Draw(Graphics graphics, int[] beg, Dictionary<XElement, Dictionary<bool, Dictionary<int, PortIO>>> dic)
        //{
        //}

        int[] GetPosition(XElement element)
        {
            return SimulinkXmlParser.GetPosition(element);
        }

        internal void GetSize(ref int x, ref int y,
        Dictionary<XElement, Dictionary<bool, Dictionary<string, PortIO>>> dic)
        {
            if (pointsDraw == null)
            {
                CreatePoints(dic);
            }
            foreach (int[] p in pointsDraw)
            {
                if (p[0] > x)
                {
                    x = p[0];
                }
                if (p[1] > y)
                {
                    y = p[1];
                }
            }
            if (children == null)
            {
                return;
            }
            foreach (Path path in children)
            {
                path.GetSize(ref x, ref y, dic);
            }
        }

        int[] GetCircularPort(XElement element, string port, bool input)
        {
            int[] p = GetPosition(element);
            if (!input)
            {
                int mo = (p[3] + p[1]) / 2;
                return new int[] { p[2], mo };
            }
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


        int[] GetDefaultPort(XElement element, string port, bool input,
            Dictionary<XElement, Dictionary<bool, Dictionary<string, PortIO>>> dic)
        {
            int[] ss = new int[] { 0, 2, 1, 3 };
            string icon = element.GetAttribute("IconShape");
            if (icon.Equals("round"))
            {
                int[] nc = GetCircularPort(element, port, input);
                if (nc != null)
                {
                    return nc;
                }
            }
            int[] p = GetPosition(element);
            int n = 1;
            int m = 0;
            int dm = 0;
            Dictionary<bool, Dictionary<string, PortIO>> dd = dic[element];
            string pp = element.GetAttribute("Ports");
            try
            {
                int[] nn = SimulinkXmlParser.ParseInt(pp);
                // n = (input) ? nn[0] : nn[1];
                m = Int32.Parse(port) - 1;
                if (!input & nn.Length > 0)
                {
                    m += dd[true].Count;
                }
                int kk = 0;
                int side = 0;
                for (; side < nn.Length; side++)
                {
                    int kkk = kk;
                    kk += nn[side];
                    if (m < kk)
                    {
                        dm = m - kkk;
                        break;
                    }
                }
                int nk = 1;
                if (nn.Length == 0)
                {
                    side = input ? 0 : 1;
                }
                else
                {
                    nk = nn[side];
                }
                bool vertical = (side == 0 | side == 1);
                float len = (float)(vertical ? (p[3] - p[1]) : (p[2] - p[0]));
                float kl = len / (float)nk;
                float pos = (EPS + (float)dm) * kl;
                int coord = p[ss[side]];
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

        void DrawEnd(float length, Graphics g)
        {
            int[][] p = pointsDraw.ToArray();

            if (p == null)
            {
                return;
            }
            if (p.Length < 2)
            {
                return;
            }
            float[][] x = new float[2][];
            int k = p.Length - 2;
            for (int i = 0; i < 2; i++)
            {
                int[] xx = p[k + i];
                x[i] = new float[] { (float)xx[0], (float)xx[1] };
            }
            float[] dx = new float[] { x[1][0] - x[0][0], x[1][1] - x[0][1] };
            float norm = (float)Math.Sqrt((double)(dx[0] * dx[0] + dx[1] * dx[1]));
            norm = length / norm;
            for (int i = 0; i < 2; i++)
            {
                dx[i] *= norm;
            }
            float[] dy = new float[] { dx[1], -dx[0] };
            float[] x0 = new float[] { x[1][0] - dx[0], x[1][1] - dx[1] };
            List<PointF> lp = new List<PointF>();
            float[] ddy = new float[2];
            for (int i = 0; i < 2; i++)
            {
                Array.Copy(dy, ddy, 2);
                for (int j = 0; j < 2; j++)
                {
                    if (i == 0)
                    {
                        ddy[j] = -ddy[j];
                    }
                    ddy[j] += x0[j];
                }
                PointF pf = new PointF(ddy[0], ddy[1]);
                lp.Add(pf);
            }
            lp.Add(new PointF(x[1][0], x[1][1]));
            Brush brush = new SolidBrush(Color.Black);
            g.FillPolygon(brush, lp.ToArray());

        }



        Path Root
        {
            get
            {
                if (parent == null)
                {
                    return this;
                }
                return parent.Root;
            }
        }
    }
}