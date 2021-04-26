using System;

using RealMatrixProcessor;
using DataPerformer;
using DataPerformer.Interfaces;

namespace GeneralLinearMethod
{

	/// <summary>
	/// Structured General linear method
	/// </summary>
	public class StructuredGLM : IStructuredCalculation, IStructuredSelection
	{
		
		#region Fields
		/// <summary>
		/// Auxiliary variable
		/// </summary>
		private double[] z;

		/// <summary>
		/// Auxiliary variable
		/// </summary>
		private double?[] y1;

		/// <summary>
		/// Residuals
		/// </summary>
		private double?[] y;

		/// <summary>
		/// Solution matrix
		/// </summary>
		private double[,] a;

		/// <summary>
		/// Partial derivation matrix
		/// </summary>
		private double?[,] h;

		/// <summary>
		/// Auxliary array for inversion
		/// </summary>
		private int[] indx;

		/// <summary>
		/// Selection
		/// </summary>
		private IStructuredSelection selection;

		/// <summary>
		/// Calculator
		/// </summary>
		private IStructuredCalculation calculator;

		/// <summary>
		/// Dimension of estimated vector
		/// </summary>
		private int n;

		/// <summary>
		/// Dimension of data
		/// </summary>
		private int l;

		/// <summary>
		/// Residuals
		/// </summary>
		private double?[] residuals;

		#endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="selection">Selection</param>
        /// <param name="calculator">Calculation</param>
		public StructuredGLM(IStructuredSelection selection, IStructuredCalculation calculator)
		{
			this.selection = selection;
			this.calculator = calculator;
			n = calculator.Dimension;
			l = selection.DataDimension;
			z = new double[n];
			y = new double?[l];
			y1 = new double?[l];
			a = new double[n, n];
			indx = new int[n];
			h = new double?[n, l];
			residuals = new double?[l];
		}
		
		/// <summary>
		/// Calculates parameters
		/// </summary>
		/// <param name="x">Input</param>
		/// <param name="selection">Selection</param>
		/// <param name="y">Output</param>
		public void Calculate(double[] x, IStructuredSelection selection, double?[] y)
		{
			calculator.Calculate(x, selection, y);
		}

		/// <summary>
		/// Dimension of estimated vector
		/// </summary>
		public int Dimension
		{
			get
			{
				return n;
			}
		}

		/// <summary>
		/// Dimension of data
		/// </summary>
		public int DataDimension
		{
			get
			{
				return selection.DataDimension;
			}
		}

		/// <summary>
		/// Access to n - th element
		/// </summary>
		public double? this[int n]
		{
			get
			{
				return selection[n];
			}
		}

		/// <summary>
		/// Weight of n - th element
		/// </summary>
		/// <param name="n">Element number</param>
		/// <returns>The weight</returns>
		public double GetWeight(int n)
		{
			return selection.GetWeight(n);
		}

		/// <summary>
		/// Aprior weight of n - th element
		/// </summary>
		/// <param name="n">Element number</param>
		/// <returns>The weight</returns>
		public double GetApriorWeight(int n)
		{
			return selection.GetApriorWeight(n);
		}

		/// <summary>
		/// Tolerance of it - th element
		/// </summary>
		/// <param name="n">Element number</param>
		/// <returns>Tolerance</returns>
		public int GetTolerance(int n)
		{
			return selection.GetTolerance(n);
		}

		/// <summary>
		/// Sets tolerance of n - th element
		/// </summary>
		/// <param name="n">Element number</param>
		/// <param name="tolerance">Tolerance to set</param>
		public void SetTolerance(int n, int tolerance)
		{
			selection.SetTolerance(n, tolerance);
		}

		/// <summary>
		/// The "is fixed amount" sign
		/// </summary>
		public bool HasFixedAmount
		{
			get
			{
				return selection.HasFixedAmount;
			}
		}

		/// <summary>
		/// Selection name
		/// </summary>
		public string Name
		{
			get
			{
				return selection.Name;
			}
		}


		/// <summary>
		/// Performs iteration step
		/// </summary>
		/// <param name="x">Input/Output parameters</param>
		/// <param name="dx">Delta</param>
		/// <param name="d">Weights of Input/Output</param>
		/// <param name="y">Auxiliary variable</param>
		/// <param name="y1">Auxiliary variable</param>
		/// <param name="h">Numercial derivations</param>
		/// <returns>Sigma0</returns>
		public double Iterate(double[] x, double[] dx, double[] d, double?[] y, double?[] y1, double?[,] h)
		{
			double s = 0;
            int l = DataDimension;
            for (int im = 0; im < l; im++)
            {
                for (int i = 0; i < n; i++)
                {
                    h[i, im] = 1;
                }
            }
 
			for (int i = 0; i < n; i++)
			{
				z[i] = 0;
				for (int j = 0; j < n; j++)
				{
					a[i, j] = 0;
				}
			}
			if (residuals == null)
			{
				residuals = new double?[l];
			}
			else if (residuals.Length != l)
			{
				residuals = new double?[l];
			}
			Calculate(x, selection, y);
			for (int i = 0; i < n; i++)
			{
				x[i] += dx[i];
				Calculate(x, selection, y1);
				for (int im = 0; im < l; im++)
				{
					double? der = (y1[im] - y[im]) / dx[i];
					double? res = this[im] - y[im];
					residuals[im] = -res;
					double r = GetWeight(im);
                    if (res != null)
                    {
                        z[i] += (double) (res * der * r);
                    }
					h[i, im] = der;
                    if (res != null)
                    {
                        s += (double)(res * res * r);
                    }
				}
				x[i] -= dx[i];
			}
			for (int im = 0; im < l; im++)
			{
				for (int i = 0; i < n; i++)
				{
                    if (h[i, im] == null)
                    {
                        continue;
                    }
					for (int j = 0; j < n; j++)
					{
                        if (h[j, im] == null)
                        {
                            continue;
                        }
						double r = GetWeight(im);
						a[i, j] += (double) (r * h[i, im] * h[j, im]);
					}
				}
			}
			for (int i = 0; i < n; i++)
			{
				a[i, i] += d[i];
			}
			RealMatrix.Solve(a, z, indx);
            for (int i = 0; i < n; i++)
            {
                x[i] += z[i];
            }
			return s;
		}

		/// <summary>
		/// Performs iteration step
		/// </summary>
		/// <param name="x">Input/Output parameters</param>
		/// <param name="dx">Delta</param>
		/// <param name="d">Weights of Input/Output</param>
		/// <returns>Sigma0</returns>
		public double Iterate(double[] x, double[] dx, double[] d)
		{
			return Iterate(x, dx, d, y, y1, h);
		}

		/// <summary>
		/// Gets Square residual
		/// </summary>
		/// <param name="x">Defined patameter</param>
		/// <param name="y">Auxiliary array</param>
		/// <returns>Square residual</returns>
		public double? GetSquareResidual(double[] x, double?[] y)
		{
			Calculate(x, selection, y);
			int l = DataDimension;
			double s = 0;
            for (int im = 0; im < l; im++)
            {
                double? res = this[im] - y[im];
                double? r = GetWeight(im);
                if (r == null | res == null)
                {
                    continue;
                }
                s += (double)(res * res * r);
            }
			return s;
		}


		/// <summary>
		/// Residuals
		/// </summary>
		public double?[] Residuals
		{
			get
			{
				return residuals;
			}
		}

		/// <summary>
		/// Data
		/// </summary>
		public double?[] Data
		{
			get
			{
				IStructuredSelection s = this;
				double?[] data = new double?[s.DataDimension];
				for (int i = 0; i < data.Length; i++)
				{
					data[i] = s[i];
				}
				return data;
			}
		}
	}
}

 