using System;
using System.Collections.Generic;
using System.Text;

namespace SphericalFields
{

    /// <summary>
    /// Legendre polynomial
    /// </summary>
    public class LegendrePolynomial
    {
        #region Fields

        /// <summary>
        /// The n - parameter
        /// </summary>
        protected int n;

        /// <summary>
        /// The m parameter
        /// </summary>
        protected int m;

        /// <summary>
        /// Function 
        /// </summary>
        protected double[][] P;

        /// <summary>
        /// Derivation
        /// </summary>
        protected double[][] dP;

        /// <summary>
        /// Auxiliary values
        /// </summary>
        protected double[][] K;


        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public LegendrePolynomial()
        {
        }

        #endregion

        #region Specific Members

        protected void Init(int n, int m)
        {
            this.n = n;
            this.m = m;
            Init();
        }


        /// <summary>
        /// Initialization
        /// </summary>
        private void Init()
        {
            P = new double[n + 1][];
            dP = new double[n + 1][];
            K = new double[n + 1][];
            for (int i = 0; i < P.Length; i++)
            {
                P[i] = new double[i + 1];
                dP[i] = new double[i + 1];
                K[i] = new double[i + 1];

            }
            for (int i = 2; i < K.Length; i++)
            {
                for (int j = 0; j < K[i].Length; j++)
                {
                    double an = (double)i;
                    double am = (double)j;
                    double an1 = an - 1;
                    K[i][j] = ((an1 * an1) - (am * am)) / (((2 * an) - 1) * ((2 * an) - 3));
                }
            }
            P[0][0] = 1;
            K[1][0] = 0;
            K[1][1] = 0;
            dP[0][0] = 0;

        }

        /// <summary>
        /// Calculates polynom and its derivation
        /// </summary>
        /// <param name="st">Sin(theta)</param>
        /// <param name="ct">Cos(theta)</param>
        public void CalculateAll(double st, double ct)
        {
            CalculatePolynom(st, ct);
            CalcDerivation(st, ct);
        }

        /// <summary>
        /// Calculates polynom
        /// </summary>
        /// <param name="st">Sin(theta)</param>
        /// <param name="ct">Cos(theta)</param>
        public void CalculatePolynom(double st, double ct)
        {
            P[0][0] = 1;
            P[1][0] = st;
            P[1][1] = ct;
            for (int i = 2; i < (n + 1); i++)
            {
                P[i][i] = ct * P[i - 1][i - 1];
                for (int j = 0; j < i; j++)
                {
                    P[i][j] = st * P[i - 1][j];
                    if (j < i - 1)
                    {
                        P[i][j] -= K[i][j] * P[i - 2][j];
                    }
                }
            }
        }


        /// <summary>
        /// Fills trigonometric functions
        /// </summary>
        /// <param name="c">cosine</param>
        /// <param name="s">sin</param>
        /// <param name="cosArray">Array of cosine</param>
        /// <param name="sinArray">Array of sine</param>
        public static void FillSinCos(double c, double s, 
            double[] cosArray, double[] sinArray)
        {
            cosArray[0] = 1;
            sinArray[0] = 0;
            for (int i = 1; i < cosArray.Length; i++)
            {
                int j = i - 1;
                cosArray[i] = c * cosArray[j] - s * sinArray[j];
                sinArray[i] = c * sinArray[j] + s * cosArray[j];
            }
        }

        /// <summary>
        /// Fills array of factorial logarthms
        /// </summary>
        /// <param name="fact">The array to fill</param>
        public static void FillLogFactorials(double[] fact)
        {
            fact[0] = 1;
            fact[1] = 1;
            for (int i = 2; i < fact.Length; i++)
            {
                fact[i] = fact[i - 1] + Math.Log((double)i);
            }
        }



       /// <summary>
        /// Calculates derivation
        /// </summary>
        /// <param name="st">Sin(theta)</param>
        /// <param name="ct">Cos(theta)</param>
        private void CalcDerivation(double st, double ct)
        {
            dP[0][0] = 0;
            dP[1][0] = -ct;
            dP[1][1] = st;
            for (int i = 2; i < (n + 1); i++)
            {
                dP[i][i] = ct * dP[i - 1][i - 1] + st * P[i - 1][i - 1];
                for (int j = 0; j < i; j++)
                {
                    dP[i][j] = st * dP[i - 1][j] - ct * P[i - 1][j];
                    if (j < i - 1)
                    {
                        dP[i][j] -= K[i][j] * dP[i - 2][j];
                    }
                }
            }
        }


        #endregion
    }
}
