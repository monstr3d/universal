using DataPerformer.Interfaces;
using DataPerformer.Portable.DifferentialEquationProcessors;
using Diagram.UI.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Orbital.Forecast.MVC.WebApplication.Models
{
    public class ForecastWeb : GeneratedProject.Forecast
    {


        #region Fields

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
            atmosphere = GetObject("Atmosphere") as DinAtm.Portable.Atmosphere;
            atm = atmosphere;
            solver = GetObject("Motion equations") as DataPerformer.Formula.DifferentialEquationSolver;
            alias = solver;
            dataConsumer = GetObject("Chart") as DataPerformer.Portable.DataConsumer;
            wrapper = new DataPerformer.Portable.Wrappers.DataConsumerWrapper(dataConsumer);
        }

        internal DataPerformer.Portable.DataConsumer Consumer
        { get => dataConsumer; }

        [Required(ErrorMessage = "Start time")]
        public DateTime Time { get; set; } = DateTime.Now;

        /// <summary>
        /// X - coordinate
        /// </summary>
        [Required(ErrorMessage = "X - coordinate")]
        public double X
        {
            get => (double)alias["x"];
            set => alias["x"] = value;
        }

        /// <summary>
        /// Y - coordinate
        /// </summary>
        [Required(ErrorMessage = "Y - coordinate")]
        public double Y
        {
            get => (double)alias["y"];
            set => alias["y"] = value;
        }

        /// <summary>
        /// X - coordinate
        /// </summary>
        [Required(ErrorMessage = "Z - coordinate")]
        public double Z
        {
            get => (double)alias["z"];
            set => alias["z"] = value;
        }

        /// <summary>
        /// X - velocity
        /// </summary>
        [Required(ErrorMessage = "X - velocity")]
        public double Vx
        {
            get => (double)alias["u"];
            set => alias["u"] = value;
        }

        /// <summary>
        /// Y - velocity
        /// </summary>
        [Required(ErrorMessage = "Y - velocity")]
        public double Vy
        {
            get => (double)alias["v"];
            set => alias["v"] = value;
        }


        /// <summary>
        /// Z - velocity
        /// </summary>
        [Required(ErrorMessage = "Z - velocity")]
        public double Vz
        {
            get => (double)alias["w"];
            set => alias["w"] = value;
        }

        /// <summary>
        /// X - coordinate
        /// </summary>
        [Required(ErrorMessage = "Ballistic coefficient")]
        public double S
        {
            get => (double)alias["s"] * 100000000000;
            set => alias["s"] = value / 100000000000;
        }


        /// <summary>
        /// Atmospheric parameter F107A
        /// </summary>
        [Required(ErrorMessage = "Atmospheric parameter F107A")]
        public int F107A
        {
            get => (int)atm["F107A"];
            set => atm["F107A"] = value;
        }


        /// <summary>
        /// Atmospheric parameter F107A
        /// </summary>
        [Required(ErrorMessage = "Atmospheric parameter F107")]
        public int F107
        {
            get => (int)atm["F107"];
            set => atm["F107"] = value;
        }

        /// <summary>
        /// Atmospheric parameter F107A
        /// </summary>
        [Required(ErrorMessage = "Atmospheric parameter F107A")]
        public int Ap
        {
            get => (int)atm["Ap"];
            set => atm["Ap"] = value;
        }

        /// <summary>
        /// Count of steps
        /// </summary>
        [Required(ErrorMessage = "Count of steps")]
        public int Count
        { get; set; } = 1800;

        public List<List<object>> Values
        {
            get
            {
                var dt = Time.ToOADate();
                var l = wrapper.PerformFixed(dt, 1, Count,
                    new DataPerformer.Portable.Helpers.TimeMeasurementProvider(),
                    new RungeProcessor(),
                    StaticExtensionDataPerformerInterfaces.Calculation, 0,
                    "Recursive.z", ["Motion equations.x", "Motion equations.y"]);

                return l;
            }
        }
    }
}