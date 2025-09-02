namespace OrdinaryDifferentialEquations
{
    /// <summary>
    /// System of differential equations
    /// </summary>
    public interface IDifferentialEquationsSystem
    {
        /// <summary>
        /// Initial state
        /// </summary>
        double[] InitialState
        {
            get;
        }

        /// <summary>
        /// Count of variables
        /// </summary>
        int Count
        {
            get;
        }


        /// <summary>
        /// State
        /// </summary>
        double[] State
        {
            get;
        }

        /// <summary>
        /// Calculates Variable
        /// </summary>
        /// <param name="time">Time</param>
        /// <param name="derivations">Derivations</param>
        void Calculate(double time, double[] derivations);
 
    }
}
