using System.ComponentModel.DataAnnotations;

namespace OnlineGameConverter.Server.Classes
{
    public record class OrbitalForecastItem
    {
   

        [Display(Name = "Time")]
        public DateTime DateTime { get;  set; }


        [Display(Name = "X - coordinate, km")]
        public double X { get;  set; }

        [Display(Name = "Y - coordinate, km")]
        public double Y { get;  set; }

        [Display(Name = "Z - coordinate, km")]
        public double Z { get;  set; }

        [Display(Name = "Vx - velocity, km/s")]
        public double Vx { get;  set; }

        [Display(Name = "Vy - velocity, km/s")]
        public double Vy { get;  set; }

        [Display(Name = "Vz - velocity, km/s")]
        public double Vz { get;  set; }



    }

    public class OrbitalForecastItemNumber
    {
         public double EquatorTime { get; set; }

       public double X { get; set; }

          public double Y { get; set; }
        public double Z { get; set; }

        public double Vx { get; set; }
        public double Vy { get; set; }

        public double Vz { get; set; }

    }

    public class OrbitalForecastItemString
    {
        public string EquatorTime { get; set; }

        public string X { get; set; }

        public string Y { get; set; }
        public string Z { get; set; }

        public string Vx { get; set; }
        public string Vy { get; set; }

        public string Vz { get; set; }

    }



}
