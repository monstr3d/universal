using System.ComponentModel.DataAnnotations;

namespace OnlineGameConverter.Server.Classes.Orbital
{

    public  class OrbitaForecastItem
    {

        [Display(Name = "Forecast start")]
        public DateTime DateTime { get; init; }


        [Display(Name = "X - coordinate, km")]
        public double X { get; init; }

        [Display(Name = "Y - coordinate, km")]
        public double Y { get; init; }

        [Display(Name = "Z - coordinate, km")]
        public double Z { get; init; }

        [Display(Name = "Vx - velocity, km/s")]
        public double Vx { get; init; }

        [Display(Name = "Vy - velocity, km/s")]
        public double Vy { get; init; }

        [Display(Name = "Vz - velocity, km/s")]
        public double Vz { get; init; }

    }

  

    public  class OrbitalForecastItemNumber 
    {
        [Display(Name = "Time of equator, s")]
        public double OrbitalTime { get; init; }

        [Display(Name = "X - coordinate, km")]
         public double X { get; init; }

        [Display(Name = "Y - coordinate, km")]
        public double Y { get; init; }

        [Display(Name = "Z - coordinate, km")]
        public double Z { get; init; }

        [Display(Name = "Vx - velocity, km/s")]
        public double Vx { get; init; }

        [Display(Name = "Vy - velocity, km/s")]
        public double Vy { get; init; }

        [Display(Name = "Vz - velocity, km/s")]
        public double Vz { get; init; }

        [Display(Name = "Duration of calculation, ms")]
        public long Duration { get; init; }

    }
}
