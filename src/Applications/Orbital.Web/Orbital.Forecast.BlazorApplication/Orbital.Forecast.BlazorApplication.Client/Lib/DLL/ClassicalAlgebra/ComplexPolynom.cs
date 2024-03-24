using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;


namespace ClassicalAlgebra
{
    /// <summary>
    /// Complex polynom
    /// </summary>
    public class ComplexPolynom : IDivision
    {
        #region Fields

        Complex[] coeff;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="coeff">Complex coefficients</param>
        public ComplexPolynom(Complex[] coeff)
        {
            this.coeff = coeff;
        }

        /// <summary>
        /// Construrtor
        /// </summary>
        /// <param name="p">Real coefficients</param>
        public ComplexPolynom(double[] p)
        {
            coeff = new Complex[p.Length];
            for (int i = 0; i < p.Length; i++)
            {
                coeff[i] = p[i];
            }
        }

        #endregion

        #region IDivision Members

        IDivision IDivision.Divide(IDivision divisor, out IDivision reminder)
        {
            ComplexPolynom pd = divisor as ComplexPolynom;
            ComplexPolynom[] cp = Divide(pd);
            cp[1].Reduce();
            reminder = cp[1];
            return cp[0];
        }

        double IDivision.Norm
        {
            get { return (double)Deg; }
        }

        bool IDivision.IsZero
        {
            get 
            {
                foreach (Complex c in coeff)
                {
                    if (c.Magnitude > 1e-10)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        #endregion

        #region Members

        /// <summary>
        /// Derivation
        /// </summary>
        public ComplexPolynom Derivation
        {
            get
            {
                if (coeff.Length == 1)
                {
                    Complex c = new Complex(0, 0);
                    return new ComplexPolynom(new Complex[] { c });
                }
                Complex[] cf = new Complex[coeff.Length - 1];
                for (int i = 0; i < cf.Length; i++)
                {
                    int k = i + 1;
                    cf[i] = coeff[k] * k;
                }
                return new ComplexPolynom(cf);
            }
        }

        /// <summary>
        /// Degree
        /// </summary>
        public int Deg
        {
            get
            {
                return coeff.Length - 1;
            }
        }

        /// <summary>
        /// Inplicit conversion
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        static public implicit operator ComplexPolynom(Complex x)
        {
            return new ComplexPolynom(new Complex[] { x });
        }
        /// <summary>
        /// Implicit conversion
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        static public implicit operator ComplexPolynom(int x)
        {
            return new ComplexPolynom(new Complex[] { x });
        }

        /// <summary>
        /// Unary minus
        /// </summary>
        /// <param name="a">Argument</param>
        /// <returns>Result</returns>
        public static ComplexPolynom operator -(ComplexPolynom a)
        {
            Complex[] cf = a.coeff;
            int n = cf.Length;
            Complex[] c = new Complex[n];
            for (int i = 0; i < n; i++)
            {
                c[i] = -cf[i];
            }
            return new ComplexPolynom(c);
        }


        /// <summary>
        /// Addition
        /// </summary>
        /// <param name="a">First term</param>
        /// <param name="b">Second term</param>
        /// <returns>Sum</returns>
        public static ComplexPolynom operator +(ComplexPolynom a, ComplexPolynom b)
        {
            Complex[] max = a.coeff;
            int min = b.coeff.Length;
            if (max.Length < min)
            {
                max = b.coeff;
                min = a.coeff.Length;
            }
            int i = 0;
            Complex[] c = new Complex[max.Length];
            for (; i < min; i++)
            {
                c[i] = a.coeff[i] + b.coeff[i];
            }
            if (a.coeff.Length == b.coeff.Length)
            {
                ComplexPolynom p = new ComplexPolynom(c);
                p.Reduce();
                return p;
            }
            for (; i < max.Length; i++)
            {
                c[i] = new Complex(max[i].Real, max[i].Imaginary);
            }
            return new ComplexPolynom(c);
        }

        /// <summary>
        /// Multiplication
        /// </summary>
        /// <param name="a">First term</param>
        /// <param name="b">Second term</param>
        /// <returns>Product</returns>
        public static ComplexPolynom operator *(ComplexPolynom a, ComplexPolynom b)
        {
            int n = a.Deg + b.Deg;
            Complex[] c = new Complex[n + 1];
            for (int i = 0; i < c.Length; i++)
            {
                c[i] = new Complex();
            }
            Complex[] ac = a.coeff;
            Complex[] bc = b.coeff;
            for (int i = 0; i < ac.Length; i++)
            {
                Complex xa = ac[i];
                for (int j = 0; j < bc.Length; j++)
                {
                    Complex xb = bc[j];
                    int k = i + j;
                    c[k] = c[k] + (xa * xb);
                }
            }
            return new ComplexPolynom(c);
        }

        /// <summary>
        /// Calculation of polynom value
        /// </summary>
        /// <param name="x">Argument</param>
        /// <returns>Value</returns>
        public Complex this[Complex x]
        {
            get
            {
                Complex a = new Complex();
                Complex b = new Complex(1, 0);
                for (int i = 0; i < coeff.Length; i++)
                {
                    a = a + coeff[i] * b;
                    b = b * x;
                }
                return a;
            }
        }

        /// <summary>
        /// Complex n - th coefficient
        /// </summary>
        /// <param name="n">Degree</param>
        /// <returns>The coefficient</returns>
        public Complex this[int n]
        {
            get
            {
                return coeff[n];
            }
            set
            {
                coeff[n] = value;
                if (n == coeff.Length - 1)
                {
                    Reduce();
                }
            }
        }

        /// <summary>
        /// Copy of polynom
        /// </summary>
        public ComplexPolynom Copy
        {
            get
            {
                Complex[] c = new Complex[coeff.Length];
                for (int i = 0; i < c.Length; i++)
                {
                    c[i] = coeff[i].Copy();
                }
                return new ComplexPolynom(c);
            }
        }


        /// <summary>
        /// Divides this polynom with reminder
        /// </summary>
        /// <param name="divisor">Divisor</param>
        /// <returns>{Divident, Reminder}</returns>
        public ComplexPolynom[] Divide(ComplexPolynom divisor)
        {
            Complex[] cf = divisor.coeff;
            ComplexPolynom rem = Copy;
            if (cf.Length > coeff.Length)
            {
                return new ComplexPolynom[]
                {
                    new ComplexPolynom(new Complex[] {new Complex()}), rem 
                };
            }
            List<Complex> q = new List<Complex>();
            Complex lead = cf[cf.Length - 1];
            do
            {
                Complex[] cr = rem.coeff;
                Complex cm = cr[cr.Length - 1];
                if (cm.Magnitude < 1e-15)
                {
                    q.Add(0);
                    Complex[] c = new Complex[cr.Length - 1];
                    Array.Copy(cr, c, c.Length);
                    rem = new ComplexPolynom(c);
                }
                else
                {
                    int dr = rem.Deg;
                    Complex cn = cm / lead;
                    q.Add(cn);
                    ComplexPolynom cp = -(Monom(rem.Deg - divisor.Deg, cn) * divisor);
                    rem = rem + cp;
                    rem = rem.Cut(dr);
   /*                  for (int i = rem.Deg; i < dr; i++)
                    {
                        q.Add(0);
                    }*/
                    if (rem.Deg < divisor.Deg)
                    {
                        break;
                    }
                    cm = rem.coeff[rem.coeff.Length - 1];
                }
                //Complex re
            }
            while (rem.Deg >= divisor.Deg);
            Complex[] crr = new Complex[q.Count];
            for (int i = 0; i < crr.Length; i++)
            {
                crr[i] = q[q.Count - i - 1];
            }
            return new ComplexPolynom[]
            {
                new ComplexPolynom(crr), rem
            };
        }



        /// <summary>
        /// Finds root of polynom
        /// </summary>
        /// <param name="accuracy">Accuracy</param>
        /// <returns>Root</returns>
        public Complex Root(double accuracy)
        {
            ComplexPolynom p = this;
            ComplexPolynom der = p.Derivation;
            ComplexPolynom sec = der.Derivation;
            int n = p.Deg;
            ComplexPolynom pol = -p * n;
            ComplexPolynom h = (n - 1) * ((n - 1) * der * der + pol * sec);
            double a = 1;
            Complex x = new Complex(0, 0);
            do
            {
                x = x + (Complex)x.Iterate(pol, der, h);
                Complex r = (Complex)p[x];
                Complex d = (Complex)der[x];
                double b = d.Magnitude;
                a = r.Magnitude;
                if (b > 0)
                {
                    a /= b;
                }
            }
            while (a > accuracy);
            return x;
        }

        /// <summary>
        /// Finds all roots of polynom
        /// </summary>
        /// <param name="accuracy">Accuracy</param>
        /// <returns>Array of roots</returns>
        public Complex[] Roots(double accuracy)
        {
            if (Deg == 1)
            {
                return new Complex[] { (-coeff[0] / coeff[1]) };
            }
            if (Deg == 2)
            {
                return SquareRoots;
            }
            ComplexPolynom polynom = this;
            ComplexPolynom p = this;
            ComplexPolynom deri = Derivation;
            IDivision div = this;
            ComplexPolynom comd = StaticExtensionClassicalAlgebra.GreatestCommonDivisor(this, deri) as ComplexPolynom;
            if (comd.Deg > 0)
            {
                List<Complex> r = new List<Complex>();
                ComplexPolynom divcomdeg = Divide(comd)[0];
                Complex[] r1 = comd.Roots(accuracy);
                Complex[] r2 = divcomdeg.Roots(accuracy);
                r.AddRange(r1);
                r.AddRange(r2);
                return r.ToArray();
            }
            Complex[] roots = new Complex[p.Deg];
            for (int i = 0; i < roots.Length; i++)
            {
                if (p.Deg == 1)
                {
                    roots[i] = (-p.coeff[0]) / p.coeff[1];
                    break;
                }
                Complex x = p.Root(accuracy);
                roots[i] = x;
                ComplexPolynom pol = new ComplexPolynom(new Complex[] { -x, 1 });
                p = p.Divide(pol)[0];
            }
            return roots;
        }



        ComplexPolynom Monom(int deg, Complex c)
        {
            Complex[] ca = new Complex[deg + 1];
            for (int i = 0; i < deg; i++)
            {
                ca[i] = new Complex();
            }
            ca[deg] = new Complex(c.Real, c.Imaginary);
            return new ComplexPolynom(ca);
        }

        private Complex[] SquareRoots
        {
            get
            {
                Complex discr = (coeff[1] * coeff[1]) - (4 * coeff[2] * coeff[0]);
                Complex twoa = 2 * coeff[2];
                Complex pl = discr.SquareRoot();
                Complex[] roots = new Complex[] { coeff[1] + pl, coeff[1] - pl };
                for (int i = 0; i < 2; i++)
                {
                    roots[i] = roots[i] / twoa;
                }
                return roots;
            }
        }

            private ComplexPolynom Cut(int n)
        {
            if (coeff.Length <= n)
            {
                return Copy;
            }
            Complex[] c = new Complex[n];
            for (int i = 0; i < n; i++)
            {

                c[i] = coeff[i].Copy();
            }
            return new ComplexPolynom(c);
        }


        private void Reduce()
        {
            int i = coeff.Length - 1;
            for (; i >= 0; i--)
            {
                if (coeff[i].Magnitude > 1e-15)
                {
                    break;
                }
            }
            if (i == coeff.Length - 1)
            {
                return;
            }
            Complex[] c = new Complex[i + 1];
            Array.Copy(coeff, c, c.Length);
            coeff = c;
        }



        #endregion

    }
}