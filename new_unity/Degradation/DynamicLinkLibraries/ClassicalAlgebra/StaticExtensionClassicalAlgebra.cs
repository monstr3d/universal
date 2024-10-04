using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ClassicalAlgebra
{

    /// <summary>
    /// Performer of classical algebra operations
    /// </summary>
    public static class StaticExtensionClassicalAlgebra
    {
        /// <summary>
        /// Copy of complex number
        /// </summary>
        /// <param name="complex">Prototype</param>
        /// <returns>Copy</returns>
        static public Complex Copy(this Complex complex)
        {
            return new Complex(complex.Real, complex.Imaginary);
        }

        /// <summary>
        /// Gets roots of real polynom
        /// </summary>
        /// <param name="p">Coefficients of real polynom</param>
        /// <returns>Complex roots</returns>
        public static Complex[] GetRoots(double[] p)
        {
            ComplexPolynom pol = new ComplexPolynom(p);
            Complex[] c = pol.Roots(1e-15);
            return c;
        }

        /// <summary>
        /// Gets norms of roots of rel polynom
        /// </summary>
        /// <param name="p">Coefficients of real polynom</param>
        /// <returns>Sorted array of norms</returns>
        public static double[] GetNorms(double[] p)
        {
            Complex[] c = GetRoots(p);
            List<double> l = new List<double>();
            foreach (Complex x in c)
            {
                l.Add(x.Magnitude);
            }
            l.Sort();
            return l.ToArray();
        }

        /// <summary>
        /// Calculates greatest common divisor
        /// </summary>
        /// <param name="el1">First element</param>
        /// <param name="el2">Second element</param>
        /// <returns>The greatest common divisor</returns>
        static public IDivision GreatestCommonDivisor(IDivision el1, IDivision el2)
        {
            IDivision c, d;
            if (el1.Norm > el2.Norm)
            {
                c = el1;
                d = el2;
            }
            else
            {
                c = el2;
                d = el1;
            }
            return greatestCommonDivisor(c, d);
        }


        internal static Complex SquareRoot(this Complex complex)
        {
            double re = complex.Real;
            double im = complex.Imaginary;
            if (im < 1e-15)
            {
                if (re >= 0)
                {
                    return Math.Sqrt(re);
                }
                return new Complex(0, Math.Sqrt(-re));
            }
            double n = Math.Sqrt(complex.Magnitude);
            double ar = complex.Phase / 2;
            double rr = n * Math.Cos(ar);
            double ri = n * Math.Sin(ar);
            return new Complex(rr, ri);
        }



        internal static Complex Sqrt(this Complex complex)
        {
            double rho = Math.Sqrt(complex.Magnitude);
            double phi = complex.Phase;
            phi *= 0.5;
            return new Complex(rho * Math.Cos(phi), rho * Math.Sin(phi));
        }



        /// <summary>
        /// Iteration for finding roots
        /// </summary>
        /// <param name="complex">Complex</param>
        /// <param name="p">Polynom</param>
        /// <param name="der">Derivation</param>
        /// <param name="h">Auxiliary polynom</param>
        /// <returns>Iteration result</returns>
        internal static Complex Iterate(this Complex complex, ComplexPolynom p, ComplexPolynom der, ComplexPolynom h)
        {
            Complex he = (Complex)h[complex];
            Complex sq = he.Sqrt();
            Complex d = (Complex)der[complex];
            Complex den1 = (Complex)(d + sq);
            Complex den2 = (Complex)(d - sq);
            Complex den = (den1.Magnitude > den2.Magnitude) ? den1 : den2;
            return (Complex)p[complex] / den;
        }




        /// <summary>
        /// Calculates greatest common divisor
        /// </summary>
        /// <param name="el1">First element</param>
        /// <param name="el2">Second element</param>
        /// <returns>The greatest common divisor</returns>
        static private IDivision greatestCommonDivisor(IDivision el1, IDivision el2)
        {
            if (el2.IsZero)
            {
                return el1;
            }
            IDivision rem;
            IDivision el = el1.Divide(el2, out rem);
            return greatestCommonDivisor(el2, rem);
        }
    }
}
