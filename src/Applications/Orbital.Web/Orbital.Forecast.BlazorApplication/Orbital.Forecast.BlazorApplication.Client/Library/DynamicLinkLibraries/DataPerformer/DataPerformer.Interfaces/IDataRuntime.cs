using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Runtime of data performer
    /// </summary>
    public interface IDataRuntime
    {

        /// <summary>
        /// Refreshes itself
        /// </summary>
        void Refresh();


        /// <summary>
        /// Starts all components
        /// </summary>
         /// <param name="time">Start time</param>
        void StartAll(double time);

        /// <summary>
        /// Updates all components
        /// </summary>
        void UpdateAll();

        /// <summary>
        /// Checks data consumer. Throws exceptions in case of fail
        /// </summary>
        /// <param name="dataConsumer">The data consumer</param>
        void Check(IDataConsumer dataConsumer);

        /// <summary>
        /// Gets differential solver from object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The solver</returns>
        IDifferentialEquationSolver GetDifferentialEquationSolver(object obj);

        /// <summary>
        /// Time
        /// </summary>
        double Time
        {
            get;
            set;
        }

        /// <summary>
        /// Provider of time measure
        /// </summary>
        ITimeMeasurementProvider TimeProvider
        {
            get;
            set;
        }

        /// <summary>
        /// All components of runtime
        /// </summary>
        IEnumerable<object> AllComponents
        {
            get;
        }
    }
}
