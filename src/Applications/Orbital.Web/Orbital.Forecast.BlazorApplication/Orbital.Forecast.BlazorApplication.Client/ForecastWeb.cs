using System.ComponentModel.DataAnnotations;

using Diagram.UI.Interfaces;
using DataPerformer.Interfaces;
using DataPerformer.Portable.DifferentialEquationProcessors;

namespace Orbital.Forecast.Blasor
{
    public class ForecastWeb
    {


        #region Fields
        GeneratedProject.Forecast.InternalDesktop forecast =
            GeneratedProject.Forecast.Desktop as
            GeneratedProject.Forecast.InternalDesktop;


        DinAtm.Portable.Atmosphere atmosphere;
        DataPerformer.Formula.DifferentialEquationSolver solver;
        IAlias alias;
        IAlias atm;
        DataPerformer.Portable.DataConsumer dataConsumer;
        DataPerformer.Portable.Wrappers.DataConsumerWrapper wrapper;

        #endregion

        /// <summary>
        /// Consructor
        /// </summary>
        public ForecastWeb()
        {
            atmosphere = forecast.GetObject("Atmosphere") as DinAtm.Portable.Atmosphere;
            atm = atmosphere;
            solver = forecast.GetObject("Motion equations") as DataPerformer.Formula.DifferentialEquationSolver;
            alias = solver;
            dataConsumer = forecast.GetObject("Chart") as DataPerformer.Portable.DataConsumer;
            wrapper = new DataPerformer.Portable.Wrappers.DataConsumerWrapper(dataConsumer);
        }

        internal DataPerformer.Portable.DataConsumer Consumer
        { get => dataConsumer; }

        [Display(Name = "Start time")]
        [Required(ErrorMessage = "Start time")]
        public DateTime Time { get; set; } = DateTime.Now;

        /// <summary>
        /// X - coordinate
        /// </summary>
        [Display(Name = "X - coordinate")]
        [Required(ErrorMessage = "X - coordinate")]
        public double X
        {
            get => (double)alias["x"];
            set => alias["x"] = value;
        }

  
        /// <summary>
        /// Y - coordinate
        /// </summary>
        [Display(Name = "Y - coordinate")]
        [Required(ErrorMessage = "Y - coordinate")]
        public double Y
        {
            get => (double)alias["y"];
            set => alias["y"] = value;
        }

        /// <summary>
        /// X - coordinate
        /// </summary>
        [Display(Name = "Z - coordinate")]
        [Required(ErrorMessage = "Z - coordinate")]
        public double Z
        {
            get => (double)alias["z"];
            set => alias["z"] = value;
        }

        /// <summary>
        /// X - velocity
        /// </summary>
        [Display(Name = "X - velocity")]
        [Required(ErrorMessage = "X - velocity")]
        public double Vx
        {
            get => (double)alias["u"];
            set => alias["u"] = value;
        }

        /// <summary>
        /// Y - velocity
        /// </summary>
        [Display(Name = "Y - velocity")]
        [Required(ErrorMessage = "Y - velocity")]
        public double Vy
        {
            get => (double)alias["v"];
            set => alias["v"] = value;
        }


        /// <summary>
        /// Z - velocity
        /// </summary>
        [Display(Name = "Z - velocity")]
        [Required(ErrorMessage = "Z - velocity")]
        public double Vz
        {
            get => (double)alias["w"];
            set => alias["w"] = value;
        }

        /// <summary>
        /// X - coordinate
        /// </summary>
        [Display(Name = "Ballistic coefficient")]
        [Required(ErrorMessage = "Ballistic coefficient")]
        public double S
        {
            get => (double)alias["s"] * 100000000000;
            set => alias["s"] = value / 100000000000;
        }


        /// <summary>
        /// Atmospheric parameter F107A
        /// </summary>
        [Display(Name = "Atmospheric parameter F107A")]
        [Required(ErrorMessage = "Atmospheric parameter F107A")]
        public int F107A
        {
            get => (int)atm["F107A"];
            set => atm["F107A"] = value;
        }

        /// <summary>
        /// Atmospheric parameter F107A
        /// </summary>
        [Display(Name = "Atmospheric parameter F107")]
        [Required(ErrorMessage = "Atmospheric parameter F107")]
        public int F107
        {
            get => (int)atm["F107"];
            set => atm["F107"] = value;
        }

        /// <summary>
        /// Atmospheric parameter F107A
        /// </summary>
        [Display(Name = "Atmospheric parameter Ap")]
        [Required(ErrorMessage = "Atmospheric parameter Ap")]
        public int Ap
        {
            get => (int)atm["Ap"];
            set => atm["Ap"] = value;
        }

        /// <summary>
        /// Count of steps
        /// </summary>
        [Display(Name = "Count of steps")]
        [Required(ErrorMessage = "Count of steps")]
        public int Count
        { get; set; } = 1800;

        public List<List<object>> Values
        {
            get
            {
                var dt = Time.ToOADate() * 86400;
                string[] par = ["Vector.Formula_8",
                    "Motion equations.x", "Motion equations.y", "Motion equations.z",
                "Motion equations.u", "Motion equations.v", "Motion equations.w"];
                var l = wrapper.PerformFixed(dt, 1, Count,
                   new DataPerformer.Portable.Helpers.TimeMeasurementProvider(null),
                   DifferentialEquationProcessor.Processor,
                   StaticExtensionDataPerformerInterfaces.Calculation, 0,
                   null, par);
                return l;
            }
        }
    }
}