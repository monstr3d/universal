using System;
using System.Collections.Generic;
using System.Text;

namespace SphericalFields
{
    /// <summary>
    /// Spherical field that is a gradient of scalar field
    /// </summary>
    public class SphericalGragient : SphericalVectorField
    {
        #region Fields
        #endregion

        #region Overriden Members

        public override void Caclulate(double ctheta, double stheta, double cphi, double sphi, double r)
        {
            CalculateAll(ctheta, stheta);
            Norm();
            LegendrePolynomial.FillSinCos(cphi, sphi, cosArray, sinArray);
            double rm = 1 / r;
            double ar = a * rm;
            double sr = ar * ar;
            sphericalVector[0] = -ccoeff[0][0] / (r * r * r);
            sphericalVector[1] = 0;
            sphericalVector[2] = 0;
            double fr = 0;
            double ft = 0;
            double fp = 0;
            for (int i = 2; i <= n; i++)
            {
                double[] cc = ccoeff[i];
                double[] ss = scoeff[i];
                double[] pp = P[i];
                double[] dp = dP[i];
                double ia = (double)(i + 1);
                double arm = ar * rm;
                for (int j = 0; j <= i; j++)
                {
                    double p = pp[j];
                    double dpp = dp[j];
                    double c = cc[j];
                    double s = ss[j];
                    double ca = cosArray[j];
                    double sa = sinArray[j];
                    double cp = ca * c + sa * s;
                    double cm = ca * s - sa * c;
                    double pr = cp * sr;
                    double dar = p * pr * ia;
                    fr += dar;
                    double dtp = dpp * pr;
                    ft += dtp;
                    double ja = (double)j;
                    double pm = cm * sr;
                    double dphi = ja * pm * dpp;
                    fp += dphi;
                }
                sr *= ar;
            }

        }

        public override void Set(int n, int m, double a, double[][] ccoeff, double[][] scoeff)
        {
            Init(n, m);
            this.n = n;
            this.m = m;
            this.a = a;
            this.ccoeff = ccoeff;
            this.scoeff = scoeff;
            cosArray = new double[n + 1];
            sinArray = new double[n + 1];
            cosArray[0] = 1;
            sinArray[0] = 0;
  /*          aArray = new double[n + 1];
            aArray[0] = 1;
            for (int i = 1; i < aArray.Length; i++)
            {
                aArray[i] = a * aArray[i - 1];
            }*/
        }

        public override SphericalType SphericalType
        {
            get { return SphericalType.Gradient; }
        }

        #endregion

        #region Specific Members

        void Norm()
        {
            for (int i = 2; i < P.Length; i++)
            {
                for (int j = 0; j < P[i].Length; j++)
                {
                    Norm(i, j);
                }
            }
        }

        private void Norm(int n, int m)
        {
            double an = (double)n;
            double am = (double)m;
            double k = ((m == 0) ? 1 : Math.Sqrt(2)) * Math.Sqrt(2 * an + 1);
            P[n][m] /= k;
            dP[n][m] /= k;
            int b = n - m + 1;
            int e = n + m;
            for (int i = b; i <= e; i++)
            {
                double ia = 1 / Math.Sqrt((double)i);
                P[n][m] *= ia;
                dP[n][m] *= ia;
            }
        }

        #endregion
    }
}
