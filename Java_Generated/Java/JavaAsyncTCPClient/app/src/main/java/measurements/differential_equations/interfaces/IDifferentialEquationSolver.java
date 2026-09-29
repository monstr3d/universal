package measurements.differential_equations.interfaces;

import measurements.time.interfaces.ITimeMeasurementProvider;

public interface IDifferentialEquationSolver {
    /// <summary>
    /// Calculates derivations
    /// </summary>
    void calculateDerivations();

    /// <summary>
    /// Copies variables from processor to solver
    /// </summary>
    /// <param name="offset">Offset</param>
    /// <param name="variables">Vector of all desktop differential equations variables</param>
    void copyVariablesToSolver(int offset, double[] variables);

    ///
    /// Sets time provider
    ///
    void setDifferentialEquationSolverTimeProvider(ITimeMeasurementProvider time);

    //gets timer provider
    ITimeMeasurementProvider getDifferentialEquationSolverTimeProvider();

}
