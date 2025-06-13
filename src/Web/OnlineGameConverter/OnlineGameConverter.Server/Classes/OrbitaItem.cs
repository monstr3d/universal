using System.ComponentModel.DataAnnotations;

namespace OnlineGameConverter.Server.Classes
{
    public record class OrbitaForecastItem
    {
    /*    public OrbitaForecastItem(DateTime datetime, double x,
            double y, double z, double Vx, double Vy, double Vz)
        {
            DateTime = datetime;
            X = x;
            Y = y;
            Z = z;
            this.Vx = Vx;
            this.Vy = Vy;
            this.Vz = Vz;
        }
    */

        [Display(Name = "Forecast start")]
        public DateTime DateTime { get; private set; }


       [Display(Name = "X - coordinate, km")]
        public double X { get; private set; }

        [Display(Name = "Y - coordinate, km")]
        public double Y { get; private set; }
        
        [Display(Name = "Z - coordinate, km")]
        public double Z { get; private set; }

        [Display(Name = "Vx - velocity, km/s")]
        public double Vx { get; private set; }

        [Display(Name = "Vy - velocity, km/s")]
        public double Vy { get; private set; }

        [Display(Name = "Vz - velocity, km/s")]
        public double Vz { get; private set; }



    }
}
