using System;
using System.Collections.Generic;
using System.Text;

namespace OrdinaryDifferentialEquations
{
    /// <summary>
    /// Performer of differential equations
    /// </summary>
    public static class DifferentialEquationsPerformer
    {

        #region Fields

        /// <summary>
        /// Default differential equation solver
        /// </summary>
        static private IDifferentialEquationSolver def;


        #endregion

        #region Members

        /// <summary>
        /// Default differential equation solver
        /// </summary>
        public static IDifferentialEquationSolver Default
        {
            get
            {
                return def;
            }
            set
            {
                def = value;
            }
        }

        /// <summary>
        /// Initialization of differential equations system
        /// </summary>
        /// <param name="system">The system</param>
        public static void Initialize(IDifferentialEquationsSystem system)
        {
            Array.Copy(system.InitialState, system.State, system.InitialState.Length);
        }

        #endregion
    }
}
