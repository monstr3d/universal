using System;
using System.Collections.Generic;
using System.Text;

namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Solver of differential equations system
    /// </summary>
    public interface IDifferentialEquationSolver : IMeasurements, IStateDoubleVariables
    {
        /// <summary>
        /// Calculates derivations
        /// </summary>
        void CalculateDerivations();

        /// <summary>
        /// Copies variables from processor to solver 
        /// </summary>
        /// <param name="offset">Offset</param>
        /// <param name="variables">Vector of all desktop differential equations variables</param>
        void CopyVariablesToSolver(int offset, double[] variables);

     }
}
