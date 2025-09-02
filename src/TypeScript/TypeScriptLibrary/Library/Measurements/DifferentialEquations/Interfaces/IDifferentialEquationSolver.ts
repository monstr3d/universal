import { ITimeMeasurementProvider } from "../../Interfaces/ITimeMeasurementProvider";

export interface IDifferentialEquationSolver
{
    /// <summary>
    /// Calculates derivations
    /// </summary>
   calculateDerivations(): void;

    /// <summary>
    /// Copies variables from processor to solver 
    /// </summary>
    /// <param name="offset">Offset</param>
    /// <param name="variables">Vector of all desktop differential equations variables</param>
    copyVariablesToSolver(offset: number, variables: number[]): void;

    ///
    /// Sets time provider
    ///
    setDifferentialEquationSolverTimeProvider(time: ITimeMeasurementProvider)  : void;

    //gets timer provider
    getDifferentialEquationSolverTimeProvider(): ITimeMeasurementProvider;


}

