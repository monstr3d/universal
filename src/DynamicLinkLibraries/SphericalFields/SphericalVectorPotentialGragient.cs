using System;


namespace SphericalFields
{
    /// <summary>
    /// Spherical Gradient of vector field
    /// </summary>
    public class SphericalVectorPotentialGragient : SphericalVectorField
    {

        #region Ctor

        public SphericalVectorPotentialGragient()
        {
        }

        #endregion

        #region Overriden Members

        public override void Caclulate(double ctheta, double stheta,
             double cphi, double sphi, double r)
        {
            FillSinCos(cphi, sphi, cosArray, sinArray);
            CalculateAll(stheta, ctheta);
            double ar = a / r;
            double arc = ar * ar;
            sphericalVector[0] = 0;
            sphericalVector[1] = 0;
            sphericalVector[2] = 0;
            for (int i = 1; i < n + 1; i++)
            {
                arc *= ar;
                double arr = arc * (double)(i + 1);
                //double art = -arc * ar;
                double arp = ar * arc / ctheta;
                for (int j = 0; j <= i; j++)
                {
                    double cc = ccoeff[i][j] * cosArray[j];
                    double cs = scoeff[i][j] * sinArray[j];
                    double sc = ccoeff[i][j] * sinArray[j];
                    double ss = scoeff[i][j] * cosArray[j];
                    double cp = 0;
                    double cm = 0;
                    if (j == 0)
                    {
                        cp = cc;
                        cm = cs;
                    }
                    else
                    {
                        cp = cc + cs;
                        cm = sc - ss;
                    }
                    double p = P[i][j];
                    double dr = arr * cp * p;
                    double dt = -arc * cp * dP[i][j];
                    double dp = arc * cm * (double)(j) * p;
                    sphericalVector[0] += dr;
                    sphericalVector[1] += dt;
                    sphericalVector[2] += dp;
                }
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
            Normalize();
        }

        public override SphericalType SphericalType
        {
            get { return SphericalType.VectorPotentialGragient; }
        }

 
        #endregion

        #region Members


        /// <summary>
        /// Normalization
        /// </summary>
        private void Normalize()
        {
            double[][] S = new double[n + 1][];
            for (int i = 0; i < S.Length; i++)
            {
                S[i] = new double[i + 1];
            }
            S[0][0] = 1;
            for (int i = 1; i < S.Length; i++)
            {
                S[i][0] = S[i - 1][0] * (((double)(2 * i - 1)) / ((double)i));
            }
            for (int i = 1; i < S.Length; i++)
            {
                double ia = (double)i;
                for (int j = 1; j < S[i].Length; j++)
                {
                    double ja = (double)j;
                    double delta = (j == 1) ? 1 : 0;
                    S[i][j] = S[i][j - 1] * Math.Sqrt(((ia - ja + 1) * (delta + 1)) / (ia + ja));
                }
            }
            for (int i = 0; i < ccoeff.Length; i++)
            {
                double[] cc = ccoeff[i];
                double[] cs = scoeff[i];
                for (int j = 0; j < ccoeff[i].Length; j++)
                {
                    double coeff = S[i][j];
                    cc[j] *= coeff;
                    cs[j] *= coeff;
                }
            }
        }

        #endregion
    }
}
