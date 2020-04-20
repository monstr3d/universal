using System;
using System.Collections.Generic;
using System.Text;

namespace CommonMathOperations
{
    /// <summary>
    /// Integration of one variable functions;
    /// </summary>
    public class Integration
    {
        //static readonly int int_max = 33;

        /// <summary>
        /// Buffer for sympson integral
        /// </summary>
        static readonly double[,] sympsonBuffer = new double[33, 3];


        public Integration()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// Integration by sympson method
        /// </summary>
        /// <param name="f">Integand</param>
        /// <param name="a">Left limit</param>
        /// <param name="b">Right limit</param>
        /// <param name="eps">Accuracy</param>
        /// <returns>The integral</returns>
        public static double Sympson(Func<double, double> f, double a, double b, double eps)
        {
            int d = 1;
            int m = 0;
            int n = 0;
            double y = 0;
            double x = a;
            double g0 = f(x);
            x = 0.5 * (a + b);
            double g2 = f(x);
            x = b;
            double g4 = f(x);
            double a0 = 0.5 * (b - a) * (g0 + (4 * g2) + g4);
            while (true)
            {
                while (true)
                {
                    double h = (b - a) / (4.0 * (double)d);
                    x = (double)((4 * m + 1)) * h + a;
                    double g1 = f(x);
                    x = (double)((4 * m) + 3) * h + a;
                    double g3 = f(x);
                    double a1 = (g0 + (4 * g1) + g2) * h;
                    double a2 = (g2 + (4 * g3) + g4) * h;
                    if ((Math.Abs(a1 + a2 - a0) >= eps / (double)d) & (n < sympsonBuffer.GetLength(0)))
                    {
                        m *= 2;
                        ++n;
                        d *= 2;
                        a0 = a1;
                        sympsonBuffer[n - 1, 0] = a2;
                        sympsonBuffer[n - 1, 1] = g3;
                        sympsonBuffer[n - 1, 2] = g4;
                        g4 = g2;
                        g2 = g1;
                    }
                    else
                    {
                        goto m1;
                    }
                m1:
                    ++m;
                    y += a1 + a2;
                    while (true)
                    {
                        if (m == (int)(2 * Math.Floor(0.5 * (double)m)))
                        {
                            m = (int)(0.5 * (double)m);
                            --n;
                            d = (int)(0.5 * (double)d);
                        }
                        else
                        {
                            goto m2;
                        }
                    }
                }
            m2:
                if (n != 0)
                {
                    a0 = sympsonBuffer[n - 1, 0];
                    g0 = g4;
                    g2 = sympsonBuffer[n, 1];
                    g4 = sympsonBuffer[n - 1, 2];
                    break;
                }
                else
                {
                    break;
                }
            }
            return y / 3;
        }
    }
}
