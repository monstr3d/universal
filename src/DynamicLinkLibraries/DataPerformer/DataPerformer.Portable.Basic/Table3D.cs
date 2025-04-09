using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataPerformer.Portable.Basic
{
    /// <summary>
    /// 3D Table
    /// </summary>
    public class Table3D
    {
        #region Fields
        /// <summary>
        /// Results of calculation
        /// </summary>
        protected double[] result = new double[2];


        /// <summary>
        /// Arguments values
        /// </summary>
        protected double[][] args = new double[3][];

        /// <summary>
        /// Function values
        /// </summary>
        protected double[,,] fun;

        /// <summary>
        /// Arguments
        /// </summary>
        protected double[] arg = new double[3];



        /// <summary>
        /// Grid node coordinates
        /// </summary>
        protected int[] nm = new int[3];


        /// <summary>
        /// derivations
        /// </summary>
        protected double[] der = new double[3];


        /// <summary>
        /// The "throws out of range exception" sign
        /// </summary>
        protected bool throwsOutOfRangeException = true;

        /// <summary>
        /// Step for partial derivation
        /// </summary>
        protected double[] dx = new double[3];

        /// <summary>
        /// Tags of arguments
        /// </summary>
        private static readonly string[] argumentTags = new string[] { "ArgumentX", "ArgumentY", "ArgumentZ" };

        /// <summary>
        /// Tags of arguments
        /// </summary>
        private static readonly string[] argumentAttr = new string[] { "nX", "nY", "nZ" };

        private const string Value = "Value";

        private const string Values = "Values";

        /// <summary>
        /// Comments
        /// </summary>
        protected byte[] comments = null;



        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        protected Table3D()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="arguments">Values of arguments</param>
        /// <param name="function">Values of function</param>
        public Table3D(double[][] arguments, double[,,] function)
        {
            Set(arguments, function);
        }


        #endregion

        #region Public Members

        /// <summary>
        /// Sets parameters
        /// </summary>
        /// <param name="arguments">Values of arguments</param>
        /// <param name="function">Values of function</param>
        public void Set(double[][] arguments, double[,,] function)
        {
            for (int i = 0; i < 3; i++)
            {
                if (arguments[i].Length != function.GetLength(i))
                {
                    throw new ErrorHandler.OwnException("Illegal dimension of Table3D");
                }
            }
            args = arguments;
            fun = function;
        }


        /// <summary>
        /// Calculates value of function
        /// </summary>
        /// <param name="x">X - argument</param>
        /// <param name="y">Y - argument</param>
        /// <param name="z">Z - argument</param>
        /// <returns>Value of function</returns>
        public double this[double x, double y, double z]
        {
            get
            {
                return Calculate(x, y, z);
            }
        }


        /// <summary>
        /// Xml import / export
        /// </summary>
        public XElement Xml
        {
            get
            {
                XElement e = XElement.Parse("<?xml version=\"1.0\" encoding=\"utf-8\"?><Table2D/>");
               
                /* XmlDocument doc = new XmlDocument();
                 doc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><Table2D/>");
                 XmlElement el = doc.DocumentElement;*/
                 for (int i = 0; i < 3; i++)
                 {
                     e.SetAttributeValue(argumentAttr[i], args[i].Length + "");
                 }
                 for (int i = 0; i < 3; i++)
                 {
                     XElement et = XElement.Parse("<" + argumentTags[i] + "/>");
                     string attr = argumentAttr[i];
                     e.Add(et);
                     int n = args[i].Length;
                     double[] ar = args[i];
                     for (int j = 0; j < n; j++)
                     {
                        XElement v = XElement.Parse("<" + ar[j] + "/>");
                        et.Add(v);
                       //  XmlElement v = doc.AppendValue(et, ar[j]);
                         v.SetAttributeValue(attr, j + "");
                     }
                 }
            /*    XElement vals = XElement.Parse("<" + Values + "/>");
                e.Add(vals);
                 for (int i = 0; i < fun.GetLength(0); i++)
                 {
                     for (int j = 0; j < fun.GetLength(1); j++)
                     {
                         for (int k = 0; k < fun.GetLength(2); k++)
                         {
                             XmlElement v = doc.AppendValue(vals, fun[i, j, k]);
                             v.SetAttribute(argumentAttr[0] + "", i + "");
                             v.SetAttribute(argumentAttr[1] + "", j + "");
                             v.SetAttribute(argumentAttr[2] + "", k + "");
                         }
                     }
                 }
                 return doc;*/
                return null;
            }
            set
            {
                /* !!!!!!
                XmlElement e = value.DocumentElement;
                int[] n = new int[3];
                for (int i = 0; i < 3; i++)
                {
                    string attr = argumentAttr[i];
                    int k = Int32.Parse(e.GetAttribute(attr));
                    n[i] = k;
                    double[] a = new double[k];
                    args[i] = a;
                    XmlElement el = e.GetElementsByTagName(argumentTags[i])[0] as XmlElement;
                    foreach (XmlElement nd in el.ChildNodes)
                    {
                        int p = Int32.Parse(nd.GetAttribute(attr));
                        double v = nd.InnerText.Convert();
                        a[p] = v;
                    }
                }
                fun = new double[args[0].Length, args[1].Length, args[2].Length];
                XmlElement vals = e.GetElementsByTagName(Values)[0] as XmlElement;
                foreach (XmlElement el in vals.ChildNodes)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        n[i] = Int32.Parse(el.GetAttribute(argumentAttr[i]));
                    }
                    double val = el.InnerText.Convert();
                    fun[n[0], n[1], n[2]] = val;
                }*/
            }
        }

        /// <summary>
        /// Count of x coordinates
        /// </summary>
        public int XCount
        {
            get
            {
                return args[0].Length;
            }
        }


        /// <summary>
        /// Count of y coordinates
        /// </summary>
        public int YCount
        {
            get
            {
                return args[1].Length;
            }
        }

        /// <summary>
        /// Gets i - th x coordinate
        /// </summary>
        /// <param name="i">Coordinate number</param>
        /// <returns>The coordinate</returns>
        public double GetX(int i)
        {
            return args[0][i];
        }

        /// <summary>
        /// Gets i - th y coordinate
        /// </summary>
        /// <param name="i">Coordinate number</param>
        /// <returns>The coordinate</returns>
        public double GetY(int i)
        {
            return args[1][i];
        }

        /// <summary>
        /// Bounds of arguments
        /// </summary>
        public double[,] Bounds
        {
            get
            {
                double[,] b = new double[2, 2];
                b[0, 0] = args[0][0];
                b[0, 1] = args[0][args[0].Length - 1];
                b[1, 0] = args[1][0];
                b[1, 1] = args[1][args[1].Length - 1];
                return b;
            }
        }


        /// <summary>
        /// Array of extremums
        /// </summary>
      /*  public double[] Extremums
        {
            get
            {
                double[] e = new double[] { fun[0, 0], fun[0, 0] };
                for (int i = 0; i < fun.GetLength(0); i++)
                {
                    for (int j = 0; j < fun.GetLength(1); j++)
                    {
                        double x = fun[i, j];
                        if (x < e[0])
                        {
                            e[0] = x;
                        }
                        if (x > e[1])
                        {
                            e[1] = x;
                        }
                    }
                }
                return e;
            }
        }*/


        /// <summary>
        /// Access to i, j, k function
        /// </summary>
        public double this[int i, int j, int k]
        {
            get
            {
                return fun[i, j, k];
            }
        }

        /// <summary>
        /// The "throws out of range exception" sign
        /// </summary>
        public bool ThrowsOutOfRangeException
        {
            get
            {
                return throwsOutOfRangeException;
            }
            set
            {
                throwsOutOfRangeException = value;
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Calculates value of function
        /// </summary>
        /// <param name="x">X - argument</param>
        /// <param name="y">Y - argument</param>
        /// <param name="z">Z - argument</param>
        /// <returns>Value of function</returns>
        protected double Calculate(double x, double y, double z)
        {
            arg[0] = x;
            arg[1] = y;
            arg[2] = z;
            for (int i = 0; i < 3; i++)
            {
                if ((arg[i] < args[i][0]) | (arg[i] > args[i][args[i].Length - 1]))
                {
                    if (throwsOutOfRangeException)
                    {
                        throw new ErrorHandler.OwnException("Out of range");
                    }
                }
                for (int j = 0; j < args[i].Length - 1; j++)
                {
                    if (arg[i] >= args[i][j] & arg[i] <= args[i][j + 1])
                    {
                        nm[i] = j;
                        goto m;
                    }
                }
                nm[i] = args[i].Length - 1;
            m:
                continue;
            }
            double f = fun[nm[0], nm[1], nm[2]];
            result[0] = f;
            result[1] = 0;
            double delta = 0;
            for (int i = 0; i < 2; i++)
            {
                double d = 0;
                if (i == 0)
                {
                    int k = nm[0] + 1;
                    if (k >= args[0].Length)
                    {
                        k = args[0].Length - 1;
                    }
                    d = fun[k, nm[1], nm[2]];
                    delta = args[0][k] - args[0][nm[0]];
                }
                else
                {
                    int k = nm[1] + 1;
                    if (k >= args[1].Length)
                    {
                        k = args[1].Length - 1;
                    }
                    d = fun[nm[0], k, k];
                    delta = args[1][k] - args[1][nm[1]];
                }
                dx[i] = (d - f) / delta;
                result[0] += dx[i] * (arg[i] - args[i][nm[i]]);
            }
            return result[0];
        }


        /// <summary>
        /// Pre initialization
        /// </summary>
        protected virtual void PreInit()
        {
        }

        /// <summary>
        /// Gets function value
        /// </summary>
        /// <returns>The value</returns>
        protected object GetFunction()
        {
            return result[0];
        }


        #endregion
    }
}
