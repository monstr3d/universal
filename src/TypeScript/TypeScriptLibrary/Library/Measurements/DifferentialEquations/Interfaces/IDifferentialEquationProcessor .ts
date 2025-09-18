/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import type { ITimeMeasurementProvider } from "../../Interfaces/ITimeMeasurementProvider";
import type { IDifferentialEquationSolver } from "./IDifferentialEquationSolver";

export interface IDifferentialEquationProcessor
{
   // setDifferentialEquationProcessor(collection: any): void;
    getDifferentialEquations(): IDifferentialEquationSolver[];
    addRangeDifferentialEquations(equations: IDifferentialEquationSolver[]): void;
    stepDifferentialEquations(start: number, finish: number): void;
    updateDimension(): void;
    getDifferentialEquationsTimeProvider(): ITimeMeasurementProvider;
    setDifferentialEquationsTimeProvider(time: ITimeMeasurementProvider): void;
    clearDifferentialEquations(): void;
    newDifferentialEquations(): IDifferentialEquationProcessor;

}