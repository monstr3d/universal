using System;
using System.Collections.Generic;
using System.Text;

namespace OrdinaryDifferentialEquations
{
    /// <summary>
    /// Runge–Kutta solver of forth order
    /// </summary>
    public class Runge4Solver : IDifferentialEquationSolver
    {

        #region Fields

        /// <summary>
        /// The singleton
        /// </summary>
        static public readonly Runge4Solver Singleton = new Runge4Solver();

        private IDifferentialEquationsSystem system;

        static private readonly double a3 = 1.0 / 3.0;

        static private readonly string[] names = new string[] { "Runge-Kutt Method?Order=4" };


        private double[] a = new double[5];

        private double h;


        private double[] xold;


        private double[] y;


        private double[] z;


        private int n;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        private Runge4Solver()
        {
        }

        #endregion

        #region IDifferentialEquationSolver Members

        IDifferentialEquationsSystem IDifferentialEquationSolver.System
        {
            get
            {
                return system;
            }
            set
            {
                system = value;
                n = system.Count;
                xold = new double[n];
                y = new double[n];
                z = new double[n];
            }
        }

        void IDifferentialEquationSolver.Step(double timeBegin, double timeEnd)
        {
            h = timeEnd - timeBegin;
            double h2 = 0.5 * h;
            a[0] = h2;
            a[1] = h2;
            a[2] = h;
            a[3] = h;
            a[4] = h2;
            double time = timeBegin;
            double[] st = system.State;
            Array.Copy(st, xold, n);
            Array.Copy(st, y, n);
            for (int i = 0; i < 4; i++)
            {
                system.Calculate(time, z);
                time += timeBegin + a[i];
                double a1 = a3 * a[i];
                double a2 = a[i + 1];
                for (int j = 0; j < n; j++)
                {
                    double d = z[j];
                    y[j] += a1 * d;
                    st[j] = xold[j] + a2 * d;
                }
            }
            Array.Copy(y, st, n);
        }

        string[] IDifferentialEquationSolver.Names
        {
            get { return names; }
        }

        IDifferentialEquationSolver IDifferentialEquationSolver.this[string name]
        {
            get
            {
                return new Runge4Solver();
            }
        }

        #endregion
    }
}
