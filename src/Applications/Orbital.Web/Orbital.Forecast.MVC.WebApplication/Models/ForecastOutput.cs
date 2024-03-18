
using System.ComponentModel.DataAnnotations;

namespace Orbital.Forecast.MVC.WebApplication.Models
{
    public class ForecastOutput
    {
        private ForecastOutput(List<object> data)
        {
            Time = DateTime.FromOADate((double)data[0] / 86400);
            X = (double)data[1];
            Y = (double)data[2];
            Z = (double)data[3];
            Vx = (double)data[4];
            Vy = (double)data[5];
            Vz = (double)data[6];
        }

        [Display(Name = "Time")]
        [Required(ErrorMessage = "Time")]
        public DateTime Time {  get; private set; }

        /// <summary>
        /// X - coordinate
        /// </summary>
        [Display(Name = "X - coordinate")]
        [Required(ErrorMessage = "X - coordinate")]
        public double X { get; private set; }
  
        /// <summary>
        /// Y - coordinate
        /// </summary>
        [Display(Name = "Y - coordinate")]
        [Required(ErrorMessage = "Y - coordinate")]
        public double Y { get; private set; }
    
        /// <summary>
        /// X - coordinate
        /// </summary>
        [Display(Name = "Z - coordinate")]
        [Required(ErrorMessage = "Z - coordinate")]
        public double Z { get; private set; }

        /// <summary>
        /// X - velocity
        /// </summary>
        [Display(Name = "X - velocity")]
        [Required(ErrorMessage = "X - velocity")]
        public double Vx { get; private set; }
  
        /// <summary>
        /// Y - velocity
        /// </summary>
        [Display(Name = "Y - velocity")]
        [Required(ErrorMessage = "Y - velocity")]
        public double Vy { get; private set; }
  

        /// <summary>
        /// Z - velocity
        /// </summary>
        [Display(Name = "Z - velocity")]
        [Required(ErrorMessage = "Z - velocity")]
        public double Vz { get; private set; }

        static public IEnumerable<ForecastOutput> FromList(List<List<object>> list)
        {
            foreach (var item in list)
            {
                yield return new ForecastOutput(item);
            }
        }
    }
}
