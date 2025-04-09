using ErrorHandler;
using System;

namespace AnalyticPolynom
{
	/// <summary>
	/// Summary description for RealPolynom.
	/// </summary>
	public class RealPolynom 
	{
		
		private	double[] coeffs;
		
        /// <summary>
        /// Default constructor
        /// </summary>
		public RealPolynom() 
		{
			coeffs = new double[1];
			coeffs[0] = 0;
		}

		/// <summary>
		/// n is a degree of the polynom + 1
		/// It is useful, because the massive of coeffitients contains n numbers then. 
		/// </summary>
		/// <param name="n"></param>
		public RealPolynom(int n) 
		{
			if (n < 0)
			{
				throw new OwnException("The size of coefficient massive should be non - negative");
			}
			coeffs = new double[n];
			for (int i =0; i < n; i++)
			{
				coeffs[i] = 0;
			}
		}
/*
		/// <summary>
/// Creating an additional polynom for using Lagrange's interpolating method.
/// </summary>
/// <param name="arg"></param>
/// <param name="val"></param>
		public RealPolynom Interpolate(double[] arg)
		{
			if(arg.Length != val.Length)
			{
				throw new Exce ption("Number of arguments is not eqal to number of values");
			}
			RealPolynom r = new RealPolynom(arg.Length);
			r[0] = 1;
			RealPolynom mult = new RealPolynom(2);
			mult[1] = 1;
			for(int i = 0; i < arg.Length; i++)
			{
				for(int j = 0; j < arg.Length; j++)
				{
					if(i != j){} 
				}
			}

		}*/

        /// <summary>
        /// Clones itself
        /// </summary>
        /// <returns>Clone</returns>
		public object Clone()
		{
			RealPolynom p = new RealPolynom(coeffs.Length);
			p.coeffs = coeffs.Clone() as double[];
			return p;
		}
		
        /// <summary>
        /// Sum
        /// </summary>
        /// <param name="p">First term</param>
        /// <param name="q">Second term</param>
        /// <returns>Sum</returns>
		static public RealPolynom operator + (RealPolynom p, RealPolynom q)
		{
			RealPolynom r = new RealPolynom(0);
			
			if (p.coeffs.Length < q.coeffs.Length)
			{
				for (int i = 0; i < p.coeffs.Length; i++)
				{
					r.coeffs[i] = p.coeffs[i] + q.coeffs[i];
				}
				for ( int i = p.coeffs.Length - 1; i < q.coeffs.Length; i++)
				{
					r.coeffs[i] = q.coeffs[i];
				}
				return r;
			}	
			
			for (int i = 0; i < q.coeffs.Length; i++)
			{
				r.coeffs[i] = p.coeffs[i] + q.coeffs[i];
			}
			for ( int i = q.coeffs.Length - 1; i < p.coeffs.Length; i++)
			{
				r.coeffs[i] = p.coeffs[i];
			}

			r.Reduce();
			
			return r;
		}

        /// <summary>
        /// Difference
        /// </summary>
        /// <param name="p">First term</param>
        /// <param name="q">Second term</param>
        /// <returns>Difference</returns>
		static public RealPolynom operator - (RealPolynom p, RealPolynom q)
		{
			RealPolynom r = new RealPolynom(0);
			
			if (p.coeffs.Length < q.coeffs.Length)
			{
				for (int i = 0; i < p.coeffs.Length; i++)
				{
					r.coeffs[i] = p.coeffs[i] - q.coeffs[i];
				}
				for ( int i = p.coeffs.Length - 1; i < q.coeffs.Length; i++)
				{
					r.coeffs[i] = - q.coeffs[i];
				}
				return r;
			}	
			
			for (int i = 0; i < q.coeffs.Length; i++)
			{
				r.coeffs[i] = p.coeffs[i] - q.coeffs[i];
			}
			for ( int i = q.coeffs.Length - 1; i < p.coeffs.Length; i++)
			{
				r.coeffs[i] = p.coeffs[i];
			}

			r.Reduce();
			
			return r;
		}

        /// <summary>
        /// Minus
        /// </summary>
        /// <param name="p">Argument</param>
        /// <returns>Minus</returns>
		static public RealPolynom operator - (RealPolynom p)
		{
			RealPolynom r = new RealPolynom(p.coeffs.Length);

			for (int i = 0; i < p.coeffs.Length; i++)
			{
				p.coeffs[i] = -p.coeffs[i];
			}

			return r;

		}
	
        /// <summary>
        /// Plus constant
        /// </summary>
        /// <param name="p">Polynom</param>
        /// <param name="d">Constant</param>
        /// <returns>Result polynom</returns>
		static public RealPolynom operator + (RealPolynom p, double d)
		{
			RealPolynom r = p.Clone() as RealPolynom;
			r.coeffs[0] += d;
			r.Reduce();
			return r;
		}

        /// <summary>
        /// Plus constant left
        /// </summary>
        /// <param name="d">Constant</param>
        /// <param name="p">Polynom</param>
        /// <returns>Result polynom</returns>
        static public RealPolynom operator +(double d, RealPolynom p)
		{
			RealPolynom r = p.Clone() as RealPolynom;
			r.coeffs[0] += d;
			r.Reduce();
			return r;
		}

        /// <summary>
        /// Minus constant
        /// </summary>
        /// <param name="p">Polynom</param>
        /// <param name="d">Constant</param>
        /// <returns>Result polynom</returns>
        static public RealPolynom operator -(RealPolynom p, double d)
		{
			RealPolynom r = p.Clone() as RealPolynom;
			r.coeffs[0] -= d;
			return r;
		}
	
	    /// <summary>
	    /// Minus constant left
	    /// </summary>
        /// <param name="d">Constant</param>
        /// <param name="p">Polynom</param>
        /// <returns>Result polynom</returns>
        static public RealPolynom operator -(double d, RealPolynom p)
		{
			RealPolynom r = -p;
			r.coeffs[0] += d;
			return r;
		}
		
        /// <summary>
        /// Multiply to constant
        /// </summary>
        /// <param name="p">Polynom</param>
        /// <param name="d">Constant</param>
        /// <returns>Result polynom</returns>
        static public RealPolynom operator *(RealPolynom p, double d)
		{
			RealPolynom r = p.Clone() as RealPolynom;
			for (int i = 0; i < r.coeffs.Length; i++)
			{
				r.coeffs[i] *= d;
			}
			r.Reduce();			
			return r;
		}

        /// <summary>
        /// Multiply to constant left
        /// </summary>
        /// <param name="d">Constant</param>
        /// <param name="p">Polynom</param>
        /// <returns>Result polynom</returns>
        static public RealPolynom operator *(double d, RealPolynom p)
		{
			RealPolynom r = p.Clone() as RealPolynom;
			for (int i=0; i < r.coeffs.Length; i++)
			{
				r.coeffs[i] *= d;
			}
			r.Reduce();
			return r;
		}

        /// <summary>
        /// Divide to constant
        /// </summary>
        /// <param name="p">Polynom</param>
        /// <param name="d">Constant</param>
        /// <returns>Result polynom</returns>
        static public RealPolynom operator /(RealPolynom p, double d)
		{
			if (d == 0)
			{
				throw new OwnException("Can not divide by zero");
			}
						RealPolynom r = p.Clone() as RealPolynom;
			for (int i=0; i < r.coeffs.Length; i++)
			{
				r.coeffs[i] /= d;
			}
			return r;
		}

        /// <summary>
        /// Derivation
        /// </summary>
        /// <param name="p">Prototype</param>
        /// <returns>Redult polynon</returns>
		static public RealPolynom operator ! (RealPolynom p)
		{
			RealPolynom r = new RealPolynom(p.coeffs.Length - 1);
			for (int i = 0; i < r.coeffs.Length; i++)
			{
				r.coeffs[i] = p.coeffs[i + 1] * i;
			}
			return r;
		}

        /// <summary>
        /// Integration
        /// </summary>
        /// <param name="p">Prototype</param>
        /// <returns>Redult polynon</returns>
        static public RealPolynom operator ~(RealPolynom p)
		{
			RealPolynom r = new RealPolynom(p.coeffs.Length + 1);
			for (int i = 0; i < p.coeffs.Length; i++)
			{
				r.coeffs[i + 1] = p.coeffs[i] / (double)(i + 1);
			}
			r.coeffs[0] = 0;
			return r;
		}


        /// <summary>
        /// Redices itself
        /// </summary>
		private void Reduce()
		{
			int i = this.coeffs.Length - 1;
			while(coeffs[i] == 0)
			{
				i--;
			}
			if (i == -1)
			{
				coeffs = new double[]{1};
			}
			else
			{
				double[] a = new double[i+1];
				for (int j = 0; j < i + 1; j++)
				{
					a[j] = this.coeffs[j];
				}
				coeffs = a;
			}
		}

        /// <summary>
        /// The "is zero" sign
        /// </summary>
		bool isZero
		{
			get
			{
				for (int i = 0; i < coeffs.Length; i++)
				{
					if (coeffs[i] != 0) 
					{
						return false;
					}
				}
				return true;
			}
		}
	
        /// <summary>
        /// Multiplication
        /// </summary>
        /// <param name="p">First term</param>
        /// <param name="q">Second term</param>
        /// <returns>Product</returns>
		static public RealPolynom operator *(RealPolynom p, RealPolynom q)
		{
			if ((p.isZero)|(q.isZero))
			{
				RealPolynom r = new RealPolynom(1);
				return r;
			}

			RealPolynom s = new RealPolynom(p.coeffs.Length + q.coeffs.Length - 1);
			
			for (int i = 0; i < p.coeffs.Length; i++)
			{
				for (int j = 0; j < q.coeffs.Length; j++)
				{
					s.coeffs[i+j] += p.coeffs[i] * q.coeffs[j];
				}
			}
			return s;
		}

        /// <summary>
        /// Access to i -th coefficient
        /// </summary>
        /// <param name="i">Coefficient index</param>
        /// <returns>Coefficient value</returns>
		public double this[int i]
		{
			get
			{
				return coeffs[i];
			}

			set
			{
				coeffs[i] = value;
			}			
		}

		/// <summary>
		/// Calcuilates polynom value
		/// </summary>
		/// <param name="x">Argument</param>
		/// <returns>Value</returns>
        public double this[double x]
		{
			get
			{
				double y = 1;
				double s = 0;
				for (int i = 0; i < coeffs.Length; i ++)
				{
					s += y * coeffs[i];
					y *= x;
				}
				return s;
			}
		}
	}
}
