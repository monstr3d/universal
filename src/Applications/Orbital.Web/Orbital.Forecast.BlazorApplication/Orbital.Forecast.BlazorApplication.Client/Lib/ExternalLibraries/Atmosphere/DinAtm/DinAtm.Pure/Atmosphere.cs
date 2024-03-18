using System;
using RealMatrixProcessor;


namespace DinAtm.Pure
{

    /// <summary>
    /// Atmosphere
    /// </summary>
    public class Atmosphere 

    {

        #region Fields

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

          #endregion

        #region Ctor

        public Atmosphere()
        {
            init();
            If = ifa;
        }

        #endregion
 
        #region Public Members

        public double Atm(double t, double[] x)
        {
            double ttt = t / 86400;
            //           ushort ho, mi, ss, sss;
            DateTime dt = DateTime.FromOADate(ttt);
            int ho = dt.Hour;
            int mi = dt.Minute;
            int ss = dt.Second;
            long it = (long)t;
            //DateTime dt1 = DateTime.F
            double sss = 1000 * (t - (double)(it));
            //sss *= 1000;
            //dt.DecodeTime(&ho, &mi, &ss, &sss);
            double tt = (ho * 60 + mi) * 60 + ss + .001 * sss;
            double days = days1900(dt) + 1;
            double ASoL = 0, DSoL = 0;//,ASoL1,DSoL1;
            //AngleSun(tt-10800.,days-1,ASoL,DSoL);
            AngleSun(tt - 10800.0, days, ref ASoL, ref DSoL);
            double alphastar = zvvr(days);
            double cosdS = Math.Cos(DSoL);
            //double startime=zvvr(days);
            //double startime1=zvvr(days-1);
            //double al=startime;
            double ca = Math.Cos(alphastar), sa = Math.Sin(alphastar);
            double h = 0;
            date[0] = dt.Day;
            date[1] = dt.Month;
            date[2] = dt.Year;
            double rho = atm(x, tt, ASoL, DSoL, ref alphastar, ref h, date);
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

        double atm(double[] x, double t, double alf, double del, ref double s0, ref double h, int[] it)
        {
            double hh = x.Normalize(y, 0);


            h = hh - 6378.140 * (1.0 - 0.335282E-2 * y[2] * y[2]);
            //int N10=0;
            //       int i, j, k, j1, k1;
            /*for(i=0;i<6;i++)
            if(ifa[0]==if1[i]) break; else N10++;
            //N10++;
            if(h<=180) //N10=1;
            for(j=0;j<21;j++)
            {
            j1=N10*21+j;
            f1[j]=f0[j1];
            }
            else
            for(k=0;k<21;k++)
            {
            k1=N10*21+k;
            f1[k]=f01[k1];
            }
            */
            //f1[12]=.611;
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

        double atm(double[] x, double t, ref double s0, ref double h, int[] ifa, DateTime Date)
        {
            date[0] = Date.Day;
            date[1] = Date.Month;
            date[2] = Date.Year;
            double days = days1900(Date);
            double ASoL = 0, DSoL = 0;
            AngleSun(t - 10800.0, days, ref ASoL, ref DSoL);
            return atm(x, t, ASoL, DSoL, ref s0, ref h, date);
        }

        double atm(double[] x, double t, ref double s0, ref double h, int[] ifa)
        {
            double ASoL = 0, DSoL = 0;
            AngleSun(-10800.0, t, ref ASoL, ref DSoL);
            //MyTime=t;
            DateTime dt = DateTime.FromOADate(t);
            dd[2] = (ushort)dt.Year;
            dd[1] = (ushort)dt.Month;
            dd[0] = (ushort)dt.Day;
            for (int i = 0; i < 3; i++) date[i] = (int)dd[i];

            double tt;
            dd[3] = (ushort)dt.Hour;
            dd[2] = (ushort)dt.Minute;
            dd[1] = (ushort)dt.Second;
            double aa = ((double)dt.ToBinary()) / 1000000000;
            dd[0] = (ushort)(1000 * (aa - Math.Floor(aa)));

            //MyTime.GetDateSec(tm,tt);
            //memcpy(date,&tm.tm_day,3*sizeof(int));
            tt = (dd[3] * 60 + dd[2]) * 60 + dd[1] + 0.001 * dd[0];
            s0 = 0.0;
            return atm(x, tt, ASoL, DSoL, ref s0, ref h, date);
        }

        void AngleSun(double T, double D, ref double ASoL, ref double DSoL)
        {
            DSoL = D + T / 86400.0;
            double TC = DSoL / 36525.0;
            double TC2 = TC * TC;
            double TC3 = TC2 * TC;
            double AL0 = 0.01675104 - 0.0000418 * TC - 0.000000126 * TC2;
            double aLAM = 4.881627933 + 628.3319507 * TC + 5.279620987e-6 * TC2;
            double H = 4.908229468 + 3.000526417e-2 * TC + 7.902463001e-6 * TC2 +
            5.817764173e-8 * TC3;
            double R = 4.523601515 - 33.75714624 * TC + 3.626406333e-5 * TC2 +
            3.87850945e-8 * TC3;
            double E0 = 0.4093197551 - 2.271109689e-4 * TC - 2.86040072e-8 * TC2 +
            8.77513e-9 * TC3 + 4.465134e-5 * Math.Cos(R);
            double DLH = aLAM - H;
            double DLH2 = 2.0 * DLH;
            double aLA0 = aLAM + 2.0 * AL0 * Math.Sin(DLH) + 1.25 * AL0 * AL0 * Math.Sin(DLH2);
            double DPSI = -17.23 * Math.Sin(R);
            double SL = Math.Sin(aLA0);
            double CL = Math.Cos(aLA0);
            double CE = Math.Cos(E0);
            double SE = Math.Sin(E0);
            double S1 = SL * CE / CL;
            double AL = Math.Atan(S1);
            if (CL < 0.0) AL += 3.141592654;
            if (AL < 0.0) AL += 6.283185308;
            ASoL = AL + (0.061164 * 15.0 * DPSI - 20.496) * 4.84813681e-6;
            DSoL = Math.Atan(SL * SE / Math.Sqrt(CL * CL + SL * SL * CE * CE)) - 9.936741207e-5 *
            SE * Math.Cos(ASoL);
        }




        static double days1900(DateTime dat)
        {
            //int y1975=1975;
            //      double a=1;
            //      a+=1;
            long db = shiftdat(dat);
            double d = 27393.5;
            int ii = 3;
            for (int i = 1975; i < dat.Year; i++)
            {
                d += 365.0;
                if (ii == 4)
                {
                    ii = 0;
                    d += 1.0;
                }
                ii++;
            }
            return d + db;
        }

        static long shiftdat(DateTime dat)
        {

            KDNEY[1] = 28;
            double a = .25 * ((double)1999);
            a = .25 * (double)dat.Year;
            int k = 4 * (int)(0.25 * (double)dat.Year);
            if (((int)(.25 * (double)dat.Year)) * 4 == dat.Year)
                KDNEY[1] = 29;
            int data = dat.Day - 1;
            if (dat.Month == 1) return data;
            for (int i = 1; i < dat.Month; i++) data += KDNEY[i];
            return data;
        }

        static double zvvr(double D)
        {
            double T1 = D / 36525.0;
            double T2 = T1 * T1;
            double R = 4.52360151 - 0.0009242202 * D + 0.00003626794 * T2;
            double FF = 0.196365056 + 0.230895722 * D - 0.00005604252 * T2;
            double DD = 6.12152393 + 0.212768711 * D - 0.00002504547 * T2;
            double SZV0 = 1.7399358945 + 0.0172027912737 * D +
            0.675587865e-5 * T2 +
            Math.Cos(0.409319754) * (-0.835464852e-4 * Math.Sin(R) -
            0.617119333e-5 * Math.Sin(2.0 * (R + FF + DD)));
            int SZ1 = (int)(SZV0 / 6.283185308);
            return SZV0 - SZ1 * 6.283185308;
        }



        #endregion

    }
}
