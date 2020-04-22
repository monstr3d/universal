using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommonMathOperations;

using RealMatrixProcessor;

using Vector3D;

namespace CelestialMechanics
{
    /// <summary>
    /// Elliptical orbit
    /// </summary>
    public class EllipticalOrbit : Orbit
    {

        #region Fields

        static double[] L = new double[3];

        static double[] W = new double[3];

        static double[] U = new double[3];

        double[,] qq = new double[4, 4];

        double pericenterDistance;
        double eccentricity;
        double inclination;
        double ascendingNode;
        double argOfPeriapsis;
        double meanAnomalyAtEpoch;
        double period;
        double epoch;

        Func<double, double> meanAnomalyFunc;

        Action<double, double[]> velocityAtEFunc;

    
        private static readonly int[] axis = new int[] { 3, 1, 3 };

        private double[] quaternion = new double[4];

        double[,] orbitPlaneRotation = new double[3, 3];

        double[] x = new double[3];
        double[] x1 = new double[3];

        double[] xSample = new double[3];

        double[] v = new double[3];
        double[] v1 = new double[3];
    
        Func<double> ecc;

        Action<double, double[]> positionAtEFunc;

        double meanMotion;

        double meanAnomaly;

        double E;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pericenterDistance">Pericenter Distance</param>
        /// <param name="eccentricity">Eccentricity</param>
        /// <param name="inclination">Inclination</param>
        /// <param name="ascendingNode">Ascending Node</param>
        /// <param name="argOfPeriapsis">Argument of Periapsis</param>
        /// <param name="meanAnomalyAtEpoch">Mean Anomaly at Epoch</param>
        /// <param name="period">Period</param>
        /// <param name="epoch">Epoch</param>
        public EllipticalOrbit(double pericenterDistance,
                                 double eccentricity,
                                 double inclination,
                                 double ascendingNode,
                                 double argOfPeriapsis,
                                 double meanAnomalyAtEpoch,
                                 double period,
                                 double epoch)
        {
            this.pericenterDistance = pericenterDistance;
            this.eccentricity = eccentricity;
            this.inclination = inclination;
            this.ascendingNode = ascendingNode;
            this.argOfPeriapsis = argOfPeriapsis;
            this.meanAnomalyAtEpoch = meanAnomalyAtEpoch;
            this.period = period;
            this.epoch = epoch;
            double[] angles = new double[] { ascendingNode, inclination, argOfPeriapsis };
            double[][] buffer = new double[][] { new double[4], new double[4] };
            double[] buff = new double[4];

            meanMotion = 2.0 * Math.PI / period;
            StaticExtensionVector3D.Rotate(angles, axis, quaternion, buffer, buff);
            quaternion.QuaternionToMatrix(orbitPlaneRotation, qq);
            if (eccentricity < 1.0)
            {
                positionAtEFunc = (double E, double[] x) =>
                {
                    double a = pericenterDistance / (1.0 - eccentricity);
                    x[0] = a * (Math.Cos(E) - eccentricity);
                    x[1] = a * Math.Sqrt(1 - (eccentricity * eccentricity)) * Math.Sin(E);
                };
                velocityAtEFunc = (double E, double[] x) =>
                    {
                        double a = pericenterDistance / (1.0 - eccentricity);
                        double sinE = Math.Sin(E);
                        double cosE = Math.Cos(E);

                        x[0] = -a * sinE;
                        x[1] = a * Math.Sqrt(1 - (eccentricity * eccentricity)) * cosE;

                        double mm = 2.0 * Math.PI / period;
                        double edot = mm / (1 - eccentricity * cosE);
                        x[0] *= edot;
                        x[1] *= edot;

                    };
            }
            else if (eccentricity > 1.0)
            {
                positionAtEFunc = (double E, double[] x) =>
                  {
                      double a = pericenterDistance / (1.0 - eccentricity);
                      x[0] = -a * (eccentricity - Math.Cosh(E));
                      x[1] = -a * Math.Sqrt((eccentricity * eccentricity) - 1) * Math.Sinh(E);
                  };
                velocityAtEFunc = (double E, double[] x) =>
      {
          double a = pericenterDistance / (1.0 - eccentricity);
          x[0] = -a * (eccentricity - Math.Cosh(E));
          x[1] = -a * Math.Sqrt((eccentricity * eccentricity) - 1) * Math.Sinh(E);
      };

            }
            else
            {
                // TODO: Handle parabolic orbits
                positionAtEFunc = (double E, double[] x) =>
                  {
                      x[0] = 0;
                      x[1] = 0;
                  };
                positionAtEFunc = (double E, double[] x) =>
                    {
                        x[0] = 0;
                        x[1] = 0;
                    };

            }

            meanAnomalyFunc = (double t) =>
                {
                    return meanAnomalyAtEpoch + meanMotion * t;
                };

            double err = 0;
            if (eccentricity == 0)
            {
                ecc = () => { return meanAnomaly; };
            }
            else if (eccentricity < 0.2)
            {
                Func<double, double> f = SolveKeplerFunc1;

                ecc = () =>
                    {
                        return f.SolveIterationFixed(10, meanAnomaly, out err);
                    };

            }
            else if (eccentricity < 0.9)
            {
                // Higher eccentricity elliptical orbit; use a more complex but
                // much faster converging iteration.
                Func<double, double> f = SolveKeplerFunc2;
                ecc = () =>
               {
                   return f.SolveIterationFixed(6, meanAnomaly, out err);
               };
            }
            else if (eccentricity < 1.0)
            {
                // Extremely stable Laguerre-Conway method for solving Kepler's
                // equation.  Only use this for high-eccentricity orbits, as it
                // requires more calcuation.
                Func<double, double> f = SolveKeplerLaguerreConway;
                ecc = () =>
                      {
                          E = meanAnomaly + 0.85 * eccentricity * Math.Sign(Math.Sin(meanAnomaly));
                          return f.SolveIterationFixed(9, meanAnomaly, out err);
                      };
            }
            else if (eccentricity == 1.0)
            {
                // Nearly parabolic orbit; very common for comets
                // TODO: handle this
                ecc = () => { return meanAnomaly; };
            }
            else
            {
                // Laguerre-Conway method for hyperbolic (ecc > 1) orbits.
                Func<double, double> f = SolveKeplerLaguerreConwayHyp;
                ecc = () =>
                    {
                        E = Math.Log(2 * meanAnomaly / eccentricity + 1.85);
                        return f.SolveIterationFixed(30, meanAnomaly, out err);
                    };
            }
        }


        #endregion

        #region Overriden

         /// <summary>
        ///  Return the position in the orbit's reference frame at the specified
        ///  time (TDB). Units are kilometers.
        /// </summary>
        /// <param name="jd">Time</param>
        /// <param name="position">Position</param>
        public override void positionAtTime(double jd, double[] position)
        {
            double E = eccentricAnomaly(jd);
            positionAtEFunc(E, x);
            RealMatrix.Multiply(orbitPlaneRotation, x, position);
        }



        /// <summary>
        /// Return the orbital velocity in the orbit's reference frame at the
        ///  specified time (TDB). Units are kilometers per day. If the method
        ///  is not overridden, the velocity will be computed by differentiation
        ///  of position.
        /// </summary>
        /// <param name="time">Time</param>
        /// <param name="velocity">Orbital velocity in the orbit's reference</param>
        public override void velocityAtTime(double time, double[] velocity)
        {
            double E = eccentricAnomaly(time);
            velocityAtEFunc(E, v);
            RealMatrix.Multiply(orbitPlaneRotation, v, velocity);
        }

        /// <summary>
        /// Return the orbital velocity in the orbit's reference frame at the
        ///  specified time (TDB). Units are kilometers per day. If the method
        ///  is not overridden, the velocity will be computed by differentiation
        ///  of position.
        /// </summary>
        /// <param name="time">Time</param>
        /// <param name="vector">Orbital state in the orbit's reference</param>
        public override void vectorAtTime(double time, double[] vector)
        {
            double E = eccentricAnomaly(time); // Eccentric anomaly

            positionAtEFunc(E, x);              // Position
            RealMatrix.Multiply(orbitPlaneRotation, x, x1);
            Array.Copy(x1, vector, 3);

            velocityAtEFunc(E, v);              // Velocity
            RealMatrix.Multiply(orbitPlaneRotation, v, v1);
            Array.Copy(v1, 0, vector, 3, 3);
        }


        /// <summary>
        /// Period
        /// </summary>
        public override double Period
        {
            get
            {
                return period;
            }
        }

        /// <summary>
        /// Bounding radius
        /// </summary>
        public override double BoundingRadius
        {
            get
            {
                return pericenterDistance * ((1.0 + eccentricity) / (1.0 - eccentricity));
            }
        }

        /// <summary>
        /// Sample
        /// </summary>
        /// <param name="start">Start</param>
        /// <param name="t">Time</param>
        /// <param name="nSamples">Number of samples</param>
        /// <param name="sample">Sample function</param>
        public override void sample(double start, double t,
                             int nSamples, Action<double, double[]> sample)
        {
            if (eccentricity >= 1.0)
            {
                double dE = 1 * Math.PI / (double)nSamples;
                for (int i = 0; i < nSamples; i++)
                {
                    positionAtEFunc(dE * i, xSample);
                    sample(t, xSample);
                }
            }
            else
            {
                // Adaptive sampling of the orbit; more samples in regions of high curvature.
                // nSamples is the number of samples that will be used for a perfectly circular
                // orbit. Elliptical orbits will have regions of higher curvature thar require
                // additional sample points.
                double E = 0.0;
                double dE = 2 * Math.PI / (double)nSamples;
                double w = (1 - (eccentricity * eccentricity));
                double M0 = E - eccentricity * Math.Sin(E);

                while (E < 2 * Math.PI)
                {
                    // Compute the time tag for this sample
                    double ce = Math.Cos(E);
                    double se = Math.Sin(E);
                    double M = E - eccentricity * se;           // Mean anomaly from ecc anomaly
                    double tsamp = t + (M - M0) * period / (2 * Math.PI); // Time from mean anomaly
                    positionAtEFunc(E, xSample);
                    sample(tsamp, xSample);

                    // Compute the curvature
                     double k = w * Math.Pow((se * se) + w * w * (ce * ce), -1.5);

                    // Step amount based on curvature--constrain it so that we don't end up
                    // taking too many samples anywhere. Clamping the curvature to 20 effectively
                    // limits the numbers of samples to 3*nSamples
                    E += dE / Math.Max(Math.Min(k, 20.0), 1.0);
                }
            }

        }

        /// <summary>
        /// "Is periodic" sign
        /// </summary>
        public override bool IsPeriodic
        {
            get { return true; }
        }

        /// <summary>
        /// Return the time range over which the orbit is valid; if the orbit
        /// is always valid, begin and end should be equal.
        /// </summary>
        /// <param name="begin">Begin of interval</param>
        /// <param name="end">End of interval</param>
        public override void getValidRange(out double begin, out double end)
        {
            begin = 0.0;
            end = 0.0;
        }


        #endregion

        #region Public

        static public Orbit StateVectorToOrbit(
          double[] position, double[] v, double gravityParameter, double time)
        {
             double pericenterDistance;
                                 double eccentricity;
                                 double inclination;
                                 double ascendingNode;
                                 double argOfPeriapsis;
                                 double meanAnomalyAtEpoch;
                                 double period;

                                 StateVectorToOrbit(position, v, gravityParameter, time,
                                     out pericenterDistance,
                                     out eccentricity,
                                     out inclination,
                                     out ascendingNode,
                                     out argOfPeriapsis,
                                     out meanAnomalyAtEpoch,
                                     out period);
                                 return
                     new EllipticalOrbit(pericenterDistance, eccentricity, inclination,
                         ascendingNode, argOfPeriapsis, meanAnomalyAtEpoch, period, time);
            
        }

        static public void StateVectorToOrbit(
            double[] position, double[] v, double gravityParameter, double time,
           out double pericenterDistance,
                                 out double eccentricity,
                                 out double inclination,
                                 out double ascendingNode,
                                 out double argOfPeriapsis,
                                 out double meanAnomalyAtEpoch,
                                 out double period)
        {
            //Vec3d R = position - Point3d(0.0, 0.0, 0.0);
            StaticExtensionVector3D.VectorPoduct(position, v, L);
            double magR = position.Norm();
            double magL = L.Norm();
            double magV = v.Norm();
            L.Multiply(1 / magL);
            StaticExtensionVector3D.VectorPoduct(L, position, W);
            W.Multiply(1 / magR);



           /* double G = Astro.G * 1e-9; // convert from meters to kilometers
            double GM = G * 
                
                gravityParameter;*/

            // Compute the semimajor axis
            double a = 1.0 / (2.0 / magR - (magV * magV) / gravityParameter);

            // Compute the eccentricity
            double p = (magL * magL) / gravityParameter;
            double q = position.ScalarProduct(v);
            double ex = 1.0 - magR / a;
            double ey = q / Math.Sqrt(a * gravityParameter);
            eccentricity = Math.Sqrt(ex * ex + ey * ey);

            // Compute the mean anomaly
            double E = Math.Atan2(ey, ex);
            meanAnomalyAtEpoch = E - eccentricity * Math.Sin(E);

            double cosi = L[1];
            inclination = 0.0;
            if (cosi < 1.0)
            {
                inclination = Math.Acos(cosi);
            }

            // Compute the longitude of ascending node
            ascendingNode = Math.Atan2(L[0], L[2]);

            // Compute the argument of pericenter
            Array.Copy(position, U, 3);
            U.Multiply(1 / magR);

            double s_nu = StaticExtensionVector3D.ScalarProduct(v, U) * Math.Sqrt(p / gravityParameter);
            double c_nu = StaticExtensionVector3D.ScalarProduct(v, W) * Math.Sqrt(p / gravityParameter) - 1;
            s_nu /= eccentricity;
            c_nu /= eccentricity;
  
            double P = U[1] * c_nu - W[1] * s_nu;
            double Q = U[1] * s_nu + W[1] * s_nu;

            argOfPeriapsis = Math.Atan2(P, Q);

            // Compute the period
            period = 2 * Math.PI * Math.Sqrt((a * a * a) / gravityParameter);
  
            pericenterDistance = a * (1 - eccentricity);///, e, i, Om, om, M, T, t);
        }

        /// <summary>
        /// Calculates Pericenter Distance from Period
        /// </summary>
        /// <param name="gravityParameter">Gravity parameter in 
        /// F = gravityParameter * M * m / r ^ 3 low </param>
        /// <param name="eccentricity">Eccentricity</param>
        /// <param name="period">Period</param>
        /// <returns>Pericenter Distance</returns>
        static public double PericenterDistanceFromPeriod(double gravityParameter,
            double eccentricity, double period)
        {
            double a = period / (2 * Math.PI);
            a *= a;
            a *= gravityParameter;
            a = Math.Pow(a, 1.0 / 3.0);
            return a * (1 - eccentricity);
        }

        /// <summary>
        /// Calculates Period from Pericenter Distance
        /// </summary>
        /// <param name="gravityParameter">Gravity parameter in 
        /// F = gravityParameter * M * m / r ^ 3 low </param>
        /// <param name="eccentricity">Eccentricity</param>
        /// <param name="pericenterDistance">Pericenter Distance</param>
        /// <returns>Period</returns>
        static public double PeriodFromPericenterDistance(double gravityParameter,
            double eccentricity, double pericenterDistance)
        {
            double a = pericenterDistance / (1 - eccentricity);
            /*/!!! TEST OF TEST ==========
            a += 0.000001;
            //==============*/
            return 2 * Math.PI * Math.Sqrt((a * a * a) / gravityParameter);
        }
            


        #endregion

        #region Protected

        protected double eccentricAnomaly(double time)
        {
            meanAnomaly = meanAnomalyFunc(time - epoch);
            return ecc();
        }

        #endregion

        #region Private

 
        double SolveKeplerFunc1(double x)
        {
            return meanAnomaly + eccentricity * Math.Sin(x);
        }



        double SolveKeplerFunc2(double x)
        {
            return x + (meanAnomaly + eccentricity * Math.Sin(x) - x) / (1 - eccentricity * Math.Cos(x));
        }


        double SolveKeplerLaguerreConway(double x)
        {
            double s = E * Math.Sin(x);
            double c = E * Math.Cos(x);
            double f = x - s - meanAnomaly;
            double f1 = 1 - c;
            double f2 = s;
            double y = x - 5 * f / (f1 + Math.Sign(f1) * Math.Sqrt(Math.Abs(16 * f1 * f1 - 20 * f * f2)));

            return y;
        }


        double SolveKeplerLaguerreConwayHyp(double x)
        {
            double s = E * Math.Sinh(x);
            double c = E * Math.Cosh(x);
            double f = s - x - meanAnomaly;
            double f1 = c - 1;
            double f2 = s;
            return  x - (5 * f) / (f1 + Math.Sign(f1) * Math.Sqrt(Math.Abs(16 * f1 * f1 - 20 * f * f2)));

        }



        #endregion
    }
}