using System;
using System.Collections.Generic;
using System.Text;

using OrdinaryDifferentialEquations;

using RealMatrixProcessor;

using ClassicalAlgebra;

namespace ControlSystems
{
    /// <summary>
    /// Rational transformation function
    /// </summary>
    public class RationalTransformControlSystemFunction : IDifferentialEquationsSystem
    {
        #region Fields

        protected RealMatrix realMatrix = new();
        protected static RealMatrix rm = new();

        /// <summary>
        /// Solver of differential equations
        /// </summary>
        private IDifferentialEquationSolver solver;

        /// <summary>
        /// Nominator
        /// </summary>
        protected double[] nom;

        /// <summary>
        /// Denominator
        /// </summary>
        protected double[] denom;

        /// <summary>
        /// State
        /// </summary>
        protected double[] state;

        /// <summary>
        /// Initial state
        /// </summary>
        double[] initialState;

        /// <summary>
        /// Count of variables
        /// </summary>
        int count;

        /// <summary>
        /// The "should stable" sign 
        /// </summary>
        protected bool shouldStable = true;

        /// <summary>
        /// Laplace Transform Letter
        /// </summary>
        static private char laplaceTransformChar = 's';

        protected double action;

        protected double maxderi;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nom">Nominator</param>
        /// <param name="denom">Denominator</param>
        public RationalTransformControlSystemFunction(double[] nom, double[] denom)
        {
            Set(nom, denom);
        }

        #endregion

        #region IDifferentialEquationsSystem Members

        double[] IDifferentialEquationsSystem.InitialState
        {
            get { return initialState; }
        }

        int IDifferentialEquationsSystem.Count
        {
            get { return count; }
        }

        double[] IDifferentialEquationsSystem.State
        {
            get { return state; }
        }

        void IDifferentialEquationsSystem.Calculate(double time, double[] derivations)
        {
            for (int i = 0; i < count - 1; i++)
            {
                derivations[i] = state[i + 1];
            }
            double a = action;
            for (int i = 0; i < count; i++)
            {
                a -= denom[i] * state[i];
            }
            maxderi = a;
            derivations[count - 1] = a;
        }

        #endregion

        #region Members

        /// <summary>
        /// Calculates derivations
        /// </summary>
        /// <param name="derivations">Derivations</param>
        public void CalculateDerivations(double[] derivations)
        {
            for (int i = 0; i < denom.Length - nom.Length + 1; i++)
            {
                double a = 0;
                for (int j = 0; i + j < state.Length & j < nom.Length; j++)
                {
                    a += nom[j] * state[i + j];
                }
                derivations[i] = a;
            }
            derivations[derivations.Length - 1] = maxderi;
        }


        /// <summary>
        /// Solver
        /// </summary>
        public IDifferentialEquationSolver Solver
        {
            set
            {
                solver = value;
                solver.System = this;
            }
        }

        /// <summary>
        /// The "should stable" sign 
        /// </summary>
        public virtual bool ShouldStable
        {
            get
            {
                return shouldStable;
            }
            set
            {
                shouldStable = value;
            }
        }

        /// <summary>
        /// The "is stable" sign
        /// </summary>
        public bool IsStable
        {
            get
            {
                return IsStablePolynom(denom);
            }
        }

        /// <summary>
        /// Steps
        /// </summary>
        /// <param name="timeBegin">Begin time</param>
        /// <param name="timeEnd">End time</param>
        /// <param name="action">Right action</param>
        public void Step(double timeBegin, double timeEnd, double action)
        {
            this.action = action;
            solver.Step(timeBegin, timeEnd);
        }

        /// <summary>
        /// Transformation
        /// </summary>
        /// <param name="timeBegin">Begin time</param>
        /// <param name="timeEnd">End time</param>
        /// <param name="action">Right action</param>
        /// <returns>Transformation result</returns>
        public double Transform(double timeBegin, double timeEnd, double action)
        {
            Step(timeBegin, timeEnd, action);
            return Output;
        }

        /// <summary>
        /// Output
        /// </summary>
        public double Output
        {
            get
            {
                double a = 0;
                for (int i = 0; i < nom.Length & i < state.Length; i++)
                {
                    a += nom[i] * state[i];
                }
                if (nom.Length == denom.Length)
                {
                    a += nom[nom.Length - 1] * maxderi;
                }
                return a;
            }
        }

        /// <summary>
        /// High frequency coefficient
        /// </summary>
        public double HighFrequecyCoefficient
        {
            get
            {
                if (denom.Length > nom.Length)
                {
                    return 0;
                }
                int n = nom.Length - 1;
                return nom[n] / denom[n];
            }
        }


        /// <summary>
        /// Order of nominator
        /// </summary>
        public int NomOrder
        {
            get
            {
                for (int i = 0; i < nom.Length; i++)
                {
                    if (Math.Abs(nom[i]) > 0)
                    {
                        return i;
                    }
                }
                return 0;
            }
        }

        /// <summary>
        /// Norms of denominator roots
        /// </summary>
        public double[] DenomRootNorms
        {
            get
            {
                return StaticExtensionClassicalAlgebra.GetNorms(denom);
            }
        }

        /// <summary>
        /// Roots of nominatror
        /// </summary>
        public double[] NomRootNorms
        {
            get
            {
                if (nom.Length > 1)
                {
                    return StaticExtensionClassicalAlgebra.GetNorms(nom);
                }
                return null;
            }
        }


        /// <summary>
        /// Coefficient
        /// </summary>
        public double Coefficient
        {
            get
            {
                return nom[0] / denom[0];
            }
        }


        /// <summary>
        /// Matrix of classical Rauss–Gurvitz stability
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static double[,] GetGurvitzMatrix(double[] p)
        {
            int dim = p.Length;
            int n = dim - 1;
            double[,] a = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                int k = i + 1;
                for (int j = 0; j < n; j++)
                {
                    int l = k - j;
                    l = dim - l;
                    if ((l < 0) | (l >= dim))
                    {
                        a[j, i] = 0;
                    }
                    else
                    {
                        a[j, i] = p[l];
                    }
                }
            }
            return a;
        }


        /// <summary>
        /// Checks stability of polynom
        /// </summary>
        /// <param name="polynom">Polynom</param>
        /// <returns>True if stable and false otherwise</returns>
        public static bool IsStablePolynom(double[] polynom)
        {
            if (polynom.Length == 1)
            {
                return true;
            }
            if (polynom.Length == 2)
            {
                return (polynom[0] * polynom[1]) > 0;
            }
            double[,] a = GetGurvitzMatrix(polynom);
            double det = rm.Det(a);
            if (det <= 0)
            {
                return false;
            }
            for (int i = 1; i < a.GetLength(0); i++)
            {
                double[,] b = rm.GetMainMinor(a, i);
                det = rm.Det(b);
                if (det <= 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Character of Laplace transformation
        /// </summary>
        public static char LaplaceTransformChar
        {
            get
            {
                return laplaceTransformChar;
            }
            set
            {
                laplaceTransformChar = value;
            }
        }


 


        /// <summary>
        /// Gets frequency characteristics
        /// </summary>
        /// <param name="frequency">Frequency</param>
        /// <param name="amplitude">Ampliture</param>
        /// <param name="phase">Phase</param>
        public void GetFrequencyCharacteristics(double frequency, out double amplitude, out double phase)
        {
            double nomRe;
            double nomIm;
            GetFrequencyChar(frequency, nom, out nomRe, out nomIm);
            double denomRe;
            double denomIm;
            GetFrequencyChar(frequency, denom, out denomRe, out denomIm);
            amplitude = Math.Sqrt(((nomRe * nomRe + nomIm * nomIm)) / ((denomRe * denomRe) + (denomIm * denomIm)));
            double p1 = Math.Atan2(nomIm, nomRe);
            double p2 = Math.Atan2(-denomIm, denomRe);
            double p = p1 + p2;
            if (p > Math.PI)
            {
                p -= Math.PI;
            }
            if (p < -Math.PI)
            {
                p += Math.PI;
            }
            phase = p;
        }

        /// <summary>
        /// Minimal and maximal frequency
        /// </summary>
        public double[] MinMaxFrequency
        {
            get
            {
                double[] d = AllNorms;
                return new double[] { d[0], d[d.Length - 1] };
            }
        }
        
        /// <summary>
        /// All norms of roots
        /// </summary>
        protected double[] AllNorms
        {
            get
            {
                double[] dn = DenomRootNorms;
                double[] n = NomRootNorms;
                List<double> l = new List<double>(dn);
                if (n != null)
                {
                    l.AddRange(n);
                }
                l.Sort();
                return l.ToArray();
            }
        }

        /// <summary>
        /// Sets transform function parameters
        /// </summary>
        /// <param name="nom">Nominator</param>
        /// <param name="denom">Denominator</param>
        protected void Set(double[] nom, double[] denom)
        {
            if (nom.Length > denom.Length)
            {
                throw new Exception("Illegal transformation");
            }
            this.nom = new double[nom.Length];
            this.denom = new double[denom.Length];
            double a = 1 / denom[denom.Length - 1];
            for (int i = 0; i < nom.Length; i++)
            {
                this.nom[i] = a * nom[i];
            }
            for (int i = 0; i < denom.Length; i++)
            {
                this.denom[i] = a * denom[i];
            }
            count = denom.Length - 1;
            state = new double[count];
            initialState = new double[count];

        }

        /// <summary>
        /// Gets frequency characteristics
        /// </summary>
        /// <param name="frequency">Frequency</param>
        /// <param name="p">Polynom</param>
        /// <param name="re">Real part</param>
        /// <param name="im">Image part</param>
        private static void GetFrequencyChar(double frequency, double[] p, out double re, out double im)
        {
            bool r = true;
            double sing = 1;
            double f = 1;
            re = 0;
            im = 0;
            for (int i = 0; i < p.Length; i++)
            {
                double x = f * p[i] * sing;
                if (r)
                {
                    re += x;
                }
                else
                {
                    im += x;
                    sing = -sing;
                }
                r = !r;
                f *= frequency;
            }
        }


        #endregion

    }
}
