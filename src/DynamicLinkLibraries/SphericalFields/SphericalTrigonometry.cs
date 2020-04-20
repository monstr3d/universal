using System;
using System.Collections.Generic;
using System.Text;

namespace SphericalFields
{
    /// <summary>
    /// Functions of spherical trinonometry
    /// </summary>
    public class SphericalTrigonometry
    {


        static public void CalculateSphericalCoorditates(double[] x, out double ctheta, out double stheta, 
            out double cphi, out double sphi, out double rho, out double r)
        {
            double rho2 = (x[0] * x[0]) + (x[1] * x[1]);
            rho = Math.Sqrt(rho2);
            double r2 = rho2 + (x[2] * x[2]);
            r = Math.Sqrt(r2);
            cphi = (x[0] / rho);
            sphi = (x[1] / rho);
            ctheta = (rho / r);
            stheta = (x[2] / r);
        }

    }
}
