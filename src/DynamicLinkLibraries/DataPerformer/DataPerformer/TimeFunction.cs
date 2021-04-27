using System;
using System.Collections.Generic;
using System.Text;

using BaseTypes.Interfaces;


using FormulaEditor;
using FormulaEditor.Interfaces;

namespace DataPerformer
{
    /// <summary>
    /// Time function
    /// </summary>
    class TimeFunction : IOneVariableFunction, IPowered
    {

        #region Fields

        internal static readonly IOneVariableFunction Object = new TimeFunction();
        private readonly static Double a = 0;
        private bool haseq = true;
        object type;
        double start = 0;
        double fin = 0;
        double step;
        private object[,] data;

        private int degree;


        #endregion

        #region Ctor

        private TimeFunction()
        {
        }

        internal TimeFunction(int size, object type)
        {
            this.type = type;
            data = new object[size, 2];
        }

        #endregion

        #region IOneVariableFunction Members

        object IOneVariableFunction.VariableType
        {
            get { return a; }
        }

        #endregion

        #region IObjectOperation Members

        object[] IObjectOperation.InputTypes
        {
            get { return new object[] { (double)0 }; }
        }


        object IObjectOperation.this[object[] x]
        {
            get
            {
                int l = data.GetLength(0);
                /*if (haseq < 0)
                {
                    bool b = true;
                    start = (double)data[0, 0];
                    fin = (double)data[data.GetLength(0) - 1, 0];
                    double d = (double)data[1, 0] - start;
                    for (int i = 2; i < l; i++)
                    {
                        double f = (double)data[i, 0] - (double)data[i - 1, 0];
                        if (Math.Abs(f - d) > 1E-12)
                        {
                            b = false;
                            break;
                        }
                    }
                    haseq = b ? 1 : 0;
                    step = d;
                }*/
                start = (double)data[0, 0];
                step = (double)data[1, 0] - (double)data[0, 0];
                int num = 0;
                double t = (double)x[0];
                if (haseq)
                {
                    num = (int)((t - start) / step);
                }
                else
                {
                    if (t < start)
                    {
                        num = -1;
                    }
                    if (t > fin)
                    {
                        num = l + 1;
                    }
                }

                if (num < 0)
                {
                    return data[0, 1];
                }
                if (num >= l)
                {
                    return data[l - 1, 1];
                }
                if (!type.Equals(a))
                {
                    return data[num, 1];
                }
                if (degree > 1 & degree < data.GetLength(0))
                {
                    return calc(num, t);
                }
                double y1 = (double)data[num, 1];
                double y2 = (double)data[num + 1, 1];
                double x1 = (double)data[num, 0];
                double x2 = (double)data[num + 1, 0];
                return y1 + (y2 - y1) * (t - x1) / step;
            }
        }

        

        object IObjectOperation.ReturnType
        {
            get { return type; }
        }

        bool IPowered.IsPowered
        {
            get { return false; }
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// Sets i - th argument and value
        /// </summary>
        /// <param name="i">The "i"</param>
        /// <param name="x">The argument</param>
        /// <param name="y">The value</param>
        internal void Set(int i, double x, object y)
        {
           // haseq = -1;
            data[i, 0] = x;
            data[i, 1] = Clone(y);
        }

        /// <summary>
        /// Degree
        /// </summary>
        internal int Degree
        {
            set
            {
                degree = value;
            }
        }

        double calc(int num, double t)
        {
            int n = num;
            if (n + degree >= data.GetLength(0))
            {
                n = data.GetLength(0) - degree - 2;
            }
            return RealMatrixProcessor.RealMatrix.LagrangeInterpolation(t, degree, n, data);
        }

        object Clone(object o)
        {
            if (o is Array)
            {
                Array arr = o as Array;
                return arr.Clone();
            }
            return o;
        }


        #endregion
    }
}
