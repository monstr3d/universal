using BaseTypes.Attributes;
using BaseTypes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BaseTypes;

namespace DynamicAtmosphere.MSISE
{

    /// <summary>
    /// Dynamic atmosphere (MSISE)
    /// </summary>
    public class Atmosphere : IPhysicalUnitTypeAttribute
    {
        #region Fields

        #region Constants

        const Double type = 0;

        object[] ob = new object[2];

        // Earth angular velocity, rad/sec
        const double OMEGA_E = 7.2921151e-5;

        // Seconds in a sideral day, based on the above angular velocity
        const double SIDEREAL_DAY = 86164.0994556;

        // Earth polar radius, meters
        const double POLAR_RADIUS = 6356752.3;
        const double Rp2 = POLAR_RADIUS * POLAR_RADIUS;
        // Earth equatorial radius, meters
        const double EQUATORIAL_RADIUS = 6378137.0;

        const double Re2 = EQUATORIAL_RADIUS * EQUATORIAL_RADIUS;

        // Flattening coefficient
        const double FLAT = (EQUATORIAL_RADIUS - POLAR_RADIUS) / EQUATORIAL_RADIUS;

        // Eccentricity
        const double ECC = 0.081819190842622;
        const double ECC2 = ECC * ECC;

        const double EPS = 1.0 / EQUATORIAL_RADIUS;


        const double TO_DEGREE = 180 / Math.PI;


        static private readonly Dictionary<Type, int> dAtm = new Dictionary<Type, int>()
        {
            {typeof(MassType), 1},
            {typeof(LengthType), - 3}
        };


        static private readonly PhysicalUnitTypeAttribute atmAttr =
            new PhysicalUnitTypeAttribute(lengthType: LengthType.Centimeter, 
                massType: MassType.Gram);

        #endregion

        #region Coefficients

        double eps = EPS;

        double rp2 = Rp2;

        double equatorial_radius = EQUATORIAL_RADIUS;
 
        double re2 = Re2;
 
        double katm = 1;

        double k3 = 1;

        double kl = 1;

        #endregion

        #region Objects

        MSISEAtmosphere.Atmosphere atmosphere = new MSISEAtmosphere.Atmosphere();

        SunPosition.Calculator sunPosition = new SunPosition.Calculator();
 
        #endregion

        #region Parameters

        /// <summary>
        /// Physical type
        /// </summary>
        protected PhysicalUnitTypeAttribute physicalType = 
            new PhysicalUnitTypeAttribute(AngleType.Radian, LengthType.Meter, TimeType.Second, MassType.Gram);


        /// <summary>
        /// 81 day average of F10.7 flux (centered on doy)
        /// </summary>
        protected double f107A;  

        /// <summary>
        /// daily F10.7 flux for previous day
        /// </summary>
        protected double f107; 

        /// <summary>
        /// magnetic index(daily)
        /// </summary>
        protected double ap;     /* magnetic index(daily) */
            
        /// <summary>
        ///   0 : daily AP
        ///   1 : 3 hr AP index for current time
        ///   2 : 3 hr AP index for 3 hrs before current time
        ///   3 : 3 hr AP index for 6 hrs before current time
        ///   4 : 3 hr AP index for 9 hrs before current time
        ///   5 : Average of eight 3 hr AP indicies from 12 to 33 hrs 
        ///           prior to current time
        ///   6 : Average of eight 3 hr AP indicies from 36 to 57 hrs 
        ///           prior to current time 
        /// </summary>
        protected double[] ap_a = new double[7];



        /// <summary>
        ///   Switches: to turn on and off particular variations use these switches.
        ///   0 is off, 1 is on, and 2 is main effects off but cross terms on.
        ///
        ///   Standard values are 0 for switch 0 and 1 for switches 1 to 23. The 
        ///   array "switches" needs to be set accordingly by the calling program. 
        ///   The arrays sw and swc are set internally.
        ///
        ///   switches[i]:
        ///    i - explanation
        ///   -----------------
        ///    0 - output in centimeters instead of meters
        ///    1 - F10.7 effect on mean
        ///    2 - time independent
        ///    3 - symmetrical annual
        ///    4 - symmetrical semiannual
        ///    5 - asymmetrical annual
        ///    6 - asymmetrical semiannual
        ///    7 - diurnal
        ///    8 - semidiurnal
        ///    9 - daily ap [when this is set to -1 (!) the pointer
        ///                  ap_a in struct nrlmsise_input must
        ///                  point to a struct ap_array]
        ///   10 - all UT/long effects
        ///   11 - longitudinal
        ///   12 - UT and mixed UT/long
        ///   13 - mixed AP/UT/LONG
        ///   14 - terdiurnal
        ///   15 - departures from diffusive equilibrium
        ///   16 - all TINF var
        ///   17 - all TLB var
        ///   18 - all TN1 var
        ///   19 - all S var
        ///   20 - all TN2 var
        ///   21 - all NLB var
        ///   22 - all TN3 var
        ///   23 - turbo scale height var        
        /// </summary>
        protected int[] switches = new int[24];

        #endregion

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Atmosphere()
        {
          /*  init();
            If = ifa;*/
        }

        #endregion

        #region IPhysicalUnitTypeAttribute Members

        PhysicalUnitTypeAttribute IPhysicalUnitTypeAttribute.PhysicalUnitTypeAttribute
        {
            get
            {

                return physicalType;
            }
            set
            {
                if (physicalType == value)
                {
                    return;
                }
                physicalType.Change -= Set;
                physicalType = value;
                Set();
                physicalType.Change += Set;
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Atmospheric parameters
        /// </summary>
        /// <param name="time">Time</param>
        /// <param name="state">State</param>
        /// <param name="density">Density</param>
        /// <param name="temperature">Temperature</param>
        public void Calculate(DateTime time, double[] state, double[] density, double[] temperature)
        {
            double ASoL = 0, DSoL = 0, day, hour;
            sunPosition.GetPosition(time, out DSoL, out ASoL, out day, out hour);
            double lat, lon, height;
            double sec = time.TimeOfDay.TotalSeconds;
            CalculateGeodetic(state, out lat, out lon, out height);
            double lst = lst = sec / 3600 + lon / 15;
            atmosphere.Calculate(time.Year, time.DayOfYear, sec,
                height * kl, lat, lon, lst, f107A, f107, ap, ap_a, density, temperature);
            for (int i = 0; i < 9; i++)
            {
                if (i == 5)
                {
                    density[i] *= katm;
                }
                else
                {
                    density[i] *= k3;
                }

            }
        }


        /// <summary>
        /// 81 day average of F10.7 flux (centered on doy)
        /// </summary>
        public double F107A
        {
            get
            {
                return f107A;
            }
            set
            {
                f107A = value;
            }
        }
        
        /// <summary>
        /// Daily F10.7 flux for previous day
        /// </summary>
        public double F107
        {
            get
            {
                return f107;
            }
            set
            {
                f107 = value;
            }
        }
        
        /// <summary>
        /// magnetic index(daily)
        /// </summary>
        public double Ap
        {
            get
            {
                return ap;
            }
            set
            {
                ap = value;
            }
        }

        /// <summary>
        /// Array containing the following magnetic values:
        /// 0 : daily AP
        ///  1 : 3 hr AP index for current time
        ///  2 : 3 hr AP index for 3 hrs before current time
        ///  3 : 3 hr AP index for 6 hrs before current time
        ///  4 : 3 hr AP index for 9 hrs before current time
        ///  5 : Average of eight 3 hr AP indicies from 12 to 33 hrs 
        ///           prior to current time
        ///  6 : Average of eight 3 hr AP indicies from 36 to 57 hrs 
        ///          prior to current time 
        /// </summary>
        public double[] Ap_a
        {
            get
            {
                double[] x = new double[7];
                Array.Copy(ap_a, x, 7);
                return x;
            }
            set
            {
                Array.Copy(value, ap_a, 7);
            }
        }

        /// <summary>
        ///   Switches: to turn on and off particular variations use these switches.
        ///   0 is off, 1 is on, and 2 is main effects off but cross terms on.
        ///
        ///   Standard values are 0 for switch 0 and 1 for switches 1 to 23. The 
        ///   array "switches" needs to be set accordingly by the calling program. 
        ///   The arrays sw and swc are set internally.
        ///
        ///   switches[i]:
        ///    i - explanation
        ///   -----------------
        ///    0 - output in centimeters instead of meters
        ///    1 - F10.7 effect on mean
        ///    2 - time independent
        ///    3 - symmetrical annual
        ///    4 - symmetrical semiannual
        ///    5 - asymmetrical annual
        ///    6 - asymmetrical semiannual
        ///    7 - diurnal
        ///    8 - semidiurnal
        ///    9 - daily ap [when this is set to -1 (!) the pointer
        ///                  ap_a in struct nrlmsise_input must
        ///                  point to a struct ap_array]
        ///   10 - all UT/long effects
        ///   11 - longitudinal
        ///   12 - UT and mixed UT/long
        ///   13 - mixed AP/UT/LONG
        ///   14 - terdiurnal
        ///   15 - departures from diffusive equilibrium
        ///   16 - all TINF var
        ///   17 - all TLB var
        ///   18 - all TN1 var
        ///   19 - all S var
        ///   20 - all TN2 var
        ///   21 - all NLB var
        ///   22 - all TN3 var
        ///   23 - turbo scale height var        
        /// </summary>
        public int[] Switches
        {
            get
            {
                int[] x = new int[24];
                Array.Copy(switches, x, 24);
                return x;
            }
            set
            {
                Array.Copy(value, switches, 24);
                atmosphere.TSelec = value;
            }
        }



        #endregion

        #region Protected Members

        void Set()
        {
            kl = LengthType.Meter.Coefficient<LengthType>(physicalType.LengthType);
            eps = EPS / kl;
            double k2 = kl * kl;
            equatorial_radius = kl * EQUATORIAL_RADIUS;
            rp2 = k2 * Rp2;
            re2 = k2 * Re2;
            katm = atmAttr.Coefficient(physicalType, dAtm);
            k3 = 1 / (kl * kl * kl);
        }

        #endregion

        #region Private Members
 
        private double GetVerticalRadius(double c2, double s2)
        {
            return Re2 / Math.Sqrt((re2 * c2) + (rp2 * s2));
        }


        private void CalculateGeodetic(double rho, double z, out double latitude, out double height)
        {
            double lat1, lat2, h1, h2, Radius;

            lat2 = Math.Atan2(z, rho * (1.0 - ECC2));
            double c = Math.Cos(lat2);
            double s = Math.Sin(lat2);
            double c2 = c * c;
            double s2 = s * s;
            Radius = GetVerticalRadius(c2, s2);
            h2 = (rho / c) - Radius;

            do
            {
                lat1 = lat2;
                h1 = h2;

                lat2 = Math.Atan2(z, rho * (1.0 - ECC2));
                c = Math.Cos(lat2);
                s = Math.Sin(lat2);
                c2 = c * c;
                s2 = s * s;
                Radius = GetVerticalRadius(c2, s2);
                h2 = (rho / c) - Radius;

            }
            while (Math.Abs(h2 - h1) > 1.0 & Math.Abs(lat2 - lat1) > eps);
            latitude = lat2;
            height = h2;
        }

        private void CalculateGeodetic(double[] x, out double latitude, out double longitude, out double height)
        {
            double c = x[0];
            double s = x[1];
            longitude = Math.Atan2(s, c);
            CalculateGeodetic(Math.Sqrt(c * c + s * s), x[2], out latitude, out height);
        }

 
 
        #endregion

    }
}
