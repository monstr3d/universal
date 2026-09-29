package external.atmosphere;

import external.geography.GeoCoordinates;
import external.sun.service.SunCoordinates;
import external.sun.service.SunPosition;
import external.sun.service.SunTime;
import external.utilities.date_time.OADateConverter;
import linear_algebra.RealMatrix;

import java.time.LocalDateTime;

public class DynamicalAtmosphere
{

    double[] ASoL = new double[]{0};
    double[] DSoL = new double[]{0};
    double[] ed = new double[]{0};
    double[] eh = new double[]{0};

    double[] h = new double[]{0};


    protected Object[] ob = new Object[2];

    static public String[] sins = new String[] { "t", "x", "y", "z" };

    static public String[] sous = new String[] { "Density" };

    static public int[] mac = { 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334, 365 };
    static public double[] f01 ={-14.608, 0.8969, 67.596, -0.4016, 0.3031E-2, 0.2344E-5, 0.130,
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
    static public double[] f0 = {
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
    static public double[] ad ={
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
    private final double[] r = new double[3];
    private final double[] y = new double[3];
    private double[][] ff0;
    private double[][] ff1;
    double ome = 7.292115085E-5;
    private final short [] dd = new short[4];
    protected double[] xout = new double[3];

    private final GeoCoordinates coordinates = new GeoCoordinates();

    private final SunCoordinates sunCoordinates = new SunCoordinates();

    private final RealMatrix realMatrix = new RealMatrix();

    public DynamicalAtmosphere()
    {
        init();
        setIf(ifa);
    }

    public void setIf(int[] value) {
        N10 = 0;
        for (int i = 0; i < 6; i++) {
            if (if1[i] == value[0]) {
                break;
            } else {
                N10++;
            }
        }
        ifa[0] = value[0];
        ifa[1] = value[1];
        ifa[2] = value[2];
    }

    private void init()
    {
        if (ff0 != null)
        {
            return;
        }
        ff0 = new double[f0.length / 21][];
        ff1 = new double[f0.length / 21][];
        for (int i = 0; i < ff0.length; i++)
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



    public double atmosphere(double t, double[] x)
    {
        var r2 = x[0] * x[0] + x[1] * x[1];
        var lat =Math.atan2(x[2],Math.sqrt(r2));
        var lon =Math.atan2(x[1], x[0]);
        coordinates.setLatitude(lat);
        coordinates.setLongitude(lon);
        double tday = t / 86400;
        LocalDateTime dt = OADateConverter.fromOADate(tday);
        var hh = realMatrix.normalize(x, y, 0);
        int ho = dt.getHour();
        int mi = dt.getMinute();
        int ss = dt.getSecond();
        long it = (long)t;
        double sss = 1000 * (t - (double)(it));
        double tt = (ho * 60 + mi) * 60 + ss + .001 * sss;
        SunPosition.getPosition(dt,  coordinates, sunCoordinates, ASoL, DSoL,  ed, eh);
        var alphastar = SunTime.CalculateGreenwichSiderealTime(dt);
        date[0] = dt.getDayOfMonth();
        date[1] = dt.getMonthValue();
        date[2] = dt.getYear();
        var rho = atm(x, tt, DSoL[0], ASoL[0], alphastar, h, date);
        return rho;

    }

    /// <summary>
    /// Atmosphere parameters
    /// </summary>
    /// 
    public  int[] getIf()
    {
        return ifa;
    }
    

    double rad(double[] x) {
        double a = 0;
        for (int i = 0; i < 3; i++) {
            a += x[i] * x[i];
        }
        return Math.sqrt(a);
    }

    double atm(double[] x, double t, double alf, double del, double s0, double[] h, int[] it)
    {
        double hh = rad(x);

     for (int i = 0; i < 3; i++) {
         y[i] = x[i] / hh;
     }
        h[0] = hh - 6378.140 * (1.0 - 0.335282E-2 * y[2] * y[2]);
        if (h[0] <= 180)
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
            if (Math.abs(Math.floor(dat2 + .00001) - dat2) < .0001)
                a2 = (mac[N3 - 1] + 1 + it[0]) / 10.0;
            else
                a2 = (mac[N3 - 1] + it[0]) / 10.0;
        }
        int N2 = (int)Math.floor(a2);
        double a3 = a2 - N2;
        N2++;
        double ad1 = ad[N2 - 1] + (ad[N2] - ad[N2 - 1]) * a3;
        double gam = alf + f1[12] - s0 - ome * (t - 10800.0);
        double cosfi = y[2] * Math.sin(del) + Math.cos(del) * (y[0] * Math.cos(gam) +
                y[1] * Math.sin(gam));
        double xk4 = 1 + (f1[16] + f1[17] * h[0] + f1[18] * h[0] * h[0]) *
                Math.log(ifa[1] / f1[20] + f1[19]);
        double xk3 = 1 + (f1[13] + f1[14] * h[0] + f1[15] * h[0] * h[0]) * ad1;
        double cosfi2 = Math.abs((1.0 + cosfi) / 2.0);
        double xk2 = 1 + (f1[6] + f1[7] * h[0] + f1[8] * Math.exp(-(h[0] + f1[9]) / f1[10]
                * (h[0] + f1[9]) / f1[10])) * Math.pow(cosfi2, f1[11] / 2);
        double xk1 = 1.0 + (f1[3] + f1[4] * h[0] + f1[5] * h[0] * h[0]) * (ifa[2] - ifa[0]) / ifa[0];
        double roh = Math.exp(f1[0] - f1[1] *Math.sqrt(h[0] - f1[2]));
        return roh * xk1 * xk2 * xk3 * xk4;
    }

}
