using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using OnlineGameConverter.Server.BusinessLogic.Orbital;
using OnlineGameConverter.Server.Classes;
using OnlineGameConverter.Server.Interfaces;

namespace OnlineGameConverter.Server.Pages
{
    public class   OrbitalForecastRazorModel :  PageModel
    {
        #region Ctor

     
        public OrbitalForecastRazorModel(IConfiguration config, 
            IForecastConditionSingleton forecastConditionSingleton)
        {
            ForecastCondition c = null;
            ForecastConditionSingleton = forecastConditionSingleton;
            if (forecastConditionSingleton != null)
            {
                c = forecastConditionSingleton.ForecastCondition;
                if (c != null)
                {
                    Begin = c.Begin;
                    End = c.End;
                    X = c.X;
                    Y = c.Y;
                    Z = c.Z;
                    Vx = c.Vx;
                    Vy = c.Vy;
                    Vz = c.Vz;
                    return;
                }
            }
            Begin = DateTime.Now;
            End = Begin + TimeSpan.FromDays(3);
            Diagram.UI.Interfaces.IDesktop  orb = new OrbitalForecast();
            var ali = Performer.GetAllAliases(orb);
            X = (double)ali["Motion equations.x"];
            Y = (double)ali["Motion equations.y"];
            Z = (double)ali["Motion equations.z"];
            Vx = (double)ali["Motion equations.u"];
            Vy = (double)ali["Motion equations.v"];
            Vz = (double)ali["Motion equations.w"];

        }
        #endregion

        #region Private

        private IForecastConditionSingleton ForecastConditionSingleton { get; set; }

    Diagram.UI.Performer Performer { get; set; } = new Diagram.UI.Performer();  


        #endregion


        public void OnGet()
        {
        }




        [BindProperty]
        [Required]
        [Display(Name = "Begin")]
        [DataType(DataType.Date)]
        public DateTime Begin { get; private set; }

        public string BeginStr => Begin.ToString();

        [BindProperty]
        [Required]
        [Display(Name = "End")]
        [DataType(DataType.Date)]
        public DateTime End { get; private set; }

        [BindProperty]
        [Required]
        [Display(Name = "X - coordinate, km")]
        public double X { get; private set; }

        [BindProperty]
        [Required]
        [Display(Name = "Y - coordinate, km")]
        public double Y { get; private set; }

        [BindProperty]
        [Required]
        [Display(Name = "Z - coordinate, km")]
        public double Z { get; private set; }

        [BindProperty]
        [Required]
        [Display(Name = "Vx - velocity, km/s")]
        public double Vx { get; private set; }

        [BindProperty]
        [Required]
        [Display(Name = "Vy - velocity, km/s")]
        public double Vy { get; private set; }

        [BindProperty]
        [Required]
        [Display(Name = "Vz - velocity, km/s")]
        public double Vz { get; private set; }


    }
}
