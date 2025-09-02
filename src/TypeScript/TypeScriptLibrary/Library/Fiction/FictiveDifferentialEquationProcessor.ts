import { OwnNotImplemented } from "../ErrorHandler/OwnNotImplemented";
import { IDifferentialEquationProcessor } from "../Measurements/DifferentialEquations/Interfaces/IDifferentialEquationProcessor ";
import { IDifferentialEquationSolver } from "../Measurements/DifferentialEquations/Interfaces/IDifferentialEquationSolver";
import { ITimeMeasurementProvider } from "../Measurements/Interfaces/ITimeMeasurementProvider";

export class FictiveDifferentialEquationProcessor implements IDifferentialEquationProcessor {
    setDifferentialEquationProcessor(collection: any): void {
        throw new OwnNotImplemented();
    }
    getDifferentialEquations(): IDifferentialEquationSolver[] {
        throw new OwnNotImplemented();
    }
    addRangeDifferentialEquations(equations: IDifferentialEquationSolver[]): void {
        throw new OwnNotImplemented();
    }
    stepDifferentialEquations(start: number, finish: number): void {
        throw new OwnNotImplemented();
    }
    updateDimension(): void {
        throw new OwnNotImplemented();
    }
    getDifferentialEquationsTimeProvider(): ITimeMeasurementProvider {
        throw new OwnNotImplemented();
    }
    setDifferentialEquationsTimeProvider(time: ITimeMeasurementProvider): void {
        throw new OwnNotImplemented();
    }
    clearDifferentialEquations(): void {
        throw new OwnNotImplemented();
    }
    newDifferentialEquations(): IDifferentialEquationProcessor {
        throw new OwnNotImplemented();
   }

}