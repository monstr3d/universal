using System;
using System.Collections.Generic;

using CommonMathOperations;

namespace MathStatistics
{
	/// <summary>
	/// Statistic functions
	/// </summary>
	public class StatisticsFunctions
	{
		private static readonly double[] fisherArray = new double[3];
		private static readonly double[,] cm = new double[,]{{-1.14473, -.6931472} , {-.6931472, 0}};
		private static readonly Func<double, double> dFisher = FisherDiff;
        private static readonly Func<double, double> dNor = expM2;
        private const double fish1 = -0.6931472;
        private const double fish2 = -1.14473;
        
        private StatisticsFunctions()
		{
		}


		/// <summary>
		/// Fisher distribution
		/// </summary>
		/// <param name="n">First degree of freedom</param>
		/// <param name="m">Second degree of freedom</param>
		/// <param name="x">Variable</param>
		/// <param name="eps">Accuracy</param>
		/// <returns>Integral fisher distribution value</returns>
		public static double Fisher(int n, int m, double x, double eps)
		{
			//double[] a = fisherArray;
			a[0] = -0.5 * (double) (n + m);
			a[1] = 0.5 * (double) (n - 1);
			int n1 = (int) (0.5 * (double) n);
			int m1 = (int) (0.5 * (double) m);
			bool logn = n == 2 * n1;
			bool logm = m == 2 * m1;
			if (m <= 2)
			{
				if (n <= 2)
				{
					a[2] = cm[m, n];
				}
				else
				{
					if(m == 1)
					{
						if (logn)
						{
							a[2] = fish1;
							--n1;
							for (int i = 1; i <= n1; i++)
							{
								a[2] += Math.Log(((double) i + 0.5) / ((double) i));
							}
						}
						else
						{
                            a[2] = fish2;
							for (int i = 1; i <= n1; i++)
							{
								a[2] += Math.Log((double) i / ((double) i - 0.5));
							}
							
						}
					}
					else if (logn)
					{
						a[2] = 0;
						--n1;
						for (int i = 1; i <= n1; i++)
						{
							a[2] += Math.Log((double) (i + 1) / ((double) i));
						}
					}
					else
					{
                        a[2] = fish1;
						for (int i = 1; i <= n1; i++)
						{
							a[2] += Math.Log((((double) i) + 0.5) / (((double) i) - 0.5));
						}
					}
				}
			}
			else if(n == 1)
			{

				if (logm)
				{
					a[2] = fish1;
					--m1;
					for (int i = 1; i <= m1; i++)
					{
						a[2] += Math.Log((((double) i) + 0.5) / (((double) i)));
					}
				}
				else
				{
                    a[2] = fish2;
					for (int i = 1; i <= m1; i++)
					{
						a[2] += Math.Log((((double) i)) / (((double) i) - 0.5));
					}
				}
			}
			else if(n == 2)
			{
				if ( logm )
				{
					a[2] = 0;
					--m1;
					for (int i = 1; i <= m1; i++)
					{
						a[2] += Math.Log((((double) i) + 1) / (((double) i)));
					}
				}
				else
				{
					a[2] = -.6931472;
					for (int i = 1; i <= m1; i++)
					{
						a[2] += Math.Log((((double) i) + 0.5) / (((double) i) - 0.5));
					}
				}
			}																 
			else if(logm == logn)
			{
				if (logm)
				{
					--n1;
					--m1;
					a[2] = Math.Log((double) (n + m + 1));
					for (int i = 1; i <= m1; i++)
					{
						a[2] += Math.Log(((double) (n1 + i)) / ((double) i));
					}
				}
				else
				{
                    a[2] = fish2;
					for (int i = 1; i <= n1; i++)
					{
						a[2] += Math.Log(((double) (i)) / ((double) i) - 0.5);
					}
					for (int i = 1; i <= m1; i++)
					{
						a[2] += Math.Log(((double) (n1 + i)) / ((double) i) - 0.5);
					}
				}
			}
			else if (logm)
			{
				a[2] = Math.Log((double) m1);
				for (int i = 1; i <= m1; i++)
				{
					a[2] += Math.Log((-0.5 + (double) (n1 + i)) / ((double) i));
				}
			}
			else
			{
				a[2] = Math.Log((double) n1);
				for (int i = 1; i <= m1; i++)
				{
					a[2] += Math.Log((-0.5 + (double) (m1 + i)) / ((double) i));
				}
			}
			double tt = x * (((double) n) / ((double) m));
			double ttf = Math.Abs(a[1]) / eps;
			if ( n == 1)
			{
				double tti = -eps / a[0];
				double exp = 2 * Math.Exp(a[2]);
				if (tt <= tti)
				{
					return exp * Math.Sqrt(tt);
				}
				else if(tt <= ttf)
				{
					return exp * Math.Sqrt(tti) + Integration.Sympson(dFisher, tti, tt, eps);
				}
			}
			if (tt > ttf)
			{
				double y = a[0] + a[1] + 1;
				return 1 + Math.Exp(a[2] + y * Math.Log(tt + 1)) / y;
			}
			return Integration.Sympson(dFisher, 0, tt, eps);
		}

        private static double[] a
        {
            get
            {
                return fisherArray;
            }
        }

		/// <summary>
		/// Kolmogoroff Smirnoff distribution
		/// </summary>
		/// <param name="x">Residual</param>
		/// <param name="n">Selection volume</param>
		/// <returns>Value of distribution</returns>
		public static double KolmgoroffSmirnoff(double x, int n)
		{
			if (x < 0.5 / (double) n)
			{
				return 0;
			}
			double nn = (double) n;
			int isgne = 1;
			if (n < 50)
			{
				int k = (int) Math.Ceiling(nn * (1 - x));
				double s = 0;
				double c = 1;
				for (int i = 1; i < k; i++)
				{
					double ii = (double) i;
					c *= (nn - ii + 1) / ii;
					s += c * ((x + ii) / Math.Pow(nn, ii - 1)) *
						((1 - x - ii) / Math.Pow(nn, nn - ii));
				}
				s = Math.Pow((1 - x), nn) + x * s;
				return 1 - 2 * s;
			}
			int j = 1;
			double a = 2 * ((double) n) * x * x;
			double r = Math.Exp(-a);
			while (true)
			{
				isgne = -isgne;
				++j;
				double c = (double)(j * j) * a;
				r += isgne * Math.Exp(-c);
				if (c > 20)
				break;
			}
			return 1 - 2 * r;
		}


		/// <summary>
		/// Guauss integral distribution
		/// </summary>
		/// <param name="x">Parameter</param>
		/// <param name="eps">Accuracy</param>
		/// <returns>Distribution value</returns>
		public static double GaussDistribution(double x, double eps)
		{
			return 0.5 + 0.5641896 * Integration.Sympson(dNor, 0, x * 0.7071068, eps);
		}

		/// <summary>
		/// Calculates Kolmogoroff Smirnoff criterion for selection
		/// </summary>
		/// <param name="f">Integral distribution</param>
		/// <param name="x">Selection</param>
		/// <returns>Criterion value</returns>
		public static double KolmgoroffSmirnoff(Func<double, double> f, double[] x)
		{
			double m = 0;
			double step = 1 / ((double) x.Length);
			for (int i = 0; i < x.Length; i++)
			{
				double emp = (double) i / (double) x.Length;
				double res = Math.Abs(emp - f(x[i]));
				if (res > m)
				{
					m = res;
				}
			}
			return m;
		}

		/// <summary>
		/// Processes normal distribution
		/// </summary>
		/// <param name="x">Selection</param>
		/// <param name="expectation">Expectation value</param>
		/// <param name="sigma">Sigma</param>
		/// <param name="kolmogoroff">Kolmogoroff level</param>
		/// <param name="eps">Accuracy</param>
		public static void ProcessNormal(List<object> x, out double expectation, 
			out double sigma, out double kolmogoroff, double eps)
		{
			x.Sort();
			double[] y = new double[x.Count];
			for (int i = 0; i < y.Length; i++)
			{
				y[i] = (double) x[i];
			}
			ProcessNormal(y, out expectation, out sigma, out kolmogoroff, eps);
		}



		/// <summary>
		/// Processes normal distribution
		/// </summary>
		/// <param name="x">Selection</param>
		/// <param name="expectation">Expectation value</param>
		/// <param name="sigma">Sigma</param>
		/// <param name="kolmogoroff">Kolmogoroff level</param>
		/// <param name="eps">Accuracy</param>
		public static void ProcessNormal(double[] x, out double expectation, 
			out double sigma, out double kolmogoroff, double eps)
		{
			double e = 0;
			double n = (double) x.Length;
			for (int i = 0; i < x.Length; i++)
			{
				e += x[i];
			}
			e /= n;
			double s = 0;
			for (int i = 0; i < x.Length; i++)
			{
				s += (x[i] - e) * (x[i] - e);
			}
			s /= n - 1;
			s = Math.Sqrt(s);
			expectation = e;
			sigma = s;
			double m = 0;
			for (int i = 0; i < x.Length; i++)
			{
				double y = (x[i] - e) / s;
				double a = (double) i / n;
				a -= GaussDistribution(y, eps);
				a = Math.Abs(a);
				if (a > m)
				{
					m = a;
				}
			}
			kolmogoroff = KolmgoroffSmirnoff(m, x.Length);

		}


		/// <summary>
		/// Differential fisher distribution
		/// </summary>
		/// <param name="x">Argument</param>
		/// <returns>Differential fisher distribution value</returns>
		private static double FisherDiff(double x)
		{
			if (x == 0)
			{
				return 0;
			}
			double[] a = fisherArray;
			return Math.Exp(a[2] + 
				a[1] * Math.Log(x) + a[0] * Math.Log(x + 1));
		}

		private static double expM2(double x)
		{
			return Math.Exp(-x * x);
		}
	}

}

