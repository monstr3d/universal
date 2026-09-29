package linear_algebra;

public class RealMatrix {
    public double normalize(double[] inp, double[] outp, int offset)
    {
        double a = 0;
        for (int i = offset; i < outp.length + offset; i++)
        {
            double b = inp[i];
            a += b * b;
        }
        a = Math.sqrt(a);
        double c = 1 / a;
        for (int i = 0; i < outp.length; i++)
        {
            outp[i] = c * inp[i + offset];
        }
        return a;
    }

}
