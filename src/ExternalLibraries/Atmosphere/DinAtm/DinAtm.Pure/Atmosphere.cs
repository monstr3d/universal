using System;
using System.ComponentModel.DataAnnotations;
using RealMatrixProcessor;
using SunPosition;

namespace DinAtm.Pure
{

    /// <summary>
    /// Atmosphere
    /// </summary>
    public class Atmosphere 

    {

        #region Fields

        Calculator calculator = new ();

        protected RealMatrix realMatrix = new();

        protected object[] ob = new object[2];

        static public readonly string[] sins = new string[] { "t", "x", "y", "z" };

        static public readonly string[] sous = new string[] { "Density" };

        static public readonly int[] mac = { 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365 };
        static public readonly double[] f01 ={-14.608, 0.8969, 67.596, -0.4016, 0.3031E-2, 0.2344E-5, 0.130,
     0.14E-3, 3.733, -507.95, 189.85, 4.2, 0.653, -0.7379, 0.8524E-2,
     -0.5328E-5, -0.1767,0.1859E-2, -0.1172E-5, 0.80, 2.0, -14.469,
     0.8517, 56.026, -0.3957, 0.2988E-2, 0.2246E-5, -0.172, 0.217E-2,
     3.784, -566.11, 200.97,4.1,0.621, -0.7379,0.8524E-2,-0.5328E-5,
     -0.1785, 0.1848E-2, -0.1211E-5, 0.89, 2.0, -15.415, 0.7729,61.836
      ,-0.3898, 0.2945E-2, 0.2148E-5, -0.274, 0.257E-2, 4.048, -632.63,
     230.76, 4.4, 0.635, -0.7379, 0.8524E-2, -0.5328E-5,-0.1802,
     0.1838E-2, -0.125E-5, 1.0, 3.0, -16.559,
      0.6982, 75.401, -0.3839, 0.2902E-2, 0.2051E-5, -0.247, 0.199E-2,
      3.495, -707.58, 278.35, 4.7, 0.632, -0.7379, 0.8524E-2, -0.5328E-5,
       -0.182, 0.1826E-2, -0.1289E-5, 1.0, 4.0, -18.219, 0.5863, 98.336
      ,-0.3472, 0.2562E-2, 0.2344E-5, -0.201, 0.161E-2, 3.2, -712.0,
      290.0, 4.5, 0.611, -0.7379, 0.8524E-2, -0.5328E-5, -0.1855, 0.1805E-2,
      -0.1367E-5, 1.0, 5.0, -19.068, 0.5177, 109.999, -0.3271, 0.2305E-2,
       0.2539E-5, -0.194, 0.134E-2, 3.0, -727.0, 300.0, 4.5, 0.611,
      -0.7379, 0.8524E-2, -0.5328E-5, -0.1891, 0.1783E-2, -0.1445E-5,
      1.0, 5.0};
        static public readonly double[] f0 = {
-18.873, 0.666, 118.013, -0.3644, 0.2618E-2, 0.349E-5, -1.0445, 0.9532E-2,
-6.4688, -507.95, 189.85, 4.2, 0.653, -2.6122, 0.02935,
     -0.6318E-4, -0.4422, 0.4809E-2, -0.9367E-5, 0.8, 2.0, -19.308, 0.596,
      119.285, -0.3525, 0.2508E-2, 0.3579E-5, -0.8181, 0.723E-2, -6.8255,
       -566.11, 200.97, 4.1, 0.621, -2.6122, 0.2935E-1, -0.6318E-4,
     -0.4109, 0.443E-2, -0.8384E-5, 0.89, 2.0, -19.532, 0.5519, 119.744,
     -0.3406, 0.2398E-2, 0.3667E-5, -0.6404, 0.5594E-2, -4.2892,-632.63,
      230.76, 4.4, 0.635, -2.6122, 0.2935E-1, -0.6318E-4, -0.3814,
     0.4074E-2, -0.7461E-5, 1.0, 3.0, -19.592,
     0.5296, 119.828, -0.3288, 0.2289E-2, 0.3752E-5, -0.4438, 0.3836E-2
     ,-1.4294, -707.58, 278.35, 4.7, 0.632, -2.6122, 0.2935E-1,-0.6318E-4,
     -0.349, 0.3682E-2, -0.6444E-5, 1.0, 4.0, -19.614, 0.5032, 119.846,
      -0.2931, 0.1961E-2, 0.4012E-5, -0.4581, 0.4157E-2, -2.6263, -712.0,
       290.0, 4.5, 0.611, -2.6122, 0.2935E-1, -0.6318E-4, -0.2882, 0.2946E-2,
      -0.4538E-5, 1.0, 5.0,-19.682, 0.4796, 119.927, -0.2016, 0.9112E-3,
       0.6411E-5, -0.2977, 0.2401E-2, 0.5736, -727.0, 300.0, 4.5,
     0.611, -2.6122, 0.02935, -0.6318E-4, -0.2255, 0.2188E-2, -0.257E-5
     ,1.0, 5.0};
        static public readonly double[] ad ={
-0.067,-0.088,-0.094,-0.088,-0.053,
     -0.005,0.039,0.09,0.123,0.133,
     0.123,0.099,0.059,0.017,-0.027,-0.065,-0.103,-0.136,-0.156,-0.172,
     -0.18,-0.183,-0.179,-0.163,-0.133,-0.085,-0.018,0.059,0.123,0.161,
     0.17,0.156,0.119,0.073,0.027,-0.023,-0.055,-0.078};

        static int[] KDNEY = { 31, 0, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        int N10;
        double[] f1;
        protected int[] ifa = new int[] { 150, 6, 140 };
        int[] if1 = new int[] { 75, 100, 125, 150, 200, 250 };
        int[] date = new int[3];
        private double[] r = new double[3];
        private double[] y = new double[3];
        private double[][] ff0;
        private double[][] ff1;
        const double ome = 7.292115085E-5;
        private ushort[] dd = new ushort[4];
        protected double[] xout = new double[3];

        double da = 0;
        double ra = 0;

        double ed = 0;
        double eh = 0;


        private cLocation cLocation = new cLocation();

        /// <summary>
        /// Coordinates of Sun
        /// </summary>
        private cSunCoordinates cSunCoordinates = new cSunCoordinates();


        #endregion

        #region Ctor

        public Atmosphere()
        {
            init();
            If = ifa;
        }

        #endregion

        #region Public Members

      //  DateTime d1900 = new DateTime(1900, 1, 1);

        public double Atm(double t, double[] x)
        {
            var r2 = x[0] * x[0] + x[1] * x[1];
            var lat = Math.Atan2(x[2], Math.Sqrt(r2));
            var lon = Math.Atan2(x[1], x[0]);
            cLocation.dLatitude = lat;
            cLocation.dLongitude = lon;
            double tday = t / 86400;
            DateTime dt = DateTime.FromOADate(tday);
            var hh = realMatrix.Normalize(x, y, 0);
            int ho = dt.Hour;
            int mi = dt.Minute;
            int ss = dt.Second;
            long it = (long)t;
            double sss = 1000 * (t - (double)(it));
            double tt = (ho * 60 + mi) * 60 + ss + .001 * sss;
            calculator.GetPosition(dt, cLocation, ref cSunCoordinates, out da, out ra, out ed, out eh);
            var alphastar = SunTime.CalculateGreenwichSiderealTime(dt);
       //     double ca = Math.Cos(alphastar), sa = Math.Sin(alphastar);
            double h = 0;
            date[0] = dt.Day;
            date[1] = dt.Month;
            date[2] = dt.Year;
            double rho = atm(x, tt, ra, da, alphastar, ref h, date);
            return rho;
        }

        /// <summary>
        /// Atmosphere parameters
        /// </summary>
        public int[] If
        {
            get
            {
                return ifa;
            }
            set
            {
                N10 = 0;
                for (int i = 0; i < 6; i++)
                {
                    if (if1[i] == value[0])
                    {
                        break;
                    }
                    else
                    {
                        N10++;
                    }
                }
                ifa[0] = value[0];
                ifa[1] = value[1];
                ifa[2] = value[2];
            }
        }
        #endregion

        #region Private Members

        private void init()
        {
            if (ff0 != null)
            {
                return;
            }
            ff0 = new double[f0.Length / 21][];
            ff1 = new double[f0.Length / 21][];
            for (int i = 0; i < ff0.Length; i++)
            {
                double[] fff = new double[21];
                double[] fff1 = new double[21];
                ff0[i] = fff;
                ff1[i] = fff1;
                int j = i * 21;
                for (int k = 0; k < 21; k++)
                {
                    int n = k + j;
                    fff[k] = f0[n];
                    fff1[k] = f01[n];
                }
            }
        }

        double atm(double[] x, double t, double alf, double del, double s0, ref double h, int[] it)
        {
            double hh = realMatrix.Normalize(x, y, 0);


            h = hh - 6378.140 * (1.0 - 0.335282E-2 * y[2] * y[2]);
           if (h <= 180)
            {
                f1 = ff0[N10];
            }
            else
            {
                f1 = ff1[N10];
            }
            int N3 = it[1] - 1;
            double a2, dat2;
            if (N3 <= 0)
                a2 = (double)it[0] / 10;
            else
            {
                dat2 = (double)it[1] / 4;
                if (Math.Abs(Math.Floor(dat2 + .00001) - dat2) < .0001)
                    a2 = (mac[N3 - 1] + 1 + it[0]) / 10.0;
                else
                    a2 = (mac[N3 - 1] + it[0]) / 10.0;
            }
            int N2 = (int)Math.Floor(a2);
            double a3 = a2 - N2;
            N2++;
            double ad1 = ad[N2 - 1] + (ad[N2] - ad[N2 - 1]) * a3;
            double gam = alf + f1[12] - s0 - ome * (t - 10800.0);
            double cosfi = y[2] * Math.Sin(del) + Math.Cos(del) * (y[0] * Math.Cos(gam) +
                 y[1] * Math.Sin(gam));
            double xk4 = 1 + (f1[16] + f1[17] * h + f1[18] * h * h) *
            Math.Log(ifa[1] / f1[20] + f1[19]);
            double xk3 = 1 + (f1[13] + f1[14] * h + f1[15] * h * h) * ad1;
            double cosfi2 = Math.Abs((1.0 + cosfi) / 2.0);
            double xk2 = 1 + (f1[6] + f1[7] * h + f1[8] * Math.Exp(-(h + f1[9]) / f1[10]
                 * (h + f1[9]) / f1[10])) * Math.Pow(cosfi2, f1[11] / 2);
            double xk1 = 1.0 + (f1[3] + f1[4] * h + f1[5] * h * h) * (ifa[2] - ifa[0]) / ifa[0];
            double roh = Math.Exp(f1[0] - f1[1] * Math.Sqrt(h - f1[2]));
            return roh * xk1 * xk2 * xk3 * xk4;
        }


        #endregion

    }
}
