using System;
using System.Collections.Generic;
using System.Text;

namespace CommonMathOperations
{
    /// <summary>
    /// Solver of different math equations
    /// </summary>
    public static class Solver
    {

        /// <summary>
        /// Iteration solving of equation x = function(x)
        /// </summary>
        /// <param name="function">The function</param>
        /// <param name="start">Start x value</param>
          /// <param name="maxIter">The maximal quantity of iterations</param>
        /// <param name="eps">Accuracy</param>
        /// <returns>The solution result</returns>
        static public double Solve(this Func<double, double> function, double start, int maxIter, double eps)
        {
            double x1 = start;
            double x2 = 0;
            for (int i = 0; i < maxIter; i++)
            {
                x2 = function(x1);
                if (Math.Abs(x1 - x2) < eps)
                {
                    return x2;
                }
                x1 = x2;
            }
            return x2;
        }

        /// <summary>
        /// Solves fixed iteration
        /// </summary>
        /// <param name="func">Function</param>
        /// <param name="maxIter">Number of iterstion</param>
        /// <param name="x0">First approximation value</param>
        /// <param name="error">Error</param>
        /// <returns>Solution</returns>
        public static double SolveIterationFixed(this Func<double, double> func, int maxIter, double x0, out double error)
        {
            double x = 0;
            double x2 = x0;

            for (int i = 0; i < maxIter; i++)
            {
                x = x2;
                x2 = func(x);
            }
            error = x2 - x;
            return x2;
        }

        /// <summary>
        /// Solve equation function(x) = 0 by bisection
        /// </summary>
        /// <param name="function">The function</param>
        /// <param name="lower">The lower boundary</param>
        /// <param name="upper">The upper boundary</param>
        /// <param name="eps">Accuracy</param>
        /// <returns>The solution result</returns>
        static public double Bisection(this Func<double, double> function, double lower, double upper, double eps)
        {
            double l = function(lower);
            double u = function(upper);
            double x = 0;
            if (l == 0)
            {
                return l;
            }
            if (u == 0)
            {
                return u;
            }
            if (l < 0)
            {
                if (u < 0)
                {
                    throw new Exception();
                }
            }
            else
            {
                x = u;
                u = l;
                l = x;
                if (l > 0 & u < 0)
                {
                    throw new Exception();
                }
            }
            while (true)
            {
                x = 0.5 * (u + l);
                if (function(x) > 0)
                {
                    u = x;
                }
                else
                {
                    l = x;
                }
                if (2 * Math.Abs(u - l) < eps)
                {
                    break;
                }
            }
            return x;
        }
    }
}
