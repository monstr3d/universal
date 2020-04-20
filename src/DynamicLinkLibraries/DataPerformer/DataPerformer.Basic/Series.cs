﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using Localization.Helper;

namespace DataPerformer.Basic
{
    /// <summary>
    /// Basic series
    /// </summary>
    public class Series
    {
        #region Fields

        /// <summary>
        /// Type value
        /// </summary>
        protected static readonly Double a = 0;

        /// <summary>
        /// Little number
        /// </summary>
        protected readonly double eps = 1e-9;

        /// <summary>
        /// Message strings
        /// </summary>
        static public readonly string[] HasEqualStepString = new string[] {"This series has equal steps",
																			  "This series has no equal steps"};
        /// <summary>
        /// Points
        /// </summary>
        protected List<double[]> points = new List<double[]>();

        /// <summary>
        /// Current parameter
        /// </summary>
        protected double[] parameter = new double[2];

        /// <summary>
        /// Step
        /// </summary>
        protected double step = 0;

        /// <summary>
        /// Start point
        /// </summary>
        protected int[] pointStart = new int[2];

        /// <summary>
        /// Finish point
        /// </summary>
        protected int[] pointFinish = new int[2];

 
        #endregion

        #region Ctor

        #endregion

        #region Specific Members

        #region Public Members

        /// <summary>
        /// Saves itself to blob
        /// </summary>
        /// <returns>The blob</returns>
        public byte[] ToBlob()
        {
            byte[] b;
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(ms))
                {
                    bw.Write(points.Count);
                    foreach (double[] p in points)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            bw.Write(p[i]);
                        }
                    }
                    bw.Flush();
                    b = ms.GetBuffer();
                }
            }
            return b;
        }

        /// <summary>
        /// Loads itself from blob
        /// </summary>
        /// <param name="blob">The blob</param>
        public void FromBlob(byte[] blob)
        {
            points.Clear();
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(blob))
            {
                using (System.IO.BinaryReader br = new System.IO.BinaryReader(ms))
                {
                    int n = br.ReadInt32();
                    for (int i = 0; i < n; i++)
                    {
                        double[] x = new double[2];
                        for (int j = 0; j < 2; j++)
                        {
                            x[j] = br.ReadDouble();
                        }
                        points.Add(x);
                    }
                }
            }
        }

        /// <summary>
        /// Compares with another series
        /// </summary>
        /// <param name="series">Another series</param>
        /// <returns>True if series are equal</returns>
        public bool Compare(Series series)
        {
            if (points.Count != series.points.Count)
            {
                return false;
            }
            for (int i = 0; i < points.Count; i++)
            {
                double[] a = points[i];
                double[] b = series.points[i];
                for (int j = 0; j < 2; j++)
                {
                    if (a[j] != b[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Adds series
        /// </summary>
        /// <param name="series">Series to add</param>
        public virtual void Add(Series series)
        {
            points.AddRange(series.points);
            step = 0;
            CheckEqualStep();
     }



        /// <summary>
        /// Creates inverted series
        /// </summary>
        /// <param name="step">Step</param>
        /// <returns>Inverted series</returns>
        public Series CreareInvertedSeries(double step)
        {
            if (IsIncreasing)
            {
                return CreateIncreasingInvertedSeries(step);
            }
            return CreateDecreasingInvertedSeries(step);
        }


        /// <summary>
        /// Creates increasing inverted series
        /// </summary>
        /// <param name="step">Step</param>
        /// <returns>Inverted series</returns>
        public Series CreateIncreasingInvertedSeries(double step)
        {
            List<double[]> l = Points;
            double[] p = l[0];
            double y1 = p[1];
            double[] p1 = l[l.Count - 1];
            double y2 = p1[1];
            Series sb = new Series();
            for (int i = 0; ; i++)
            {
                double yy = y1 + i * step;
                if (yy > y2)
                {
                    sb.AddXY(y2, p1[0]);
                    break;
                }
                double x = CaclulateIncreasingInvertedFunction(l, yy);
                sb.AddXY(yy, x);
            }
            return sb;
        }

        /// <summary>
        /// Creates decreasing inverted series
        /// </summary>
        /// <param name="step">Step</param>
        /// <returns>Inverted series</returns>
        public Series CreateDecreasingInvertedSeries(double step)
        {
            List<double[]> l = Points;
            double[] p = l[0];
            double y1 = p[1];
            double[] p1 = l[l.Count - 1];
            double y2 = p1[1];
            Series sb = new Series();
            for (int i = 0; ; i++)
            {
                double yy = y2 + i * step;
                if (yy > y2)
                {
                    sb.AddXY(y2, p[0]);
                    break;
                }
                double x = CaclulateDecreasingInvertedFunction(l, yy);
                sb.AddXY(yy, x);
            }
            return sb;
        }

        /// <summary>
        /// Calculates value of equal step
        /// </summary>
        /// <param name="x">Argument</param>
        /// <returns>Value</returns>
        public double CalculateEqualStep(double x)
        {
            List<double[]> l = Points;
            double x1 = l[0][0];
            double x2 = l[1][0];
            double s = x2 = x1;
            double dx = (x - x1) / s;
            int n = (int)dx;
            if (n >= l.Count)
            {
                return l[l.Count - 1][1];
            }
            return LinearInterpolation(x, l[n], l[n + 1]);
        }

        /// <summary>
        /// The is increasing sign
        /// </summary>
        public virtual bool IsIncreasing
        {
            get
            {
                List<double[]> l = Points;
                double[] p1 = l[0];
                double[] p2 = l[l.Count - 1];
                double y1 = p1[1];
                double y2 = p2[1];
                return y2 > y1;
            }
        }

        /// <summary>
        /// Inverted function
        /// </summary>
        /// <param name="x">Argument</param>
        /// <returns>Value of inverted function</returns>
        public virtual double InvertedFunction(double x)
        {
            return InvertedFunction(Points, x);
        }

        /// <summary>
        /// Inverted function
        /// </summary>
        /// <param name="l">Values</param>
        /// <param name="x">Argument</param>
        /// <returns>Value of inverted function</returns>
        public static double InvertedFunction(List<double[]> l, double x)
        {
            double[] p1 = l[0];
            double[] p2 = l[l.Count - 1];
            double y1 = p1[1];
            double y2 = p2[1];
            if (y2 > y1)
            {
                return CaclulateIncreasingInvertedFunction(l, x);
            }
            return CaclulateDecreasingInvertedFunction(l, x);
        }

        /// <summary>
        /// Points
        /// </summary>
        public List<double[]> Points
        {
            get { return points; }
        }

        /// <summary>
        /// Creates correspond xml
        /// </summary>
        /// <param name="doc">document to create element</param>
        /// <returns>The created element</returns>
        public XmlElement ExportToXml(XmlDocument doc)
        {
            doc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><Series/>");
            foreach (double[] p in points)
            {
                XmlElement ep = doc.CreateElement("PlotPoint");
                XmlAttribute ax = doc.CreateAttribute("PlotX");
                ax.Value = "" + p[0];
                ep.Attributes.Append(ax);
                XmlAttribute ay = doc.CreateAttribute("PlotY");
                ay.Value = "" + p[1];
                ep.Attributes.Append(ay);
                doc.DocumentElement.AppendChild(ep);
            }
            return doc.DocumentElement;
        }

        /// <summary>
        /// Export to xml
        /// </summary>
        public XmlDocument Xml
        {
            get
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><Series/>");
                CreateElements(doc, doc.DocumentElement);
                return doc;
            }
            set
            {
                points.Clear();
                XmlElement e = value.DocumentElement;
                Load(e);
            }
        }

        /// <summary>
        /// Exports array of series to single document
        /// </summary>
        /// <param name="seriesArray">Array of series</param>
        /// <returns></returns>
        public static XmlDocument Export(Series[] seriesArray)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><SeriesCollection/>");
            foreach (Series s in seriesArray)
            {
                XmlElement e = doc.CreateElement("Series");
                doc.DocumentElement.AppendChild(e);
                s.CreateElements(doc, e);
            }
            return doc;
        }

        /// <summary>
        /// Imports series collecion from document
        /// </summary>
        /// <param name="doc">The document</param>
        /// <returns>Collection of series</returns>
        public static Series[] ImportSeriesCollection(XmlDocument doc)
        {
            XmlNodeList l = doc.DocumentElement.GetElementsByTagName("Series");
            List<Series> ls = new List<Series>();
            foreach (XmlElement e in l)
            {
                Series s = new Series();
                s.Load(e);
                ls.Add(s);
            }
            return ls.ToArray();
        }

        /// <summary>
        /// Calculates increasing inverted function
        /// </summary>
        /// <param name="l">Values</param>
        /// <param name="y">Argument</param>
        /// <returns>Value of inverted function</returns>
        public static double CaclulateIncreasingInvertedFunction(IList<double[]> l, double y)
        {
            double[] p = l[0];
            for (int i = 1; i < l.Count; i++)
            {
                double[] p1 = l[i];
                if (y < p1[1])
                {
                    return LinearInterpolation(y, p, p1);
                }
                p = p1;
            }
            return 0;
        }


        /// <summary>
        /// Calculates increasing inverted function
        /// </summary>
        /// <param name="l">Values</param>
        /// <param name="y">Argument</param>
        /// <returns>Value of inverted function</returns>
        public static double CaclulateDecreasingInvertedFunction(IList<double[]> l, double y)
        {
            double[] p = l[l.Count - 1];
            for (int i = l.Count - 2; i >= 0; i--)
            {
                double[] p1 = l[i];
                if (y > p1[1])
                {
                    return LinearInterpolation(y, p, p1);
                }
                p = p1;
            }
            return 0;
        }


        /// <summary>
        /// Linear interpolation
        /// </summary>
        /// <param name="x">Argument</param>
        /// <param name="x1">x1</param>
        /// <param name="y1">y1</param>
        /// <param name="x2">x2</param>
        /// <param name="y2">y2</param>
        /// <returns>Interpolated value</returns>
        public static double LinearInterpolation(double x, double x1, double y1, double x2, double y2)
        {
            return y1 + (((y2 - y1) * (x - x1)) / (x2 - x1));
        }

        /// <summary>
        /// Linear interpolation
        /// </summary>
        /// <param name="x">Argument</param>
        /// <param name="p1">Point 1</param>
        /// <param name="p2">Point 2</param>
        /// <returns>Interpolated value</returns>
        public static double LinearInterpolation(double x, double[] p1, double[] p2)
        {
            return LinearInterpolation(x, p1[0], p1[1], p2[0], p2[1]);
        }

        /// <summary>
        /// Copies from another series
        /// </summary>
        /// <param name="s">Pattern series</param>
        public void CopyFrom(Series s)
        {
            points.Clear();
            for (int i = 0; i < s.Count; i++)
            {
                AddXY(s[i, 0], s[i, 1]);
            }
            step = 0;
            CheckEqualStep();
        }


        /// <summary>
        /// Adds point
        /// </summary>
        /// <param name="x">x - coordinate</param>
        /// <param name="y">y - coordinate</param>
        public virtual void AddXY(double x, double y)
        {
            if (Double.IsNaN(x) | Double.IsNaN(y) | Double.IsInfinity(x) | Double.IsInfinity(y))
            {
                throw new Exception("Infinity");
            }
            points.Add(new double[] { x, y });
        }

        /// <summary>
        /// Access to i - th point (j = 0 access to x - coordinate, j = 1 access to y coordinate)
        /// </summary>
        public double this[int i, int j]
        {
            get
            {
                double[] x = points[i] as double[];
                return x[j];
            }
        }

        /// <summary>
        /// Clears itself
        /// </summary>
        public virtual void Clear()
        {
            points.Clear();
        }

        /// <summary>
        /// Count of points
        /// </summary>
        public int Count
        {
            get
            {
                return points.Count;
            }
        }

        /// <summary>
        /// Size of this series
        /// </summary>
        public double[,] Size
        {
            get
            {
                double[,] size = new double[2, 2];
                for (int i = 0; i < points.Count; i++)
                {
                    double[] x = (double[])points[i];
                    if (i == 0)
                    {
                        size[0, 0] = x[0];
                        size[0, 1] = x[1];
                        size[1, 0] = x[0];
                        size[1, 1] = x[1];
                        continue;
                    }
                    for (int j = 0; j < 2; j++)
                    {
                        if (x[j] < size[0, j])
                        {
                            size[0, j] = x[j];
                        }
                        if (x[j] > size[1, j])
                        {
                            size[1, j] = x[j];
                        }
                    }
                }
                return size;
            }
        }

 
        /// <summary>
        /// Access to value of function and its derivation
        /// </summary>
        public double[] this[double x]
        {
            get
            {
                if (this[0, 0] > x)
                {
                    //throw new Exception("Argument too small");
                    parameter[0] = this[0, 1];
                    parameter[1] = 0;
                    return parameter;
                }
                if (this[Count - 1, 0] < x)
                {
                    //throw new Exception("Argument too large");
                    parameter[0] = this[Count - 1, 1];
                    parameter[1] = 0;
                    return parameter;
                }
                if (step != 0)
                {
                    int i = (int)(Math.Floor((x - this[0, 0]) / step));
                    if (i == Count - 1)
                    {
                        --i;
                    }
                    double x1 = this[i, 0];
                    double x2 = this[i + 1, 0];
                    double y1 = this[i, 1];
                    double y2 = this[i + 1, 1];
                    parameter[1] = (y2 - y1) / (x2 - x1);
                    parameter[0] = y1 + parameter[1] * (x - x1);
                    return parameter;
                }
                for (int i = 1; i < Count; i++)
                {
                    double x2 = this[i, 0];
                    if (x2 > x)
                    {
                        double x1 = this[i - 1, 0];
                        double y1 = this[i - 1, 1];
                        double y2 = this[i, 1];
                        parameter[1] = (y2 - y1) / (x2 - x1);
                        parameter[0] = y1 + parameter[1] * (x - x1);
                        break;
                    }
                }
                return parameter;
            }
        }

        #endregion

        #region Proected Members

        /// <summary>
        /// Checks whether series has equal step
        /// </summary>
        protected void CheckEqualStep()
        {
            if (points.Count < 2)
            {
                return;
            }
            double s = 0;
            double t = 0;
            for (int i = 0; i < points.Count; i++)
            {
                double[] p = points[i] as double[];
                if (i == 1)
                {
                    s = p[0] - t;
                }
                if (i > 1)
                {
                    if (Math.Abs(s - (p[0] - t)) > (eps * Math.Abs(s)))
                    {
                        return;
                    }
                }
                t = p[0];
            }
            step = s;
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Creates Elements
        /// </summary>
        /// <param name="doc">document</param>
        /// <param name="e">root element</param>
        void CreateElements(XmlDocument doc, XmlElement e)
        {
            foreach (double[] p in points)
            {
                XmlElement ep = doc.CreateElement("PlotPoint");
                XmlAttribute ax = doc.CreateAttribute("PlotX");
                ax.Value = p[0].Convert();
                ep.Attributes.Append(ax);
                XmlAttribute ay = doc.CreateAttribute("PlotY");
                ay.Value = p[1].Convert();
                ep.Attributes.Append(ay);
                e.AppendChild(ep);
            }
        }

        /// <summary>
        /// Loads from element
        /// </summary>
        /// <param name="e">The element</param>
        void Load(XmlElement e)
        {
            foreach (XmlElement el in e.ChildNodes)
            {
                AddXY(el.Attributes["PlotX"].Value.Convert(), el.Attributes["PlotY"].Value.Convert());
            }
        }

        #endregion

        #endregion

    }
}
