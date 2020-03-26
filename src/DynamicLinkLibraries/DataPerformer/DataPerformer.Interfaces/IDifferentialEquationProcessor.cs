using System;
using System.Collections.Generic;
using System.Text;

namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Processor of differential equations
    /// </summary>
    public interface IDifferentialEquationProcessor 
    {
        /// <summary>
        /// Sets consumers
        /// </summary>
        /// <param name="collection">Consumers</param>
        /// <returns>Lists of parameters</returns>
        void Set(object collection);

        /// <summary>
        /// Differential equations
        /// </summary>
        ICollection<IDifferentialEquationSolver> Equations
        {
            get;
        }

        /// <summary>
        /// Adds equations
        /// </summary>
        /// <param name="equations">Equations</param>
        void AddRange(ICollection<IDifferentialEquationSolver> equations);

        /// <summary>
        /// Performs step
        /// </summary>
        /// <param name="tStart">Start time</param>
        /// <param name="tFinish">Finish time</param>
        void Step(double tStart, double tFinish);

        /// <summary>
        /// Updates dimension
        /// </summary>
        void UpdateDimension();

        /// <summary>
        /// Updates measurements
        /// </summary>
        void UpdateMeasurements();

        /// <summary>
        /// Time provider
        /// </summary>
        ITimeMeasureProvider TimeProvider
        {
            get;
            set;
        }

        /// <summary>
        /// Clears all
        /// </summary>
        void Clear();

        /// <summary>
        /// Creates new processor
        /// </summary>
        IDifferentialEquationProcessor New
        {
            get;
        }
       
    }
}
