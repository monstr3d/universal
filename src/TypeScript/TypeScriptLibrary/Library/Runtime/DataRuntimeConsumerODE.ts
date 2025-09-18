/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */

import type { IDifferentialEquationProcessor } from "../Measurements/DifferentialEquations/Interfaces/IDifferentialEquationProcessor ";
import type { IDifferentialEquationSolver } from "../Measurements/DifferentialEquations/Interfaces/IDifferentialEquationSolver";
import type { IDataConsumer } from "../Measurements/Interfaces/IDataConsumer";
import type { ITimeMeasurementProvider } from "../Measurements/Interfaces/ITimeMeasurementProvider";
import { DataRuntimeConsumer } from "./DataRuntimeConsumer";

export class DataRuntimeConsumerODE extends DataRuntimeConsumer
{
    protected processor !: IDifferentialEquationProcessor;

    protected differentialEquations: IDifferentialEquationSolver[] = [];

    constructor(consumer: IDataConsumer, processor: IDifferentialEquationProcessor) {
        super(consumer);
        this.processor = processor.newDifferentialEquations();
        let equations: IDifferentialEquationSolver[] = [];
        for (let measurements of this.measurements)
        {
            if (this.performer.implementsType(measurements, "IDifferentialEquationSolver"))
            {
                let solver = measurements as unknown as IDifferentialEquationSolver;
                equations.push(solver);
            }
        }
        this.processor.addRangeDifferentialEquations(equations);
        this.processor.updateDimension();
    }

    setTimeProvider(timeProvider: ITimeMeasurementProvider): void {
        super.setTimeProvider(timeProvider);
        this.processor.setDifferentialEquationsTimeProvider(timeProvider);
    }


    stepRuntime(begin: number, end: number): void
    {
        this.processor.stepDifferentialEquations(begin, end);
    }

}