using System;
using System.Collections.Generic;
using System.Text;

namespace OrdinaryDifferentialEquations
{
    public interface IDifferentialEquationSolver
    {
        /// <summary>
        /// System
        /// </summary>
        IDifferentialEquationsSystem System
        {
            get;
            set;
        }

 
        /// <summary>
        /// Performs step
        /// </summary>
        /// <param name="timeBegin">Begin time</param>
        /// <param name="timeEnd">End time</param>
        void Step(double timeBegin, double timeEnd);

        /// <summary>
        /// Names of solvers
        /// </summary>
        string[] Names
        {
            get;
        }

        /// <summary>
        /// Gers solver by name
        /// </summary>
        /// <param name="name">Name of solver</param>
        /// <returns>The solver</returns>
        IDifferentialEquationSolver this[string name]
        {
            get;
        }

    }
}
