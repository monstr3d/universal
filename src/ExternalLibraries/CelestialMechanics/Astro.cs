using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelestialMechanics
{
    /// <summary>
    /// Astro constants
    /// </summary>
    public static class Astro
    {
        public const double J2000 = 2451545.0;

      // !!! OLD VALUE OF CELESTIA SOFTWARE  public const double G = 6.672e-11; // N m^2 / kg^2

        /// <summary>
        /// Gravity constant 6.674 28 (+/- 0.000 67) x 10-11 m3 kg-1 s -2
        /// Read more: http://www.universetoday.com/43227/gravity-constant/#ixzz2HxUNrwMk
        /// </summary>
        public const double G = 6.67428e-11;

        


        public const double SolarMass = 1.989e30;
        //!!! OLD VALUE public const double EarthMass = 5.976e24;
        /// <summary>
        /// Mass of Earth KG.
        /// </summary>
        public const double EarthMass = 5.9736E24;
        public const double LunarMass = 7.354e22;

        public const double SOLAR_IRRADIANCE = 1367.6;        // Watts / m^2
        public const double SOLAR_POWER = 3.8462e26;  // Watts

        public const double ORBITAL_VELOCITY_DIFF_DELTA = 1.0 / 1440.0;

        // Angle between J2000 mean equator and the ecliptic plane.
        // 23 deg 26' 21".448 (Seidelmann, _Explanatory Supplement to the
        // Astronomical Almanac_ (1992), eqn 3.222-1.
        //public const  double J2000Obliquity = degToRad(23.4392911); 
    }
}
